using Moldels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class cls_dal_Invoices
    {
        static string connectionString = cls_dal_Connections.connectionString;

        public static bool AddInvoice(
      cls_ml_Invoices invoice,
      List<cls_ml_InvoiceDetail> details,
      out string errorMessage)
        {
            errorMessage = "";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    // 1️⃣ إضافة الفاتورة
                    string invoiceQuery = @"
        INSERT INTO Invoices
        (
            ClientID,
            SupplierID,
            InvoiceType,
            Date,
            TotalAmount,
            DiscountAmount,
            NetAmount,
            PaymentMethode
        )
        VALUES
        (
            @ClientID,
            @SupplierID,
            @InvoiceType,
            @Date,
            @TotalAmount,
            @DiscountAmount,
            @NetAmount,
            @PaymentMethod
        );
        SELECT SCOPE_IDENTITY();";

                    int invoiceID;

                    using (SqlCommand cmdInvoice = new SqlCommand(invoiceQuery, con, transaction))
                    {
                        cmdInvoice.Parameters.Add("@ClientID", SqlDbType.Int)
                            .Value = invoice.ClientID > 0 ? invoice.ClientID : (object)DBNull.Value;

                        cmdInvoice.Parameters.Add("@SupplierID", SqlDbType.Int)
                            .Value = invoice.SupplierID > 0 ? invoice.SupplierID : (object)DBNull.Value;

                        cmdInvoice.Parameters.AddWithValue("@InvoiceType", invoice.InvoiceType);
                        cmdInvoice.Parameters.AddWithValue("@Date", invoice.Date);
                        cmdInvoice.Parameters.AddWithValue("@TotalAmount", invoice.TotalAmount);
                        cmdInvoice.Parameters.AddWithValue("@DiscountAmount", invoice.DiscountAmount);
                        cmdInvoice.Parameters.AddWithValue("@NetAmount", invoice.NetAmount);
                        cmdInvoice.Parameters.AddWithValue("@PaymentMethod", invoice.PaymentMethod);

                        invoiceID = Convert.ToInt32(cmdInvoice.ExecuteScalar());
                    }

                    // 2️⃣ تفاصيل الفاتورة + تعديل الكمية + دعم المنتجات الجديدة
                    foreach (var detail in details)
                    {
                        int productId = detail.ProductID;

                        // 🔹 إذا المنتج جديد (ProductID = -1) → إضافة المنتج أولاً
                        if (productId == -1)
                        {
                            string insertProduct = @"
            INSERT INTO Products
            (Reference, ProductName, ProductBrand, Cost, Price, isActive)
            VALUES (@Reference, @ProductName, @ProductBrand, @Cost, @Price,1);
            SELECT SCOPE_IDENTITY();";

                            using (SqlCommand cmdProduct = new SqlCommand(insertProduct, con, transaction))
                            {
                                cmdProduct.Parameters.AddWithValue("@Reference", detail.Reference ?? "");
                                cmdProduct.Parameters.AddWithValue("@ProductName", detail.ProductName ?? "");
                                cmdProduct.Parameters.AddWithValue("@ProductBrand", detail.ProductBrand ?? "");
                                cmdProduct.Parameters.AddWithValue("@Cost", detail.Cost);
                                cmdProduct.Parameters.AddWithValue("@Price", detail.UnitPrice);

                                productId = Convert.ToInt32(cmdProduct.ExecuteScalar());
                            }
                        }

                        // 🔥 تعديل الكمية حسب نوع الفاتورة
                        if (invoice.InvoiceType == "بيع")
                        {
                            cls_dal_Products.DecreaseProductQuantity(
                                productId,
                                detail.Quantity,
                                con,
                                transaction
                            );
                        }
                        else if (invoice.InvoiceType == "شراء")
                        {
                            cls_dal_Products.IncreaseProductQuantity(
                                productId,
                                detail.Quantity,
                                con,
                                transaction
                            );
                        }

                        // 🔹 إضافة التفاصيل إلى الجدول الصحيح
                        if (invoice.InvoiceType == "شراء")
                        {
                            // جدول المشتريات
                            string purchaseDetailQuery = @"
            INSERT INTO PurchasesInvoicesDetails
            (
                InvoiceID,
                ProductID,
                Cost,
                Quantity
            )
            VALUES
            (
                @InvoiceID,
                @ProductID,
                @Cost,
                @Quantity
            );";

                            using (SqlCommand cmdDetail = new SqlCommand(purchaseDetailQuery, con, transaction))
                            {
                                cmdDetail.Parameters.AddWithValue("@InvoiceID", invoiceID);
                                cmdDetail.Parameters.AddWithValue("@ProductID", productId);
                                cmdDetail.Parameters.AddWithValue("@Cost", detail.Cost);
                                cmdDetail.Parameters.AddWithValue("@Quantity", detail.Quantity);
                                cmdDetail.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            // جدول المبيعات
                            string saleDetailQuery = @"
            INSERT INTO InvoicesDetails
            (
                InvoiceID,
                ProductID,
                ProductPrice,
                Quantity,
                Discount,
                NetAmount
            )
            VALUES
            (
                @InvoiceID,
                @ProductID,
                @UnitPrice,
                @Quantity,
                @Discount,
                @NetAmount
            );";

                            using (SqlCommand cmdDetail = new SqlCommand(saleDetailQuery, con, transaction))
                            {
                                cmdDetail.Parameters.AddWithValue("@InvoiceID", invoiceID);
                                cmdDetail.Parameters.AddWithValue("@ProductID", productId);
                                cmdDetail.Parameters.AddWithValue("@UnitPrice", detail.UnitPrice);
                                cmdDetail.Parameters.AddWithValue("@Quantity", detail.Quantity);
                                cmdDetail.Parameters.AddWithValue("@Discount", detail.DiscountAmount);
                                cmdDetail.Parameters.AddWithValue("@NetAmount", detail.LineTotalAfterDiscount);
                                cmdDetail.ExecuteNonQuery();
                            }
                        }
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    errorMessage = ex.Message;
                    return false;
                }
            }
        }


        public static List<cls_vm_InvoiceList> GetInvoicesForUI(
string keyword,
string invoiceType,   // "بيع" أو "شراء"
DateTime? dateFrom,
DateTime? dateTo,
out string error)
        {
            error = string.Empty;
            List<cls_vm_InvoiceList> list = new List<cls_vm_InvoiceList>();

            try
            {
                using (SqlConnection conn = new SqlConnection(cls_dal_Connections.connectionString))
                {
                    conn.Open();

                    // جدول التفاصيل حسب نوع الفاتورة
                    string detailsTable = invoiceType == "شراء" ? "PurchasesInvoicesDetails" : "InvoicesDetails";

                    // الانضمام للعميل أو المورد
                    string clientSupplierJoin = invoiceType == "شراء"
                        ? "LEFT JOIN Suppliers s ON s.ID = i.SupplierID"
                        : "INNER JOIN Clients c ON c.ID = i.ClientID";

                    string clientSupplierName = invoiceType == "شراء" ? "s.Name" : "c.Name";

                    // أول 3 منتجات لكل فاتورة
                    var productsDict = new Dictionary<int, string>();
                    string productQuery = $@"
SELECT 
    d.InvoiceID,
    STUFF((
        SELECT TOP 3 ', ' + p.ProductName
        FROM {detailsTable} d2
        LEFT JOIN Products p ON p.ID = d2.ProductID
        WHERE d2.InvoiceID = d.InvoiceID
        ORDER BY d2.ID
        FOR XML PATH(''), TYPE
    ).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS Products
FROM {detailsTable} d
GROUP BY d.InvoiceID;
";

                    using (SqlCommand cmdProd = new SqlCommand(productQuery, conn))
                    using (SqlDataReader readerProd = cmdProd.ExecuteReader())
                    {
                        while (readerProd.Read())
                        {
                            productsDict.Add(
                                Convert.ToInt32(readerProd["InvoiceID"]),
                                readerProd["Products"].ToString()
                            );
                        }
                    }

                    // الاستعلام الرئيسي مع LEFT JOIN على تفاصيل الفاتورة والمنتجات
                    string query = $@"
SELECT 
    i.ID,
    {clientSupplierName} AS ClientSupplier,
    i.Date,
    i.TotalAmount,
    i.DiscountAmount,
    i.PaymentMethode
FROM Invoices i
{clientSupplierJoin}
LEFT JOIN {detailsTable} d ON d.InvoiceID = i.ID
LEFT JOIN Products p ON p.ID = d.ProductID
WHERE i.InvoiceType = @InvoiceType
  {(dateFrom.HasValue ? "AND i.Date >= @DateFrom" : "")}
  {(dateTo.HasValue ? "AND i.Date <= @DateTo" : "")}
  AND (@Keyword = '' OR p.ProductName LIKE '%' + @Keyword + '%')
GROUP BY i.ID, {clientSupplierName}, i.Date, i.TotalAmount, i.DiscountAmount, i.PaymentMethode
ORDER BY i.Date DESC;
";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@InvoiceType", invoiceType);
                        if (dateFrom.HasValue)
                            cmd.Parameters.AddWithValue("@DateFrom", dateFrom.Value.Date);
                        if (dateTo.HasValue)
                            cmd.Parameters.AddWithValue("@DateTo", dateTo.Value.Date);

                        cmd.Parameters.AddWithValue("@Keyword", string.IsNullOrWhiteSpace(keyword) ? "" : keyword);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int invoiceId = Convert.ToInt32(reader["ID"]);

                                list.Add(new cls_vm_InvoiceList
                                {
                                    InvoiceID = invoiceId,
                                    ClientOrSupplier = reader["ClientSupplier"] != DBNull.Value
                                        ? reader["ClientSupplier"].ToString()
                                        : string.Empty,
                                    Date = reader["Date"] != DBNull.Value
                                        ? (DateTime?)Convert.ToDateTime(reader["Date"])
                                        : null,
                                    TotalAmount = Convert.ToDecimal(reader["TotalAmount"]),
                                    DiscountAmount = Convert.ToDecimal(reader["DiscountAmount"]),
                                    NetAmount = Convert.ToDecimal(reader["TotalAmount"]) - Convert.ToDecimal(reader["DiscountAmount"]),
                                    Products = productsDict.ContainsKey(invoiceId) ? productsDict[invoiceId] : string.Empty
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return list;
        }











    }
}

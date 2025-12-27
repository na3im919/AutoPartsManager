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

                        // 🔹 إضافة التفاصيل إلى InvoicesDetails
                        string detailQuery = @"
                INSERT INTO InvoicesDetails
                (
                    InvoiceID,
                    ProductID,
                    ProductPrice,
                    Quantity
                )
                VALUES
                (
                    @InvoiceID,
                    @ProductID,
                    @UnitPrice,
                    @Quantity
                );";

                        using (SqlCommand cmdDetail = new SqlCommand(detailQuery, con, transaction))
                        {
                            cmdDetail.Parameters.AddWithValue("@InvoiceID", invoiceID);
                            cmdDetail.Parameters.AddWithValue("@ProductID", productId);
                            cmdDetail.Parameters.AddWithValue("@UnitPrice", detail.UnitPrice);
                            cmdDetail.Parameters.AddWithValue("@Quantity", detail.Quantity);
                            cmdDetail.ExecuteNonQuery();
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






    }
}

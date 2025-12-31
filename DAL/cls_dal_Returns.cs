using Moldels.ML_Returns;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class cls_dal_returns
    {
        static string connectionString = cls_dal_Connections.connectionString;

        // دالة لجلب بيانات الفاتورة (النوع والعميل/المورد)
        public static Tuple<string, string> GetInvoiceInfo(int invoiceId, out string error)
        {
            error = string.Empty;
            string invoiceType = "";
            string clientSupplierName = "";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                    SELECT i.InvoiceType, ISNULL(c.Name, s.Name) AS ClientSupplierName
                    FROM Invoices i
                    LEFT JOIN Clients c ON i.ClientID = c.ID
                    LEFT JOIN Suppliers s ON i.SupplierID = s.ID
                    WHERE i.ID = @InvoiceID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@InvoiceID", invoiceId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                invoiceType = reader["InvoiceType"].ToString();
                                clientSupplierName = reader["ClientSupplierName"].ToString();
                            }
                            else
                            {
                                error = "الفاتورة المحددة غير موجودة.";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return string.IsNullOrEmpty(error) ? Tuple.Create(invoiceType, clientSupplierName) : null;
        }

        // دالة لجلب كل المنتجات القابلة للإرجاع من فاتورة معينة
        public static List<ReturnProductModel> GetInvoiceProductsForReturn(int invoiceId, out string error)
        {
            error = string.Empty;
            var productsList = new List<ReturnProductModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // 1. جلب نوع الفاتورة أولاً
                    string invoiceTypeQuery = "SELECT InvoiceType FROM Invoices WHERE ID = @InvoiceID";
                    string invoiceType = "";
                    using (var cmd = new SqlCommand(invoiceTypeQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@InvoiceID", invoiceId);
                        invoiceType = cmd.ExecuteScalar()?.ToString() ?? "";
                    }

                    if (string.IsNullOrEmpty(invoiceType))
                    {
                        error = "لم يتم العثور على الفاتورة المحددة.";
                        return productsList;
                    }

                    // 2. بناء الاستعلام بناءً على نوع الفاتورة
                    string detailsTable = invoiceType == "شراء" ? "PurchasesInvoicesDetails" : "InvoicesDetails";
                    string priceColumn = invoiceType == "شراء" ? "pid.Cost" : "pid.ProductPrice";

                    string query = $@"
                    SELECT 
                        p.ID AS ProductID,
                        p.ProductName,
                        {priceColumn} AS Price,
                        pid.Quantity AS InvoiceQuantity,
                        ISNULL(SUM(rd.Quantity), 0) AS ReturnedQuantity,
                        pid.ID AS InvoiceDetailID
                    FROM {detailsTable} pid
                    INNER JOIN Products p ON p.ID = pid.ProductID
                    LEFT JOIN Returns r ON r.InvoiceID = pid.InvoiceID
                    LEFT JOIN ReturnsDetails rd ON rd.ReturnsID = r.ID AND rd.ProductID = p.ID
                    WHERE pid.InvoiceID = @InvoiceID
                    GROUP BY p.ID, p.ProductName, {priceColumn}, pid.Quantity, pid.ID
                    ORDER BY p.ProductName";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@InvoiceID", invoiceId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                productsList.Add(new ReturnProductModel
                                {
                                    ProductID = Convert.ToInt32(reader["ProductID"]),
                                    ProductName = reader["ProductName"].ToString(),
                                    Price = Convert.ToDecimal(reader["Price"]),
                                    InvoiceQuantity = Convert.ToInt32(reader["InvoiceQuantity"]),
                                    ReturnedQuantity = Convert.ToInt32(reader["ReturnedQuantity"]),
                                    ReturnQuantity = 0,
                                    IsSelected = false,
                                    InvoiceDetailID = Convert.ToInt32(reader["InvoiceDetailID"]) // <-- أضف هذا السطر
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

            return productsList;
        }

        // الدالة الرئيسية لحفظ المرتجع بالكامل (تستخدم معاملة transaction)
        public static bool SaveNewReturn(int invoiceId, List<ReturnDetailToSave> returnDetails, out string error)
        {
            error = string.Empty;
            int returnId = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. إنشاء سجل المرتجع الرئيسي
                            string returnQuery = @"
                            INSERT INTO Returns (InvoiceID, Date, TotalAmount, ReturnType, Status, ClientID, SupplierID)
                            OUTPUT INSERTED.ID
                            VALUES (@InvoiceID, GETDATE(), 0, @ReturnType, 'COMPLETED', 
                                    (SELECT ClientID FROM Invoices WHERE ID = @InvoiceID), 
                                    (SELECT SupplierID FROM Invoices WHERE ID = @InvoiceID))";

                            using (SqlCommand cmd = new SqlCommand(returnQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@InvoiceID", invoiceId);
                                cmd.Parameters.AddWithValue("@ReturnType", "SALE"); // يمكنك تمرير النوع كمعامل إذا لزم الأمر
                                returnId = (int)cmd.ExecuteScalar();
                            }

                            // 2. إضافة تفاصيل المرتجعات وتحديث المخزون
                            foreach (var detail in returnDetails)
                            {
                                // إضافة تفاصيل المنتج المرتجع
                                string detailQuery = @"
                                INSERT INTO ReturnsDetails (ReturnsID, ProductID, ProductPrice, Quantity, InvoiceDetailID)
                                VALUES (@ReturnsID, @ProductID, @ProductPrice, @Quantity, @InvoiceDetailID)";

                                using (SqlCommand cmd = new SqlCommand(detailQuery, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@ReturnsID", returnId);
                                    cmd.Parameters.AddWithValue("@ProductID", detail.ProductID);
                                    cmd.Parameters.AddWithValue("@ProductPrice", detail.ProductPrice);
                                    cmd.Parameters.AddWithValue("@Quantity", detail.Quantity);
                                    cmd.Parameters.AddWithValue("@InvoiceDetailID", detail.InvoiceDetailID);
                                    cmd.ExecuteNonQuery();
                                }

                                // تحديث كمية المنتج في المخزون
                                string updateProductQuery = @"
                                UPDATE Products 
                                SET Quantity = Quantity + @Quantity 
                                WHERE ID = @ProductID";

                                using (SqlCommand cmd = new SqlCommand(updateProductQuery, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@Quantity", detail.Quantity);
                                    cmd.Parameters.AddWithValue("@ProductID", detail.ProductID);
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            // 3. تحديث المبلغ الإجمالي للمرتجع
                            string updateTotalQuery = @"
                            UPDATE Returns 
                            SET TotalAmount = (
                                SELECT SUM(rd.Quantity * rd.ProductPrice) 
                                FROM ReturnsDetails rd 
                                WHERE rd.ReturnsID = @ReturnID
                            )
                            WHERE ID = @ReturnID";

                            using (SqlCommand cmd = new SqlCommand(updateTotalQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@ReturnID", returnId);
                                cmd.ExecuteNonQuery();
                            }

                            // 4. تأكيد المعاملة
                            transaction.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            // 5. التراجع عن المعاملة في حال حدوث أي خطأ
                            transaction.Rollback();
                            error = "فشل حفظ المرتجع: " + ex.Message;
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error = "خطأ في الاتصال بقاعدة البيانات: " + ex.Message;
                return false;
            }
        }

        public static List<ReturnHistoryModel> GetReturnsHistory(string returnType, out string error)
        {
            error = string.Empty;
            var returnsList = new List<ReturnHistoryModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                    SELECT 
                        r.ID AS ReturnID,
                        r.Date,
                        r.ReturnType,
                        r.TotalAmount,
                        r.Status,
                        r.InvoiceID,
                        ISNULL(c.Name, s.Name) AS ClientSupplierName
                    FROM Returns r
                    LEFT JOIN Clients c ON r.ClientID = c.ID
                    LEFT JOIN Suppliers s ON r.SupplierID = s.ID
                    WHERE r.ReturnType = @ReturnType
                    ORDER BY r.Date DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ReturnType", returnType);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                returnsList.Add(new ReturnHistoryModel
                                {
                                    ReturnID = Convert.ToInt32(reader["ReturnID"]),
                                    Date = Convert.ToDateTime(reader["Date"]),
                                    ReturnType = reader["ReturnType"].ToString(),
                                    ClientSupplierName = reader["ClientSupplierName"].ToString(),
                                    TotalAmount = Convert.ToDecimal(reader["TotalAmount"]),
                                    Status = reader["Status"].ToString(),
                                    InvoiceID = Convert.ToInt32(reader["InvoiceID"])
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

            return returnsList;
        }

        // دالة لجلب تفاصيل مرتجع معين
        public static List<ReturnDetailItemModel> GetReturnDetails(int returnId, out string error)
        {
            error = string.Empty;
            var detailsList = new List<ReturnDetailItemModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                    SELECT 
                        p.ProductName,
                        rd.ProductPrice,
                        rd.Quantity,
                        rd.Total
                    FROM ReturnsDetails rd
                    INNER JOIN Products p ON rd.ProductID = p.ID
                    WHERE rd.ReturnsID = @ReturnID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ReturnID", returnId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                detailsList.Add(new ReturnDetailItemModel
                                {
                                    ProductName = reader["ProductName"].ToString(),
                                    Price = Convert.ToDecimal(reader["ProductPrice"]),
                                    Quantity = Convert.ToInt32(reader["Quantity"]),
                                    Total = Convert.ToDecimal(reader["Total"])
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

            return detailsList;
        }
    }
}

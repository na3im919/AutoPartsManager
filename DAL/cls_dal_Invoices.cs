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

                    SqlCommand cmdInvoice = new SqlCommand(invoiceQuery, con, transaction);

                    // ClientID (NULL إذا لم يوجد)
                    if (invoice.ClientID > 0)
                        cmdInvoice.Parameters.Add("@ClientID", SqlDbType.Int).Value = invoice.ClientID;
                    else
                        cmdInvoice.Parameters.Add("@ClientID", SqlDbType.Int).Value = DBNull.Value;

                    // SupplierID (NULL إذا لم يوجد)
                    if (invoice.SupplierID > 0)
                        cmdInvoice.Parameters.Add("@SupplierID", SqlDbType.Int).Value = invoice.SupplierID;
                    else
                        cmdInvoice.Parameters.Add("@SupplierID", SqlDbType.Int).Value = DBNull.Value;

                    cmdInvoice.Parameters.AddWithValue("@InvoiceType", invoice.InvoiceType);
                    cmdInvoice.Parameters.AddWithValue("@Date", invoice.Date);
                    cmdInvoice.Parameters.AddWithValue("@TotalAmount", invoice.TotalAmount);
                    cmdInvoice.Parameters.AddWithValue("@DiscountAmount", invoice.DiscountAmount);
                    cmdInvoice.Parameters.AddWithValue("@NetAmount", invoice.NetAmount);
                    cmdInvoice.Parameters.AddWithValue("@PaymentMethod", invoice.PaymentMethod);

                    int invoiceID = Convert.ToInt32(cmdInvoice.ExecuteScalar());

                    // 2️⃣ إضافة تفاصيل الفاتورة
                    foreach (var detail in details)
                    {
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

                        SqlCommand cmdDetail = new SqlCommand(detailQuery, con, transaction);

                        cmdDetail.Parameters.AddWithValue("@InvoiceID", invoiceID);
                        cmdDetail.Parameters.AddWithValue("@ProductID", detail.ProductID);
                        cmdDetail.Parameters.AddWithValue("@UnitPrice", detail.UnitPrice);
                        cmdDetail.Parameters.AddWithValue("@Quantity", detail.Quantity);

                        cmdDetail.ExecuteNonQuery();
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

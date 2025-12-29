using Moldels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class cls_dal_reportes
    {
        static string connectionString = cls_dal_Connections.connectionString;

        public static List<cls_ml_Invoices> GetSalesReport(DateTime startDate, DateTime endDate, out string error_message)
        {
            error_message = string.Empty;

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"
                        SELECT ID, Date, TotalAmount, DiscountAmount
                        FROM Invoices
                        WHERE InvoiceType = 'بيع' AND Date >= @StartDate AND Date <= @EndDate  AND PaymentMethode = 'نقد'
                    ";
                    using(SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StartDate", startDate);
                        command.Parameters.AddWithValue("@EndDate", endDate);
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            List<cls_ml_Invoices> salesReports = new List<cls_ml_Invoices>();
                            while (reader.Read())
                            {
                                cls_ml_Invoices invoice = new cls_ml_Invoices
                                {
                                    ID = reader.GetInt32(0),
                                    Date = reader.GetDateTime(1),
                                    TotalAmount = reader.GetDecimal(2),
                                    DiscountAmount = reader.IsDBNull(3) ? 0 : reader.GetDecimal(3)
                                };

                                salesReports.Add(invoice);
                            }

                            return salesReports;
                        }
                    }
                }
                catch(Exception ex)
                {
                    error_message = ex.Message;
                    return null;
                }
            }

        }
    }
}

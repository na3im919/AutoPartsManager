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

        public static List<cls_ml_ProfitData> GetProfitReportData(
            DateTime startDate,
            DateTime endDate,
            out string error)
        {
            error = "";
            var profitDataList = new List<cls_ml_ProfitData>();

            string query = @"
    SELECT 
        inv.Date,
        p.ProductName,
        det.Quantity,
        det.ProductPrice AS SalePrice,
        p.Cost AS CostPrice,
        det.Total AS TotalRevenue,
        (det.Quantity * p.Cost) AS TotalCost,
        CAST(0 AS BIT) AS IsReturn
    FROM Invoices AS inv
    INNER JOIN InvoicesDetails AS det ON inv.ID = det.InvoiceID
    INNER JOIN Products AS p ON det.ProductID = p.ID
    WHERE inv.Date BETWEEN @StartDate AND @EndDate
      AND inv.InvoiceType = N'بيع'

    UNION ALL

    SELECT 
        r.Date,
        p.ProductName,
        (-rd.Quantity) AS Quantity,
        rd.ProductPrice AS SalePrice,
        p.Cost AS CostPrice,
        (-rd.Total) AS TotalRevenue,
        (-rd.Quantity * p.Cost) AS TotalCost,
        CAST(1 AS BIT) AS IsReturn
    FROM Returns AS r
    INNER JOIN ReturnsDetails AS rd ON r.ID = rd.ReturnsID
    INNER JOIN Products AS p ON rd.ProductID = p.ID
    WHERE r.Date BETWEEN @StartDate AND @EndDate
      AND r.ReturnType = N'بيع'

    ORDER BY Date DESC;
    ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            profitDataList.Add(new cls_ml_ProfitData
                            {
                                Date = reader.GetDateTime(reader.GetOrdinal("Date")),
                                ProductName = reader["ProductName"].ToString(),
                                Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                                SalePrice = reader.GetDecimal(reader.GetOrdinal("SalePrice")),
                                CostPrice = reader.GetDecimal(reader.GetOrdinal("CostPrice")),
                                TotalRevenue = reader.GetDecimal(reader.GetOrdinal("TotalRevenue")),
                                TotalCost = reader.GetDecimal(reader.GetOrdinal("TotalCost")),
                                IsReturn = reader.GetBoolean(reader.GetOrdinal("IsReturn"))
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error = "فشل تحميل بيانات تقرير الأرباح: " + ex.Message;
            }

            return profitDataList;
        }

        public static List<cls_ml_BestSellingProduct> GetTop10BestSellingProducts(
            DateTime startDate,
            DateTime endDate,
            out string error)
        {
            error = string.Empty;
            List<cls_ml_BestSellingProduct> list = new List<cls_ml_BestSellingProduct>();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"
                    SELECT TOP 10
                        p.ID AS ProductID,
                        p.ProductName,
                        SUM(det.Quantity) AS TotalQuantity,
                        SUM(det.Total) AS TotalRevenue,
                        SUM(det.Quantity * p.Cost) AS TotalCost
                    FROM Invoices inv
                    INNER JOIN InvoicesDetails det ON inv.ID = det.InvoiceID
                    INNER JOIN Products p ON det.ProductID = p.ID
                    WHERE inv.InvoiceType = 'بيع'
                      AND inv.Date BETWEEN @StartDate AND @EndDate
                    GROUP BY p.ID, p.ProductName
                    ORDER BY SUM(det.Quantity) DESC;
                    ";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(new cls_ml_BestSellingProduct
                        {
                            ProductID = Convert.ToInt32(reader["ProductID"]),
                            ProductName = reader["ProductName"].ToString(),
                            TotalQuantity = Convert.ToInt32(reader["TotalQuantity"]),
                            TotalRevenue = Convert.ToDecimal(reader["TotalRevenue"]),
                            TotalCost = Convert.ToDecimal(reader["TotalCost"])
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return list;
        }


        public static List<cls_ml_MostReturnedProduct> GetTop10MostReturnedProducts(
    DateTime startDate,
    DateTime endDate,
    out string error)
        {
            error = "";
            var list = new List<cls_ml_MostReturnedProduct>();

            string query = @"
    SELECT TOP 10
        p.ID AS ProductID,
        p.ProductName,
        SUM(rd.Quantity) AS TotalReturnedQuantity,
        SUM(rd.Total) AS TotalReturnedRevenue,
        SUM(rd.Quantity * p.Cost) AS TotalReturnedCost
    FROM Returns r
    INNER JOIN ReturnsDetails rd ON r.ID = rd.ReturnsID
    INNER JOIN Products p ON rd.ProductID = p.ID
    WHERE r.ReturnType = N'SALE'
      AND r.Status = N'COMPLETED'
      AND r.Date BETWEEN @StartDate AND @EndDate
    GROUP BY p.ID, p.ProductName
    ORDER BY SUM(rd.Quantity) DESC;
    ";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            list.Add(new cls_ml_MostReturnedProduct
                            {
                                ProductID = Convert.ToInt32(dr["ProductID"]),
                                ProductName = dr["ProductName"].ToString(),
                                TotalReturnedQuantity = Convert.ToInt32(dr["TotalReturnedQuantity"]),
                                TotalReturnedRevenue = Convert.ToDecimal(dr["TotalReturnedRevenue"]),
                                TotalReturnedCost = Convert.ToDecimal(dr["TotalReturnedCost"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error = "فشل تحميل Top 10 المنتجات الأكثر إرجاعًا: " + ex.Message;
            }

            return list;
        }




    }
}

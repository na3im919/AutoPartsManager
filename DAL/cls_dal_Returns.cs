using Moldels;
using Moldels.Returns;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class cls_dal_Returns
    {
        static string connectionString = cls_dal_Connections.connectionString;


        public static int AddReturn(
    cls_ml_Returns model,
    SqlConnection con,
    SqlTransaction tran)
        {
            string query = @"
        INSERT INTO Returns
        (InvoiceID, ReturnType, Status, ClientID, SupplierID, Date, TotalAmount)
        VALUES
        (@InvoiceID, @ReturnType, @Status, @ClientID, @SupplierID, @Date, @TotalAmount);
        SELECT SCOPE_IDENTITY();";

            using (SqlCommand cmd = new SqlCommand(query, con, tran))
            {
                cmd.Parameters.AddWithValue("@InvoiceID", model.InvoiceID);
                cmd.Parameters.AddWithValue("@ReturnType", model.ReturnType);
                cmd.Parameters.AddWithValue("@Status", model.Status);
                cmd.Parameters.AddWithValue("@ClientID", (object)model.ClientID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@SupplierID", (object)model.SupplierID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Date", model.Date);
                cmd.Parameters.AddWithValue("@TotalAmount", model.TotalAmount);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }


        public static void AddReturnDetail(
    cls_ml_ReturnDetails model,
    SqlConnection con,
    SqlTransaction tran)
        {
            string query = @"
        INSERT INTO ReturnsDetails
        (ReturnsID, InvoiceDetailID, ProductID, ProductPrice, Quantity, Notes)
        VALUES
        (@ReturnsID, @InvoiceDetailID, @ProductID, @ProductPrice, @Quantity, @Notes)";

            using (SqlCommand cmd = new SqlCommand(query, con, tran))
            {
                cmd.Parameters.AddWithValue("@ReturnsID", model.ReturnsID);
                cmd.Parameters.AddWithValue("@InvoiceDetailID", model.InvoiceDetailID);
                cmd.Parameters.AddWithValue("@ProductID", model.ProductID);
                cmd.Parameters.AddWithValue("@ProductPrice", model.ProductPrice);
                cmd.Parameters.AddWithValue("@Quantity", model.Quantity);
                cmd.Parameters.AddWithValue("@Notes", model.Notes ?? "");

                cmd.ExecuteNonQuery();
            }
        }


        public static void UpdateProductQuantityForReturn(
    int productId,
    int qty,
    string returnType,
    SqlConnection con,
    SqlTransaction tran)
        {
            string query = returnType == "بيع"
                ? "UPDATE Products SET Quantity = Quantity + @Qty WHERE ID = @ID"
                : "UPDATE Products SET Quantity = Quantity - @Qty WHERE ID = @ID";

            using (SqlCommand cmd = new SqlCommand(query, con, tran))
            {
                cmd.Parameters.AddWithValue("@Qty", qty);
                cmd.Parameters.AddWithValue("@ID", productId);
                cmd.ExecuteNonQuery();
            }
        }

        public static bool AddReturn(
    cls_ml_Returns header,
    List<cls_ml_ReturnDetails> details,
    out string error)
        {
            error = "";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();

                try
                {
                    int returnId = AddReturn(header, con, tran);

                    foreach (var item in details)
                    {
                        item.ReturnsID = returnId;
                        AddReturnDetail(item, con, tran);

                        UpdateProductQuantityForReturn(
                            item.ProductID,
                            item.Quantity,
                            header.ReturnType,
                            con,
                            tran);
                    }

                    tran.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    error = ex.Message;
                    return false;
                }
            }
        }

        public static List<cls_ml_ReturnsDisplay> GetAllReturns(out string error)
        {
            error = "";
            List<cls_ml_ReturnsDisplay> list = new List<cls_ml_ReturnsDisplay>();

            string query = @"
        SELECT 
            r.ID,
            r.InvoiceID,
            r.Date,
            r.ClientID,
            c.Name AS ClientName,
            r.SupplierID,
            s.Name AS SupplierName,
            r.Status,
            r.TotalAmount
        FROM Returns r
        LEFT JOIN Clients c ON r.ClientID = c.ID
        LEFT JOIN Suppliers s ON r.SupplierID = s.ID
        ORDER BY r.Date DESC";

            try
            {
                using (SqlConnection con = new SqlConnection(cls_dal_Connections.connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            list.Add(new cls_ml_ReturnsDisplay
                            {
                                ID = Convert.ToInt32(dr["ID"]),
                                InvoiceID = Convert.ToInt32(dr["InvoiceID"]),
                                Date = Convert.ToDateTime(dr["Date"]),

                                ClientID = dr["ClientID"] != DBNull.Value
                                    ? Convert.ToInt32(dr["ClientID"])
                                    : (int?)null,

                                ClientName = dr["ClientName"] != DBNull.Value
                                    ? dr["ClientName"].ToString()
                                    : "",

                                SupplierID = dr["SupplierID"] != DBNull.Value
                                    ? Convert.ToInt32(dr["SupplierID"])
                                    : (int?)null,

                                SupplierName = dr["SupplierName"] != DBNull.Value
                                    ? dr["SupplierName"].ToString()
                                    : "",

                                Status = dr["Status"].ToString(),
                                TotalAmount = Convert.ToDecimal(dr["TotalAmount"])
                            });
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


        public static List<cls_ml_ReturnDetails> GetReturnDetailsByInvoice(int invoiceID, out string error)
        {
            error = "";
            List<cls_ml_ReturnDetails> details = new List<cls_ml_ReturnDetails>();

            try
            {
                using (SqlConnection con = new SqlConnection(cls_dal_Connections.connectionString))
                {
                    con.Open();
                    string query = @"
                SELECT rd.ID, rd.ReturnsID, rd.InvoiceDetailID, rd.ProductID, rd.ProductPrice, rd.Quantity, rd.Notes
                FROM ReturnsDetails rd
                INNER JOIN Returns r ON r.ID = rd.ReturnsID
                WHERE r.InvoiceID = @InvoiceID";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@InvoiceID", invoiceID);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                details.Add(new cls_ml_ReturnDetails
                                {
                                    ID = Convert.ToInt32(dr["ID"]),
                                    ReturnsID = Convert.ToInt32(dr["ReturnsID"]),
                                    InvoiceDetailID = Convert.ToInt32(dr["InvoiceDetailID"]),
                                    ProductID = Convert.ToInt32(dr["ProductID"]),
                                    ProductPrice = Convert.ToDecimal(dr["ProductPrice"]),
                                    Quantity = Convert.ToInt32(dr["Quantity"]),
                                    Notes = dr["Notes"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return null;
            }

            return details;
        }

        public static List<cls_ml_ReturnDetails>  GetReturnsDeatailBy(int ReturnsID, out string error_message)
        {
            List<cls_ml_ReturnDetails> details = new List<cls_ml_ReturnDetails>();
            error_message = string.Empty;

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string query = @"SELECT p.ProductName, p.Price, rs.Quantity, rs.Notes, rs.Total FROM Products AS p INNER JOIN ReturnsDetails AS rs ON rs.ProductID = p.ID WHERE rs.ReturnsID = @ReturnsID";
                    connection.Open();
                    using(SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ReturnsID", ReturnsID);
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                string Notes = reader["Notes"] == DBNull.Value ? "" : reader["Notes"].ToString();
                                cls_ml_ReturnDetails detail = new cls_ml_ReturnDetails()
                                {
                                    ProductName = reader["ProductName"].ToString(),
                                    ProductPrice = Convert.ToDecimal(reader["Price"]),
                                    Quantity = Convert.ToInt32(reader["Quantity"]),
                                    Notes = Notes,
                                   Total = Convert.ToDecimal(reader["Total"])
                                };
                                details.Add(detail);
                            }
                        }
                    }

                }
                catch(Exception ex)
                {
                    error_message = ex.Message;
                }
            }


            return details;
        }

    }
} 

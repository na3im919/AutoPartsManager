using Moldels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class cls_dal_recomendations
    {
        static string connectionString = cls_dal_Connections.connectionString;

        public static bool AddRecommendation(cls_ml_Products product, out string error_message)
        {
            error_message = string.Empty;
            using (SqlConnection conn = new SqlConnection(cls_dal_Connections.connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO ProductsRecomendations (Reference, ProductName, ProductBrand, Quantity) " +
                                   "VALUES (@Reference, @ProductName, @ProductBrand,@Quantity)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Reference", product.Reference);
                        cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                        cmd.Parameters.AddWithValue("@ProductBrand", product.ProductBrand);
                        cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    error_message = ex.Message;
                    return false;
                }
            }
        }

        public static List<cls_ml_Products> GetRecommendedProducts(out string error_message)
        {
            error_message = string.Empty;
            List<cls_ml_Products> recomended = new List<cls_ml_Products>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM ProductsRecomendations";
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                string ProductBrand = reader["ProductBrand"] == DBNull.Value ? "" : reader["ProductBrand"].ToString();
                                string refference = reader["Refference"] == DBNull.Value ? "" : reader["Refference"].ToString();
                                cls_ml_Products product = new cls_ml_Products()
                                {
                                    ID = Convert.ToInt32(reader["ID"]),
                                    ProductName = reader["ProductName"].ToString(),
                                    ProductBrand = ProductBrand,
                                    Reference = refference,
                                    AlreadyRecomended = Convert.ToBoolean(reader["AlreadyRecomended"])
                                    
                                };
                                recomended.Add(product);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    error_message = ex.Message;
                }
            }
            return recomended;
        }
    }
}

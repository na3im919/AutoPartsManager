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

        public static bool AddRecommendation(cls_ml_Products product, bool isNew, out string error_message)
        {
            error_message = string.Empty;
            using (SqlConnection conn = new SqlConnection(cls_dal_Connections.connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO ProductsRecomendations 
                             (Refference, ProductName, ProductBrand, Quantity) 
                             VALUES (@Refference, @ProductName, @ProductBrand, @Quantity)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Refference", product.Reference);
                        cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                        cmd.Parameters.AddWithValue("@ProductBrand", product.ProductBrand);

                        // إذا كان المنتج جديد نضع الكمية من cls_ml_Products وإلا نضع 0
                        cmd.Parameters.AddWithValue("@Quantity", isNew ? product.Quantity : 0);

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
                                    AlreadyRecomended = Convert.ToBoolean(reader["AlreadyRecomended"]),
                                    Quantity = Convert.ToInt32(reader["Quantity"])
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
        public static bool UpdateRecommendedProduct(
            List<cls_ml_Products> products,
            out string error_message)
        {
            error_message = string.Empty;
            bool success = true;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"
                UPDATE ProductsRecomendations
                SET 
                    AlreadyRecomended = @AlreadyRecomended,
                    Quantity = @Quantity
                WHERE ID = @ID";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        foreach (var p in products)
                        {
                            cmd.Parameters.Clear();

                            cmd.Parameters.AddWithValue("@AlreadyRecomended", p.AlreadyRecomended);
                            cmd.Parameters.AddWithValue("@Quantity", p.Quantity);
                            cmd.Parameters.AddWithValue("@ID", p.ID);

                            int result = cmd.ExecuteNonQuery();
                            if (result == 0)
                                success = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    error_message = ex.Message;
                    success = false;
                }
            }

            return success;
        }


        public static bool DeleteRecommendedProduct(int productId, out string errorMessage)
        {
            errorMessage = string.Empty;
            bool success = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "DELETE FROM ProductsRecomendations WHERE ID = @ID";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", productId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        success = rowsAffected > 0;

                        if (!success)
                        {
                            errorMessage = "لم يتم العثور على المنتج للحذف.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    errorMessage = ex.Message;
                }
            }

            return success;
        }
    }
}

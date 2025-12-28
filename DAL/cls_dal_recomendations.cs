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
        string connectionString = cls_dal_Connections.connectionString;

        public static bool AddRecommendation(cls_ml_Products product, out string error_message)
        {
            error_message = string.Empty;
            using(SqlConnection conn = new SqlConnection(cls_dal_Connections.connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO ProductsRecomendations (Reference, ProductName, ProductBrand, Quantity) " +
                                   "VALUES (@Reference, @ProductName, @ProductBrand,@Quantity)";
                    using(SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Reference", product.Reference);
                        cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                        cmd.Parameters.AddWithValue("@ProductBrand", product.ProductBrand);
                        cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
                catch(Exception ex)
                {
                    error_message = ex.Message;
                    return false;
                }
            }
        }
    }
}

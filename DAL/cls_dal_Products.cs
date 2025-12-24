using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moldels;

namespace DAL
{
    public class cls_dal_Products
    {
        static string connectionString = cls_dal_Connections.connectionString;
        public static List<cls_ml_Products> GetProductsByKeyword(string kw, string invoiceType, out string error_message)
        {
            error_message = string.Empty;
            List<cls_ml_Products> products = new List<cls_ml_Products>();

            // شرط Quantity فقط إذا كانت الفاتورة من نوع بيع
            string quantityCondition = invoiceType == "بيع" ? "AND Quantity > 0" : "";

            string query = "SELECT * FROM Products WHERE isActive = 1 AND (Reference LIKE @Keyword OR ProductName LIKE @Keyword OR ProductBrand LIKE @Keyword) "
                           + quantityCondition;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Keyword", "%" + kw + "%");

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                products.Add(new cls_ml_Products
                                {
                                    ID = Convert.ToInt32(reader["ID"]),
                                    ProductName = reader["ProductName"].ToString(),
                                    ProductBrand = reader["ProductBrand"].ToString(),
                                    Reference = reader["Reference"].ToString(),
                                    Price = Convert.ToDecimal(reader["Price"]),
                                    Quantity = Convert.ToInt32(reader["Quantity"]),
                                    Cost = Convert.ToDecimal(reader["Cost"]),
                                    isActive = Convert.ToBoolean(reader["isActive"])
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        error_message = ex.Message;
                    }
                }
            }

            return products;
        }


        /// <summary>
        /// إرجاع الكمية المتاحة للمنتج حسب ID
        /// </summary>
        public static int GetAvailableQuantity(int productId, out string error_message)
        {
            int availableQuantity = 0;
            error_message = string.Empty;

            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                string query = "SELECT Quantity FROM Products WHERE ID = @ProductID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ProductID", productId);

                con.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    availableQuantity = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                error_message = ex.Message;
            }
            finally
            {
                con.Close();
            }

            return availableQuantity;
        }

        public static void DecreaseProductQuantity(
    int productId,
    int quantity,
    SqlConnection con,
    SqlTransaction transaction)
        {
            string query = @"
        UPDATE Products
        SET Quantity = Quantity - @Qty
        WHERE ID = @ProductID AND Quantity >= @Qty";

            using (SqlCommand cmd = new SqlCommand(query, con, transaction))
            {
                cmd.Parameters.AddWithValue("@Qty", quantity);
                cmd.Parameters.AddWithValue("@ProductID", productId);

                int affectedRows = cmd.ExecuteNonQuery();

                if (affectedRows == 0)
                    throw new Exception("الكمية غير كافية للمنتج");
            }
        }


        public static void IncreaseProductQuantity(
    int productId,
    int quantity,
    SqlConnection con,
    SqlTransaction transaction)
        {
            string query = @"
        UPDATE Products
        SET Quantity = Quantity + @Qty
        WHERE ID = @ProductID";

            using (SqlCommand cmd = new SqlCommand(query, con, transaction))
            {
                cmd.Parameters.AddWithValue("@Qty", quantity);
                cmd.Parameters.AddWithValue("@ProductID", productId);

                int affectedRows = cmd.ExecuteNonQuery();

                if (affectedRows == 0)
                    throw new Exception("تعذر زيادة كمية المنتج. تحقق من وجود المنتج.");
            }
        }


    }
}

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

        public static List<cls_ml_Products> GetAllProducts(
            string kw,
            bool isActive,
            bool zero_quantity,
            out string error_message)
        {
            error_message = string.Empty;
            List<cls_ml_Products> Products = new List<cls_ml_Products>();

            // شرط حالة المنتج
            string productStatus = isActive ? "isActive = 1" : "isActive = 0";

            // بناء الاستعلام الأساسي
            string query = "SELECT * FROM Products WHERE " + productStatus;

            // ✅ شرط الكمية = 0 (فقط للمنتجات النشطة)
            if (zero_quantity)
            {
                query += " AND Quantity = 0";
            }

            // شرط البحث بالكلمة المفتاحية
            if (!string.IsNullOrEmpty(kw))
            {
                query += " AND (Reference LIKE @Keyword OR ProductName LIKE @Keyword OR ProductBrand LIKE @Keyword)";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                if (!string.IsNullOrEmpty(kw))
                {
                    command.Parameters.AddWithValue("@Keyword", "%" + kw + "%");
                }

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cls_ml_Products product = new cls_ml_Products
                            {
                                ID = (int)reader["ID"],
                                Reference = reader["Reference"] != DBNull.Value ? reader["Reference"].ToString() : string.Empty,
                                ProductName = reader["ProductName"] != DBNull.Value ? reader["ProductName"].ToString() : string.Empty,
                                ProductBrand = reader["ProductBrand"] != DBNull.Value ? reader["ProductBrand"].ToString() : string.Empty,
                                Cost = reader["Cost"] != DBNull.Value ? Convert.ToDecimal(reader["Cost"]) : 0,
                                Price = reader["Price"] != DBNull.Value ? Convert.ToDecimal(reader["Price"]) : 0,
                                Quantity = reader["Quantity"] != DBNull.Value ? Convert.ToInt32(reader["Quantity"]) : 0
                            };

                            Products.Add(product);
                        }
                    }
                }
                catch (Exception ex)
                {
                    error_message = ex.Message;
                }
            }

            return Products;
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


        public static bool SetInactive(int productId, out string error)
        {
            error = string.Empty;
             

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"
                UPDATE Products
                SET IsActive = 0
                WHERE ID = @ID";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ID", productId);
                        con.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }


        public static bool SetActive(int productId, out string error)
        {
            error = string.Empty;


            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"
                UPDATE Products
                SET IsActive = 1
                WHERE ID = @ID";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ID", productId);
                        con.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
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

        public static int GetProductIdByReference(string reference)
        {
            if (string.IsNullOrWhiteSpace(reference))
                return -1;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT ID 
            FROM Products 
            WHERE Reference = @Reference
        ";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Reference", reference);

                    con.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int productId))
                        return productId;
                    else
                        return -1;
                }
            }
        }

        public static int AddProduct(
    cls_ml_Products product,
    SqlConnection con,
    SqlTransaction tran)
        {
            string query = @"
        INSERT INTO Products
        (Reference, ProductName, ProductBrand, Cost, Price, Quantity, isActive)
        OUTPUT INSERTED.ID
        VALUES
        (@Reference, @ProductName, @ProductBrand, @Cost, @Price, @Quantity, @isActive)
    ";

            using (SqlCommand cmd = new SqlCommand(query, con, tran))
            {
                cmd.Parameters.AddWithValue("@Reference", product.Reference);
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@ProductBrand", product.ProductBrand);
                cmd.Parameters.AddWithValue("@Cost", product.Cost);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
                cmd.Parameters.AddWithValue("@isActive", true);

                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }


    }
}

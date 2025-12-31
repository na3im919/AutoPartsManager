using Moldels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class cls_dal_Clients
    {
        static string connectionString = cls_dal_Connections.connectionString;


        public static List<cls_ml_Clients> GetActiveClients(out string error_message)
        {
            error_message = string.Empty;
            List<cls_ml_Clients> clients = new List<cls_ml_Clients>();

            string query = @"
        SELECT 
            ID,
            Name,
            Phone,
            Address,
            isActive
        FROM Clients
        WHERE isActive = 1";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cls_ml_Clients client = new cls_ml_Clients
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Name = reader["Name"].ToString(),
                                Phone = reader["Phone"].ToString(),
                                Address = reader["Address"].ToString(),
                                IsActive = Convert.ToBoolean(reader["isActive"])
                            };

                            clients.Add(client);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error_message = ex.Message;
            }

            return clients;
        }

        public static List<cls_ml_Clients> GetClients(string keyword, bool isActive, out string error_message)
        {
            error_message = string.Empty;
            List<cls_ml_Clients> clients = new List<cls_ml_Clients>();

            string query = @"
        SELECT 
            ID,
            Name,
            Phone,
            Address,
            isActive
        FROM Clients
        WHERE isActive = @IsActive
          AND (Name LIKE @Keyword OR Phone LIKE @Keyword OR Address LIKE @Keyword)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IsActive", isActive);
                    command.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cls_ml_Clients client = new cls_ml_Clients
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Name = reader["Name"].ToString(),
                                Phone = reader["Phone"].ToString(),
                                Address = reader["Address"].ToString(),
                                IsActive = Convert.ToBoolean(reader["isActive"])
                            };

                            clients.Add(client);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error_message = ex.Message;
            }

            return clients;
        }

        public static bool DeleteClient(int clientId, out string error_message)
        {
            error_message = string.Empty;
            bool success = false;

            string query = @"
                UPDATE Clients
                SET isActive = 0
                WHERE ID = @ClientID
            ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClientID", clientId);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    success = rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                error_message = "فشل حذف العميل: " + ex.Message;
            }

            return success;
        }
    } 
}


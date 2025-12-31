using Moldels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class cls_dal_Suppliers
    {
        static string connectionString = cls_dal_Connections.connectionString;

        public static List<cls_ml_Suppliers> GetActiveSuppliers(out string error_message)
        {
            error_message = string.Empty;
            List<cls_ml_Suppliers> suppliers = new List<cls_ml_Suppliers>();

            string query = @"
                SELECT 
                    ID,
                    Name,
                    Phone,
                    Address,
                    isActive
                FROM Suppliers
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
                            cls_ml_Suppliers supplier = new cls_ml_Suppliers
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Name = reader["Name"].ToString(),
                                Phone = reader["Phone"].ToString(),
                                Address = reader["Address"].ToString(),
                                isActive = Convert.ToBoolean(reader["isActive"])
                            };

                            suppliers.Add(supplier);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error_message = ex.Message;
            }

            return suppliers;
        }


        public static List<cls_ml_Suppliers> GetSuppliers(string keyword, bool isActive, out string error_message)
        {
            error_message = string.Empty;
            List<cls_ml_Suppliers> suppliers = new List<cls_ml_Suppliers>();

            string query = @"
                SELECT ID, Name, Phone, Address, isActive
                FROM Suppliers
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
                            suppliers.Add(new cls_ml_Suppliers
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Name = reader["Name"].ToString(),
                                Phone = reader["Phone"].ToString(),
                                Address = reader["Address"].ToString(),
                                isActive = Convert.ToBoolean(reader["isActive"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error_message = ex.Message;
            }

            return suppliers;
        }

        public static bool AddSupplier(cls_ml_Suppliers supplier, out string error_message)
        {
            error_message = string.Empty;
            bool isSuccess = false;

            string query = @"
                INSERT INTO Suppliers (Name, Phone, Address, isActive)
                VALUES (@Name, @Phone, @Address, @IsActive)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", supplier.Name);
                    command.Parameters.AddWithValue("@Phone", supplier.Phone ?? string.Empty);
                    command.Parameters.AddWithValue("@Address", supplier.Address ?? string.Empty);
                    command.Parameters.AddWithValue("@IsActive", supplier.isActive);

                    connection.Open();
                    isSuccess = command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                error_message = ex.Message;
            }

            return isSuccess;
        }

        public static bool UpdateSupplier(cls_ml_Suppliers supplier, out string error_message)
        {
            error_message = string.Empty;
            bool isSuccess = false;

            string query = @"
                UPDATE Suppliers
                SET Name = @Name,
                    Phone = @Phone,
                    Address = @Address
                WHERE ID = @ID";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", supplier.Name);
                    command.Parameters.AddWithValue("@Phone", supplier.Phone ?? string.Empty);
                    command.Parameters.AddWithValue("@Address", supplier.Address ?? string.Empty);
                    command.Parameters.AddWithValue("@ID", supplier.ID);

                    connection.Open();
                    isSuccess = command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                error_message = ex.Message;
            }

            return isSuccess;
        }

        public static bool DeleteSupplier(int supplierID, out string error_message)
        {
            error_message = string.Empty;
            bool isSuccess = false;

            string query = "UPDATE Suppliers SET isActive = 0 WHERE ID = @ID";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", supplierID);
                    connection.Open();
                    isSuccess = command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                error_message = ex.Message;
            }

            return isSuccess;
        }

        public static bool RestoreSupplier(int supplierID, out string error_message)
        {
            error_message = string.Empty;
            bool isSuccess = false;

            string query = "UPDATE Suppliers SET isActive = 1 WHERE ID = @ID";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", supplierID);
                    connection.Open();
                    isSuccess = command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                error_message = ex.Message;
            }

            return isSuccess;
        }

        public static cls_ml_Suppliers GetSupplierByID(int supplierID, out string error_message)
        {
            error_message = string.Empty;
            cls_ml_Suppliers supplier = null;

            string query = "SELECT ID, Name, Phone, Address, isActive FROM Suppliers WHERE ID = @ID";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", supplierID);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            supplier = new cls_ml_Suppliers
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Name = reader["Name"].ToString(),
                                Phone = reader["Phone"].ToString(),
                                Address = reader["Address"].ToString(),
                                isActive = Convert.ToBoolean(reader["isActive"])
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error_message = ex.Message;
            }

            return supplier;
        }
    }
}

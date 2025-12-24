using Moldels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}


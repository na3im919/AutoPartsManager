using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class cls_dal_security
    {
        static string connectionString = cls_dal_Connections.connectionString;
        public static string GetStoredHardwareHash()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd =
                new SqlCommand("SELECT TOP 1 HardwareHash FROM AppLicense", con))
            {
                con.Open();
                object result = cmd.ExecuteScalar();
                return result?.ToString();
            }
        }

        // 🔹 حفظ الهاردوير هاش (أول مرة فقط)
        public static void SaveHardwareHash(string hardwareHash)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd =
                new SqlCommand("INSERT INTO AppLicense (HardwareHash) VALUES (@hash)", con))
            {
                cmd.Parameters.AddWithValue("@hash", hardwareHash);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

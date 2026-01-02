using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moldels;

namespace DAL
{
    public class cls_dal_Connections
    {

        public static string connectionString =
@"Data Source=(LocalDB)\MSSQLLocalDB;
Initial Catalog=AutoPartsManager;
AttachDbFilename=|DataDirectory|\AutoPartsManager.mdf;
Integrated Security=True;";


        /// <summary>
        /// استخدم هذا الاتصال في جميع الدوال
        /// بعد أن تم Attach القاعدة أول مرة
        /// </summary>
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(DatabaseManager.GetConnectionString());
        }

        // public static string connectionString = "Server=.;Database=AutoPartsManager;User Id=sa;Password=123456;";
        //public static string connectionString = "Server=(localdb)\\mssqllocaldb;Database=AutoPartsManager;Integrated Security=True;";



    }
}

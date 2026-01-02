using System;
using System.Data.SqlClient;
using System.IO;

namespace DAL
{
    public static class DatabaseManager
    {
        // اسم القاعدة داخل LocalDB
        private static string databaseName = "AutoPartsManager";

        // المجلد الذي سيحفظ فيه قاعدة البيانات
        private static string dataFolder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments),
            "AutoPartsManager",
            "Data");

        // المسار النهائي للملف MDF
        private static string mdfPath = Path.Combine(dataFolder, "AutoPartsManager.mdf");

        /// <summary>
        /// يستدعى عند تشغيل البرنامج لأول مرة
        /// ينشئ المجلد إذا لم يكن موجود
        /// ينسخ قاعدة البيانات إذا لم تكن موجودة
        /// يربطها بـ LocalDB
        /// </summary>
        public static void InitializeDatabase()
        {
            // إنشاء المجلد
            Directory.CreateDirectory(dataFolder);

            // نسخ MDF من مجلد البرنامج إذا لم يكن موجود
            if (!File.Exists(mdfPath))
            {
                string sourceFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AutoPartsManager.mdf");
                if (!File.Exists(sourceFile))
                    throw new FileNotFoundException("File AutoPartsManager.mdf not found in program folder.", sourceFile);

                File.Copy(sourceFile, mdfPath);
            }

            // Attach القاعدة فقط إذا لم تكن موجودة مسبقًا داخل LocalDB
            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True"))
            {
                conn.Open();

                string sql = $@"
IF DB_ID('{databaseName}') IS NULL
    CREATE DATABASE [{databaseName}]
    ON (FILENAME = '{mdfPath}')
    FOR ATTACH;
";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// الاتصال بالقاعدة بعد أول Attach
        /// يستخدم Initial Catalog فقط
        /// </summary>
        public static string GetConnectionString()
        {
            return $@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog={databaseName};Integrated Security=True;";
        }
    }
}

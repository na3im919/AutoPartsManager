using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms; // تأكد من إضافة هذا using إذا كنت تستخدم WinForms

public static class DatabaseHelper
{
    public static void EnsureDatabaseExists()
    {
        // سلسلة الاتصال بخادم LocalDB دون تحديد قاعدة بيانات
        string masterConnectionString = "Server=(localdb)\\MSSQLLocalDB;Integrated Security=True;";
        string dbName = "AutoPartsManager";

        try
        {
            // 1. التحقق من وجود قاعدة البيانات
            using (SqlConnection connection = new SqlConnection(masterConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand($"SELECT database_id FROM sys.databases WHERE Name = '{dbName}'", connection);
                object result = cmd.ExecuteScalar();

                // إذا كانت النتيجة ليست null، فهذا يعني أن قاعدة البيانات موجودة، نخرج من الدالة
                if (result != null)
                {
                    return;
                }
            }

            // 2. إذا لم تكن قاعدة البيانات موجودة، قم باستعادتها
            RestoreDatabase(masterConnectionString, dbName);

        }
        catch (Exception ex)
        {
            MessageBox.Show($"حدث خطأ أثناء التحقق من قاعدة البيانات: {ex.Message}", "خطأ في قاعدة البيانات", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(1); // إغلاق التطبيق في حالة حدوث خطأ جسيم
        }
    }

    private static void RestoreDatabase(string masterConnectionString, string dbName)
    {
        // المسار إلى ملف النسخة الاحتياطية بجانب ملف التطبيق
        string backupFilePath = Path.Combine(Application.StartupPath, "Resources", "AutoPartsManager.bak");

        // المسارات التي سيتم فيها إنشاء ملفات قاعدة البيانات الجديدة
        string dataFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"AutoPartsManager.mdf");
        string logFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"AutoPartsManager_log.ldf");

        if (!File.Exists(backupFilePath))
        {
            MessageBox.Show($"ملف النسخة الاحتياطية للقاعدة غير موجود في المسار المتوقع: {backupFilePath}", "ملف مفقود", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        try
        {
            // إغلاق جميع الاتصالات المحتملة لضمان عدم وجود ملفات مستخدمة
            SqlConnection.ClearAllPools();

            using (SqlConnection connection = new SqlConnection(masterConnectionString))
            {
                connection.Open();

                // أمر SQL لاستعادة قاعدة البيانات
                string restoreQuery = $@"
                    RESTORE DATABASE [{dbName}] 
                    FROM DISK = '{backupFilePath}' 
                    WITH MOVE 'AutoPartsManager' TO '{dataFilePath}',
                         MOVE 'AutoPartsManager_log' TO '{logFilePath}',
                         REPLACE;";

                SqlCommand cmd = new SqlCommand(restoreQuery, connection);
                cmd.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"فشل استعادة قاعدة البيانات: {ex.Message}", "خطأ في الاستعادة", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(1);
        }
    }
}
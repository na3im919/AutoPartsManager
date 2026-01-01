using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class cls_dal_DB
    {
        static string connectionString = cls_dal_Connections.connectionString;

        public static string ResetDatabase(out string error_message)
        {
            error_message = string.Empty;
            string resetScript = @"
            USE [AutoPartsManager];
            SET NOCOUNT ON;

            -- الخطوة 1: تعطيل جميع القيود (Foreign Keys)
            DECLARE @sql NVARCHAR(MAX);
            DECLARE cursor_fk CURSOR FOR
            SELECT 'ALTER TABLE [dbo].[' + OBJECT_NAME(f.parent_object_id) + '] NOCHECK CONSTRAINT [' + f.name + ']'
            FROM sys.foreign_keys AS f;

            OPEN cursor_fk;
            FETCH NEXT FROM cursor_fk INTO @sql;
            WHILE @@FETCH_STATUS = 0
            BEGIN
                EXEC sp_executesql @sql;
                FETCH NEXT FROM cursor_fk INTO @sql;
            END
            CLOSE cursor_fk;
            DEALLOCATE cursor_fk;

            -- الخطوة 2: حذف البيانات من الجداول بالترتيب الصحيح
            DELETE FROM [dbo].[ReturnsDetails];
            DELETE FROM [dbo].[PurchasesInvoicesDetails];
            DELETE FROM [dbo].[InvoicesDetails];
            DELETE FROM [dbo].[Returns];
            DELETE FROM [dbo].[Invoices];
            DELETE FROM [dbo].[Products];
            DELETE FROM [dbo].[ProductsRecomendations];
            DELETE FROM [dbo].[Clients] WHERE ID <> 1;
            DELETE FROM [dbo].[Suppliers] WHERE ID <> 1;

            -- الخطوة 3: إعادة تعيين عدّد الهوية (IDENTITY)
            DBCC CHECKIDENT ('[dbo].[ReturnsDetails]', RESEED, 0);
            DBCC CHECKIDENT ('[dbo].[PurchasesInvoicesDetails]', RESEED, 0);
            DBCC CHECKIDENT ('[dbo].[InvoicesDetails]', RESEED, 0);
            DBCC CHECKIDENT ('[dbo].[Returns]', RESEED, 0);
            DBCC CHECKIDENT ('[dbo].[Invoices]', RESEED, 0);
            DBCC CHECKIDENT ('[dbo].[Products]', RESEED, 0);
            DBCC CHECKIDENT ('[dbo].[ProductsRecomendations]', RESEED, 0);
            DBCC CHECKIDENT ('[dbo].[Clients]', RESEED, 1);
            DBCC CHECKIDENT ('[dbo].[Suppliers]', RESEED, 1);

            -- الخطوة 4: إعادة تفعيل جميع القيود (Foreign Keys)
            DECLARE cursor_fk_check CURSOR FOR
            SELECT 'ALTER TABLE [dbo].[' + OBJECT_NAME(f.parent_object_id) + '] WITH CHECK CHECK CONSTRAINT [' + f.name + ']'
            FROM sys.foreign_keys AS f;

            OPEN cursor_fk_check;
            FETCH NEXT FROM cursor_fk_check INTO @sql;
            WHILE @@FETCH_STATUS = 0
            BEGIN
                EXEC sp_executesql @sql;
                FETCH NEXT FROM cursor_fk_check INTO @sql;
            END
            CLOSE cursor_fk_check;
            DEALLOCATE cursor_fk_check;
        ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(resetScript, connection))
                    {
                        // تعيين نوع الأمر إلى Text لتنفيذ نص SQL مباشرة
                        command.CommandType = CommandType.Text;

                        connection.Open();
                        command.ExecuteNonQuery(); // ExecuteNonQuery مناسب لأوامر DDL مثل DELETE و DBCC
                    }
                }
                return "تمت إعادة تعيين قاعدة البيانات بنجاح.";
            }
            catch (SqlException ex)
            {
                // إرجاع رسالة الخطأ من SQL Server
                return "فشلت عملية إعادة التعيين. خطأ في قاعدة البيانات: " + ex.Message;
            }
            catch (Exception ex)
            {
                // إرجاع رسالة الخطأ العامة
                return "فشلت عملية إعادة التعيين. خطأ عام: " + ex.Message;
            }
        }



        public static bool BackupDatabase(string backupPath, out string error_message)
        {
            error_message = string.Empty;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    connection.Open();

                    // استبدل "AutoPartsManager" باسم قاعدة البيانات لديك
                    command.CommandText = $@"BACKUP DATABASE [AutoPartsManager] TO DISK = '{backupPath}' WITH INIT, STATS = 10";
                    command.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                error_message = ex.Message;
                return false;
            }
        }

        public static bool RestoreDatabase(string backupFilePath, out string error_message)
        {
            error_message = string.Empty;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString)) // الاتصال بالـ master DB
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    connection.Open();

                    // الانتقال إلى قاعدة البيانات الرئيسية
                    command.CommandText = "USE master";
                    command.ExecuteNonQuery();

                    // 1️⃣ وضع قاعدة البيانات في وضع SINGLE_USER وإلغاء أي جلسات نشطة
                    command.CommandText = @"
                ALTER DATABASE AutoPartsManager
                SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
                    command.ExecuteNonQuery();

                    // 2️⃣ استعادة قاعدة البيانات من النسخة الاحتياطية
                    command.CommandText = $@"
                RESTORE DATABASE AutoPartsManager
                FROM DISK = N'{backupFilePath}'
                WITH REPLACE";
                    command.ExecuteNonQuery();

                    // 3️⃣ إعادة قاعدة البيانات إلى MULTI_USER
                    command.CommandText = @"
                ALTER DATABASE AutoPartsManager
                SET MULTI_USER";
                    command.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                error_message = ex.Message;
                return false;
            }
        }
    }
}

using AutoPartsManager;
using AutoPartsManager.Security;
using BL;
using System;
using System.IO;
using System.Windows.Forms;


internal static class Program
{
    [STAThread]
    static void Main()
    {
        try
        {
            //cls_bl_Initialize.InitializeDatabase();



            //DatabaseHelper.EnsureDatabaseExists();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //if (!HardwareLicense.ValidateOrActivateFirstTime())
            //    return;

            // --- عمليات التحقق والتحديث عند بدء التشغيل ---
            // هذه فكرة ممتازة لضمان أن البيانات في حالة متسقة عند بدء التطبيق
            // --- تشغيل الفورم الرئيسية ---
            Application.Run(new frm_main());
        }
        catch (Exception ex)
        {
            MessageBox.Show("حدث خطأ غير متوقع أثناء بدء التطبيق: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
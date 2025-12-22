using AutoPartsManager;
using System;
using System.Windows.Forms;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        // --- عمليات التحقق والتحديث عند بدء التشغيل ---
        // هذه فكرة ممتازة لضمان أن البيانات في حالة متسقة عند بدء التطبيق
        // --- تشغيل الفورم الرئيسية ---
        Application.Run(new frm_main());
    }
}
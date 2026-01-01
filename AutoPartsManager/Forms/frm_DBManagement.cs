using BL;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AutoPartsManager.Forms
{
    public partial class frm_DBManagement : XtraForm
    {
        public frm_DBManagement()
        {
            InitializeComponent();
        }

        private void frm_DBManagement_Load(object sender, EventArgs e)
        {
            // يمكنك إضافة أي إعدادات فورم عند التحميل إذا رغبت
        }

        private void btnResetDB_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
           "تحذير: سيؤدي هذا الإجراء إلى حذف جميع البيانات نهائياً ما عدا العميل والمورد رقم 1. هل تريد المتابعة؟",
           "تأكيد إعادة التعيين",
           MessageBoxButtons.YesNo,
           MessageBoxIcon.Warning
       );

            if (result == DialogResult.Yes)
            {
                string error = string.Empty;
                // استدعاء دالة إعادة التعيين
                // يجب أن تمرر سلسلة الاتصال الصحيحة
                string connectionString = "Your_Connection_String_Here";
                string message = cls_bl_DB.ResetDatabase(out error);

                // إظهار نتيجة العملية للمستخدم
                if (message.Contains("بنجاح"))
                {
                    MessageBox.Show(message, "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnBackupDB_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Backup Files (*.bak)|*.bak";
                sfd.FileName = $"AutoPartsManager_Backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string error;
                    if (cls_bl_DB.BackupDatabase(sfd.FileName, out error))
                    {
                        MessageBox.Show("تم إنشاء نسخة احتياطية بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("فشل النسخ الاحتياطي: " + error, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnRestoreDB_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Backup Files (*.bak)|*.bak";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var result = MessageBox.Show(
                        "سيتم استعادة قاعدة البيانات من النسخة الاحتياطية. سيتم استبدال جميع البيانات الحالية.\nهل تريد المتابعة؟",
                        "تأكيد الاستعادة",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        string error;
                        if (cls_bl_DB.RestoreDatabase(ofd.FileName, out error))
                        {
                            MessageBox.Show("تم استعادة قاعدة البيانات بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("فشل الاستعادة: " + error, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}


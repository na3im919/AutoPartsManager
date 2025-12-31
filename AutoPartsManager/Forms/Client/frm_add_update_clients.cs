using BL;
using DevExpress.XtraEditors;
using Moldels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoPartsManager.Forms.Client
{
    public partial class frm_add_update_clients : XtraForm
    {
        int _clientID = -1;
        public bool IsConfirmed = false;
        enum frmMode
        {
            Add,
            Update
        }
        frmMode currentMode;
        public frm_add_update_clients()
        {
            InitializeComponent();
            this.Text = "إضافة عميل جديد";
            currentMode = frmMode.Add;
        }

        public frm_add_update_clients(int clintID)
        {
            InitializeComponent();
            _clientID = clintID;
            this.Text = "تعديل بيانات العميل";
            currentMode = frmMode.Update;
        }

        private void btn_add_update_client_Click(object sender, EventArgs e)
        {
            string name = txt_client_name.Text.Trim();
            string phone = txt_phone.Text.Trim();
            string address = txt_address.Text.Trim();

            // ===== Validation =====
            if (string.IsNullOrEmpty(name))
            {
                txt_client_name.Focus();
                txt_client_name.ErrorText = "اسم الزبون مطلوب.";
                return;
            }

            if (phone.Length != 10 || !phone.All(char.IsDigit))
            {
                txt_phone.Focus();
                txt_phone.ErrorText = "رقم الهاتف يجب أن يكون مكونًا من 10 أرقام.";
                return;
            }

            // ===== Create client object =====
            cls_ml_Clients client = new cls_ml_Clients
            {
                ID = _clientID, // للـ Update، سيبقى -1 في حالة Add ولن يستخدم
                Name = name,
                Phone = phone,
                Address = address,
                IsActive = true
            };

            string error;
            bool success;

            if (currentMode == frmMode.Add)
            {
                success = cls_bl_Clients.AddClient(client, out error);
                if (success)
                    XtraMessageBox.Show("تمت إضافة العميل بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    XtraMessageBox.Show("فشل إضافة العميل: " + error, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else // Update
            {
                success = cls_bl_Clients.UpdateClient(client, out error);
                if (success)
                    XtraMessageBox.Show("تم تحديث بيانات العميل بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    XtraMessageBox.Show("فشل تحديث بيانات العميل: " + error, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (success)
            {
                IsConfirmed = true;
                this.Close(); // اغلق الفورم بعد النجاح
            }
                
        }

        private void frm_add_update_clients_Load(object sender, EventArgs e)
        {
            if(currentMode == frmMode.Update)
            {
                string error;
                var client = cls_bl_Clients.GetClientByID(_clientID, out error);

                if (!string.IsNullOrEmpty(error))
                {
                    MessageBox.Show(error, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (client != null)
                {
                    txt_client_name.Text = client.Name;
                    txt_phone.Text = client.Phone;
                    txt_address.Text = client.Address;
                }
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            IsConfirmed = false;
            this.Close();
        }
    }
}

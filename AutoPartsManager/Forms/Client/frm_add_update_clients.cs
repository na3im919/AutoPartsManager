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
        public frm_add_update_clients()
        {
            InitializeComponent();
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
            cls_ml_Clients newClient = new cls_ml_Clients
            {
                Name = name,
                Phone = phone,
                Address = address,
                IsActive = true
            };

            // ===== Add client via BL =====
            string error;
            bool success = cls_bl_Clients.AddClient(newClient, out error);

            if (success)
            {

                MessageBox.Show("تمت إضافة العميل بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                MessageBox.Show("فشل إضافة العميل: " + error, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

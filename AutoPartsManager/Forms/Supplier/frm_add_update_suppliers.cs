using BL;
using DevExpress.XtraEditors;
using Moldels;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AutoPartsManager.Forms.Supplier
{
    public partial class frm_add_update_suppliers : XtraForm
    {
        int _supplierID = -1;
        public bool IsConfirmed = false;
        enum frmMode { Add, Update }
        frmMode currentMode;

        public frm_add_update_suppliers()
        {
            InitializeComponent();
            this.Text = "إضافة مورد جديد";
            currentMode = frmMode.Add;
        }

        public frm_add_update_suppliers(int supplierID)
        {
            InitializeComponent();
            _supplierID = supplierID;
            this.Text = "تعديل بيانات المورد";
            currentMode = frmMode.Update;
        }

        private void btn_add_update_supplier_Click(object sender, EventArgs e)
        {
            string name = txt_supplier_name.Text.Trim();
            string phone = txt_phone.Text.Trim();
            string address = txt_address.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                txt_supplier_name.Focus();
                txt_supplier_name.ErrorText = "اسم المورد مطلوب.";
                return;
            }
            if (phone.Length != 10 || !phone.All(char.IsDigit))
            {
                txt_phone.Focus();
                txt_phone.ErrorText = "رقم الهاتف يجب أن يكون مكونًا من 10 أرقام.";
                return;
            }

            cls_ml_Suppliers supplier = new cls_ml_Suppliers
            {
                ID = _supplierID,
                Name = name,
                Phone = phone,
                Address = address,
                isActive = true
            };

            string error;
            bool success;

            if (currentMode == frmMode.Add)
            {
                success = cls_bl_Suppliers.AddSupplier(supplier, out error);
                if (success)
                    XtraMessageBox.Show("تمت إضافة المورد بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    XtraMessageBox.Show("فشل إضافة المورد: " + error, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                success = cls_bl_Suppliers.UpdateSupplier(supplier, out error);
                if (success)
                    XtraMessageBox.Show("تم تحديث بيانات المورد بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    XtraMessageBox.Show("فشل تحديث بيانات المورد: " + error, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (success)
            {
                IsConfirmed = true;
                this.Close();
            }
        }

        private void frm_add_update_suppliers_Load(object sender, EventArgs e)
        {
            if (currentMode == frmMode.Update)
            {
                string error;
                var supplier = cls_bl_Suppliers.GetSupplierByID(_supplierID, out error);
                if (!string.IsNullOrEmpty(error))
                {
                    MessageBox.Show(error, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (supplier != null)
                {
                    txt_supplier_name.Text = supplier.Name;
                    txt_phone.Text = supplier.Phone;
                    txt_address.Text = supplier.Address;
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

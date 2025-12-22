using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace AutoPartsManager.Forms
{
    public partial class frm_quantity : XtraForm
    {
        public int CurrentQuantity { get; set; }  // الكمية الحالية قبل التعديل
        public int NewQuantity { get; private set; } // الكمية الجديدة بعد التعديل
        public bool IsConfirmed { get; private set; } = false;
        public int MaxQuantity { get; set; } // الحد الأقصى المتاح

        public frm_quantity()
        {
            InitializeComponent();
        }

        private void frm_quantity_Load(object sender, EventArgs e)
        {
            textBoxQuantity.Text = CurrentQuantity.ToString();
            textBoxQuantity.Focus();
            textBoxQuantity.SelectAll();
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            int enteredQty;
            if (!int.TryParse(textBoxQuantity.Text, out enteredQty) || enteredQty <= 0)
                return;

            if (enteredQty > MaxQuantity)
            {
                MessageBox.Show($"الكمية المدخلة تتجاوز الحد الأقصى المتاح!\nالكمية المتاحة: {MaxQuantity}",
                                    "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxQuantity.Text = CurrentQuantity.ToString();
                return;
            }

            NewQuantity = enteredQty;
            IsConfirmed = true;
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            IsConfirmed = false;
            this.Close();
        }

        // Optional: منع الأحرف غير الرقمية
        private void textBoxQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        // اختصارات: Enter = تأكيد، Esc = إلغاء
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                btn_confirm.PerformClick();
                return true;
            }
            if (keyData == Keys.Escape)
            {
                btn_cancel.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void frm_quantity_Shown(object sender, EventArgs e)
        {
            textBoxQuantity.Focus();
            textBoxQuantity.SelectAll();
        }
    }
}

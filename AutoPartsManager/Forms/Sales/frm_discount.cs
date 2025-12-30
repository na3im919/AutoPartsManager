using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace AutoPartsManager.Forms
{
    public partial class frm_discount : XtraForm
    {
        public bool IsConfirmed { get; private set; }
        public bool IsDeleted { get; private set; }
        public decimal DiscountValue { get; private set; } // خصم لكل وحدة
        public string ProductName { get; set; }

        public frm_discount()
        {
            InitializeComponent();
        }

        private void frm_discount_Load(object sender, EventArgs e)
        {
            txt_discount.Focus();
            txt_discount.SelectAll();
            txt_product_name.Text = ProductName;
            txt_discount.Text = "0.00";
        }

        private void btn_confirm_discount_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txt_discount.Text, out decimal value))
                value = 0;

            if (value < 0)
                value = 0;

            DiscountValue = value;
            IsConfirmed = true;
            IsDeleted = false;
            this.Close();
        }

        private void btn_delete_discount_Click(object sender, EventArgs e)
        {
            DiscountValue = 0;
            IsConfirmed = false;
            IsDeleted = true;
            this.Close();
        }

       

        private void txt_discount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;
            if (char.IsDigit(e.KeyChar)) return;
            if (e.KeyChar == '.' && !txt_product_name.Text.Contains(".")) return;
            e.Handled = true;

        }

        private void txt_discount_Click(object sender, EventArgs e)
        {
            txt_product_name.SelectAll();

        }
    }
}

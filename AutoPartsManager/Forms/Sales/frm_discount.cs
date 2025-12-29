using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace AutoPartsManager.Forms
{
    public partial class frm_discount : XtraForm


    {
        public bool IsCanceled { get; private set; }
        public bool IsConfirmed { get; private set; }
        public decimal DiscountValue { get; private set; } // مبلغ ثابت فقط
        public decimal GrandTotal { get; set; }

        public frm_discount()
        {
            InitializeComponent();
            
        }



        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Enter = تأكيد
            if (keyData == Keys.Enter)
            {
                btn_confirm_discount_Click(null, null);
                return true;
            }

            // Esc = إلغاء
            if (keyData == Keys.Escape)
            {
                btn_cancel_discount_Click(null, null);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // السماح بالتحكم
            if (char.IsControl(e.KeyChar))
                return;

            // السماح بالأرقام
            if (char.IsDigit(e.KeyChar))
                return;

            // السماح بالفاصلة العشرية
            if (e.KeyChar == '.' && !textBox1.Text.Contains("."))
                return;

            // منع أي شيء آخر
            e.Handled = true;
        }


      


        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void btn_cancel_discount_Click(object sender, EventArgs e)
        {
            IsCanceled = true;
            this.Close();
        }


        private void btn_confirm_discount_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
                return;

            if (!decimal.TryParse(textBox1.Text, out decimal inputValue))
                return;

            if (inputValue < 0)
                return;

            // لا يتجاوز إجمالي الفاتورة
            if (inputValue > GrandTotal)
                inputValue = GrandTotal;

            DiscountValue = inputValue;
            IsConfirmed = true;
            IsCanceled = false;
            this.Close();
        }


        private void frm_discount_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            textBox1.SelectAll();
        }


        private void frm_discount_Shown(object sender, EventArgs e)
        {
            textBox1.Focus();
            textBox1.SelectAll();
        }

    }
}

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
        public enum DiscountType
        {
            Percentage,
            FixedAmount
        }
        public DiscountType SelectedDiscountType
        {
            get { return Discount; }
            set { Discount = value; }
        }


        DiscountType Discount;


        public bool IsCanceled { get; private set; }

        public decimal DiscountValue { get; private set; }   // قيمة الخصم
        public bool IsConfirmed { get; private set; }         // هل تم التأكيد
        public decimal GrandTotal { get; set; }               // المجموع قبل الخصم

        public frm_discount()
        {
            InitializeComponent();
            Discount = DiscountType.FixedAmount;
            
        }

        private decimal CalculateDiscount()
        {
            decimal inputValue;

            if (!decimal.TryParse(textBox1.Text, out inputValue) || inputValue < 0)
                return 0;

            if (Discount == DiscountType.FixedAmount)
            {
                // خصم مبلغ ثابت
                return Math.Min(inputValue, GrandTotal);
            }
            else
            {
                // خصم نسبة مئوية
                if (inputValue > 100)
                    inputValue = 100;

                return GrandTotal * (inputValue / 100);
            }
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


        private void btn_fixed_amount_Click(object sender, EventArgs e)
        {
            SelectedDiscountType = DiscountType.FixedAmount;
            pictureBox1.Image = Properties.Resources.dollar_symbol;
            textBox1.Focus();
            textBox1.SelectAll();
        }

        private void btn_percentage_Click(object sender, EventArgs e)
        {
            SelectedDiscountType = DiscountType.Percentage;
            pictureBox1.Image = Properties.Resources.percentage;
            textBox1.Focus();
            textBox1.SelectAll();
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

            decimal inputValue;
            if (!decimal.TryParse(textBox1.Text, out inputValue) || inputValue < 0)
                return;

            DiscountValue = inputValue; // فقط القيمة كما ادخلها المستخدم
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

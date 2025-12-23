using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoPartsManager.Forms.Purchases
{
    public partial class frm_purchases : frm_sales
    {
        protected override string InvoiceType => "شراء";
        protected override bool AllowDiscount => false;
        public frm_purchases()
        {
            //InitializeComponent();

        }

        protected override void ConfigureFormForType()
        {
            label1.Text = "إدارة المشتريات";
            label1.Location = new Point(5, 115);
            pictureBox1.Image = Properties.Resources.purchasing__1_;
            label2.Visible = false;
            lbl_discount.Visible = false;
        }

        protected override void AddSelectedProductToInvoice()
        {
            if (dgv_suggest.SelectedRows.Count == 0) return;

            var row = dgv_suggest.SelectedRows[0];
            int productId = Convert.ToInt32(row.Cells["ID"].Value);
            string productName = row.Cells["ProductName"].Value.ToString();
            decimal price = Convert.ToDecimal(row.Cells["Price"].Value);

            // بالنسبة للمشتريات لا نتحقق من الكمية المتاحة
            foreach (DataGridViewRow invoiceRow in dgv_invoice_list.Rows)
            {
                if (Convert.ToInt32(invoiceRow.Cells["ID"].Value) == productId)
                {
                    int currentQty = Convert.ToInt32(invoiceRow.Cells["Quantity"].Value);
                    invoiceRow.Cells["Quantity"].Value = currentQty + 1;
                    invoiceRow.Cells["Total"].Value = (currentQty + 1) * price;
                    ApplyDiscountAndCalculateTotal();
                    txtSearch.Clear();
                    dgv_suggest.Visible = false;
                    return;
                }
            }

            // إضافة المنتج جديد في القائمة
            dgv_invoice_list.Rows.Add(productId, productName, 1, price, price);
            txtSearch.Clear();
            dgv_suggest.Visible = false;
            ApplyDiscountAndCalculateTotal();
        }


        protected override void btn_edit_quantity_Click(object sender, EventArgs e)
        {
            if (dgv_invoice_list.SelectedRows.Count == 0) return;

            DataGridViewRow row = dgv_invoice_list.SelectedRows[0];
            int currentQty = Convert.ToInt32(row.Cells["Quantity"].Value);

            // للشراء، الحد الأقصى يمكن أن يكون مفتوحًا أو رقم كبير جدًا
            int maxQty = int.MaxValue;

            frm_quantity qForm = new frm_quantity { CurrentQuantity = currentQty, MaxQuantity = maxQty };
            qForm.ShowDialog();
            if (!qForm.IsConfirmed) return;

            int newQty = qForm.NewQuantity;

            row.Cells["Quantity"].Value = newQty;
            row.Cells["Total"].Value = newQty * Convert.ToDecimal(row.Cells["Price"].Value);

            // نحسب المجموع بعد التعديل
            ApplyDiscountAndCalculateTotal();
        }


    }
}

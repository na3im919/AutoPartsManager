using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoPartsManager.Forms.Returns
{
    public partial class frm_add_returns : XtraForm
    {
        string invoiceType = "Sale";
        string keyword = "";
        public frm_add_returns()
        {
            InitializeComponent();
        }


        public void LoadInvoicesToDGV(
      string keyword,
      string invoiceType,
      DateTime? dateFrom,
      DateTime? dateTo,
      DataGridView dgv_invoices)
        {
            string error;
            var invoicesList = BL.cls_bl_Invoices.GetInvoicesForUI(
                keyword,
                invoiceType,
                dateFrom,
                dateTo,
                out error
            );

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show("حدث خطأ: " + error, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ترتيب حسب التاريخ (الأحدث أولاً) قبل الربط
            dgv_invoices.DataSource = invoicesList
                .OrderByDescending(i => i.Date)
                .ToList();

            // التأكد من وجود أعمدة
            if (dgv_invoices.Columns.Count == 0) return;

            // إخفاء عمود InvoiceID
            if (dgv_invoices.Columns["InvoiceID"] != null)
                dgv_invoices.Columns["InvoiceID"].Visible = false;

            // رؤوس الأعمدة بالعربية
            dgv_invoices.Columns["ClientOrSupplier"].HeaderText = "العميل / المورد";
            dgv_invoices.Columns["Date"].HeaderText = "التاريخ";
            dgv_invoices.Columns["TotalAmount"].HeaderText = "المبلغ الإجمالي";
            dgv_invoices.Columns["DiscountAmount"].HeaderText = "الخصم";
            dgv_invoices.Columns["NetAmount"].HeaderText = "الصافي";
            dgv_invoices.Columns["Products"].HeaderText = "أول 3 منتجات";

            // ضبط عرض الأعمدة تلقائيًا
            dgv_invoices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // تنسيق العمود Date
            dgv_invoices.Columns["Date"].DefaultCellStyle.Format = "yyyy-MM-dd";
        }


        private void frm_add_returns_Load(object sender, EventArgs e)
        {
            rad_sales.Checked = true;
            LoadInvoicesToDGV(
                "",
                invoiceType,
                null,
                null,
                dgv_invoices
            );
        }

        private void rad_sales_CheckedChanged(object sender, EventArgs e)
        {
            invoiceType = rad_sales.Checked ? "بيع" : "شراء";
            LoadInvoicesToDGV(
                keyword,
                invoiceType,
                null,
                null,
                dgv_invoices
            );
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            keyword = textBox1.Text.Trim();
            LoadInvoicesToDGV(keyword,
                invoiceType,
                null,
                null,
                dgv_invoices
            );
        }
    }
}

using AutoPartsManager.Forms.Inventory;
using AutoPartsManager.Forms.Purchases;
using BL;
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
    

    public partial class frm_add_return : XtraForm
    {
        public bool refreshList = false;
        private DateTime? Date_from;
        private DateTime? Date_to;
        private string invoiceType = "بيع";


        string keyword = "";
        public frm_add_return()
        {
            InitializeComponent();
        }


        private void frm_add_return_select_invoice_Load(object sender, EventArgs e)
        {
            rb_sales.Checked = true;   // الافتراضي

            LoadInvoices();
        }

        private void LoadInvoices()
        {
            string error;
            var invoices = cls_bl_Invoices.GetInvoicesForReturn(
                invoiceType, keyword, Date_from, Date_to, out error);

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show("حدث خطأ: " + error, "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frm_inventory.SetupGridView(dgv_invoices);
            dgv_invoices.Rows.Clear();
            dgv_invoices.Columns.Clear();

            dgv_invoices.Columns.Add("ID", "ID");
            dgv_invoices.Columns.Add("ClientID", "ClientID");
            dgv_invoices.Columns.Add("ClientName", "الزبون");
            dgv_invoices.Columns.Add("Date", "التاريخ");
            dgv_invoices.Columns.Add("TotalAmount", "الإجمالي");
            dgv_invoices.Columns.Add("Discount", "الخصم");
            dgv_invoices.Columns.Add("NetAmount", "الصافي");
            dgv_invoices.Columns.Add("PaymentMethode", "طريقة الدفع");
            dgv_invoices.Columns.Add("ProductsSummary", "منتجات الفاتورة");

            dgv_invoices.Columns["ProductsSummary"].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            dgv_invoices.RowHeadersVisible = false;
            dgv_invoices.Columns["ID"].Visible = false;
            dgv_invoices.Columns["ClientID"].Visible = false;

            dgv_invoices.Columns["Date"].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            dgv_invoices.Columns["NetAmount"].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            dgv_invoices.Columns["ClientName"].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            // تغيير التسمية حسب النوع
            dgv_invoices.Columns["ClientName"].HeaderText =
                invoiceType == "بيع" ? "الزبون" : "المورد";

            foreach (var inv in invoices)
            {
                dgv_invoices.Rows.Add(
                    inv.ID,
                    inv.ClientID,       // Client أو Supplier حسب النوع
                    inv.ClientName,     // Client أو Supplier حسب النوع
                    inv.Date.ToString("yyyy-MM-dd"),
                    inv.TotalAmount,
                    inv.Discount,
                    inv.NetAmount,
                    inv.PaymentMethode,
                    inv.ProductsSummary
                );
            }
        }

        // عند النقر على فاتورة لفتح تفاصيلها
        private void dgv_invoices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // رقم الفاتورة
            int invoiceID = Convert.ToInt32(dgv_invoices.Rows[e.RowIndex].Cells["ID"].Value);

            // الشخص (زبون أو مورد)
            int personID = Convert.ToInt32(dgv_invoices.Rows[e.RowIndex].Cells["ClientID"].Value);

            // نوع الفاتورة (بيع أو شراء) حسب RadioButton أو المتغير
            string invoiceType = this.invoiceType;

            // فتح الفورم الذي يعرض تفاصيل الفاتورة للإرجاع
            frm_return_history detailsForm = new frm_return_history(invoiceID, personID, invoiceType);

            detailsForm.ShowDialog();

            // بعد الإغلاق يمكن إعادة تحميل القائمة إذا تم الإرجاع
            if (detailsForm.isReturned)
            {
                LoadInvoices();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            keyword = txtSearch.Text.Trim();
            LoadInvoices();
        }

        private void chk_date_fiter_CheckedChanged(object sender, EventArgs e)
        {
            if(chk_date_fiter.Checked)
            {
                dtp_from.Enabled = true;
                dtp_to.Enabled = true;
                Date_from = dtp_from.Value.Date;
                Date_to = dtp_to.Value.Date.AddDays(1).AddSeconds(-1);

            }
            else
            {
                dtp_from.Enabled = false;
                dtp_to.Enabled = false;
                Date_from = (DateTime?)null;
                Date_to = (DateTime?)null;

            }
            LoadInvoices();
        }

        private void dtp_from_ValueChanged(object sender, EventArgs e)
        {
            if (!dtp_from.Enabled)
            {
                Date_from = (DateTime?)null;
                return;
            }
            Date_from = dtp_from.Value.Date; ;

            LoadInvoices();
        }

        private void dtp_to_ValueChanged(object sender, EventArgs e)
        {
            if(!dtp_to.Enabled)
            {
                Date_to= (DateTime?)null;
                return;
            }
            Date_to = dtp_to.Value.Date.AddDays(1).AddSeconds(-1);
            LoadInvoices();

        }

        private void rb_sales_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_sales.Checked)
            {
                invoiceType = "بيع";
                LoadInvoices();
            }
        }

        private void rb_purchases_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_purchases.Checked)
            {
                invoiceType = "شراء";
                LoadInvoices();
            }
        }

    }
}

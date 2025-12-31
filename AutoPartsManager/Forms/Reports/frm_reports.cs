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
namespace AutoPartsManager.Forms.frm_reports
{
    public partial class frm_reports : XtraForm
    {
        string report_type = "";
        DateTime startDate = DateTime.Now;
        DateTime endDate = DateTime.Now;
        public frm_reports()
        {
            InitializeComponent();
        }

        private void CalculateTotals(
    List<cls_ml_Invoices> sales,
    out decimal totalAmount,
    out decimal netAmount)
        {
            totalAmount = 0;
            netAmount = 0;

            foreach (var invoice in sales)
            {
                totalAmount += invoice.TotalAmount;
                netAmount += (invoice.TotalAmount - invoice.DiscountAmount);
            }
        }


        private void LoadSalesReportGrid(DateTime startDate, DateTime endDate)
        {
            string error;
            var sales = cls_bl_reportes.GetSalesReport(startDate, endDate, out error);

            pnl_reports.Controls.Clear();
            pnl_main_lbl.Visible = true;
            pnl_sub_lbl.Visible = true;

            lbl_main_title.Visible = true;
            lbl_sub_title.Visible = true;
            lbl_main_content.Visible = true;
            lbl_sub_content.Visible = true;

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show(error, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataGridView dgv = new DataGridView();

            // ===== Basic Settings =====
            dgv.Dock = DockStyle.Fill;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;

            // ===== Header Style =====
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersHeight = 40;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // ===== Rows Style =====
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            // ===== Columns =====
            dgv.Columns.Add("Date", "التاريخ");
            dgv.Columns.Add("Total", "الإجمالي");
            dgv.Columns.Add("Discount", "الخصم");
            dgv.Columns.Add("Net", "الصافي");

            // ===== Data =====
            foreach (var invoice in sales)
            {
                decimal net = invoice.TotalAmount - invoice.DiscountAmount;

                dgv.Rows.Add(
                    invoice.Date.ToString("yyyy-MM-dd"),
                    invoice.TotalAmount.ToString("N2"),
                    invoice.DiscountAmount.ToString("N2"),
                    net.ToString("N2")
                );
            }
            decimal total;
            decimal Net;

            CalculateTotals(sales, out total, out Net);

            dgv.Rows.Add("الإجمالي",
                         total.ToString("N2"),
                         "",
                         Net.ToString("N2")
                         );


            dgv.Rows[dgv.Rows.Count - 1].DefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);


            pnl_reports.Controls.Add(dgv);

            lbl_main_title.Text = "إجمالي المبيعات";
            lbl_sub_title.Text = "الصافي الإجمالي";

            lbl_main_content.Text = total.ToString("N2") + " دج";
            lbl_sub_content.Text = Net.ToString("N2") + " دج";

        }

        private void LoadProfitReportGrid(DateTime startDate, DateTime endDate)
        {
            string error;
            var profitData = cls_bl_reportes.GetProfitReportData(startDate, endDate, out error);

            pnl_reports.Controls.Clear();
            pnl_main_lbl.Visible = true;
            pnl_sub_lbl.Visible = true;
            lbl_main_title.Visible = true;
            lbl_sub_title.Visible = true;
            lbl_main_content.Visible = true;
            lbl_sub_content.Visible = true;

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show(error, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataGridView dgv = new DataGridView();

            // ===== Basic Settings =====
            dgv.Dock = DockStyle.Fill;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;

            // ===== Header Style =====
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersHeight = 40;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // ===== Rows Style =====
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            // ===== Columns =====
            dgv.Columns.Add("Date", "التاريخ");
            dgv.Columns.Add("ProductName", "اسم المنتج");
            dgv.Columns.Add("Quantity", "الكمية");
            dgv.Columns.Add("Revenue", "الإيراد");
            dgv.Columns.Add("Cost", "التكلفة");
            dgv.Columns.Add("Profit", "الربح");
            dgv.Columns.Add("Margin", "هامش الربح %");

            // ===== Totals =====
            decimal totalRevenue = 0;
            decimal totalCost = 0;
            decimal totalProfit = 0;

            // ===== Data =====
            foreach (var item in profitData)
            {
                decimal profit = item.TotalRevenue - item.TotalCost;
                decimal margin = item.TotalRevenue != 0
                    ? (profit / item.TotalRevenue) * 100
                    : 0;

                dgv.Rows.Add(
                    item.Date.ToString("yyyy-MM-dd"),
                    item.ProductName,
                    item.Quantity.ToString("N0"),
                    item.TotalRevenue.ToString("N2"),
                    item.TotalCost.ToString("N2"),
                    profit.ToString("N2"),
                    margin.ToString("N2") + " %"
                );

                totalRevenue += item.TotalRevenue;
                totalCost += item.TotalCost;
                totalProfit += profit;
            }

            // ===== Total Margin =====
            decimal totalMargin = totalRevenue != 0
                ? (totalProfit / totalRevenue) * 100
                : 0;

            // ===== Total Row =====
            dgv.Rows.Add(
                "الإجمالي",
                "",
                "",
                totalRevenue.ToString("N2"),
                totalCost.ToString("N2"),
                totalProfit.ToString("N2"),
                totalMargin.ToString("N2") + " %"
            );

            dgv.Rows[dgv.Rows.Count - 1].DefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            pnl_reports.Controls.Add(dgv);

            // ===== Top Labels =====
            lbl_main_title.Text = "إجمالي الإيرادات";
            lbl_sub_title.Text = "إجمالي الفائدة";
            lbl_main_content.Text = totalRevenue.ToString("N2") + " دج";
            lbl_sub_content.Text = totalProfit.ToString("N2") + " دج";
        }

        private void LoadTop10BestSellingProducts(DateTime startDate, DateTime endDate)
        {
            string error;
            var data = cls_bl_reportes.GetTop10BestSellingProducts(startDate, endDate, out error);

            pnl_reports.Controls.Clear();
            pnl_main_lbl.Visible = true;
            pnl_sub_lbl.Visible = true;

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show(error, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataGridView dgv = new DataGridView();

            // ===== نفس تصميم التقارير =====
            dgv.Dock = DockStyle.Fill;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersHeight = 40;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgv.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(245, 245, 245);

            // ===== Columns =====
            dgv.Columns.Add("Rank", "#");
            dgv.Columns.Add("Product", "اسم المنتج");
            dgv.Columns.Add("Quantity", "الكمية المباعة");

            int rank = 1;
            foreach (var item in data)
            {
                dgv.Rows.Add(
                    rank++,
                    item.ProductName,
                    item.TotalQuantity.ToString("N0")
                );
            }

            pnl_reports.Controls.Add(dgv);
            lbl_main_title.Visible = false;
            lbl_sub_title.Visible = false;
            lbl_main_content.Visible = false;
            lbl_sub_content.Visible = false;
        }

        private void chk_reportes_SelectedIndexChanged(object sender, EventArgs e)
        {
            report_type = chk_reportes.Text;
        }

        private void btn_daily_Click(object sender, EventArgs e)
        {
            startDate = DateTime.Today;
            endDate = DateTime.Now;
        }

        private void btn_weekly_Click(object sender, EventArgs e)
        {
            startDate = DateTime.Today.AddDays(-7);
            endDate = DateTime.Now;
        }

        private void btn_monthly_Click(object sender, EventArgs e)
        {
            startDate = DateTime.Today.AddMonths(-1);
            endDate = DateTime.Now;
        }

        private void btn_yearly_Click(object sender, EventArgs e)
        {
            startDate = DateTime.Today.AddYears(-1);
            endDate = DateTime.Now;
        }

        private void btn_add_report_Click(object sender, EventArgs e)
        {
            switch (report_type)
            {
                case "المبيعات":
                    LoadSalesReportGrid(startDate, endDate);
                    break;
                case "الأرباح": // <-- تأكد من وجود هذه الحالة
                    LoadProfitReportGrid(startDate, endDate);
                    break;
                case "المنتجات الأكثر مبيعا":
                    LoadTop10BestSellingProducts(startDate, endDate);
                    break;
            }
        }
        private void dto_startDate_ValueChanged(object sender, EventArgs e)
        {
            startDate = dtp_startDate.Value;
            endDate = dtp_endDate.Value;
        }

        private void dtp_endDate_ValueChanged(object sender, EventArgs e)
        {
            startDate = dtp_startDate.Value;
            endDate = dtp_endDate.Value;
        }

        private void dtp_startDate_Enter(object sender, EventArgs e)
        {
            startDate = dtp_startDate.Value;
            endDate = dtp_endDate.Value;
        }
    }
}

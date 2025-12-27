using AutoPartsManager.Forms.Inventory;
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
    public partial class frm_sales_returns : XtraForm
    {
        public frm_sales_returns()
        {
            InitializeComponent();
        }


        private void LoadReturns()
        {
            string error;
            var returns = cls_bl_Returns.GetReturns(out error);

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show("حدث خطأ: " + error, "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgv_returns.Rows.Clear();

            bool isClientReturns = rb_client_returns.Checked;

            foreach (var r in returns)
            {
                // فلترة حسب النوع
                if (isClientReturns && r.ClientID == null)
                    continue;

                if (!isClientReturns && r.SupplierID == null)
                    continue;

                int rowIndex = dgv_returns.Rows.Add();
                var row = dgv_returns.Rows[rowIndex];

                row.Cells["ID"].Value = r.ID;
                row.Cells["InvoiceID"].Value = r.InvoiceID;
                row.Cells["Date"].Value = r.Date.ToString("yyyy-MM-dd");

                row.Cells["ClientID"].Value = r.ClientID;
                row.Cells["ClientName"].Value = r.ClientName;

                row.Cells["SupplierID"].Value = r.SupplierID;
                row.Cells["SupplierName"].Value = r.SupplierName;

                row.Cells["Status"].Value = r.Status;
                row.Cells["TotalAmount"].Value = r.TotalAmount;

                row.Cells["Details"].Value = Properties.Resources.file;
            }

            AdjustColumnsVisibility(isClientReturns);
        }

        private void AdjustColumnsVisibility(bool isClientReturns)
        {
            dgv_returns.Columns["ClientID"].Visible = isClientReturns;
            dgv_returns.Columns["ClientName"].Visible = isClientReturns;

            dgv_returns.Columns["SupplierID"].Visible = !isClientReturns;
            dgv_returns.Columns["SupplierName"].Visible = !isClientReturns;

            dgv_returns.Columns["ClientName"].HeaderText = "الزبون";
            dgv_returns.Columns["SupplierName"].HeaderText = "المورد";
        }


        private void frm_sales_returns_Load(object sender, EventArgs e)
        {
            rb_client_returns.Checked = true;
            LoadReturns();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void dgv_returns_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            string col = dgv_returns.Columns[e.ColumnIndex].Name;

            if (col != "Details")
                return;

            int returnsID = Convert.ToInt32(dgv_returns.Rows[e.RowIndex].Cells["ID"].Value);

            frm_return_details details = new frm_return_details(returnsID);
            details.ShowDialog();
        }

        private void rb_client_returns_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_client_returns.Checked)
                LoadReturns();
        }

        private void rb_supplier_returns_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_supplier_returns.Checked)
                LoadReturns();
        }

        private void btn_add_return_Click(object sender, EventArgs e)
        {
            frm_add_return @return = new frm_add_return();
            @return.ShowDialog();
            if (@return.refreshList)
            {

                LoadReturns();
            }
        }
    }
}

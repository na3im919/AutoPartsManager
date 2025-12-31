// Forms/Returns/frm_returns.cs
using DevExpress.XtraEditors;
using Moldels;
using BL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AutoPartsManager.Forms.Returns
{
    public partial class frm_returns : XtraForm
    {
        public frm_returns()
        {
            InitializeComponent();
        }

        private void frm_returns_Load(object sender, EventArgs e)
        {
            rad_sale.Checked = true; // تحديد الخيار الافتراضي
            LoadReturnsData();
            SetupDataGridView(); // Move this after loading data
        }

        private void SetupDataGridView()
        {
            // إضافة عمود الصورة
            DataGridViewImageColumn detailsColumn = new DataGridViewImageColumn
            {
                Name = "Details",
                HeaderText = "",
                Image = Properties.Resources.file, // يجب أن تضيف أيقونة لمشروعك
                Width = 50,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dgv_returns.Columns.Add(detailsColumn);

            // إخفاء الأعمدة غير المرغوب فيها
            if (dgv_returns.Columns["ReturnID"] != null)
                dgv_returns.Columns["ReturnID"].Visible = false;
            if (dgv_returns.Columns["InvoiceID"] != null)
                dgv_returns.Columns["InvoiceID"].Visible = false;
            if (dgv_returns.Columns["ReturnType"] != null)
                dgv_returns.Columns["ReturnType"].Visible = false;

            // تنسيق الأعمدة
            if (dgv_returns.Columns["Date"] != null)
            {
                dgv_returns.Columns["Date"].DefaultCellStyle.Format = "yyyy-MM-dd";
                dgv_returns.Columns["Date"].HeaderText = "التاريخ";
            }

            if (dgv_returns.Columns["ClientSupplierName"] != null)
                dgv_returns.Columns["ClientSupplierName"].HeaderText = "العميل/المورد";

            if (dgv_returns.Columns["TotalAmount"] != null)
            {
                dgv_returns.Columns["TotalAmount"].DefaultCellStyle.Format = "F2";
                dgv_returns.Columns["TotalAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_returns.Columns["TotalAmount"].HeaderText = "المبلغ الإجمالي";
            }

            if (dgv_returns.Columns["Status"] != null)
                dgv_returns.Columns["Status"].HeaderText = "الحالة";
            

            dgv_returns.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_returns.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LoadReturnsData()
        {
            string returnType = rad_sale.Checked ? "SALE" : "PURCHASE";
            string error;
            var returnsList = cls_bl_Returns.GetReturnsHistory(returnType, out error);

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show("حدث خطأ: " + error, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Clear existing columns before setting the data source
            dgv_returns.Columns.Clear();
            dgv_returns.DataSource = returnsList;
        }

        private void rad_sale_CheckedChanged(object sender, EventArgs e)
        {
            LoadReturnsData();
            SetupDataGridView(); // Re-setup after loading new data
        }

        private void rad_purchase_CheckedChanged(object sender, EventArgs e)
        {
            LoadReturnsData();
            SetupDataGridView(); // Re-setup after loading new data
        }

        // حدث النقر على خلايا الـ DataGridView
        private void dgv_returns_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // تحقق مما إذا كان النقر على عمود "التفاصيل"
            if (e.ColumnIndex == dgv_returns.Columns["Details"].Index && e.RowIndex >= 0)
            {
                // احصل على ReturnID من الصف المحدد
                int returnId = Convert.ToInt32(dgv_returns.Rows[e.RowIndex].Cells["ReturnID"].Value);

                // افتح نافذة التفاصيل
                using (var detailsForm = new frm_return_details(returnId))
                {
                    detailsForm.ShowDialog();
                }
            }
        }

        private void btn_add_returns_Click(object sender, EventArgs e)
        {
            frm_add_returns addReturnsForm = new frm_add_returns();
            addReturnsForm.Show();
            addReturnsForm.FormClosed += (s, args) => {
                LoadReturnsData();
                SetupDataGridView(); // Re-setup after loading new data
            };
        }
    }
}
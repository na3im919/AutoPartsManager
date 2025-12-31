// Forms/Returns/frm_return_history_detail.cs
using DevExpress.XtraEditors;
using Moldels;
using BL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AutoPartsManager.Forms.Returns
{
    public partial class frm_return_details : XtraForm
    {
        private readonly int _returnId;

        public frm_return_details(int returnId)
        {
            InitializeComponent();
            _returnId = returnId;
        }

        private void frm_return_details_Load(object sender, EventArgs e)
        {
            LoadReturnDetails();
        }

        private void LoadReturnDetails()
        {
            string error;
            var detailsList = cls_bl_Returns.GetReturnDetails(_returnId, out error);

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show("حدث خطأ: " + error, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // يمكنك هنا جلب معلومات المرتجع الرئيسية وعرضها في الـ Labels
            // مثال: this.Text = $"تفاصيل المرتجع رقم {_returnId}";

            dgv_details.DataSource = detailsList;
            SetupDetailsDataGridView();
        }

        private void SetupDetailsDataGridView()
        {
            dgv_details.Columns["ProductName"].HeaderText = "اسم المنتج";
            dgv_details.Columns["Price"].HeaderText = "السعر";
            dgv_details.Columns["Quantity"].HeaderText = "الكمية";
            dgv_details.Columns["Total"].HeaderText = "الإجمالي";

            dgv_details.Columns["Price"].DefaultCellStyle.Format = "F2";
            dgv_details.Columns["Total"].DefaultCellStyle.Format = "F2";
            dgv_details.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_details.ReadOnly = true; // جعل الجدول للقراءة فقط
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
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

namespace AutoPartsManager.Forms.Returns
{
    public partial class frm_return_history : XtraForm
    {
        private int _invoiceID;
        private int _personID;   // ClientID أو SupplierID
        private string _invoiceType; // "بيع" أو "شراء"
        public bool isReturned = false;
        public frm_return_history(int invoiceID, int personID, string invoiceType)
        {
            InitializeComponent();

            _invoiceID = invoiceID;
            _personID = personID;
            _invoiceType = invoiceType;

            dgv_return_detail.CurrentCellDirtyStateChanged += (s, e) =>
            {
                if (dgv_return_detail.IsCurrentCellDirty)
                    dgv_return_detail.CommitEdit(DataGridViewDataErrorContexts.Commit);
            };
        }


        private void LoadReturnableProducts(int invoiceID)
        {
            string error = string.Empty;

            var list = cls_bl_Returns.GetReturnableProducts(invoiceID, _invoiceType, out error);

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show(error, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgv_return_detail.Rows.Clear();

            foreach (var item in list)
            {
                int rowIndex = dgv_return_detail.Rows.Add(
                    item.ProductID,
                    item.InvoiceDetailID,
                    item.ProductName,
                    item.ProductPrice,
                    item.QuantityPurchased,
                    item.QuantityAlreadyReturned,
                    item.AvailableToReturn,
                    0, // Quantity to return
                    false, // SelectProduct
                    item.Notes
                );

                dgv_return_detail.Columns["SelectProduct"].ReadOnly = false;
                dgv_return_detail.Columns["Notes"].ReadOnly = false;
                // إذا لا توجد كمية متاحة للإرجاع
                if (item.AvailableToReturn == 0)
                {
                    dgv_return_detail.Rows[rowIndex].ReadOnly = true;
                    dgv_return_detail.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightGray;
                }
            }
        }

        private List<cls_ml_ReturnDetails> PrepareReturnDetails()
        {
            List<cls_ml_ReturnDetails> list = new List<cls_ml_ReturnDetails>();

            var selectedRows = dgv_return_detail.Rows
                .Cast<DataGridViewRow>()
                .Where(r => Convert.ToBoolean(r.Cells["SelectProduct"].Value));

            if (!selectedRows.Any())
            {
                MessageBox.Show(
                    "يرجى اختيار منتج واحد على الأقل للإرجاع",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return null;
            }

            foreach (DataGridViewRow row in selectedRows)
            {
                int qty = Convert.ToInt32(row.Cells["Quantity"].Value);
                int available = Convert.ToInt32(row.Cells["AvailableToReturn"].Value);

                if (qty <= 0 || qty > available)
                {
                    MessageBox.Show(
                        $"كمية الإرجاع غير صحيحة للمنتج: {row.Cells["ProductName"].Value}",
                        "خطأ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return null;
                }
                string notes = row.Cells["Notes"].Value?.ToString() ?? string.Empty;

                
                    list.Add(new cls_ml_ReturnDetails
                    {
                        // ReturnsID يتم تعيينه لاحقًا داخل Transaction
                        InvoiceDetailID = Convert.ToInt32(row.Cells["InvoiceDetailID"].Value),
                        ProductID = Convert.ToInt32(row.Cells["ProductID"].Value),
                        ProductPrice = Convert.ToDecimal(row.Cells["ProductPrice"].Value),
                        Quantity = qty,
                        Notes = notes
                    });
            }

            return list;
        }


        private void dgv_return_detail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgv_return_detail.Columns[e.ColumnIndex].Name == "SelectProduct")
            {
                bool selected = Convert.ToBoolean(
                    dgv_return_detail.Rows[e.RowIndex].Cells["SelectProduct"].Value
                );

                dgv_return_detail.Rows[e.RowIndex].Cells["Quantity"].ReadOnly = !selected;

                if (!selected)
                    dgv_return_detail.Rows[e.RowIndex].Cells["Quantity"].Value = 0;
            }
        }

        private void dgv_return_detail_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgv_return_detail.IsCurrentCellDirty)
                dgv_return_detail.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }


        private void btn_save_return_Click(object sender, EventArgs e)
        {
            var details = PrepareReturnDetails();
            if (details == null) return;

            cls_ml_Returns header = new cls_ml_Returns
            {
                InvoiceID = _invoiceID,
                ReturnType = _invoiceType,
                Status = "مؤكدة",
                ClientID = _invoiceType == "بيع" ? _personID : (int?)null,
                SupplierID = _invoiceType == "شراء" ? _personID : (int?)null,
                Date = DateTime.Now,
                TotalAmount = details.Sum(d => d.ProductPrice * d.Quantity)
            };


            string error;
            bool result = cls_bl_Returns.AddReturn(header, details, out error);

            if (!result)
            {
                MessageBox.Show(error, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(
                "تم حفظ الإرجاع بنجاح",
                "نجاح",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
            isReturned = true;
            this.Close();
        }

        private void frm_return_deatails_Load(object sender, EventArgs e)
        {
            this.Text = _invoiceType == "بيع"
                ? "إرجاع من فاتورة بيع"
                : "إرجاع من فاتورة شراء";

            foreach (DataGridViewColumn col in dgv_return_detail.Columns)
                col.ReadOnly = true;

            dgv_return_detail.Columns["SelectProduct"].ReadOnly = false;

            LoadReturnableProducts(_invoiceID);
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            isReturned = false;
            this.Close();
        }
    }
}

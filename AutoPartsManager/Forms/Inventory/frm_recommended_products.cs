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

namespace AutoPartsManager.Forms.Inventory
{
    public partial class frm_recommended_products : XtraForm
    {
        public frm_recommended_products()
        {
            InitializeComponent();
        }


        void LoadRecommendedProducts()
        {
            string error = string.Empty;

            var recommended = cls_bl_recomendations.GetRecommendedProducts(out error);
            if (!string.IsNullOrEmpty(error))
            {
                XtraMessageBox.Show(error);
            }
            else
            {
                dgv_inventory.Rows.Clear();
                foreach (var product in recommended)
                {
                    object imageValue = null;
                    if (product.AlreadyRecomended)
                    {
                        // ضع هنا صورة من الموارد أو ملف
                        imageValue = Properties.Resources.check; // مثال: صورة علامة صح من Resources
                    }
                    else
                        imageValue = Properties.Resources.close__2_;
                    dgv_inventory.Rows.Add
                            (
                           product.ID,
                           product.Reference,
                           product.ProductName,
                           product.ProductBrand,
                           product.Quantity,
                           imageValue
                            );
                }
            }


        }


        private void dgv_inventory_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgv_inventory.CurrentCell.ColumnIndex == dgv_inventory.Columns["Quantity"].Index) // عمود Quantity
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress -= Tb_KeyPress; // لتجنب تكرار الحدث
                    tb.KeyPress += Tb_KeyPress;
                }
            }
        }

        private void Tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            // السماح فقط بالأرقام و backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void SetupDataGridView()
        {
            // افترض أن dgv_inventory موجود بالفعل
            foreach (DataGridViewColumn col in dgv_inventory.Columns)
            {
                if (col.Name == "Quantity")
                    col.ReadOnly = false; // السماح بالتحرير
                else
                    col.ReadOnly = true;  // منع التحرير
            }
        }




        private void frm_recommended_products_Load(object sender, EventArgs e)
        {
            dgv_inventory.EditingControlShowing += dgv_inventory_EditingControlShowing;
            LoadRecommendedProducts();
            SetupDataGridView();

        }

        private void dgv_inventory_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgv_inventory.Columns[e.ColumnIndex].Name == "Quantity")
            {
                string value = e.FormattedValue.ToString().Trim();

                // إذا كانت الخلية فارغة
                if (string.IsNullOrEmpty(value))
                {
                    dgv_inventory.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                    return;
                }

                // إذا لم تكن رقمًا
                if (!int.TryParse(value, out _))
                {
                    e.Cancel = true;
                    MessageBox.Show("Quantity must be a number");
                }
            }
        }

        private void dgv_inventory_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_inventory.Columns[e.ColumnIndex].Name == "Quantity")
            {
                var cell = dgv_inventory.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString()))
                {
                    cell.Value = 0;
                }
            }
        }

    }
}

using BL;
using DevExpress.XtraEditors;
using Moldels;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AutoPartsManager.Forms.Supplier
{
    public partial class frm_Suppliers : XtraForm
    {
        string kw = "";
        bool isActive = true;

        public frm_Suppliers()
        {
            InitializeComponent();
            LoadSuppliersGrid();
        }

        private void LoadSuppliersGrid()
        {
            string error;
            var suppliers = cls_bl_Suppliers.GetSuppliers(kw, isActive, out error);

            dgv_suppliers.Controls.Clear();
            dgv_suppliers.Rows.Clear();
            dgv_suppliers.Columns.Clear();

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show(error, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ===== Basic settings =====
            dgv_suppliers.Dock = DockStyle.Fill;
            dgv_suppliers.ReadOnly = true;
            dgv_suppliers.AllowUserToAddRows = false;
            dgv_suppliers.RowHeadersVisible = false;
            dgv_suppliers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_suppliers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_suppliers.BackgroundColor = Color.White;

            // ===== Columns =====
            dgv_suppliers.Columns.Add("ID", "رقم المورد");
            dgv_suppliers.Columns.Add("Name", "الاسم");
            dgv_suppliers.Columns.Add("Phone", "الهاتف");
            dgv_suppliers.Columns.Add("Address", "العنوان");

            // ===== Image Columns =====
            if (isActive)
            {
                var editCol = new DataGridViewImageColumn() { Name = "Edit", Image = Properties.Resources.edit__1_, ImageLayout = DataGridViewImageCellLayout.Zoom };
                dgv_suppliers.Columns.Add(editCol);
                var deleteCol = new DataGridViewImageColumn() { Name = "Delete", Image = Properties.Resources.bin, ImageLayout = DataGridViewImageCellLayout.Zoom };
                dgv_suppliers.Columns.Add(deleteCol);
                editCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                deleteCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            else
            {
                var restoreCol = new DataGridViewImageColumn() { Name = "Restore", Image = Properties.Resources.updated, ImageLayout = DataGridViewImageCellLayout.Zoom };
                dgv_suppliers.Columns.Add(restoreCol);
                restoreCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            // ===== Fill data =====
            foreach (var sup in suppliers)
                dgv_suppliers.Rows.Add(sup.ID, sup.Name, sup.Phone, sup.Address);

           
        }

        private void Dgv_suppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (e.RowIndex >= dgv_suppliers.Rows.Count) return;

            int supplierId = Convert.ToInt32(dgv_suppliers.Rows[e.RowIndex].Cells["ID"].Value);

            if (dgv_suppliers.Columns[e.ColumnIndex].Name == "Edit")
            {
                frm_add_update_suppliers frm = new frm_add_update_suppliers(supplierId);
                frm.ShowDialog();
                if (frm.IsConfirmed) LoadSuppliersGrid();
            }
            else if (dgv_suppliers.Columns[e.ColumnIndex].Name == "Delete")
            {
                var result = MessageBox.Show("هل أنت متأكد من حذف هذا المورد؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string error;
                    if (cls_bl_Suppliers.DeleteSupplier(supplierId, out error))
                    {
                        MessageBox.Show("تم حذف المورد بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadSuppliersGrid();
                    }
                    else
                        MessageBox.Show("فشل الحذف: " + error, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (dgv_suppliers.Columns[e.ColumnIndex].Name == "Restore")
            {
                var result = MessageBox.Show("هل تريد استعادة هذا المورد؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string error;
                    if (cls_bl_Suppliers.RestoreSupplier(supplierId, out error))
                    {
                        MessageBox.Show("تم استعادة المورد بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadSuppliersGrid();
                    }
                    else
                        MessageBox.Show("فشل الاستعادة: " + error, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            kw = txtSearch.Text.Trim();
            LoadSuppliersGrid();
        }

        private void chk_non_active_suppliers_CheckedChanged(object sender, EventArgs e)
        {
            isActive = !chk_non_active_suppliers.Checked;
            LoadSuppliersGrid();
        }

        private void btn_add_supplier_Click(object sender, EventArgs e)
        {
            frm_add_update_suppliers frm = new frm_add_update_suppliers();
            frm.ShowDialog();
            LoadSuppliersGrid();
        }

        private void frm_Suppliers_Load(object sender, EventArgs e)
        {
            dgv_suppliers.CellClick += Dgv_suppliers_CellClick;

        }
    }
}

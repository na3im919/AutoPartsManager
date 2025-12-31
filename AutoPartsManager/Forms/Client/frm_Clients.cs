using AutoPartsManager.Forms.Client;
using BL;
using DevExpress.XtraEditors;
using Moldels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AutoPartsManager.Forms
{
    public partial class frm_Clients : XtraForm
    {
        string kw = "";
        bool isActive = true;
        public frm_Clients()
        {
            InitializeComponent();
            LoadClientsGrid();
        }

        private void LoadClientsGrid()
        {
            string error;
            var clients = cls_bl_Clients.GetClients(kw, isActive, out error);

            dgv_clients.Controls.Clear();
            dgv_clients.Rows.Clear();
            dgv_clients.Columns.Clear();

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show(error, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ===== Basic Settings =====
            dgv_clients.Dock = DockStyle.Fill;
            dgv_clients.ReadOnly = true;
            dgv_clients.AllowUserToAddRows = false;
            dgv_clients.AllowUserToDeleteRows = false;
            dgv_clients.RowHeadersVisible = false;
            dgv_clients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_clients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_clients.BackgroundColor = Color.White;
            dgv_clients.BorderStyle = BorderStyle.None;

            // ===== Header Style =====
            dgv_clients.EnableHeadersVisualStyles = false;
            dgv_clients.ColumnHeadersHeight = 40;
            dgv_clients.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dgv_clients.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv_clients.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // ===== Rows Style =====
            dgv_clients.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgv_clients.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            // ===== Columns =====
            dgv_clients.Columns.Add("ID", "رقم العميل");
            dgv_clients.Columns.Add("Name", "الاسم");
            dgv_clients.Columns.Add("Phone", "الهاتف");
            dgv_clients.Columns.Add("Address", "العنوان");

            // ===== Image Columns =====
            if (isActive)
            {
                // Edit Column
                DataGridViewImageColumn editColumn = new DataGridViewImageColumn();
                editColumn.Name = "Edit";
                editColumn.HeaderText = "";
                editColumn.Image = Properties.Resources.edit__1_;
                editColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dgv_clients.Columns.Add(editColumn);
                editColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                // Delete Column
                DataGridViewImageColumn deleteColumn = new DataGridViewImageColumn();
                deleteColumn.Name = "Delete";
                deleteColumn.HeaderText = "";
                deleteColumn.Image = Properties.Resources.bin;
                deleteColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dgv_clients.Columns.Add(deleteColumn);
                deleteColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            else
            {
                // Restore Column
                DataGridViewImageColumn restoreColumn = new DataGridViewImageColumn();
                restoreColumn.Name = "Restore";
                restoreColumn.HeaderText = "";
                restoreColumn.Image = Properties.Resources.updated; // أيقونة الاستعادة
                restoreColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dgv_clients.Columns.Add(restoreColumn);
                restoreColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            // ===== Fill Data =====
            foreach (var client in clients)
            {
                dgv_clients.Rows.Add(
                    client.ID,
                    client.Name,
                    client.Phone,
                    client.Address
                );
            }

            // ===== Handle Cell Clicks =====
            dgv_clients.CellClick += Dgv_clients_CellClick;
        }

        private void Dgv_clients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Edit Column Clicked
            if (dgv_clients.Columns[e.ColumnIndex].Name == "Edit")
            {
                int clientId = Convert.ToInt32(dgv_clients.Rows[e.RowIndex].Cells["ID"].Value);
                // افتح نموذج التعديل هنا مع clientId
                MessageBox.Show($"تعديل العميل: {clientId}");
            }

            // Delete Column Clicked
            if (dgv_clients.Columns[e.ColumnIndex].Name == "Delete")
            {
                int clientId = Convert.ToInt32(dgv_clients.Rows[e.RowIndex].Cells["ID"].Value);
                // تنفيذ الحذف هنا بعد تأكيد
                DialogResult result = MessageBox.Show("هل أنت متأكد من حذف العميل؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string error = string.Empty;
                    bool deleted = cls_bl_Clients.DeleteClient(clientId, out error);
                    LoadClientsGrid();
                }
            }
        }

        private void chk_non_active_clients_CheckedChanged(object sender, EventArgs e)
        {
            isActive = !chk_non_active_clients.Checked;
            LoadClientsGrid();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            kw = txtSearch.Text.Trim();
            LoadClientsGrid();
        }

        private void btn_add_client_Click(object sender, EventArgs e)
        {
            frm_add_update_clients frm_Add_Update_Clients = new frm_add_update_clients();
            frm_Add_Update_Clients.ShowDialog();
            LoadClientsGrid();
        }
    }
}

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

namespace AutoPartsManager.Forms.Clients
{
    public partial class frm_clients : XtraForm
    {
        bool isActive =true;
        string kw = string.Empty;
        public frm_clients()
        {
            
            InitializeComponent();
        }


        public void LoadClientsList()
        {
            string error_message = string.Empty;

            List<cls_ml_Clients> clients =
                cls_bl_Clients.GetClients(kw, isActive, out error_message);

            if (!string.IsNullOrEmpty(error_message))
            {
                MessageBox.Show(error_message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgv_clients.Rows.Clear();

            if (clients == null || clients.Count == 0)
                return;

            foreach (var client in clients)
            {
                dgv_clients.Rows.Add(
                    client.ID,
                    client.Name,
                    client.Phone,
                    client.Address,
                    Properties.Resources.edit__1_,
                    Properties.Resources.bin,
                    Properties.Resources._return
                );
            }
        }

        private void dgv_clients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int clientID = Convert.ToInt32(dgv_clients.Rows[e.RowIndex].Cells["ID"].Value);

            if (dgv_clients.Columns[e.ColumnIndex].Name == "Delete")
            {
                // تعطيل العميل
            }
            else if (dgv_clients.Columns[e.ColumnIndex].Name == "Restore")
            {
                // تفعيل العميل
            }
            else if (dgv_clients.Columns[e.ColumnIndex].Name == "Edit")
            {
                // فتح فورم التعديل
            }
        }


        private void ClientsListButtonsManager(bool isActiveClients)
        {
            if (isActiveClients)
            {
                dgv_clients.Columns["Edit"].Visible = true;
                dgv_clients.Columns["Delete"].Visible = true;
                dgv_clients.Columns["Restore"].Visible = false;
            }
            else
            {
                dgv_clients.Columns["Edit"].Visible = false;
                dgv_clients.Columns["Delete"].Visible = false;
                dgv_clients.Columns["Restore"].Visible = true;
            }
        }

        private void frm_clients_Load(object sender, EventArgs e)
        {
            rad_active.Checked = true;
            ClientsListButtonsManager(isActive);
            LoadClientsList();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            kw = txtSearch.Text.Trim();
            LoadClientsList();
        }


        private void rad_active_CheckedChanged(object sender, EventArgs e)
        {
            if (!rad_active.Checked) return;

            isActive = true;
            LoadClientsList();
            ClientsListButtonsManager(isActive);
        }

        private void rad_non_active_CheckedChanged(object sender, EventArgs e)
        {
            if (!rad_non_active.Checked) return;

            isActive = false;
            LoadClientsList();
            ClientsListButtonsManager(isActive);
        }

        private void btn_add_new_client_Click(object sender, EventArgs e)
        {
            frm_add_update_client add_Update_Client = new frm_add_update_client();
            add_Update_Client.ShowDialog();
        }
    }
}

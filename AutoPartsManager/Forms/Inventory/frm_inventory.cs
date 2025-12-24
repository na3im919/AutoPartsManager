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
    public partial class frm_inventory : XtraForm
    {
        public frm_inventory()
        {
            InitializeComponent();
        }


        public void SetupGridView(DataGridView gridView)
        {
            // Example setup code for the DataGridView
            gridView.AutoGenerateColumns = false;
            gridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridView.MultiSelect = false;
            gridView.AllowUserToAddRows = false;
            gridView.AllowUserToDeleteRows = false;
            gridView.Font = new Font("Segoe UI", 16);
        }

        private void frm_inventory_Load(object sender, EventArgs e)
        {
            SetupGridView(dgv_invoice);
        }
    }
}

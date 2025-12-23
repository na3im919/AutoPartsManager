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

namespace AutoPartsManager.Forms.Sales
{
    public partial class frm_add_invoice : XtraForm
    {
        private decimal _grandTotal;
        private decimal _discountAmount;
        public string PaymentMethod { get; set; }
        public int ClientID { get; set; }

        public frm_add_invoice(decimal grandTotal, decimal discountAmount)
        {
            InitializeComponent();
            _grandTotal = grandTotal;
            _discountAmount = discountAmount;

        }

        private List<cls_ml_Clients> _clients;

        private void FillClientsComboBoxEdit()
        {
            string error;
            _clients = cls_bl_Clients.GetActiveClients(out error);

            cmb_client_name.Properties.Items.Clear();

            foreach (var c in _clients)
                cmb_client_name.Properties.Items.Add(c.Name);
        }


        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_add_invoice_Load(object sender, EventArgs e)
        {
            txt_discount.Text = _discountAmount.ToString("C2");
            txt_total.Text = _grandTotal.ToString("C2");
            decimal netAmount = _grandTotal - _discountAmount;
            txt_net_amount.Text = netAmount.ToString("C2");
            PaymentMethod = "نقد";

            FillClientsComboBoxEdit();
        }

        private void chk_cash_or_not_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_cash_or_not.Checked)
            {
                PaymentMethod = "دفع آجل";
            }
            else
            {
                PaymentMethod = "نقد";
            }
        }

        private void btn_add_invoice_Click(object sender, EventArgs e)
        {
            int index = cmb_client_name.SelectedIndex;
            int clientId = _clients[index].ID;
            this.Close();

        }
    }
}

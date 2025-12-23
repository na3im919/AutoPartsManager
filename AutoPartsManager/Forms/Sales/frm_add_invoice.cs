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
        public bool IsApproved { get; set; }

        private cls_ml_Clients _unknownClient;

        public frm_add_invoice(decimal grandTotal, decimal discountAmount)
        {
            InitializeComponent();
            _grandTotal = grandTotal;
            _discountAmount = discountAmount;
            this.KeyPreview = true;

        }

        private List<cls_ml_Clients> _clients;

        private void FillClientsComboBoxEdit()
        {
            string error;
            _clients = cls_bl_Clients.GetActiveClients(out error);

            cmb_client_name.Properties.Items.Clear();

            foreach (var c in _clients)
            {
                if (c.Name == "مجهول")
                    _unknownClient = c;

                cmb_client_name.Properties.Items.Add(c.Name);
            }
        }


        private void btn_cancel_Click(object sender, EventArgs e)
        {
            IsApproved = false;
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

                // إزالة "مجهول"
                if (_unknownClient != null)
                {
                    cmb_client_name.Properties.Items.Remove("مجهول");

                    // لو كان محدد، نلغي التحديد
                    if (cmb_client_name.Text == "مجهول")
                        cmb_client_name.SelectedIndex = -1;
                }
            }
            else
            {
                PaymentMethod = "نقد";

                // إعادة "مجهول"
                if (_unknownClient != null &&
                    !cmb_client_name.Properties.Items.Contains("مجهول"))
                {
                    cmb_client_name.Properties.Items.Insert(0, "مجهول");
                    cmb_client_name.SelectedIndex = 0;
                }
            }
        }


        private void btn_add_invoice_Click(object sender, EventArgs e)
        {
            string clientName = cmb_client_name.Text;

            var client = _clients.FirstOrDefault(c => c.Name == clientName);

            if (client == null)
            {
                XtraMessageBox.Show("يرجى اختيار عميل صحيح");
                return;
            }

            ClientID = client.ID;
            IsApproved = true;
            this.Close();
        }

        private void frm_add_invoice_Shown(object sender, EventArgs e)
        {
            cmb_client_name.SelectedIndex = 0;

        }

        private void frm_add_invoice_KeyDown(object sender, KeyEventArgs e)
        {
            // ==== Add Invoice Enter ==== //
            if(e.KeyCode == Keys.Enter)
            {
                btn_add_invoice_Click(null, null);
                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }

            // ==== Close Invoice Esc ==== //
            if (e.KeyCode == Keys.Escape)
            {
                btn_cancel_Click(null, null);
                e.Handled = true;
                e.SuppressKeyPress= true;
                return;

            }
        }
    }
}

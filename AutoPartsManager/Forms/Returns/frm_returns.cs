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

namespace AutoPartsManager.Forms.Returns
{
    public partial class frm_returns : XtraForm
    {
        public frm_returns()
        {
            InitializeComponent();
        }

        private void btn_add_returns_Click(object sender, EventArgs e)
        {
            frm_add_returns frm = new frm_add_returns();
            frm.ShowDialog();
        }
    }
}

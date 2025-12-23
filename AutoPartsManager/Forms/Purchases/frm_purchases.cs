using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoPartsManager.Forms.Purchases
{
    public partial class frm_purchases : frm_sales
    {
        protected override string InvoiceType => "شراء";
        protected override bool AllowDiscount => false;
        public frm_purchases()
        {
            //InitializeComponent();

        }

        protected override void ConfigureFormForType()
        {
            label1.Text = "إدارة المشتريات";
            label1.Location = new Point(5, 115);
            pictureBox1.Image = Properties.Resources.purchasing__1_;
        }

    }
}

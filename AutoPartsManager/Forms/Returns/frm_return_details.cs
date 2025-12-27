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

namespace AutoPartsManager.Forms.Returns
{
    public partial class frm_return_details : XtraForm
    {
        int _returnID;
        public frm_return_details(int returnID)
        {
            InitializeComponent();
            _returnID = returnID;
        }



        private void LoadReturnDetails(int returnID)
        {
            string error_message = string.Empty;

            var details = cls_bl_Returns.GetReturnsDeatailBy(returnID, out error_message);

            if (!string.IsNullOrEmpty(error_message))
            {
                XtraMessageBox.Show(error_message);
            }

            foreach (var item in details)
            {
                int rowIndex = dgv_return_detail.Rows.Add(
                    item.ProductName,
                    item.ProductPrice,
                    item.Quantity,
                    item.Total,
                    item.Notes
                    );
            }
        }

        private void frm_return_details_Load(object sender, EventArgs e)
        {
            LoadReturnDetails(_returnID);
        }
    }
}

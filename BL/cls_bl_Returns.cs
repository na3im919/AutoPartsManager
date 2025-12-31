using DAL;
using Moldels.ML_Returns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class cls_bl_Returns
    {

        public static Tuple<string, string> GetInvoiceInfo(int invoiceId, out string error)
        {
            return cls_dal_returns.GetInvoiceInfo(invoiceId, out error);
        }

        public static List<ReturnProductModel> GetInvoiceProductsForReturn(int invoiceId, out string error)
        {
            return cls_dal_returns.GetInvoiceProductsForReturn(invoiceId, out error);
        }

        public static bool SaveNewReturn(int invoiceId, List<ReturnDetailToSave> returnDetails, out string error)
        {
             return cls_dal_returns.SaveNewReturn(invoiceId, returnDetails, out error);
        }
    }
}

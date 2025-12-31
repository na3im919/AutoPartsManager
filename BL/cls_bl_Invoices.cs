using Moldels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class cls_bl_Invoices
    {


        public static bool AddInvoice(cls_ml_Invoices invoice, List<cls_ml_InvoiceDetail> details, out string errorMessage)
        {
            return DAL.cls_dal_Invoices.AddInvoice(invoice, details, out errorMessage);
        }


        public static List<cls_vm_InvoiceList> GetInvoicesForUI(
    string keyword,
    string invoiceType,   // "Sale" أو "Purchase"
    DateTime? dateFrom,
    DateTime? dateTo,
    out string error)
        {
            return DAL.cls_dal_Invoices.GetInvoicesForUI(
                keyword,
                invoiceType,
                dateFrom,
                dateTo,
                out error);
        }

    }
}

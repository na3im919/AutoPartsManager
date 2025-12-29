using DAL;
using Moldels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class cls_bl_reportes
    {
        public static List<cls_ml_Invoices> GetSalesReport(DateTime startDate, DateTime endDate, out string error_message)
        {
            return cls_dal_reportes.GetSalesReport(startDate, endDate, out error_message);
        }
    }
}

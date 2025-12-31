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

        public static List<cls_ml_ProfitData> GetProfitReportData(DateTime startDate, DateTime endDate, out string error)
        {
            return cls_dal_reportes.GetProfitReportData(startDate, endDate, out error);
        }

        public static List<cls_ml_BestSellingProduct> GetTop10BestSellingProducts(
            DateTime startDate,
            DateTime endDate,
            out string error)
        {
            return cls_dal_reportes.GetTop10BestSellingProducts(startDate, endDate, out error);
        }


        public static List<cls_ml_MostReturnedProduct> GetTop10MostReturnedProducts(
   DateTime startDate,
   DateTime endDate,
   out string error)
        {
            return cls_dal_reportes.GetTop10MostReturnedProducts(startDate, endDate, out error);
        }
    }
}

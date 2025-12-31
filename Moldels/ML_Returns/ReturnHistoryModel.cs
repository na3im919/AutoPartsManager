using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moldels.ML_Returns
{
    public class ReturnHistoryModel
    {
        public int ReturnID { get; set; }
        public DateTime Date { get; set; }
        public string ReturnType { get; set; } // "بيع" أو "شراء"
        public string ClientSupplierName { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public int InvoiceID { get; set; } // لاستخدامه عند فتح التفاصيل
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moldels.Returns
{
    public class cls_ml_InvoiceSummary
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public DateTime Date { get; set; }
        public decimal NetAmount { get; set; }
        public string PaymentMethode { get; set; }
        public string ProductsSummary { get; set; } // أول 3 منتجات + "..." إذا أكثر
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moldels
{
    public class cls_ml_Returns
    {
        public int ID { get; set; }
        public int InvoiceID { get; set; }
        public string ReturnType { get; set; }   // SALE / PURCHASE
        public string Status { get; set; }       // COMPLETED
        public int? ClientID { get; set; }
        public int? SupplierID { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
    }

}

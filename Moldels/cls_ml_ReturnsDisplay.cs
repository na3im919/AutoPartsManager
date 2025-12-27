using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moldels.Returns
{
    public class cls_ml_ReturnsDisplay
    {
        public int ID { get; set; }
        public int InvoiceID { get; set; }
        public DateTime Date { get; set; }

        public int? ClientID { get; set; }
        public string ClientName { get; set; }

        public int? SupplierID { get; set; }
        public string SupplierName { get; set; }

        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
    }


}

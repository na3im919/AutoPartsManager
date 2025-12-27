using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moldels
{
    public class cls_ml_ReturnDetails
    {
        public int ID { get; set; }                 // أضف هذا
        public int ReturnsID { get; set; }
        public int InvoiceDetailID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }
        public decimal Total { get; set; }

    }


}

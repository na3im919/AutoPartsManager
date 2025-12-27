using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moldels.Returns
{
    public class cls_ml_ReturnableProduct
    {
        public int InvoiceDetailID { get; set; } // <-- مهم
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int QuantityPurchased { get; set; }
        public int QuantityAlreadyReturned { get; set; }
        public int AvailableToReturn { get; set; }

        public string Notes { get; set; }
    }


}

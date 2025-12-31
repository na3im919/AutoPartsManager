using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moldels.ML_Returns
{
    public class ReturnDetailToSave
    {
        public int ProductID { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public int InvoiceDetailID { get; set; } // معرف التفصيل في الفاتورة الأصلية
    }
}

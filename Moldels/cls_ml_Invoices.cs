using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moldels
{
    public class cls_ml_Invoices
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public int SupplierID { get; set; }
        public string InvoiceType { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }       // مجموع كل تفاصيل الفاتورة
        public decimal DiscountAmount { get; set; }    // الخصم على الفاتورة
        public string PaymentMethod { get; set; }

        // NetAmount محسوب تلقائيًا
        public decimal NetAmount
        {
            get
            {
                return TotalAmount - DiscountAmount;
            }
        }

    }
}

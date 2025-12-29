using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moldels
{
    public class cls_ml_InvoiceDetail
    {
        public int ID { get; set; }
        public int InvoiceID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Cost { get; set; }
        public int Quantity { get; set; }
        public decimal DiscountAmount { get; set; } = 0; // خصم لكل سطر

        // 🔸 خصائص مساعدة (Runtime Only)
        public string ProductName { get; set; }
        public string Reference { get; set; }
        public string ProductBrand { get; set; }
        public bool IsNewProduct { get; set; }

        // إجمالي السطر قبل الخصم
        public decimal LineTotal => UnitPrice * Quantity;

        // إجمالي السطر بعد الخصم
        public decimal LineTotalAfterDiscount => (UnitPrice * Quantity) - DiscountAmount;
    }
}

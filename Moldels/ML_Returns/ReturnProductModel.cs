using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moldels.ML_Returns
{
    public class ReturnProductModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; } // السعر (بعد الخصم للبيع، أو التكلفة للشراء)
        public int InvoiceQuantity { get; set; } // الكمية الأصلية في الفاتورة
        public int ReturnedQuantity { get; set; } // الكمية التي تم إرجاعها مسبقًا
        public int ReturnQuantity { get; set; } // الكمية التي سيدخلها المستخدم للإرجاع الآن
        public bool IsSelected { get; set; } // هل اختار المستخدم هذا المنتج للإرجاع؟
        public int InvoiceDetailID { get; set; }

        // خاصية مساعدة لحساب الكمية القابلة للإرجاع
        public int AvailableReturnQuantity => InvoiceQuantity - ReturnedQuantity;
    }
}

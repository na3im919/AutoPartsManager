using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moldels
{
    public class cls_ml_ProfitData
    {
        public DateTime Date { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; } // سيكون سالباً في حالة المرتجع
        public decimal SalePrice { get; set; }
        public decimal CostPrice { get; set; }
        public decimal TotalRevenue { get; set; } // SalePrice * Quantity (سيكون سالباً للمرتجع)
        public decimal TotalCost { get; set; } // CostPrice * Quantity (سيكون سالباً للمرتجع)
        public bool IsReturn { get; set; } // لتحديد ما إذا كان البند مرتجعاً
    }

}

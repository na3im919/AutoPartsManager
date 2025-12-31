using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moldels
{
    public class cls_ml_BestSellingProduct
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }

        public int TotalQuantity { get; set; }

        public decimal TotalRevenue { get; set; }
        public decimal TotalCost { get; set; }

        public decimal Profit
        {
            get { return TotalRevenue - TotalCost; }
        }

        public decimal ProfitMarginPercent
        {
            get
            {
                if (TotalRevenue == 0)
                    return 0;
                return (Profit / TotalRevenue) * 100;
            }
        }
    }
}

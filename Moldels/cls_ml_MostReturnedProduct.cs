using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moldels
{
    public class cls_ml_MostReturnedProduct
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }

        public int TotalReturnedQuantity { get; set; }
        public decimal TotalReturnedRevenue { get; set; }
        public decimal TotalReturnedCost { get; set; }

        public decimal Loss
        {
            get { return TotalReturnedRevenue - TotalReturnedCost; }
        }

        public decimal LossPercent
        {
            get
            {
                if (TotalReturnedRevenue == 0)
                    return 0;
                return (Loss / TotalReturnedRevenue) * 100;
            }
        }
    }
}

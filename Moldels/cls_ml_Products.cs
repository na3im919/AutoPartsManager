using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moldels
{
    public class cls_ml_Products
    {
        public int ID { get; set; }
        public string Reference { get; set; }
        public string ProductName { get; set; }
        public string ProductBrand { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool isActive { get; set; }


        // في كلاس cls_ml_Products
        public override string ToString()
        {
            // يمكنك تخصيص النص الذي يظهر في القائمة
            return $"{ProductName}        {ProductBrand}      {Quantity}        {Price}  DZD";
        }
    }
}

using DAL;
using Moldels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class cls_bl_Products
    {

        public static List<cls_ml_Products> SearchForProducts(string keyword, out string error_message)
        {
            return cls_dal_Products.GetProductsByKeyword(keyword, out error_message);
        }


        public static int GetAvailableQuantity(int productId, out string error_message)
        {
            return cls_dal_Products.GetAvailableQuantity(productId, out error_message);
        }
    }
}

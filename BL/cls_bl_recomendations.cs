using DAL;
using Moldels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class cls_bl_recomendations
    {
        public static bool AddRecommendation(cls_ml_Products product, out string error_message)
        {
            return cls_dal_recomendations.AddRecommendation(product, out error_message);
        }

        public static List<cls_ml_Products> GetRecommendedProducts(out string error_message)
        {
            return cls_dal_recomendations.GetRecommendedProducts(out error_message);
        }


        public static bool UpdateRecommendedProduct(List<cls_ml_Products> products, out string error_message)
        {
            return cls_dal_recomendations.UpdateRecommendedProduct(products, out error_message);
        }



    }
}

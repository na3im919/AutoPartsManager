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

        // في Business Layer
        public static List<cls_ml_Products> SearchForProducts(string keyword, string invoiceType, out string error_message)
        {
            return cls_dal_Products.GetProductsByKeyword(keyword, invoiceType, out error_message);
        }
        public static List<cls_ml_Products> GetAllProducts(string kw, bool isActive, bool zero_qty, out string error_message)
        {
            return cls_dal_Products.GetAllProducts(kw, isActive, zero_qty, out error_message);
        }

        public static int GetProductIdByReference(string reference)
        {
            return cls_dal_Products.GetProductIdByReference(reference);
        }

        public static int GetAvailableQuantity(int productId, out string error_message)
        {
            return cls_dal_Products.GetAvailableQuantity(productId, out error_message);
        }

        public static bool DeactivateProduct(int productId, out string error)
        {
            error = string.Empty;
            return cls_dal_Products.SetInactive(productId, out error);
        }

        public static bool SetActive(int productId, out string error)

        { return cls_dal_Products.SetActive(productId, out error); }


        public static cls_ml_Products GetProductInfoByID(int productId, out string error_message)
        {
            return cls_dal_Products.GetProductInfoByID(productId, out error_message);
        }


        public static bool AddProductStock(cls_ml_Products product, out string error_message)
        {
            return cls_dal_Products.AddProductStock(product, out error_message);
        }

        public static bool UpdateProductStock(cls_ml_Products product, out string error_message)
        {
            return cls_dal_Products.UpdateProductStock(product, out error_message);
        }


        public static List<cls_ml_Products> GetDepletedProducts(out string error_message)
        {
            return cls_dal_Products.GetDepletedProducts(out error_message);
        }


       

    }
}

using DAL;
using Moldels;
using Moldels.Returns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class cls_bl_Returns
    {
        public static bool AddReturn(
    cls_ml_Returns header,
    List<cls_ml_ReturnDetails> details,
    out string error)
        {
            error = "";

            if (details == null || details.Count == 0)
            {
                error = "تفاصيل الإرجاع فارغة";
                return false;
            }

            return cls_dal_Returns.AddReturn(header, details, out error);
        }


        public static List<cls_ml_ReturnsDisplay> GetReturns(out string error)
        {
            return cls_dal_Returns.GetAllReturns(out error);
        }


        public static List<cls_ml_ReturnableProduct> GetReturnableProducts(
       int invoiceID, string invoiceType, out string error)
        {
            error = "";
            try
            {
                // 1️⃣ جلب تفاصيل الفاتورة حسب النوع
                var invoiceDetails = cls_dal_Invoices.GetInvoiceDetails(invoiceID, invoiceType, out error);
                if (!string.IsNullOrEmpty(error)) return null;

                // 2️⃣ جلب كل الإرجاعات السابقة لهذه الفاتورة
                var returnDetails = cls_dal_Returns.GetReturnDetailsByInvoice(invoiceID, out error);
                if (!string.IsNullOrEmpty(error)) return null;

                // 3️⃣ حساب الكمية المتاحة للإرجاع لكل منتج
                List<cls_ml_ReturnableProduct> result = invoiceDetails.Select(d => new cls_ml_ReturnableProduct
                {
                    InvoiceDetailID = d.ID,
                    ProductID = d.ProductID,
                    ProductName = d.ProductName,
                    ProductPrice = d.UnitPrice, // السعر يأتي مباشرة من GetInvoiceDetails
                    QuantityPurchased = d.Quantity,
                    QuantityAlreadyReturned = returnDetails
                        .Where(r => r.ProductID == d.ProductID)
                        .Sum(r => r.Quantity),
                    AvailableToReturn = d.Quantity - returnDetails
                        .Where(r => r.ProductID == d.ProductID)
                        .Sum(r => r.Quantity),
                    Notes = "" // يمكن تركها فارغة أو إضافة ملاحظات حسب الحاجة
                }).ToList();

                return result;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return null;
            }
        }




        public static List<cls_ml_ReturnDetails> GetReturnsDeatailBy(int ReturnsID, out string error_message)
        {
            return cls_dal_Returns.GetReturnsDeatailBy(ReturnsID, out error_message);
        }

    }
}

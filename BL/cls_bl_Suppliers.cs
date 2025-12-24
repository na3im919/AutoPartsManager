using DAL;
using Moldels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class cls_bl_Suppliers
    {
        public static List<cls_ml_Suppliers> GetActiveSuppliers(out string error_message)
        {
            return cls_dal_Suppliers.GetActiveSuppliers(out error_message);
        }
    }
}

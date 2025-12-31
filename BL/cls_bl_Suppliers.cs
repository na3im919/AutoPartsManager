using DAL;
using Moldels;
using System;
using System.Collections.Generic;

namespace BL
{
    public class cls_bl_Suppliers
    {
        public static List<cls_ml_Suppliers> GetActiveSuppliers(out string error_message)
        {
            return cls_dal_Suppliers.GetActiveSuppliers(out error_message);
        }


        // ===== جلب الموردين حسب الكلمة المفتاحية والحالة =====
        public static List<cls_ml_Suppliers> GetSuppliers(string keyword, bool isActive, out string error_message)
        {
            return cls_dal_Suppliers.GetSuppliers(keyword, isActive, out error_message);
        }

        // ===== إضافة مورد جديد =====
        public static bool AddSupplier(cls_ml_Suppliers supplier, out string error_message)
        {
            return cls_dal_Suppliers.AddSupplier(supplier, out error_message);
        }

        // ===== تحديث بيانات مورد =====
        public static bool UpdateSupplier(cls_ml_Suppliers supplier, out string error_message)
        {
            return cls_dal_Suppliers.UpdateSupplier(supplier, out error_message);
        }

        // ===== حذف مورد (تغيير isActive إلى 0) =====
        public static bool DeleteSupplier(int supplierID, out string error_message)
        {
            return cls_dal_Suppliers.DeleteSupplier(supplierID, out error_message);
        }

        // ===== استعادة مورد (تغيير isActive إلى 1) =====
        public static bool RestoreSupplier(int supplierID, out string error_message)
        {
            return cls_dal_Suppliers.RestoreSupplier(supplierID, out error_message);
        }

        // ===== جلب مورد حسب ID =====
        public static cls_ml_Suppliers GetSupplierByID(int supplierID, out string error_message)
        {
            return cls_dal_Suppliers.GetSupplierByID(supplierID, out error_message);
        }
    }
}

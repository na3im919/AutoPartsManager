using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moldels
{
    public class cls_ml_Suppliers
    {
        // معرف المورد (Primary Key)
        public int ID { get; set; }

        // اسم المورد
        public string Name { get; set; }

        // رقم الهاتف
        public string Phone { get; set; }

        // عنوان المورد
        public string Address { get; set; }

        // حالة المورد (نشط / غير نشط)
        public bool isActive { get; set; }

        // المُنشئ الافتراضي
        public cls_ml_Suppliers() { }

        // منشئ مع المعطيات
        public cls_ml_Suppliers(int id, string name, string phone, string address, bool isActive)
        {
            ID = id;
            Name = name;
            Phone = phone;
            Address = address;
            this.isActive = isActive;
        }
    }
}

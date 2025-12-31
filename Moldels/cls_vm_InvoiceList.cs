using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moldels
{
    public class cls_vm_InvoiceList
    {
        public int InvoiceID { get; set; }       // مخفي في UI
        public string ClientOrSupplier { get; set; }
        public DateTime? Date { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal NetAmount { get; set; }
        public string Products { get; set; }     // أول 3 منتجات فقط
    }

}

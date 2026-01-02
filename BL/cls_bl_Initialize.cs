using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public  class cls_bl_Initialize
    {

        public static void InitializeDatabase()
        {
            // كل ما يفعله DAL
            DatabaseManager.InitializeDatabase();
        }
    }
}

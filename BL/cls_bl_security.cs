using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class cls_bl_security
    {
        public static string GetStoredHardwareHash()
        {
            return cls_dal_security.GetStoredHardwareHash();
        }

        public static void ActivateFirstTime(string hardwareHash)
        {
            cls_dal_security.SaveHardwareHash(hardwareHash);
        }
    }
    
}

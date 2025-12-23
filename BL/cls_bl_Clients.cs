using DAL;
using Moldels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class cls_bl_Clients
    {
        public static List<cls_ml_Clients> GetActiveClients(out string error_message)
        {
            return cls_dal_Clients.GetActiveClients(out error_message);
        }
    }
}

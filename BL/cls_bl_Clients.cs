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

        public static bool AddClient(cls_ml_Clients client, out string error_message)
        {
            return cls_dal_Clients.AddClient(client, out error_message);
        }

        public static bool UpdateClient(cls_ml_Clients client, out string error_message)
        {
            return cls_dal_Clients.UpdateClient(client, out error_message);
        }

        public static cls_ml_Clients GetClientByID(int clientID, out string error_message)
        {
            return cls_dal_Clients.GetClientByID(clientID, out error_message);
        }
        public static bool DeleteClient(int clientId, out string error_message)
        {
            return cls_dal_Clients.DeleteClient(clientId, out error_message);
        }

        public static List<cls_ml_Clients> GetClients(string keyword, bool isActive, out string error_message)
        {
            return cls_dal_Clients.GetClients(keyword, isActive, out error_message);
        }

        public static bool RestoreClient(int clientId, out string error_message)
        {
            return cls_dal_Clients.RestoreClient(clientId, out error_message);
        }
    }
}

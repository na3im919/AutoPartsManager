using DAL;
using System;
using System.Collections.Generic;

namespace BL
{
    public class cls_bl_DB
    {
        public static string ResetDatabase(out string error_message)
        {
            return cls_dal_DB.ResetDatabase(out error_message);
        }

        public static bool BackupDatabase(string backupPath, out string error_message)
        {
            return cls_dal_DB.BackupDatabase(backupPath, out error_message);
        }

        public static bool RestoreDatabase(string backupPath, out string error_message)
        {
            return cls_dal_DB.RestoreDatabase(backupPath, out error_message);
        }
    }
}

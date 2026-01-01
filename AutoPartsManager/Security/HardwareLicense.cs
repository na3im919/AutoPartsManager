using BL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoPartsManager.Security
{
    public class HardwareLicense
    {
        private const string SALT = "APM_SECURE_SALT_2026";

        private static string GetMotherboardSerial()
        {
            try
            {
                using (var searcher =
                    new ManagementObjectSearcher(
                        "SELECT SerialNumber FROM Win32_BaseBoard"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                        return obj["SerialNumber"]?.ToString().Trim();
                }
            }
            catch { }

            return string.Empty;
        }

        private static string GetSystemUUID()
        {
            try
            {
                using (var searcher =
                    new ManagementObjectSearcher(
                        "SELECT UUID FROM Win32_ComputerSystemProduct"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                        return obj["UUID"]?.ToString().Trim();
                }
            }
            catch { }

            return string.Empty;
        }

        private static string BuildFingerprint()
        {
            string mb = GetMotherboardSerial();
            string uuid = GetSystemUUID();

            return $"{SALT}|{mb}|{uuid}";
        }


        private static string HashFingerprint(string input)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hash = sha.ComputeHash(bytes);

                return BitConverter.ToString(hash)
                    .Replace("-", "")
                    .ToLower();
            }
        }

        public static string GetCurrentHardwareHash()
        {
            string fingerprint = BuildFingerprint();
            return HashFingerprint(fingerprint);
        }

        public static string GetStoredHardwareHash()
        {
            return cls_bl_security.GetStoredHardwareHash();
        }


        public static bool ValidateOrActivateFirstTime()
        {
            string currentHash = GetCurrentHardwareHash();
            string storedHash = cls_bl_security.GetStoredHardwareHash();

            // ✅ أول تشغيل → حفظ الهاردوير
            if (string.IsNullOrEmpty(storedHash))
            {
                cls_bl_security.ActivateFirstTime(currentHash);

                MessageBox.Show(
                    "تم تفعيل البرنامج على هذا الجهاز بنجاح",
                    "Activation Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return true;
            }

            // ❌ جهاز مختلف
            if (currentHash != storedHash)
            {
                MessageBox.Show(
                    "هذا البرنامج مرخص للعمل على جهاز واحد فقط",
                    "License Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);

                Environment.Exit(0);
                return false;
            }

            // ✅ نفس الجهاز
            return true;
        }
    }
}


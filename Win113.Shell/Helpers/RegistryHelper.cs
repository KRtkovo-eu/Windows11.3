using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win113.Shell.Helpers
{
    public static class RegistryHelper
    {
        public struct RegistryKeyValue
        {
            public RegistryKeyValue(RegistryKey regBase, string regPath, string regKey)
            {
                RegistryBase = regBase;
                RegistryPath = regPath;
                RegistryKey = regKey;
            }

            public RegistryKey RegistryBase { get; }
            public string RegistryPath { get; }
            public string RegistryKey { get; }
        }

        public static RegistryKeyValue AccentColorRegPath = 
            new RegistryKeyValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\Accent", "AccentColorMenu");
        public static RegistryKeyValue DefaultShell =
            new RegistryKeyValue(Registry.LocalMachine, @"Software\Microsoft\Windows NT\CurrentVersion\WinLogon", "Shell");

        public static UInt32 ReadDword(RegistryKeyValue regPath)
        {
            // Opening the registry key
            RegistryKey rk = regPath.RegistryBase.OpenSubKey(regPath.RegistryPath);
            // Open a subKey as read-only

            if (rk == null)
            {
                return 0;
            }
            else
            {
                try
                {
                    // If the RegistryKey exists I get its value or null is returned.        
                    return (UInt32)((Int32)rk.GetValue(regPath.RegistryKey.ToUpper()));
                }
                catch (Exception e)
                {

                    return 0;
                }
            }
        }

        public static T Read<T>(RegistryKeyValue regPath)
        {
            // Opening the registry key
            RegistryKey rk = regPath.RegistryBase.OpenSubKey(regPath.RegistryPath);
            // Open a subKey as read-only

            if (rk == null)
            {
                return (T)Convert.ChangeType(default(T), typeof(T));
            }
            else
            {
                try
                {
                    // If the RegistryKey exists I get its value or null is returned.        
                    return (T)rk.GetValue(regPath.RegistryKey.ToUpper());
                }
                catch (Exception e)
                {

                    return (T)Convert.ChangeType(default(T), typeof(T));
                }
            }
        }

        public static void Write<T>(RegistryKeyValue regPath, T KeyValue, RegistryValueKind registryValueKind = RegistryValueKind.String)
        {
            // Opening the registry key
            RegistryKey rk = regPath.RegistryBase.OpenSubKey(regPath.RegistryPath, true);
            // Open a subKey as read-only

            if (rk == null)
            {
                rk = regPath.RegistryBase.CreateSubKey(regPath.RegistryPath, true);
            }

            Write(rk, regPath.RegistryKey, KeyValue, registryValueKind);
        }

        public static void Write<T>(RegistryKey rk, string Key, T KeyValue, RegistryValueKind registryValueKind = RegistryValueKind.String)
        {
            rk.SetValue(Key, KeyValue, registryValueKind);
        }

        public static void Delete(RegistryKeyValue regPath, bool deleteKey = false)
        {
            // Opening the registry key
            RegistryKey rk = regPath.RegistryBase.OpenSubKey(regPath.RegistryPath, true);
            // Open a subKey as read-only

            if (rk != null)
            {
                try
                {
                    rk.DeleteValue(regPath.RegistryKey);
                }
                catch (Exception)
                {

                }

                if (deleteKey)
                {
                    regPath.RegistryBase.DeleteSubKey(regPath.RegistryPath);
                }

            }
        }

    }
}
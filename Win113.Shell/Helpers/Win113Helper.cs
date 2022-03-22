using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win113.Shell.Helpers
{
    public static class Win113Helper
    {
        public static bool IsWin113DefaultShell()
        {
            return RegistryHelper.Read<string>(RegistryHelper.DefaultShell).Contains("bobshell.desktop.exe") ? true : false;
        }

        public static Process GetDesktopProcess()
        {
            return Process.GetProcesses().FirstOrDefault(x => x.ProcessName.ToLowerInvariant() == "bobshell.desktop");
        }

        public static bool IsRunningOnlyOneInstance()
        {
            return Process.GetProcesses().Where(x => x.ProcessName.ToLowerInvariant() == "bobshell.desktop").Count() == 1;
        }
    }
}

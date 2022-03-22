using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Win113.Shell;
using Win113.Shell.Helpers;

namespace Win113.Exec
{
    static class Executor
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            switch(args.FirstOrDefault(x => x.StartsWith("shell:::")).Replace("shell:::", ""))
            {
                case "ShutdownDialog":
                    Application.Run(new Shell.Windows.Dialog.ShutdownDialog());
                    break;
                case "DesktopSettings":
                    Application.Run(new Shell.Windows.Dialog.DesktopSettingsWindow());
                    break;
                case "RunDialog":
                    //RunApplication(@"c:\windows\system32\rundll32.exe", "shell32.dll,#61", false, true);
                    RunFileDlg(IntPtr.Zero, IntPtr.Zero, null, "Run...", null, 0);
                    break;
                case "ModemConnect":
                    Application.Run(new Shell.Windows.Dialog.ModemConnect());
                    break;
                case "AnalogClock":
                    Application.Run(new Shell.Windows.Sizable.AnalogClockForm());
                    break;
            }
        }

        [DllImport("shell32.dll", EntryPoint = "#61", CharSet = CharSet.Unicode)]
        public static extern int RunFileDlg(IntPtr hWnd, IntPtr icon, string path, string title, string prompt, uint flags);
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Win113.Shell;

namespace Win113.Taskbar
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            int processCount = Process.GetProcesses().Where(x => x.ProcessName.ToLowerInvariant() == "bobshell.taskbar").Count();
            if (processCount == 1)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                try
                {
                    Application.Run(new Shell.Windows.Special.TaskbarForm());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Win113.Shell.Helpers;

namespace Win113.Desktop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //if (Win113Helper.IsWin113DefaultShell())
            //{
                if (Win113Helper.IsRunningOnlyOneInstance())
                {
                    try
                    {
                        Application.Run(new Shell.Windows.Special.DesktopForm());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            //}
            //else
            //{
            //    Shell.Windows.Special.ContainerForm container = new Shell.Windows.Special.ContainerForm();
            //    Application.Run(container);
            //}
        }
    }
}

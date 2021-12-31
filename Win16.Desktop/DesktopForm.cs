using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;
using Win16.Helpers;

namespace Win16.Desktop
{
    public partial class DesktopForm : Form
    {
        private bool isDefaultShell = false;

        public DesktopForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            isDefaultShell = RegistryHelper.Read<string>(RegistryHelper.DefaultShell) == "win16.progman.exe" ? true : false;

            if (isDefaultShell)
            {
                System.Threading.Thread.Sleep(5 * 1000);

                this.MaximizedBounds = Screen.PrimaryScreen.Bounds;
                this.Bounds = Screen.PrimaryScreen.Bounds;
                this.DesktopBounds = Screen.PrimaryScreen.Bounds;
                this.WindowState = FormWindowState.Maximized;
                this.Width = Screen.PrimaryScreen.Bounds.Width;
                this.Height = Screen.PrimaryScreen.Bounds.Height;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show(RegistryHelper.Read<string>(RegistryHelper.DefaultShell));
                this.Close();
            }

            GlobalHotKey.RegisterHotKey("Win + R", () => WindowsHelper.RunApplication("cmd"));
        }

        // Hide in Alt+Tab
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                // turn on WS_EX_TOOLWINDOW style bit
                cp.ExStyle |= 0x80;
                return cp;
            }
        }

        private void DesktopForm_Activated(object sender, EventArgs e)
        {
            this.SendToBack();
        }

        private void DesktopForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (e.CloseReason == CloseReason.UserClosing);
            // disable user closing the form, but no one else
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            switch (listView1.SelectedItems[0].Text)
            {
                case "Program Manager":
                    Process processName = Process.GetProcesses().FirstOrDefault(x => x.ProcessName.ToLowerInvariant() == "win16.progman");
                    if (processName == null)
                    {
                        //Start application here
                        if (WindowsHelper.RunApplication("win16.progman.exe"))
                        {
                            Cursor.Current = Cursors.Default;
                        }
                    }
                    else
                    {
                        //Set foreground window
                        var handle = processName.MainWindowHandle;
                        SetForegroundWindow(handle);

                        if (IsIconic(handle))
                            ShowWindow(handle, SW_RESTORE);
                    }

                    break;

            }
        }

        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr handle);

        [DllImport("User32.dll")]
        private static extern bool IsIconic(IntPtr handle);

        [DllImport("User32.dll")]
        private static extern bool ShowWindow(IntPtr handle, int nCmdShow);
        private const int SW_RESTORE = 9;
    }
}

using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Win16.Helpers;
using ManagedShell.WindowsTasks;
using ManagedShell.Common.Helpers;
using ManagedShell.Common.Enums;
using System.IO;
using System.Windows.Interop;
using System.Windows;
using System.ComponentModel;
using System.Collections.Specialized;
using Microsoft.Win32;

namespace Win16.Desktop
{
    public partial class DesktopForm : Form
    {
        private bool isDefaultShell = false;
        private Tasks tasks;
        private System.Drawing.Point taskbarDefaultLocation, taskbarCurrentLocation;
        private int taskbarHeight;

        public DesktopForm()
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            isDefaultShell = RegistryHelper.Read<string>(RegistryHelper.DefaultShell) == "win16.shell.exe" ? true : false;

#if !DEBUG
            if (isDefaultShell)
            {
#endif
                System.Threading.Thread.Sleep(5 * 1000);

                this.MaximizedBounds = Screen.PrimaryScreen.Bounds;
                this.Bounds = Screen.PrimaryScreen.Bounds;
                this.DesktopBounds = Screen.PrimaryScreen.Bounds;
                this.WindowState = FormWindowState.Maximized;
                this.Width = Screen.PrimaryScreen.Bounds.Width;
                this.Height = Screen.PrimaryScreen.Bounds.Height;
                taskbarDefaultLocation = desktopIconsListView.Location;

                PersonalizeDesktop();

                // Instantiate service for tracking opened windows
                TasksService tasksService = new TasksService(IconSize.Small);
                tasks = new Tasks(tasksService);
                // Start the service.
                tasks.Initialize();
                // Subscribe on event - list of windows changed
                tasks.GroupedWindows.CollectionChanged += GroupedWindows_CollectionChanged;
                desktopIconsListView.LargeImageList = iconsOfOpened;
                desktopIconsListView.SmallImageList = iconsOfOpened;
                TrackWindows();

                RegistryMonitor monitor = new
                RegistryMonitor(RegistryHive.LocalMachine, @"Software\KRtkovo.eu\Win16.Shell\Desktop");
                monitor.RegChanged += new EventHandler(RegistryWatchdog);
                monitor.Start();

                // Register global hotkeys (keyboard shortcuts)
                GlobalHotKey.RegisterHotKey("Win + R", () => WindowsHelper.RunApplication(@"c:\windows\system32\rundll32.exe", "shell32.dll,#61", false, true));

                // Finish
                WindowsHelper.PlaySound(Properties.Resources.TADA);
#if !DEBUG
            }
            else
            {
                System.Windows.Forms.MessageBox.Show(RegistryHelper.Read<string>(RegistryHelper.DefaultShell));
                this.Close();
            }
#endif

            
        }

        private void RegistryWatchdog(object sender, EventArgs e)
        {
            PersonalizeDesktop();
        }

        private void PersonalizeDesktop()
        {
            Color desktopBackColor = Color.FromName(RegistryHelper.Read<string>(new RegistryHelper.RegistryKeyValue(Registry.LocalMachine, @"Software\KRtkovo.eu\Win16.Shell\Desktop", "BackColor")));
            this.BackColor = desktopBackColor;
            desktopIconsListView.BackColor = desktopBackColor;

            taskbarHeight = Convert.ToInt32(RegistryHelper.Read<string>(new RegistryHelper.RegistryKeyValue(Registry.LocalMachine, @"Software\KRtkovo.eu\Win16.Shell\Desktop", "TaskbarSize")));
            taskbarCurrentLocation = new System.Drawing.Point(taskbarDefaultLocation.X, taskbarDefaultLocation.Y - taskbarHeight);
            ResizeSpaceForDesktopIcons();


            this.Invalidate(true);
            this.Update();
        }

        private void GroupedWindows_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            TrackWindows();
        }

        private void TrackWindows()
        {
            // Access the window listing.
            var windowsOpened = tasks.GroupedWindows;

            foreach (ApplicationWindow windowOpened in windowsOpened)
            {
                windowOpened.PropertyChanged -= UpdateDesktopIcons;
                windowOpened.PropertyChanged += UpdateDesktopIcons;

                RemoveExitedIcons();

                var icoName = windowOpened.Title.Replace(" ", "");
                System.Windows.Controls.Image img = new System.Windows.Controls.Image();
                img.Source = windowOpened.Icon;

                if (img != null)
                {
                    var ico = System.Drawing.Icon.ExtractAssociatedIcon(windowOpened.WinFileName).ToBitmap();

                    if (!iconsOfOpened.Images.ContainsKey(icoName))
                    {
                        iconsOfOpened.Images.Add(icoName, ico);
                    }
                }
            }

            this.Invalidate(true);
            this.Update();
        }

        private void UpdateDesktopIcons(object sender, PropertyChangedEventArgs e)
        {
            ApplicationWindow windowOpened = (ApplicationWindow)sender;

            if(windowOpened.Title != "Program Manager" && windowOpened.ShowInTaskbar)
            {
                var icoName = windowOpened.Title.Replace(" ", "");

                // Set default icon when program icon is not found in collection
                if(!iconsOfOpened.Images.ContainsKey(icoName))
                {
                    icoName = "executable.ico";
                }

                var itemName = GetWindowThreadProcessId(windowOpened.Handle, out uint processId).ToString();
                if (windowOpened.IsMinimized)
                {
                    if (!desktopIconsListView.Items.ContainsKey(itemName))
                    {
                        var item = new ListViewItem(windowOpened.Title, icoName);
                        item.Name = itemName;
                        item.Tag = windowOpened.Handle;

                        desktopIconsListView.Items.Add(item);
                    }
                }
                // Is not minimized
                else
                {
                    if (desktopIconsListView.Items.ContainsKey(itemName))
                    {
                        desktopIconsListView.Items.RemoveAt(desktopIconsListView.Items.IndexOfKey(itemName));
                    }
                }

                this.Invalidate(true);
                this.Update();
            }

            ResizeSpaceForDesktopIcons();
        }

        private void ResizeSpaceForDesktopIcons()
        {
            // Increase space when too much windows opened
            var occupiedSpaceWithIcons = ((desktopIconsListView.Items.Count) * 73);
            if (occupiedSpaceWithIcons > desktopIconsListView.Bounds.Width)
            {
                desktopIconsListView.Height = 82 + 70;
                desktopIconsListView.Location = new System.Drawing.Point(taskbarCurrentLocation.X, taskbarCurrentLocation.Y - 70);
            }
            else
            {
                desktopIconsListView.Height = 82;
                desktopIconsListView.Location = taskbarCurrentLocation;
            }
        }

        private void RemoveExitedIcons()
        {
            // Remove all exited applications shown on desktop
            foreach (ListViewItem item in desktopIconsListView.Items)
            {
                if(item.Text != "Program Manager")
                {
                    var windowsOpened = tasks.GroupedWindows;
                    bool iconToDelete = true;
                    foreach (ApplicationWindow w in windowsOpened)
                    {
                        var itemName = GetWindowThreadProcessId(w.Handle, out uint processId).ToString();
                        if (item.Name == itemName)
                        {
                            iconToDelete = false;
                        }
                    }

                    if (iconToDelete && desktopIconsListView.Items.ContainsKey(item.Name))
                    {
                        desktopIconsListView.Items.RemoveAt(desktopIconsListView.Items.IndexOfKey(item.Name));
                    }
                }
            }
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

            switch (desktopIconsListView.SelectedItems[0].Text)
            {
                case "Program Manager":
                    Process processName = Process.GetProcesses().FirstOrDefault(x => x.ProcessName.ToLowerInvariant() == "win16.shell");
                    if (processName == null)
                    {
                        //Start application here
                        if (WindowsHelper.RunApplication("win16.shell.exe"))
                        {
                            Cursor.Current = Cursors.Default;
                        }
                    }
                    else
                    {
                        //Set foreground window
                        var progmanHandle = processName.MainWindowHandle;
                        SetForegroundWindow(progmanHandle);

                        if (IsIconic(progmanHandle))
                            ShowWindow(progmanHandle, SW_RESTORE);
                    }

                    break;
                default:
                    IntPtr handle = (IntPtr)desktopIconsListView.SelectedItems[0].Tag;
                    SetForegroundWindow(handle);

                    if (IsIconic(handle))
                        ShowWindow(handle, SW_RESTORE);
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

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);

        private void DesktopForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Dispose of the service and icons.
            IconHelper.DisposeIml();
            tasks.Dispose();

            // Exit the application.
            System.Windows.Application.Current.Shutdown();
        }
    }
}

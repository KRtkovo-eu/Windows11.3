using ManagedShell.Common.Enums;
using ManagedShell.Common.Helpers;
using ManagedShell.WindowsTasks;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Win113.Shell.Helpers;
using Win113.Shell;

namespace Win113.Shell.Windows.Special
{
    public partial class DesktopForm : Form
    {
        private bool isDefaultShell = false;
        private Tasks tasks;
        private Point taskpanelDefaultLocation, taskpanelCurrentLocation;



        public DesktopForm()
        {
            InitializeComponent();

            // Show boot image
            BootImageForm bootImageForm = new BootImageForm();
            var bootImageThread = new System.Threading.Thread(delegate ()
            {
                Application.Run(bootImageForm);
            });
            bootImageThread.Start();

            bootImageForm.UpdateStatus("Preparing network connection...");
            System.Threading.Thread.Sleep(1 * 1000);
            bootImageForm.UpdateStatus("Loading your personal settings...");

            // Set desktop form
            this.DoubleBuffered = true;

            isDefaultShell = Win113Helper.IsWin113DefaultShell();

            if (isDefaultShell)
            {
                System.Threading.Thread.Sleep(4 * 1000);

                this.MaximizedBounds = Screen.PrimaryScreen.Bounds;
                this.Bounds = Screen.PrimaryScreen.Bounds;
                this.DesktopBounds = Screen.PrimaryScreen.Bounds;
                this.Width = Screen.PrimaryScreen.WorkingArea.Width;
                this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            }
            else
            {
                this.MaximizedBounds = Screen.PrimaryScreen.WorkingArea;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.Location = new Point(50, 50);
                this.ShowInTaskbar = true;
                this.ShowIcon = true;
            }
            taskpanelDefaultLocation = desktopIconsListView.Location;

            bootImageForm.UpdateStatus("Applying your personal settings...");

            PersonalizeDesktop();

            SystemEvents.DisplaySettingsChanged += new EventHandler(SystemEvents_DisplaySettingsChanged);

            // Instantiate service for tracking opened windows
            TasksService tasksService = new TasksService(IconSize.Medium);
            tasks = new Tasks(tasksService);
            // Start the service.
            tasks.Initialize();
            // Subscribe on event - list of windows changed
            tasks.GroupedWindows.CollectionChanged += GroupedWindows_CollectionChanged;
            desktopIconsListView.LargeImageList = iconsOfOpened;
            desktopIconsListView.SmallImageList = iconsOfOpened;
            TrackWindows();

            // Monitor changes is registry
            RegistryMonitor monitor = new
            RegistryMonitor(RegistryHive.CurrentUser, @"Software\KRtkovo.eu\Win113.Shell\Desktop");
            monitor.RegChanged += new EventHandler(RegistryWatchdog);
            monitor.Start();

            // Register global hotkeys (keyboard shortcuts)
            GlobalHotKey.RegisterHotKey("Win + R", () => WindowsHelper.ShowDialog("Run"));

            bootImageForm.UpdateStatus("Done.");

            // Finish
            WindowsHelper.PlaySound(Properties.Resources.TADA);

            bootImageForm.CloseForm();
            //bootImageThread.Abort();

            // Remove the Program Manager added on desktop
            desktopIconsListView.Items.Clear();

            // Run Program Manager
            WindowsHelper.RunApplication(AppDomain.CurrentDomain.BaseDirectory + "\\bobshell.progman.exe");
        }

        public void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            if (isDefaultShell)
            {
                this.MaximizedBounds = Screen.PrimaryScreen.Bounds;
                this.Bounds = Screen.PrimaryScreen.Bounds;
                this.DesktopBounds = Screen.PrimaryScreen.Bounds;
                this.Width = Screen.PrimaryScreen.WorkingArea.Width;
                this.Height = Screen.PrimaryScreen.WorkingArea.Height;
                
            }
            taskpanelDefaultLocation = desktopIconsListView.Location;
        }

        private void RegistryWatchdog(object sender, EventArgs e)
        {
            PersonalizeDesktop();
        }

        private void PersonalizeDesktop()
        {
            // Desktop colors
            UInt32 regBackColor = RegistryHelper.ReadDword(new RegistryHelper.RegistryKeyValue(Registry.CurrentUser, @"Software\KRtkovo.eu\Win113.Shell\Desktop", "BackColor"));
            Color desktopBackColor = regBackColor == 0 ? Color.Teal : WindowsHelper.DWORD2RGBA(regBackColor);
            this.BackColor = desktopBackColor;
            desktopIconsListView.BackColor = desktopBackColor;

            var desktopForeColor = RegistryHelper.ReadDword(new RegistryHelper.RegistryKeyValue(Registry.CurrentUser, @"Software\KRtkovo.eu\Win113.Shell\Desktop", "ForeColor"));
            this.ForeColor = desktopForeColor == 0 ? Color.White : WindowsHelper.DWORD2RGBA(desktopForeColor);
            desktopIconsListView.ForeColor = desktopForeColor == 0 ? Color.White : WindowsHelper.DWORD2RGBA(desktopForeColor);


            //Handle taskbar
            var taskbarChangeTrigger = RegistryHelper.Read<string>(new RegistryHelper.RegistryKeyValue(Registry.CurrentUser, @"Software\KRtkovo.eu\Win113.Shell\Desktop", "TaskbarChangeTrigger"));
            var taskbarHeight = Convert.ToInt32(RegistryHelper.Read<string>(new RegistryHelper.RegistryKeyValue(Registry.CurrentUser, @"Software\KRtkovo.eu\Win113.Shell\Taskbar", "TaskbarHeight")));
            var taskbarWidth = Convert.ToInt32(RegistryHelper.Read<string>(new RegistryHelper.RegistryKeyValue(Registry.CurrentUser, @"Software\KRtkovo.eu\Win113.Shell\Taskbar", "TaskbarWidth")));
            var taskbarLocX = Convert.ToInt32(RegistryHelper.Read<string>(new RegistryHelper.RegistryKeyValue(Registry.CurrentUser, @"Software\KRtkovo.eu\Win113.Shell\Taskbar", "TaskbarX")));
            var taskbarLocY = Convert.ToInt32(RegistryHelper.Read<string>(new RegistryHelper.RegistryKeyValue(Registry.CurrentUser, @"Software\KRtkovo.eu\Win113.Shell\Taskbar", "TaskbarY")));
            var taskbarDock = RegistryHelper.Read<string>(new RegistryHelper.RegistryKeyValue(Registry.CurrentUser, @"Software\KRtkovo.eu\Win113.Shell\Taskbar", "Dock"));
            var hidePanelTaskWhenTaskbarActive = Convert.ToInt32(RegistryHelper.Read<string>(new RegistryHelper.RegistryKeyValue(Registry.CurrentUser, @"Software\KRtkovo.eu\Win113.Shell\Desktop", "HidePanelTaskWhenTaskbarActive")));
            Process taskbarProcess = Process.GetProcesses().FirstOrDefault(x => x.ProcessName.ToLowerInvariant() == "bobshell.taskbar");
            if (taskbarProcess != null && taskbarChangeTrigger != "-1")
            {
                switch(taskbarDock)
                {
                    case "Bottom":
                        taskpanelCurrentLocation = new Point(taskpanelDefaultLocation.X, taskpanelDefaultLocation.Y - taskbarHeight);
                        break;
                    case "Left":
                        taskpanelCurrentLocation = new Point(taskpanelDefaultLocation.X + taskbarWidth, taskpanelDefaultLocation.Y);
                        break;
                    default:
                        taskpanelCurrentLocation = taskpanelDefaultLocation;
                        break;
                }


                if (hidePanelTaskWhenTaskbarActive == 1)
                {
                    desktopIconsListView.Hide();
                }
                else
                {
                    if (!desktopIconsListView.Visible)
                    {
                        desktopIconsListView.Show();
                    }
                }
            }
            else
            {
                taskpanelCurrentLocation = new Point(taskpanelDefaultLocation.X, taskpanelDefaultLocation.Y);
                desktopIconsListView.Show();
            }
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

            RemoveExitedIcons();

            foreach (ApplicationWindow windowOpened in windowsOpened)
            {
                windowOpened.PropertyChanged -= UpdateDesktopIcons;
                windowOpened.PropertyChanged += UpdateDesktopIcons;

                var icoName = windowOpened.Handle.ToString();
                System.Windows.Controls.Image img = new System.Windows.Controls.Image();
                img.Source = windowOpened.Icon;

                if (img != null)
                {
                    var ico = Win32ApiHelper.GetIcon(windowOpened.WinFileName).ToBitmap();

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

            //if(windowOpened.Title != "Program Manager" && windowOpened.ShowInTaskbar)
            if (windowOpened.ShowInTaskbar)
            {
                UpdateDesktopIcons(windowOpened.Title, windowOpened.Handle, windowOpened.IsMinimized);
            }
        }

        delegate void UpdateDesktopIconsCallback(string windowOpenedTitle, object windowOpenedHandle, bool windowdOpenedIsMinimized);

        private void UpdateDesktopIcons(string windowOpenedTitle, object windowOpenedHandle, bool windowOpenedIsMinimized)
        {
            if (desktopIconsListView.InvokeRequired)
            {
                UpdateDesktopIconsCallback d = new UpdateDesktopIconsCallback(UpdateDesktopIcons);
                this.Invoke(d, new object[] { windowOpenedTitle, windowOpenedHandle, windowOpenedIsMinimized });
            }
            else
            { 
                var icoName = windowOpenedHandle.ToString();

                // Set default icon when program icon is not found in collection
                if (!iconsOfOpened.Images.ContainsKey(icoName))
                {
                    icoName = "executable.ico";
                }

                if (windowOpenedIsMinimized)
                {
                    if (!desktopIconsListView.Items.ContainsKey(icoName))
                    {
                        var item = new ListViewItem(windowOpenedTitle, icoName);
                        item.Name = icoName;
                        item.Tag = windowOpenedHandle;

                        desktopIconsListView.Items.Add(item);
                    }
                }
                // Is not minimized
                else
                {
                    if (desktopIconsListView.Items.ContainsKey(icoName))
                    {
                        desktopIconsListView.Items.RemoveAt(desktopIconsListView.Items.IndexOfKey(icoName));
                    }
                }

                this.Invalidate(true);
                this.Update();

                ResizeSpaceForDesktopIcons();
            }
        }

        private void ResizeSpaceForDesktopIcons()
        {
            // Increase space when too much windows opened
            var occupiedSpaceWithIcons = ((desktopIconsListView.Items.Count) * 73);
            if (occupiedSpaceWithIcons > desktopIconsListView.Bounds.Width)
            {
                desktopIconsListView.Height = 82 + 70;
                desktopIconsListView.Location = new System.Drawing.Point(taskpanelCurrentLocation.X, taskpanelCurrentLocation.Y - 70);
            }
            else
            {
                desktopIconsListView.Height = 82;
                desktopIconsListView.Location = taskpanelCurrentLocation;
            }
        }

        private void RemoveExitedIcons()
        {
            // Remove all exited applications shown on desktop
            foreach (ListViewItem item in desktopIconsListView.Items)
            {
                //if(item.Text != "Program Manager")
                //{
                    var windowsOpened = tasks.GroupedWindows;
                    bool iconToDelete = true;
                    foreach (ApplicationWindow w in windowsOpened)
                    {
                        var itemName = w.Handle.ToString();
                        if (item.Name == itemName)
                        {
                            iconToDelete = false;
                        }
                    }

                    if (iconToDelete && desktopIconsListView.Items.ContainsKey(item.Name))
                    {
                        desktopIconsListView.Items.RemoveAt(desktopIconsListView.Items.IndexOfKey(item.Name));
                    }
                //}
            }
        }

        // Hide in Alt+Tab
        protected override CreateParams CreateParams
        {
            get
            {
                if(isDefaultShell)
                {
                    CreateParams cp = base.CreateParams;
                    // turn on WS_EX_TOOLWINDOW style bit
                    cp.ExStyle |= 0x80;
                    return cp;
                }
                else
                {
                    CreateParams cp = base.CreateParams;
                    cp.ExStyle |= 0x80;
                    return cp;
                }
            }
        }

        private void DesktopForm_Activated(object sender, EventArgs e)
        {
            if(Win113Helper.IsWin113DefaultShell())
            {
                this.SendToBack();
            }
        }

        private void DesktopForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // disable user closing the form, but no one else
            if (isDefaultShell)
                e.Cancel = (e.CloseReason == CloseReason.UserClosing);
            
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (desktopIconsListView.SelectedItems.Count == 1)
            {
                switch (desktopIconsListView.SelectedItems[0].Text)
                {
                    case "Program Manager":
                        RunProgramManager();
                        break;
                    default:
                        IntPtr handle = (IntPtr)desktopIconsListView.SelectedItems[0].Tag;
                        Win32ApiHelper.SetForegroundWindow(handle);

                        //if (IsIconic(handle))
                        Win32ApiHelper.ShowWindow(handle, Win32ApiHelper.SW_RESTORE);
                        break;
                }
            }
        }

        private void RunProgramManager()
        {
            Process processName = Process.GetProcesses().FirstOrDefault(x => x.ProcessName.ToLowerInvariant() == "bobshell.progman");
            if (processName == null)
            {
                //Start application here
                if (WindowsHelper.RunApplication(AppDomain.CurrentDomain.BaseDirectory + "\\bobshell.progman.exe"))
                {
                    Cursor.Current = Cursors.Default;
                }
            }
            else
            {
                //Set foreground window
                var progmanHandle = processName.MainWindowHandle;
                Win32ApiHelper.SetForegroundWindow(progmanHandle);

                //if (IsIconic(progmanHandle))
                Win32ApiHelper.ShowWindow(progmanHandle, Win32ApiHelper.SW_RESTORE);
            }
        }

        private void DesktopForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void DesktopForm_ResizeEnd(object sender, EventArgs e)
        {
            taskpanelDefaultLocation = desktopIconsListView.Location;
        }

        private void DesktopForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Dispose of the service and icons.
            IconHelper.DisposeIml();
            tasks.Dispose();

            Application.Exit();
        }
    }
}

using ManagedShell.Common.Enums;
using ManagedShell.Common.Helpers;
using ManagedShell.WindowsTasks;
using Microsoft.Win32;
using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Win113.Shell.Helpers;
using static Win113.Shell.Helpers.Win32ApiHelper;

namespace Win113.Shell.Windows.Special
{
    public partial class TaskbarForm : Form
    {
        private Tasks tasks;
        private const int cCaption = 5;   // Caption bar height;
        private bool startButtonSelected = false;
        private bool closeButtonSelected = false;

        public TaskbarForm()
        {
            InitializeComponent();

            CallbackMessageID = RegisterCallbackMessage();
            if (CallbackMessageID == 0)
                throw new Exception("RegisterCallbackMessage failed");

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            var height = RegistryHelper.Read<string>(new RegistryHelper.RegistryKeyValue(Registry.CurrentUser, @"Software\KRtkovo.eu\Win113.Shell\Taskbar", "TaskbarHeight"));
            var width = RegistryHelper.Read<string>(new RegistryHelper.RegistryKeyValue(Registry.CurrentUser, @"Software\KRtkovo.eu\Win113.Shell\Taskbar", "TaskbarWidth"));
            var locX = RegistryHelper.Read<string>(new RegistryHelper.RegistryKeyValue(Registry.CurrentUser, @"Software\KRtkovo.eu\Win113.Shell\Taskbar", "TaskbarX"));
            var locY = RegistryHelper.Read<string>(new RegistryHelper.RegistryKeyValue(Registry.CurrentUser, @"Software\KRtkovo.eu\Win113.Shell\Taskbar", "TaskbarY"));
            var dock = RegistryHelper.Read<string>(new RegistryHelper.RegistryKeyValue(Registry.CurrentUser, @"Software\KRtkovo.eu\Win113.Shell\Taskbar", "Dock"));
            var hidePanelTaskWhenTaskbarActive = Convert.ToInt32(RegistryHelper.Read<string>(new RegistryHelper.RegistryKeyValue(Registry.CurrentUser, @"Software\KRtkovo.eu\Win113.Shell\Desktop", "HidePanelTaskWhenTaskbarActive")));
            hideDesktopTaskPanelToolStripMenuItem.Checked = (hidePanelTaskWhenTaskbarActive == 1 ? true : false);

            if (height != "") this.Height = Convert.ToInt32(height);
            if (width != "") this.Width = Convert.ToInt32(width);
            if (locX != "" && locY != "")
            {
                this.Location = new Point(Convert.ToInt32(locX), Convert.ToInt32(locY));
            }
            else
            {
                this.Location = new Point(0, Screen.PrimaryScreen.Bounds.Height - this.Height);
            }
            //this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.TopMost = true;

            if(dock != "Float")
            {
                AppBarEdges dockEdge;
                Enum.TryParse(dock, out dockEdge);

                PositionAppBar(dockEdge, false, false);
            }
            else
            {
                floatToolStripMenuItem.Checked = true;
                dockToolStripMenuItem.Checked = false;

                bottomToolStripMenuItem.Checked = false;
                topToolStripMenuItem.Checked = false;
                leftToolStripMenuItem.Checked = false;
                rightToolStripMenuItem.Checked = false;
                this.MinimumSize = new Size(450, 61);
            }

            SystemEvents.DisplaySettingsChanged += new EventHandler(SystemEvents_DisplaySettingsChanged);

            // Instantiate service for tracking opened windows
            TasksService tasksService = new TasksService(IconSize.Medium);
            tasks = new Tasks(tasksService);
            // Start the service.
            tasks.Initialize();
            // Subscribe on event - list of windows changed
            tasks.GroupedWindows.CollectionChanged += GroupedWindows_CollectionChanged;
            taskbarIconsListView.LargeImageList = iconsOnTaskbar;
            taskbarIconsListView.SmallImageList = iconsOnTaskbar;
            ListView.CheckForIllegalCrossThreadCalls = false;
            TrackWindows();

            clockTimer_Tick(null, null);
            clockTimer.Start();
        }

        public void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            //this.MaximizedBounds = Screen.PrimaryScreen.Bounds;
            //this.Bounds = Screen.PrimaryScreen.Bounds;
            //this.DesktopBounds = Screen.PrimaryScreen.Bounds;
            //this.Width = Screen.PrimaryScreen.Bounds.Width;
            //this.Height = Screen.PrimaryScreen.Bounds.Height;
        }

        private void StartButton_Paint(object sender, PaintEventArgs e)
        {
            if(startButtonSelected)
            {
                ControlPaint.DrawBorder(e.Graphics, StartButton.ClientRectangle,
                    SystemColors.ControlLightLight, 1, ButtonBorderStyle.Inset,
                    SystemColors.ControlLightLight, 1, ButtonBorderStyle.Inset,
                    SystemColors.ControlLightLight, 2, ButtonBorderStyle.Inset,
                    SystemColors.ControlLightLight, 2, ButtonBorderStyle.Inset);
            }
            else
            {
                ControlPaint.DrawBorder(e.Graphics, StartButton.ClientRectangle,
                    SystemColors.ControlLightLight, 1, ButtonBorderStyle.Outset,
                    SystemColors.ControlLightLight, 1, ButtonBorderStyle.Outset,
                    SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
                    SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset);
            }
        }

        private void Taskbar_Shown(object sender, EventArgs e)
        {
            RegistryHelper.Write<string>(new RegistryHelper.RegistryKeyValue(Registry.CurrentUser, @"Software\KRtkovo.eu\Win113.Shell\Desktop", "TaskbarChangeTrigger"), new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds().ToString());
        }

        private void Taskbar_Resize(object sender, EventArgs e)
        {
            if(this.Height > 83)
            {
                StartButton.Height = 44;
            }
            else
            {
                StartButton.Height = 22;
            }

            statusPanel.Refresh();
        }


        private void TaskbarForm_Load(object sender, EventArgs e)
        {

        }

        private void GroupedWindows_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
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
                    Icon ico = new Icon(Win32ApiHelper.GetIcon(windowOpened.WinFileName), 24, 24);
                    var bmp = ico.ToBitmap();

                    if (!iconsOnTaskbar.Images.ContainsKey(icoName))
                    {
                        iconsOnTaskbar.Images.Add(icoName, bmp);
                    }
                }
            }

            // Prevent taskbar from beeing shown in state scroll out of bounds (useful when labels of opened windows are long)
            taskbarIconsListView.AutoScrollOffset = new Point(taskbarIconsListView.Bounds.X, 0);

            this.Invalidate(true);
            this.Update();
        }


        private void UpdateDesktopIcons(object sender, PropertyChangedEventArgs e)
        {
            ApplicationWindow applicationWindow = (ApplicationWindow)sender;
            if (applicationWindow.ShowInTaskbar)
            {
                UpdateDesktopIcons(applicationWindow.Title, applicationWindow.Handle, Convert.ToInt32(applicationWindow.ProcId));
            }
        }


        delegate void UpdateDesktopIconsCallback(string windowOpenedTitle, object windowOpenedHandle, int windowOpenedProcID);

        private void UpdateDesktopIcons(string windowOpenedTitle, object windowOpenedHandle, int windowOpenedProcID)
        {
            if (taskbarIconsListView.InvokeRequired)
            {
                UpdateDesktopIconsCallback d = new UpdateDesktopIconsCallback(UpdateDesktopIcons);
                this.Invoke(d, new object[] { windowOpenedTitle, windowOpenedHandle, windowOpenedProcID });
            }
            else
            {
                var icoName = windowOpenedHandle.ToString();

                // Set default icon when program icon is not found in collection
                if (!iconsOnTaskbar.Images.ContainsKey(icoName))
                {
                    icoName = "executable.ico";
                }

                // If window is new, add it to the listview
                if (!taskbarIconsListView.Items.ContainsKey(icoName))
                {
                    var item = new ListViewItem(windowOpenedTitle, icoName);
                    item.Name = icoName;
                    item.Tag = windowOpenedHandle;

                    taskbarIconsListView.Items.Add(item);
                }
                // If window exists and title changed, edit it in listview
                else
                {
                    taskbarIconsListView.Items[taskbarIconsListView.Items.IndexOfKey(icoName)].Text = windowOpenedTitle;
                }

                this.Invalidate(true);
                this.Update();
            }
        }

        private void RemoveExitedIcons()
        {
            // Remove all exited applications shown on desktop
            foreach (ListViewItem item in taskbarIconsListView.Items)
            {
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

                if (iconToDelete && taskbarIconsListView.Items.ContainsKey(item.Name))
                {
                    taskbarIconsListView.Items.RemoveAt(taskbarIconsListView.Items.IndexOfKey(item.Name));
                }
            }
        }

        private void statusPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, statusPanel.ClientRectangle,
            SystemColors.ControlLightLight, 1, ButtonBorderStyle.Inset,
            SystemColors.ControlLightLight, 1, ButtonBorderStyle.Inset,
            SystemColors.ControlLightLight, 2, ButtonBorderStyle.Inset,
            SystemColors.ControlLightLight, 2, ButtonBorderStyle.Inset);
        }

        private void Taskbar_FormClosed(object sender, FormClosedEventArgs e)
        {
            RegistryHelper.Write<string>(new RegistryHelper.RegistryKeyValue(Registry.CurrentUser, @"Software\KRtkovo.eu\Win113.Shell\Desktop", "TaskbarChangeTrigger"), "-1");

            // Dispose of the service and icons.
            IconHelper.DisposeIml();
            tasks.Dispose();

            clockTimer.Stop();
        }

        private void Taskbar_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (e.CloseReason == CloseReason.UserClosing);
            // disable user closing the form, but no one else
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

        // Make form resizable
        private const int
            HTLEFT = 10,
            HTRIGHT = 11,
            HTTOP = 12,
            HTTOPLEFT = 13,
            HTTOPRIGHT = 14,
            HTBOTTOM = 15,
            HTBOTTOMLEFT = 16,
            HTBOTTOMRIGHT = 17;

        const int _ = 10; // you can rename this variable if you like

        Rectangle Top { get { return new Rectangle(0, 0, this.ClientSize.Width, _); } }
        Rectangle Left { get { return new Rectangle(0, 0, _, this.ClientSize.Height); } }
        Rectangle Bottom { get { return new Rectangle(0, this.ClientSize.Height - _, this.ClientSize.Width, _); } }
        Rectangle Right { get { return new Rectangle(this.ClientSize.Width - _, 0, _, this.ClientSize.Height); } }

        private void StartButton_Click(object sender, EventArgs e)
        {
        
        }

        private void StartButton_MouseDown(object sender, MouseEventArgs e)
        {
            startButtonSelected = true;
            (sender as System.Windows.Forms.Button).Invalidate();
        }

        private void StartButton_MouseUp(object sender, MouseEventArgs e)
        {
            startButtonSelected = false;
            (sender as System.Windows.Forms.Button).Invalidate();
        }

        private void closeButton_MouseDown(object sender, MouseEventArgs e)
        {
            closeButtonSelected = true;
            (sender as System.Windows.Forms.Button).Invalidate();
        }

        private void closeButton_MouseUp(object sender, MouseEventArgs e)
        {
            closeButtonSelected = false;
            (sender as System.Windows.Forms.Button).Invalidate();
        }

        private void closeButton_Paint(object sender, PaintEventArgs e)
        {
            if (closeButtonSelected)
            {
                ControlPaint.DrawBorder(e.Graphics, closeButton.ClientRectangle,
                    SystemColors.ControlLightLight, 1, ButtonBorderStyle.Inset,
                    SystemColors.ControlLightLight, 1, ButtonBorderStyle.Inset,
                    SystemColors.ControlLightLight, 2, ButtonBorderStyle.Inset,
                    SystemColors.ControlLightLight, 2, ButtonBorderStyle.Inset);
            }
            else
            {
                ControlPaint.DrawBorder(e.Graphics, closeButton.ClientRectangle,
                    SystemColors.ControlLightLight, 1, ButtonBorderStyle.Outset,
                    SystemColors.ControlLightLight, 1, ButtonBorderStyle.Outset,
                    SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
                    SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            configMenu.Show(Cursor.Position);           
        }

        private void taskbarIconsListView_DoubleClick(object sender, EventArgs e)
        {
            IntPtr handle = (IntPtr)taskbarIconsListView.SelectedItems[0].Tag;
            Win32ApiHelper.SetForegroundWindow(handle);

            //if (IsIconic(handle))
            Win32ApiHelper.ShowWindow(handle, Win32ApiHelper.SW_RESTORE);
        }

        private void clockTimer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;

            var clockText = "";
            clockText += now.ToLocalTime().ToLongTimeString();
            clockText += Environment.NewLine;
            clockText += now.ToLocalTime().ToString("dddd");
            clockText += Environment.NewLine;
            clockText += now.ToLocalTime().ToShortDateString();

            clockLabel.Text = clockText;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void topToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PositionAppBar(AppBarEdges.Top);
        }

        private void bottomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PositionAppBar(AppBarEdges.Bottom);
        }

        private void leftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PositionAppBar(AppBarEdges.Left);
        }

        private void rightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PositionAppBar(AppBarEdges.Right);
        }

        private void floatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PositionAppBar(AppBarEdges.Float);
        }

        
        private void PositionAppBar(AppBarEdges position, bool writeToRegistry = true, bool resizePanel = true)
        {
            taskbarIconsListView.Location = new Point(69, 10);
            taskbarIconsListView.Height = this.Height - 13;
            taskbarIconsListView.Width = this.Width - 165;
            taskbarIconsListView.MaximumSize = new Size(0, 0);
            statusPanel.Visible = true;

            if (position == AppBarEdges.Float)
            {
                this.MinimumSize = new Size(450, 61);

                floatToolStripMenuItem.Checked = true;
                dockToolStripMenuItem.Checked = false;

                bottomToolStripMenuItem.Checked = false;
                topToolStripMenuItem.Checked = false;
                leftToolStripMenuItem.Checked = false;
                rightToolStripMenuItem.Checked = false;

                if(resizePanel)
                {
                    this.Width = 800;
                    this.Height = 61;
                }
            }
            else
            {
                this.MinimumSize = new Size(65, 61);

                floatToolStripMenuItem.Checked = false;
                dockToolStripMenuItem.Checked = true;

                switch (position)
                {
                    case AppBarEdges.Bottom:
                        bottomToolStripMenuItem.Checked = true;
                        topToolStripMenuItem.Checked = false;
                        leftToolStripMenuItem.Checked = false;
                        rightToolStripMenuItem.Checked = false;

                        if (resizePanel)
                        {
                            this.Height = 61;
                        }

                        break;
                    case AppBarEdges.Top:
                        bottomToolStripMenuItem.Checked = false;
                        topToolStripMenuItem.Checked = true;
                        leftToolStripMenuItem.Checked = false;
                        rightToolStripMenuItem.Checked = false;

                        if (resizePanel)
                        {
                            this.Height = 61;
                        }

                        break;
                    case AppBarEdges.Left:
                        bottomToolStripMenuItem.Checked = false;
                        topToolStripMenuItem.Checked = false;
                        leftToolStripMenuItem.Checked = true;
                        rightToolStripMenuItem.Checked = false;

                        taskbarIconsListView.Location = new Point(5, 61);
                        taskbarIconsListView.Height = this.Height - 61;
                        taskbarIconsListView.Width = this.Width - 12;
                        taskbarIconsListView.MaximumSize = new Size(taskbarIconsListView.Width, taskbarIconsListView.Height);

                        statusPanel.Visible = false;

                        if (resizePanel)
                        {
                            this.Width = 67;
                        }
                        
                        break;
                    case AppBarEdges.Right:
                        bottomToolStripMenuItem.Checked = false;
                        topToolStripMenuItem.Checked = false;
                        leftToolStripMenuItem.Checked = false;
                        rightToolStripMenuItem.Checked = true;

                        taskbarIconsListView.Location = new Point(5, 61);
                        taskbarIconsListView.Height = this.Height - 61;
                        taskbarIconsListView.Width = this.Width - 12;
                        taskbarIconsListView.MaximumSize = new Size(taskbarIconsListView.Width, taskbarIconsListView.Height);

                        statusPanel.Visible = false;

                        if (resizePanel)
                        {
                            this.Width = 67;
                        }

                        break;
                }
            }

            // Change application edge
            m_PrevSize = Size;
            this.Edge = position;
            taskbarIconsListView.Refresh();

            if (writeToRegistry)
            {
                RegistryHelper.Write<string>(new RegistryHelper.RegistryKeyValue(Registry.CurrentUser, @"Software\KRtkovo.eu\Win113.Shell\Taskbar", "Dock"), position.ToString());
                RegistryHelper.Write<string>(new RegistryHelper.RegistryKeyValue(Registry.CurrentUser, @"Software\KRtkovo.eu\Win113.Shell\Taskbar", "TaskbarHeight"), this.Height.ToString());
                RegistryHelper.Write<string>(new RegistryHelper.RegistryKeyValue(Registry.CurrentUser, @"Software\KRtkovo.eu\Win113.Shell\Taskbar", "TaskbarWidth"), this.Width.ToString());
                RegistryHelper.Write<string>(new RegistryHelper.RegistryKeyValue(Registry.CurrentUser, @"Software\KRtkovo.eu\Win113.Shell\Taskbar", "TaskbarX"), this.Location.X.ToString());
                RegistryHelper.Write<string>(new RegistryHelper.RegistryKeyValue(Registry.CurrentUser, @"Software\KRtkovo.eu\Win113.Shell\Taskbar", "TaskbarY"), this.Location.Y.ToString());
                RegistryHelper.Write<string>(new RegistryHelper.RegistryKeyValue(Registry.CurrentUser, @"Software\KRtkovo.eu\Win113.Shell\Desktop", "TaskbarChangeTrigger"), new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds().ToString());
            }

        }


        Rectangle TopLeft { get { return new Rectangle(0, 0, _, _); } }
        Rectangle TopRight { get { return new Rectangle(this.ClientSize.Width - _, 0, _, _); } }
        Rectangle BottomLeft { get { return new Rectangle(0, this.ClientSize.Height - _, _, _); } }
        Rectangle BottomRight { get { return new Rectangle(this.ClientSize.Width - _, this.ClientSize.Height - _, _, _); } }

        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            if (message.Msg == 0x84)
            {  // Trap WM_NCHITTEST
                Point pos = new Point(message.LParam.ToInt32());
                pos = this.PointToClient(pos);
                
                if (pos.Y < cCaption)
                {
                    message.Result = (IntPtr)2;  // HTCAPTION
                    return;
                }

                var cursor = this.PointToClient(Cursor.Position);

                if (TopLeft.Contains(cursor)) message.Result = (IntPtr)HTTOPLEFT;
                else if (TopRight.Contains(cursor)) message.Result = (IntPtr)HTTOPRIGHT;
                else if (BottomLeft.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMLEFT;
                else if (BottomRight.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMRIGHT;

                else if (Top.Contains(cursor)) message.Result = (IntPtr)HTTOP;
                else if (Left.Contains(cursor)) message.Result = (IntPtr)HTLEFT;
                else if (Right.Contains(cursor)) message.Result = (IntPtr)HTRIGHT;
                else if (Bottom.Contains(cursor)) message.Result = (IntPtr)HTBOTTOM;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle rc;
            rc = new Rectangle(0, 0, this.ClientSize.Width, cCaption);
            var titlebarColor = WindowsHelper.GetUserAccentColor();

            e.Graphics.FillRectangle(Form.ActiveForm == this && Win32ApiHelper.IsWindowEnabled(this.Handle) ? titlebarColor : Brushes.White, rc);

        }




#region AppBarFunctions

        // saves the current edge
        private AppBarEdges m_Edge = AppBarEdges.Float;

        // are we in dock mode?
        private Boolean IsAppbarMode = false;

        // save the floating size and location
        private Size m_PrevSize;
        private Point m_PrevLocation;

        // saves the callback message id
        private UInt32 CallbackMessageID = 0;

        public enum AppBarEdges
        {
            Left = 0,
            Top = 1,
            Right = 2,
            Bottom = 3,
            Float = 4
        }

        public enum AppBarMessages
        {
            /// <summary>
            /// Registers a new appbar and specifies the message identifier
            /// that the system should use to send notification messages to 
            /// the appbar. 
            /// </summary>
            New = 0x00000000,
            /// <summary>
            /// Unregisters an appbar, removing the bar from the system's 
            /// internal list.
            /// </summary>
            Remove = 0x00000001,
            /// <summary>
            /// Requests a size and screen position for an appbar.
            /// </summary>
            QueryPos = 0x00000002,
            /// <summary>
            /// Sets the size and screen position of an appbar. 
            /// </summary>
            SetPos = 0x00000003,
            /// <summary>
            /// Retrieves the autohide and always-on-top states of the 
            /// Microsoft® Windows® taskbar. 
            /// </summary>
            GetState = 0x00000004,
            /// <summary>
            /// Retrieves the bounding rectangle of the Windows taskbar. 
            /// </summary>
            GetTaskBarPos = 0x00000005,
            /// <summary>
            /// Notifies the system that an appbar has been activated. 
            /// </summary>
            Activate = 0x00000006,
            /// <summary>
            /// Retrieves the handle to the autohide appbar associated with
            /// a particular edge of the screen. 
            /// </summary>
            GetAutoHideBar = 0x00000007,
            /// <summary>
            /// Registers or unregisters an autohide appbar for an edge of 
            /// the screen. 
            /// </summary>
            SetAutoHideBar = 0x00000008,
            /// <summary>
            /// Notifies the system when an appbar's position has changed. 
            /// </summary>
            WindowPosChanged = 0x00000009,
            /// <summary>
            /// Sets the state of the appbar's autohide and always-on-top 
            /// attributes.
            /// </summary>
            SetState = 0x0000000a
        }

        private void TaskbarForm_ResizeEnd(object sender, EventArgs e)
        {
            //RegistryHelper.Write<string>(new RegistryHelper.RegistryKeyValue(Registry.CurrentUser, @"Software\KRtkovo.eu\Win113.Shell\Desktop", "TaskbarSize"), this.Height.ToString());
            RegistryHelper.Write<string>(new RegistryHelper.RegistryKeyValue(Registry.CurrentUser, @"Software\KRtkovo.eu\Win113.Shell\Taskbar", "TaskbarHeight"), this.Height.ToString());
            RegistryHelper.Write<string>(new RegistryHelper.RegistryKeyValue(Registry.CurrentUser, @"Software\KRtkovo.eu\Win113.Shell\Taskbar", "TaskbarWidth"), this.Width.ToString());
            RegistryHelper.Write<string>(new RegistryHelper.RegistryKeyValue(Registry.CurrentUser, @"Software\KRtkovo.eu\Win113.Shell\Desktop", "TaskbarChangeTrigger"), new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds().ToString());

            // Prevent appbar from taking weird spacing
            m_PrevSize = Size;
            if(this.Edge != AppBarEdges.Float)
                this.Edge = this.Edge;
        }

        private void hideDesktopTaskPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideDesktopTaskPanelToolStripMenuItem.Checked = !hideDesktopTaskPanelToolStripMenuItem.Checked;
            RegistryHelper.Write<string>(new RegistryHelper.RegistryKeyValue(Registry.CurrentUser, @"Software\KRtkovo.eu\Win113.Shell\Desktop", "HidePanelTaskWhenTaskbarActive"), hideDesktopTaskPanelToolStripMenuItem.Checked ? "1" : "0");
        }

        public AppBarEdges Edge
        {
            get
            {
                return m_Edge;
            }
            set
            {
                m_Edge = value;
                if (value == AppBarEdges.Float)
                    AppbarRemove();
                else
                    AppbarNew();

                if (IsAppbarMode)
                    SizeAppBar();

            }
        }

        private Boolean AppbarRemove()
        {
            // prepare data structure of message
            ShellApi.APPBARDATA msgData = new ShellApi.APPBARDATA();
            msgData.cbSize = (UInt32)Marshal.SizeOf(msgData);
            msgData.hWnd = Handle;

            // remove appbar
            UInt32 retVal = ShellApi.SHAppBarMessage((UInt32)AppBarMessages.Remove, ref msgData);

            IsAppbarMode = false;

            Size = m_PrevSize;
            Location = m_PrevLocation;

            return (retVal != 0) ? true : false;
        }

        private Boolean AppbarNew()
        {
            if (CallbackMessageID == 0)
                throw new Exception("CallbackMessageID is 0");

            if (IsAppbarMode)
                return true;

            m_PrevSize = Size;
            m_PrevLocation = Location;

            // prepare data structure of message
            ShellApi.APPBARDATA msgData = new ShellApi.APPBARDATA();
            msgData.cbSize = (UInt32)Marshal.SizeOf(msgData);
            msgData.hWnd = Handle;
            msgData.uCallbackMessage = CallbackMessageID;

            // install new appbar
            UInt32 retVal = ShellApi.SHAppBarMessage((UInt32)AppBarMessages.New, ref msgData);
            IsAppbarMode = (retVal != 0);

            SizeAppBar();

            return IsAppbarMode;
        }

        private void SizeAppBar()
        {
            ShellApi.RECT rt = new ShellApi.RECT();

            if ((m_Edge == AppBarEdges.Left) ||
                (m_Edge == AppBarEdges.Right))
            {
                rt.top = 0;
                rt.bottom = SystemInformation.PrimaryMonitorSize.Height;
                if (m_Edge == AppBarEdges.Left)
                {
                    rt.right = m_PrevSize.Width;
                }
                else
                {
                    rt.right = SystemInformation.PrimaryMonitorSize.Width;
                    rt.left = rt.right - m_PrevSize.Width;
                }
            }
            else
            {
                rt.left = 0;
                rt.right = SystemInformation.PrimaryMonitorSize.Width;
                if (m_Edge == AppBarEdges.Top)
                {
                    rt.bottom = m_PrevSize.Height;
                }
                else
                {
                    rt.bottom = SystemInformation.PrimaryMonitorSize.Height;
                    rt.top = rt.bottom - m_PrevSize.Height;
                }
            }

            AppbarQueryPos(ref rt);

            switch (m_Edge)
            {
                case AppBarEdges.Left:
                    rt.right = rt.left + m_PrevSize.Width;
                    break;
                case AppBarEdges.Right:
                    rt.left = rt.right - m_PrevSize.Width;
                    break;
                case AppBarEdges.Top:
                    rt.bottom = rt.top + m_PrevSize.Height;
                    break;
                case AppBarEdges.Bottom:
                    rt.top = rt.bottom - m_PrevSize.Height;
                    break;
            }

            AppbarSetPos(ref rt);

            Location = new Point(rt.left, rt.top);
            Size = new Size(rt.right - rt.left, rt.bottom - rt.top);
        }

        private void AppbarQueryPos(ref ShellApi.RECT appRect)
        {
            // prepare data structure of message
            ShellApi.APPBARDATA msgData = new ShellApi.APPBARDATA();
            msgData.cbSize = (UInt32)Marshal.SizeOf(msgData);
            msgData.hWnd = Handle;
            msgData.uEdge = (UInt32)m_Edge;
            msgData.rc = appRect;

            // query postion for the appbar
            ShellApi.SHAppBarMessage((UInt32)AppBarMessages.QueryPos, ref msgData);
            appRect = msgData.rc;
        }

        private void AppbarSetPos(ref ShellApi.RECT appRect)
        {
            // prepare data structure of message
            ShellApi.APPBARDATA msgData = new ShellApi.APPBARDATA();
            msgData.cbSize = (UInt32)Marshal.SizeOf(msgData);
            msgData.hWnd = Handle;
            msgData.uEdge = (UInt32)m_Edge;
            msgData.rc = appRect;

            // set postion for the appbar
            ShellApi.SHAppBarMessage((UInt32)AppBarMessages.SetPos, ref msgData);
            appRect = msgData.rc;
        }

        private UInt32 RegisterCallbackMessage()
        {
            String uniqueMessageString = Guid.NewGuid().ToString();
            return ShellApi.RegisterWindowMessage(uniqueMessageString);
        }
        #endregion
    }
}

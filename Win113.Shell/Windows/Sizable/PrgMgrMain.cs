using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Win113.Shell.Helpers;
using Win113.Shell.Properties;
using System.Diagnostics;
using System.Linq;

namespace Win113.Shell.Windows.Sizable
{
    public partial class PrgMgrMain : Form
    {
        private const int cGrip = 16;      // Grip size
        private const int cCaption = 24;   // Caption bar height;
        private const int borderWidth = 3;
        private Color borderColor = Color.LightGray;
        private Color captionButtonsColor = Color.FromArgb(195, 199, 203);
        Font titleFont = new Font("System", 10, FontStyle.Bold);
        private SolidBrush titlebarColor;

        private bool isDefaultShell = false;
        private bool initRun = true;

        private Form taskbarForm;

        public PrgMgrMain()
        {
            InitializeComponent();
            InitialiseFormEdge();

            isDefaultShell = Win113Helper.IsWin113DefaultShell();

            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            noSelectButton1.BackColor = captionButtonsColor;
            button1.BackColor = captionButtonsColor;
            button2.BackColor = captionButtonsColor;

            var accentColor = RegistryHelper.ReadDword(RegistryHelper.AccentColorRegPath);
            if (accentColor > 0)
            {
                titlebarColor = new SolidBrush(WindowsHelper.DWORD2RGBA(accentColor));
            }
            else
            {
                titlebarColor = new SolidBrush(Color.DarkBlue);
            }



        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            borderColor = Color.LightGray;

            Rectangle rc;
            rc = new Rectangle(0, 0, this.ClientSize.Width - 4, cCaption);

            e.Graphics.FillRectangle(Form.ActiveForm == this && Win32ApiHelper.IsWindowEnabled(this.Handle) ? titlebarColor : Brushes.White, rc);


            Size titleSize = TextRenderer.MeasureText(this.Text, titleFont);
            e.Graphics.DrawString(this.Text, titleFont, Form.ActiveForm == this && Win32ApiHelper.IsWindowEnabled(this.Handle) ? Brushes.White : Brushes.Black, ((this.ClientSize.Width / 2) - (titleSize.Width / 2)), 5);

            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, borderColor, borderWidth, ButtonBorderStyle.Solid, borderColor, borderWidth, ButtonBorderStyle.Solid, borderColor, borderWidth, ButtonBorderStyle.Solid, borderColor, borderWidth, ButtonBorderStyle.Solid);

            //ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Black, 1, ButtonBorderStyle.Solid, Color.Black, 1, ButtonBorderStyle.Solid, Color.Black, 1, ButtonBorderStyle.Solid, Color.Black, 1, ButtonBorderStyle.Solid);
            if(this.WindowState != FormWindowState.Maximized)
            {
                ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
                    SystemColors.ControlLightLight, 1, ButtonBorderStyle.Outset,
                    SystemColors.ControlLightLight, 1, ButtonBorderStyle.Outset,
                    SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
                    SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset);
            }
            

            if (Form.ActiveForm == this)
            {
                splitContainer1.SplitterWidth = 2;
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            button1.BackgroundImage = this.WindowState == FormWindowState.Maximized ? Resources.maximized : Resources.maximize;

            this.Refresh();

            Update();

            if (isDefaultShell && initRun)
            {
                this.WindowState = FormWindowState.Normal;

                initRun = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
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

        Rectangle TopLeft { get { return new Rectangle(0, 0, _, _); } }
        Rectangle TopRight { get { return new Rectangle(this.ClientSize.Width - _, 0, _, _); } }
        Rectangle BottomLeft { get { return new Rectangle(0, this.ClientSize.Height - _, _, _); } }

        private void noSelectButton1_Click(object sender, EventArgs e)
        {
            //var p = MousePosition.X + (MousePosition.Y * 0x10000);
            var p = this.Location.X + 4 + ((this.Location.Y + 25) * 0x10000);
            Win32ApiHelper.SendMessage(this.Handle, Win32ApiHelper.WM_POPUPSYSTEMMENU, (IntPtr)0, (IntPtr)p);
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (listView1.SelectedItems.Count == 1)
            {
                switch (listView1.SelectedItems[0].Text)
                {
                    case "MS-DOS Prompt":
                        if (WindowsHelper.RunApplication("cmd"))
                        {
                            Cursor.Current = Cursors.Default;
                        }
                        break;
                    case "Registry Editor":
                        if (WindowsHelper.RunApplication("regedit"))
                        {
                            Cursor.Current = Cursors.Default;
                        }
                        break;
                    case "File Manager":
                        if (WindowsHelper.RunApplication("explorer", useShell: false))
                        {
                            Cursor.Current = Cursors.Default;
                        }
                        break;
                    case "Internet Explorer":
                        if (WindowsHelper.RunApplication("msedge"))
                        {
                            Cursor.Current = Cursors.Default;
                        }
                        break;
                    case "Altap Salamander":
                        if (WindowsHelper.RunApplication("C:\\Program Files\\Altap Salamander\\salamand.exe"))
                        {
                            Cursor.Current = Cursors.Default;
                        }
                        break;
                    case "Task Manager":
                        if (WindowsHelper.RunApplication("taskmgr"))
                        {
                            Cursor.Current = Cursors.Default;
                        }
                        break;
                    case "Configure Desktop":
                        if (WindowsHelper.RunApplication("bobshell.exec.exe", "shell:::DesktopSettings", false, true))
                        {
                            Cursor.Current = Cursors.Default;
                        }
                        break;
                    case "Computer Settings":
                        if (WindowsHelper.RunApplication("C:\\Windows\\system32\\control.exe"))
                        {
                            Cursor.Current = Cursors.Default;
                        }
                        break;
                    case "Extended Taskbar":
                        if (isDefaultShell)
                        {
                            if (WindowsHelper.RunApplication("bobshell.taskbar.exe"))
                            {
                                Cursor.Current = Cursors.Default;
                            }
                        }
                        else
                        {
                            if (taskbarForm == null)
                            {
                                taskbarForm = new Shell.Windows.Special.TaskbarForm();
                            }
                            taskbarForm.Show();
                        }

                        break;
                }
            }
        }



        private IWin32Window GetWindowFromHost(int hwnd)
        {
            IWin32Window window = null;
            IntPtr handle = new IntPtr(hwnd);

            try
            {
                NativeWindow nativeWindow = new NativeWindow();
                nativeWindow.AssignHandle(handle);
                window = nativeWindow;
            }
            finally
            {
                handle = IntPtr.Zero;
            }

            return window;
        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, button1.ClientRectangle,
            SystemColors.ControlLightLight, 1, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 1, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("winver");
        }

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

        // System context menu
        private const int WS_SYSMENU = 0x80000;
        private int WS_SIZEBOX = 0x40000,
                    WS_MINIMIZEBOX = 0x00020000,
                    WS_MAXIMIZEBOX = 0x00010000,
                    WS_BORDER = 0x00800000,
                    WS_DLGFRAME = 0x00400000,
                    WS_GROUP = 0x00020000;

        private void ProgramManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(isDefaultShell)
            {
                // disable user closing the form, but no one else
                if (isDefaultShell)
                    e.Cancel = (e.CloseReason == CloseReason.UserClosing);

                exitToolStripMenuItem_Click(null, null);
            }
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowsHelper.ShowDialog("Run");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isDefaultShell)
            {
                WindowsHelper.ShowDialog("Shutdown");
            }
            else
            {
                WindowsHelper.ShowDialog("ShutdownLegacy");
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams p = base.CreateParams;
                p.Style = WS_MINIMIZEBOX | WS_MAXIMIZEBOX | WS_SYSMENU;
                return p;
            }
        }




        protected bool isDragging = false;
        protected Rectangle lastRectangle = new Rectangle();


        protected void InitialiseFormEdge()
        {
            int resizeWidth = 5;

            this.MouseDown += new MouseEventHandler(form_MouseDown);
            this.MouseMove += new MouseEventHandler(form_MouseMove);
            this.MouseUp += delegate (object sender, MouseEventArgs e)
            {
                isDragging = false;
            };

            // bottom
            UserControl uc1 = new UserControl()
            {
                Anchor = (AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right),
                Height = resizeWidth,
                Width = this.DisplayRectangle.Width - (resizeWidth * 2),
                Left = resizeWidth,
                Top = this.DisplayRectangle.Height - resizeWidth,
                BackColor = Color.Transparent,
                Cursor = Cursors.SizeNS
            };
            uc1.MouseDown += form_MouseDown;
            uc1.MouseUp += form_MouseUp;
            uc1.MouseMove += delegate (object sender, MouseEventArgs e)
            {
                if (isDragging)
                {
                    this.Size = new Size(lastRectangle.Width, e.Y - lastRectangle.Y + this.Height);
                }
            };
            uc1.BringToFront();

            this.Controls.Add(uc1);

            // right
            UserControl uc2 = new UserControl()
            {
                Anchor = (AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom),
                Height = this.DisplayRectangle.Height - (resizeWidth * 2),
                Width = resizeWidth,
                Left = this.DisplayRectangle.Width - resizeWidth,
                Top = resizeWidth,
                BackColor = Color.Transparent,
                Cursor = Cursors.SizeWE
            };
            uc2.MouseDown += form_MouseDown;
            uc2.MouseUp += form_MouseUp;
            uc2.MouseMove += delegate (object sender, MouseEventArgs e)
            {
                if (isDragging)
                {
                    this.Size = new Size(e.X - lastRectangle.X + this.Width, lastRectangle.Height);
                }
            };
            uc2.BringToFront();

            this.Controls.Add(uc2);

            // bottom-right
            UserControl uc3 = new UserControl()
            {
                Anchor = (AnchorStyles.Bottom | AnchorStyles.Right),
                Height = resizeWidth,
                Width = resizeWidth,
                Left = this.DisplayRectangle.Width - resizeWidth,
                Top = this.DisplayRectangle.Height - resizeWidth,
                BackColor = Color.Transparent,
                Cursor = Cursors.SizeNWSE
            };
            uc3.MouseDown += form_MouseDown;
            uc3.MouseUp += form_MouseUp;
            uc3.MouseMove += delegate (object sender, MouseEventArgs e)
            {
                if (isDragging)
                {
                    this.Size = new Size((e.X - lastRectangle.X + this.Width), (e.Y - lastRectangle.Y + this.Height));
                }
            };
            uc3.BringToFront();

            this.Controls.Add(uc3);

            // top-right
            UserControl uc4 = new UserControl()
            {
                Anchor = (AnchorStyles.Top | AnchorStyles.Right),
                Height = resizeWidth,
                Width = resizeWidth,
                Left = this.DisplayRectangle.Width - resizeWidth,
                Top = 0,
                BackColor = Color.Transparent,
                Cursor = Cursors.SizeNESW
            };
            uc4.MouseDown += form_MouseDown;
            uc4.MouseUp += form_MouseUp;
            uc4.MouseMove += delegate (object sender, MouseEventArgs e)
            {
                if (isDragging)
                {
                    int diff = (e.Location.Y - lastRectangle.Y);
                    int y = (this.Location.Y + diff);

                    this.Location = new Point(this.Location.X, y);
                    this.Size = new Size(e.X - lastRectangle.X + this.Width, (this.Height + (diff * -1)));
                }
            };
            uc4.BringToFront();
            //uc4.BackColor = Color.Firebrick;

            this.Controls.Add(uc4);

            // top
            UserControl uc5 = new UserControl()
            {
                Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right),
                Height = resizeWidth,
                Width = this.DisplayRectangle.Width - (resizeWidth * 2),
                Left = resizeWidth,
                Top = 0,
                BackColor = Color.Transparent,
                Cursor = Cursors.SizeNS
            };
            uc5.MouseDown += form_MouseDown;
            uc5.MouseUp += form_MouseUp;
            uc5.MouseMove += delegate (object sender, MouseEventArgs e)
            {
                if (isDragging)
                {
                    int diff = (e.Location.Y - lastRectangle.Y);
                    int y = (this.Location.Y + diff);

                    this.Location = new Point(this.Location.X, y);
                    this.Size = new Size(lastRectangle.Width, (this.Height + (diff * -1)));
                }
            };
            uc5.BringToFront();

            this.Controls.Add(uc5);

            // left
            UserControl uc6 = new UserControl()
            {
                Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom),
                Height = this.DisplayRectangle.Height - (resizeWidth * 2),
                Width = resizeWidth,
                Left = 0,
                Top = resizeWidth,
                BackColor = Color.Transparent,
                Cursor = Cursors.SizeWE
            };
            uc6.MouseDown += form_MouseDown;
            uc6.MouseUp += form_MouseUp;
            uc6.MouseMove += delegate (object sender, MouseEventArgs e)
            {
                if (isDragging)
                {
                    int diff = (e.Location.X - lastRectangle.X);
                    int x = (this.Location.X + diff);

                    this.Location = new Point(x, this.Location.Y);
                    this.Size = new Size((this.Width + (diff * -1)), this.Height);
                }
            };
            uc6.BringToFront();

            this.Controls.Add(uc6);

            // bottom-left
            UserControl uc7 = new UserControl()
            {
                Anchor = (AnchorStyles.Bottom | AnchorStyles.Left),
                Height = resizeWidth,
                Width = resizeWidth,
                Left = 0,
                Top = this.DisplayRectangle.Height - resizeWidth,
                BackColor = Color.Transparent,
                Cursor = Cursors.SizeNESW
            };
            uc7.MouseDown += form_MouseDown;
            uc7.MouseUp += form_MouseUp;
            uc7.MouseMove += delegate (object sender, MouseEventArgs e)
            {
                if (isDragging)
                {
                    int diff = (e.Location.X - lastRectangle.X);
                    int x = (this.Location.X + diff);

                    this.Location = new Point(x, this.Location.Y);
                    this.Size = new Size((this.Width + (diff * -1)), (e.Y - lastRectangle.Y + this.Height));
                }
            };
            uc7.BringToFront();

            this.Controls.Add(uc7);

            // bottom-left
            UserControl uc8 = new UserControl()
            {
                Anchor = (AnchorStyles.Top | AnchorStyles.Left),
                Height = resizeWidth,
                Width = resizeWidth,
                Left = 0,
                Top = 0,
                BackColor = Color.Transparent,
                Cursor = Cursors.SizeNWSE
            };
            uc8.MouseDown += form_MouseDown;
            uc8.MouseUp += form_MouseUp;
            uc8.MouseMove += delegate (object sender, MouseEventArgs e)
            {
                if (isDragging)
                {
                    int dX = (e.Location.X - lastRectangle.X);
                    int dY = (e.Location.Y - lastRectangle.Y);
                    int x = (this.Location.X + dX);
                    int y = (this.Location.Y + dY);

                    this.Location = new Point(x, y);
                    this.Size = new Size((this.Width + (dX * -1)), (this.Height + (dY * -1)));
                }
            };
            uc8.BringToFront();

            this.Controls.Add(uc8);
        }


        private void form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastRectangle = new Rectangle(e.Location.X, e.Location.Y, this.Width, this.Height);
            }
        }

        private void form_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                int x = (this.Location.X + (e.Location.X - lastRectangle.X));
                int y = (this.Location.Y + (e.Location.Y - lastRectangle.Y));

                this.Location = new Point(x, y);
            }
        }

        private void form_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }
    }



}


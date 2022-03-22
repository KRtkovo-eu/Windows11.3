using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Win113.Shell.Properties;
using System.Linq;
using Win113.Shell.Helpers;
using Microsoft.Win32;

namespace Win113.Shell.Windows.Dialog
{
    public partial class DesktopSettingsWindow : Form
    {
        private const int cGrip = 16;      // Grip size
        private const int cCaption = 24;   // Caption bar height;
        private const int borderWidth = 3;
        private Color borderColor, defaultBorderColor;
        private Color captionButtonsColor = Color.FromArgb(195, 199, 203);
        Size toolbarPanelSize;
        Font titleFont = new Font("System", 10, FontStyle.Bold);
        private SolidBrush titlebarColor;

        public DesktopSettingsWindow()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            noSelectButton1.BackColor = captionButtonsColor;

            var accentColor = RegistryHelper.ReadDword(RegistryHelper.AccentColorRegPath);
            if (accentColor > 0)
            {
                borderColor = WindowsHelper.DWORD2RGBA(accentColor);
            }
            else
            {
                borderColor = Color.DarkBlue;
            }
            defaultBorderColor = borderColor;
            titlebarColor = new SolidBrush(borderColor);



            // This dialog specific
            var desktopBackColor = RegistryHelper.ReadDword(new RegistryHelper.RegistryKeyValue(Registry.CurrentUser, @"Software\KRtkovo.eu\Win113.Shell\Desktop", "BackColor"));
            desktopBackColorButton.BackColor = desktopBackColor == 0 ? Color.Teal : WindowsHelper.DWORD2RGBA(desktopBackColor);
            var desktopForeColor = RegistryHelper.ReadDword(new RegistryHelper.RegistryKeyValue(Registry.CurrentUser, @"Software\KRtkovo.eu\Win113.Shell\Desktop", "ForeColor"));
            desktopForeColorButton.BackColor = desktopForeColor == 0 ? Color.White : WindowsHelper.DWORD2RGBA(desktopForeColor);
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle rc = new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
            rc = new Rectangle(0, 0, this.ClientSize.Width, cCaption);

            e.Graphics.FillRectangle(Form.ActiveForm == this ? titlebarColor : Brushes.White, rc);

            
            Size titleSize = TextRenderer.MeasureText(this.Text, titleFont);
            e.Graphics.DrawString(this.Text, titleFont, Form.ActiveForm == this ? Brushes.White : Brushes.Black, ((this.ClientSize.Width/2) - (titleSize.Width/2)), 5);

            borderColor = Form.ActiveForm == this ? defaultBorderColor : Color.LightGray;

            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, borderColor, borderWidth, ButtonBorderStyle.Solid, borderColor, borderWidth, ButtonBorderStyle.Solid, borderColor, borderWidth, ButtonBorderStyle.Solid, borderColor, borderWidth, ButtonBorderStyle.Solid);

            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Black, 1, ButtonBorderStyle.Solid, Color.Black, 1, ButtonBorderStyle.Solid, Color.Black, 1, ButtonBorderStyle.Solid, Color.Black, 1, ButtonBorderStyle.Solid);

            if (Form.ActiveForm == this)
            {
                toolbarPanelSize = new Size(ClientSize.Width - 6, 27);
            }

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Refresh();

            //Invalidate(true);
            Update();
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
            var p = this.Location.X + 4 + ( (this.Location.Y + 25) * 0x10000);
            Win32ApiHelper.SendMessage(this.Handle, Win32ApiHelper.WM_POPUPSYSTEMMENU, (IntPtr)0, (IntPtr)p);
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("winver");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Update registry values
            RegistryHelper.Write<Int32>(new RegistryHelper.RegistryKeyValue(Registry.CurrentUser, @"Software\KRtkovo.eu\Win113.Shell\Desktop", "BackColor"), (Int32)WindowsHelper.RGBA2DWORD(desktopBackColorButton.BackColor), RegistryValueKind.DWord);
            RegistryHelper.Write<Int32>(new RegistryHelper.RegistryKeyValue(Registry.CurrentUser, @"Software\KRtkovo.eu\Win113.Shell\Desktop", "ForeColor"), (Int32)WindowsHelper.RGBA2DWORD(desktopForeColorButton.BackColor), RegistryValueKind.DWord);

            this.Close();
        }

        private void noSelectButton1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, okButton.ClientRectangle,
            SystemColors.ControlLightLight, 1, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 1, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset);
        }

        private void desktopBackColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorPicker = new ColorDialog();
            colorPicker.AllowFullOpen = true;
            colorPicker.AnyColor = true;
            colorPicker.SolidColorOnly = false;
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                desktopBackColorButton.BackColor = colorPicker.Color;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void desktopForeColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorPicker = new ColorDialog();
            colorPicker.AllowFullOpen = true;
            colorPicker.AnyColor = true;
            colorPicker.SolidColorOnly = false;
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                desktopForeColorButton.BackColor = colorPicker.Color;
            }
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
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams p = base.CreateParams;
                p.Style = WS_SYSMENU;
                return p;
            }
        }

    }
}


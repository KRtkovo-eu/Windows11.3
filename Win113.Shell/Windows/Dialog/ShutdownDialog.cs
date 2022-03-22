using System;
using System.Drawing;
using System.Windows.Forms;
using Win113.Shell.Helpers;

namespace Win113.Shell.Windows.Dialog
{
    public partial class ShutdownDialog : Form
    {
        private const int cGrip = 16;      // Grip size
        private const int cCaption = 24;   // Caption bar height;
        private const int borderWidth = 3;
        private Color borderColor;
        private Color captionButtonsColor = Color.FromArgb(195, 199, 203);
        Size toolbarPanelSize;
        Font titleFont = new Font("System", 10, FontStyle.Bold);
        private SolidBrush titlebarColor;

        private OverlayWindow overlayWindow;

        public ShutdownDialog()
        {
            overlayWindow = new OverlayWindow();
            overlayWindow.Show();

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
            titlebarColor = new SolidBrush(borderColor);

            windowsBrandingPictureBox.Image = WindowsHelper.WindowsBrandingImage();

            shutdownActions.SelectedIndex = 1;

            this.BringToFront();
            this.Activate();
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle rc = new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
            rc = new Rectangle(0, 0, this.ClientSize.Width, cCaption);

            e.Graphics.FillRectangle(Form.ActiveForm == this ? titlebarColor : Brushes.White, rc);

            
            Size titleSize = TextRenderer.MeasureText(this.Text, titleFont);
            e.Graphics.DrawString(this.Text, titleFont, Form.ActiveForm == this ? Brushes.White : Brushes.Black, ((this.ClientSize.Width/2) - (titleSize.Width/2)), 5);

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
            this.Location = new Point(this.Location.X, (Screen.PrimaryScreen.Bounds.Height - this.Width) / 2 - 50);
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            switch (shutdownActions.SelectedIndex)
            {
                //Log off
                case 0:
                    WindowsHelper.RunApplication("cmd", "/c shutdown -l -t 0", false, true);
                    break;
                //Shut down
                case 1:
                    WindowsHelper.RunApplication("cmd", "/c shutdown -s -t 0", false, true);
                    break;
                //Restart
                case 2:
                    WindowsHelper.RunApplication("cmd", "/c shutdown -r -t 0", false, true);
                    break;
                //Hibernate
                case 3:
                    WindowsHelper.RunApplication("cmd", "/c shutdown -h -t 0", false, true);
                    break;
            }

            
            overlayWindow.Close();
            this.Close();
        }

        private void noSelectButton1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, button1.ClientRectangle,
            SystemColors.ControlLightLight, 1, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 1, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            overlayWindow.Close();
            this.Close();
        }

        private void shutdownActions_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(shutdownActions.SelectedIndex)
            {
                //Log off
                case 0:
                    actionDescriptionLbl.Text = "Ends your session, leaving the computer running on full power.";
                    break;
                //Shut down
                case 1:
                    actionDescriptionLbl.Text = "Ends your session and shuts down Windows so that you can safely" + Environment.NewLine + "turn off power.";
                    break;
                //Restart
                case 2:
                    actionDescriptionLbl.Text = "Ends your session, shuts down Windows, and starts Windows again.";
                    break;
                //Hibernate
                case 3:
                    actionDescriptionLbl.Text = "Saves your session to disk so that you can safely turn off power." + Environment.NewLine +
                                                "Your session is restored the next time you start Windows.";
                    break;
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
                //if (pos.Y < cCaption)
                //{
                //    message.Result = (IntPtr)2;  // HTCAPTION
                //    return;
                //}


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
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams p = base.CreateParams;
                p.Style = Win32ApiHelper.WS_SYSMENU;
                return p;
            }
        }
    }
}


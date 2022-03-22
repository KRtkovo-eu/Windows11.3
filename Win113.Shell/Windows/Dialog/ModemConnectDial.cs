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

namespace Win113.Shell.Windows.Dialog
{
    public partial class ModemConnectDial : Form
    {
        private const int cGrip = 16;      // Grip size
        private const int cCaption = 24;   // Caption bar height;
        private const int borderWidth = 3;
        private Color borderColor;
        Font titleFont = new Font("System", 10, FontStyle.Bold);
        private SolidBrush titlebarColor;

        public ModemConnectDial()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);

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
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Refresh();

            statusLable.Text = "Status: Dialing...";
            extendedStatus.AppendText("+++ATH" + Environment.NewLine);
            this.Refresh();
            System.Threading.Thread.Sleep(500);
            extendedStatus.AppendText("ATH" + Environment.NewLine);
            System.Threading.Thread.Sleep(500);
            statusPicture.BackgroundImage = Resources.dial_on_off;
            extendedStatus.AppendText("OK" + Environment.NewLine);
            this.Refresh();
            System.Threading.Thread.Sleep(1000);
            extendedStatus.AppendText("AT" + Environment.NewLine);
            this.Refresh();
            System.Threading.Thread.Sleep(500);
            extendedStatus.AppendText("OK" + Environment.NewLine);
            this.Refresh();
            System.Threading.Thread.Sleep(100);
            extendedStatus.AppendText("ATE0V1" + Environment.NewLine);
            this.Refresh();
            System.Threading.Thread.Sleep(400);
            extendedStatus.AppendText("OK" + Environment.NewLine);
            this.Refresh();
            System.Threading.Thread.Sleep(100);
            extendedStatus.AppendText("AT" + Environment.NewLine);
            this.Refresh();
            System.Threading.Thread.Sleep(400);
            extendedStatus.AppendText("OK" + Environment.NewLine);
            this.Refresh();
            System.Threading.Thread.Sleep(100);
            extendedStatus.AppendText("ATDT1" + Environment.NewLine);
            this.Refresh();
            System.Threading.Thread.Sleep(900);
            extendedStatus.AppendText("RINGING" + Environment.NewLine);
            this.Refresh();
            System.Threading.Thread.Sleep(1500);
            extendedStatus.AppendText("CONNECT 28800" + Environment.NewLine);
            statusPicture.BackgroundImage = Resources.dial_off_on;
            this.Refresh();


            
            System.Threading.Thread.Sleep(300);
            extendedStatus.AppendText(".");
            statusPicture.BackgroundImage = Resources.dial_on_off;
            this.Refresh();
            System.Threading.Thread.Sleep(500);
            extendedStatus.AppendText(".");
            statusPicture.BackgroundImage = Resources.dial_off_on;
            this.Refresh();
            System.Threading.Thread.Sleep(500);
            extendedStatus.AppendText(".");
            this.Refresh();
            System.Threading.Thread.Sleep(500);
            statusPicture.BackgroundImage = Resources.dial_on_on;
            extendedStatus.AppendText(".");
            this.Refresh();
            System.Threading.Thread.Sleep(500);
            statusPicture.BackgroundImage = Resources.dial_off_on;
            extendedStatus.AppendText(".");
            this.Refresh();
            System.Threading.Thread.Sleep(200);
            statusPicture.BackgroundImage = Resources.dial_on_off;
            this.Refresh();
            System.Threading.Thread.Sleep(300);
            extendedStatus.AppendText(".");
            this.Refresh();
            System.Threading.Thread.Sleep(200);
            statusPicture.BackgroundImage = Resources.dial_off;
            statusLable.Text = "Status: Establishing connection...";
            extendedStatus.AppendText(Environment.NewLine + "CONNECT 57600" + Environment.NewLine);
            this.Refresh();


            System.Threading.Thread.Sleep(300);
            statusPicture.BackgroundImage = Resources.dial_on_on;
            extendedStatus.AppendText(".");
            this.Refresh();
            System.Threading.Thread.Sleep(500);
            extendedStatus.AppendText(".");
            statusPicture.BackgroundImage = Resources.dial_off;
            this.Refresh();
            System.Threading.Thread.Sleep(500);
            extendedStatus.AppendText(".");
            this.Refresh();
            System.Threading.Thread.Sleep(500);
            statusPicture.BackgroundImage = Resources.dial_off_on;
            extendedStatus.AppendText(".");
            this.Refresh();
            System.Threading.Thread.Sleep(500);
            statusPicture.BackgroundImage = Resources.dial_on_on;
            extendedStatus.AppendText(".");
            this.Refresh();
            System.Threading.Thread.Sleep(200);
            statusPicture.BackgroundImage = Resources.dial_on_off;
            extendedStatus.AppendText(Environment.NewLine + "OK" + Environment.NewLine);
            this.Refresh();
            System.Threading.Thread.Sleep(500);
            statusPicture.BackgroundImage = Resources.dial_off;
            extendedStatus.AppendText("SYN" + Environment.NewLine);
            this.Refresh();

            
            System.Threading.Thread.Sleep(300);
            statusPicture.BackgroundImage = Resources.dial_on_off;
            extendedStatus.AppendText("OK" + Environment.NewLine);
            extendedStatus.AppendText("OK SYN-ACK" + Environment.NewLine);
            this.Refresh();
            System.Threading.Thread.Sleep(500);
            statusPicture.BackgroundImage = Resources.dial_off_on;
            extendedStatus.AppendText("OK OK" + Environment.NewLine);
            extendedStatus.AppendText("ACK" + Environment.NewLine);
            this.Refresh();
            System.Threading.Thread.Sleep(1000);
            statusPicture.BackgroundImage = Resources.dial_on_on;
            extendedStatus.AppendText("OK" + Environment.NewLine);
            extendedStatus.AppendText("SYN=4321" + Environment.NewLine);
            this.Refresh();
            System.Threading.Thread.Sleep(500);
            statusPicture.BackgroundImage = Resources.dial_off_on;
            extendedStatus.AppendText("OK" + Environment.NewLine);
            extendedStatus.AppendText("OK SYN=5501" + Environment.NewLine);
            extendedStatus.AppendText("OK OK" + Environment.NewLine);
            this.Refresh();
            System.Threading.Thread.Sleep(200);
            extendedStatus.AppendText("ACK=5502" + Environment.NewLine);
            statusPicture.BackgroundImage = Resources.dial_on_on;
            this.Refresh();
            System.Threading.Thread.Sleep(500);
            statusPicture.BackgroundImage = Resources.dial_on_off;
            extendedStatus.AppendText("OK" + Environment.NewLine);
            this.Refresh();

            extendedStatus.AppendText("AT" + Environment.NewLine);
            System.Threading.Thread.Sleep(300);
            statusPicture.BackgroundImage = Resources.dial_on_on;
            extendedStatus.AppendText(".");
            this.Refresh();
            System.Threading.Thread.Sleep(500);
            statusPicture.BackgroundImage = Resources.dial_off;
            extendedStatus.AppendText(".");
            this.Refresh();
            System.Threading.Thread.Sleep(500);
            extendedStatus.AppendText(".");
            this.Refresh();
            System.Threading.Thread.Sleep(500);
            statusPicture.BackgroundImage = Resources.dial_on_on;
            extendedStatus.AppendText(".");
            this.Refresh();
            System.Threading.Thread.Sleep(500);
            statusPicture.BackgroundImage = Resources.dial_off_on;
            extendedStatus.AppendText(".");
            this.Refresh();
            System.Threading.Thread.Sleep(200);
            statusPicture.BackgroundImage = Resources.dial_on_off;
            extendedStatus.AppendText(Environment.NewLine + "OK" + Environment.NewLine);
            this.Refresh();
            System.Threading.Thread.Sleep(500);
            statusPicture.BackgroundImage = Resources.dial_off;
            statusLable.Text = "Status: Verifying username and password...";
            extendedStatus.AppendText("AT USER PASS" + Environment.NewLine);
            this.Refresh();

            
            System.Threading.Thread.Sleep(300);
            statusPicture.BackgroundImage = Resources.dial_on_off;
            extendedStatus.AppendText(".");
            this.Refresh();
            System.Threading.Thread.Sleep(500);
            statusPicture.BackgroundImage = Resources.dial_off_on;
            extendedStatus.AppendText(".");
            this.Refresh();
            System.Threading.Thread.Sleep(500);
            extendedStatus.AppendText(".");
            this.Refresh();
            System.Threading.Thread.Sleep(500);
            statusPicture.BackgroundImage = Resources.dial_on_on;
            extendedStatus.AppendText(".");
            this.Refresh();
            System.Threading.Thread.Sleep(500);
            statusPicture.BackgroundImage = Resources.dial_off_on;
            extendedStatus.AppendText(".");
            this.Refresh();
            System.Threading.Thread.Sleep(200);
            statusPicture.BackgroundImage = Resources.dial_on_off;
            extendedStatus.AppendText(Environment.NewLine + "OK" + Environment.NewLine);
            this.Refresh();
            System.Threading.Thread.Sleep(500);
            statusPicture.BackgroundImage = Resources.dial_off;
            statusLable.Text = "Status: Logging to the network...";
            extendedStatus.AppendText("DUPLEX 1" + Environment.NewLine);
            this.Refresh();

            
            System.Threading.Thread.Sleep(300);
            statusPicture.BackgroundImage = Resources.dial_on_on;
            extendedStatus.AppendText("." + Environment.NewLine);
            this.Refresh();
            System.Threading.Thread.Sleep(500);
            statusPicture.BackgroundImage = Resources.dial_off;
            extendedStatus.AppendText("OK" + Environment.NewLine);
            this.Refresh();
            System.Threading.Thread.Sleep(1000);
            statusPicture.BackgroundImage = Resources.dial_off_on;
            extendedStatus.AppendText("AT" + Environment.NewLine);
            this.Refresh();
            System.Threading.Thread.Sleep(500);
            statusPicture.BackgroundImage = Resources.dial_on_on;
            extendedStatus.AppendText("OK" + Environment.NewLine);
            this.Refresh();
            System.Threading.Thread.Sleep(200);
            statusPicture.BackgroundImage = Resources.dial_on_off;
            extendedStatus.AppendText("CONNECT" + Environment.NewLine);
            this.Refresh();
            System.Threading.Thread.Sleep(500);
            statusPicture.BackgroundImage = Resources.dial_off;
            extendedStatus.AppendText("OK" + Environment.NewLine);
            this.Refresh();


            System.Threading.Thread.Sleep(500);
            extendedStatus.AppendText("ACCEPT" + Environment.NewLine);
            statusLable.Text = "Status: Connection established!";
            statusPicture.BackgroundImage = Resources.dial_on_on;
            this.Refresh();
            System.Threading.Thread.Sleep(2500);

            extendedStatus.AppendText("DONE" + Environment.NewLine);
            this.Refresh();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

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

        private void ModemConnectDial_Resize(object sender, EventArgs e)
        {
            this.Refresh();
            Update();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

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
            }
            

        }

        // System context menu
        private const int WS_SYSMENU = 0x80000;
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


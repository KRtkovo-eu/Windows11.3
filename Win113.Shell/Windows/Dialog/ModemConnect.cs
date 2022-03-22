using Microsoft.Win32;
using System;
using System.Drawing;
using System.Windows.Forms;
using Win113.Shell.Helpers;

namespace Win113.Shell.Windows.Dialog
{
    public partial class ModemConnect : Form
    {
        private const int cGrip = 16;      // Grip size
        private const int cCaption = 24;   // Caption bar height;
        private const int borderWidth = 3;
        private Color borderColor;
        private Color captionButtonsColor = Color.FromArgb(195, 199, 203);
        Font titleFont = new Font("System", 10, FontStyle.Bold);
        private SolidBrush titlebarColor;


        public ModemConnect()
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

            //Invalidate(true);
            Update();
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            savePasswordCheckBox.Checked = false;
        }

        private bool isDtmfPlayed = false;
        private void phoneNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            string keyPressed = e.KeyChar.ToString();

            // Check for a naughty character in the KeyDown event.
            if (System.Text.RegularExpressions.Regex.IsMatch(keyPressed, @"[^0-9^+^A^B^C^D^\*^\#^\(^\)^\-^\b]"))
            {
                // Stop the character from being entered into the control since it is illegal.
                e.Handled = true;
            }
            else
            {
                isDtmfPlayed = Helpers.Audio.AudioHelper.PlayDTMF(keyPressed);
            }
        }

        private void phoneNumberTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if(isDtmfPlayed)
            {
                Helpers.Audio.AudioHelper.StopDTMF();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(WindowsHelper.IsNetworkAvailable())
            {
                RegistryHelper.Write<string>(new RegistryHelper.RegistryKeyValue(Registry.CurrentUser, @"Software\KRtkovo.eu\Win113.Shell\Desktop", "Network"), "disconnected");

                string phoneNumber = phoneNumberTextBox.Text;
                phoneNumber = phoneNumber.Replace("(", "");
                phoneNumber = phoneNumber.Replace(")", "");
                phoneNumber = phoneNumber.Replace("-", "");
                phoneNumber = phoneNumber.Replace(" ", "");
                phoneNumber = phoneNumber.Replace("+", "");

                this.Hide();
                ModemConnectDial modemConnectDial = new ModemConnectDial();
                var correctUsername = false;
                var correctPhoneNumber = false;

                switch (phoneNumber)
                {
                    //"+1 (570)-234-0003"
                    case "15702340003":
                        if (usernameTextBox.Text == "ab3c-illinois@atson.net")
                        {
                            WindowsHelper.PlaySound(Properties.Resources.modemDial_15702340003);
                            correctUsername = true;
                            correctPhoneNumber = true;
                        }

                        break;
                    //"+1 (570)-224-4262"
                    case "15702244262":
                        if (usernameTextBox.Text == "FG44SA-NY3")
                        {
                            WindowsHelper.PlaySound(Properties.Resources.modemDial_15702244262);
                            correctUsername = true;
                            correctPhoneNumber = true;
                        }

                        break;
                    default:
                        WindowsHelper.PlaySound(Properties.Resources.phoneNumberNotExist);
                        correctUsername = true;
                        correctPhoneNumber = false;
                        break;
                }

                if (correctPhoneNumber)
                {
                    if (correctUsername)
                    {
                        if (modemConnectDial.ShowDialog() == DialogResult.OK)
                        {
                            RegistryHelper.Write<string>(new RegistryHelper.RegistryKeyValue(Registry.CurrentUser, @"Software\KRtkovo.eu\Win113.Shell\Desktop", "Network"), "connected");

                            if (new ModemConnected().ShowDialog() == DialogResult.OK)
                            {
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong username or password!", "Connection failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Wrong phone number!", "Connection failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (MessageBox.Show("Network connection is not available at the moment.") == DialogResult.OK) ;
            }
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


using System;
using System.Drawing;
using System.Windows.Forms;

namespace Win113.Shell.Windows.Dialog
{
    public partial class OverlayWindow : Form
    {
        protected override bool ShowWithoutActivation => true;

        public OverlayWindow()
        {
            InitializeComponent();

            this.Opacity = 0.75;
            this.BackColor = Color.Magenta;
            this.TransparencyKey = Color.Magenta;

            this.MaximizedBounds = Screen.PrimaryScreen.Bounds;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.DesktopBounds = Screen.PrimaryScreen.Bounds;
            this.WindowState = FormWindowState.Maximized;
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;
        }

        private const int WM_MOUSEACTIVATE = 0x0021, MA_NOACTIVATE = 0x0003;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_MOUSEACTIVATE)
            {
                m.Result = (IntPtr)MA_NOACTIVATE;
                return;
            }
            base.WndProc(ref m);
        }

        private const int WS_EX_NOACTIVATE = 0x08000000;
        private const int WS_DISABLED = 0x08000000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams p = base.CreateParams;
                p.Style = WS_DISABLED;
                //p.ExStyle |= WS_EX_NOACTIVATE;
                return p;
            }
        }
    }
}

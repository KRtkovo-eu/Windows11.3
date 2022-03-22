using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Win113.Shell.Windows.Sizable
{
    public partial class AnalogClockForm : Form
    {
		public AnalogClockForm()
		{
			InitializeComponent();
		}

		protected override void OnHelpButtonClicked(CancelEventArgs e)
		{
			e.Cancel = true;
			base.OnHelpButtonClicked(e);
			this.WindowState = FormWindowState.Minimized;
		}

		protected override void WndProc(ref Message m)
		{
			if (m.Msg == 0x216 || m.Msg == 0x214)
			{ // WM_MOVING || WM_SIZING
			  // Keep the window square
				RECT rc = (RECT)Marshal.PtrToStructure(m.LParam, typeof(RECT));
				int w = rc.Right - rc.Left;
				int h = rc.Bottom - rc.Top;
				int z = w > h ? w : h;
				rc.Bottom = rc.Top + z;
				rc.Right = rc.Left + z - 20;
				Marshal.StructureToPtr(rc, m.LParam, false);
				m.Result = (IntPtr)1;
				return;
			}
			base.WndProc(ref m);
		}
		[StructLayout(LayoutKind.Sequential)]
		public struct RECT
		{
			public int Left;
			public int Top;
			public int Right;
			public int Bottom;
		}

    }
}

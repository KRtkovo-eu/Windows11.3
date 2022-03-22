using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Windows.Interop;
using System.Windows;

namespace Win113.Shell.Helpers
{
    public static class Win32ApiHelper
    {
        public const int WS_SYSMENU = 0x80000;
        public const int WS_SIZEBOX = 0x40000,
                    WS_MINIMIZEBOX = 0x00020000,
                    WS_MAXIMIZEBOX = 0x00010000,
                    WS_BORDER = 0x00800000,
                    WS_DLGFRAME = 0x00400000,
                    WS_GROUP = 0x00020000,
                    WS_TILED = 0x00000000,
                    WS_CAPTION = 0x00800000,
                    WS_THICKFRAME = 0x00040000;
        public const short SWP_NOMOVE = 0X2;
        public const short SWP_NOSIZE = 1;
        public const short SWP_NOZORDER = 0X4;
        public const int SWP_SHOWWINDOW = 0x0040;

        [DllImport("kernel32.dll", EntryPoint = "LoadLibraryA")]
        public static extern IntPtr LoadLibrary(string sLibName);
        [DllImport("kernel32.dll", EntryPoint = "FreeLibrary")]
        public static extern int FreeLibrary(IntPtr hLib);

        [DllImport("User32.dll")]
        public static extern IntPtr LoadBitmap(IntPtr hInstance, int uID);

        [DllImport("User32.dll")]
        public static extern IntPtr LoadImage(IntPtr hInstance, int uID);

        public static Bitmap BitmapFromDll(string dllPath, int uID)
        {

            IntPtr hDll = LoadLibrary(dllPath);
            if (hDll == IntPtr.Zero)
            {
                System.Windows.MessageBox.Show("Can't load library!");
                return null;
            }

            IntPtr hRes;
            
            try
            {
                hRes = LoadBitmap(hDll, uID);
            }
            catch
            {
                hRes = LoadImage(hDll, uID);
            }
            
            Bitmap bmp = Bitmap.FromHbitmap(hRes);

            FreeLibrary(hDll);

            return bmp;
        }

        public static Bitmap ImageFromDll(string dllPath, int uID)
        {
            var asm = System.Reflection.Assembly.LoadFile(dllPath);

            string[] manifest = asm.GetManifestResourceNames();

            using (UnmanagedMemoryStream stream = (UnmanagedMemoryStream)asm.GetManifestResourceStream(manifest[uID]))//The Index of the Image you want to use
            {
                using (MemoryStream ms1 = new MemoryStream())
                {
                    stream.CopyTo(ms1);
                    System.Windows.Media.Imaging.BitmapImage bmi = new System.Windows.Media.Imaging.BitmapImage();
                    bmi.BeginInit();
                    bmi.StreamSource = new MemoryStream(ms1.ToArray());
                    bmi.EndInit();
                    return BitmapImage2Bitmap(bmi); //The name of your Image Control
                }

            }
        }

        private static Bitmap BitmapImage2Bitmap(BitmapImage bitmapImage)
        {
            // BitmapImage bitmapImage = new BitmapImage(new Uri("../Images/test.png", UriKind.Relative));

            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                enc.Save(outStream);
                System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(outStream);

                return new Bitmap(bitmap);
            }
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        private static BitmapImage Bitmap2BitmapImage(Bitmap bitmap)
        {
            IntPtr hBitmap = bitmap.GetHbitmap();
            BitmapImage retval;

            try
            {
                retval = (BitmapImage)Imaging.CreateBitmapSourceFromHBitmap(
                             hBitmap,
                             IntPtr.Zero,
                             Int32Rect.Empty,
                             BitmapSizeOptions.FromEmptyOptions());
            }
            finally
            {
                DeleteObject(hBitmap);
            }

            return retval;
        }


        [DllImport("User32.dll")]
        public static extern bool SetForegroundWindow(IntPtr handle);

        [DllImport("User32.dll")]
        public static extern bool IsIconic(IntPtr handle);

        [DllImport("User32.dll")]
        public static extern bool ShowWindow(IntPtr handle, int nCmdShow);
        public const int SW_RESTORE = 9;

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);

        [DllImport("shell32.dll")]
        public static extern IntPtr ExtractAssociatedIcon(IntPtr hInst,
        StringBuilder lpIconPath, out ushort lpiIcon);

        public static Icon GetIconOldSchool(string fileName)
        {
            ushort uicon;
            StringBuilder strB = new StringBuilder(fileName);
            IntPtr handle = ExtractAssociatedIcon(IntPtr.Zero, strB, out uicon);
            Icon ico = Icon.FromHandle(handle);

            return ico;
        }

        public static Icon GetIcon(string fileName)
        {
            try
            {
                Icon icon = Icon.ExtractAssociatedIcon(fileName);
                return icon;
            }
            catch
            {
                try
                {
                    Icon icon2 = GetIconOldSchool(fileName);
                    return icon2;
                }
                catch
                {
                    return null;
                }
            }
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        public const int WM_POPUPSYSTEMMENU = 0x313;

        [DllImport("user32.dll")]
        public static extern bool IsWindowEnabled(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);

    }

}

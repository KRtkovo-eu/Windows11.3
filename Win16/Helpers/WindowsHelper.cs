using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

namespace Win16.Helpers
{
    public static class WindowsHelper
    {

        public static Color DWORD2RGBA(uint dwColor)
        {
            var R = dwColor % 256; dwColor /= 256;
            var G = dwColor % 256; dwColor /= 256;
            var B = dwColor % 256; dwColor /= 256;
            var A = dwColor % 256; /* dwColor /= 256; */

            return Color.FromArgb((int)A, (int)R, (int)G, (int)B);
        }

        public static bool RunApplication(string application, string arguments = "", bool useShell = true, bool withoutWindow = false)
        {
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo(application);
            process.StartInfo.Arguments = arguments;
            process.StartInfo.UseShellExecute = useShell;

            if (withoutWindow)
            {
                process.StartInfo.RedirectStandardOutput = withoutWindow;
                process.StartInfo.CreateNoWindow = withoutWindow;
            }

            return process.Start();
        }

        public static void PlaySound(System.IO.Stream str)
        {
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
            snd.Play();
        }
    }
}

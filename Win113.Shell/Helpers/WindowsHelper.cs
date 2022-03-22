using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Net.NetworkInformation;
using System.Management;

namespace Win113.Shell.Helpers
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
        public static uint RGBA2DWORD(Color color)
        {
            uint dwColor = (uint)(color.A * 256 * 256 * 256);
            dwColor += (uint)(color.B * 256 * 256);
            dwColor += (uint)(color.G * 256);
            dwColor += (uint)(color.R);

            return dwColor;
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

            if (Win113Helper.IsWin113DefaultShell())
            {
                return process.Start();
            }
            else
            {
                var result = process.Start();
                Process desktopProcess = Win113Helper.GetDesktopProcess();
                int checkingProcess = 0;
                int checkingWindow = 0;

                if (desktopProcess != null)
                {
                    Process appProcess;

                    do
                    {
                        appProcess = Process.GetProcesses().FirstOrDefault(x => application.Contains(x.ProcessName));

                        // Wait some time between checking of window open
                        while ((appProcess.MainWindowHandle.Equals(IntPtr.Zero) || appProcess.MainWindowHandle == null) && checkingWindow < 10)
                        {
                            System.Threading.Thread.Sleep(10);
                            checkingWindow++;
                        }
                        checkingProcess++;
                    }
                    while (appProcess == null && checkingProcess < 10);

                    if(appProcess == null)
                    {
                        return false;
                    }

                    // Wait some time before setting parent window
                    System.Threading.Thread.Sleep(500);
                    Win32ApiHelper.SetParent(appProcess.MainWindowHandle, desktopProcess.MainWindowHandle);

                    // Add app process to child process tracker to kill all processes running in main window when main window closed
                    ChildProcessTracker.AddProcess(appProcess);
                    return true;
                }

                return result;
            }

        }

        public static void PlaySound(System.IO.Stream str)
        {
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
            snd.Play();
        }

        public static void ShowDialog(string dialogName)
        {
            switch (dialogName)
            {
                case "Run":
                    RunApplication("bobshell.exec.exe", "shell:::RunDialog", false, true);
                    break;
                case "Shutdown":
                    RunApplication("bobshell.exec.exe", "shell:::ShutdownDialog", false, true);
                    break;
                case "ShutdownLegacy":
                    dynamic activexShell = Activator.CreateInstance(Type.GetTypeFromProgID("Shell.Application"));
                    activexShell.ShutdownWindows();
                    break;
            }
        }

        public static SolidBrush GetUserAccentColor()
        {
            var accentColor = RegistryHelper.ReadDword(RegistryHelper.AccentColorRegPath);
            if (accentColor > 0)
            {
                return new SolidBrush(DWORD2RGBA(accentColor));
            }
            else
            {
                return new SolidBrush(Color.DarkBlue);
            }
        }

        public struct WebBrowserInfo
        {
            public WebBrowserInfo(string productName, string registryKeyName, Image icon, Image iconSmall)
            {
                ProductName = productName;
                RegistryKeyName = registryKeyName;
                Icon = icon;
                IconSmall = iconSmall;
            }

            public string ProductName { get; }
            public string RegistryKeyName { get; }
            public Image IconSmall { get; }
            public Image Icon { get; }
        }

        public struct WebBrowser
        {
            public WebBrowser(WebBrowserInfo browserInfo, string progID, string hive, string progName, bool isDefault, string path)
            {
                BrowserInfo = browserInfo;
                ProgID = progID;
                Hive = hive;
                ProgName = progName;
                IsDefault = isDefault;
                Path = path;
            }

            public WebBrowserInfo BrowserInfo { get; }
            public string ProgID { get; set; }
            public string Hive { get; set; }
            public string ProgName { get; set; }
            public bool IsDefault { get; set; }
            public string Path { get; }
        }

        // List of known web browsers, their names and progIDs
        public static List<WebBrowserInfo> KnownWebBrowsersInfo = new List<WebBrowserInfo>()
        {
            new WebBrowserInfo("Microsoft Edge", "Microsoft Edge", Properties.Resources.edge_48, Properties.Resources.edge_21),
            new WebBrowserInfo("Chromium", "Chromium", Properties.Resources.chromium_48, Properties.Resources.chromium_21),
            new WebBrowserInfo("Google Chrome", "Google Chrome", Properties.Resources.chrome_48, Properties.Resources.chrome_21),
            new WebBrowserInfo("Vivaldi", "Vivaldi", Properties.Resources.vivaldi_48, Properties.Resources.vivaldi_21),
            new WebBrowserInfo("Opera", "OperaStable", Properties.Resources.opera_48, Properties.Resources.opera_21),
            new WebBrowserInfo("Brave", "Brave", Properties.Resources.brave_48, Properties.Resources.brave_21),
            new WebBrowserInfo("Firefox", "Firefox", Properties.Resources.firefox_48, Properties.Resources.firefox_21),
            new WebBrowserInfo("Waterfox", "Waterfox", Properties.Resources.waterfox_48, Properties.Resources.waterfox_21),
        };

        public static bool IsDefaultWebBrowser(string progID)
        {
            var currentProgID = Registry.CurrentUser.OpenSubKey($@"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http\UserChoice").GetValue("ProgID");

            return progID.Equals(currentProgID);
        }


        public static List<WebBrowser> GetInstalledWebBrowser()
        {
            RegistryKey hkcu = Registry.CurrentUser.OpenSubKey(@"Software\Clients\StartMenuInternet");
            RegistryKey hklm = Registry.LocalMachine.OpenSubKey(@"Software\Clients\StartMenuInternet");

            List<WebBrowser> hkcuWebBrowsers = new List<WebBrowser>();
            List<WebBrowser> hklmWebBrowsers = new List<WebBrowser>();

            if (hkcu != null)
            {
                foreach (var subkey in hkcu.GetSubKeyNames())
                {
                    RegistryKey browserInfo = hkcu.OpenSubKey($@"{subkey}\Capabilities\FileAssociations");
                    if (browserInfo != null)
                    {
                        var browserPath = RegistryHelper.Read<string>(new RegistryHelper.RegistryKeyValue(Registry.CurrentUser, $@"Software\Clients\StartMenuInternet\{subkey}\shell\open\command", ""));
                        browserPath = browserPath.Replace("\"", "");

                        WebBrowserInfo subkeyBrowserInfo = KnownWebBrowsersInfo.First(x => subkey.StartsWith(x.RegistryKeyName));
                        string subkeyBrowserProgID = browserInfo.GetValue(".html").ToString();
                        hkcuWebBrowsers.Add(new WebBrowser(subkeyBrowserInfo, subkeyBrowserProgID, "hkcu", subkey, IsDefaultWebBrowser(subkeyBrowserProgID), browserPath));
                    }

                }
            }
            if (hklm != null)
            {
                foreach (var subkey in hklm.GetSubKeyNames())
                {
                    RegistryKey browserInfo = hklm.OpenSubKey($@"{subkey}\Capabilities\FileAssociations");
                    if (browserInfo != null)
                    {
                        var browserPath = RegistryHelper.Read<string>(new RegistryHelper.RegistryKeyValue(Registry.LocalMachine, $@"Software\Clients\StartMenuInternet\{subkey}\shell\open\command", ""));
                        browserPath = browserPath.Replace("\"", "");

                        WebBrowserInfo subkeyBrowserInfo = KnownWebBrowsersInfo.First(x => subkey.StartsWith(x.RegistryKeyName));
                        string subkeyBrowserProgID = browserInfo.GetValue(".html").ToString();
                        hklmWebBrowsers.Add(new WebBrowser(subkeyBrowserInfo, subkeyBrowserProgID, "hklm", subkey, IsDefaultWebBrowser(subkeyBrowserProgID), browserPath));
                    }
                }
            }

            List<WebBrowser> webBrowsersAvailable = hkcuWebBrowsers.Union(hklmWebBrowsers).ToList();

            return webBrowsersAvailable;
        }

        public static WebBrowser GetDefaultWebBrowser()
        {
            return GetInstalledWebBrowser().Find(x => x.IsDefault);
        }

        /// <summary>
        /// Indicates whether any network connection is available
        /// Filter connections below a specified speed, as well as virtual network cards.
        /// </summary>
        /// <returns>
        ///     <c>true</c> if a network connection is available; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNetworkAvailable()
        {
            return IsNetworkAvailable(0);
        }

        /// <summary>
        /// Indicates whether any network connection is available.
        /// Filter connections below a specified speed, as well as virtual network cards.
        /// </summary>
        /// <param name="minimumSpeed">The minimum speed required. Passing 0 will not filter connection using speed.</param>
        /// <returns>
        ///     <c>true</c> if a network connection is available; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNetworkAvailable(long minimumSpeed)
        {
            if (!NetworkInterface.GetIsNetworkAvailable())
                return false;

            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                // discard because of standard reasons
                if ((ni.OperationalStatus != OperationalStatus.Up) ||
                    (ni.NetworkInterfaceType == NetworkInterfaceType.Loopback) ||
                    (ni.NetworkInterfaceType == NetworkInterfaceType.Tunnel))
                    continue;

                // this allow to filter modems, serial, etc.
                // I use 10000000 as a minimum speed for most cases
                if (ni.Speed < minimumSpeed)
                    continue;

                // discard virtual cards (virtual box, virtual pc, etc.)
                if ((ni.Description.IndexOf("virtual", StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (ni.Name.IndexOf("virtual", StringComparison.OrdinalIgnoreCase) >= 0))
                    continue;

                // discard "Microsoft Loopback Adapter", it will not show as NetworkInterfaceType.Loopback but as Ethernet Card.
                if (ni.Description.Equals("Microsoft Loopback Adapter", StringComparison.OrdinalIgnoreCase))
                    continue;

                return true;
            }
            return false;
        }

        public static Bitmap WindowsBrandingImage()
        {
            return WindowsIsNot10but11(WindowsVersion()) ? Properties.Resources.windows11brand : Win32ApiHelper.BitmapFromDll(@"C:\Windows\Branding\Basebrd\basebrd.dll", 123);
        }

        public static string WindowsVersion()
        {
            // Check program is running on Win11 
            // or Win10, Server 2016, 2019, 2022 in legacy mode
            string windowsVersion = "";
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem"))
            {
                ManagementObjectCollection information = searcher.Get();
                if (information != null)
                {
                    foreach (ManagementObject obj in information)
                    {
                        windowsVersion = obj["Caption"].ToString() + " - " + obj["OSArchitecture"].ToString();
                    }
                }
                windowsVersion = windowsVersion.Replace("NT 5.1.2600", "XP");
                windowsVersion = windowsVersion.Replace("NT 5.2.3790", "Server 2003");

                return windowsVersion;

            }
        }

        public static bool WindowsIsNot10but11(string windowsVersion) { 

            if (windowsVersion.StartsWith("Microsoft Windows 11"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}

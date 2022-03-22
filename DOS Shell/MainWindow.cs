using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using DOS.Shell.Helpers;

namespace DOS.Shell
{
    class MainWindow
    {
        private static WindowPage SelectedPage = WindowPage.MainPage;
        private static ConsoleKeyInfo pressedKey;

        public static void Main(string[] args)
        {
            // Prepare console to run the application
            ShellConsole.Init(
                header: "Space Terminal for Workstations Installer"
            );
            
            // Run the application main loop for drawing window
            while (true)
            {
                switch(SelectedPage)
                {
                    case WindowPage.About:
                        ShellConsole.MainKeyBindings(new string[] { "F1 - Help", "F9 - Return back", "F10 - Exit" });

                        ShellConsole.FillPartOfWindow(ConsoleColor.Blue, 2, 1);
                        ShellConsole.WriteLine(ShellConsole.Title, ShellConsole.ShellLinePad.Center, bgColor: ConsoleColor.Blue, foreColor: ConsoleColor.White);
                        ShellConsole.WriteLine("(C) 2022, KRtkovo.eu", ShellConsole.ShellLinePad.Center, bgColor: ConsoleColor.Blue, foreColor: ConsoleColor.White);
                        ShellConsole.WriteLine("", ShellConsole.ShellLinePad.Center, bgColor: ConsoleColor.Blue, foreColor: ConsoleColor.White);
                        ShellConsole.WriteLine("", ShellConsole.ShellLinePad.Center, bgColor: ConsoleColor.Blue, foreColor: ConsoleColor.White);
                        ShellConsole.WriteLine("  This tool is used to convert the existing Ubuntu installation on your Space Malina PC", ShellConsole.ShellLinePad.Right, bgColor: ConsoleColor.Blue, foreColor: ConsoleColor.White);
                        ShellConsole.WriteLine("  to the Space Terminal for Workstations with all advantages and features.", ShellConsole.ShellLinePad.Right, bgColor: ConsoleColor.Blue, foreColor: ConsoleColor.White);
                        ShellConsole.FillRestOfWindow(ConsoleColor.Blue);

                        // Get user interaction
                        pressedKey = Console.ReadKey(true);
                        switch (pressedKey.Key)
                        {
                            // F10 = Exit
                            case ConsoleKey.F10:
                                SelectedPage = WindowPage.ExitConfirm;
                                //return;
                                break;
                            case ConsoleKey.F9:
                                SelectedPage = (SelectedPage == WindowPage.About) ? WindowPage.MainPage : WindowPage.About;
                                break;
                            default:
                                SystemSounds.Beep.Play();
                                break;
                        }

                        break;
                    case WindowPage.ExitConfirm:
                        ShellConsole.MainKeyBindings(new string[] { "Y - Exit application", "N - Return to application" });

                        ShellConsole.FillPartOfWindow(ConsoleColor.Red, 3, 1);
                        ShellConsole.WriteLine("╔═════════════════════════════════════════════════════════════╗", ShellConsole.ShellLinePad.Center, bgColor: ConsoleColor.Red);
                        ShellConsole.WriteLine("║  Do you really want to stop the process of the conversion?  ║", ShellConsole.ShellLinePad.Center, bgColor: ConsoleColor.Red, foreColor: ConsoleColor.White);
                        ShellConsole.WriteLine("║                                                             ║", ShellConsole.ShellLinePad.Center, bgColor: ConsoleColor.Red, foreColor: ConsoleColor.White);
                        ShellConsole.WriteLine("║     You won't be able to use all advantages and features    ║", ShellConsole.ShellLinePad.Center, bgColor: ConsoleColor.Red, foreColor: ConsoleColor.White);
                        ShellConsole.WriteLine("║                 of your new Space Malina PC!                ║", ShellConsole.ShellLinePad.Center, bgColor: ConsoleColor.Red, foreColor: ConsoleColor.White);
                        ShellConsole.WriteLine("║─────────────────────────────────────────────────────────────║", ShellConsole.ShellLinePad.Center, bgColor: ConsoleColor.Red, foreColor: ConsoleColor.White);
                        ShellConsole.WriteLine("║                    Press key to confirm:                    ║", ShellConsole.ShellLinePad.Center, bgColor: ConsoleColor.Red, foreColor: ConsoleColor.White);
                        ShellConsole.WriteLine("║                       Y - yes, N - no                       ║", ShellConsole.ShellLinePad.Center, bgColor: ConsoleColor.Red, foreColor: ConsoleColor.White);
                        ShellConsole.WriteLine("╚═════════════════════════════════════════════════════════════╝", ShellConsole.ShellLinePad.Center, bgColor: ConsoleColor.Red);
                        ShellConsole.FillRestOfWindow(ConsoleColor.Red);

                        pressedKey = Console.ReadKey(true);
                        switch (pressedKey.Key)
                        {
                            // F10 = Exit
                            case ConsoleKey.Y:
                                return;
                            case ConsoleKey.N:
                                SelectedPage = WindowPage.MainPage;
                                break;
                            default:
                                SystemSounds.Beep.Play();
                                break;
                        }

                        break;
                    default:
                        ShellConsole.MainKeyBindings(new string[] { "F1 - Help", "F9 - About", "F10 - Exit" });

                        ShellConsole.FillPartOfWindow(ConsoleColor.Blue, 1, 1);
                        ShellConsole.WriteLine("  Welcome to the " + ShellConsole.Title, ShellConsole.ShellLinePad.Right, ConsoleColor.White, ConsoleColor.Blue);
                        ShellConsole.WriteLine("", ShellConsole.ShellLinePad.Right, ConsoleColor.White, ConsoleColor.Blue);
                        ShellConsole.WriteLine("  ──────────────────────────────────────────────────────────────────────────────────────", ShellConsole.ShellLinePad.Right, ConsoleColor.White, ConsoleColor.Blue);
                        ShellConsole.WriteLine("", ShellConsole.ShellLinePad.Right, ConsoleColor.White, ConsoleColor.Blue);
                        ShellConsole.WriteLine("    * Press ENTER to start conversion of your Ubuntu installation to the Space Terminal for Workstations.", ShellConsole.ShellLinePad.Right, ConsoleColor.White, ConsoleColor.Blue);
                        ShellConsole.WriteLine("", ShellConsole.ShellLinePad.Right, ConsoleColor.White, ConsoleColor.Blue);
                        ShellConsole.WriteLine("    * Press F1 for help.", ShellConsole.ShellLinePad.Right, ConsoleColor.White, ConsoleColor.Blue);
                        ShellConsole.WriteLine("", ShellConsole.ShellLinePad.Right, ConsoleColor.White, ConsoleColor.Blue);
                        ShellConsole.WriteLine("    * Press F9 to see information about the application.", ShellConsole.ShellLinePad.Right, ConsoleColor.White, ConsoleColor.Blue);
                        ShellConsole.WriteLine("", ShellConsole.ShellLinePad.Right, ConsoleColor.White, ConsoleColor.Blue);
                        ShellConsole.WriteLine("    * Press F10 to exit.", ShellConsole.ShellLinePad.Right, ConsoleColor.White, ConsoleColor.Blue);
                        ShellConsole.FillRestOfWindow(ConsoleColor.Blue);

                        // Get user interaction
                        pressedKey = Console.ReadKey(true);
                        switch (pressedKey.Key)
                        {
                            // F10 = Exit
                            case ConsoleKey.F10:
                                SelectedPage = WindowPage.ExitConfirm;
                                //return;
                                break;
                            case ConsoleKey.F9:
                                SelectedPage = (SelectedPage == WindowPage.About) ? WindowPage.MainPage : WindowPage.About;
                                break;
                            default:
                                SystemSounds.Beep.Play();
                                break;
                        }

                        break;
                }
            }
            
        }

        private enum WindowPage
        {
            MainPage,
            About,
            ExitConfirm,
        }
    }
}
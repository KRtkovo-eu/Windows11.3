using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS.Shell.Helpers
{
    static class ShellConsole
    {
        private static int lastRowCursorPos;
        private static ConsoleColor headerBgColor = ConsoleColor.Magenta;
        private static ConsoleColor headerForeColor = ConsoleColor.White;
        private static ConsoleColor menuBgColor = ConsoleColor.Cyan;
        private static ConsoleColor menuForeColor = ConsoleColor.Black;

        public static void Init(string header)
        {
            Console.CursorVisible = false;
            lastRowCursorPos = Console.WindowTop + Console.WindowHeight - 1;

            Header(header);
        }

        public static void WriteLine(string s, ShellLinePad linePad = ShellLinePad.None, ConsoleColor foreColor = ConsoleColor.White, ConsoleColor bgColor = ConsoleColor.Black, int CursorTop = -1)
        {
            // Text padding (add spaces from left, right or both sides)
            switch (linePad)
            {
                case ShellLinePad.Center:
                    s = s.PadBoth(Console.WindowWidth);
                    break;
                case ShellLinePad.Right:
                    s = s.PadRight(Console.WindowWidth);
                    break;
                case ShellLinePad.Left:
                    s = s.PadLeft(Console.WindowWidth);
                    break;
            }

            // Set line color
            Console.ForegroundColor = foreColor;
            Console.BackgroundColor = bgColor;

            // Set correct cursor position (right next one after the last added)
            if(Console.CursorTop > 0 && CursorTop == -1)
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
            }
            if(CursorTop != -1)
            {
                Console.SetCursorPosition(0, CursorTop);
            }
            
            // Write the actual text of the line
            Console.WriteLine(s);

            // Reset console color to the default values
            Console.ResetColor();

            // Prevent scroll of the window
            PreventScrolling();
        }

        public static void Write(string s)
        {
            Console.Write(s);
        }


        
        /// <summary>
        /// Application header, also sets the console title
        /// </summary>
        /// <param name="title">Title of application</param>
        private static void Header(string title)
        {
            Console.Title = title;
            //Console.ForegroundColor = ConsoleColor.White;
            //Console.BackgroundColor = ConsoleColor.Blue;
            ShellConsole.WriteLine(title, ShellLinePad.Center, headerForeColor, headerBgColor, CursorTop: 0);
            //Console.ResetColor();
        }
        public static string Title
        {
            get
            {
                return Console.Title;
            }
        }

        public static void MainKeyBindings(string[] mainKeyBindings)
        {
            string items = "  ";
            foreach(string item in mainKeyBindings)
            {
                items += item;

                if(item != mainKeyBindings.Last())
                    items += " | ";
            }
            WriteLine(items, ShellLinePad.Right, menuForeColor, menuBgColor, CursorTop: lastRowCursorPos);
        }

        public static void FillPartOfWindow(ConsoleColor bgColor, int numberOfRows, int startingRow = -1)
        {
            int cursorEndPos = (startingRow == -1) ? Console.CursorTop + numberOfRows : startingRow + numberOfRows;
            for (int i = (startingRow == -1) ? Console.CursorTop : startingRow; i <= cursorEndPos; i++)
                WriteLine("", ShellLinePad.Center, bgColor: bgColor, CursorTop: i);
        }

        public static void FillRestOfWindow(ConsoleColor bgColor)
        {
            for(int i = Console.CursorTop; i <= lastRowCursorPos; i++)
                WriteLine("", ShellLinePad.Center, bgColor: bgColor);   
        }

        private static void PreventScrolling()
        {
            Console.SetWindowPosition(0, 0);
        }

        private static string PadBoth(this string str, int length)
        {
            int spaces = length - str.Length;
            int padLeft = spaces / 2 + str.Length;
            return str.PadLeft(padLeft).PadRight(length);
        }

        public enum ShellLinePad
        {
            None,
            Left,
            Center,
            Right
        }
    }
}

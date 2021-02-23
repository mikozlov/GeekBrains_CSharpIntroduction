using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz2._4
{
    class ConsolePrint
    {
        public static void DrawHorizontalLine(int offsetY, string sym, int lenght)
        {
            Console.SetCursorPosition(0, offsetY);
            for (int i = 0; i < lenght; i++)
            {
                Console.Write(sym);
            }
            Console.Write("\n");
        }
        public static void PrintTextAlign(int rowNum, string str, Align align)
        {
            int horizontalStart;
            switch (align)
            {
                case Align.Left://1
                    horizontalStart = 0;
                    Console.SetCursorPosition(horizontalStart, rowNum);
                    Console.WriteLine(str);
                    break;
                case Align.Right:
                    horizontalStart = (Console.WindowWidth - str.Length);
                    Console.SetCursorPosition(horizontalStart, rowNum);
                    Console.WriteLine(str);
                    break;
                case Align.Centr:
                    horizontalStart = (Console.WindowWidth - str.Length) / 2;
                    Console.SetCursorPosition(horizontalStart, rowNum);
                    Console.WriteLine(str);
                    break;
                default: //left
                    horizontalStart = 0;
                    Console.SetCursorPosition(horizontalStart, rowNum);
                    Console.WriteLine(str);
                    break;

            }   
        
        } 
    }
    enum Align
    {
        Left = 1,
        Right = 2,
        Centr = 3
    }
}

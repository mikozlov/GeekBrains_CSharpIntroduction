using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz3._1
{
    class Program
    {

        static void Main(string[] args)
        {
        
            int arrayDim = 10;
            int[,] userArray = new int[arrayDim, arrayDim];


            //заполнение массива и вывод значений по диагонали
            int val = 0;
            for (int i = 0; i <= userArray.GetUpperBound(0); i++)
                    for (int j = 0; j <= userArray.GetUpperBound(1); j++)                    
                        userArray[i, j] = ++val;

            ArrayPrint(userArray, ArrayPrintOptions.allValDiagonal);
            ArrayPrint(userArray, ArrayPrintOptions.MainDiagonal);
            ArrayPrint(userArray, ArrayPrintOptions.SideDiagonal);
            ArrayPrint(userArray, ArrayPrintOptions.SideDiagonalRevers);

            Console.ReadKey();




        }
        public static void ArrayPrint(int[,] userArray, ArrayPrintOptions option)
        {
            int leftShift = 0;
            int k = 0;

            switch (option)
            {
                case ArrayPrintOptions.allValDiagonal:
                    Console.WriteLine("Вывод значений массива по диагонали");
                    for (int i = 0; i <= userArray.GetUpperBound(0); i++)
                        for (int j = 0; j <= userArray.GetUpperBound(1); j++)
                        {
                            Console.SetCursorPosition(++leftShift, Console.CursorTop);
                            Console.WriteLine(userArray[i, j]);
                        }
                    break;
                case ArrayPrintOptions.MainDiagonal:
                    Console.WriteLine("Вывод значений главной диагонали");
                    for (int i = 0; i <= userArray.GetUpperBound(0); i++)
                    {
                        Console.SetCursorPosition(++leftShift, Console.CursorTop);
                        Console.WriteLine(userArray[i, i]);
                    }
                    break;
                case ArrayPrintOptions.SideDiagonal:
                    leftShift = userArray.GetUpperBound(0);
                    Console.WriteLine("Вывод значений побочной диагонали");

                    for (int i = userArray.GetUpperBound(0); i >= 0; i--)
                    {
                        Console.SetCursorPosition(leftShift--, Console.CursorTop);
                        Console.WriteLine(userArray[k++, i]);
                    }
                    break;
                case ArrayPrintOptions.SideDiagonalRevers:
                    leftShift = userArray.GetUpperBound(0);

                    Console.WriteLine("Вывод значений побочной в обратном порядке");

                    for (int i = userArray.GetUpperBound(0); i >= 0; i--)
                    {
                        Console.SetCursorPosition(leftShift--, Console.CursorTop);
                        Console.WriteLine(userArray[i, k++]);
                    }
                    break;
                default:
                    Console.WriteLine("Ошибка!! Некорректная опция ArrayPrintOptions!");
                    break;
            }
        }
        public enum ArrayPrintOptions
        {
            allValDiagonal = 1,
            MainDiagonal =2,
            SideDiagonal =3,
            SideDiagonalRevers =4

        }
    }
}

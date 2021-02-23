using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alg_dz1._3
{
    public class Program
    {

        static void Main(string[] args)
        {
            while (true)
            {
                int fibonachiNum = UserInput.GetNumInt("Введите порядковый номер числа Фибоначи: ");
                if (fibonachiNum < 0) fibonachiNum *= -1;

                //Циклический
                Console.WriteLine("Алгоритм2:Число Фибоначи №{1} = {0}", getFibonachi2(fibonachiNum), fibonachiNum);                
                //Рекурсивный
                Console.WriteLine("Алгоритм3:Число Фибоначи №{1} = {0}", getFibonachi3(fibonachiNum), fibonachiNum);
                //Рекурсивный
                Console.WriteLine("Алгоритм4:Число Фибоначи №{1} = {0}", getFibonachi4((ulong)fibonachiNum), fibonachiNum);

                //Гибридный?)                
                i = 0;
                ulong fibonachi1 = 0;
                ulong fibonachi2 = 1;
                ulong fibonachi3 = 1;
                Console.WriteLine("Алгоритм?:Число Фибоначи №{1} = {0}", getFibonachi1(ref fibonachi3, ref fibonachi1, ref fibonachi2, fibonachiNum), fibonachiNum);
                
            }
       
        }

        public static int i = 0;
        public static ulong getFibonachi1(ref ulong fibonachi3, ref ulong fibonachi1, ref ulong fibonachi2, int fibonachiNum)
        {
            if (fibonachiNum == 0) return 0;


            while (i < fibonachiNum)
            {
                if (fibonachi3 >= 18_446_744_073_709_551_615) { Console.WriteLine("Ошибка!Превышен допустимый размер числа."); return 0; }
                fibonachi3 = fibonachi1 + fibonachi2;
                fibonachi1 = fibonachi2;
                fibonachi2 = fibonachi3;
                i++;
                getFibonachi1(ref fibonachi3, ref fibonachi1, ref fibonachi2, fibonachiNum);
            }

            return fibonachi1;
        }
        public static ulong getFibonachi2(int fibonachiNum)
        {
            ulong fibonachi3 = 1;
            ulong fibonachi1 = 0;
            ulong fibonachi2 = 1;

            for (int j = 0; j < fibonachiNum; j++)
            {

                if (fibonachi3 >= 18_446_744_073_709_551_615)
                    break;

                fibonachi3 = fibonachi1 + fibonachi2;
                fibonachi1 = fibonachi2;
                fibonachi2 = fibonachi3;

            }

            return fibonachi1;

        }
        public static ulong getFibonachi4(ulong fibonachiNum)
        {
            if (fibonachiNum == 0 || fibonachiNum == 1)
            {
                return (ulong)fibonachiNum;
            }
            else
            {
                return getFibonachi4(fibonachiNum - 1) + getFibonachi4(fibonachiNum - 2);
            }

        }
        public static ulong getFibonachi3(int fibonachiNum, int iterator = 0, ulong f3=2, ulong f1=0, ulong f2=1)
        {
            if (iterator < fibonachiNum)            
               return getFibonachi3(fibonachiNum, ++iterator, (f3 = f1 + f2), (f1 = f2), (f2 = f3));
            
            return f1;

        }
    }
}

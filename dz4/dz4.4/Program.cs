using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dz2._1;

namespace dz4._4
{
    class Program
    {
        public static int i;
        public static int fibonachiNum;
        static void Main(string[] args)
        {
            ulong fibonachi1 = 0;
            ulong fibonachi2 = 1;
            ulong fibonachi3 = 1;
            fibonachiNum = UserInput.GetNumInt("Введите порядковый номер числа Фибоначи: ");

            if (fibonachiNum==0)
            {
                Console.WriteLine("Число Фибоначи №0 = 0");
                Console.ReadKey();
                return;
            }

            i = 1;


            Console.WriteLine("Число Фибоначи №{1} = {0}",  getFibonachi(ref fibonachi3, ref fibonachi1, ref fibonachi2), i-1);

            Console.ReadKey();
        }
        
        public static ulong getFibonachi(ref ulong fibonachi3, ref ulong fibonachi1, ref ulong fibonachi2)
        {
            
            fibonachi3 = fibonachi1 + fibonachi2;
            fibonachi1 = fibonachi2;
            fibonachi2 = fibonachi3;
            
            Console.WriteLine("{0} {1}",i++ , fibonachi3);

            while (i <= fibonachiNum)
            {
                
                if (fibonachi3 >= 18_446_744_073_709_551_615)
                    break;
                fibonachi3 = getFibonachi(ref fibonachi3, ref fibonachi1, ref fibonachi2);
                
            }

            return fibonachi3;

            }
            
            
    }
}

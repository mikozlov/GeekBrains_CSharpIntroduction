using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz4._2
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Чтобы получить сумму - введите одной строкой целые числа разделенные пробелом:");
           Console.WriteLine( SumFromSpaceString (Console.ReadLine()));
            Console.ReadKey();


            
        }
        static int SumFromSpaceString(string Numbers)
        {
            int Sum = 0;
            string [] NumArray = Numbers.Split(' ');

            for (int i =0; i < NumArray.Length; i++)             
            if (int.TryParse(NumArray[i], out int Num))
                Sum += Num;


            return Sum;
        }
    }
}

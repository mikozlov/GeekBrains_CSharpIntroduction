using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dz2._1;

namespace dz2._3
{
    class Program
    {
        static void Main(string[] args)
        {
           var num = UserInput.GetNumInt("\nВведите целое число:");
            if ((num % 2) == 0)
            {
                Console.WriteLine("\nПоздравляем! Вы ввели четное число.");
                Console.ReadKey();
            }
            else 
            {
                Console.WriteLine("\nПоздравляем! Вы ввели четное число.");
                Console.ReadKey();
            }
        }
    }
}

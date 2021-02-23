using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Как вас зовут?");
            string userName = Console.ReadLine();
            Console.WriteLine($"Привет, {userName}, сегодня {DateTime.Now.ToShortDateString()}");
            Console.ReadKey();
        }
    }
}

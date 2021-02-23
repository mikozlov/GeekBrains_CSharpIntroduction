using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz3._3
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Напишите слово которое надо первернуть:");
                string userInput = Console.ReadLine();

                for (int i = userInput.Length-1; i >= 0; i--)
                {
                    Console.Write(userInput[i]); 
                }
                Console.WriteLine("\n");
            }
        }
    }
}

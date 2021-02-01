using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz4._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] personFIO = { { "Kozlov", "Mikhail", "Alexandrovich" }, { "Petrov", "Soso", "Pauliashvili" }, { "Kobra", "Alex", "Ignatovich" }, { "Big", "Petr", "Petrovich" } };

            for (int i=0; i <= personFIO.GetUpperBound(0); i++)
            {
                Console.WriteLine("Сотрудник: {0}", GetFullName(personFIO[i, 1], personFIO[i, 0], personFIO[i, 2]));
            }

            Console.ReadKey();

        }
        static string GetFullName(string firstName, string lastName, string patronymic)
        {
            return $"{lastName} {firstName[0]}.{patronymic[0]}.";            
        }
    }

}

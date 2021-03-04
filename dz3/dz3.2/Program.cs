using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace dz3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] phoneBook = new string[5, 2];
            phoneBook[0, 0] = "Ivanov"; phoneBook[0, 1] = "+7 925 11111111";
            phoneBook[1, 0] = "Kozlov"; phoneBook[1, 1] = "+7 925 22222222";
            phoneBook[2, 0] = "Sidorov"; phoneBook[2, 1] = "+7 925 33333333";
            phoneBook[3, 0] = "Kozlov"; phoneBook[3, 1] = "+7 925 44444444";
            phoneBook[4, 0] = "Pimenov"; phoneBook[4, 1] = "kakadu@gmail.com";


            Console.WriteLine("Кого вы ищете? Для поиска используйте синтаксис регулярных выражений (regexp):");
            while (true)
            {                
                string query = Console.ReadLine();
                searchInphoneBook(query, phoneBook);
                Console.WriteLine("Хотите найти кого то еще? Для поиска используйте синтаксис регулярных выражений (regexp):");
            }
            

        }

        public static void searchInphoneBook(string query, string[,] phoneBook)
        {
            string searchRes ="";
            for (int i = 0; i <= phoneBook.GetUpperBound(0); i++)
                if (new Regex (query).IsMatch(phoneBook[i, 0]))
                    searchRes += $"{phoneBook[i, 0]} {phoneBook[i, 1]}\n";

            if(searchRes == "")
                Console.WriteLine("\nПо запросу ничего не найдено");
            Console.WriteLine(searchRes);

        }
    }
}

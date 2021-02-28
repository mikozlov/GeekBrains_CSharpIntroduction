using System;

namespace alg_dz2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            string[] array = { "Первый","Второй","3","4-ый","5ятый","Шшшшшш","Ссссс","8888888","9 девятый, nine, neun","10 последний"};
            foreach (var item in array)
            {
                Console.WriteLine("#{0}: {1}", i++, item);
            }
            Console.WriteLine();

            while (true)
            {
                    Console.WriteLine("Что вы ищите?:");
                    string searchString = Console.ReadLine();
                    int res = BinarySearch.Search(array, searchString);
                if (res == -1)
                { 
                    Console.WriteLine("По вашему запросу ничего не найдено"); 
                }
                else
                { 
                    Console.WriteLine("Найдено совпадние, элемент #{0}", res); 
                }
            }
            
           
        }
            
    }

}

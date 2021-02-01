using System;
using System.IO;

namespace dz5._1
{
    class Program
    {
        static void Main(string[] args)
        {

            string fileName = "StringFile.txt";

            Console.WriteLine("Напишите что-нибудь, чтобы мы  могли сохранить это в файл:");
            string str = Console.ReadLine();
            
            File.WriteAllText(fileName, str);
            Console.WriteLine("В файл {0} записан следующий текст: {1}",fileName ,File.ReadAllText("StringFile.txt"));

            Console.ReadKey();
        }
    }
}
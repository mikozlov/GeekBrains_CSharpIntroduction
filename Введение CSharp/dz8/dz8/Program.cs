using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz8
{
    class Program
    {
        static void Main(string[] args)
        {
            if (Properties.Settings.Default.WelcomePhrase == "")
            {
                Console.WriteLine("Как вас поприветствовать?:");
                Properties.Settings.Default.WelcomePhrase = Console.ReadLine();
                Console.WriteLine("Как вас зовут?:");
                Properties.Settings.Default.Name = Console.ReadLine();
                Console.WriteLine("Сколько вам лет?:");
                Properties.Settings.Default.Age = Console.ReadLine();
                Console.WriteLine("Кто вы по профессии?:");
                Properties.Settings.Default.Profession = Console.ReadLine();
                Properties.Settings.Default.Save();
            }

            Console.Clear();
            Console.WriteLine("{0}", Properties.Settings.Default.WelcomePhrase);
            Console.WriteLine("Ваше имя: {0}", Properties.Settings.Default.Name);
            Console.WriteLine("Ваш возраст: {0}", Properties.Settings.Default.Age);
            Console.WriteLine("Ваша профессия: {0}", Properties.Settings.Default.Profession);
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Удалить данные?[да/нет]:");
            var answer = Console.ReadLine();

            if (answer == "да")
            {
                Properties.Settings.Default.WelcomePhrase = "";
                Properties.Settings.Default.Name = "";
                Properties.Settings.Default.Age = "";
                Properties.Settings.Default.Profession = "";
                Properties.Settings.Default.Save();
            }


        }
    }
}

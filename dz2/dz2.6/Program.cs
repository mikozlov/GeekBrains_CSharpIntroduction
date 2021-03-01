using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz2._6
{
    class Program
    {
        static void Main(string[] args)
        {

            //задаем режим работы офиса
            OfficeSсhedule.workingDays = (byte)new Random().Next(0,128);
            //Расшифровываем маску через enum WeekDay           
            string str = "";
            for (int i = 1; i <= 64; i *= 2)
            {
                if (OfficeSсhedule.workingDays == 0)
                {
                    Console.WriteLine("Next week our office on holidays. Try next time;)");
                    Console.ReadKey();
                    return;
                }

                if ((OfficeSсhedule.workingDays & i) == i)
                {
                    str += Enum.GetName(typeof(WeekDay),i);
                    str += ", ";
                }
            }
            //Запрос пользователя об удобных датах посещения офиса
            Console.WriteLine($"Next week our company work on: {str}");
            Console.WriteLine("When would you like to come?");
            Console.WriteLine($"Plese print weekday f.e. [{str}] :");
            string userInput = Console.ReadLine();
            //todo:можно развить тему с проверкой ответа на допустимое значение и корректировкой в графике работы офиса исключив из него выбранный день 
            Console.WriteLine(userInput);
            Console.ReadKey();
        }
        class OfficeSсhedule
        {
           public static byte workingDays;
            /*            
            Monday = 1,
            Tuesday = 2,
            Wednesday = 4,
            Thursday = 8,
            Friday = 16,
            Saturday = 32,
            Sunday = 64 
            */

        }
        public enum WeekDay 
        {
            Monday = 1,
            Tuesday = 2,
            Wednesday = 4,
            Thursday = 8,
            Friday = 16,
            Saturday = 32,
            Sunday = 64        
        }
    }
}

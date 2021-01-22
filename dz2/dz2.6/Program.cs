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
            OfficeSсhedule office_I = new OfficeSсhedule((byte)new Random().Next(0,128));
            //Расшифровываем маску через enum WeekDay           
            string str = "";
            for (int i = 1; i <= 64; i *= 2)
            {
                if (office_I.workingDays == 0)
                {
                    Console.WriteLine("Next week our office on holidays. Try next time;)");
                    Console.ReadKey();
                    return;
                }

                if ((office_I.workingDays & i) == i)
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
            Console.WriteLine(userInput);
            Console.ReadKey();
        }
        class OfficeSсhedule
        {
           public byte workingDays;
            /*            
            Monday = 1,
            Tuesday = 2,
            Wednesday = 4,
            Thursday = 8,
            Friday = 16,
            Saturday = 32,
            Sunday = 64 
            */
            public OfficeSсhedule(byte wDays)
            {
                   workingDays = wDays;
            }
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

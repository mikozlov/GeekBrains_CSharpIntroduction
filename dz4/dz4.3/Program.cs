using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dz2._1;

namespace dz4._3
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
             Console.WriteLine(GetRussianSeasonName(GetSeason(GetMonthNum())));
            Console.ReadKey();

        }
        public static string GetRussianSeasonName (Seasons season)
        {
            switch (season)
            { 
                case Seasons.Winter:
                    return "Зима";                    
                case Seasons.Spring:
                    return "Весна";
                case Seasons.Summer:
                    return "Лето";
                case Seasons.Autumn:
                    return "Осень";
                default:
                    UserInput.ErrorMesseg("Ошибка. Некорректное значение переменной season");
                    return "XXXXX";
            }
        
        
        }
        public static Seasons GetSeason(int monthNum)
        {
            if (monthNum == 12 || monthNum <= 2)
                return Seasons.Winter;
            else if (monthNum >= 3 & monthNum <= 5)
                return Seasons.Spring;
            else if (monthNum >= 6 & monthNum <= 8)
                return Seasons.Summer;
            else // (monthNum >= 9 & monthNum <= 11)
                return Seasons.Autumn;

        }

        public static int GetMonthNum()
        {
            int monthNum;
            while (true)
            {
                monthNum = UserInput.GetNumInt("\nУкажите порядковый номер текущего месяца:");
                if (monthNum >= 1 && monthNum <= 12)
                {
                    break;
                }
                else
                {
                    UserInput.ErrorMesseg("\nНекоретный ввод. Укажите число от 1 до 12");
                }
            }
            return monthNum;
        }
        public  enum Seasons
        {
            Winter, Spring, Summer, Autumn
        }
    }

}

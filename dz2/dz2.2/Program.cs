using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dz2._1;

namespace dz2._2
{
   public class Program
    {
        static void Main(string[] args)
        {        
            Console.WriteLine("\nТекущий месяц:\n{0}", (new DateTime(1, GetMonthNum(), 1).ToString("MMMM")));
            Console.ReadKey();
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
                    UserInput.errorMesseg("\nНекоретный ввод. Укажите число от 1 до 12"); 
                }
            }
            return monthNum;
        }

    }
}

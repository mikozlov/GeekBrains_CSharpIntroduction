using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alg_dz1._3
{
    public class UserInput
    {
        public static float GetNumFloat(string userRequest)
        {
            float value;
            while (true)
            {

                Console.WriteLine(userRequest);
                try
                {
                    value = float.Parse(Console.ReadLine());
                    break;
                }
                catch
                {
                    ErrorMesseg("Введено некорректное значение. Повторите ввод указав десятичное число\n>>");                  
                }
            }
            return value;
         

        }
        public static int GetNumInt(string userRequest)
        {
            int value;
            while (true)
            {

                Console.WriteLine(userRequest);
                try
                {
                    value = int.Parse(Console.ReadLine());
                    break;
                }
                catch
                {
                    ErrorMesseg("Введено некорректное значение. Повторите ввод указав целое число от -2147483648 до 2147483647\n>>");
                }
            }
            return value;
        }
        public static void ErrorMesseg(string errorMesseg)
        {
            var defColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorMesseg);
            Console.ForegroundColor = defColor;
        }
    }
}

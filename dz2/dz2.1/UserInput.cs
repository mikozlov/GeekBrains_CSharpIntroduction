using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz2._1
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
                    errorMesseg("Введено некорректное значение. Повторите ввод указав десятичное число\n>>");                  
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
                    errorMesseg("Введено некорректное значение. Повторите ввод указав целое число\n>>");
                }
            }
            return value;
        }
        public static void errorMesseg(string errorMesseg)
        {
            var defColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorMesseg);
            Console.ForegroundColor = defColor;
        }
    }
}

using System;

namespace alg_dz1
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
           Console.WriteLine(TestPrimeOrNot(GetNumInt("Напишите число, чтобы проверить простое ли оно:")));

        }
        public static string TestPrimeOrNot(int n)
        {
            int d = 0;
            int i = 2;

            while (i < n)
            {

                if (n % i == 0)
                    d++;

                    i++;
            }

            if (d == 0)
            {
                return "Простое";
            }
            else
            {
                return "Не простое";
            }
        }
        public static int GetNumInt(string userRequest)
        {
           
            while (true)
            {

                Console.WriteLine(userRequest);

                   if( int.TryParse(Console.ReadLine(),out int num) )
                        if (num >= 0)
                        return num;

                    ErrorMesseg("Введено некорректное значение. Повторите ввод указав целое число от 0 до 2147483647\n>>");
                
            }
            
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


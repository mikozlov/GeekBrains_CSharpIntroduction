using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvgTemp = dz2._1.Program;
using MothfName = dz2._2.Program;

namespace dz2._5
{
    class Program
    {
        static void Main(string[] args)
        {
           var temp = AvgTemp.GetAvgTemp();
           var month = MothfName.GetMonthNum();

            if (month <=2 || month <= 2 && temp >= 0 )
            {
                Console.Clear();
                Console.WriteLine("\nДождливая зима...( \nПри Собянине все зимы дождливые.");
                Console.ReadKey();
            }  
        }
    }
}

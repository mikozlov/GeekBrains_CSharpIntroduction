using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz2._1
{
    public class Program
    {
        static void Main(string[] args)
        {
            GetAvgTemp();
        }
        public static float GetAvgTemp()
        {
            float MaxTemp = UserInput.GetNumFloat("\nУкажите максимальную температуру за сутки [MaxTemp]:");
            float MinTemp = UserInput.GetNumFloat("\nУкажите минимальную температуру за сутки [MinTemp]:");

            float AvgTemp = (MaxTemp + MinTemp) / 2;
            Console.WriteLine($"\nСреднесуточная температура составляет:\n{AvgTemp}");
            Console.ReadKey();
            return AvgTemp;
        }
    }

}

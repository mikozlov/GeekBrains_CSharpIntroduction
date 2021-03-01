using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace dz2._4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Общие данные продавца
            string brandName = "ООО \"Веселый молочник\"" ;
            int kkm = 00039892;
            ulong inn = 007721754215;                      
            string emploerPost = "Кассир";
            string operationType = "Продажа";
            DateTime billCreateTime = DateTime.Now;
            int billCount = new Random().Next(2000);
            double totalCost = 0;

            //Генерация списка покупок
            List<GoodInBasket> goods =new List<GoodInBasket>();                       
            for (int n = 0; n < (new Random().Next(10)); n++)
            {               
                goods.Add(new GoodInBasket());
                Thread.Sleep(20);
            }
            
            #region Печать чека
            // Старт печати чека
            int i = 0;
            Console.WindowWidth = 40;
            Console.WindowHeight = 40;
            ConsolePrint.DrawHorizontalLine(i++, "==", 20);
            ConsolePrint.PrintTextAlign(i++ , brandName, Align.Centr);
            ConsolePrint.PrintTextAlign(i++, "ДОБРО ПОЖАЛОВАТЬ !", Align.Centr);
            ConsolePrint.PrintTextAlign(++i, $"ККМ:{kkm}", Align.Left); ConsolePrint.PrintTextAlign(i++, $"ИНН:{inn}", Align.Right);
            ConsolePrint.PrintTextAlign(i, $"{billCreateTime}", Align.Left); ConsolePrint.PrintTextAlign(i++, $"{emploerPost}", Align.Right);
            ConsolePrint.PrintTextAlign(i, $"{operationType}", Align.Left); ConsolePrint.PrintTextAlign(i++, $"#{billCount}", Align.Right); 
            ConsolePrint.DrawHorizontalLine(i++, "==", 20);

            // Печать списка покупок
            
            foreach (var good in goods) 
                {                     
                    ConsolePrint.PrintTextAlign(i, $"{good.name}", Align.Left); ConsolePrint.PrintTextAlign(i++, $"{good.count} X {good.cost}", Align.Right);            
                    totalCost += (good.cost*good.count);                    
                }

            // Печать итого
            ConsolePrint.DrawHorizontalLine(i++, "==", 20);                       
            ConsolePrint.PrintTextAlign(i++, $"В т.ч. Налоги:", Align.Left);
            ConsolePrint.PrintTextAlign(i, $"По налогу А 18%:", Align.Left); ConsolePrint.PrintTextAlign(i++, $"={totalCost * 0.18}", Align.Right);
            ConsolePrint.PrintTextAlign(i, $"По налогу Б 10%:", Align.Left); ConsolePrint.PrintTextAlign(i++, $"={totalCost * 0.1}", Align.Right);
            ConsolePrint.PrintTextAlign(i, $"ИТОГ", Align.Left); ConsolePrint.PrintTextAlign(i++, $"={totalCost}", Align.Right);
            ConsolePrint.PrintTextAlign(i, $"ОПЛАТ. КАРТОЙ", Align.Left); ConsolePrint.PrintTextAlign(i++, $"={totalCost}", Align.Right);

            // Завершение печати чека
            ConsolePrint.DrawHorizontalLine(i++, "==", 20);            
            ConsolePrint.PrintTextAlign(i++, "ЭКЛЗ 0699062480", Align.Centr);
            ConsolePrint.PrintTextAlign(i++, "00002589 #062444", Align.Centr);
            Console.ReadKey();
            #endregion
        }

    }
    class GoodInBasket
    {
        public float cost;
        public string name;
        public float count;

       public GoodInBasket()
        {
         cost = new Random().Next(500,1000);
         name = $"Молочный продукт №{new Random().Next(100000):D}";
         count = new Random().Next(10);
        }
    }
}

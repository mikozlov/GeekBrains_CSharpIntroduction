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
            string kkm = "00039892";
            string inn = "007721754215";                      
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
            ConsolPrint.DrawHorizontalLine(i++, "==", 20);
            ConsolPrint.PrintTextAlign(i++ , brandName, align.Centr);
            ConsolPrint.PrintTextAlign(i++, "ДОБРО ПОЖАЛОВАТЬ !", align.Centr);
            ConsolPrint.PrintTextAlign(++i, $"ККМ:{kkm}", align.Left); ConsolPrint.PrintTextAlign(i++, $"ИНН:{inn}", align.Right);
            ConsolPrint.PrintTextAlign(i, $"{billCreateTime}", align.Left); ConsolPrint.PrintTextAlign(i++, $"{emploerPost}", align.Right);
            ConsolPrint.PrintTextAlign(i, $"{operationType}", align.Left); ConsolPrint.PrintTextAlign(i++, $"#{billCount}", align.Right); 
            ConsolPrint.DrawHorizontalLine(i++, "==", 20);

            // Печать списка покупок
            
            foreach (var good in goods) 
                {                     
                    ConsolPrint.PrintTextAlign(i, $"{good.name}", align.Left); ConsolPrint.PrintTextAlign(i++, $"{good.count} X {good.cost}", align.Right);            
                    totalCost += (good.cost*good.count);                    
                }

            // Печать итого
            ConsolPrint.DrawHorizontalLine(i++, "==", 20);                       
            ConsolPrint.PrintTextAlign(i++, $"В т.ч. Налоги:", align.Left);
            ConsolPrint.PrintTextAlign(i, $"По налогу А 18%:", align.Left); ConsolPrint.PrintTextAlign(i++, $"={totalCost * 0.18}", align.Right);
            ConsolPrint.PrintTextAlign(i, $"По налогу Б 10%:", align.Left); ConsolPrint.PrintTextAlign(i++, $"={totalCost * 0.1}", align.Right);
            ConsolPrint.PrintTextAlign(i, $"ИТОГ", align.Left); ConsolPrint.PrintTextAlign(i++, $"={totalCost}", align.Right);
            ConsolPrint.PrintTextAlign(i, $"ОПЛАТ. КАРТОЙ", align.Left); ConsolPrint.PrintTextAlign(i++, $"={totalCost}", align.Right);

            // Завершение печати чека
            ConsolPrint.DrawHorizontalLine(i++, "==", 20);            
            ConsolPrint.PrintTextAlign(i++, "ЭКЛЗ 0699062480", align.Centr);
            ConsolPrint.PrintTextAlign(i++, "00002589 #062444", align.Centr);
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

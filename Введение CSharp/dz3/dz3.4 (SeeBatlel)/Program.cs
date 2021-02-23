using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace dz3._4__SeeBatlel_
{
    class Program
    {
        static void Main(string[] args)
        {
            int offsetX = 1;
            int offsetY = 1;

            string[,] annotion =new string [11, 11];

            for (int i =1;i<=10 ;i++)
                annotion[0, i] = i.ToString();

            for (int i = 1; i <= 10; i++)
                annotion[i, 0] = Char.ConvertFromUtf32(i+64);



            printField(annotion, offsetX, offsetY);

            printField(fieldGenerate(), offsetX + 2, offsetY + 1);
            Console.ReadKey();
        }

        static void printField(string[,] frame, int xOffset, int yOffset)
        {
            for (int i = 0; i <= frame.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= frame.GetUpperBound(1); j++)
                {
                    Console.SetCursorPosition(i*3+xOffset, j + yOffset);
                    Console.Write(frame[i, j]);
                }
                Console.WriteLine();
            }
        }
        static string[,] fieldGenerate()
        {
            string[,] frame = new string[10, 10];

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    frame[i, j] = " ~ ";
                }
            }

            shipGenerate(4, ref frame); Thread.Sleep(10);

            shipGenerate(3, ref frame); Thread.Sleep(10);
            shipGenerate(3, ref frame); Thread.Sleep(10);
           
            shipGenerate(2, ref frame); Thread.Sleep(10);
            shipGenerate(2, ref frame); Thread.Sleep(10);
            shipGenerate(2, ref frame); Thread.Sleep(10);

            shipGenerate(1, ref frame); Thread.Sleep(10);
            shipGenerate(1, ref frame); Thread.Sleep(10);
            shipGenerate(1, ref frame); Thread.Sleep(10);
            shipGenerate(1, ref frame); Thread.Sleep(10);

            return frame;
        }
        static void shipGenerate(int shipDeckNum, ref string[,] frame)
        {
            Random r = new Random();
            int x;
            int y;
            int n;
            int d = r.Next(1, 3);
            bool flag = true;
            

            while (flag)
            {
                bool check = true;
                switch (d)
                {
                    default:
                        x = r.Next(0, 9 - shipDeckNum); Thread.Sleep(10);
                        y = r.Next(0, 9); Thread.Sleep(10);
                        for (n=y-1; n<=(y+1); n++) 
                        {
                            for (int k = -1; k < shipDeckNum + 1; k++)
                            {
                                if (((x + k) < 10) & ((x + k) >= 0) & (n < 10) & (n >= 0))
                                {
                                    if (frame[x + k, n] == "[X]")
                                        check = false;
                                }
                                if (!check)
                                    break;
                            }
                            if (!check)
                                break;
                        }
                        if (!check)
                            break;

                        for (int k = 0; k < shipDeckNum; k++)
                        {
                            frame[x + k, y] = "[X]";
                        }

                        flag = false;
                        break;

                    case 2:
                        x = r.Next(0, 10); Thread.Sleep(10);
                        y = r.Next(0, 10 - shipDeckNum); Thread.Sleep(10);
                        for (n = x - 1; n <= (x + 1); n++)
                        {
                            for (int k = -1; k < shipDeckNum + 1; k++)
                            {
                                if ((n < 10) & (n >= 0) & ((y + k) < 10) & ((y + k) >= 0))
                                {
                                    if (frame[n, y + k] == "[X]")
                                        check = false;
                                        
                                }
                                if (!check)
                                    break;
                            }
                            if (!check)
                                break;
                        }
                        if (!check)
                            break;
                        for (int k = 0; k < shipDeckNum; k++)
                            {
                            
                                    frame[x, y + k] = "[X]";
                            }
                        flag = false;
                        break;

                }

                
            }
            
        }
        
    }
}


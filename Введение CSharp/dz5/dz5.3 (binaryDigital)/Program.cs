using System;
using System.IO;

namespace dz5._3__binaryDigital_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите целые числа через пробел для записи в бинарный файл: ");
            string str = Console.ReadLine();
            string [] strArray=  str.Split(' ');
            byte[] byteArray = new byte [strArray.Length];

            for (int i =0; i< strArray.Length; i++ )
            {
                if(byte.TryParse(strArray[i], out byte digit))                
                byteArray[i] = digit;
            }


            File.WriteAllBytes("binaryFile.bin", byteArray);
            byte[] read = File.ReadAllBytes("binaryFile.bin");
            for (int i = 0; i < read.GetLongLength(0); i++ )
            {
                Console.WriteLine(read[i]);
            }
                Console.ReadKey();

        }
    }
}

using System;
using System.IO;


namespace dz5._2__starupTime_
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!File.Exists("startup.txt"))
            {               
                File.WriteAllText("startup.txt", "Log запуск dz5.2: \n");
            }

                File.AppendAllText("startup.txt", DateTime.Now.ToString());
                File.AppendAllText("startup.txt", Environment.NewLine);
                Console.WriteLine(File.ReadAllText("startup.txt"));
                Console.ReadKey();

        }
    }
}

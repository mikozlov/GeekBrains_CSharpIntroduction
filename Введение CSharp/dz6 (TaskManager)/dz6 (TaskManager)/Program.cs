using System;
using System.Diagnostics;

namespace dz6__TaskManager_
{
    class Program
    {
        static void Main(string[] args)
        {
            string userAnswer = "";
            bool flag = false;
            string manual = @"
Введите запрос:
>>'refresh'
>>'kill_id' (пример: kill_id 12345) 
>>'kill_name' (пример: kill_name chrome)
";
            MyTaskManager.showMeProcesses();
            while (true)
            {
                flag = false;
                Console.WriteLine(manual);



                userAnswer = Console.ReadLine();


                if (userAnswer.StartsWith("kill_id"))
                    if (userAnswer.Length > 8)
                        if (int.TryParse(userAnswer.Substring(8), out int idToKill))
                        { 
                            MyTaskManager.KillProcessById(idToKill);
                            flag = true;
                        }


                if (userAnswer.StartsWith("kill_name"))
                    if (userAnswer.Length > 10)
                    { 
                        MyTaskManager.KillProcessByName(userAnswer.Substring(10));
                        flag = true;
                    }

                if (userAnswer.StartsWith("refresh"))
                {
                    MyTaskManager.showMeProcesses();
                    flag = true;
                }
                
                if (!flag)
                        Console.WriteLine("Ошибка! Некорректное имя команды.");


            }
            Console.ReadKey();
        }
    }
}

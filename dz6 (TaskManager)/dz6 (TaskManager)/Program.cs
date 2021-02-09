using System;
using System.Diagnostics;

namespace dz6__TaskManager_
{
    class Program
    {
        static void Main(string[] args)
        {
            string userAnswer = "";
            while (true)
            {

                var processes = Process.GetProcesses();

                for (int i = 0; i < processes.Length; i++)
                {
                    Console.CursorLeft = 0;
                    Console.Write(processes[i].Id);
                    Console.CursorLeft = 10;
                    Console.Write(processes[i].ProcessName);
                    Console.WriteLine();
                }
                Console.Write("Prompt 'kill_by_Id' or 'kill_by_Name':>");

                userAnswer = Console.ReadLine();


                if (userAnswer.StartsWith("kill_by_Id"))
                 if (int.TryParse(userAnswer, out int idToKill))
                    Process.GetProcessById(idToKill).Kill();

                if (userAnswer.StartsWith("kill_by_Name"))
                    if (userAnswer.Length > 13) 
                { 
                  Process [] processes1 = Process.GetProcessesByName(userAnswer.Substring(13));
                }

            }
            Console.ReadKey();
        }
    }
}

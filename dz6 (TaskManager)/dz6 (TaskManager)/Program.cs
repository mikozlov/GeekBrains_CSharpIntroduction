using System;
using System.Diagnostics;

namespace dz6__TaskManager_
{
    class Program
    {
        static void Main(string[] args)
        {

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
                Console.Write("Prompt ID to kill:>");

                if (int.TryParse(Console.ReadLine(), out int idToKill))
                    Process.GetProcessById(idToKill).Kill();
            }
            Console.ReadKey();
        }
    }
}

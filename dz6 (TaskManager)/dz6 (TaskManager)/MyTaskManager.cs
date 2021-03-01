using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace dz6__TaskManager_
{
    class MyTaskManager
    {
        public static void showMeProcesses()
        {
            var processes = Process.GetProcesses();

            Console.WriteLine("{0,-50}|{1,-10}|{2,-20}|", "ProcessName", "Id", "VirtualMemorySize64");
            Console.WriteLine();

            for (int i = 0; i < processes.Length; i++)
            {               
                Console.WriteLine("{0,-50}|{1,-10}|{2,-20}|", processes[i].ProcessName, processes[i].Id, processes[i].VirtualMemorySize64);                
            }
        }
        public static void KillProcessById(int idToKill)
        {

                try
                {
                    Process.GetProcessById(idToKill).Kill();
                }
                catch
                {
                    Console.Write("Ошибка!: Невозможно завершить процесс");
                }
        }
        
    public static void KillProcessByName (string NameToKill)
        {

            try
            {
                Process[] processes1 = Process.GetProcessesByName(NameToKill);
                foreach (Process p in processes1)
                    try
                    {
                        p.Kill();
                    }
                    catch
                    {
                        Console.Write("Ошибка!: Невозможно завершить процесс");
                    }
            }
            catch
            {
                Console.Write("Ошибка!: Невозможно завершить процесс");
            }
        }
    }
}


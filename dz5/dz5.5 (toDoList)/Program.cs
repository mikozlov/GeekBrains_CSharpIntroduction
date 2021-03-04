using System;
using System.IO;
using System.Text.Json;


namespace dz5._5__toDoList_
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonfileName = "toDoList.json";
            if (!File.Exists(jsonfileName))
                File.AppendAllText(jsonfileName, "");
            Console.WriteLine("Привет, мистер продуктивище!!!Готов к новым задачам?! Ладно,ладно...молчу\n");
            ToDo.ShowMeToDoList();

            while (true)
            {
                Console.WriteLine("\n>>[add] - чтобы ввести новое задание (пример: add сходить на работу)\n>>[done num] - чтобы отметить как завершенное (пример: done 5)\n>>[undone num] - чтобы отметить как незавершенное (пример: undone 5)\n>>[show] - чтобы показать список задач\n");
                string userAnswer = Console.ReadLine();

                if (userAnswer.StartsWith("add "))
                    if (userAnswer.Length > 4)
                        ToDo.addNewTask(userAnswer.Substring(4));

                if (userAnswer.StartsWith("show"))
                    ToDo.ShowMeToDoList();

                if (userAnswer.StartsWith("done "))
                    if(userAnswer.Length > 5)
                        if (int.TryParse(userAnswer.Substring(5), out int doneNum))
                            ToDo.CheckDone(doneNum);   
                
                if (userAnswer.StartsWith("undone "))
                    if (userAnswer.Length > 7)
                        if (int.TryParse(userAnswer.Substring(7), out int undoneNum))
                            ToDo.CheckUnDone(undoneNum);  
                                        
                
            }
            


        }
   }
}

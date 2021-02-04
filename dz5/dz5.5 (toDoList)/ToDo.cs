using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;

namespace dz5._5__toDoList_
{
    class ToDo
    {
        private static ToDo[] curentTaskList;
        private static ToDo[] CurentTaskList
                    {
            get
            { return curentTaskList; }
            set
            { curentTaskList = value; }
                }
        private bool isDone; 
        private static string filePath = "toDoList.json";
        public string Id { get; set; }
        public int NumInList { get; set; }
        public string Title { get; set; }

        public string IsDoneSymbol { get; private set; }
        public bool IsDone 
        {
            get
            {

                return isDone;
            }
            set
            {
                if (value)
                {
                IsDoneSymbol = "[X]";
                isDone = true;
                }
                else
                {
                    IsDoneSymbol = "[-]";
                    isDone = false;
                }

            }

        }

        public ToDo(string title, bool status = false)
        {

            this.Id = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            this.IsDone = status;
            this.Title = title;
        }
        public ToDo()
        { }
        public static void ShowMeToDoList()
        {
            if (!File.Exists(filePath))
                File.AppendAllText(filePath, "");
            UpdateToDolist();
            var toDoList = ToDo.CurentTaskList;
            for (int i = 0; i < toDoList.Length; i++)
                Console.WriteLine("#{0} {2} {1}", toDoList[i].NumInList, toDoList[i].Title,  toDoList[i].IsDoneSymbol);
        }
        private static void UpdateToDolist()
        {
            var options = new JsonSerializerOptions();
            options.AllowTrailingCommas = true;
            ToDo[] toDoList = JsonSerializer.Deserialize<ToDo[]>($"[{File.ReadAllText(filePath)}]", options);

            for (int i = 0; i < toDoList.Length; i++)
            {
                toDoList[i].NumInList = i + 1;
            }
            ToDo.CurentTaskList = toDoList;

        }
        public static void addNewTask(string taskTitle)
        {
            if (!File.Exists(filePath))
                File.AppendAllText(filePath, "");

            string toDo = JsonSerializer.Serialize(new ToDo(taskTitle));
            File.AppendAllText(filePath, $"{toDo},");
            ShowMeToDoList();
        }
        private static void ReWriteTaskListFile(ToDo[] TaskList)
        {
            //UpdateToDolist();

            File.WriteAllText(filePath,"");

            for (int i = 0; i < TaskList.Length; i++)
            {
                File.AppendAllText(filePath, $"{JsonSerializer.Serialize(TaskList[i])},");
            }         


        }
        public static void CheckDone(int taskNum)
        {
            if (!File.Exists(filePath))
                Console.WriteLine("Пусто, братишка...");
            CurentTaskList[taskNum - 1].IsDone = true;
            
            ReWriteTaskListFile(CurentTaskList);
            UpdateToDolist();

            ShowMeToDoList();
        }
        public static void CheckUnDone(int taskNum)
        {
            if (!File.Exists(filePath))
                Console.WriteLine("Пусто, братишка...");
            CurentTaskList[taskNum - 1].IsDone = false;

            ReWriteTaskListFile(CurentTaskList);
            UpdateToDolist();

            ShowMeToDoList();
        }
    }
}

using System;
using System.IO;

namespace dz5._5__toDoList_
{
    class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists("tasks.json"))
            { }
        }
    }
    class ToDo
    {
        private string title;
        private bool isDone;

       public string Title { get; set; }
       public string IsDone { get; set; }



    }
}

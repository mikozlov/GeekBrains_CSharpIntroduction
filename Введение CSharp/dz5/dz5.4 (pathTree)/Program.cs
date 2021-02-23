using System;
using System.IO;
using System.Text.RegularExpressions;

namespace dz5._4__pathTree_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Укажите путь к папке для анализа папочной структуры и файлов:");
            Console.WriteLine(@"Пример>>C:\Users\kozlovma\source\repos\GeekBrains_CSharpIntroduction");

            string BasePath = Console.ReadLine();
            //string BasePath = @"C:\Users\kozlovma\source\repos\GeekBrains_CSharpIntroduction";

            if (!Directory.Exists(BasePath))
            { Console.WriteLine("Жаль, но такого пути не существует"); return; }
                
            
            string logFileName = "DirectoryTree.csv";
            if (File.Exists(logFileName)) File.Delete(logFileName);

            Console.WriteLine("<BasePath>-{0}\n", BasePath);


                //Циклы SearchOption.AllDirectories  
                File.WriteAllText(logFileName, "");
                writePathFileNames(BasePath, BasePath.Length, logFileName);


                //Рекурсия
                File.WriteAllText("R" + logFileName, "");
                writePathFileNamesRecursion(BasePath, BasePath.Length, "R" + logFileName);
            

                //Циклы через дерево каталогов  
                File.WriteAllText("C" + logFileName, "");
                writePathFileNames2(BasePath, BasePath.Length, "C" + logFileName);

            Console.WriteLine("Создан лог-файл с описанием дерева файлов и каталогов: {0}", logFileName);
            
            Console.ReadKey();
        }

        static string cutFileName(string filePath)
        { 
          string[] f = new string[filePath.Split('\\').Length];            
          f = filePath.Split('\\');
            return f[f.Length-1];
        }
        static void printFileNames(string filePath, int leftCutIndex, string logFileName)
        {
            //Console.WriteLine("<Path>-..{0}", filePath.Substring(leftCutIndex));

            File.AppendAllText(logFileName,"");
            File.AppendAllText(logFileName,$"<Path>-..{filePath.Substring(leftCutIndex)}\n");
            var df = Directory.GetFiles(filePath);

            for (int i = 0; i < df.Length; i++)
            {
                Console.WriteLine("..{1};{0}", cutFileName(df[i]), filePath.Substring(leftCutIndex));
                File.AppendAllText(logFileName,$"..{filePath.Substring(leftCutIndex)};{cutFileName(df[i])}\n");
                
            }
        }
        static void writePathFileNames(string BasePath, int leftCutIndex, string logFileName)
        {
            
            printFileNames(BasePath, leftCutIndex, logFileName);

            var dd = Directory.GetDirectories(BasePath,"*" , SearchOption.AllDirectories );            
                    for (int j = 0; j < dd.Length; j++)
                    {
                        printFileNames(dd[j], leftCutIndex, logFileName);
                    }
        }
        static void writePathFileNamesRecursion(string BasePath, int leftCutIndex, string logFileName)
        {
            
            printFileNames(BasePath, leftCutIndex, logFileName);
            if (Directory.GetDirectories(BasePath).Length != 0)
            {
                var dirs = Directory.GetDirectories(BasePath);
                for (int i = 0; i < dirs.Length; i++)
                {
                    var dd = Directory.GetDirectories(dirs[i]);
                    writePathFileNamesRecursion(dirs[i], leftCutIndex, logFileName);
                }
            }
            
        }
        static void writePathFileNames2(string BasePath, int leftCutIndex, string logFileName)
        {
            string[] dirs = { BasePath};


            while (dirs.Length>0)
            {
                string[] dirsBuffer =  { };
                string[] oldDirs =  { };
                string[] newDirs =  { };

                for (int d = 0; d < dirs.Length; d++)
                {
                    printFileNames(dirs[d], leftCutIndex, logFileName);
                    if (Directory.GetDirectories(dirs[d]).Length != 0)
                    {

                        newDirs = Directory.GetDirectories(dirs[d]);
                        oldDirs = dirsBuffer;
                        dirsBuffer = new string[oldDirs.Length + newDirs.Length];
                        oldDirs.CopyTo(dirsBuffer, 0); newDirs.CopyTo(dirsBuffer, oldDirs.Length);
                        
                    }
                }

                dirs = dirsBuffer;
                
            }

        }
    }
}
    



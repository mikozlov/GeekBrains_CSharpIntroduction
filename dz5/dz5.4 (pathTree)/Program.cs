using System;
using System.IO;
using System.Text.RegularExpressions;

namespace dz5._4__pathTree_
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] BasePath = { @"C:\Users\kozlovma\source\repos\GeekBrains_CSharpIntroduction" };
            Console.WriteLine("<BasePath>-{0}", BasePath);

            
           // writePathFileNames(BasePath, BasePath.Length);
            writePathFileNamesRecursion(BasePath, BasePath.Length);
            
            Console.ReadKey();
        }

        static string cutFileName(string filePath)
        { 
          string[] f = new string[filePath.Split('\\').Length];            
          f = filePath.Split('\\');
            return f[f.Length-1];
        }
        static void printFileNames(string filePath, int leftCutIndex)
        {
            Console.WriteLine("<Path>-..{0}", filePath.Substring(leftCutIndex));
            var df = Directory.GetFiles(filePath);

            for (int i = 0; i < df.Length; i++)
            {
                Console.WriteLine(" <File>----{0}", cutFileName(df[i]));
            }
        }


        static void writePathFileNames(string BasePath, int leftCutIndex)
        {  
                var dd = Directory.GetDirectories(BasePath,"*" , SearchOption.AllDirectories );            
                    for (int j = 0; j < dd.Length; j++)
                    {
                        printFileNames(dd[j], leftCutIndex);
                    }
        }
        static string writePathFileNamesRecursion(object BasePath, int leftCutIndex)
        {
            string[] hh =(string[]) BasePath;
            for (int i = 0; i < hh.Length; i++)
            {
                var dd = Directory.GetDirectories(hh[i]);
                for (int j = 0; j < dd.Length; j++)
                {
                    printFileNames(dd[j], leftCutIndex);


                }
                return writePathFileNamesRecursion(dd, leftCutIndex);
            }
            return "";
        }
    }
}
    



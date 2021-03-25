using System;
using System.Collections;



namespace alg_dz7
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int rows = 10;
            int columns = 10;

            int[,] array = FillArray(rows, columns);
            CreateHazards(array);
            PrintArray(array);
            Console.WriteLine("Кол-во путей из верхней левой клетки в правую нижнюю с учетом препятствий равно:");
            Console.WriteLine(CountPathNum(array));     
            Console.ReadKey();

            /*
                1 1 1 1 1 1 1 1 1 1
                1 1 1 1 1 1 1 1 1 1
                1 1 1 1 1 1 1 1 1 1
                1 1 1 1 1 1 1 1 1 1
                1 1 1 1 0 1 1 1 1 0
                1 1 1 1 1 1 1 1 1 1
                1 1 1 1 1 1 1 1 1 1
                1 1 1 1 1 1 1 1 1 1
                1 1 1 1 1 1 1 1 1 1
                1 1 1 1 0 1 1 1 1 1
                Кол-во путей из верхней левой клетки в правую нижнюю с учетом препятствий равно:
                29690
             */
        }
        public static void PrintArray(int [,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)                
                    Console.Write($"{array[i, j]} ");
                
                Console.WriteLine();
            }
        }
        public static int [,]  FillArray(int x, int y)
        {
            int[,] fild = new int[x,y];
            FillArrayRec(fild, fild.GetLength(0)-1, fild.GetLength(1)-1);
            return fild;
        }
        public static void CreateHazards(in int [,] array)
        {
            int x = array.GetLength(0)-1;
            int y = array.GetLength(1)-1;
            array[x / 2, y / 2] = 0;
            array[x / 2, y] = 0;
            array[x, y / 2] = 0;
            
        }
        private static void FillArrayRec(int [,] fild,int x, int y)
        {
            if (x >= 0 && y >= 0)
            {
                fild[x, y] = 1;
                FillArrayRec(fild, x - 1, y);
                FillArrayRec(fild, x, y - 1);
            }
            
        }
        public static int CountPathNum(int[,] array)
        {
            return CountPathNumRec(array.GetLength(0)-1, array.GetLength(1)-1, array);
        }
        private static int CountPathNumRec(int x, int y, in int [,] array)
        {
            if (x == 0 && y == 0)            
                return 1;
            if (x < 0 || y < 0)            
                return 0;
            if (array[x,y] == 0)
                return 0;

            return CountPathNumRec(x - 1, y, array) + CountPathNumRec(x, y - 1, array);
        }
    }
}

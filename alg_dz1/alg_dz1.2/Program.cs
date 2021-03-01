using System;

namespace alg_dz1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добрый день! StrangeSum имеет асимптотическую сложность O(1 + N*N*N*4-N) или O(N^3)");
            
            Console.WriteLine(StrangeSum(new int []{1,2,3,4,5,6,7,8}));
            Console.ReadKey();

        }
        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0; // O(1)
            for (int i = 0; i < inputArray.Length; i++) // O(N)
            {
                for (int j = 0; j < inputArray.Length; j++) // O(N)
                {
                    for (int k = 0; k < inputArray.Length; k++) // O(N)
                    {
                        int y = 0; // O(1)

                        if (j != 0) // O(1)
                        {
                            y = k / j; // O(1)
                        }

                        sum += inputArray[i] + i + k + j + y; // O(1)
                    }
                }
            }

            return sum;
        }
    }
}

using System;
using System.Collections.Generic;
using BenchmarkDotNet.Running;

namespace alg_dz4
{
    public class Program
    {
        static void Main(string[] args)
        {
            // BenchmarkArrayTest
            if (false) 
            {
            BenchmarkRunner.Run<ArrayBenchmarkTest>();

            Console.ReadKey();
            /*
             * 
            | Method                | hs                    | val   | array         | Mean      | Error     | StdDev |

           Поиск внутри диапазона:
            | hsArrayCont           | Syste(...)nt32] [50] | 5000   |            ? | 14.166 ns  | 0.1403 ns | 0.1312 ns |  
            | normArrayIndOf        |                    ? | 5000   | Int32[10000] | 952.388 ns | 4.5984 ns | 4.3014 ns |
            | normArrayBinarySearch |                    ? | 5000   | Int32[10000] | 35.293 ns  | 0.1935 ns | 0.1810 ns |

           Поиск за рамками диапазона:
            | hsArrayCont           | Syste(...)nt32] [50] | 10001  |            ? | 8.257 ns   | 0.1060 ns | 0.0939 ns |
            | normArrayIndOf        |                    ? | 10001  | Int32[10000] | 3,640.429 ns | 71.0814 ns | 92.4259 ns |
            | normArrayBinarySearch |                    ? | 10001  | Int32[10000] | 37.798 ns  | 0.6786 ns | 0.8078 ns |
            */

            }
            // DrawBinaryTree
            if (true)
            {
                var r = new Random();
                var biTree = new BinaryTree();

                biTree.AddItem(20);
                for (int i = 0; i < 20; i++)
                {
                    biTree.AddItem(r.Next(1, 50));
                }
                biTree.AddItem(22);
                for (int i = 0; i < 20; i++)
                {
                    biTree.AddItem(r.Next(1, 50));
                }

                biTree.PrintTree();
                var node = biTree.GetNodeByValue(22);
                var root = biTree.GetRoot();

                Console.WriteLine("findnode:"+ node.Value);
                Console.WriteLine("root:"+ root.Value);

                while (true)
                {
                    Console.WriteLine("Какой нод удалить?:");
                    if (int.TryParse(Console.ReadLine(), out int res))
                    {
                        Console.WriteLine("-----------------");
                        biTree.RemoveItem(res);
                        biTree.PrintTree();
                    }
                }
                

                Console.ReadKey();

            }


        }
    }
}
    
    

using System;
using System.Collections;

namespace alg_dz5
{
    class Program
    {
        static void Main(string[] args)
        {
            var biTree = new BinaryTree();
                biTree.FillInTestData(BinaryTree.FillUpType.Normal);
            
            biTree.PrintTree();

            Console.WriteLine("Тестовый запрос -> 1:");
            Console.WriteLine("\n\nBFS_TreeLookUp:");
            Console.WriteLine("Ожидаемый результат  : --> 8 --> 4 --> 12 --> 2 --> 6 --> 10 --> 14 --> 1");
            Console.Write("Фактический результат:");
            BFS_TreeLookUp(biTree, 1);
            Console.WriteLine("\n\nDFS_TreeLookUp:");
            Console.WriteLine("Ожидаемый результат  : --> 8 --> 4 --> 2 --> 1");
            Console.Write("Фактический результат:");
            DFS_TreeLookUp(biTree, 1);         

            /*
             * └─(root)8
                  ├─(R)12
                  | ├─(R)14
                  | | ├─(R)15
                  | | └─(L)13
                  | └─(L)10
                  |   ├─(R)11
                  |   └─(L)9
                  └─(L)4
                    ├─(R)6
                    | ├─(R)7
                    | └─(L)5
                    └─(L)2
                      ├─(R)3
                      └─(L)1
                Тестовый запрос -> 1:


                BFS_TreeLookUp:
                Ожидаемый результат  : --> 8 --> 4 --> 12 --> 2 --> 6 --> 10 --> 14 --> 1
                Фактический результат: --> 8 --> 4 --> 12 --> 2 --> 6 --> 10 --> 14 --> 1
                Поиск завершен успешно: 1


                DFS_TreeLookUp:
                Ожидаемый результат  : --> 8 --> 4 --> 2 --> 1
                Фактический результат: --> 8 --> 4 --> 2 --> 1
                Поиск завершен успешно: 1
             */


            Console.WriteLine("\n\nКакой нод найти?:");
            if (int.TryParse(Console.ReadLine(), out int res))
            {
                Console.WriteLine("\n\nBFS_TreeLookUp:");
                BFS_TreeLookUp(biTree, res);

                Console.WriteLine("\n\nDFS_TreeLookUp:");
                DFS_TreeLookUp(biTree, res);
            }
        }

        static TreeNode BFS_TreeLookUp(BinaryTree binaryTree, int searchValue)
        {            
            var queue = new Queue();
            var node = binaryTree.GetRoot();
            queue.Enqueue(node);
            while (queue.Count>0)
            {
                node = (TreeNode)queue.Dequeue();
                Console.Write($" --> {node.Value}");
                if (node.Value == searchValue)
                {
                    Console.WriteLine($"\nПоиск завершен успешно: {node.Value}");
                    return node;
                }

                if (node.LeftChild != null)
                    queue.Enqueue(node.LeftChild);
                if (node.RightChild != null)
                    queue.Enqueue(node.RightChild);
            }
            Console.WriteLine("\nПоиск не дал результатов");
            return null;
        }

        static TreeNode DFS_TreeLookUp(BinaryTree binaryTree, int searchValue)
        {
            var stack = new Stack();
            var node = binaryTree.GetRoot();
            stack.Push(node);
            while (stack.Count > 0)
            {
                node = (TreeNode)stack.Pop();
                Console.Write($" --> {node.Value}");

                if (node.Value == searchValue)
                {
                    Console.WriteLine($"\nПоиск завершен успешно: {node.Value}");
                    return node;
                }

                if (node.RightChild != null)
                    stack.Push(node.RightChild);

                if (node.LeftChild != null)
                    stack.Push(node.LeftChild);
            }
            Console.WriteLine("\nПоиск не дал результатов");
            return null;
        }
    }
}

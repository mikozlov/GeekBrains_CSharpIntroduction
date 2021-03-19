using System;
using System.Collections;



namespace alg_dz6
{
    class Program

    {
        static void Main(string[] args)
        {

            Graph g = new Graph();


            g.AddVetex("A");// id 0
            g.AddVetex("B");// id 1
            g.AddVetex("C");// id 2
            g.AddVetex("D");// id 3
            g.AddVetex("E");// id 4
            g.AddVetex("F");// id 5
            g.AddVetex("G");// id 6
            g.AddVetex("H");// id 7
            g.AddVetex("I");// id 8
            g.AddVetex("K");// id 9


            g.AddEdge(0, 1);
            g.AddEdge(1, 2); g.AddEdge(1, 4); g.AddEdge(1, 5); g.AddEdge(1, 7); g.AddEdge(1, 8);
            g.AddEdge(2, 3);
            g.AddEdge(3, 6); g.AddEdge(3, 7); g.AddEdge(3, 9); g.AddEdge(3, 8);
            g.AddEdge(4, 5); g.AddEdge(4, 7); g.AddEdge(4, 9);
            g.AddEdge(5, 2);
            g.AddEdge(6, 1);
            g.AddEdge(7, 2);
            g.AddEdge(8, 4);

            // Ссылка на визуализацию: http://graphonline.ru/?graph=HNbJtWBYpVHodBVe


            g.Print();

            Console.Write("\n\nBFS_GrafLookUp:\n");
            Console.WriteLine("Ожидаемый порядок обхода: --> A(0) --> B(1) --> C(2) --> E(4) --> F(5) --> G(6) --> H(7) --> I(8) --> D(3) --> K(9) ");
            Console.Write("Результат выполнения: ");
            BFS_GrafLookUp(0, g);


            Console.Write("\n\nDFS_GrafLookUp:\n");
            Console.WriteLine("Ожидаемый порядок обхода: --> A(0) --> B(1) --> C(2) --> D(3) --> G(6) --> H(7) --> E(4) --> F(5) --> I(8) --> 9(K)");
            Console.Write("Результат выполнения: ");
            DFS_GrafLookUp(0, g);

            Console.WriteLine();
           
            /*
            Graf matrix:

            #|A|B|C|D|E|F|G|H|I|K|
            A | 0,1,0,0,0,0,0,0,0,0,
            B | 1,0,1,0,1,1,1,1,1,0,
            C | 0,1,0,1,0,1,0,1,0,0,
            D | 0,0,1,0,0,0,1,1,1,1,
            E | 0,1,0,0,0,1,0,1,1,1,
            F | 0,1,1,0,1,0,0,0,0,0,
            G | 0,1,0,1,0,0,0,0,0,0,
            H | 0,1,1,1,1,0,0,0,0,0,
            I | 0,1,0,1,1,0,0,0,0,0,
            K | 0,0,0,1,1,0,0,0,0,0,

            BFS_GrafLookUp:
            Ожидаемый порядок обхода: --> A(0)-- > B(1)-- > C(2)-- > E(4)-- > F(5)-- > G(6)-- > H(7)-- > I(8)-- > D(3)-- > K(9)
            Результат выполнения:  --> A(0)-- > B(1)-- > C(2)-- > E(4)-- > F(5)-- > G(6)-- > H(7)-- > I(8)-- > D(3)-- > K(9)

            DFS_GrafLookUp:
            Ожидаемый порядок обхода: --> A(0)-- > B(1)-- > C(2)-- > D(3)-- > G(6)-- > H(7)-- > E(4)-- > F(5)-- > I(8)-- > 9(K)
            Результат выполнения:  --> A(0)-- > B(1)-- > C(2)-- > D(3)-- > G(6)-- > H(7)-- > E(4)-- > F(5)-- > I(8)-- > K(9)
            */

        }

        static void BFS_GrafLookUp(int startIndex, Graph g)
        {
            bool[] isDone = new bool[g.matrix.GetLength(0)];

            var queue = new Queue();
            isDone[startIndex] = true;
            var node = startIndex;
            queue.Enqueue(node);
            while (queue.Count > 0)
            {
                node = (int)queue.Dequeue();
                Console.Write($" --> {g.vertices.Find(v => v.Id == node).Name}({node})");

                for (int i = 0; i < g.matrix.GetLength(0); i++)
                {
                    if (g.matrix[i, node] == 1 & isDone[i] == false)
                    {
                        queue.Enqueue(i);
                        isDone[i] = true;
                    }
                }
            }
        }
        public static bool[] isDone;

        static void DFS_GrafLookUp(int startIndex, Graph g)
        {
            isDone = new bool[g.matrix.GetLength(0)];
            DFS_ReqFunc(startIndex, g);
        }
        static void DFS_ReqFunc(int startIndex, Graph g)
        {            
            isDone[startIndex] = true;    
                Console.Write($" --> {g.vertices.Find(v => v.Id == startIndex).Name}({startIndex})");
                for (int i = 0; i < g.matrix.GetLength(0); i++)
                {
                    if (g.matrix[i, startIndex] == 1 & isDone[i] == false)
                    {
                        DFS_ReqFunc(i, g);        
                    }
                }

            

        }
    }
}

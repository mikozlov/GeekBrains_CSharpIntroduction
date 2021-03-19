
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace alg_dz6
{
    public class Graph
    {
        public int vertexNumber = 0;
        public int[,] matrix = new int[0, 0];
        public List<Vertex> vertices = new List<Vertex>();    

        public void AddEdge(int VertexNum1, int VertexNum2)
        {
            this.matrix[VertexNum1, VertexNum2] = 1;
            this.matrix[VertexNum2, VertexNum1] = 1;
        }
        public void DeleteEdge(int VertexNum1, int VertexNum2)
        {
            this.matrix[VertexNum1, VertexNum2] = 0;
            this.matrix[VertexNum2, VertexNum1] = 0;
        }
        public void AddVetex(string name, int value = 1)
        {
            
            vertices.Add(new Vertex() { Id = this.vertexNumber,Deleted = false,Name = name,Value = value});

            int[,] a = new int[this.matrix.GetLength(0) + 1, this.matrix.GetLength(0) + 1];            
            Array.Copy(this.matrix, a, this.matrix.Length);
            this.matrix = a;
            this.vertexNumber++;
        }

        public void Print()
        {
            Console.WriteLine("Graf matrix:");      

                for (int i = -1 ; i < this.vertices.Count; i++)
            {
                Console.WriteLine();
                for (int j = -1 ; j < this.matrix.GetLength(1); j++)
                {

                    if (i == -1 & j != -1)
                    {
                        Console.Write($"{vertices.Find(v => v.Id == j).Name}|");
                    }
                    else if(i == -1 & j == -1)
                    {
                        Console.Write("#|");
                    }
                    if (i != -1 & j == -1)
                    {
                        Console.Write($"{vertices.Find(v => v.Id == i).Name}|");
                    }
                    else if (i != -1 & j != -1)
                    {
                        if (this.matrix[i, j] == 1)
                        {
                            Console.Write($"1,");
                        }
                        else
                        {
                            Console.Write($"0,");
                        }
                    }
                }
            }
        }       
    }  
}

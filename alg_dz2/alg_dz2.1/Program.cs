﻿using System;

namespace alg_dz2
{
    public class Program
    {
        static void Main(string[] args)
        {
            TwoWayLinkedList list = new TwoWayLinkedList();

            for (int i = 1; i <= 30; i++)
            {
                list.AddNode(i);                
            }


            list.PrintList();

            list.AddNodeAfter(list.FindNode(20),200);

            list.PrintList();

            list.RemoveNode (list.FindNode(200));

            list.PrintList();

            list.RemoveNode(20);

            list.PrintList();

            Console.WriteLine(list.GetCount());

            Console.ReadKey();

        }

    }
    public class TwoWayLinkedList : ILinkedList
    {
        public Node FirstNode { get; set; } = null;
        public Node LastNode { get; set; } = null;

       public  void AddNode(int value)
        {         
            
            var newNode = new Node();
            newNode.Value = value;
            newNode.PrevNode = LastNode;            
            newNode.NextNode = null;
            if (LastNode != null)
                LastNode.NextNode = newNode;

        
 

            LastNode = newNode;

            if (FirstNode == null)
            {
                FirstNode = LastNode;
            } else if (FirstNode.NextNode == null)
            {
                FirstNode.NextNode = LastNode;
            }
            
        }

        public void AddNodeAfter(Node node, int value)
        {
 
            if (node != null)
            {
            var newNode = new Node();
            newNode.Value = value;
            newNode.PrevNode = node;
            newNode.NextNode = node.NextNode;
            node.NextNode = newNode;
            }

        }

        public Node FindNode(int searchValue)
        {
            if (FirstNode != null)
            {

                Node node = FirstNode;

                do
                {
                    if (node.Value == searchValue)
                        return node;

                    node = node.NextNode;

                } while (node != null);
            }

            return null;
        }

        public int GetCount()
        {
            int i = 0;
            if (FirstNode!=null)
            {
            Node node = FirstNode;

            do
            {
                i++;
                node = node.NextNode;

            } while (node != null);

                return i;
            }
            return 0;
        }

        public void RemoveNode(int index)
        {
            if (FirstNode == null)
            {
                return;
            }

            if (index == 0)
            {
                if (FirstNode.NextNode == null)
                    FirstNode = null;
                else
                {
                FirstNode = FirstNode.NextNode;
                FirstNode.PrevNode = null;
                }
                return;
            }
            else
            {
                int i = 0;
                Node node = FirstNode;
                do
                {
                    i++;
                    if (node.NextNode == null)
                        return;

                    node = node.NextNode;

                    if (i == index)
                    {
                        if (node != LastNode)
                        {
                            node.PrevNode.NextNode = node.NextNode;
                            node.NextNode.PrevNode = node.PrevNode;
                        }
                        else
                        {
                            node.PrevNode.NextNode = null;
                            LastNode = node.PrevNode;
                        }

                        return;
                    }


                } while (node != LastNode);                
            }

           
        }

        public void RemoveNode(Node node)
        {
            if (node == null)            
                return;
            
            if (FirstNode == node)
                if (FirstNode.NextNode == null)
                {
                    FirstNode = null;
                    LastNode = null;
                }
                else 
                {
                    FirstNode = node.NextNode;
                    FirstNode.PrevNode = null;
                }

                

            if (node.PrevNode != null)
                node.PrevNode.NextNode = node.NextNode;
            if (node.NextNode != null)
                node.NextNode.PrevNode = node.PrevNode;


            
        }
        public void PrintList()
        {
            int i = 0;
            Node node = FirstNode;

            Console.WriteLine("ILinkedList.PrintList:");
            do
            {
                Console.WriteLine("#{0} : {1}", i++, node.Value);                
                node = node.NextNode;

            } while (node != null);
            Console.WriteLine();
        }
    }
}

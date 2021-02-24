using System;

namespace alg_dz2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

    }
    public class TwoWayLinkedList : ILinkedList
    {
       public Node FirstNode { get; set; }
       public Node LastNode { get; set; }

        void ILinkedList.AddNode(int value)
        {
            if (FirstNode.Value == null)
            {
                FirstNode = new Node();
                LastNode = FirstNode;
            }

            var node = LastNode;

            node.Value = value;
            node.PrevNode = node.NextNode;
            node.NextNode = null;


        }

        void ILinkedList.AddNodeAfter(Node node, int value)
        {
            throw new NotImplementedException();
        }

        Node ILinkedList.FindNode(int searchValue)
        {
            throw new NotImplementedException();
        }

        int ILinkedList.GetCount()
        {
            throw new NotImplementedException();
        }

        void ILinkedList.RemoveNode(int index)
        {
            throw new NotImplementedException();
        }

        void ILinkedList.RemoveNode(Node node)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace alg_dz4
{
    public class TreeNode
    {
        public int Value { get; set; }
        public TreeNode LeftChild { get; set; }
        public TreeNode RightChild { get; set; }

        public override bool Equals(object obj)
        {
            var node = obj as TreeNode;

            if (node == null)
                return false;

            return node.Value == Value;
        }
        public void PrintPretty(string indent, bool last, string sing)
        {

            Console.Write(indent);
            if (last)
            {
                Console.Write("└─");
                indent += "  ";
            }

            else
            {
                Console.Write("├─");
                indent += "| ";
            }

            

                Console.WriteLine(sing + Value);



            var children = new List<(TreeNode,string)>();
            if (this.RightChild != null)
                children.Add((this.RightChild, "(R)"));
            if (this.LeftChild != null)
                children.Add((this.LeftChild, "(L)"));

            for (int i = 0; i < children.Count; i++)
                children[i].Item1.PrintPretty(indent, i == children.Count - 1, children[i].Item2);

        }
    }
}

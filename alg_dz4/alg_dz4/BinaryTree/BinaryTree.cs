using System;
using System.Collections.Generic;
using System.Text;

namespace alg_dz4
{
    public class BinaryTree : ITree
    {
        TreeNode RootNode { get; set; }
        
        public void AddItem(int value)
        {
            if (RootNode == null)
                RootNode = new TreeNode() { Value = value };
            else
                AddItemRec(RootNode, value);  
        }
        private void AddItemRec(TreeNode curentNode,  int value)
        {
            if (value == curentNode.Value)
            { return; }
            else if (value > curentNode.Value)
            {
                if (curentNode.RightChild == null)                
                    curentNode.RightChild =  new TreeNode() { Value = value };
                else
                    AddItemRec (curentNode.RightChild, value);
            }
            else if (value < curentNode.Value)
            {
                if (curentNode.LeftChild == null)
                    curentNode.LeftChild = new TreeNode() { Value = value };
                else
                    AddItemRec(curentNode.LeftChild, value);            
            }
        }
        public TreeNode GetNodeByValue(int value)
        {
            return GetNodeByValueWithParent(value, out TreeNode parent);
        }

        private TreeNode GetNodeByValueWithParent(int value, out TreeNode parent)
        {
            TreeNode head = RootNode;
            parent = null;
            while (head != null)
            {
                if (head.Value == value)
                {
                    break;
                }
                else if (head.Value < value)
                {
                    parent = head;
                    head = head.RightChild;
                }
                else if (head.Value > value)
                {
                    parent = head;
                    head = head.LeftChild;
                }
            }
            return head;
        }

        public TreeNode GetRoot()
        {
            return RootNode;
        }

        public void PrintTree()
        {
           var biTreeArray = TreeHelper.GetTreeInLine(this);


            RootNode.PrintPretty("", true,"(root)");

        }
 
        

        public void RemoveItem(int value)
        {
            TreeNode parent;
            TreeNode node = GetNodeByValueWithParent(value, out parent);

            // Case: node не найден
            if (node == null) 
            {
                return;
            }
            // Case: нет потомков
            if (node.RightChild == null & node.LeftChild == null) 
            {
                // Case: нет потомков, node - корень
                if (parent == null)
                    RootNode = null;
                // Case: нет потомков, node - НЕкорень
                else
                {
                    if (parent.Value > node.Value) // node - leftChild
                        parent.LeftChild = null;
                    if (parent.Value < node.Value) // node - rihtChild
                        parent.RightChild = null;
                }
                return;
            }

            // Case: нет потомка справа
            if (node.RightChild == null)
            {
                // Case: нет потомка справа, node корень
                if (parent == null)
                    RootNode = node.LeftChild;
                // Case: нет потомка справа, node- НЕкорень
                else
                {
                    if (parent.Value > node.Value) // node - leftChild
                        parent.LeftChild = node.LeftChild;
                    if (parent.Value < node.Value) // node - rihtChild
                        parent.RightChild = node.LeftChild;
                }
                return;
            }
            // Case: нет потомка слева
            if (node.LeftChild == null)
            {
                // Case: нет потомка слева, node - корень
                if (parent == null)
                    RootNode = node.RightChild;
                // Case: нет потомка слева, node - НЕкорень
                else
                {
                    if (parent.Value > node.Value) // node - leftChild
                        parent.LeftChild = node.RightChild;
                    if (parent.Value < node.Value) // node - rihtChild
                        parent.RightChild = node.RightChild;
                }
                return;
            }
            // Case: есть два потомка, поиск самого левого от правого
            if (node.RightChild != null & node.LeftChild != null)
            {
                    TreeNode currentNode = node.RightChild;
                    TreeNode parentNode = node;
                    while (currentNode.LeftChild != null)
                    {
                        parentNode = currentNode;
                        currentNode = parentNode.LeftChild;
                    }
                    node.Value = currentNode.Value;
                    if (currentNode.RightChild != null)
                    {
                        parentNode.LeftChild = currentNode.RightChild;
                    }
                    else
                    {
                        parentNode.LeftChild = null;
                    }
                    node.Value = currentNode.Value;
                
            }






        }
    }




}



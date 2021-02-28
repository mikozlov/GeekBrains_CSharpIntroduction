using Microsoft.VisualStudio.TestTools.UnitTesting;
using alg_dz2;
using System;
using System.Collections.Generic;
using System.Text;

namespace alg_dz2.Tests
{
    [TestClass()]
    public class TwoWayLinkedListTests
    {
        [TestMethod()]
        public void AddNodeTest()
        {
            var list = new TwoWayLinkedList();

            list.AddNode(1);
            Assert.AreEqual(list.LastNode, list.FirstNode);
            Assert.AreEqual(1, list.LastNode.Value);
            

            list.AddNode(2);
            Assert.AreEqual(list.LastNode, list.FirstNode.NextNode);
            Assert.AreEqual(null, list.FirstNode.PrevNode);
            Assert.AreEqual(null, list.LastNode.NextNode);
            Assert.AreEqual(2, list.LastNode.Value);
            Assert.AreEqual(1, list.FirstNode.Value);

            list.AddNode(3);
            Assert.AreEqual(2, list.FirstNode.NextNode.Value);
            Assert.AreEqual(list.FirstNode, list.FirstNode.NextNode.PrevNode);
            Assert.AreEqual(list.LastNode, list.FirstNode.NextNode.NextNode);
            Assert.AreEqual(null, list.FirstNode.PrevNode);
            Assert.AreEqual(null, list.LastNode.NextNode);
            Assert.AreEqual(3, list.LastNode.Value);
            Assert.AreEqual(1, list.FirstNode.Value);




        }

        [TestMethod()]
        public void AddNodeAfterTest()
        {
            var list = new TwoWayLinkedList();

            for (int i = 1; i <= 10; i++)
            {
                list.AddNode(i);
            }
            list.AddNodeAfter(list.FirstNode, 1111);
            Assert.AreEqual(1111, list.FirstNode.NextNode.Value);
            Assert.AreEqual(list.FirstNode, list.FirstNode.NextNode.PrevNode);
            Assert.AreEqual(1, list.FirstNode.Value);

        }

        [TestMethod()]
        public void FindNodeTest()
        {
            var list1 = new TwoWayLinkedList();

            for (int i = 1; i <= 10; i++)
            {
                list1.AddNode(i);
            }

            Assert.AreEqual(list1.LastNode.PrevNode,list1.FindNode(9));

            var list2 = new TwoWayLinkedList();

            for (int i = 1; i <= 1; i++)
            {
                list2.AddNode(i);
            }

            Assert.AreEqual(list2.FirstNode, list2.FindNode(1));

            var list3 = new TwoWayLinkedList();

            for (int i = 1; i <= 0; i++)
            {
                list3.AddNode(i);
            }

            Assert.AreEqual(null, list3.FindNode(9));
        }

        [TestMethod()]
        public void GetCountTest()
        {
            var list1 = new TwoWayLinkedList();
            for (int i = 1; i <= 10; i++)
            {
                list1.AddNode(i);
            }
            Assert.AreEqual(10, list1.GetCount());

            var list2 = new TwoWayLinkedList();
            for (int i = 1; i <= 1; i++)
            {
                list2.AddNode(i);
            }
            Assert.AreEqual(1, list2.GetCount());

            var list3 = new TwoWayLinkedList();
            for (int i = 1; i <= 0; i++)
            {
                list3.AddNode(i);
            }
            Assert.AreEqual(0, list3.GetCount());
        }

        [TestMethod()]
        public void RemoveNodeTest_Index()
        {
            var list = new TwoWayLinkedList();
            for (int i = 1; i <= 10; i++)
            {
                list.AddNode(i);
            }
            list.RemoveNode(9);
            Assert.AreEqual(9, list.LastNode.Value);
            list.RemoveNode(0);
            Assert.AreEqual(2, list.FirstNode.Value);
            list.RemoveNode(2);
            Assert.AreEqual(3, list.FirstNode.NextNode.Value);
            Assert.AreEqual(5, list.FirstNode.NextNode.NextNode.Value);
        }

        [TestMethod()]
        public void RemoveNodeTest_Index_ShortList()
        {
            var list = new TwoWayLinkedList();
            for (int i = 1; i <= 1; i++)
            {
                list.AddNode(i);
            }
            list.RemoveNode(0);
            Assert.AreEqual(0, list.GetCount());

            var list1 = new TwoWayLinkedList();
            for (int i = 1; i <= 0; i++)
            {
                list.AddNode(i);
            }
            list.RemoveNode(0);
            Assert.AreEqual(0, list.GetCount());

            var list2 = new TwoWayLinkedList();
            for (int i = 1; i <= 0; i++)
            {
                list2.AddNode(i);
            }
            list2.RemoveNode(999);
            Assert.AreEqual(0, list2.GetCount());



        }

        [TestMethod()]
        public void RemoveNodeTest_Node_ShortList()
        {
            var list = new TwoWayLinkedList();
            for (int i = 1; i <= 1; i++)
            {
                list.AddNode(i);
            }
            list.RemoveNode(list.FirstNode);
            Assert.AreEqual(0, list.GetCount());

            var list4 = new TwoWayLinkedList();
            for (int i = 1; i <= 1; i++)
            {
                list4.AddNode(i);
            }
            list4.RemoveNode(list4.LastNode);
            Assert.AreEqual(0, list.GetCount());



            var list1 = new TwoWayLinkedList();
            for (int i = 1; i <= 0; i++)
            {
                list.AddNode(i);
            }
            list.RemoveNode(list1.FirstNode);
            Assert.AreEqual(null, list1.FirstNode);


            var list3 = new TwoWayLinkedList();
            for (int i = 1; i <= 10; i++)
            {
                list3.AddNode(i);
            }
            list3.RemoveNode(new Node());

   

        }


    }
}
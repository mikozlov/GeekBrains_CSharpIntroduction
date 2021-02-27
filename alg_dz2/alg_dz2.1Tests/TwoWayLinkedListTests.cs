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
            Assert.AreEqual(2, list.FirstNode.NextNode.NextNode.Value);

        }

        [TestMethod()]
        public void FindNodeTest()
        {
            var list = new TwoWayLinkedList();

            for (int i = 1; i <= 10; i++)
            {
                list.AddNode(i);
            }

            Assert.AreEqual(list.LastNode.PrevNode,list.FindNode(9));
        }

        [TestMethod()]
        public void GetCountTest()
        {
            var list = new TwoWayLinkedList();
            for (int i = 1; i <= 10; i++)
            {
                list.AddNode(i);
            }
            Assert.AreEqual(10, list.GetCount());
        }

        [TestMethod()]
        public void RemoveNodeTest()
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
        public void RemoveNodeTest1()
        {
            var list = new TwoWayLinkedList();
            for (int i = 1; i <= 10; i++)
            {
                list.AddNode(i);
            }
            list.RemoveNode(list.FirstNode);
            Assert.AreEqual(2, list.FirstNode.Value);
            list.RemoveNode(list.LastNode);
            Assert.AreEqual(9, list.LastNode.Value);
            list.RemoveNode(list.FirstNode.NextNode.NextNode);
            Assert.AreEqual(3, list.FirstNode.NextNode.Value);
            Assert.AreEqual(5, list.FirstNode.NextNode.NextNode.Value);
        }


    }
}
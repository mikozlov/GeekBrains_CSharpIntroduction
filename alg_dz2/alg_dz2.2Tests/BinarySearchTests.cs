using Microsoft.VisualStudio.TestTools.UnitTesting;
using alg_dz2._2;
using System;
using System.Collections.Generic;
using System.Text;

namespace alg_dz2._2.Tests
{
    [TestClass()]
    public class BinarySearchTests
    {
        [TestMethod()]
        public void SearchTest()
        {

            string[] array = { "Первый", "Второй", "3", "4-ый", "5ятый", "Шшшшшш", "Ссссс", "8888888", "9 девятый, nine, neun", "10 последний" };


            Assert.AreEqual(0, BinarySearch.Search(array, "Первый"));
            Assert.AreEqual(9, BinarySearch.Search(array, "10 последний"));
            Assert.AreEqual(2, BinarySearch.Search(array, "3"));
            Assert.AreEqual(-1, BinarySearch.Search(array, "3 4435364"));
        }
    }
}
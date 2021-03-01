using alg_dz1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace alg_dz1.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void TestPrimeOrNotTest()
        {
            (string, int)[] numCase = 
                { 
                ("Простое", 2), 
                ("Простое", 3),
                ("Простое", 5),
                ("Простое", 7),
                ("Простое", 11),
                ("Простое", 13),
                ("Простое", 17),
                ("Простое", 19),
                ("Простое", 23),
                ("Простое", 29),
                ("Простое", 31),
                ("Простое", 37),
                ("Простое", 97),
                ("Не простое", 4),
                ("Не простое", 6),
                ("Не простое", 8),
                ("Не простое", 9),
                ("Не простое", 10),
                ("Не простое", 30),
                ("Не простое", 58),
                ("Не простое", 69),
                ("Не простое", 88),
                ("Не простое", 76)
            } ;
            foreach (var i in numCase)
            {
                Assert.AreEqual(i.Item1, Program.TestPrimeOrNot(i.Item2));
            }
            Assert.AreNotEqual("Простое", Program.TestPrimeOrNot(10));
        }
    }
}
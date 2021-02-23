using Microsoft.VisualStudio.TestTools.UnitTesting;
using alg_dz1._3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alg_dz1._3.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void getFibonachiTest()
        {
            (int, ulong) [] testArray = 
                {
                ( 0, 0 ),
                ( 1, 1 ),
                ( 2, 1 ),
                ( 3, 2 ),
                ( 4, 3 ),
                ( 5, 5 ),
                ( 6, 8 ),
                ( 7, 13 ),
                ( 8, 21 ),
                ( 9, 34 ),
                ( 10, 55 ),

                };
            foreach (var num in testArray)
            {
              

                ulong f1 = Program.getFibonachi2(num.Item1);
                ulong f2 = Program.getFibonachi3(num.Item1);
                ulong f3 = Program.getFibonachi4((ulong)num.Item1);


                Program.i = 0;
                ulong fibonachi1 = 0;
                ulong fibonachi2 = 1;
                ulong fibonachi3 = 1;
                ulong f4 = Program.getFibonachi1(ref fibonachi3, ref fibonachi1, ref fibonachi2, num.Item1);


                Assert.IsTrue(f1 == f2 & f1 == f3 & f1 == f4);
                Assert.AreEqual(f1, num.Item2);
            }

        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace alg_dz4
{
    public class ArrayBenchmarkTest
    {



        public IEnumerable<object[]> TestArray()
        {
            int index = 10000;
            Random r = new Random();
            int[] testArray = new int[index];
            for (int i = 0; i < index; i++)
            {
                testArray[i] = r.Next(1, index);
            }
            yield return new object[] { testArray, index + 1 };
            testArray[r.Next(1, index)] = index / 2;
            yield return new object[] { testArray, index / 2 };

        }
        public IEnumerable<object[]> TestHsArray()
        {
            int index = 10000;
            Random r = new Random();
            HashSet<int> testArray = new HashSet<int>();
            
            
            for (int i = 0; i < index; i++)
            {               
                testArray.Add(r.Next(1, index));
            }
            yield return new object[] { testArray, index + 1 };
            testArray.Add(index / 2);
            yield return new object[] { testArray, index / 2 };
        }

        [Benchmark]
        [ArgumentsSource(nameof(TestHsArray))]
        public void hsArrayCont(HashSet<int> hs, int val)
        {
            hs.Contains(val);
        }

        [Benchmark]
        [ArgumentsSource(nameof(TestArray))]

        public void normArrayIndOf(int[] array, int val)
        {
            Array.IndexOf<int>(array, val);
        }
        [Benchmark]
        [ArgumentsSource(nameof(TestArray))]

        public void normArrayBinarySearch(int[] array, int val)
        {
            Array.BinarySearch(array, val);
        }
    }
}

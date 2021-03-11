using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace alg_dz3
{
    public class Program
    {
        static void Main(string[] args)
        {
                 
            BenchmarkRunner.Run<Distance>();          
            Console.ReadKey();

            /*
                                     Результат выполнения на моем ПК (рандом)
                        |                        Method |                  p1 |                  p2 |       Mean |     Error |    StdDev |
                        |------------------------------ |-------------------- |-------------------- |-----------:|----------:|----------:|
                        |       GetDistanceStructDouble | 20486,186;13245,141 | 40722,656;38201,742 | 10.5853 ns | 0.1796 ns | 0.1680 ns |
                        |        GetDistanceStructFloat |  29309,418;44527,38 |  34799,715;39838,47 |  9.3134 ns | 0.0740 ns | 0.0692 ns |
                        |         GetDistanceClassFloat | 40993,316;36158,457 |  38038,32;45040,348 |  0.3284 ns | 0.0434 ns | 0.0446 ns |
                        | GetDistanceStructFloat_noSqrt | 43766,215;27556,936 | 32999,906;32324,152 |  5.6919 ns | 0.1319 ns | 0.1169 ns |

                                Результат выполнения на моем ПК (сопоставимы данные1)

                        |                        Method |                  p1 |                p2 |       Mean |     Error |    StdDev |
                        |------------------------------ |-------------------- |------------------ |-----------:|----------:|----------:|
                        |         GetDistanceClassFloat |               0;100 |          100;3000 |  0.1781 ns | 0.0198 ns | 0.0165 ns |
                        |        GetDistanceStructFloat |               0;100 |          100;3000 |  9.4098 ns | 0.1886 ns | 0.1764 ns |
                        |       GetDistanceStructDouble |               0;100 |          100;3000 | 10.5867 ns | 0.0882 ns | 0.0782 ns |
                        | GetDistanceStructFloat_noSqrt |               0;100 |          100;3000 |  5.4262 ns | 0.1208 ns | 0.1130 ns |
                        |         GetDistanceClassFloat | 204867760;132766744 | 40675724;38207660 |  0.1326 ns | 0.0215 ns | 0.0201 ns |
                        |        GetDistanceStructFloat | 204867760;132766744 | 40675724;38207660 |  9.3320 ns | 0.1701 ns | 0.1508 ns |
                        |       GetDistanceStructDouble | 204867760;132766744 | 40675724;38207660 | 10.4675 ns | 0.0694 ns | 0.0615 ns |
                        | GetDistanceStructFloat_noSqrt | 204867760;132766744 | 40675724;38207660 |  5.6568 ns | 0.1409 ns | 0.1318 ns |

                                Результат выполнения на моем ПК (сопоставимы данные)
                        |                        Method |                  p1 |                  p2 |       Mean |     Error |    StdDev |
                        |------------------------------ |-------------------- |-------------------- |-----------:|----------:|----------:|
                        |         GetDistanceClassFloat |               0;100 |            100;3000 |  0.1483 ns | 0.0129 ns | 0.0115 ns |
                        |        GetDistanceStructFloat |               0;100 |            100;3000 |  9.3089 ns | 0.0809 ns | 0.0675 ns |
                        |       GetDistanceStructDouble |               0;100 |            100;3000 | 10.5486 ns | 0.0724 ns | 0.0642 ns |
                        | GetDistanceStructFloat_noSqrt |               0;100 |            100;3000 |  5.6292 ns | 0.0632 ns | 0.0591 ns |
                        |         GetDistanceClassFloat | 2048677,6;1327667,5 | 406757,22;382076,62 |  0.1981 ns | 0.0105 ns | 0.0082 ns |
                        |        GetDistanceStructFloat | 2048677,6;1327667,5 | 406757,22;382076,62 |  9.2143 ns | 0.0825 ns | 0.0732 ns |
                        |       GetDistanceStructDouble | 2048677,6;1327667,5 | 406757,22;382076,62 | 10.6213 ns | 0.0795 ns | 0.0744 ns |
                        | GetDistanceStructFloat_noSqrt | 2048677,6;1327667,5 | 406757,22;382076,62 |  5.5867 ns | 0.0813 ns | 0.0721 ns |

             */
        }




        public class PoinClass
        {
            public float X { get; set; }
            public float Y { get; set; }

            public PoinClass()
            {
                Random rnd = new Random();
                X = MathF.Sqrt(rnd.Next());
                Y = MathF.Sqrt(rnd.Next());
            }
            public override string ToString() => $"{X};{Y}";
            public PoinClass(float x, float y)
            {                
                X = x;
                Y = y;
            }

        }
        public struct PoinStruct
        {
            public float X { get; set; }
            public float Y { get; set; }
            public PoinStruct(bool flag)
            {
                Random rnd = new Random();
                X = MathF.Sqrt(rnd.Next());
                Y = MathF.Sqrt(rnd.Next());
            }
            public PoinStruct(float x, float y)
            {
                X = x;
                Y = y;
            }
            public override string ToString() => $"{X};{Y}";

        }


        public class Distance
        {
            public IEnumerable<float[]> Points()
            {
                /*
                Random rnd = new Random();
                for (int i = 0; i < 1; i++)
                {                
           
                    yield return new float[] {MathF.Sqrt(rnd.Next()), MathF.Sqrt(rnd.Next()), MathF.Sqrt(rnd.Next()), MathF.Sqrt(rnd.Next()) };
                }
                */
                yield return new float[] { 0,100,100,3000 };
                yield return new float[] { 204867766.186E-2f , 132766745.141E-2f, 40675722.656E-2f, 38207661.742E-2f };
                



            }
            public IEnumerable<object[]> Points_PointClass()
            {
                foreach (var item in Points())
                {
                    yield return new object[]{new PoinClass(item[0], item[1]), new PoinClass(item[2], item[3]) };
                }

                
            }
            public IEnumerable<object[]> Points_PointStruct()
            {
                foreach (var item in Points())
                {
                    yield return new object[] { new PoinStruct(item[0], item[1]), new PoinStruct(item[2], item[3]) };
                }

            }

            [Benchmark]
            [ArgumentsSource(nameof (Points_PointClass))]
            public float GetDistanceClassFloat(PoinClass p1, PoinClass p2)
            {
                float x = p1.X - p2.X;
                float y = p1.Y - p2.Y;
                return MathF.Sqrt((x * x) + (y * y));
            }

            [Benchmark]
            [ArgumentsSource(nameof(Points_PointStruct))]
            public  float GetDistanceStructFloat(PoinStruct p1, PoinStruct p2)
            {
                float x = p1.X - p2.X;
                float y = p1.Y - p2.Y;
                return MathF.Sqrt((x * x) + (y * y));
            }
            [Benchmark]
            [ArgumentsSource(nameof(Points_PointStruct))]
            public  Double GetDistanceStructDouble(PoinStruct p1, PoinStruct p2)
            {
                float x = p1.X - p2.X;
                float y = p1.Y - p2.Y;
                return MathF.Sqrt((x * x) + (y * y));
            }
            [Benchmark]
            [ArgumentsSource(nameof(Points_PointStruct))]
            public  float GetDistanceStructFloat_noSqrt(PoinStruct p1, PoinStruct p2)
            {
                float x = p1.X - p2.X;
                float y = p1.Y - p2.Y;
                return (x * x) + (y * y);

            }

        }
    }
}

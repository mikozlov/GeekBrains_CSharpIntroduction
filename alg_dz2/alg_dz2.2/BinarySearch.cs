using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

namespace alg_dz2._2
{
    public class BinarySearch
    {
        public static int Search(Object[] array, Object val)
        {
            
            (int, int) [] intArray =  Sort(ConvertToHex(array));
            int intVal = val.GetHashCode();


            int left = 0;
            int right = array.Length;
            int mid = 0;

            while (!(left >= right))
            {
                mid = left + (right - left) / 2;

                if (intArray[mid].Item1 == intVal)
                    return intArray[mid].Item2;

                if ((intArray[mid].Item1 > intVal))
                    right = mid;
                else
                    left = mid + 1;
            }

            return -1;
        }


        private static (int, int)[] Sort((int, int)[] intArray)
        {
            //Array.Sort(intArray);
            (int, int) temp;
            for (int i = 0; i < intArray.Length - 1; i++)
            {
                for (int j = i + 1; j < intArray.Length; j++)
                {
                    if (intArray[i].Item1 > intArray[j].Item1)
                    {
                        temp = intArray[i];
                        intArray[i] = intArray[j];
                        intArray[j] = temp;
                    }
                }
            }
            
            return intArray;

        }
        private static (int, int)[] ConvertToHex(Object [] array)
        {
            
            var intArray = new (int, int)[array.Length];
            

            for (int i = 0; i < array.Length; i++)
                intArray[i] = (array[i].GetHashCode(), i);   

            return intArray;
        }




    }
}

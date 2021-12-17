using System;
using System.Linq;

namespace Tests
{
    public static class ArrayExtensions
    {
        public static string Print<T>(this T[] arr)
        {
            return $"[{String.Join(',', arr)}]";
        }

        public static int[][] ToTwoDimentionArray(this string str)
        {            
            var strRows = str.Split("],");
            var array = new int[strRows.Length][];
            for(int i=0; i<array.Length; i++)
            {
                array[i] = strRows[i].Split(",").Select(s => int.Parse(s.Trim('[',']'))).ToArray();
            }

            return array;
        }
    }
}
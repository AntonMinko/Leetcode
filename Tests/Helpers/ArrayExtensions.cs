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
    }
}
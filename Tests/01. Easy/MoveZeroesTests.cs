using System;
using Solutions;
using Xunit;

namespace Tests
{
    public class MoveZeroesTests
    {
        [Theory]
        [InlineData(new int[] {})]
        [InlineData(new int[] {0})]
        [InlineData(new int[] {-1})]
        [InlineData(new int[] {0,1})]
        [InlineData(new int[] {1,0})]
        [InlineData(new int[] {0,1,0,2,0,3,0})]
        [InlineData(new int[] {0,1,0,3,12})]
        public void Test1(int[] nums)
        {
            new MoveZeroesSolution().MoveZeroes(nums);
            AssertAllZeroesInTheEnd(nums);
        }

        private void AssertAllZeroesInTheEnd(int[] nums)
        {
            bool foundZero = false;
            for(int i=0; i<nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    foundZero = true;
                }
                if (nums[i]!= 0 && foundZero)
                {
                    throw new Exception("Array is not ordered");
                }
            }
        }
    }
}
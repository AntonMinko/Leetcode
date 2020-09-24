using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using System.Diagnostics;
using FluentAssertions;

namespace Tests
{
    public class MedianOfTwoSortedArraysTests
    {
        private readonly ITestOutputHelper output;

        public MedianOfTwoSortedArraysTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [InlineData(new int[] { 1, 3 }, new int[] {2}, 2)]
        [InlineData(new int[] { 1, 2 }, new int[] { 3, 4 }, 2.5)]
        [InlineData(new int[] { 0, 0 }, new int[] { 0, 0 }, 0)]
        [InlineData(new int[] {}, new int[] { 1 }, 1)]
        [InlineData(new int[] { 2 }, new int[] {}, 2)]
        [InlineData(new int[] { 3, 3 }, new int[] { 2, 2 }, 2.5)]
        [InlineData(new int[] { 5, 6, 7 }, new int[] { 1, 2, 3, 4 }, 4)]
        [InlineData(new int[] { 1, 3 }, new int[] { 5, 7, 9 }, 5)]
        public void DataDrivenTest(int[] nums1, int[] nums2, int expectedMedian)
        {
            var sut = new MedianOfTwoSortedArrays();

            double median = sut.FindMedianSortedArrays(nums1, nums2);
        }
    }
}
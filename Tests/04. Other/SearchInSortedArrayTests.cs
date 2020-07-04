using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using System.Diagnostics;
using FluentAssertions;

namespace Tests
{
    public class SearchInSortedArrayTests
    {
        private readonly ITestOutputHelper output;

        public SearchInSortedArrayTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void TestName()
        {
            //Given

            //When

            //Then
        }

        [Theory]
        [InlineData(new int[] { }, 1, -1)]
        [InlineData(new int[] { 0 }, 1, -1)]
        [InlineData(new int[] { 1 }, 1, 0)]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 0, -1)]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5, 6, 7 }, 4, 4)]
        [InlineData(new int[] { 0, 1, 2, 3, 5, 6, 7 }, 10, -1)]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5, 6, 7 }, 1, 1)]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5, 6, 7 }, 0, 0)]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5, 6, 7 }, 7, 7)]
        public void DataDrivenTest(int[] nums, int target, int expectedIndex)
        {
            var sut = new SearchInSortedArray();
            int index = sut.Search(nums, target);

            index.Should().Be(expectedIndex, nums.Print());
        }
    }
}
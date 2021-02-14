using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using System.Diagnostics;
using FluentAssertions;

namespace Tests
{
    public class MinimumInSortedRotatedArrayIITests : BaseTests
    {
        public MinimumInSortedRotatedArrayIITests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void TestName()
        {
            //Given

            //When

            //Then
        }

        [Theory]
        [InlineData(1, new int[] { 1, 2 }, 1)]
        [InlineData(2, new int[] { 2, 1 }, 1)]
        [InlineData(3, new int[] { 2 }, 2)]
        [InlineData(4, new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0)]
        [InlineData(5, new int[] { 3, 4, 5, 1, 2 }, 1)]
        [InlineData(6, new int[] { 11, 13, 15, 17 }, 11)]
        [InlineData(7, new int[] { 11, 13, 15, 17, 9 }, 9)]
        [InlineData(8, new int[] { 4, 5, 6, 0, 1, 2 }, 0)]
        [InlineData(9, new int[] { 1, 1 }, 1)]
        [InlineData(10, new int[] { 3, 1, 3 }, 1)]
        [InlineData(11, new int[] { 1, 3, 1 }, 1)]
        [InlineData(12, new int[] { 1, 3, 3, 3, 3, 3, 3, 3 }, 1)]
        [InlineData(13, new int[] { 3, 3, 3, 3, 3, 3, 3, 1 }, 1)]
        [InlineData(14, new int[] { 3, 3, 3, 1, 3, 3, 3, 3 }, 1)]
        [InlineData(15, new int[] { 2, 2, 3, 3, 1, 1, 2, 2 }, 1)]
        [InlineData(16, new int[] { 0, 0, 1, 1, 2, 0 }, 0)]
        public void DataDrivenTest(int testId, int[] nums, int expected)
        {
            var sut = new MinimumInSortedRotatedArrayII();
            int actual = MeasureAndExecute(testId, () => sut.FindMin(nums));

            actual.Should().Be(expected);
        }
    }
}
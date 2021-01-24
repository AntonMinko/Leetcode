using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using FluentAssertions;
using Solutions.DynamicProgramming;

namespace Tests
{
    public class BestSumMemoizationTests : BaseTests
    {
        public BestSumMemoizationTests(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData(1, 7, new int[] { 5, 3, 4, 7 }, new int[] { 7 })]
        [InlineData(2, 7, new int[] { 5, 6, 3 }, null)]
        [InlineData(3, 8, new int[] { 2, 3, 5 }, new int[] { 5, 3 })]
        [InlineData(4, 8, new int[] { 1, 4, 5 }, new int[] { 4, 4 })]
        [InlineData(5, 100, new int[] { 1, 2, 3, 4, 5, 25 }, new int[] { 25, 25, 25, 25 })]
        public void DataDrivenTest(int testId, int target, int[] nums, int[] expectedResult)
        {
            var sut = new BestSumMemoization();
            var actual = MeasureAndExecute(testId, () => sut.BestSum(target, nums));

            actual.Should().BeEquivalentTo(expectedResult);
        }
    }
}
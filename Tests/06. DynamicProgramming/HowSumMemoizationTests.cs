using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using FluentAssertions;
using Solutions.DynamicProgramming;

namespace Tests
{
    public class HowSumMemoizationTests : BaseTests
    {
        public HowSumMemoizationTests(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData(1, 7, new int[] { 2, 3 }, new int[] { 3, 2, 2 })]
        [InlineData(2, 7, new int[] { 5, 3, 4, 7 }, new int[] { 4, 3 })]
        [InlineData(3, 7, new int[] { 2, 4 }, null)]
        [InlineData(4, 8, new int[] { 2, 3, 5 }, new int[] { 2, 2, 2, 2 })]
        [InlineData(5, 300, new int[] { 7, 14 }, null)]
        public void DataDrivenTest(int testId, int target, int[] nums, int[] expectedResult)
        {
            var sut = new HowSumMemoization();
            var actual = MeasureAndExecute(testId, () => sut.HowSum(target, nums));

            actual.Should().BeEquivalentTo(expectedResult);
        }
    }
}
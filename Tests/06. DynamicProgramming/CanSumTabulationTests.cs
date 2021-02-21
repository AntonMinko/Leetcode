using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using FluentAssertions;
using Solutions.DynamicProgramming;

namespace Tests
{
    public class CanSumTabulationTests : BaseTests
    {
        public CanSumTabulationTests(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData(1, 7, new int[] { 2, 3 }, true)]
        [InlineData(2, 7, new int[] { 5, 3, 4, 7 }, true)]
        [InlineData(3, 7, new int[] { 2, 4 }, false)]
        [InlineData(4, 8, new int[] { 2, 3, 5 }, true)]
        [InlineData(5, 300, new int[] { 7, 14 }, false)]
        public void DataDrivenTest(int testId, int target, int[] nums, bool expectedresult)
        {
            var sut = new CanSumTabulation();
            bool actual = MeasureAndExecute(testId, () => sut.CanSum(target, nums));

            actual.Should().Be(expectedresult);
        }
    }
}
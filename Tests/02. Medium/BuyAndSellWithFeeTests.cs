using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using System.Diagnostics;
using FluentAssertions;

namespace Tests
{
    public class BuyAndSellWithFeeTests : BaseTests
    {
        public BuyAndSellWithFeeTests(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData(1, new int[] { 5 }, 1, 0)]
        [InlineData(2, new int[] { 1, 3 }, 2, 0)]
        [InlineData(3, new int[] { 1, 4 }, 2, 1)]
        [InlineData(4, new int[] { 4, 1 }, 1, 0)]
        [InlineData(5, new int[] { 1, 3, 7, 5, 10, 3 }, 3, 6)]
        [InlineData(6, new int[] { 1, 3, 2, 8, 4, 9 }, 2, 8)]
        public void DataDrivenTest(int testId, int[] prices, int fee, int expected)
        {
            var sut = new BuyAndSellWithFee();
            var actual = MeasureAndExecute(testId, () => sut.MaxProfit(prices, fee));

            actual.Should().Be(expected);
        }
    }
}
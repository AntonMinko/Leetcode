using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using System.Diagnostics;
using FluentAssertions;

namespace Tests
{
    public class CoinChangeTests : BaseTests
    {
        public CoinChangeTests(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData(1, new int[] { 1, 2, 5 }, 11, 3)]
        [InlineData(2, new int[] { 2 }, 3, -1)]
        [InlineData(3, new int[] { 1 }, 0, 0)]
        [InlineData(4, new int[] { 1 }, 1, 1)]
        [InlineData(5, new int[] { 1 }, 2, 2)]
        [InlineData(6, new int[] { 1, 6, 10 }, 12, 2)]
        public void DataDrivenTest(int testId, int[] coins, int amount, int expected)
        {
            var sut = new CoinChange();
            int actual = MeasureAndExecute(testId, () => sut.GetCoinChange(coins, amount));

            actual.Should().Be(expected);
        }
    }
}
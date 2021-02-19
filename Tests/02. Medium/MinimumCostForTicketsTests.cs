using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using System.Diagnostics;
using FluentAssertions;

namespace Tests
{
    public class MinimumCostForTicketsTests : BaseTests
    {
        public MinimumCostForTicketsTests(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData(1, new int[] { 1, 4, 6, 7, 8, 20 }, new int[] { 2, 7, 15 }, 11)]
        [InlineData(2, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 30, 31 }, new int[] { 2, 7, 15 }, 17)]
        [InlineData(3, new int[] { 1, 4 }, new int[] { 2, 7, 15 }, 4)]
        [InlineData(4, new int[] { 1, 4, 6, 7 }, new int[] { 2, 7, 15 }, 7)]
        public void DataDrivenTest(int testId, int[] days, int[] costs, int expected)
        {
            var sut = new MinimumCostForTickets();
            int actual = MeasureAndExecute(testId, () => sut.MincostTickets(days, costs));

            actual.Should().Be(expected);
        }
    }
}
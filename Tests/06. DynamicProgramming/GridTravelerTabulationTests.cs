using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using System.Diagnostics;
using FluentAssertions;

namespace Tests
{
    public class GridTravelerTabulationTests : BaseTests
    {
        public GridTravelerTabulationTests(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData(1, 0, 0, 0)]
        [InlineData(2, 1, 1, 1)]
        [InlineData(3, 2, 3, 3)]
        [InlineData(4, 3, 2, 3)]
        [InlineData(5, 3, 3, 6)]
        [InlineData(6, 18, 18, 2333606220)]
        public void DataDrivenTest(int testId, int m, int n, long expected)
        {
            var sut = new GridTravelerTabulation();
            long actual = MeasureAndExecute(testId, () => sut.CountWays(m, n));

            actual.Should().Be(expected);
        }
    }
}
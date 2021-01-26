using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using System.Diagnostics;
using FluentAssertions;

namespace Tests
{
    public class TrapRainWaterTests : BaseTests
    {
        public TrapRainWaterTests(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData(1, new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }, 6)]
        [InlineData(2, new int[] { 4, 2, 0, 3, 2, 5 }, 9)]
        [InlineData(3, new int[] { 1, 2, 3, 4, 5 }, 0)]
        [InlineData(4, new int[] { 5, 4, 3, 2, 1 }, 0)]
        [InlineData(5, new int[] { 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }, 400)]
        public void V1Test(int testId, int[] heights, int expected)
        {
            var sut = new TrapRainWater();

            int actual = MeasureAndExecute(testId, () => sut.Trap(heights));

            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData(1, new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }, 6)]
        [InlineData(2, new int[] { 4, 2, 0, 3, 2, 5 }, 9)]
        [InlineData(3, new int[] { 1, 2, 3, 4, 5 }, 0)]
        [InlineData(4, new int[] { 5, 4, 3, 2, 1 }, 0)]
        [InlineData(5, new int[] { 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }, 400)]
        public void V2Test(int testId, int[] heights, int expected)
        {
            var sut = new TrapRainWater2();

            int actual = MeasureAndExecute(testId, () => sut.Trap(heights));

            actual.Should().Be(expected);
        }
    }
}
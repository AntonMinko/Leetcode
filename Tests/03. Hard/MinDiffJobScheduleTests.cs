using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using System.Diagnostics;
using FluentAssertions;

namespace Tests
{
    public class MinDiffJobScheduleTests : BaseTests
    {
        public MinDiffJobScheduleTests(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData(1, new int[] { 6, 5, 4, 3, 2, 1 }, 2, 7)]
        [InlineData(2, new int[] { 9, 9, 9 }, 4, -1)]
        [InlineData(3, new int[] { 1, 1, 1 }, 3, 3)]
        [InlineData(4, new int[] { 7, 1, 7, 1, 7, 1 }, 3, 15)]
        [InlineData(5, new int[] { 1, 7, 1, 7, 1, 7, 1 }, 3, 9)]
        [InlineData(6, new int[] { 11, 111, 22, 222, 33, 333, 44, 444 }, 6, 843)]
        [InlineData(7, new int[] { 143, 446, 351, 170, 117, 963, 785, 76, 139, 772 }, 5, 1839)]
        [InlineData(8, new int[] { 4, 7, 6, 5, 2, 10, 9, 1, 3, 8 }, 5, 26)]
        [InlineData(9, new int[] { 380, 302, 102, 681, 863, 676, 243, 671, 651, 612, 162, 561, 394, 856, 601, 30, 6, 257, 921, 405, 716, 126, 158, 476, 889, 699, 668, 930, 139, 164, 641, 801, 480, 756, 797, 915, 275, 709, 161, 358, 461, 938, 914, 557, 121, 964, 315 }, 10, 3807)]
        public void DataDrivenTest(int testId, int[] jobDifficulty, int days, int expected)
        {
            var sut = new MinDiffJobSchedule();
            int actual = MeasureAndExecute(testId, () => sut.MinDifficulty(jobDifficulty, days));

            actual.Should().Be(expected);
        }
    }
}
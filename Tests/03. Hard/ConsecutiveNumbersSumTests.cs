using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using System.Diagnostics;
using FluentAssertions;

namespace Tests
{
    public class ConsecutiveNumbersSumTests : BaseTests
    {
        public ConsecutiveNumbersSumTests(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData(1, 5, 2)]
        [InlineData(2, 9, 3)]
        [InlineData(3, 15, 4)]
        public void DataDrivenTest(int testId, int N, int expected)
        {
            var sut = new ConsecutiveNumbersSum();
            int actual = MeasureAndExecute(testId, () => sut.Sum(N));

            actual.Should().Be(expected);
        }
    }
}
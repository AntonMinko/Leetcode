using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using System.Diagnostics;
using System.Linq;
using FluentAssertions;

namespace Tests
{
    public class LastStoneWeigthTests
    {
        private readonly ITestOutputHelper output;

        public LastStoneWeigthTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [InlineData(new int[] {}, 0)]
        [InlineData(new int[] {2}, 2)]
        [InlineData(new int[] {3,3}, 0)]
        [InlineData(new int[] {4,3,2}, 1)]
        [InlineData(new int[] {2,7,4,1,8,1}, 1)]
        [InlineData(new int[] {7,6,7,6,9}, 5)]
        public void DataDrivenTest(int[] stones, int expectedResult)
        {
            var sut = new LastStoneWeightProblem();
            int actualResult = sut.LastStoneWeight(stones);
            actualResult.Should().Be(expectedResult, stones.Print());
        }
    }
}
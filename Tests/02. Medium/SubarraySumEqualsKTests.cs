using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using System.Diagnostics;
using FluentAssertions;

namespace Tests
{
    public class SubarraySumEqualsKTests
    {
        private readonly ITestOutputHelper output;

        public SubarraySumEqualsKTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [InlineData(new int[] { 1,1,1}, 2, 2)]
        public void DataDrivenTest(int[] nums, int k, int expectedCount)
        {
            var sut = new SubarraySumEqualsK();
            int count = sut.SubarraySum(nums, k);

            count.Should().Be(expectedCount, nums.Print());
        }
    }
}
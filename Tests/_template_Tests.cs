using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using System.Diagnostics;
using FluentAssertions;

namespace Tests
{
    public class _template_Tests
    {
        private readonly ITestOutputHelper output;

        public _template_Tests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void TestName()
        {
            //Given

            //When

            //Then
        }

        [Theory]
        [InlineData(new int[] { 0 }, 1, -1)]
        public void DataDrivenTest(int[] nums, int target, int expectedIndex)
        {
        }
    }
}
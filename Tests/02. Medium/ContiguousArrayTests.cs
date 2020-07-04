using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using System.Diagnostics;
using FluentAssertions;

namespace Tests
{
    public class ContiguousArrayTests
    {
        private readonly ITestOutputHelper output;

        public ContiguousArrayTests(ITestOutputHelper output)
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
        [InlineData(new int[] {1}, 0)]
        [InlineData(new int[] {1,0}, 2)]
        [InlineData(new int[] {0, 1,0}, 2)]
        [InlineData(new int[] {0, 0, 0, 1, 0, 1}, 4)]
        [InlineData(new int[] {0, 0, 0, 1, 0, 1, 0}, 4)]
        public void DataDrivenTest(int[] nums, int expectedLength)
        {
            var sut = new ContiguousArray();
            int actualLength = sut.FindMaxLength(nums);

            actualLength.Should().Be(expectedLength, nums.Print());
        }
    }
}
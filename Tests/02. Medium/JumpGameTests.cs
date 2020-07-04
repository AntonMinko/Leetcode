using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using System.Diagnostics;
using FluentAssertions;

namespace Tests
{
    public class JumpGameTests
    {
        private readonly ITestOutputHelper output;

        public JumpGameTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [InlineData(new int[] { 3,2,1,0,4 }, false)]
        [InlineData(new int[] { 2,3,1,1,4 }, true)]
        [InlineData(new int[] { 3,2,1,1,0 }, true)]
        [InlineData(new int[] { 1,1,1,1,0 }, true)]
        [InlineData(new int[] { 2,0,2,0,0 }, true)]
        [InlineData(new int[] { 0 }, true)]
        public void DataDrivenTest(int[] nums, bool canJumpExpected)
        {
            var sut = new JumpGame();
            bool canJump = sut.CanJump(nums);

            canJump.Should().Be(canJumpExpected, nums.Print());
        }
    }
}
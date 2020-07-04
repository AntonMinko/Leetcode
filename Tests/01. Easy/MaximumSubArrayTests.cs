using Solutions;
using Xunit;

namespace Tests
{
    public class MaximumSubArrayTests
    {
        [Fact]
        public void TestName()
        {
            int expectedMax = 6;
            int max = new MaximumSubArray().MaxSubArray(new int[] {1,-2,3,2,0,-1,-1,1,-1,1,2});

            Assert.Equal(expectedMax, max);
        }
    }
}
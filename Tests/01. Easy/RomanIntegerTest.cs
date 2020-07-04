using Xunit;

namespace Solutions.Test
{
    
    public class RomanIntegerTest
    {
        [Theory]
        [InlineData("I", 1)]
        [InlineData("IV", 4)]
        [InlineData("III", 3)]
        [InlineData("IX", 9)]
        [InlineData("VII", 7)]
        [InlineData("LVIII", 58)]
        [InlineData("MCMXCIV", 1994)]
        public void RomanIntegersTest(string roman, int expectedNumber)
        {
            var converter = new RomanIntegers();
            int actualNumber = converter.RomanToInt(roman);

            Assert.Equal(expectedNumber, actualNumber);
        }

        [Fact]
        public void TestName()
        {
            var result = new FindTwoIndexes().TwoSum(new[] {-1,-2, -3, -4, -5}, 8);
            Assert.True(result[0] == 2);
            Assert.True(result[0] == 4);
        }
    }
}
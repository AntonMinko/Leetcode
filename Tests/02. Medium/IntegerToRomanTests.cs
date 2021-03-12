using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using System.Diagnostics;
using FluentAssertions;

namespace Tests
{
    public class IntegerToRomanTests : BaseTests
    {
        public IntegerToRomanTests(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData(1, 1, "I")]
        [InlineData(2, 2, "II")]
        [InlineData(3, 3, "III")]
        [InlineData(4, 4, "IV")]
        [InlineData(5, 5, "V")]
        [InlineData(6, 6, "VI")]
        [InlineData(7, 7, "VII")]
        [InlineData(8, 8, "VIII")]
        [InlineData(9, 9, "IX")]
        [InlineData(10, 10, "X")]
        [InlineData(11, 11, "XI")]
        [InlineData(12, 17, "XVII")]
        [InlineData(13, 19, "XIX")]
        [InlineData(14, 58, "LVIII")]
        [InlineData(15, 1994, "MCMXCIV")]
        // [InlineData(, , "")]
        // [InlineData(, , "")]
        public void DataDrivenTest(int testId, int num, string expected)
        {
            var sut = new IntegerToRoman();
            string actual = MeasureAndExecute(testId, () => sut.IntToRoman(num));

            actual.Should().Be(expected);
        }
    }
}
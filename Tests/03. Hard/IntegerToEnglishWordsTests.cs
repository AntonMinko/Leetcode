using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using System.Diagnostics;
using FluentAssertions;

namespace Tests
{
    public class IntegerToEnglishWordsTests : BaseTests
    {
        public IntegerToEnglishWordsTests(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData(1, 123, "One Hundred Twenty Three")]
        [InlineData(2, 12345, "Twelve Thousand Three Hundred Forty Five")]
        [InlineData(3, 1234567, "One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven")]
        [InlineData(4, 1234567891, "One Billion Two Hundred Thirty Four Million Five Hundred Sixty Seven Thousand Eight Hundred Ninety One")]
        [InlineData(5, 0, "Zero")]
        [InlineData(6, 10, "Ten")]
        [InlineData(7, 1001, "One Thousand One")]
        [InlineData(8, 100001, "One Hundred Thousand One")]
        [InlineData(9, 1000000, "One Million")]
        public void DataDrivenTest(int testId, int number, string expected)
        {
            var sut = new IntegerToEnglishWords();
            string actual = MeasureAndExecute(testId, () => sut.NumberToWords(number));

            actual.Should().Be(expected);
        }
    }
}
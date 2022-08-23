using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using System.Diagnostics;
using FluentAssertions;

namespace Tests
{
    public class LongestPalindromicSubstringTests
    {
        private readonly ITestOutputHelper output;

        public LongestPalindromicSubstringTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [InlineData("babad", "bab")]
        [InlineData("cbbd", "bb")]
        [InlineData("babab", "babab")]
        [InlineData("besad", "b")]
        [InlineData("babababa", "bababab")]
        [InlineData("sabababa", "abababa")]
        [InlineData("", "")]
        [InlineData("b", "b")]
        [InlineData("acbdaaebca", "aa")]
        public void DataDrivenTest(string s, string expected)
        {
            var sut = new LongestPalindromicSubstring();
            string actual = sut.LongestPalindrome(s);
            actual.Should().Be(expected, $"s={s}, expected={expected}, actual={actual}");
        }
    }
}
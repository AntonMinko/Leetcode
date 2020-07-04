﻿using Solutions;
using Xunit;
using System.Text;
using System.Diagnostics;
using Xunit.Abstractions;

namespace Tests
{
    public class RegularExpressionMatchingTests
    {
        private readonly ITestOutputHelper output;

        public RegularExpressionMatchingTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void TestName()
        {

        }

        [Theory]
        [InlineData("aa", "a", false)]
        [InlineData("aa", "a*", true)]
        [InlineData("ab", ".*", true)]
        [InlineData("ab", ".*c", false)]
        [InlineData("aab", "c*a*b", true)]
        [InlineData("mississippi", "mis*is*p*.", false)]
        [InlineData("mississippi", "mis*is*ip*.", true)]
        [InlineData("", "", false)]
        public void DataDrivenTest(string str, string pattern, bool isMatchExpected)
        {
            var sut = new RegularExpressionMatching();
            bool isMatch = sut.IsMatch(str, pattern);

            output.WriteLine($"Matching '{str}' against '{pattern}'");
            Assert.Equal(isMatch, isMatchExpected);
        }
    }
}
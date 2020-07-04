using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using System.Diagnostics;
using FluentAssertions;

namespace Tests
{
    public class ValidParenthesisStringTests
    {
        private readonly ITestOutputHelper output;

        public ValidParenthesisStringTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [InlineData("()", true)]
        [InlineData("(******", true)]
        [InlineData("(*)", true)]
        [InlineData("(((**)", true)]
        [InlineData("(((*)", false)]
        [InlineData("(*))", true)]
        public void DataDrivenTest(string str, bool isValidExpected)
        {
            var sut = new ValidParenthesisString();
            bool isValid = sut.CheckValidString2(str);
            isValid.Should().Be(isValidExpected);
        }
    }
}
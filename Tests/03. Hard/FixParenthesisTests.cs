using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using System.Diagnostics;
using FluentAssertions;
using System.Linq;

namespace Tests
{
    public class FixParenthesisTests : BaseTests
    {
        public FixParenthesisTests(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData(1, "()())()", new string[] {"(())()","()()()"})]
        [InlineData(2, "(a)())()", new string[] {"(a())()","(a)()()"})]
        [InlineData(3, ")(", new string[] {""})]
        [InlineData(4, "((i)", new string[] {"(i)"})]
        public void DataDrivenTest(int testId, string input, string[] expected)
        {
            var sut = new FixParenthesis();
            var actual = MeasureAndExecute(testId, () => sut.RemoveInvalidParentheses(input));

            actual.Should().BeEquivalentTo(expected.ToList());
        }
    }
}
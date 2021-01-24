using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using FluentAssertions;
using Solutions.DynamicProgramming;

namespace Tests
{
    public class CanConstructMemoizationTests : BaseTests
    {
        public CanConstructMemoizationTests(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData(1, "abcdef", new string[] { "ab", "abc", "cd", "def", "abcd" }, true)]
        [InlineData(2, "skateboard", new string[] { "bo", "rd", "ate", "t", "ska", "sk", "boar" }, false)]
        [InlineData(3, "enterapotentpot", new string[] { "a", "p", "ent", "enter", "ot", "o", "t" }, true)]
        [InlineData(4, "eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef", new string[] { "e", "ee", "eee", "eeee", "eeeee" }, false)]
        public void DataDrivenTest(int testId, string target, string[] wordBank, bool expectedresult)
        {
            var sut = new CanConstructMemoization();
            bool actual = MeasureAndExecute(testId, () => sut.CanConstruct(target, wordBank));

            actual.Should().Be(expectedresult);
        }
    }
}
using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using FluentAssertions;
using Solutions.DynamicProgramming;

namespace Tests
{
    public class CountConstructTabulationTests : BaseTests
    {
        public CountConstructTabulationTests(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData(1, "purple", new string[] { "purp", "p", "ur", "le", "purpl" }, 2)]
        [InlineData(2, "abcdef", new string[] { "ab", "abc", "cd", "def", "abcd" }, 1)]
        [InlineData(3, "skateboard", new string[] { "bo", "rd", "ate", "t", "ska", "sk", "boar" }, 0)]
        [InlineData(4, "enterapotentpot", new string[] { "a", "p", "ent", "enter", "ot", "o", "t" }, 4)]
        [InlineData(5, "eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef", new string[] { "e", "ee", "eee", "eeee", "eeeee" }, 0)]
        public void DataDrivenTest(int testId, string target, string[] wordBank, int expectedresult)
        {
            var sut = new CountConstructTabulation();
            int actual = MeasureAndExecute(testId, () => sut.CountConstruct(target, wordBank));

            actual.Should().Be(expectedresult);
        }
    }
}
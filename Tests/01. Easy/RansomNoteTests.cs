using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using System.Diagnostics;
using FluentAssertions;

namespace Tests
{
    public class RansomNoteTests
    {
        private readonly ITestOutputHelper output;

        public RansomNoteTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [InlineData("", "b", true)]
        [InlineData("", "", true)]
        [InlineData("a", "b", false)]
        [InlineData("aa", "ab", false)]
        [InlineData("aa", "aab", true)]
        [InlineData("bjaajgea", "affhiiicabhbdchbidghccijjbfjfhjeddgggbajhidhjchiedhdibgeaecffbbbefiabjdhggihccec", true)]
        public void DataDrivenTest(string ransomNote, string magazine, bool canConstructExpected)
        {
            var sut = new RansomNote();
            bool canConstruct = sut.CanConstruct(ransomNote, magazine);
            canConstruct.Should().Be(canConstructExpected, $"{ransomNote} in {magazine}");
        }
    }
}
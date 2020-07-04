using Solutions;
using Xunit;
using System.Text;
using System.Diagnostics;

namespace Tests
{
    public class BackspaceStringCompareTests
    {
        [Fact]
        public void TestName()
        {

        }

        [Theory]
        [InlineData("ab#c", "ad#c", true)]
        [InlineData("ab##", "c#d#", true)]
        [InlineData("a##c", "#a#c", true)]
        [InlineData("a#c", "b", false)]
        [InlineData("######", "", true)]
        [InlineData("abb#c", "add#c", false)]
        [InlineData("abc", "abc", true)]
        [InlineData("q#w#e#r#qwertyqwertyqwertyqwerty", "q#w#e#r#qwertyqwertyqwertyqwerty", true)]
        public void DataDrivenTest(string S, string T, bool isExpectedEqual)
        {
            var sut = new BacspaceStringCompare();
            bool isEqual = sut.BackspaceCompare(S, T);

            Assert.Equal(isExpectedEqual, isEqual);
        }
    }
}
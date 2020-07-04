using Solutions;
using Xunit;
using System.Text;
using System.Diagnostics;
using Xunit.Abstractions;

namespace Tests
{
    public class ReverseWordsInStringTests
    {
        private readonly ITestOutputHelper output;

    public ReverseWordsInStringTests(ITestOutputHelper output)
    {
        this.output = output;
    }

        [Fact]
        public void TestName()
        {
            string input = " the! sky  is blue";
            string expected = "blue is sky the!";
            var sut = new ReverseWordsInString();
            string actual = sut.ReverseWords(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestName2()
        {
            var sb = new StringBuilder();
            for (int i=0; i<10000000; i++)
            {
                sb.Append("shit!   ");
            }
            string input = sb.ToString();
            string expected = input.TrimEnd();

            var sut = new ReverseWordsInString();

            var timer = Stopwatch.StartNew();
            string actual = sut.ReverseWords(input);
            timer.Stop();
            output.WriteLine($"Method1 took {timer.ElapsedMilliseconds}");
            //Assert.Equal(expected, actual);

            timer = Stopwatch.StartNew();
            actual = sut.ReverseWords2(input);
            timer.Stop();
            output.WriteLine($"Method2 took {timer.ElapsedMilliseconds}");
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("the sky is blue", "blue is sky the")]
        [InlineData("  hello world!  ", "world! hello")]
        [InlineData("a good   example", "example good a")]
        [InlineData("", "")]
        [InlineData("hi", "hi")]        
        public void DataDrivenTest(string input, string expected)
        {
            var sut = new ReverseWordsInString();
            string actual = sut.ReverseWords(input);

            Assert.Equal(expected, actual);
        }
    }
}
using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using System.Diagnostics;
using FluentAssertions;

namespace Tests
{
    public class TextJustificationTests : BaseTests
    {
        public TextJustificationTests(ITestOutputHelper output) : base(output)
        {
        }

        /*
        Example 1:
        Input: words = ["This", "is", "an", "example", "of", "text", "justification."], maxWidth = 16
        Output:
        [
           "This    is    an",
           "example  of text",
           "justification.  "
        ]

        Example 2:
        Input: words = ["What","must","be","acknowledgment","shall","be"], maxWidth = 16
        Output:
        [
          "What   must   be",
          "acknowledgment  ",
          "shall be        "
        ]
        Explanation: Note that the last line is "shall be    " instead of "shall     be", because the last line must be left-justified instead of fully-justified.
        Note that the second line is also left-justified becase it contains only one word.

        Example 3:
        Input: words = ["Science","is","what","we","understand","well","enough","to","explain","to","a","computer.","Art","is","everything","else","we","do"], maxWidth = 20
        Output:
        [
          "Science  is  what we",
          "understand      well",
          "enough to explain to",
          "a  computer.  Art is",
          "everything  else  we",
          "do                  "
        ]

        Constraints:
            1 <= words.length <= 300
            1 <= words[i].length <= 20
            words[i] consists of only English letters and symbols.
            1 <= maxWidth <= 100
            words[i].length <= maxWidth
        */

        [Fact]
        public void Test1_Basic()
        {
            //Given
            string[] words = new string[] { "This", "is", "an", "example", "of", "text", "justification." };
            int maxWidth = 16;

            //When
            var sut = new TextJustification();
            var justifiedText = sut.FullJustify(words, maxWidth);

            //Then
            justifiedText.Count.Should().Be(3);
            justifiedText[0].Should().Be("This    is    an");
            justifiedText[1].Should().Be("example  of text");
            justifiedText[2].Should().Be("justification.  ");
        }

        [Fact]
        public void Test2_LongWord()
        {
            //Given
            string[] words = new string[] { "What", "must", "be", "acknowledgment", "shall", "be" };
            int maxWidth = 16;

            //When
            var sut = new TextJustification();
            var justifiedText = sut.FullJustify(words, maxWidth);

            //Then
            justifiedText.Count.Should().Be(3);
            justifiedText[0].Should().Be("What   must   be");
            justifiedText[1].Should().Be("acknowledgment  ");
            justifiedText[2].Should().Be("shall be        ");
        }

        [Fact]
        public void Test3_LongerText()
        {
            //Given
            string[] words = new string[] { "Science", "is", "what", "we", "understand", "well", "enough", "to", "explain", "to", "a", "computer.", "Art", "is", "everything", "else", "we", "do" };
            int maxWidth = 20;

            //When
            var sut = new TextJustification();
            var justifiedText = sut.FullJustify(words, maxWidth);

            //Then
            justifiedText.Count.Should().Be(6);
            justifiedText[0].Should().Be("Science  is  what we");
            justifiedText[1].Should().Be("understand      well");
            justifiedText[2].Should().Be("enough to explain to");
            justifiedText[3].Should().Be("a  computer.  Art is");
            justifiedText[4].Should().Be("everything  else  we");
            justifiedText[5].Should().Be("do                  ");
        }

        [Fact]
        public void Test4_SingleWord()
        {
            //Given
            string[] words = new string[] { "Science" };
            int maxWidth = 20;

            //When
            var sut = new TextJustification();
            var justifiedText = sut.FullJustify(words, maxWidth);

            //Then
            justifiedText.Count.Should().Be(1);
            justifiedText[0].Should().Be("Science             ");
        }
    }
}
using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using System.Diagnostics;
using FluentAssertions;

namespace Tests
{
    public class BinaryTreeFromStringTests : BaseTests
    {
        public BinaryTreeFromStringTests(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData(1, "-42", "[-42]")]
        [InlineData(2, "4(2(3)(1))(6(5))", "[4,2,6,3,1,5,null]")]
        [InlineData(3, "4(2(3)(1))(6(5)(7))", "[4,2,6,3,1,5,7]")]
        [InlineData(4, "-4(2(3)(1))(6(5)(7))", "[-4,2,6,3,1,5,7]")]
        //[InlineData(1, "", "")]
        public void DataDrivenTest(int testId, string str, string expected)
        {
            var sut = new BinaryTreeFromString();
            TreeNode actualNode = MeasureAndExecute(testId, () => sut.Str2tree(str));
            string actualStr = actualNode.ToStringBFS();

            actualStr.Should().Be(expected);
        }
    }
}
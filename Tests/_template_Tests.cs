using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using System.Diagnostics;
using FluentAssertions;

namespace Tests
{
    public class _template_Tests : BaseTests
    {
        public _template_Tests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void TestName()
        {
            //Given

            //When

            //Then
        }

        [Theory]
        [InlineData(1, new int[] { 0 }, 1, -1)]
        public void DataDrivenTest(int testId, int[] nums, int target, int expected)
        {
            // var sut = new CanConstructMemoization();
            // bool actual = MeasureAndExecute(testId, () => sut.CanConstruct(target, wordBank));

            // actual.Should().Be(expectedresult);
        }
    }
}
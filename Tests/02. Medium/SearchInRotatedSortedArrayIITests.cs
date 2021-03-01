using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using System.Diagnostics;
using FluentAssertions;

namespace Tests
{
    public class SearchInRotatedSortedArrayIITests : BaseTests
    {
        public SearchInRotatedSortedArrayIITests(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData(1, new int[] { 2, 5, 6, 0, 0, 1, 2 }, 0, true)]
        [InlineData(2, new int[] { 2, 5, 6, 0, 0, 1, 2 }, 3, false)]
        [InlineData(3, new int[] { 2, 2, 5, 6, 6, 6, 0, 0, 1, 1, 2 }, 6, true)]
        [InlineData(4, new int[] { 2, 2, 2, 2, 2, 2, 2, 2 }, 6, false)]
        [InlineData(5, new int[] { 2, 2, 2, 2, 2, 2, 6, 2 }, 6, true)]
        [InlineData(6, new int[] { 0, 0, 1, 1, 2, 0 }, 2, true)]
        [InlineData(7, new int[] { 1, 0, 1, 1, 1 }, 0, true)]
        [InlineData(8, new int[] { 5, 1, 3 }, 3, true)]
        [InlineData(9, new int[] { 5, 1, 3 }, 1, true)]
        [InlineData(10, new int[] { 5, 1, 3 }, 5, true)]
        [InlineData(11, new int[] { 5, 1 }, 5, true)]
        [InlineData(12, new int[] { 5, 1 }, 1, true)]
        [InlineData(13, new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0, true)]
        [InlineData(14, new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1 }, 2, true)]
        [InlineData(15, new int[] { 1, 1, 2, 2, 0, 0 }, 0, true)]
        public void DataDrivenTest(int testId, int[] nums, int target, bool expected)
        {
            var sut = new SearchInRotatedSortedArrayII();
            bool actual = MeasureAndExecute(testId, () => sut.Search(nums, target));

            actual.Should().Be(expected);
        }
    }
}
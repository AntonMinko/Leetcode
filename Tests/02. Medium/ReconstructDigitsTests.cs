using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using System.Diagnostics;
using FluentAssertions;

namespace Tests
{
    public class ReconstructDigitsTests : BaseTests
    {
        public ReconstructDigitsTests(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData(1, "owoztneoer", "012")]
        [InlineData(2, "nnie", "9")]
        [InlineData(3, "owoztneoernnneeeooo", "011112")]
        [InlineData(4, "roze", "0")]
        [InlineData(5, "reteh", "3")]
        [InlineData(6, "foveurfixneevssigneeiinht", "456789")]
        [InlineData(7, "foveurfixneevssigneeiinhtowoztneoerfoveurfixneevssigneeiinht", "012445566778899")]
        public void DataDrivenTest(int testId, string s, string expected)
        {
            var sut = new ReconstructDigits();
            var actual = MeasureAndExecute(testId, () => sut.OriginalDigits(s));

            actual.Should().Be(expected);
        }
    }
}
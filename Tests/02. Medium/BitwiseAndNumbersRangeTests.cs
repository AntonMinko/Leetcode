using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using System.Diagnostics;
using FluentAssertions;
using System;

namespace Tests
{
    public class BitwiseAndNumbersRangeTests
    {
        private class SlowBitwizeAnd
        {
            public int RangeBitwiseAnd(int m, int n)
            {
                int result = m;
                for (int i = m + 1; i <= n; i++)
                {
                    result &= i;
                }

                return result;
            }
        }
        private readonly ITestOutputHelper output;

        public BitwiseAndNumbersRangeTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void TestName()
        {
            //Given
            int from = 123, to = 234;
            var testLogic = new SlowBitwizeAnd();
            int expected = testLogic.RangeBitwiseAnd(from, to);
            output.WriteLine($"from     = {Convert.ToString(from, toBase: 2)}");
            output.WriteLine($"to       = {Convert.ToString(to, toBase: 2)}");
            output.WriteLine($"expected = {Convert.ToString(expected, toBase: 2)}");

            //When
            var sut = new BitwiseAndNumbersRange();
            int result = sut.RangeBitwiseAnd(from, to);

            //Then
            result.Should().Be(expected);
        }
    }
}
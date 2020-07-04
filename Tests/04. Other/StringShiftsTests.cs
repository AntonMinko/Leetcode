using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using System.Diagnostics;
using FluentAssertions;

namespace Tests
{
    public class StringShiftsTests
    {
        private readonly ITestOutputHelper output;

        public StringShiftsTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Test1()
        {
        //Given
        string str = "abc";
        int[][] shifts = new int[][] {new int[] {0,1}, new int[] {1,2}};
        
        //When
        var sut = new StringShifths();
        string result = sut.StringShift(str, shifts);

        //Then
        result.Should().Be("cab");
        }

        [Fact]
        public void Test2()
        {
        //Given
        string str = "abcdefg";
        int[][] shifts = new int[][]
        {
            new int[] {1,1},
            new int[] {1,1},
            new int[] {0,2},
            new int[] {1,3}
        };
        
        //When
        var sut = new StringShifths();
        string result = sut.StringShift(str, shifts);

        //Then
        result.Should().Be("efgabcd");
        }
    }
}
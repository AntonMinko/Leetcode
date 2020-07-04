using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using System.Diagnostics;
using FluentAssertions;

namespace Tests
{
    public class MaximalSquareTests
    {
        private readonly ITestOutputHelper output;

        public MaximalSquareTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Square2by2()
        {
            //Given
            var input = new char[][] {
                new[] {'1', '0', '1', '0', '0'},
                new[] {'1', '0', '1', '1', '1'},
                new[] {'1', '1', '1', '1', '1'},
                new[] {'1', '0', '0', '1', '0'}};
            var sut = new MaximalSquareProblem();

            //When
            int result = sut.MaximalSquare(input);

            //Then
            result.Should().Be(4);
        }

        [Fact]
        public void Square1by1_1()
        {
            //Given
            var input = new char[][] {
                new[] {'1'}};
            var sut = new MaximalSquareProblem();

            //When
            int result = sut.MaximalSquare(input);

            //Then
            result.Should().Be(1);
        }

        [Fact]
        public void Square1by1_0()
        {
            //Given
            var input = new char[][] {
                new[] {'0'}};
            var sut = new MaximalSquareProblem();

            //When
            int result = sut.MaximalSquare(input);

            //Then
            result.Should().Be(0);
        }

        [Fact]
        public void Square4by4()
        {
            //Given
            var input = new char[][] {
                new[] {'0', '1', '1', '1', '1'},
                new[] {'1', '1', '1', '1', '1'},
                new[] {'1', '1', '1', '1', '1'},
                new[] {'1', '1', '1', '1', '1'}};
            var sut = new MaximalSquareProblem();

            //When
            int result = sut.MaximalSquare(input);

            //Then
            result.Should().Be(16);
        }

        [Fact]
        public void Square3by3()
        {
            //Given
            var input = new char[][] {
                new[] {'0','0','1','0'},
                new[] {'1','1','1','1'},
                new[] {'1','1','1','1'},
                new[] {'1','1','1','0'},
                new[] {'1','1','0','0'},
                new[] {'1','1','1','1'},
                new[] {'1','1','1','0'}};
            var sut = new MaximalSquareProblem();

            //When
            int result = sut.MaximalSquare(input);

            //Then
            result.Should().Be(9);
        }

        [Fact]
        public void Square3by3_2()
        {
            //Given
            var input = new char[][] {
                new[] {'0','0','0','1'},
                new[] {'1','1','0','1'},
                new[] {'1','1','1','1'},
                new[] {'0','1','1','1'},
                new[] {'0','1','1','1'}};
            var sut = new MaximalSquareProblem();

            //When
            int result = sut.MaximalSquare(input);

            //Then
            result.Should().Be(9);
        }
    }
}
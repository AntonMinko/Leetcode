using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using System.Diagnostics;
using FluentAssertions;

namespace Tests
{
    public class NumberOfIslandsTests
    {
        private readonly ITestOutputHelper output;

        public NumberOfIslandsTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Test1()
        {
            //Given
            char[][] input = new char[][] {
                new char[] {'1','1','1','1','0'},
                new char[] {'1','1','0','1','0'},
                new char[] {'1','1','0','0','0'},
                new char[] {'0','0','0','0','0'}
            };

            //When
            var sut = new NumberOfIslands();
            int num = sut.NumIslands(input);

            //Then
            num.Should().Be(1);
        }

        [Fact]
        public void Test2()
        {
            //Given
            char[][] input = new char[][] {
                new char[] {'1','1','0','0','0'},
                new char[] {'1','1','0','0','0'},
                new char[] {'0','0','1','0','0'},
                new char[] {'0','0','0','1','1'}
            };

            //When
            var sut = new NumberOfIslands();
            int num = sut.NumIslands(input);

            //Then
            num.Should().Be(3);
        }

        [Fact]
        public void Test3()
        {
            //Given
            char[][] input = new char[][] {
                new char[] {'1','1','1'},
                new char[] {'0','1','0'},
                new char[] {'1','1','1'}
            };

            //When
            var sut = new NumberOfIslands();
            int num = sut.NumIslands(input);

            //Then
            num.Should().Be(1);
        }

        [Fact]
        public void Test4()
        {
            //Given
            char[][] input = new char[][] {
                new char[] {'0','1','0'},
                new char[] {'1','1','1'},
                new char[] {'0','1','0'}
            };

            //When
            var sut = new NumberOfIslands();
            int num = sut.NumIslands(input);

            //Then
            num.Should().Be(1);
        }

        [Fact]
        public void Test5()
        {
            //Given
            char[][] input = new char[][] {
                new char[] {'0','0','0'},
                new char[] {'0','1','0'},
                new char[] {'0','0','0'}
            };

            //When
            var sut = new NumberOfIslands();
            int num = sut.NumIslands(input);

            //Then
            num.Should().Be(1);
        }

        [Fact]
        public void Test6()
        {
            //Given
            char[][] input = new char[][] {
                new char[] {'0'}
            };

            //When
            var sut = new NumberOfIslands();
            int num = sut.NumIslands(input);

            //Then
            num.Should().Be(0);
        }

        [Fact]
        public void Test7()
        {
            //Given
            char[][] input = new char[][] {
                new char[] {'1'}
            };

            //When
            var sut = new NumberOfIslands();
            int num = sut.NumIslands(input);

            //Then
            num.Should().Be(1);
        }

        [Fact]
        public void Test8()
        {
            //Given
            char[][] input = new char[][] {
                new char[] {'1','0','1'},
                new char[] {'0','1','0'},
                new char[] {'1','0','1'}
            };

            //When
            var sut = new NumberOfIslands();
            int num = sut.NumIslands(input);

            //Then
            num.Should().Be(5);
        }

        [Fact]
        public void Test9()
        {
            //Given
            char[][] input = new char[][] { };

            //When
            var sut = new NumberOfIslands();
            int num = sut.NumIslands(input);

            //Then
            num.Should().Be(0);
        }
    }
}
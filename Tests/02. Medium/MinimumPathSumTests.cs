using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using System.Diagnostics;
using FluentAssertions;

namespace Tests
{
    public class MinimumPathSumTests
    {
        private readonly ITestOutputHelper output;

        public MinimumPathSumTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Test1()
        {
            //Given
            int[][] input = new int[][] {
                new int[] {1,3,1},
                new int[] {1,5,1},
                new int[] {4,2,1}
            };

            //When
            var sut = new MinimumPathSum();
            int num = sut.MinPathSum(input);

            //Then
            num.Should().Be(7);
        }

        [Fact]
        public void Test2()
        {
            //Given
            int[][] input = new int[][] {
                new int[] {1,1,1},
                new int[] {1,1,1},
                new int[] {1,1,1}
            };

            //When
            var sut = new MinimumPathSum();
            int num = sut.MinPathSum(input);

            //Then
            num.Should().Be(5);
        }

        [Fact]
        public void Test3()
        {
            //Given
            int[][] input = new int[0][];

            //When
            var sut = new MinimumPathSum();
            int num = sut.MinPathSum(input);

            //Then
            num.Should().Be(0);
        }

        [Fact]
        public void Test4()
        {
            //Given
            int[][] input = new int[][] {
                new int[] {4}
            };

            //When
            var sut = new MinimumPathSum();
            int num = sut.MinPathSum(input);

            //Then
            num.Should().Be(4);
        }

        [Fact]
        public void Test5()
        {
            //Given
            int[][] input = new int[][] {
                new int[] {9,1,4,8}
            };

            //When
            var sut = new MinimumPathSum();
            int num = sut.MinPathSum(input);

            //Then
            num.Should().Be(22);
        }
    }
}
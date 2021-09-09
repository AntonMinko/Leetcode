using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using System.Diagnostics;
using FluentAssertions;

namespace Tests
{
    public class ParallelCoursesTests : BaseTests
    {
        public ParallelCoursesTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Test1()
        {
            var relations = new int[][]
            {
                new[] {1, 3},
                new[] {2, 3}
            };

            var sut = new ParallelCourses();
            int actual = MeasureAndExecute(1, () => sut.MinimumSemesters(3, relations));

            actual.Should().Be(2);
        }

        [Fact]
        public void Test2()
        {
            var relations = new int[][]
            {
                new[] {1, 2},
                new[] {2, 3},
                new[] {3, 1}
            };

            var sut = new ParallelCourses();
            int actual = MeasureAndExecute(2, () => sut.MinimumSemesters(5, relations));

            actual.Should().Be(-1, "Cycle detected");
        }

        [Fact]
        public void Test3()
        {
            var relations = new int[][]
{
                new[] {1, 3},
                new[] {2, 3}
};

            var sut = new ParallelCourses();
            int actual = MeasureAndExecute(3, () => sut.MinimumSemesters(1000, relations));

            actual.Should().Be(2);
        }

        [Fact]
        public void Test4()
        {
            var relations = new int[][]
{
                new[] {1, 2},
                new[] {2, 3},
                new[] {3, 4},
                new[] {4, 5},
                new[] {5, 6},
                new[] {6, 7},
                new[] {7, 8},
};

            var sut = new ParallelCourses();
            int actual = MeasureAndExecute(4, () => sut.MinimumSemesters(10, relations));

            actual.Should().Be(8);
        }
    }
}
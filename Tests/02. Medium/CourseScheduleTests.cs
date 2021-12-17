using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using System.Diagnostics;
using FluentAssertions;

namespace Tests
{
    public class CourseScheduleTests : BaseTests
    {
        public CourseScheduleTests(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData(1, 2, "[[1,0]]", false)]
        [InlineData(2, 2, "[[1,0],[0,1]]", true)]
        [InlineData(3, 4, "[[0,1],[0,2],[1,2],[2,3]]", false)]
        [InlineData(4, 4, "[[1,0],[2,0],[2,1],[3,2]]", false)]
        [InlineData(5, 4, "[[1,0],[0,3],[2,1],[3,2]]", true)]
        [InlineData(6, 2, "[[1,1]]", true)]
        public void DataDrivenTest(int testId, int numCourses, string prerequisites, bool expected)
        {
            var sut = new CourseSchedule();
            bool actual = MeasureAndExecute(testId, () => sut.CanFinish(numCourses, prerequisites.ToTwoDimentionArray()));

            actual.Should().Be(expected);
        }
    }
} 
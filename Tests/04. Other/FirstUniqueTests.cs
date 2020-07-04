using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using System.Diagnostics;
using FluentAssertions;

namespace Tests
{
    public class FirstUniqueTests
    {
        private readonly ITestOutputHelper output;

        public FirstUniqueTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Test1()
        {
            FirstUnique firstUnique = new FirstUnique(new[] { 2, 3, 5 });
            int unique = firstUnique.ShowFirstUnique(); // return 2
            unique.Should().Be(2);

            firstUnique.Add(5);            // the queue is now [2,3,5,5]
            unique = firstUnique.ShowFirstUnique(); // return 2
            unique.Should().Be(2);

            firstUnique.Add(2);            // the queue is now [2,3,5,5,2]
            unique = firstUnique.ShowFirstUnique(); // return 3
            unique.Should().Be(3);

            firstUnique.Add(3);            // the queue is now [2,3,5,5,2,3]
            unique = firstUnique.ShowFirstUnique(); // return -1
            unique.Should().Be(-1);
        }

        [Fact]
        public void Test2()
        {
            FirstUnique firstUnique = new FirstUnique(new[] { 7, 7, 7, 7, 7, 7 });
            int unique = firstUnique.ShowFirstUnique(); // return -1
            unique.Should().Be(-1);

            firstUnique.Add(7);            // the queue is now [7,7,7,7,7,7,7]
            firstUnique.Add(3);            // the queue is now [7,7,7,7,7,7,7,3]
            firstUnique.Add(3);            // the queue is now [7,7,7,7,7,7,7,3,3]
            firstUnique.Add(7);            // the queue is now [7,7,7,7,7,7,7,3,3,7]
            firstUnique.Add(17);           // the queue is now [7,7,7,7,7,7,7,3,3,7,17]
            unique = firstUnique.ShowFirstUnique();
            unique.Should().Be(17);
        }

        [Fact]
        public void Test3()
        {
            FirstUnique firstUnique = new FirstUnique(new[] { 809 });
            int unique = firstUnique.ShowFirstUnique(); // return 809
            unique.Should().Be(809);

            firstUnique.Add(809);            // the queue is now [809,809]
            unique = firstUnique.ShowFirstUnique();
            unique.Should().Be(-1);
        }
    }
}
using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using FluentAssertions;
using Solutions.DynamicProgramming;
using System.Collections.Generic;

namespace Tests
{
    public class AllConstructMemoizationTests : BaseTests
    {
        public AllConstructMemoizationTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Test1()
        {
            int testId = 1;
            string target = "purple";
            var wordBank = new string[] { "purp", "p", "ur", "le", "purpl" };
            var expected = new List<List<string>> { new List<string> { "purp", "le" }, new List<string> { "p", "ur", "p", "le" } };

            var sut = new AllConstructMemoization();
            var actual = MeasureAndExecute(testId, () => sut.AllConstruct(target, wordBank));

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Test2()
        {
            int testId = 2;
            string target = "abcdef";
            var wordBank = new string[] { "ab", "abc", "cd", "def", "abcd" };
            var expected = new List<List<string>> { new List<string> { "abc", "def" } };

            var sut = new AllConstructMemoization();
            var actual = MeasureAndExecute(testId, () => sut.AllConstruct(target, wordBank));

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Test3()
        {
            int testId = 3;
            string target = "skateboard";
            var wordBank = new string[] { "bo", "rd", "ate", "t", "ska", "sk", "boar" };
            var expected = new List<List<string>>();

            var sut = new AllConstructMemoization();
            var actual = MeasureAndExecute(testId, () => sut.AllConstruct(target, wordBank));

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Test4()
        {
            int testId = 4;
            string target = "enterapotentpot";
            var wordBank = new string[] { "a", "p", "ent", "enter", "ot", "o", "t" };
            var expected = new List<List<string>> {
                new List<string> { "enter", "a", "p", "ot", "ent", "p" , "ot" },
                new List<string> { "enter", "a", "p", "ot", "ent", "p" , "o", "t" },
                new List<string> { "enter", "a", "p", "o", "t", "ent", "p" , "ot" },
                new List<string> { "enter", "a", "p", "o", "t", "ent", "p" , "o", "t" } };

            var sut = new AllConstructMemoization();
            var actual = MeasureAndExecute(testId, () => sut.AllConstruct(target, wordBank));

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Test5()
        {
            int testId = 5;
            string target = "eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef";
            var wordBank = new string[] { "e", "ee", "eee", "eeee", "eeeee" };
            var expected = new List<List<string>>();

            var sut = new AllConstructMemoization();
            var actual = MeasureAndExecute(testId, () => sut.AllConstruct(target, wordBank));

            actual.Should().BeEquivalentTo(expected);
        }
    }
}
using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using System.Diagnostics;
using FluentAssertions;

namespace Tests
{
    public class TrieTests
    {
        private readonly ITestOutputHelper output;

        public TrieTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void BasicTest()
        {
            Trie trie = new Trie();

            trie.Insert("apple");
            bool found = trie.Search("apple");   // returns true
            found.Should().Be(true, "apple");

            found = trie.Search("app");     // returns false
            found.Should().Be(false, "Search('app')");

            found = trie.StartsWith("app"); // returns true
            found.Should().Be(true, "StartsWith('app')");
            
            trie.Insert("app");
            trie.Search("app");     // returns true
            found.Should().Be(true, "Search('app')");
        }
    }
}
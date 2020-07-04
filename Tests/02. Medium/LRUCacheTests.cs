using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using System.Diagnostics;
using FluentAssertions;

namespace Tests
{
    public class LRUCacheTests
    {
        private readonly ITestOutputHelper output;

        public LRUCacheTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void TestName()
        {
            LRUCache cache = new LRUCache(2 /* capacity */ );

            cache.Put(1, 1);
            cache.Put(2, 2);
            cache.Get(1).Should().Be(1);
            cache.Put(3, 3);
            cache.Get(2).Should().Be(-1);
            cache.Get(3).Should().Be(3);
            cache.Put(1,5);
            cache.Put(4, 4);
            cache.Get(3).Should().Be(-1);
            cache.Get(1).Should().Be(5);
            cache.Get(4).Should().Be(4);
        }
    }
}
using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using System.Diagnostics;
using FluentAssertions;

namespace Tests
{
    public class UndergroundSystemTests : BaseTests
    {
        public UndergroundSystemTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Test1()
        {
            UndergroundSystem undergroundSystem = new UndergroundSystem();

            undergroundSystem.CheckIn(45, "Leyton", 3);
            undergroundSystem.CheckIn(32, "Paradise", 8);
            undergroundSystem.CheckIn(27, "Leyton", 10);
            undergroundSystem.CheckOut(45, "Waterloo", 15);
            undergroundSystem.CheckOut(27, "Waterloo", 20);
            undergroundSystem.CheckOut(32, "Cambridge", 22);

            double average1 = undergroundSystem.GetAverageTime("Paradise", "Cambridge");
            average1.Should().Be(14.0);

            double average2 = undergroundSystem.GetAverageTime("Leyton", "Waterloo");
            average2.Should().Be(11.0);

            undergroundSystem.CheckIn(10, "Leyton", 24);
            double average3 = undergroundSystem.GetAverageTime("Leyton", "Waterloo");
            average3.Should().Be(11.0);

            undergroundSystem.CheckOut(10, "Waterloo", 38);
            double average4 = undergroundSystem.GetAverageTime("Leyton", "Waterloo");
            average4.Should().Be(12.0);
        }

        [Fact]
        public void Test2()
        {
            UndergroundSystem undergroundSystem = new UndergroundSystem();

            undergroundSystem.CheckIn(10, "Leyton", 3);
            undergroundSystem.CheckOut(10, "Paradise", 8);
            double average1 = undergroundSystem.GetAverageTime("Leyton", "Paradise");
            average1.Should().Be(5.0);

            undergroundSystem.CheckIn(5, "Leyton", 10);
            undergroundSystem.CheckOut(5, "Paradise", 16);
            double average2 = undergroundSystem.GetAverageTime("Leyton", "Paradise");
            average2.Should().Be(5.5);

            undergroundSystem.CheckIn(2, "Leyton", 21);
            undergroundSystem.CheckOut(2, "Paradise", 30);
            double average3 = undergroundSystem.GetAverageTime("Leyton", "Paradise");
            average3.Should().BeApproximately(6.66667, 0.001);
        }
    }
}
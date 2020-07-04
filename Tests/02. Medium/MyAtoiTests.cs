using Xunit;

namespace Solutions.Test
{
    
    public class MyAtoiTest
    {

        [Fact]
        public void Test()
        {
            int result = new Atoi().MyAtoi("0-1");
            Assert.Equal(0, result);
        }
    }
}
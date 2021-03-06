﻿using Solutions;
using Xunit;

namespace Tests
{
    public class HappyNumberTests
    {
        [Fact]
        public void TestName()
        {
            int input = 19;
            bool expectedIsHappy = true;

            bool actualIsHappy = new HappyNumber().IsHappy(input);

            Assert.Equal(expectedIsHappy, actualIsHappy);
        }
    }
}
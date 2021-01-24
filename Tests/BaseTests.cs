using Xunit.Abstractions;
using System.Diagnostics;
using System;

namespace Tests
{
    public abstract class BaseTests
    {
        protected readonly ITestOutputHelper output;

        protected BaseTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        protected T MeasureAndExecute<T>(int testId, Func<T> func)
        {
            var timer = Stopwatch.StartNew();
            try
            {
                return func();
            }
            finally
            {
                timer.Stop();
                output.WriteLine($"Test {testId}. Execution took: {timer.ElapsedMilliseconds} ms.");
            }

        }
    }
}
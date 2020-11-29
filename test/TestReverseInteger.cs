namespace test
{
    using dev;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class TestReverseInteger : IDisposable
    {
        [Fact]
        public void TestSolution()
        {
            var soln = new ReverseInteger();
            
            var result = soln.Reverse(123);
            
        }
        
        public void Dispose()
        {
            
        }
    }
}

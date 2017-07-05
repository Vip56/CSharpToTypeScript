using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TypescriptSyntaxPaste.UnitTest
{
    public class Class1
    {
        public Class1()
        {
        }

        [Fact]
        public void Test()
        {
            var a = 1;
            var b = a + 1;

            Assert.Equal(b, 2);
        }
    }
}

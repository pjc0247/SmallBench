using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallBench
{
    public class TestIterationAttribute : Attribute
    {
        public int[] iterations;

        public TestIterationAttribute(int[] iterations)
        {
            this.iterations = iterations;
        }
    }
}

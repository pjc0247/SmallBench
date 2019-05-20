using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallBench
{
    public class TestDescriptionAttribute : Attribute
    {
        public string description;

        public TestDescriptionAttribute(string description)
        {
            this.description = description;
        }
    }
}

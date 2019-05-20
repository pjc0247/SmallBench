using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallBench
{
    partial class BenchReport
    {
        public string testName;
        public string description;

        public string sourceA, sourceB;
        public string instructionA, instructionB;
        public int codesizeA, codesizeB;

        public string methodNameA, methodNameB;
        public RunData[] runData;
    }
    public struct RunData
    {
        public int iteration;
        public double timeA, timeB;
    }
}

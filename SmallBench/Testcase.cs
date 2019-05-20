// https://raw.githubusercontent.com/pjc0247/speedtest/master/Speedtest.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SmallBench
{
    public class Testcase
    {
        private RunData[] runData;

        private string nameA, nameB;

        private Action<object, object> actionA, actionB;

        protected virtual object Prepare()
        {
            return null;
        }
        protected virtual object GenerateInput(int iteration)
        {
            return null;
        }

        protected void A(Expression<Action<object, object>> func)
        {
            if (func.Body is MethodCallExpression mcall)
                nameA = mcall.Method.Name;

            actionA = func.Compile();
        }
        protected void B(Expression<Action<object, object>> func)
        {
            if (func.Body is MethodCallExpression mcall)
                nameB = mcall.Method.Name;

            actionB = func.Compile();
        }

        public void Execute()
        {
            var iterations = GetType().GetCustomAttributes(false)
                .OfType<TestIterationAttribute>()
                .FirstOrDefault()
                .iterations;
            var runData = new List<RunData>();

            foreach (var iteration in iterations)
            {
                var rd = new RunData();
                var input = GenerateInput(iteration);
                var p = Prepare();
                rd.iteration = iteration;
                GC.Collect();

                var st = DateTime.Now;
                actionA.Invoke(input, p);
                rd.timeA = (DateTime.Now - st).TotalMilliseconds;

                p = Prepare();
                GC.Collect();

                st = DateTime.Now;
                actionB.Invoke(input, p);
                rd.timeB = (DateTime.Now - st).TotalMilliseconds;

                runData.Add(rd);
            }

            this.runData = runData.ToArray();
        }

        public string GenerateReport()
        {
            var report = new BenchReport();

            var ilA = ILExtractor.GetILData(GetType(), nameA);
            var ilB = ILExtractor.GetILData(GetType(), nameB);

            report.testName = GetType().Name;
            report.description = GetType().GetCustomAttributes(false)
                .OfType<TestDescriptionAttribute>()
                .FirstOrDefault()
                .description;

            report.sourceA = ilA.source;
            report.sourceB = ilB.source;
            report.instructionA = ilA.body;
            report.instructionB = ilB.body;
            report.codesizeA = ilA.codesize;
            report.codesizeB = ilB.codesize;
            report.methodNameA = nameA;
            report.methodNameB = nameB;
            report.runData = runData;

            return report.TransformText();
        }
    }
}
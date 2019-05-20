using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SmallBench
{
    [TestDescription("SADFSAFSAFSDAF")]
    [TestIteration(new int[] { 10000, 1000000, 10000000 })]
    class IfOrDictionary : Testcase
    {
        public IfOrDictionary()
        {
            A((input, _) => FromDict((string[])input, (Dictionary<string, string>)_));
            B((input, _) => FromIfElse((string[])input, (Dictionary<string, string>)_));
        }

        protected override object Prepare()
        {
            var map = new Dictionary<string, string>();
            map["void"] = "void";
            map["int"] = "int";
            map["char"] = "char";
            map["byte"] = "byte";
            map["sbyte"] = "sbyte";
            map["bool"] = "bool";
            map["short"] = "short";
            map["ushort"] = "ushort";
            map["string"] = "string";
            map["float"] = "float";
            map["double"] = "double";
            map["decimal"] = "decimal";
            map["uint"] = "uint";
            map["long"] = "long";
            map["ulong"] = "ulong";
            map["object"] = "object";
            return map;
        }
        protected override object GenerateInput(int iteration)
        {
            var validItems = new string[]
            {
                "void", "int", "uint", "char", "byte", "sbyte", "bool", "short", "ushort",
                "string", "float", "double", "decimal", "long", "ulong", "object"
            };
            var inputs = new List<string>();
            var rd = new Random();

            for (int i = 0; i < iteration; i++)
                inputs.Add(validItems[rd.Next(0, validItems.Length)]);

            return inputs.ToArray();
        }

        [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
        private void FromDict(string[] input, Dictionary<string, string> dict)
        {
            foreach (var i in input)
            {
                string output = null;
                dict.TryGetValue(i, out output);
            }
        }
        [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
        private void FromIfElse(string[] input, Dictionary<string, string> dict)
        {
            foreach (var i in input)
            {
                string output = null;

                if (i == "void") output = "void";
                else if (i == "int") output = "int";
                else if (i == "char") output = "char";
                else if (i == "byte") output = "byte";
                else if (i == "sbyte") output = "sbyte";
                else if (i == "bool") output = "bool";
                else if (i == "short") output = "short";
                else if (i == "ushort") output = "ushort";
                else if (i == "string") output = "string";
                else if (i == "float") output = "float";
                else if (i == "double") output = "double";
                else if (i == "decimal") output = "decimal";
                else if (i == "uint") output = "uint";
                else if (i == "long") output = "long";
                else if (i == "ulong") output = "ulong";
                else if (i == "object") output = "object";
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var c = new IfOrDictionary();

            c.Execute();

            Console.WriteLine(c.GenerateReport());

            System.IO.File.WriteAllText("a.md", c.GenerateReport());
        }
    }
}

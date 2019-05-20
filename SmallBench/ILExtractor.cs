using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

using Mono.Cecil;

namespace SmallBench
{
    public struct ILData
    {
        public string source;
        public string body;
        public int codesize;
    }
    class ILExtractor
    {
        public static ILData GetILData(Type type, string methodName)
        {
            var path = Assembly.GetEntryAssembly().Location;
            var readerParameters = new ReaderParameters {
                ReadSymbols = true
            };
            var module = ModuleDefinition.ReadModule(path, readerParameters);
            var typeDef = module.GetTypes()
                .Where(x => x.FullName == type.FullName)
                .FirstOrDefault();
            var methodDef = typeDef.Methods
                .Where(x => x.Name == methodName)
                .FirstOrDefault();

            var sb = new StringBuilder();
            foreach (var il in methodDef.Body.Instructions)
            {
                sb.AppendLine(il.ToString());
            }

            var sp = methodDef.DebugInformation.SequencePoints[0];
            var lastSp = methodDef.DebugInformation.SequencePoints.Last();
            var file = File.ReadAllText(sp.Document.Url);

            var src = file.Split('\n')
                .Skip(sp.StartLine)
                .Take(lastSp.EndLine - sp.StartLine - 1)
                .Aggregate((a, b) => a + '\n' + b);

            return new ILData(){
                body = sb.ToString(),
                source = src,
                codesize = methodDef.Body.CodeSize
            };
        }
    }
}

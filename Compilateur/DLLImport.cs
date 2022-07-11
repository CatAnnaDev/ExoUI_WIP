using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime;

namespace code2.Compilateur
{
    public class DLLImport
    {
        private List<string> dll = new List<string>();
        public List<string> ImportDLL(string code)
        {
            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(code);
            string basePath = Path.GetDirectoryName(
                typeof(GCSettings).GetTypeInfo().Assembly.Location
            );
            var root = syntaxTree.GetRoot() as CompilationUnitSyntax;
            if (root != null)
            {
                SyntaxList<UsingDirectiveSyntax> references = root.Usings;
                List<string> referencePaths = new List<string>
                {
                    typeof(object).GetTypeInfo().Assembly.Location,
                    typeof(Console).GetTypeInfo().Assembly.Location,
                    typeof(HttpClient).GetTypeInfo().Assembly.Location,
                    Path.Combine(basePath, "System.dll"),
                    Path.Combine(basePath, "System.Runtime.dll"),
                    Path.Combine(basePath, "System.Runtime.Extensions.dll"),
                    Path.Combine(basePath, "mscorlib.dll"),
                    Path.Combine(basePath, "System.Net.Http.dll"),
                    Path.Combine(basePath, "System.Threading.Tasks.dll"),
                    Path.Combine(basePath, "System.Text.dll")
                };
                referencePaths.AddRange(
                    references.Select(x => Path.Combine(basePath, $"{x.Name}.dll"))
                );
                List<PortableExecutableReference> executableReferences = new List<PortableExecutableReference>();
                foreach (string reference in referencePaths)
                {
                    if (File.Exists(reference))
                    {
                        dll.Add(reference);
                    }
                }
            }
            return dll;
        }
    }
}

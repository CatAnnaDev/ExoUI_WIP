using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Windows.Forms;

namespace code2
{
    internal class Compil
    {

        public string CompileAndRun(string code)
        {
            RichTextBox t = Application.OpenForms["Form1"].Controls["richTextBox1"] as RichTextBox;

            CompilerParameters CompilerParams = new CompilerParameters();

            CompilerParams.GenerateInMemory = true;
            CompilerParams.TreatWarningsAsErrors = false;
            CompilerParams.GenerateExecutable = false;
            CompilerParams.CompilerOptions = "/optimize";

            string[] references = { "System.dll" };
            CompilerParams.ReferencedAssemblies.AddRange(references);

            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerResults compile = provider.CompileAssemblyFromSource(CompilerParams, code);

            if (compile.Errors.HasErrors)
            {
                string text = "Compile error: ";
                foreach (var ce in compile.Errors)
                {
                    text += ce.ToString();
                }
                t.Text = "";
                t.Text = $"{text}";
            }

            else if (compile.Output != null)
            {
                string output = "";
                foreach (var sc in compile.Output)
                {
                    output += sc.ToString();
                }
                t.Text = "";
                t.Text = $"{output}";
            }

            Module module = compile.CompiledAssembly.GetModules()[0];
            Type mt = null;
            MethodInfo methInfo = null;

            if (module != null)
            {
                mt = module.GetType("CodeFromFile.CodeFromFile");
            }

            if (mt != null)
            {
                methInfo = mt.GetMethod("Add");
            }

            if (methInfo != null)
            {
                return (string)methInfo.Invoke(null, new object[] { 5, 10 });
            }

            return compile.Output.ToString();
        }
    }
}

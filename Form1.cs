using Microsoft.CSharp;
using ScintillaNET;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace code2
{
    public partial class Form1 : Form
    {
        private static List<TimeSpan> stopwatchlist = new List<TimeSpan>();
        private Stopwatch _stopwtch;

        private static List<Tuple<string, string, string>> Exo;

        private Compil cp = new Compil();

        private static int nbExoCurrent = -1;

        private static int nbexo = 0;

        private static int nbScoring = 0;

        private static bool SolvedExo = false;

        private const int BACK_COLOR = 0x2A211C;

        private const int FORE_COLOR = 0xB7B7B7;

        private const int NUMBER_MARGIN = 1;

        private const int BOOKMARK_MARGIN = 2;

        private const int BOOKMARK_MARKER = 2;

        [Obsolete]
        public Form1()
        {
            InitializeComponent();
            ExoClass exo = new ExoClass();
            Exo = exo.InitExo();
            

            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
        }

       /* Scintilla scintilla1;*/


        private int lineCount = 0;
        private StringBuilder output = new StringBuilder();

        private string Exec(string filename, string cmd, RichTextBox rtbLog, Scintilla rtbinfo)
        {
            string result = "";
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Normal;
            startInfo.FileName = filename;
            startInfo.Arguments = $"/C " + cmd;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.CreateNoWindow = true;
            process.OutputDataReceived += ((sender, e) =>
            {

                if (!string.IsNullOrEmpty(e.Data))
                {
                    lineCount++;
                    if (lineCount == 1)
                    {
                        output.Append(e.Data);
                    }
                    else if (lineCount == 2)
                    {
                        output.Append("\n"+e.Data+"\n");
                    }
                    else
                    {
                        output.AppendLine(e.Data);
                    }
                }
            });

            process.ErrorDataReceived += ((sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    lineCount++;
                    output.AppendLine("[" + lineCount + "]: " + e.Data);
                }
            });

            process.StartInfo = startInfo;
            process.Start();

            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();

            rtbLog.Text = output.ToString();
            
            process.WaitForExit();
            process.Close();
            result = output.ToString();
            lineCount = 0;
            output.Clear();
            return result;
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            /*scintilla1 = new Scintilla();*/
/*            scintilla1.Text = scintilla1.Text;
            scintilla1.Controls.Add(scintilla1);*/

            scintilla1.Dock = DockStyle.Fill;
            scintilla1.TextChanged += this.OnTextChanged;

            InitColors();
            InitSyntaxColoring();
            InitNumberMargin();

        }

        private void OnTextChanged(object sender, EventArgs e)
        {

        }

        public static Color IntToColor(int rgb)
        {
            return Color.FromArgb(255, (byte)(rgb >> 16), (byte)(rgb >> 8), (byte)rgb);
        }

        private void InitColors()
        {

            scintilla1.SetSelectionBackColor(true, IntToColor(0x114D9C));

        }

        private void InitSyntaxColoring()
        {

            // Configure the default style
            scintilla1.StyleResetDefault();
            scintilla1.Styles[Style.Default].Font = "Consolas";
            scintilla1.Styles[Style.Default].Size = 12;
            scintilla1.Styles[Style.Default].BackColor = IntToColor(0x212121);
            scintilla1.Styles[Style.Default].ForeColor = IntToColor(0xFFFFFF);
            scintilla1.CaretForeColor = Color.White;
            scintilla1.StyleClearAll();

            // Configure the CPP (C#) lexer styles
            scintilla1.Styles[Style.Cpp.Identifier].ForeColor = IntToColor(0xD0DAE2);
            scintilla1.Styles[Style.Cpp.Comment].ForeColor = IntToColor(0xBD758B);
            scintilla1.Styles[Style.Cpp.CommentLine].ForeColor = IntToColor(0x40BF57);
            scintilla1.Styles[Style.Cpp.CommentDoc].ForeColor = IntToColor(0x2FAE35);
            scintilla1.Styles[Style.Cpp.Number].ForeColor = IntToColor(0xFFFF00);
            scintilla1.Styles[Style.Cpp.String].ForeColor = IntToColor(0xFFFF00);
            scintilla1.Styles[Style.Cpp.Character].ForeColor = IntToColor(0xE95454);
            scintilla1.Styles[Style.Cpp.Preprocessor].ForeColor = IntToColor(0x8AAFEE);
            scintilla1.Styles[Style.Cpp.Operator].ForeColor = IntToColor(0xE0E0E0);
            scintilla1.Styles[Style.Cpp.Regex].ForeColor = IntToColor(0xff00ff);
            scintilla1.Styles[Style.Cpp.CommentLineDoc].ForeColor = IntToColor(0x77A7DB);
            scintilla1.Styles[Style.Cpp.Word].ForeColor = IntToColor(0x48A8EE);
            scintilla1.Styles[Style.Cpp.Word2].ForeColor = IntToColor(0xF98906);
            scintilla1.Styles[Style.Cpp.CommentDocKeyword].ForeColor = IntToColor(0xB3D991);
            scintilla1.Styles[Style.Cpp.CommentDocKeywordError].ForeColor = IntToColor(0xFF0000);
            scintilla1.Styles[Style.Cpp.GlobalClass].ForeColor = IntToColor(0x48A8EE);
            scintilla1.Lexer = Lexer.Cpp;

            scintilla1.SetKeywords(0, "class extends implements import interface new case do while else if for in switch throw get set function var try catch finally while with default break continue delete return each const namespace package include use is as instanceof typeof author copy default deprecated eventType example exampleText exception haxe inheritDoc internal link mtasc mxmlc param private return see serial serialData serialField since throws usage version langversion playerversion productversion dynamic private public partial static intrinsic internal native override protected AS3 final super this arguments null Infinity NaN undefined true false abstract as base bool break by byte case catch char checked class const continue decimal default delegate do double descending explicit event extern else enum false finally fixed float for foreach from goto group if implicit in int interface internal into is lock long new null namespace object operator out override orderby params private protected public readonly ref return switch struct sbyte sealed short sizeof stackalloc static string select this throw true try typeof uint ulong unchecked unsafe ushort using var virtual volatile void while where yield");
            scintilla1.SetKeywords(1, "void Null ArgumentError arguments Array Boolean Class Date DefinitionError Error EvalError Function int Math Namespace Number Object RangeError ReferenceError RegExp SecurityError String SyntaxError TypeError uint XML XMLList Boolean Byte Char DateTime Decimal Double Int16 Int32 Int64 IntPtr SByte Single UInt16 UInt32 UInt64 UIntPtr Void Path File System Windows Forms ScintillaNET");

        }

        private void InitNumberMargin()
        {

            scintilla1.Styles[Style.LineNumber].BackColor = IntToColor(BACK_COLOR);
            scintilla1.Styles[Style.LineNumber].ForeColor = IntToColor(FORE_COLOR);
            scintilla1.Styles[Style.IndentGuide].ForeColor = IntToColor(FORE_COLOR);
            scintilla1.Styles[Style.IndentGuide].BackColor = IntToColor(BACK_COLOR);

            var nums = scintilla1.Margins[NUMBER_MARGIN];
            nums.Width = 30;
            nums.Type = MarginType.Number;
            nums.Sensitive = true;
            nums.Mask = 0;

            scintilla1.MarginClick += scintilla1_MarginClick;
        }

        private void scintilla1_MarginClick(object sender, MarginClickEventArgs e)
        {
            if (e.Margin == BOOKMARK_MARGIN)
            {
                // Do we have a marker for this line?
                const uint mask = (1 << BOOKMARK_MARKER);
                var line = scintilla1.Lines[scintilla1.LineFromPosition(e.Position)];
                if ((line.MarkerGet() & mask) > 0)
                {
                    // Remove existing bookmark
                    line.MarkerDelete(BOOKMARK_MARKER);
                }
                else
                {
                    // Add bookmark
                    line.MarkerAdd(BOOKMARK_MARKER);
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                button1.PerformClick();
                Thread.Sleep(50);
            }
            if (e.KeyCode == Keys.F2)
            {
                button2.PerformClick();
                Thread.Sleep(50);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            CSharpCodeProvider codeProvider = new CSharpCodeProvider();
            ICodeCompiler icc = codeProvider.CreateCompiler();
            string Output = "Out.exe";
            //richTextBox1.Text = "";
            CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateExecutable = true;
            parameters.OutputAssembly = Output;
            string[] fileEntries = Directory.GetFiles(@"ref/", "*.dll");
            foreach (string fileName in fileEntries)
                parameters.ReferencedAssemblies.Add(fileName);

            CompilerResults results = icc.CompileAssemblyFromSource(parameters, scintilla1.Text);

            if (results.Errors.Count > 0)
            {
                richTextBox2.ForeColor = Color.White;
                foreach (CompilerError CompErr in results.Errors)
                {
                    richTextBox2.Text = "";
                    richTextBox2.Text = $"Line number {CompErr.Line},\nError Number: {CompErr.ErrorNumber} {CompErr.ErrorText}\n";
                }
            }
            else
            {
                richTextBox2.ForeColor = Color.White;
                richTextBox2.Text = "Successful Compile!";

                if (Exec("cmd", Output, richTextBox2, scintilla1).Equals(Exo[nbExoCurrent].Item3))
                {
                    if (MessageBox.Show("GG t'as bon") == DialogResult.OK)
                    {
                        button2.Visible = true;
                        SolvedExo = true;
                    }
                }
            }

            // cp.CompileAndRun(scintilla1.Text); WIP
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (nbExoCurrent +1 == Exo.Count)
            {
                _stopwtch.Stop();
                timer1.Stop();
                scintilla1.Clear();
                StringBuilder swl = new StringBuilder();
                for (int i = 0; i < stopwatchlist.Count; i++)
                {
                    swl.Append($"\n{stopwatchlist[i]}");
                }

                scintilla1.Text = swl.ToString();
            }

            if (button2.Text == "Start")
            {
                if (checkBox1.Checked)
                {
                    label3.Visible = true;
                    _stopwtch = new Stopwatch();
                    _stopwtch.Start();
                    timer1.Start();
                }
                else
                {
                    label3.Visible = false;
                }

                checkBox1.Visible = false;

                nbExoCurrent++;
                button2.Visible = false;
                button2.Text = "Next";

                richTextBox1.Clear();
                richTextBox2.Clear();
                scintilla1.Clear();

                scintilla1.Text = Exo[nbExoCurrent].Item1;

                richTextBox1.Text = Exo[nbExoCurrent].Item2;

                label2.Text = $"Exo: {nbexo}/{Exo.Count}";
                label1.Text = $"Score: {nbScoring}/{Exo.Count}";
            }
            if (SolvedExo && button2.Text == "Next")
            {
                nbExoCurrent++;
                nbexo++;
                nbScoring++;

                richTextBox1.Clear();
                richTextBox2.Clear();
                scintilla1.Clear();

                label2.Text = $"Exo: {nbexo}/{Exo.Count}";
                label1.Text = $"Score: {nbScoring}/{Exo.Count}";

                scintilla1.Text = Exo[nbExoCurrent].Item1;

                richTextBox1.Text = Exo[nbExoCurrent].Item2;
                richTextBox2.Clear();
                button2.Visible = false;
                SolvedExo = false;
                stopwatchlist.Add(_stopwtch.Elapsed);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Code frm2 = Application
                .OpenForms
                .OfType<Code>()
                .LastOrDefault();
            if (null == frm2)
            {
                frm2 = new Code();
                frm2.Show();
            }
            else
            {
                frm2.Activate();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(nbExoCurrent == -1 ) return;
            richTextBox1.Clear();
            richTextBox2.Clear();
            scintilla1.Clear();

            scintilla1.Text = Exo[nbExoCurrent].Item1;
            richTextBox1.Text = Exo[nbExoCurrent].Item2;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label3.Text = string.Format("Elapsed Time: \n{0:hh\\:mm\\:ss}", _stopwtch.Elapsed);
        }
    }
}

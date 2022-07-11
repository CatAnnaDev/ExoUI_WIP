#region

using code2.Compilateur;
using Microsoft.CSharp;
using ScintillaNET;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace code2
{
    public partial class Form1 : Form
    {

        private const int BackColor = 0x2A211C;

        private const int ForeColor = 0xB7B7B7;

        private const int NumberMargin = 1;

        private const int BookmarkMargin = 2;

        private const int BookmarkMarker = 2;
        private static readonly List<TimeSpan> _stopwatchlist = new List<TimeSpan>();

        private static Stopwatch _stopwtch;

        private static List<Tuple<string, string, string>> _exo;

        //private Compil _cp = new Compil();

        private static int _nbExoCurrent = 8;

        private static int _nbexo;

        private static int _nbScoring;

        private static bool _solvedExo;
        private readonly StringBuilder _output = new StringBuilder();

        private int _lineCount;

        [Obsolete]
        public Form1()
        {
            InitializeComponent();
            var exo = new ExoClass();
            _exo = exo.InitExo();

            KeyDown += Form1_KeyDown;
        }

        private string Exec(string filename, string cmd, RichTextBox rtbLog)
        {
            string result;
            var process = new Process();
            var startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Normal;
            startInfo.FileName = filename;
            startInfo.Arguments = "/C " + cmd;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.CreateNoWindow = true;
            process.OutputDataReceived += (sender, e) =>
            {

                if (!string.IsNullOrEmpty(e.Data))
                {
                    _lineCount++;
                    if (_lineCount == 1)
                    {
                        _output.Append(e.Data);
                    }
                    else if (_lineCount == 2)
                    {
                        _output.Append("\n" + e.Data + "\n");
                    }
                    else
                    {
                        _output.AppendLine(e.Data);
                    }
                }
            };

            process.ErrorDataReceived += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    _lineCount++;
                    _output.AppendLine("[" + _lineCount + "]: " + e.Data);
                }
            };

            process.StartInfo = startInfo;
            process.Start();

            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();

            rtbLog.Text = _output.ToString();

            process.WaitForExit();
            process.Close();
            result = _output.ToString();
            _lineCount = 0;
            _output.Clear();
            return result;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*scintilla1 = new Scintilla();*/
            /*            scintilla1.Text = scintilla1.Text;
                        scintilla1.Controls.Add(scintilla1);*/
            scintilla1.AutoCComplete();
            scintilla1.Dock = DockStyle.Fill;
            scintilla1.TextChanged += OnTextChanged;
            //scintilla1.AutoCCompleted += this.scintilla_AutoCompleteAccepted;

            InitColors();
            InitSyntaxColoring();
            InitNumberMargin();

        }

/*
        private void scintilla_AutoCompleteAccepted(object sender, AutoCSelectionEventArgs e)
        {
            throw new NotImplementedException();
        }
*/

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
            scintilla1.Styles[Style.Default].Size = 13;
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

            scintilla1.SetKeywords(0,
                "class extends implements import interface new case do while else if for in switch throw get set function var try catch finally while with default break continue delete return each const namespace package include use is as instanceof typeof author copy default deprecated eventType example exampleText exception haxe inheritDoc internal link mtasc mxmlc param private return see serial serialData serialField since throws usage version langversion playerversion productversion dynamic private public partial static intrinsic internal native override protected AS3 final super this arguments null Infinity NaN undefined true false abstract as base bool break by byte case catch char checked class const continue decimal default delegate do double descending explicit event extern else enum false finally fixed float for foreach from goto group if implicit in int interface internal into is lock long new null namespace object operator out override orderby params private protected public readonly ref return switch struct sbyte sealed short sizeof stackalloc static string select this throw true try typeof uint ulong unchecked unsafe ushort using var virtual volatile void while where yield");
            scintilla1.SetKeywords(1,
                "void Null ArgumentError arguments Array Boolean Class Date DefinitionError Error EvalError Function int Math Namespace Number Object RangeError ReferenceError RegExp SecurityError String SyntaxError TypeError uint XML XMLList Boolean Byte Char DateTime Decimal Double Int16 Int32 Int64 IntPtr SByte Single UInt16 UInt32 UInt64 UIntPtr Void Path File System Windows Forms ScintillaNET");

        }

        private void InitNumberMargin()
        {

            scintilla1.Styles[Style.LineNumber].BackColor = IntToColor(BackColor);
            scintilla1.Styles[Style.LineNumber].ForeColor = IntToColor(ForeColor);
            scintilla1.Styles[Style.IndentGuide].ForeColor = IntToColor(ForeColor);
            scintilla1.Styles[Style.IndentGuide].BackColor = IntToColor(BackColor);

            Margin nums = scintilla1.Margins[NumberMargin];
            nums.Width = 30;
            nums.Type = MarginType.Number;
            nums.Sensitive = true;
            nums.Mask = 0;

            scintilla1.MarginClick += scintilla1_MarginClick;
        }

        private void scintilla1_MarginClick(object sender, MarginClickEventArgs e)
        {
            if (e.Margin == BookmarkMargin)
            {
                // Do we have a marker for this line?
                const uint mask = 1 << BookmarkMarker;
                Line line = scintilla1.Lines[scintilla1.LineFromPosition(e.Position)];
                if ((line.MarkerGet() & mask) > 0)
                {
                    // Remove existing bookmark
                    line.MarkerDelete(BookmarkMarker);
                }
                else
                {
                    // Add bookmark
                    line.MarkerAdd(BookmarkMarker);
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                button1.PerformClick();
                Thread.Sleep(50);
            }
            if (keyData == Keys.F2)
            {
                button2.PerformClick();
                Thread.Sleep(50);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        [Obsolete]
        private async void button1_Click_1(object sender, EventArgs e)
        {
            var codeProvider = new CSharpCodeProvider();
            ICodeCompiler icc = codeProvider.CreateCompiler();
            string output = "Out.exe";
            //richTextBox1.Text = "";
            var parameters = new CompilerParameters();
            parameters.GenerateExecutable = true;
            parameters.OutputAssembly = output;
            DLLImport dll = new DLLImport();
            try
            {
                string[] fileEntries = Directory.GetFiles(@"ref/", "*.dll");

                foreach (string fileName in fileEntries)
                {
                    //parameters.ReferencedAssemblies.Add(fileName);
                }
                foreach (var import in dll.ImportDLL(scintilla1.Text))
                {
                    if(scintilla1.Text.StartsWith("using ") && scintilla1.Text.EndsWith(";"))
                        
                        parameters.ReferencedAssemblies.Add(import);
                }
            }
            catch
            {
                // ignored
            }

            CompilerResults results = icc.CompileAssemblyFromSource(parameters, scintilla1.Text);

            if (results.Errors.Count > 0)
            {
                richTextBox2.ForeColor = Color.White;
                foreach (CompilerError compErr in results.Errors)
                {
                    richTextBox2.Text = "";
                    richTextBox2.Text = $@"Line number {compErr.Line},
Error Number: {compErr.ErrorNumber} {compErr.ErrorText}
";
                }
            }
            else
            {
                richTextBox2.ForeColor = Color.White;
                richTextBox2.Text = @"Successful Compile!";

                if (Exec("cmd", output, richTextBox2).Equals(_exo[_nbExoCurrent].Item3))
                {
                    if (MessageBox.Show(@"GG t'as bon") == DialogResult.OK)
                    {
                        button2.Visible = true;
                        _solvedExo = true;

                        await NextConfirm();
                    }
                }
            }

            //cp.CompileAndRun(scintilla1.Text);
        }

        private Task NextConfirm()
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

            if (_nbExoCurrent + 1 == _exo.Count)
            {
                _stopwtch.Stop();
                timer1.Stop();
                scintilla1.Clear();
                var swl = new StringBuilder();
                for (int i = 0; i < _stopwatchlist.Count; i++)
                {
                    swl.Append($"\n{_stopwatchlist[i]}");
                }

                scintilla1.Text = swl.ToString();
            }

            if (_solvedExo)
            {
                _nbExoCurrent++;
                _nbexo++;
                _nbScoring++;

                richTextBox1.Clear();
                richTextBox2.Clear();
                scintilla1.Clear();

                label2.Text = $@"Exo: {_nbexo}/{_exo.Count}";
                label1.Text = $@"Score: {_nbScoring}/{_exo.Count}";

                scintilla1.Text = _exo[_nbExoCurrent].Item1;

                richTextBox1.Text = _exo[_nbExoCurrent].Item2;
                richTextBox2.Clear();
                button2.Visible = false;
                _solvedExo = false;
                if (_stopwtch != null)
                    _stopwatchlist.Add(_stopwtch.Elapsed);
            }
            return Task.CompletedTask;
        }

        private void button2_Click_1(object sender, EventArgs e)
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

            if (button2.Text == @"Start")
            {
                checkBox1.Visible = false;

                _nbExoCurrent++;
                button2.Visible = false;
                button2.Text = @"Next";

                richTextBox1.Clear();
                richTextBox2.Clear();
                scintilla1.Clear();

                scintilla1.Text = _exo[_nbExoCurrent].Item1;

                richTextBox1.Text = _exo[_nbExoCurrent].Item2;

                label2.Text = $@"Exo: {_nbexo}/{_exo.Count}";
                label1.Text = $@"Score: {_nbScoring}/{_exo.Count}";
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
            if (_nbExoCurrent == -1) return;
            richTextBox1.Clear();
            richTextBox2.Clear();
            scintilla1.Clear();

            scintilla1.Text = _exo[_nbExoCurrent].Item1;
            richTextBox1.Text = _exo[_nbExoCurrent].Item2;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = string.Format(@"Elapsed Time: 
{0:hh\:mm\:ss}",
                _stopwtch.Elapsed);
        }
    }
}

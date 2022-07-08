using ScintillaNET;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace code2
{
    public partial class Code : Form
    {

        private const int BACK_COLOR = 0x2A211C;

        private const int FORE_COLOR = 0xB7B7B7;

        private const int NUMBER_MARGIN = 1;

        private const int BOOKMARK_MARGIN = 2;

        private const int BOOKMARK_MARKER = 2;

        private readonly Dictionary<int, string> codeExemple = new Dictionary<int, string>
        {
            {
                0,
                "            bool isCSharpFun = true;\r\n            bool isFishTasty = false;\r\n            Console.WriteLine(isCSharpFun);   // Outputs True\r\n            Console.WriteLine(isFishTasty);   // Outputs False\r\n            \r\n            \r\n            int x = 10;\r\n            int y = 9;\r\n            Console.WriteLine(x > y); // returns True, because 10 is higher than 9\r\n            \r\n            \r\n            Console.WriteLine(10 == 15); // returns False, because 10 is not equal to 15"
            },
            {
                1,
                "        public static void Break()\r\n        {\r\n            for (int i = 0; i < 10; i++) \r\n            {\r\n                if (i == 4) \r\n                {\r\n                    break; // si i = 4 alors on sort de la boucle\r\n                }\r\n                Console.WriteLine(i);\r\n            }\r\n        }    \r\n        \r\n        public static void Continue()\r\n        {\r\n            for (int i = 0; i < 10; i++) \r\n            {\r\n                if (i == 4) \r\n                {\r\n                    continue; // si i = 4 alors on continue jusqu'à la fin de la boucle soit 10\r\n                }\r\n                Console.WriteLine(i);\r\n            }\r\n        }"
            },
            {
                2,
                "        // commentaire sur une ligne\r\n\r\n        /*\r\n        * commentaire sur plusieurs lignes\r\n        * commentaire sur plusieurs lignes\r\n        * commentaire sur plusieurs lignes\r\n        */     \r\n\r\n        /*\r\n            commentaire sur plusieurs lignes\r\n            commentaire sur plusieurs lignes\r\n            commentaire sur plusieurs lignes\r\n        */ "
            },
            {
                3,
                "        int myNum = 5;               // Integer (whole number)\r\n        double myDoubleNum = 5.99D;  // Floating point number\r\n        char myLetter = 'D';         // Character\r\n        bool myBool = true;          // Boolean\r\n        string myText = \"Hello\";     // String\r\n        \r\n        // et bien plus "
            },
            {
                4,
                "            // Use if to specify a block of code to be executed, if a specified condition is true\r\n            // Use else to specify a block of code to be executed, if the same condition is false\r\n            // Use else if to specify a new condition to test, if the first condition is false\r\n            // Use switch to specify many alternative blocks of code to be executed\r\n            \r\n            if (condition) \r\n            {\r\n                // block of code to be executed if the condition is True\r\n            }\r\n            \r\n            if (20 > 18) \r\n            {\r\n                Console.WriteLine(\"20 is greater than 18\");\r\n            }\r\n            \r\n            int x = 20;\r\n            int y = 18;\r\n            if (x > y) \r\n            {\r\n                Console.WriteLine(\"x is greater than y\");\r\n            }\r\n            \r\n            if (condition)\r\n            {\r\n                // block of code to be executed if the condition is True\r\n            } \r\n            else \r\n            {\r\n                // block of code to be executed if the condition is False\r\n            }\r\n            \r\n            int time = 20;\r\n            if (time < 18) \r\n            {\r\n                Console.WriteLine(\"Good day.\");\r\n            } \r\n            else \r\n            {\r\n                Console.WriteLine(\"Good evening.\");\r\n            }\r\n            // Outputs \"Good evening.\"\r\n            \r\n            if (condition1)\r\n            {\r\n                // block of code to be executed if condition1 is True\r\n            } \r\n            else if (condition2) \r\n            {\r\n                // block of code to be executed if the condition1 is false and condition2 is True\r\n            } \r\n            else\r\n            {\r\n                // block of code to be executed if the condition1 is false and condition2 is False\r\n            }"
            },
            {
                5,
                "        public static void While()\r\n        {\r\n            int i = 0;\r\n            while (i < 10) // si i n'est pas = a 10, on continue\r\n            {\r\n                i++;\r\n            }\r\n        }      \r\n        \r\n        public static void Do_While()\r\n        {\r\n            int i = 0; // fait augmenter i de 1 à chaque tour de boucle et si i = 10 on stop\r\n            do\r\n            {\r\n                i++;\r\n            }while (i < 10)\r\n        }   \r\n        \r\n        public static void For()\r\n        {\r\n           List<int> list = new List<int>();\r\n           for (int i = 0; i < 10; i++) // ajoute les nombres de 0 à 9 dans la liste\r\n           {\r\n             list.Add(i);\r\n           }\r\n        }  \r\n        \r\n        public static void Foreach()\r\n        {\r\n            Dictionary<int, string> dict = new Dictionary<int, string>();\r\n            dict.Add(1, \"one\");\r\n            foreach (var data in dict) // lis tous les éléments de la liste avec la key et la value\r\n            {\r\n                Console.WriteLine(data.Key  + \" \" + data.Value);\r\n                // data.Key = 1\r\n                // data.Value = one\r\n            }\r\n        } "
            },
            {
                6,
                "            int a = 10;\r\n            int b = 20;\r\n            \r\n            if(a == b) // si a est égal à b\r\n            if(a != b) // si a est différent de b ou alors si a n'es pas égale à b\r\n            if(a > b) // si a est supérieur à b\r\n            if(a < b) // si a est inférieur à b\r\n            if(a >= b) // si a est supérieur ou égal à b\r\n            if(a <= b) // si a est inférieur ou égal à b\r\n            if(a == b && a == b) // si a est égal à b et aussi a est égal à b\r\n            if(a == b & a == b) // si a est égal à b et a est égal à b\r\n            if(a == b || a == b) // si a est égal à b ou sinon a est égal à\r\n            if(a == b | a == b) // si a est égal à b ou a est égal à b"
            },
            { 7, "            Console.WriteLine(\"Hello World\"); // print et saute une ligne auto\r\n            Console.Write(\"Hello World\"); // print et reste sur la même ligne " },
            {
                8,
                "            string greeting = \"Hello\";\r\n            \r\n            Console.WriteLine(\"The length of the txt string is: \" + greeting.Length); // prints the length of the string\r\n            Console.WriteLine(greeting.ToUpper());   // Outputs \"HELLO WORLD\"\r\n            Console.WriteLine(greeting.ToLower());   // Outputs \"hello world\"\r\n            \r\n            \r\n            string firstName = \"John \";\r\n            string lastName = \"Doe\";\r\n            string name = firstName + lastName;\r\n            Console.WriteLine(name); // Outputs \"John Doe\"\r\n            \r\n            \r\n            string myString = \"Hello\";\r\n            Console.WriteLine(myString[0]);  // Outputs \"H\"\r\n            Console.WriteLine(myString[1]);  // Outputs \"e\""
            },
            {
                9,
                "            int day = 4; // day = 4\r\n            switch (day) \r\n            {\r\n                case 1:\r\n                    Console.WriteLine(\"Monday\");\r\n                    break;\r\n                case 2:\r\n                    Console.WriteLine(\"Tuesday\");\r\n                    break;\r\n                case 3:\r\n                    Console.WriteLine(\"Wednesday\");\r\n                    break;\r\n                case 4: // donc on s'arrête ici et print Thursday puis on break pour ne pas check le reste du switch\r\n                    Console.WriteLine(\"Thursday\");\r\n                    break;\r\n                case 5:\r\n                    Console.WriteLine(\"Friday\");\r\n                    break;\r\n                case 6:\r\n                    Console.WriteLine(\"Saturday\");\r\n                    break;\r\n                case 7:\r\n                    Console.WriteLine(\"Sunday\");\r\n                    break;\r\n            }\r\n            // Outputs \"Thursday\" (day 4)"
            },
            {
                10,
                "        // Implicit Casting (automatically) - converting a smaller type to a larger type size\r\n        // char -> int -> long -> float -> double\r\n        \r\n        // Explicit Casting (manually) - converting a larger type to a smaller size type\r\n        // double -> float -> long -> int -> char\r\n        \r\n        int myInt = 10;\r\n        double myDouble = 5.25;\r\n        bool myBool = true;\r\n\r\n        static void funtion()\r\n        {\r\n            // Example 1\r\n            Console.WriteLine(Convert.ToString(myInt)); // convert int to string\r\n            Console.WriteLine(Convert.ToDouble(myInt)); // convert int to double\r\n            Console.WriteLine(Convert.ToInt32(myDouble)); // convert double to int\r\n            Console.WriteLine(Convert.ToString(myBool)); // convert bool to string\r\n            \r\n            // Example 2\r\n            Console.WriteLine(myInt.ToString()); // convert int to string\r\n            Console.WriteLine((double)myInt); // convert int to double\r\n            Console.WriteLine((int)myDouble); // convert double to int\r\n            Console.WriteLine(myBool.ToString()); // convert bool to string\r\n            \r\n        }"
            },
            {
                11,
                "            // Print \" Enter username: \" \r\n            Console.Write(\"Enter username: \");\r\n\r\n            // Attend la réponse de l'utilisateur et le met dans la variable username\r\n            string userName = Console.ReadLine();\r\n\r\n            // Print la variable username \r\n            Console.WriteLine(\"Username is: \" + userName);\r\n            // OU\r\n            Console.WriteLine($\"Username is: {userName}\");"
            },
            {
                12,
                "        var a = 1; // variable qui peux prendre n'importe quel type de donnée\r\n        const int b = 2; // variable de type entier constante\r\n        int c = 3; // variable de type entier\r\n        float d = 4.5f; // variable de type flottant\r\n        double e = 5.5; // variable de type flottant\r\n        string f = \"Hello World\"; // variable de type chaîne de caractères\r\n        bool g = true; // variable de type booléen\r\n        char h = 'a'; // variable de type caractère\r\n        object i = new object(); // variable de type objet\r\n        object[] j = new object[3]; // variable de type tableau d'objets\r\n        int[] k = new int[3]; // variable de type tableau d'entiers\r\n        float[] l = new float[3]; // variable de type tableau de flottants\r\n        double[] m = new double[3]; // variable de type tableau de flottants\r\n        string[] n = new string[3]; // variable de type tableau de chaînes de caractères\r\n        bool[] o = new bool[3]; // variable de type tableau de booléens\r\n        char[] p = new char[3]; // variable de type tableau de caractères\r\n        object[,] q = new object[3, 3]; // variable de type tableau de tableaux d'objets\r\n        int[,] r = new int[3, 3]; // variable de type tableau de tableaux d'entiers\r\n        float[,] s = new float[3, 3]; // variable de type tableau de tableaux de flottants\r\n        double[,] t = new double[3, 3]; // variable de type tableau de tableaux de flottants\r\n        string[,] u = new string[3, 3]; // variable de type tableau de tableaux de chaînes de caractères\r\n        bool[,] v = new bool[3, 3]; // variable de type tableau de tableaux de booléens\r\n        List<string> list = new List<string>(); // variable de type liste de chaînes de caractères\r\n        Dictionary<string, int> dict = new Dictionary<string, int>(); // variable de type dictionnaire de chaînes de caractères et entiers"
            }
        };
        private Scintilla TextArea;
        public Code()
        {
            InitializeComponent();
        }

        private int select { get; set; }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            select = listBox1.SelectedIndex;
            TextArea.Text = codeExemple[select];
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

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

            TextArea.SetSelectionBackColor(true, IntToColor(0x114D9C));

        }

        private void InitSyntaxColoring()
        {

            // Configure the default style
            TextArea.StyleResetDefault();
            TextArea.Styles[Style.Default].Font = "Consolas";
            TextArea.Styles[Style.Default].Size = 12;
            TextArea.Styles[Style.Default].BackColor = IntToColor(0x212121);
            TextArea.Styles[Style.Default].ForeColor = IntToColor(0xFFFFFF);
            TextArea.CaretForeColor = Color.White;
            TextArea.StyleClearAll();

            // Configure the CPP (C#) lexer styles
            TextArea.Styles[Style.Cpp.Identifier].ForeColor = IntToColor(0xD0DAE2);
            TextArea.Styles[Style.Cpp.Comment].ForeColor = IntToColor(0xBD758B);
            TextArea.Styles[Style.Cpp.CommentLine].ForeColor = IntToColor(0x40BF57);
            TextArea.Styles[Style.Cpp.CommentDoc].ForeColor = IntToColor(0x2FAE35);
            TextArea.Styles[Style.Cpp.Number].ForeColor = IntToColor(0xFFFF00);
            TextArea.Styles[Style.Cpp.String].ForeColor = IntToColor(0xFFFF00);
            TextArea.Styles[Style.Cpp.Character].ForeColor = IntToColor(0xE95454);
            TextArea.Styles[Style.Cpp.Preprocessor].ForeColor = IntToColor(0x8AAFEE);
            TextArea.Styles[Style.Cpp.Operator].ForeColor = IntToColor(0xE0E0E0);
            TextArea.Styles[Style.Cpp.Regex].ForeColor = IntToColor(0xff00ff);
            TextArea.Styles[Style.Cpp.CommentLineDoc].ForeColor = IntToColor(0x77A7DB);
            TextArea.Styles[Style.Cpp.Word].ForeColor = IntToColor(0x48A8EE);
            TextArea.Styles[Style.Cpp.Word2].ForeColor = IntToColor(0xF98906);
            TextArea.Styles[Style.Cpp.CommentDocKeyword].ForeColor = IntToColor(0xB3D991);
            TextArea.Styles[Style.Cpp.CommentDocKeywordError].ForeColor = IntToColor(0xFF0000);
            TextArea.Styles[Style.Cpp.GlobalClass].ForeColor = IntToColor(0x48A8EE);
            TextArea.Lexer = Lexer.Cpp;

            TextArea.SetKeywords(0,
                "class extends implements import interface new case do while else if for in switch throw get set function var try catch finally while with default break continue delete return each const namespace package include use is as instanceof typeof author copy default deprecated eventType example exampleText exception haxe inheritDoc internal link mtasc mxmlc param private return see serial serialData serialField since throws usage version langversion playerversion productversion dynamic private public partial static intrinsic internal native override protected AS3 final super this arguments null Infinity NaN undefined true false abstract as base bool break by byte case catch char checked class const continue decimal default delegate do double descending explicit event extern else enum false finally fixed float for foreach from goto group if implicit in int interface internal into is lock long new null namespace object operator out override orderby params private protected public readonly ref return switch struct sbyte sealed short sizeof stackalloc static string select this throw true try typeof uint ulong unchecked unsafe ushort using var virtual volatile void while where yield");
            TextArea.SetKeywords(1,
                "void Null ArgumentError arguments Array Boolean Class Date DefinitionError Error EvalError Function int Math Namespace Number Object RangeError ReferenceError RegExp SecurityError String SyntaxError TypeError uint XML XMLList Boolean Byte Char DateTime Decimal Double Int16 Int32 Int64 IntPtr SByte Single UInt16 UInt32 UInt64 UIntPtr Void Path File System Windows Forms ScintillaNET");

        }

        private void InitNumberMargin()
        {


            TextArea.Styles[Style.LineNumber].BackColor = IntToColor(BACK_COLOR);
            TextArea.Styles[Style.LineNumber].ForeColor = IntToColor(FORE_COLOR);
            TextArea.Styles[Style.IndentGuide].ForeColor = IntToColor(FORE_COLOR);
            TextArea.Styles[Style.IndentGuide].BackColor = IntToColor(BACK_COLOR);

            Margin nums = TextArea.Margins[NUMBER_MARGIN];
            nums.Width = 30;
            nums.Type = MarginType.Number;
            nums.Sensitive = true;
            nums.Mask = 0;

            TextArea.MarginClick += TextArea_MarginClick;
        }

        private void TextArea_MarginClick(object sender, MarginClickEventArgs e)
        {
            if (e.Margin == BOOKMARK_MARGIN)
            {
                // Do we have a marker for this line?
                const uint mask = 1 << BOOKMARK_MARKER;
                Line line = TextArea.Lines[TextArea.LineFromPosition(e.Position)];
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

        private void Code_Load(object sender, EventArgs e)
        {
            TextArea = new Scintilla();
            TextArea.Text = richTextBox1.Text;
            richTextBox1.Controls.Add(TextArea);

            TextArea.Dock = DockStyle.Fill;
            richTextBox1.TextChanged += OnTextChanged;

            InitColors();
            InitSyntaxColoring();
            InitNumberMargin();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = checkBox1.Checked;
        }
    }
}

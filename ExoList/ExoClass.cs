#region

using System;
using System.Collections.Generic;

#endregion

namespace code2
{
    internal class ExoClass
    {

        public List<Tuple<string, string, string>> InitExo()
        {
            List<Tuple<string, string, string>> Exo = new List<Tuple<string, string, string>>
            {
                Tuple.Create("using System;\r\n\r\nnamespace EXO\r\n{\r\n    class Program\r\n    {\r\n        static void Main(string[] args)\r\n        {\r\n            console.WriteLine(\"Hello World!\");\r\n        }\r\n    }\r\n}",
                    "// Erreur\r\n// RESULT : Hello World!",
                    "Hello World!"),
                Tuple.Create(
                    "using System;\r\n\r\nnamespace EXO1\r\n{\r\n    class Program\r\n    {\r\n        static void Main(string[] args)\r\n        {\r\n            int x = 15;\r\n            for (int i = 0; i < x; i++)\r\n            {\r\n                Console.WriteLine(i);\r\n            }\r\n        }\r\n    }\r\n}",
                    "// Manquant\r\n// Result : 01234567891011121314",
                    "01234567891011121314"),
                Tuple.Create(
                    "using System;\r\n\r\nnamespace EXO2\r\n{\r\n    class Program\r\n    {\r\n        static void Main(string[] args)\r\n        {\r\n            string EXO2 = \"Salut je suis \"Psyko\" et j'aime bien Dev des exo a 5h du mat XD\"\r\n\r\n                Console.Write(EXO2);\r\n\r\n        }\r\n    }\r\n}",
                    "//ERREUR\r\n// Result : Salut je suis \"Psyko\" et j'aime bien Dev des exo a 5h du mat XD",
                    "Salut je suis \"Psyko\" et j'aime bien Dev des exo a 5h du mat XD"),
                Tuple.Create(
                    "using System;\r\n\r\nnamespace EXO3\r\n{\r\n    class Program\r\n    {\r\n        static void Main(string[] args)\r\n        {\r\n            Console.WriteLine(Truc(5,10f));\r\n        }\r\n\r\n        private static int Truc(int num, float num2)\r\n        {\r\n            int result = num + num2;\r\n            return result;\r\n        }\r\n    }\r\n}",
                    "//ERREUR\r\n//Result : 15",
                    "15"),
                Tuple.Create(
                    "using System;\r\n\r\nnamespace EXO4\r\n{\r\n    class Program\r\n    {\r\n        static void Main(string[] args)\r\n        {\r\n            string[] blap = { \"Blap\", \"Blap1\", \"Blap2\", \"blap3\" };\r\n            foreach (int S in blap)  Console.WriteLine(S);\r\n        }\r\n    }\r\n}",
                    "//Manque\r\n//Result : BLAP BLAP1 BLAP2 BLAP3",
                    "BLAP BLAP1 BLAP2 BLAP3"),
                Tuple.Create(
                    "using System;\r\n\r\nnamespace EXO5\r\n{\r\n    class Program\r\n    {\r\n        static void Main(string[] args)\r\n        {\r\n            Console.WriteLine(TXT.Truc(\"des choses\"));\r\n        }\r\n\r\n\r\n    }\r\n\r\n    class TXT\r\n    {\r\n        private static string Truc(string txt)\r\n        {\r\n            return txt.Substring(0);\r\n        }\r\n    }\r\n}",
                    "//ERREUR\r\n//Result : choses",
                    "choses"),
                Tuple.Create(
                    "using System;\r\nusing System.Collections.Generic;\r\n\r\nnamespace EXO6\r\n{\r\n    class Program\r\n    {\r\n        static void Main(string[] args)\r\n        {\r\n            List<string> dinosaurs = new List<int>();\r\n\r\n            dinosaurs.Add(\"Tyrannosaurus\");\r\n            dinosaurs.Add(\"Amargasaurus\");\r\n            dinosaurs.Add(\"Mamenchisaurus\");\r\n            dinosaurs.Add(\"Deinonychus\");\r\n            dinosaurs.Add(\"Compsognathus\");\r\n            foreach (string dinosaur in dinosaurs)\r\n            {\r\n                Console.WriteLine(dinosaur[1]);\r\n            }\r\n        }\r\n    }\r\n\r\n}",
                    "//ERREUR\r\n//Result : Tyrannosaurus\r\nAmargasaurus\r\nMamenchisaurus\r\nDeinonychus\r\nCompsognathus",
                    "Tyrannosaurus\nAmargasaurus\nMamenchisaurus\r\nDeinonychus\r\nCompsognathus\r\n"),
                //Tuple.Create("Exo", "info", "reponse"), Exo 7 readline part 1
                Tuple.Create(
                    "using System;\r\nusing System.Collections.Generic;\r\n\r\nnamespace EXO8 {\r\n    class Program {\r\n        static void Main(string[] args) {\r\n            Dictionary<int, string> dico = new Dictionary<int, string>();\r\n            dico.Add(1, \"Meow\");\r\n            dico.Add(2, \"Chat\");\r\n            dico.Add(3, \"Chien\");\r\n\r\n            foreach(KeyValuePair<int, string> kvp in dico) {\r\n                if(kvp.Key != 0) {\r\n                    Console.WriteLine(\"Key = {0}, Value = {1}\", kvp.Key, kvp.Value);\r\n                }\r\n            }\r\n        }\r\n    }\r\n}",
                    "//ERREUR / MANQUE\r\n//Result uniquement : Key = 2, Value = \"Chat\"",
                    "Key = 2, Value = \"Chat\""),
                Tuple.Create("using System;\r\n\r\nnamespace EXO10 {\r\n    class Program {\r\n        static void Main(string[] args) {\r\n            int blap = Convert.ToInt32(0xFFFFFFFF);\r\n            Console.WriteLine(blap);\r\n        }\r\n    }\r\n}",
                    "// Erreur pas touche au 0xFFFFFFFF\r\n// recherche internet ok\r\n// Result : 4294967295",
                    "4294967295"),
                Tuple.Create(
                    "using System;\r\n\r\nnamespace EXO12 {\r\n    class Program {\r\n        enum Level {\r\n            Low = 4,\r\n            Medium = 5,\r\n            High = 6\r\n        }\r\n        static void Main(string[] args) {\r\n            Level myVar = Level.Medium;\r\n            Console.WriteLine(myVar);\r\n        }\r\n\r\n    }\r\n}",
                    "//ERREUR\r\n//Result : 15",
                    "15"),

                Tuple.Create(
                    "using System;\r\nusing System.Text.RegularExpressions;\r\n\r\nnamespace EXO\r\n{\r\n    class Program\r\n    {\r\n        static void Main(string[] args)\r\n        {\r\n            string data = \"Hello World!\";\r\n            Regex regex = new(\"[0-9]\");\r\n            if(regex.IsMatch(data))\r\n                Console.WriteLine(\"Hello World!\");\r\n            else\r\n                Console.WriteLine(\"doesn't match\");\r\n        }\r\n    }\r\n}",
                    "// Erreur / change\r\n// RESULT : Hello World!",
                    "Hello World!"),
                Tuple.Create(
                    "using System;\r\n\r\nnamespace EXO1\r\n{\r\n    class Program\r\n    {\r\n        static void Main(string[] args)\r\n        {\r\n            int x = 15;\r\n            for (int i = 0; i < x; i++)\r\n            {\r\n                switch(i) {\r\n                    case \"1\":\r\n                    Console.WriteLine($\"Your result: {x} + {i} = \" + (x + i));\r\n                    break;\r\n                    default:\r\n                    Console.WriteLine(\"Error\");\r\n                    break;\r\n                }\r\n            }\r\n        }\r\n    }\r\n}",
                    "// Manquant\r\n// Result : Your result: 15 + 1 = 16 ",
                    "Your result: 15 + 1 = 16"),
                Tuple.Create(
                    "using System;\r\n\r\nnamespace EXO2\r\n{\r\n    class Program\r\n    {\r\n        static void Main(string[] args)\r\n        {\r\n            string EXO2 = 'Askip les cours en c# c'est rigolo';\r\n\r\n                Console.Write(EXO2);\r\n\r\n        }\r\n    }\r\n}",
                    "// ERREUR\r\n// Result : Askip les cours en c# c'est rigolo",
                    "Askip les cours en c# c'est rigolo"),
                Tuple.Create(
                    "using System;\r\n\r\nnamespace EXO3\r\n{\r\n    class Program\r\n    {\r\n        static void Main(string[] args)\r\n        {\r\n            if(byte.MaxValue >= int.MaxValue) {\r\n                Console.WriteLine(\"OK\");\r\n            }else {\r\n                Console.WriteLine(\"NOP\");\r\n            }\r\n        }\r\n    }\r\n}",
                    "//ERREUR operateur logique\r\n//Result : OK",
                    "OK"),
                Tuple.Create(
                    "using System;\r\n\r\nnamespace EXO4\r\n{\r\n    class Program\r\n    {\r\n        static void Main(string[] args)\r\n        {\r\n            string txt = \"Chalut je suis un poti chat\";\r\n            Console.WriteLine(txt.Replace(\" \", \"\"));\r\n        }\r\n    }\r\n}",
                    "//Erreur\r\n//Result : CHALUT JE SUIS UN POTI CHAT",
                    "CHALUT JE SUIS UN POTI CHAT"),
                Tuple.Create(
                    "using System;\r\n\r\nnamespace EXO5\r\n{\r\n    class Program\r\n    {\r\n        static void Main(string[] args)\r\n        {\r\n            try {\r\n                Console.WriteLine(TXT.Truc(\"des choses\"));\r\n            }\r\n            catch(Exception ex) { Console.WriteLine(ex.Message); }\r\n        }\r\n\r\n\r\n    }\r\n\r\n    class TXT\r\n    {\r\n        public static int Truc(string txt)\r\n        {\r\n            txt = txt;\r\n            if(!txt.Contains(\"des\")) return txt.Length;\r\n            else return \"\".Length;\r\n        }\r\n    }\r\n}",
                    "//ERREUR / Manque\r\n//Result : 6",
                    "6"),
                Tuple.Create(
                    "using System;\r\nusing System.Collections.Generic;\r\n\r\nnamespace EXO6\r\n{\r\n    class Program\r\n    {\r\n        static void Main(string[] args)\r\n        {\r\n            List<string> listOne = new();\r\n            listOne.Add(\"One\");\r\n            listOne.Add(\"Two\");\r\n            listOne.Add(\"Three\");\r\n            listOne.Add(\"Four\");\r\n            listOne.Add(\"Five\");\r\n\r\n\r\n            List<string> listTwo = new();\r\n            listTwo.Add(\"A\");\r\n            listTwo.Add(\"B\");\r\n            listTwo.Add(\"C\");\r\n\r\n            listOne.AddRange(listTwo);\r\n            listOne.RemoveRange(0, 0);\r\n\r\n            foreach (string list in listOne)\r\n            {\r\n                Console.WriteLine(list);\r\n            }\r\n        }\r\n    }\r\n\r\n}",
                    "//ERREUR\r\n//Result : \r\n/*\r\nA\r\nB\r\nC\r\n*/",
                    "A\nB\nC"),
                Tuple.Create(
                    "using System;\r\nusing System.Diagnostics;\r\n\r\nnamespace EXO7\r\n{\r\n    class Program\r\n    {\r\n        static void Main(string[] args)\r\n        {\r\n            int hexa = 0xF;\r\n            int Result = 0;\r\n            \r\n            Console.WriteLine(Result);\r\n        }\r\n    }\r\n}",
                    "//Dev\r\n// Convertir 0xF en chiffre\r\n//print le Resuslt\r\n// internet ok",
                    "15"),
                Tuple.Create(
                    "using System;\r\nusing System.Collections.Generic;\r\n\r\nnamespace EXO8 {\r\n    class Program {\r\n\r\n        public static int[] blap0 = new int[] { 104, 101, 108, 108, 111 };\r\n\r\n        public static List<string> meow = new List<string>();\r\n\r\n        static void Main(string[] args) {\r\n\r\n            Console.WriteLine(String.Join(\"\", meow.ToArray()));\r\n        }\r\n\r\n\r\n        public static List<string> Trucnul(int[] rienici) {\r\n            foreach(var s in rienici) {\r\n                meow.Add(euh2(s));\r\n            }\r\n            return meow;\r\n        }\r\n\r\n        public static string euh2(int num) {\r\n            char character = (char)num;\r\n            string text = character.ToString();\r\n            return text;\r\n        }\r\n\r\n    }\r\n\r\n}",
                    "// MANQUE\r\n//Result : Hello",
                    "Hello"),
                //Tuple.Create("Exo", "info", "reponse"), Exo 9 main arg part 2
                Tuple.Create("using System;\r\n\r\nnamespace EXO10 {\r\n    class Program {\r\n        static void Main(string[] args) {\r\n\r\n            //code\r\n\r\n        }\r\n    }\r\n}",
                    "// Dev\r\n// Result : print le min et le max value de int sur la même ligne \" Nombre, Nombre \"",
                    $"{int.MaxValue}, {int.MinValue}"),
                Tuple.Create(
                    "using Newtonsoft.Json;\r\nusing System;\r\nusing System.Net.Http;\r\nusing System.Threading.Tasks;\r\n\r\nnamespace EXO11 {\r\n    class Program {\r\n        static readonly HttpClient client = new HttpClient();\r\n        static async Task Main(string[] args) {\r\n\r\n            HttpResponseMessage response = await client.GetAsync(\"https://jsonplaceholder.typicode.com/todos/1\");\r\n            string responseBody = await response.Content.ReadAsStringAsync();\r\n            Console.WriteLine(responseBody);\r\n\r\n        }\r\n\r\n        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);\r\n        public class Root {\r\n            public int userId { get; set; }\r\n            public int id { get; set; }\r\n            public string title { get; set; }\r\n            public bool completed { get; set; }\r\n        }\r\n    }\r\n}",
                    "//MODIF\r\n// recherche internet ok\r\n// Result : print uniquement le titre \r\n\r\n/*\r\n        delectus aut autem\r\n*/",
                    "delectus aut autem"),
                Tuple.Create(
                    "using System;\r\nusing System.Diagnostics;\r\n\r\nnamespace EXO12 {\r\n    class Program {\r\n        static void Main(string[] args) {\r\n            Process process = new();\r\n            ProcessStartInfo startInfo = new();\r\n\r\n        }\r\n\r\n    }\r\n}",
                    "// Dev\r\n//Result : Ouvrir NotePad.exe avec du c# \r\n//             Process process = new();\r\n//             ProcessStartInfo startInfo = new();\r\n\r\n// internet ok",
                    ""),

                Tuple.Create(
                    "using System;\r\n\r\nnamespace EXO\r\n{\r\n    class Program\r\n    {\r\n        static void PrintPoint(IPoint p)\r\n        {\r\n            Console.WriteLine(\"x={0}, y={1}\", p.X, p.Y);\r\n        }\r\n\r\n        static void Main()\r\n        {\r\n            IPoint p = new Point(2, 3);\r\n            Console.Write(\"My Point: \");\r\n            PrintPoint(p);\r\n        }\r\n\r\n    }\r\n    interface IPoint\r\n    {\r\n        // Property signatures:\r\n        int X\r\n        {\r\n            get;\r\n            private set;\r\n        }\r\n\r\n        int Y\r\n        {\r\n            get;\r\n           private set;\r\n        }\r\n\r\n        double Distance\r\n        {\r\n            get;\r\n        }\r\n    }\r\n\r\n    class Point : IPoint\r\n    {\r\n        // Constructor:\r\n        public Point(int x, int y)\r\n        {\r\n            X = x;\r\n            Y = y;\r\n        }\r\n\r\n        // Property implementation:\r\n        public int X { get; private set; }\r\n\r\n        public int Y { get; private set; }\r\n\r\n        // Property implementation\r\n        public double Distance => Math.Sqrt(X * X + Y * Y);\r\n\r\n    }\r\n}",
                    "// Erreur / change\r\n// RESULT : My Point: x=2, y=3",
                    "My Point: x=2, y=3"),
                //Tuple.Create("Exo", "info", "reponse"), Exo 1 test output
                Tuple.Create("using System;\r\n\r\nnamespace EXO2\r\n{\r\n    class Program\r\n    {\r\n        static void Main(string[] args)\r\n        {\r\n           \r\n            // code ici \r\n\r\n        }\r\n    }\r\n}",
                    "// print l'enum de console color \r\n// Result :\r\n/*  \r\n    Black\r\n    DarkBlue\r\n    DarkGreen\r\n    DarkCyan\r\n    DarkRed\r\n    DarkMagenta\r\n    DarkYellow\r\n    Gray\r\n    DarkGray\r\n    Blue\r\n    Green\r\n    Cyan\r\n    Red\r\n    Magenta\r\n    Yellow\r\n    White\r\n*/",
                    "Black\r\nDarkBlue\r\nDarkGreen\r\nDarkCyan\r\nDarkRed\r\nDarkMagenta\r\nDarkYellow\r\nGray\r\nDarkGray\r\nBlue\r\nGreen\r\nCyan\r\nRed\r\nMagenta\r\nYellow\r\nWhite"),
                Tuple.Create(
                    "using System;\r\nusing System.Threading;\r\n\r\nnamespace EXO3\r\n{\r\n    class Program\r\n    {\r\n        static void Main(string[] args)\r\n        {\r\n            new Thread(() => trouvemoi());\r\n\r\n        }\r\n\r\n        private static void trouvemoi()\r\n        {\r\n            Console.WriteLine(\"blap\");\r\n        }\r\n    }\r\n}",
                    "// print blap\r\n//Result : blap",
                    "blap"),
                //Tuple.Create("Exo", "info", "reponse"), Exo 4 cursor pos part 3
                Tuple.Create(
                    "\r\nusing System;\r\n\r\nnamespace EXO5\r\n{\r\n    class Program\r\n    {\r\n        \r\n        static void Main(string[] args)\r\n        {\r\n            machin();\r\n        }\r\n    }\r\n\r\n    public class truc\r\n    {\r\n       public static void machin()\r\n        {\r\n            Console.WriteLine(\"je suis machin\");\r\n        }\r\n    }\r\n}",
                    "//Manque\r\n//Result : je suis machin",
                    "je suis machin"),
                Tuple.Create(
                    "using System;\r\nusing System.Text;\r\n\r\nnamespace EXO6\r\n{\r\n    class Program\r\n    {\r\n        static string phrase = \"Hellow j'suis une phrase qui vas être mise en base64\";\r\n        static void Main(string[] args)\r\n        {\r\n\r\n        }\r\n    }\r\n\r\n}",
                    "//dev mettre la phrase en base64 puis la remettre normal, internet okay \r\n//Result : \r\n/*\r\n \r\nSABlAGwAbABvAHcAIABqACcAcwB1AGkAcwAgAHUAbgBlACAAcABoAHIAYQBzAGUAIABxAHUAaQAgAHYAYQBzACAA6gB0AHIAZQAgAG0AaQBzAGUAIABlAG4AIABiAGEAcwBlADYANAA=\r\nHellow j'suis une phrase qui vas être mise en base64\r\n*/",
                    "SABlAGwAbABvAHcAIABqACcAcwB1AGkAcwAgAHUAbgBlACAAcABoAHIAYQBzAGUAIABxAHUAaQAgAHYAYQBzACAA6gB0AHIAZQAgAG0AaQBzAGUAIABlAG4AIABiAGEAcwBlADYANAA=\r\nHellow j'suis une phrase qui vas être mise en base64"),
                Tuple.Create(
                    "using System;\r\nusing System.Diagnostics;\r\n\r\nnamespace EXO7\r\n{\r\n    \r\n    interface IPolygon { void calculateArea(int a, int b); }\r\n    interface IColor { void getColor(); }\r\n    \r\n    class Rectangle : IPolygon, IColor {\r\n        public void calculateArea(int a, int b) {\r\n            int area = a * b;\r\n            Console.Write(\"Area of Rectangle: \" + area +\" => \");\r\n        }\r\n        public void getColor() {\r\n            Console.Write(\"Red Rectangle\");\r\n            \r\n        }\r\n    }\r\n    \r\n    class Program \r\n    {\r\n        static void Main(string[] args)\r\n        {\r\n            //Code ici   \r\n            // init class Rectangle\r\n            // set value a et b dans calculateArea\r\n            // chopper la couleur dans getColor\r\n        }\r\n    }\r\n}",
                    "// Dev\r\n// Manque \r\n// Result Area of Rectangle: 20000 => Red Rectangle ",
                    "Area of Rectangle: 20000 => Red Rectangle"),
                Tuple.Create(
                    "using System;\r\nusing System.Collections.Generic;\r\n\r\nnamespace EXO8 {\r\n    class Program {\r\n        \r\n        static void Main(string[] args) \r\n        {\r\n            // init la class Chat\r\n            // get le bool de la class Chat\r\n            // le print \r\n        }\r\n    }\r\n\r\n    public class Chat\r\n    {\r\n       bool ImACat;\r\n\r\n       public Chat()\r\n       {\r\n           ImACat = true;\r\n       }\r\n    } \r\n}\r\n\r\n\r\n// MANQUE\r\n//Result : Hello",
                    "// MANQUE\r\n//Result : Hello",
                    "true"),
                //Tuple.Create("Exo", "info", "reponse"), Exo 9 color print part 3
                //Tuple.Create("Exo", "info", "reponse"), Exo 10 multi cas part 3
                //Tuple.Create("Exo", "info", "reponse"), Exo 11 inifint loop part 3
                Tuple.Create(
                    "using System;\r\nusing System.Diagnostics;\r\n\r\nnamespace EXO12 \r\n{\r\n    class Program \r\n    {\r\n        static void Main(string[] args) \r\n        {\r\n            int nb = 0;\r\n            \r\n            Console.WriteLine(\"NB = nb\");\r\n\r\n        }\r\n\r\n    }\r\n}",
                    "// Erreur \r\n// Result : NB = 0",
                    "NB = 0"),
                Tuple.Create(
                    "using System;\r\nusing System.Security.Cryptography;\r\nusing System.Text;\r\n\r\nnamespace EXO9 {\r\n    class Program {\r\n\r\n\r\n        static void Main(string[] args) {\r\n            string work = \"DES CHOSES\";\r\n            Console.WriteLine(Log.Back(work));\r\n        }\r\n    }\r\n\r\n    public class Log {\r\n        public static string Back(string rawData) {\r\n\r\n            using(SHA256 sha256Hash = SHA256.Create()) {\r\n                //code ICI\r\n            }\r\n        }\r\n    }\r\n}",
                    "// Dev\r\n//convertir un string en SHA256\r\n// recherche internet ok\r\n// RESULT : cfbda284b93b9a8af1ef848808f8983ecd81bf852b02201ce479ca230b08e19e",
                    "cfbda284b93b9a8af1ef848808f8983ecd81bf852b02201ce479ca230b08e19e"),
                Tuple.Create(
                    "using System;\r\nusing System.Net.Http;\r\nusing System.Threading.Tasks;\r\n\r\nnamespace EXO11 {\r\n    class Program {\r\n        static readonly HttpClient client = new HttpClient();\r\n        static async Task Main(string[] args) {\r\n\r\n            HttpResponseMessage response = await client.GetAsync(\"http://www.perdu.com/\");\r\n            response.EnsureSuccessStatusCode();\r\n            string responseBody = await response.Content.ReadAsStringAsync();\r\n            Console.WriteLine(responseBody);\r\n\r\n        }\r\n    }\r\n}",
                    "//MODIF\r\n// recherche internet ok\r\n// Result : \r\n\r\n/*\r\n        Server: Apache\r\n        Upgrade: h2\r\n        Connection: Upgrade\r\n        ETag: \"cc-5344555136fe9\"\r\n        Accept-Ranges: bytes\r\n        Cache-Control: max-age=600\r\n        Vary: Accept-Encoding,User-Agent\r\n*/",
                    "Server: Apache\r\nUpgrade: h2\r\nConnection: Upgrade\r\nETag: \"cc-5344555136fe9\"\r\nAccept-Ranges: bytes\r\nCache-Control: max-age=600\r\nVary: Accept-Encoding,User-Agent")
            };

            return Exo;

        }
    }
}

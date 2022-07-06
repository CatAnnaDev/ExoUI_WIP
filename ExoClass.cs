using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code2
{
    internal class ExoClass
    {

        public List<Tuple<string, string, string>> InitExo()
        {
            var Exo = new List<Tuple<string, string, string>>
            {
                Tuple.Create("using System;\r\n\r\nnamespace EXO1\r\n{\r\n    class Program\r\n    {\r\n        static void Main(string[] args)\r\n        {\r\n            int x = 15;\r\n            for (int i = 0; i < x; i++)\r\n            {\r\n                Console.WriteLine(i);\r\n            }\r\n        }\r\n    }\r\n}", "// Manquant\r\n// Result : 01234567891011121314", "01234567891011121314"),
                Tuple.Create("using System;\r\n\r\nnamespace EXO2\r\n{\r\n    class Program\r\n    {\r\n        static void Main(string[] args)\r\n        {\r\n            string EXO2 = \"Salut je suis \"Psyko\" et j'aime bien Dev des exo a 5h du mat XD\"\r\n\r\n                Console.Write(EXO2);\r\n\r\n        }\r\n    }\r\n}", "//ERREUR\r\n// Result : Salut je suis \"Psyko\" et j'aime bien Dev des exo a 5h du mat XD", "Salut je suis \"Psyko\" et j'aime bien Dev des exo a 5h du mat XD"),
                Tuple.Create("using System;\r\n\r\nnamespace EXO3\r\n{\r\n    class Program\r\n    {\r\n        static void Main(string[] args)\r\n        {\r\n            Console.WriteLine(Truc(5,10f));\r\n        }\r\n\r\n        private static int Truc(int num, float num2)\r\n        {\r\n            int result = num + num2;\r\n            return result;\r\n        }\r\n    }\r\n}", "//ERREUR\r\n//Result : 15", "15"),
                Tuple.Create("using System;\r\n\r\nnamespace EXO4\r\n{\r\n    class Program\r\n    {\r\n        static void Main(string[] args)\r\n        {\r\n            string[] blap = { \"Blap\", \"Blap1\", \"Blap2\", \"blap3\" };\r\n            foreach (int S in blap)  Console.WriteLine(S);\r\n        }\r\n    }\r\n}", "//Manque\r\n//Result : BLAP BLAP1 BLAP2 BLAP3", "BLAP BLAP1 BLAP2 BLAP3"),
                Tuple.Create("using System;\r\n\r\nnamespace EXO5\r\n{\r\n    class Program\r\n    {\r\n        static void Main(string[] args)\r\n        {\r\n            Console.WriteLine(TXT.Truc(\"des choses\"));\r\n        }\r\n\r\n\r\n    }\r\n\r\n    class TXT\r\n    {\r\n        private static string Truc(string txt)\r\n        {\r\n            return txt.Substring(0);\r\n        }\r\n    }\r\n}", "//ERREUR\r\n//Result : choses", "choses"),
                Tuple.Create("using System;\r\nusing System.Collections.Generic;\r\n\r\nnamespace EXO6\r\n{\r\n    class Program\r\n    {\r\n        static void Main(string[] args)\r\n        {\r\n            List<string> dinosaurs = new List<int>();\r\n\r\n            dinosaurs.Add(\"Tyrannosaurus\");\r\n            dinosaurs.Add(\"Amargasaurus\");\r\n            dinosaurs.Add(\"Mamenchisaurus\");\r\n            dinosaurs.Add(\"Deinonychus\");\r\n            dinosaurs.Add(\"Compsognathus\");\r\n            foreach (string dinosaur in dinosaurs)\r\n            {\r\n                Console.WriteLine(dinosaur[1]);\r\n            }\r\n        }\r\n    }\r\n\r\n}", "//ERREUR\r\n//Result : Tyrannosaurus\r\nAmargasaurus\r\nMamenchisaurus\r\nDeinonychus\r\nCompsognathus", "Tyrannosaurus\r\nAmargasaurus\r\nMamenchisaurus\r\nDeinonychus\r\nCompsognathus"),
                Tuple.Create("Exo", "info", "reponse"),
                Tuple.Create("Exo", "info", "reponse"),
                Tuple.Create("Exo", "info", "reponse"),
                Tuple.Create("Exo", "info", "reponse"),
                Tuple.Create("Exo", "info", "reponse"),
                Tuple.Create("Exo", "info", "reponse"),
                Tuple.Create("Exo", "info", "reponse"),

                Tuple.Create("Exo", "info", "reponse"),
                Tuple.Create("Exo", "info", "reponse"),
                Tuple.Create("Exo", "info", "reponse"),
                Tuple.Create("Exo", "info", "reponse"),
                Tuple.Create("Exo", "info", "reponse"),
                Tuple.Create("Exo", "info", "reponse"),
                Tuple.Create("Exo", "info", "reponse"),
                Tuple.Create("Exo", "info", "reponse"),
                Tuple.Create("Exo", "info", "reponse"),
                Tuple.Create("Exo", "info", "reponse"),
                Tuple.Create("Exo", "info", "reponse"),
                Tuple.Create("Exo", "info", "reponse"),
                Tuple.Create("Exo", "info", "reponse"),

                Tuple.Create("Exo", "info", "reponse"),
                Tuple.Create("Exo", "info", "reponse"),
                Tuple.Create("Exo", "info", "reponse"),
                Tuple.Create("Exo", "info", "reponse"),
                Tuple.Create("Exo", "info", "reponse"),
                Tuple.Create("Exo", "info", "reponse"),
                Tuple.Create("Exo", "info", "reponse"),
                Tuple.Create("Exo", "info", "reponse"),
                Tuple.Create("Exo", "info", "reponse"),
                Tuple.Create("Exo", "info", "reponse"),
                Tuple.Create("Exo", "info", "reponse"),
                Tuple.Create("Exo", "info", "reponse"),
                Tuple.Create("Exo", "info", "reponse")
            };

            return Exo;

        }
    }
}

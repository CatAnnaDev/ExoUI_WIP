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
                Tuple.Create("using System;\r\n\r\nnamespace EXO2\r\n{\r\n    class Program\r\n    {\r\n        static void Main(string[] args)\r\n        {\r\n            string EXO2 = \"Salut je suis \"Psyko\" et j'aime bien Dev des exo à 5h du mat XD\"\r\n\r\n                Console.Write(EXO2);\r\n\r\n        }\r\n    }\r\n}", "//ERREUR\r\n// Result : Salut je suis \"Psyko\" et j'aime bien Dev des exo à 5h du mat XD", "Salut je suis \"Psyko\" et j'aime bien Dev des exo à 5h du mat XD"),
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

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
                Tuple.Create("using System;\r\n\r\nnamespace EXO\r\n{\r\n    class Program\r\n    {\r\n        static void Main(string[] args)\r\n        {\r\n            console.WriteLine(\"Hello World!\");\r\n        }\r\n    }\r\n}", "// Erreur\r\n// RESULT : Hello World!", "Hello World!"),
                Tuple.Create("using System;\r\n\r\nnamespace EXO1\r\n{\r\n    class Program\r\n    {\r\n        static void Main(string[] args)\r\n        {\r\n            int x = 15;\r\n            for (int i = 0; i < x; i++)\r\n            {\r\n                Console.WriteLine(i);\r\n            }\r\n        }\r\n    }\r\n}", "// Manquant\r\n// Result : 01234567891011121314", "01234567891011121314"),
                Tuple.Create("using System;\r\n\r\nnamespace EXO2\r\n{\r\n    class Program\r\n    {\r\n        static void Main(string[] args)\r\n        {\r\n            string EXO2 = \"Salut je suis \"Psyko\" et j'aime bien Dev des exo a 5h du mat XD\"\r\n\r\n                Console.Write(EXO2);\r\n\r\n        }\r\n    }\r\n}", "//ERREUR\r\n// Result : Salut je suis \"Psyko\" et j'aime bien Dev des exo a 5h du mat XD", "Salut je suis \"Psyko\" et j'aime bien Dev des exo a 5h du mat XD"),
                Tuple.Create("using System;\r\n\r\nnamespace EXO3\r\n{\r\n    class Program\r\n    {\r\n        static void Main(string[] args)\r\n        {\r\n            Console.WriteLine(Truc(5,10f));\r\n        }\r\n\r\n        private static int Truc(int num, float num2)\r\n        {\r\n            int result = num + num2;\r\n            return result;\r\n        }\r\n    }\r\n}", "//ERREUR\r\n//Result : 15", "15"),
                Tuple.Create("using System;\r\n\r\nnamespace EXO4\r\n{\r\n    class Program\r\n    {\r\n        static void Main(string[] args)\r\n        {\r\n            string[] blap = { \"Blap\", \"Blap1\", \"Blap2\", \"blap3\" };\r\n            foreach (int S in blap)  Console.WriteLine(S);\r\n        }\r\n    }\r\n}", "//Manque\r\n//Result : BLAP BLAP1 BLAP2 BLAP3", "BLAP BLAP1 BLAP2 BLAP3"),
                Tuple.Create("using System;\r\n\r\nnamespace EXO5\r\n{\r\n    class Program\r\n    {\r\n        static void Main(string[] args)\r\n        {\r\n            Console.WriteLine(TXT.Truc(\"des choses\"));\r\n        }\r\n\r\n\r\n    }\r\n\r\n    class TXT\r\n    {\r\n        private static string Truc(string txt)\r\n        {\r\n            return txt.Substring(0);\r\n        }\r\n    }\r\n}", "//ERREUR\r\n//Result : choses", "choses"),
                Tuple.Create("using System;\r\nusing System.Collections.Generic;\r\n\r\nnamespace EXO6\r\n{\r\n    class Program\r\n    {\r\n        static void Main(string[] args)\r\n        {\r\n            List<string> dinosaurs = new List<int>();\r\n\r\n            dinosaurs.Add(\"Tyrannosaurus\");\r\n            dinosaurs.Add(\"Amargasaurus\");\r\n            dinosaurs.Add(\"Mamenchisaurus\");\r\n            dinosaurs.Add(\"Deinonychus\");\r\n            dinosaurs.Add(\"Compsognathus\");\r\n            foreach (string dinosaur in dinosaurs)\r\n            {\r\n                Console.WriteLine(dinosaur[1]);\r\n            }\r\n        }\r\n    }\r\n\r\n}", "//ERREUR\r\n//Result : Tyrannosaurus\r\nAmargasaurus\r\nMamenchisaurus\r\nDeinonychus\r\nCompsognathus", "Tyrannosaurus\nAmargasaurus\nMamenchisaurus\r\nDeinonychus\r\nCompsognathus\r\n"),
                //Tuple.Create("Exo", "info", "reponse"), Exo 7
                Tuple.Create("using System;\r\nusing System.Collections.Generic;\r\n\r\nnamespace EXO8 {\r\n    class Program {\r\n        static void Main(string[] args) {\r\n            Dictionary<int, string> dico = new Dictionary<int, string>();\r\n            dico.Add(1, \"Meow\");\r\n            dico.Add(2, \"Chat\");\r\n            dico.Add(3, \"Chien\");\r\n\r\n            foreach(KeyValuePair<int, string> kvp in dico) {\r\n                if(kvp.Key != 0) {\r\n                    Console.WriteLine(\"Key = {0}, Value = {1}\", kvp.Key, kvp.Value);\r\n                }\r\n            }\r\n        }\r\n    }\r\n}", "//ERREUR / MANQUE\r\n//Result uniquement : Key = 2, Value = \"Chat\"", "Key = 2, Value = \"Chat\""),
                Tuple.Create("using System;\r\nusing System.Security.Cryptography;\r\n\r\nnamespace EXO9 {\r\n    class Program {\r\n\r\n\r\n        static void Main(string[] args) {\r\n            string work = \"DES CHOSES\";\r\n            Console.WriteLine(Log.Back(work));\r\n        }\r\n    }\r\n\r\n    public class Log {\r\n        public static string Back(string rawData) {\r\n\r\n            using(SHA256 sha256Hash = SHA256.Create()) {\r\n                //code ICI\r\n            }\r\n        }\r\n    }\r\n}", "// Dev\r\n//convertir un string en SHA256\r\n// recherche internet ok\r\n// RESULT : cfbda284b93b9a8af1ef848808f8983ecd81bf852b02201ce479ca230b08e19e", "cfbda284b93b9a8af1ef848808f8983ecd81bf852b02201ce479ca230b08e19e"),
                Tuple.Create("using System;\r\n\r\nnamespace EXO10 {\r\n    class Program {\r\n        static void Main(string[] args) {\r\n            int blap = Convert.ToInt32(0xFFFFFFFF);\r\n            Console.WriteLine(blap);\r\n        }\r\n    }\r\n}", "// Erreur pas touche au 0xFFFFFFFF\r\n// recherche internet ok\r\n// Result : 4294967295", "4294967295"),
                Tuple.Create("using System;\r\nusing System.Net.Http;\r\nusing System.Threading.Tasks;\r\n\r\nnamespace EXO11 {\r\n    class Program {\r\n        static readonly HttpClient client = new HttpClient();\r\n        static async Task Main(string[] args) {\r\n\r\n            HttpResponseMessage response = await client.GetAsync(\"http://www.perdu.com/\");\r\n            response.EnsureSuccessStatusCode();\r\n            string responseBody = await response.Content.ReadAsStringAsync();\r\n            Console.WriteLine(responseBody);\r\n\r\n        }\r\n    }\r\n}", "//MODIF\r\n// recherche internet ok\r\n// Result : \r\n\r\n/*\r\n        Server: Apache\r\n        Upgrade: h2\r\n        Connection: Upgrade\r\n        ETag: \"cc-5344555136fe9\"\r\n        Accept-Ranges: bytes\r\n        Cache-Control: max-age=600\r\n        Vary: Accept-Encoding,User-Agent\r\n*/", "Server: Apache\r\nUpgrade: h2\r\nConnection: Upgrade\r\nETag: \"cc-5344555136fe9\"\r\nAccept-Ranges: bytes\r\nCache-Control: max-age=600\r\nVary: Accept-Encoding,User-Agent"),
                Tuple.Create("using System;\r\n\r\nnamespace EXO12 {\r\n    class Program {\r\n        enum Level {\r\n            Low = 4,\r\n            Medium = 5,\r\n            High = 6\r\n        }\r\n        static void Main(string[] args) {\r\n            Level myVar = Level.Medium;\r\n            Console.WriteLine(myVar);\r\n        }\r\n\r\n    }\r\n}", "//ERREUR\r\n//Result : 15", "15"),

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

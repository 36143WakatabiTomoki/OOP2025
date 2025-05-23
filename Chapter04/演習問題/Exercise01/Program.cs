
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            List<string> langs = [
                "C#", "Java", "Ruby", "PHP", "Python", "TypeScript",
                "JavaScript", "Swift", "Go",
            ];

            Exercise1(langs);
            Console.WriteLine("---");
            Exercise2(langs);
            Console.WriteLine("---");
            Exercise3(langs);
        }

        private static void Exercise1(List<string> langs) {
            foreach (var n in langs) {
                if(n.Contains('S')) {
                    Console.WriteLine(n);
                }
            }

            Console.WriteLine();

            for (int count = 0; count < langs.Count; count++) {
                if (langs[count].Contains('S')) {
                    Console.WriteLine(langs[count]);
                }
            }

            Console.WriteLine();

            while (true) {
                foreach (var n in langs) {
                    if (n.Contains('S')) {
                        Console.WriteLine(n);
                    }
                }
                break;
            }

            Console.WriteLine();
        }

        private static void Exercise2(List<string> langs) {
            var name = langs.Where(n => n.Contains('S')).ToArray();
            foreach (var select in name) {
                Console.WriteLine(select);
            }
        }

        private static void Exercise3(List<string> langs) {
            var lang = langs.Find(n => n.Length == 10);
            Console.WriteLine(lang ??= "unknown");
        }
    }
}


using System.Text;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz";

            Console.WriteLine("6.3.1");
            Exercise1(text);

            Console.WriteLine("6.3.2");
            Exercise2(text);

            Console.WriteLine("6.3.3");
            Exercise3(text);

            Console.WriteLine("6.3.4");
            Exercise4(text);

            Console.WriteLine("6.3.5");
            Exercise5(text);

        }

        private static void Exercise1(string text) {
            var space = text.Count(t => text.Contains(""));
            Console.WriteLine(space);

            if(text.Contains(' ')) {
                Console.WriteLine(space);
            }
        }

        private static void Exercise2(string text) {
            Console.WriteLine(text.Replace("big", "small"));
        }

        private static void Exercise3(string text) {
            string[] words = text.Split(' ');
            var sb = new StringBuilder();
            foreach (var word in words) {
                sb.Append(word + " ");
            }
            var texts = sb.ToString();
            Console.WriteLine(texts.Trim());
        }

        private static void Exercise4(string text) {
            string[] words = text.Split(' ');
            Console.WriteLine("単語数：" + words.Count());
        }

        private static void Exercise5(string text) {
            var words = text.Split(' ');
            foreach (var word in words) {
                if(word.Length <= 4) {
                    Console.WriteLine(word);
                }
            }
        }
    }
}

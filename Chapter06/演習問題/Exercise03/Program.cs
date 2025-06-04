using System;
using System.Globalization;
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

            Console.WriteLine("6.3.99");
            Exercise6(text);

        }


        private static void Exercise1(string text) {
            //var space = text.Count(t => text.Contains(' '));
            var space = text.Count(c => c == ' ');
            //var space = text.Count(char.IsWhiteSpace);

            Console.WriteLine("空白数：{0}", space);
        }

        private static void Exercise2(string text) {
            Console.WriteLine(text.Replace("big", "small"));
        }

        private static void Exercise3(string text) {
            string[] words = text.Split(' ');
            var sb = new StringBuilder(words[0]);
            foreach (var word in words.Skip(1)) {
                sb.Append(" ");
                sb.Append(word);
            }
            Console.WriteLine(sb + " ");
        }

        private static void Exercise4(string text) {
            string[] words = text.Split(' ');
            Console.WriteLine("単語数：" + words.Count());
        }

        private static void Exercise5(string text) {
            var words = text.Split(' ');
            foreach (var word in words) {
                if (word.Length <= 4) {
                    Console.WriteLine(word);
                }
            }
        }

        private static void Exercise6(string text) {
            Console.WriteLine("文字列：" + text);
            Console.WriteLine();
            Console.WriteLine("出現アルファベットの個数");
            var alphabet = "abcdefghijklmnopqrstuvwxyz";
            var cultureInfo = new CultureInfo("ja-JP");
            int count = 0;
            foreach (var alphabetsolo in alphabet) {
                String alphabetString = alphabetsolo.ToString();
                foreach (var word in text) {
                    String wordString = word.ToString();
                    if (String.Compare(wordString, alphabetString, cultureInfo, CompareOptions.IgnoreCase) == 0) {
                        count++;
                    }
                }
                Console.WriteLine($"{alphabetsolo}：{count}");
                count = 0;
            }
        }
    }
}

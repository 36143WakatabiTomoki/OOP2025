namespace Exercise04 {
    internal class Program {
        static void Main(string[] args) {
            var line = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";
            string[] words = line.Split(';', '=');
            for(int i = 0;i < words.Length;i+=2) {
                Console.WriteLine(ToJapanese(words[i]) + "：" + ToJapanese(words[i+1]));
            }
        }

        /// <summary>
        /// 引数の単語を日本語へ変換します
        /// </summary>
        /// <param name="key">"Novelist","BestWork","Born"</param>
        /// <returns>"「作家」,「代表作」,「誕生年」</returns>
        static string ToJapanese(string key) {
            switch (key) {
                case "Novelist":
                    return "作家";
                    break;
                case "BestWork":
                    return "代表作";
                    break;
                case "Born":
                    return "誕生年";
                    break;
                default:
                    return key;
            }
        }
    }
}
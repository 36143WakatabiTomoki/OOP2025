namespace Exercise04 {
    internal class Program {
        static void Main(string[] args) {
            var line = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";
            string[] words = line.Split(';', '=');

            //foreach (var pair in line.Split(';')) {
            //    var word = pair.Split('=');
            //    Console.WriteLine($"{ToJapanese(word[0])}：{ToJapanese(word[1])}");
            //}

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
            return key switch {
                "Novelist" => "作家",
                "BestWork" => "代表作",
                "Born" => "誕生年",
                _ => key
            };
            //switch (key) {
            //    case "Novelist":
            //        return "作家";
            //    case "BestWork":
            //        return "代表作";
            //    case "Born":
            //        return "誕生年";
            //    default:
            //        return key;
            //}
        }
    }
}
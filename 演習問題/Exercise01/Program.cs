using System.Globalization;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            string? temp1 = Console.ReadLine();
            string? temp2 = Console.ReadLine();

            var cultureinfo = new CultureInfo("ja-JP");
            if (String.Compare(temp1, temp2, cultureinfo, CompareOptions.IgnoreKanaType) == 0) {
                Console.WriteLine("一致しています");
            } else {
                Console.WriteLine("一致していません");
            }
        }
    }
}

using TextFileProcessor;

namespace LineCounter {
    internal class Program {
        static void Main(string[] args) {
            Console.Write("読み込むファイル：");
            string path = Console.ReadLine();
            if (!File.Exists(path)) {
                Console.WriteLine("ファイルが見つかりませんでした");
                return;
            }
            TextProcessor.Run<LineCounterProcessor>(path);
        }
    }
}

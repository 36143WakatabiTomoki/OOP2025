namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            var readTextPath = "走れメロス.txt";
            var writeTextPath = "writeLineText.txt";
            int count = 1;
            using (var writer = new StreamWriter(writeTextPath)) {
                foreach (var line in File.ReadLines(readTextPath)) {
                    writer.WriteLine($"{count} {line}");
                    count++;
                }
            }
        }
    }
}

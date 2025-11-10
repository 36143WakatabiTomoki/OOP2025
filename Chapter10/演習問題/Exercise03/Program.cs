namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("");
            var firstTextFile = Console.ReadLine();
            Console.WriteLine();
            var endTextFile = Console.ReadLine();

            using (var writer = new StreamWriter(firstTextFile, append: true)) {
                foreach (var line in File.ReadLines(endTextFile)) {
                    writer.WriteLine(line);
                }
            }
        }
    }
}

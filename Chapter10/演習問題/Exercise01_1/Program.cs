namespace Exercise01_1 {
    internal class Program {
        static void Main(string[] args) {
            var readTextPath = "Library.cs";
            CountClass(readTextPath);
        }

        public static void CountClass(string readTextName) {
            int count = 0;
            if (File.Exists(readTextName)) {
                using var readText = new StreamReader(readTextName);
                while (!readText.EndOfStream) {
                    var line = readText.ReadLine();
                    if (line.Contains("class")) {
                        count++;
                    }
                }
                Console.WriteLine(count);
            }
        }
    }
}

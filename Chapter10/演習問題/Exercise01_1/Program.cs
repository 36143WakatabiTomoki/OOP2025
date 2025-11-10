namespace Exercise01_1 {
    internal class Program {
        static void Main(string[] args) {
            var readTextPath = "Library.cs";
            Console.WriteLine(CountClass(readTextPath));
        }

        //10.1_1
        //public static int CountClass(string readTextName) {
        //    int count = 0;
        //    if (File.Exists(readTextName)) {
        //        using var readText = new StreamReader(readTextName);
        //        while (!readText.EndOfStream) {
        //            var line = readText.ReadLine();
        //            if (line.Contains("class")) {
        //                count++;
        //            }
        //        }
        //    }
        //    return count;
        //}

        //10.1_2
        public static int CountClass(string readTextName) {
            int count = 0;
            var readText = File.ReadAllLines(readTextName);
            foreach (var line in readText) {
                if(line.Contains("class")) {
                    count++;
                }
            }
            return count;
        }

        //10.1_3
    }
}

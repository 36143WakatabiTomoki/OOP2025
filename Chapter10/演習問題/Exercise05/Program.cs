namespace Exercise05 {
    internal class Program {
        static void Main(string[] args) {
            var di = new DirectoryInfo("C:\\Users\\infosys\\source\\repos\\OOP2025\\Chapter10\\演習問題\\Exercise05\\File");
            var files = di.EnumerateFiles("*");
            foreach (var file in files) {
                File.Copy($"{file}", $"{file.Name}", overwrite:true);
            }
        }
    }
}

namespace Exercise04 {
    internal class Program {
        static void Main(string[] args) {
            var di = new DirectoryInfo("C:\\Users\\infosys\\source\\repos\\OOP2025");
            var fileSystems = di.EnumerateFiles();
            foreach (var item in fileSystems) {
                if(item.Length >= 1048576) {
                    Console.WriteLine(item.Name);
                }
            }
        }
    }
}

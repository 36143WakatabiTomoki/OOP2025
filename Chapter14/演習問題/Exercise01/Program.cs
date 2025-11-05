namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var texta = File.ReadLinesAsync("走れメロス.txt");
            Console.WriteLine(texta);
        }
    }
}

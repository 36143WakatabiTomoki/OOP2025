
namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            Exercise1();
            Console.WriteLine("---");
            Exercise2();
            Console.WriteLine("---");
            Exercise3();
        }

        private static void Exercise1() {
            var number = int.Parse(Console.ReadLine());
            if(number < 0 || number >= 500) {
                Console.WriteLine(number);
            }else if(number < 100) {
                Console.WriteLine(number * 2);
            }else if(number < 500) {
                Console.WriteLine(number * 3);
            }else {
                Console.WriteLine("入力値に誤りがあります");
            }
        }

        private static void Exercise2() {
            var number = int.Parse(Console.ReadLine());
            switch (number) {
                case < 0 or >= 500:
                    Console.WriteLine(number);
                    break;
                case < 100:
                    Console.WriteLine(number * 2);
                    break;
                case < 500:
                    Console.WriteLine(number * 3);
                    break;
                case :
                    Console.WriteLine("入力値に誤りがあります");
                    break;
            }
        }

        private static void Exercise3() {
        }
    }
}

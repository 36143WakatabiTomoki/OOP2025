﻿
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            int[] numbers = [5, 10, 17, 9, 3, 21, 10, 40, 21, 3, 35];

            Console.WriteLine("7.1.1");
            Exercise1(numbers);

            Console.WriteLine("7.1.2");
            Exercise2(numbers);

            Console.WriteLine("7.1.3");
            Exercise3(numbers);

            Console.WriteLine("7.1.4");
            Exercise4(numbers);

            Console.WriteLine("7.1.5");
            Exercise5(numbers);
        }

        private static void Exercise1(int[] numbers) {
            Console.WriteLine(numbers.Max());
        }

        private static void Exercise2(int[] numbers) {
            // numbers.TakeLast(2).ToList().ForEach(Console.WriteLine);

            foreach (var number in numbers.Skip(numbers.Count() - 2)) {
                Console.WriteLine(number);
            }
        }

        private static void Exercise3(int[] numbers) {
            var number = numbers.Select(n => n.ToString("000").ToArray());
            foreach (var count in number) {
                Console.WriteLine(count);
            }
        }

        private static void Exercise4(int[] numbers) {
            var number = numbers.OrderBy(n => n).Take(3).ToArray();
            foreach (var count in number) {
                Console.WriteLine(count);
            }
        }

        private static void Exercise5(int[] numbers) {
            var number = numbers.Distinct().ToList();
            Console.WriteLine(number.Where(n => n > 10).Count());
        }
    }
}


namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            Exercise1_2();
            Console.WriteLine();
            Exercise1_3();
            Console.WriteLine();
            Exercise1_4();
            Console.WriteLine();
            Exercise1_5();
            Console.WriteLine();
            Exercise1_6();
            Console.WriteLine();
            Exercise1_7();
            Console.WriteLine();
            Exercise1_8();

            Console.ReadLine();
        }

        private static void Exercise1_2() {
            var Book = Library.Books
                .MaxBy(b => b.Price);
            Console.WriteLine(Book);
        }

        private static void Exercise1_3() {
            var YearBookCount = Library.Books
                .GroupBy(b => b.PublishedYear)
                .OrderBy(b => b.Key)
                .Select(x => new {
                    YearName = x.Key,
                    YearCount = x.Count(),
                });

            foreach (var YearCount in YearBookCount) {
                Console.WriteLine($"{YearCount.YearName}: {YearCount.YearCount}");
            }
        }

        private static void Exercise1_4() {
            var Book = Library.Books
                .OrderByDescending(b => b.PublishedYear)
                .ThenByDescending(b => b.Price);

            foreach (var item in Book) {
                Console.WriteLine($"{item.PublishedYear}年 {item.Price}円 {item.Title}");
            }
        }

        private static void Exercise1_5() {
            var bookCategory = Library.Books
        }

        private static void Exercise1_6() {
        }

        private static void Exercise1_7() {
        }

        private static void Exercise1_8() {
        }
    }
}


using System.Text.RegularExpressions;

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
                .Where(b => b.PublishedYear == 2022)
                .Join(Library.Categories,
                    book => book.CategoryId,
                    Category => Category.Id,
                    (book, category) => new {
                        Category = category.Name
                    })
                .Distinct();

            foreach (var name in bookCategory) {
                Console.WriteLine(name.Category);
            }
        }

        private static void Exercise1_6() {
            var categoryName = Library.Books
                .Join(Library.Categories,
                    book => book.CategoryId,
                    Category => Category.Id,
                    (book, category) => new {
                        Category = category.Name,
                        book = book.Title
                    })
                .GroupBy(b => b.Category)
                .OrderBy(b => b.Key);

            foreach (var item in categoryName) {
                Console.WriteLine($"# {item.Key}");
                foreach (var name in item) {
                    Console.WriteLine($"    {name.book}");
                }
            }
        }

        private static void Exercise1_7() {
            var development = Library.Categories
                .Where(x => x.Name.Equals("Development"))
                .Join(Library.Books,
                c => c.Id,
                b => b.CategoryId,
                (c, b) => new {
                    b.PublishedYear,
                    b.Title
                })
                .GroupBy(x => x.PublishedYear)
                .OrderBy(x => x.Key);

            foreach (var item in development) {
                Console.WriteLine($"# {item.Key}");
                foreach (var title in item) {
                    Console.WriteLine($"    {title.Title}");
                }
            }
        }

        private static void Exercise1_8() {
            var books = Library.Categories
                .GroupJoin(Library.Books,
                c => c.Id,
                b => b.CategoryId,
                (c, b) => new {
                    c.Name,
                    Count = b.Count()
                })
                .Where(x => x.Count >= 4);

            foreach (var book in books) {
                Console.WriteLine(book.Name);
            }
        }
    }
}

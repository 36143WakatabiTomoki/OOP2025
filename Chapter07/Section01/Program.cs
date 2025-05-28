namespace Section01 {
    internal class Program {
        static void Main(string[] args) {

            var books = Books.GetBooks();

            // 本の平均金額を表示
            Console.WriteLine(books.Average(n => n.Price));

            //本のページ合計を表示
            Console.WriteLine(books.Sum(n => n.Pages));

            // 金額の安い書籍名と金額を表示
            var lowPriceBook = books.Where(x => x.Price == books.Min(b => b.Price));
            foreach (var item in lowPriceBook) {
                Console.WriteLine(item.Title + "：" + item.Price);
            }

            // ページが多い書籍名とページ数を表示
            var upPagebook = books.Where(x => x.Pages == books.Max(b => b.Pages));
            foreach (var item in upPagebook) {
                Console.WriteLine(item.Title + "：" + item.Pages + "ページ");
            }

            // タイトルに「物語」が含まれている書籍名をすべて表示
            var book = books.Where(n => n.Title.Contains("物語")).ToArray();
            foreach (var bookname in book) {
                Console.WriteLine(bookname.Title);
            }
        }
    }
}

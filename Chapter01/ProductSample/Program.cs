namespace ProductSample {
    internal class Program {
        static void Main(string[] args) {

            Product karinto = new Product(123, "かりんとう", 180);

            Product kasutera = new Product(222, "カステラ", 222);


            //税抜きの価格を表示【かりんとうの税抜き価格は○○円です】

            Console.WriteLine(karinto.Name + "の税抜き価格は" + karinto.Price + "円です");

            //消費税額の表示【かりんとうの消費税額は○○円です】

            Console.WriteLine(karinto.Name + "の消費税額は" + karinto.GetTax() + "円です");

            //税込み価格の表示【かりんとうの税込み価格は○○円です】

            Console.WriteLine(karinto.Name + "の税込み価格は" + karinto.GetPriceIncludingTax() + "円です");



            Console.WriteLine(kasutera.Name + "の税抜き価格は" + kasutera.Price + "円です");

            Console.WriteLine(kasutera.Name + "の消費税額は" + kasutera.GetTax() + "円です");

            Console.WriteLine(kasutera.Name + "の税込み価格は" + kasutera.GetPriceIncludingTax() + "円です");

        }
    }
}

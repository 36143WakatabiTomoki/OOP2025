using System.Diagnostics.Metrics;
using System.Threading;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {

            Console.WriteLine("***　変換アプリ　***");
            Console.WriteLine("１：ヤードからメートル");
            Console.WriteLine("２：メートルからヤード");
            Console.Write("＞");
            int check = int.Parse(Console.ReadLine());


            if (check == 1) {
                Console.Write("変換前(ヤード)：");
                int change = int.Parse(Console.ReadLine());
                PrintYardToMeterList(change);
            } else if (check == 2) {
                Console.Write("変換前(メートル)：");
                int change = int.Parse(Console.ReadLine());
                PrintMeterToYardList(change);
            /*} else if (check == 3) {
                PrintInchToMeterList(start, end);
            } else if (check == 4) {
                PrintMeterToInchList(start, end);*/
            } else {
                Console.WriteLine("Error");
            }
        }

        /*
        // インチからメートルへの対応表を出力
        static void PrintInchToMeterList(int start, int end) {
            for (int Inch = start; Inch <= end; Inch++) {
                double meter = FromInch(Inch);
                Console.WriteLine($"{Inch} inch = {meter:0.0000} m");
            }
        }

        // メートルからインチへの対応表を出力
        static void PrintMeterToInchList(int start, int end) {
            for (int Meter = start; Meter <= end; Meter++) {
                double inch = ToInch(Meter);
                Console.WriteLine($"{Meter} m = {inch:0.0000} inch");
            }
        }*/

        // ヤードからメートルへの対応表を出力
        static void PrintYardToMeterList(int change) {
            double meter = FromYard(change);
            Console.WriteLine($"変換後(メートル)：{meter:0.000}");
        }

        // メートルからヤードへの対応表を出力
        static void PrintMeterToYardList(int change) {
            double yard = ToYard(change);
            Console.WriteLine($"変換後(ヤード)：{yard:0.000}");
        }

        /*
        // インチからメートルを求める
        public static double FromInch(double Inch) {
            return Inch * 0.0254;
        }

        // メートルからインチを求める
        public static double ToInch(double Meter) {
            return Meter / 0.0254;
        }*/

        // ヤードからメートルを求める
        public static double FromYard(double Yard) {
            return Yard * 0.9144;
        }

        // メートルからヤードを求める
        public static double ToYard(double Meter) {
            return Meter / 1.09361;
        }
    }
}

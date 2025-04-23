namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {

            Console.WriteLine("***　変換アプリ　***");
            Console.WriteLine("１：ヤードからメートル");
            Console.WriteLine("２：メートルからヤード");
            Console.Write("＞");
            int check = int.Parse(Console.ReadLine());

            Console.Write("はじめ：");
            int start = int.Parse(Console.ReadLine());

            Console.Write("おわり：");
            int end = int.Parse(Console.ReadLine());


            if (check == 1) {
                PrintYardToMeterList(start, end);
            } else if (check == 2) {
                PrintMeterToYardList(start, end);
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
        static void PrintYardToMeterList(int start, int end) {
            for (int Yard = start; Yard <= end; Yard++) {
                double meter = FromYard(Yard);
                Console.WriteLine($"{Yard} yard = {meter:0.000} m");
            }
        }

        // メートルからヤードへの対応表を出力
        static void PrintMeterToYardList(int start, int end) {
            for (int Meter = start; Meter <= end; Meter++) {
                double yard = ToYard(Meter);
                Console.WriteLine($"{Meter} m = {yard:0.000} yard");
            }
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
            return Meter / 0.9144;
        }
    }
}

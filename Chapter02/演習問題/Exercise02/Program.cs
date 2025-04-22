namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {

            PrintInchToMeterList();            
        }

        // インチからメートルへの対応表を出力
        static void PrintInchToMeterList() {
            for (int Inch = 1; Inch <= 10; Inch++) {
                double meter = FromInch(Inch);
                Console.WriteLine($"{Inch} inch = {meter:0.0000} m");
            }
        }

        // インチからメートルを求める
        public static double FromInch(double Inch) {
            return Inch * 0.0254;
        }
    }
}

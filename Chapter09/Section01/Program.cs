using System.Globalization;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var today = new DateTime(2025, 7, 12); //日付
            var now = DateTime.Now; //日付と時刻


            Console.WriteLine($"Today：{today}");
            Console.WriteLine($"Now：{now}");

            //①自分の生年月日は何曜日かをプログラムを書いて調べる
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();

            Console.WriteLine("日付を入力");
            Console.Write("西暦：");
            var year = int.Parse(Console.ReadLine());
            Console.Write("月：");
            var month = int.Parse(Console.ReadLine());
            Console.Write("日：");
            var day = int.Parse(Console.ReadLine());

            var mybir = new DateTime(year, month, day);

            var dayOfWeek = culture.DateTimeFormat.GetDayName(mybir.DayOfWeek);
            var str = mybir.ToString("ggyy年M月d日", culture);

            Console.WriteLine($"{str}は{dayOfWeek}です");

            var toDay = DateTime.Today;
            int birthday = 0;
            int a = toDay.Year - mybir.Year;
            for (int i = 0; i < a; i++) {
                var LeapYear = DateTime.IsLeapYear(mybir.Year + i);
                if (LeapYear) {
                    birthday += 366;
                } else {
                    birthday += 365;
                }
            }

            int b = toDay.Month - mybir.Month;
            int e = mybir.Month - toDay.Month;
            int[] d = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (b > 0) {
                for (int i = 0; i <= b; i++) {
                    if (i != b)
                        birthday += d[i];
                    else
                        birthday += (d[i] - mybir.Day);
                }
            } else {
                for (int i = 0; i <= e; i++) {
                    if (i != e)
                        birthday += d[i];
                    else
                        birthday += (d[i] - mybir.Day);
                }
            }
            
            Console.WriteLine(birthday);

            TimeSpan diff = DateTime.Today - mybir;
            Console.WriteLine(diff.TotalDays + "日");

            // あなたは〇〇歳です！


            int age = GetAge(mybir, DateTime.Today);
            static int GetAge(DateTime birth, DateTime targetDay) {
                var age = targetDay.Year - birth.Year;
                if(targetDay < birth.AddYears(age)) {
                    age--;
                }
                return age;
            }

                var isLeapYear = DateTime.IsLeapYear(year);
            if(isLeapYear) {
                Console.WriteLine($"{year}年はうるう年です");
            }else {
                Console.WriteLine($"{year}年は平年です");
            }
        }
    }
}

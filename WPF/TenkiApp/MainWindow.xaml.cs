using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Windows;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TenkiApp {

    public partial class MainWindow : Window {

        public MainWindow() {
            InitializeComponent();
            SearchBox.Text = "伊勢崎市";
            SetUp();
            //var lat, lon = GetLocationByIPAsync();
            //ReverseGeocodeAsync(lat, lon);
        }

        // ======== 検索ボタン ========
        private async void Button_ClickAsync(object sender, RoutedEventArgs e) {

            var (lat, lon) = await GetLatLonAsync(SearchBox.Text);

            if (lat == null || lon == null) {
                CurrentTime.Text = "緯度・経度を取得できません。";
                return;
            }

            TenkiResponse? weather = await GetCurrentTemperatureAsync(lat.Value, lon.Value);

            if (weather?.current != null) {

                // 現在の天気
                CurrentTime.Text = weather.current.time;
                CurrentTemperature.Text = $"{weather.current.temperature_2m}℃";
                CurrentWeather.Text = weather_code(weather.current.weather_code);

                // 現在の天気アイコンだけ抽出
                CurrentWeatherIcon.Text = icon_only(weather.current.weather_code);

                // ======= 週間天気を ItemsControl に流す =======
                var culture = new System.Globalization.CultureInfo("ja-JP");
                var today = DateTime.Today;

                var weekList = new List<WeekWeather>();

                for (int i = 0; i < 7; i++) {
                    var dayName = culture.DateTimeFormat.GetDayName(today.AddDays(i + 1).DayOfWeek);

                    weekList.Add(new WeekWeather {
                        Day = dayName,
                        Icon = icon_only(weather.daily.weather_code[i]),
                        Temp = $"{weather.daily.temperature_2m_max[i]}℃ / {weather.daily.temperature_2m_min[i]}℃"
                    });
                }

                WeekItems.ItemsSource = weekList;
            } else {
                CurrentTime.Text = "データが取得できませんでした。";
            }
        }

        // ====== 位置 → 緯度経度 ======
        static async Task<(double?, double?)> GetLatLonAsync(string place) {
            using var client = new HttpClient();

            string url = $"https://geocoding-api.open-meteo.com/v1/search?name={Uri.EscapeDataString(place)}&language=ja";

            var json = await client.GetStringAsync(url);

            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;

            if (!root.TryGetProperty("results", out var results) || results.GetArrayLength() == 0)
                return (null, null);

            var first = results[0];
            return (first.GetProperty("latitude").GetDouble(),
                    first.GetProperty("longitude").GetDouble());
        }

        // ====== 逆ジオコーディング（未使用） ======
        public async Task<string> ReverseGeocodeAsync(double lat, double lon) {
            string url = $"https://nominatim.openstreetmap.org/reverse?format=jsonv2&lat={lat}&lon={lon}";

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "WPFApp");

            var json = await client.GetStringAsync(url);
            var data = JObject.Parse(json);

            return data["display_name"]?.ToString() ?? "住所が見つかりませんでした";
        }

        // ====== 天気 API 呼び出し ======
        static async Task<TenkiResponse?> GetCurrentTemperatureAsync(double lat, double lon) {

            using var http = new HttpClient();

            string Url =
                $"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}" +
                $"&current=temperature_2m,wind_speed_10m,relative_humidity_2m,weather_code" +
                $"&daily=temperature_2m_max,temperature_2m_min,weather_code";

            return await http.GetFromJsonAsync<TenkiResponse>(Url);
        }

        //public async Task<(double?, double?)> GetLocationByIPAsync() {
        //    using var client = new HttpClient();

        //    var response = await client.GetStringAsync("https://ipinfo.io/json");
        //    var json = JObject.Parse(response);

        //    var lon = json["loc"]; // "lat,lon"
        //    return lon;
        //}

        private async void SetUp() {
            var (lat, lon) = await GetLatLonAsync(SearchBox.Text);

            if (lat == null || lon == null) {
                CurrentTime.Text = "緯度・経度を取得できません。";
                return;
            }

            TenkiResponse? weather = await GetCurrentTemperatureAsync(lat.Value, lon.Value);

            if (weather?.current != null) {

                // 現在の天気
                CurrentTime.Text = weather.current.time;
                CurrentTemperature.Text = $"{weather.current.temperature_2m}℃";
                CurrentWeather.Text = weather_code(weather.current.weather_code);

                // 現在の天気アイコンだけ抽出
                CurrentWeatherIcon.Text = icon_only(weather.current.weather_code);

                // ======= 週間天気を ItemsControl に流す =======
                var culture = new System.Globalization.CultureInfo("ja-JP");
                var today = DateTime.Today;

                var weekList = new List<WeekWeather>();

                for (int i = 0; i < 7; i++) {
                    var dayName = culture.DateTimeFormat.GetDayName(today.AddDays(i + 1).DayOfWeek);

                    weekList.Add(new WeekWeather {
                        Day = dayName,
                        Icon = icon_only(weather.daily.weather_code[i]),
                        Temp = $"{weather.daily.temperature_2m_max[i]}℃ / {weather.daily.temperature_2m_min[i]}℃"
                    });
                }

                WeekItems.ItemsSource = weekList;
            } else {
                CurrentTime.Text = "データが取得できませんでした。";
            }
        }

        // ====== 天気コード → 日本語と絵文字 ======
        static string weather_code(double code) =>
        code switch {
            0 => "☀ 晴れ",
            1 or 2 or 3 => "☁ 曇り",
            45 or 48 => "🌫 霧",
            51 or 53 or 55 => "🌂 霧雨",
            61 or 63 or 65 => "🌧 雨",
            71 or 73 or 75 => "❅ 雪",
            80 or 81 or 82 => "☂ にわか雨",
            85 or 86 => "❅ 雪",
            95 => "⛈ 雷雨",
            _ => "不明"
        };

        // アイコンだけ欲しい時
        static string icon_only(double code) =>
            weather_code(code).Split(' ')[0];
    }

    // ====== ItemsControl 用のモデル ======
    public class WeekWeather {
        public string Day { get; set; }
        public string Icon { get; set; }
        public string Temp { get; set; }
    }

    // ====== API レスポンスモデル ======
    public class TenkiResponse {
        public Current current { get; set; }
        public Daily daily { get; set; }
    }

    public class Current {
        public string time { get; set; }
        public double temperature_2m { get; set; }
        public double wind_speed_10m { get; set; }
        public double relative_humidity_2m { get; set; }
        public double weather_code { get; set; }
    }

    public class Daily {
        public double[] temperature_2m_max { get; set; }
        public double[] temperature_2m_min { get; set; }
        public double[] weather_code { get; set; }
    }
}

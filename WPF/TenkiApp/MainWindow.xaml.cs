using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.WebRequestMethods;

namespace TenkiApp {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            SearchBox.Text = "伊勢崎市";
        }

        private async void Button_ClickAsync(object sender, RoutedEventArgs e) {
            var (lat, lon) = await GetLatLonAsync(SearchBox.Text);

            if (lat == null || lon == null) {
                CurrentTime.Text = "緯度・経度を取得できません。";
                return;
            }

            TenkiResponse? weather = await GetCurrentTemperatureAsync(lat.Value, lon.Value);

            if (weather?.current != null) {
                CurrentTime.Text = weather.current.time;
                CurrentTemperature.Text = weather.current.temperature_2m.ToString() + "℃";
                CurrentWeather.Text = weather_code(weather.current.weather_code);
                TemperatureWeek1.Text = $"{weather.daily.temperature_2m_max[0].ToString()}℃\n{weather.daily.temperature_2m_min[0].ToString()}℃\n{weather_code(weather.daily.weather_code[0])}";
                TemperatureWeek2.Text = $"{weather.daily.temperature_2m_max[1].ToString()}℃\n{weather.daily.temperature_2m_min[1].ToString()}℃\n{weather_code(weather.daily.weather_code[1])}";
                TemperatureWeek3.Text = $"{weather.daily.temperature_2m_max[2].ToString()}℃\n{weather.daily.temperature_2m_min[2].ToString()}℃\n{weather_code(weather.daily.weather_code[2])}";
                TemperatureWeek4.Text = $"{weather.daily.temperature_2m_max[3].ToString()}℃\n{weather.daily.temperature_2m_min[3].ToString()}℃\n{weather_code(weather.daily.weather_code[3])}";
                TemperatureWeek5.Text = $"{weather.daily.temperature_2m_max[4].ToString()}℃\n{weather.daily.temperature_2m_min[4].ToString()}℃\n{weather_code(weather.daily.weather_code[4])}";
                TemperatureWeek6.Text = $"{weather.daily.temperature_2m_max[5].ToString()}℃\n{weather.daily.temperature_2m_min[5].ToString()}℃\n{weather_code(weather.daily.weather_code[5])}";
                TemperatureWeek7.Text = $"{weather.daily.temperature_2m_max[6].ToString()}℃\n{weather.daily.temperature_2m_min[6].ToString()}℃\n{weather_code(weather.daily.weather_code[6])}";
            } else {
                CurrentTime.Text = "データが取得できませんでした。";
            }
        }
    

        static async Task<(double?, double?)> GetLatLonAsync(string place) {
            using var client = new HttpClient();

            string url = $"https://geocoding-api.open-meteo.com/v1/search?name={Uri.EscapeDataString(place)}&language=ja";

            var json = await client.GetStringAsync(url);

            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;

            if (!root.TryGetProperty("results", out var results) || results.GetArrayLength() == 0) {
                return (null, null);
            }

            var first = results[0];
            double lat = first.GetProperty("latitude").GetDouble();
            double lon = first.GetProperty("longitude").GetDouble();

            return (lat, lon);
        }

        static async Task<TenkiResponse?> GetCurrentTemperatureAsync(double lat, double lon) {
            using var http = new HttpClient();

            string Url = $"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}&current=temperature_2m,wind_speed_10m,relative_humidity_2m,weather_code&daily=temperature_2m_max,temperature_2m_min,weather_code";

            var weather = await http.GetFromJsonAsync<TenkiResponse>(Url);

            return weather;
        }

        // 対応する天気は open-meteo の一番下にある
        static string weather_code(double weatherCode) {
            switch (weatherCode) {
                case 0:
                    return "☀ 晴れ";
                case 1 or 2 or 3:
                    return "☁ 曇り";
                case 45 or 48:
                    return "🌫 霧";
                case 51 or 53 or 55:
                    return "🌂 霧雨";
                case 61 or 63 or 65:
                    return "🌧 降雨";
                case 71 or 73 or 75:
                    return "❅ 降雪";
                case 80 or 81 or 82:
                    return "☂ 雨";
                case 85 or 86:
                    return "❅ 雪";
                case 95:
                    return "⛈ 雷雨";
                default:
                    return "error";
            }
        }
    }

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

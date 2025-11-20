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
        }

        private async void Button_ClickAsync(object sender, RoutedEventArgs e) {
            var (lat, lon) = await GetLatLonAsync(TextBox1.Text);

            if (lat == null || lon == null) {
                TextBlock1.Text = "緯度・経度を取得できません。";
                return;
            }

            TenkiResponse? weather = await GetCurrentTemperatureAsync(lat.Value, lon.Value);

            if (weather?.current != null) {
                TextBlock1.Text = weather.current.time;
                TextBlock2.Text = weather.current.temperature_2m.ToString();
                TextBlock3.Text = weather_code(weather.current.weather_code);
            } else {
                TextBlock1.Text = "データが取得できませんでした。";
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

            string Url = $"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}&current=temperature_2m,wind_speed_10m,relative_humidity_2m,weather_code";

            var weather = await http.GetFromJsonAsync<TenkiResponse>(Url);

            return weather;
        }

        // 対応する天気は open-meteo の一番下にある
        static string weather_code(double weatherCode) {
            switch (weatherCode) {
                case 0:
                    return "晴れ";
                case 1^3:
                    return "曇り";
                case 45 or 48:
                    return "霧";
                default:
                    return "error";
            }
        }
    }

    public class TenkiResponse {
        public Current current { get; set; }
    }

    public class Current {
        public string time { get; set; }
        public double temperature_2m { get; set; }
        public double wind_speed_10m { get; set; }
        public double relative_humidity_2m { get; set; }
        public double weather_code { get; set; }
    }
}

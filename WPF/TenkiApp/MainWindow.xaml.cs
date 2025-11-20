using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

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

            double? temperature = await GetCurrentTemperatureAsync(lat.Value, lon.Value);

            TextBlock1.Text = temperature.ToString();
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

        static async Task<double?> GetCurrentTemperatureAsync(double lat, double lon) {
            using var client = new HttpClient();

            string url = $"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}&current_weather=true";

            var json = await client.GetStringAsync(url);

            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;

            if (!root.TryGetProperty("current_weather", out var weather)) {
                return null;
            }

            return weather.GetProperty("temperature").GetDouble();
        }
    }
}

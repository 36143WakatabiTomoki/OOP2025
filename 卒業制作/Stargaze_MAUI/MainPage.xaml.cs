using System.Collections.ObjectModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Stargaze_MAUI {
    public partial class MainPage : ContentPage {
        public ObservableCollection<Constellation> Constellations { get; set; } = new();

        public MainPage() {
            InitializeComponent();
            BindingContext = this;
        }

        private async void OnLoadDataClicked(object sender, EventArgs e) {
            try {
                var httpClient = new HttpClient {
                    BaseAddress = new Uri("https://app.livlog.xyz/hoshimiru/")
                };
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json");
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation(
                    "authorization", "Bearer c6468419-bcf4-4f3f-ae5b-be33d524b062");

                var response = await httpClient.GetAsync(
                    "constellation?lat=35.6581&lng=139.7414&date=2026-01-15&hour=20&min=00&id=&disp=on");
                response.EnsureSuccessStatusCode();

                string responseData = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var apiResponse = JsonSerializer.Deserialize<ConstellationApiResponse>(responseData, options);

                Constellations.Clear();
                if (apiResponse?.Results != null) {
                    foreach (var c in apiResponse.Results)
                        Constellations.Add(c);
                }
            }
            catch (Exception ex) {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }

    public class ConstellationApiResponse {
        [JsonPropertyName("results")]
        public List<Constellation> Results { get; set; }
    }

    public class Constellation {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("jpName")]
        public string JpName { get; set; }

        [JsonPropertyName("enName")]
        public string EnName { get; set; }

        [JsonPropertyName("ryaku")]
        public string Ryaku { get; set; }

        [JsonPropertyName("altitude")]
        public string Altitude { get; set; }

        [JsonPropertyName("altitudeNum")]
        public double AltitudeNum { get; set; }

        [JsonPropertyName("direction")]
        public string Direction { get; set; }

        [JsonPropertyName("directionNum")]
        public double DirectionNum { get; set; }

        [JsonPropertyName("eclipticalFlag")]
        public string EclipticalFlag { get; set; }

        [JsonPropertyName("ptolemyFlag")]
        public string PtolemyFlag { get; set; }

        [JsonPropertyName("roughly")]
        public string Roughly { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("origin")]
        public string Origin { get; set; }

        [JsonPropertyName("season")]
        public string Season { get; set; }

        [JsonPropertyName("starIcon")]
        public string StarIcon { get; set; }

        [JsonPropertyName("starImage")]
        public string StarImage { get; set; }
    }
}

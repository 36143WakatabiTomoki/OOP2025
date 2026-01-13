
namespace seisaku_test_1 {
    internal class Program {
        static async Task Main(string[] args) {
            var baseAddress = new Uri("https://app.livlog.xyz/hoshimiru/");

            using (var httpClient = new HttpClient { BaseAddress = baseAddress }) {

                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json");

                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("authorization", "Bearer c6468419-bcf4-4f3f-ae5b-be33d524b062");

                using (var response = await httpClient.GetAsync("constellation?lat=35.6581&lng=139.7414&date=2020-01-15&hour=20&min=00&id=1&disp=on")) {

                    string responseData = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseData);
                }
            }
        }
    }
}


using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace seisaku_test_1 {
    internal class Program {
        static async Task Main(string[] args) {
            var baseAddress = new Uri("https://app.livlog.xyz/hoshimiru/");

            using (var httpClient = new HttpClient { BaseAddress = baseAddress }) {

                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json");

                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("authorization", "Bearer c6468419-bcf4-4f3f-ae5b-be33d524b062");

                using (var response = await httpClient.GetAsync("constellation?lat=35.6581&lng=139.7414&date=2026-01-15&hour=20&min=00&id=&disp=on")) {

                    response.EnsureSuccessStatusCode();
                    string responseData = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions {
                        PropertyNameCaseInsensitive = true
                    };
                    var apiResponse = JsonSerializer.Deserialize<ConstellationApiResponse>(responseData, options);

                    if (apiResponse?.Results != null) {
                        var constellations = apiResponse.Results;
                        foreach (var c in constellations) {
                            Console.WriteLine($"{c.JpName} / {c.Direction} / 高度:{c.AltitudeNum}");
                        }
                    } else {
                        Console.WriteLine("結果がありません");
                    }
                }
            }
        }

        public class ConstellationApiResponse {
            [JsonPropertyName("results")]
            public List<Constellation> Results { get; set; }
        }


        public class Constellation { //画面サイズ 2000x1200

            // 基本情報
            [JsonPropertyName("id")]
            public string Id { get; set; }              // 星座ID

            [JsonPropertyName("jpName")]
            public string JpName { get; set; }          // 日本語名

            [JsonPropertyName("enName")]
            public string EnName { get; set; }          // 英語名

            [JsonPropertyName("ryaku")]
            public string Ryaku { get; set; }           // 星座略号 (IAUの3文字略号)

            // 観測データ
            [JsonPropertyName("altitude")]
            public string Altitude { get; set; }        // 高度(人向け)

            [JsonPropertyName("altitudeNum")]
            public double AltitudeNum { get; set; }     // 高度(数値・値)

            [JsonPropertyName("direction")]
            public string Direction { get; set; }       // 方角(人向け)

            [JsonPropertyName("directionNum")]
            public double DirectionNum { get; set; }    // 方角(度)

            // 分類フラグ
            [JsonPropertyName("eclipticalFlag")]
            public string EclipticalFlag { get; set; }  // 横道星座かどうか (1=横道)

            [JsonPropertyName("ptolemyFlag")]
            public string PtolemyFlag { get; set; }     // プトレマイオスの48星座か

            // 解説
            [JsonPropertyName("roughly")]
            public string Roughly { get; set; }         // 簡単な説明 (要約)

            [JsonPropertyName("content")]
            public string Content { get; set; }         // 星座の概要説明

            [JsonPropertyName("origin")]
            public string Origin { get; set; }          // 星座の神話・由来

            [JsonPropertyName("season")]
            public string Season { get; set; }          // 主に見られる季節

            //描画
            [JsonPropertyName("starIcon")]
            public string StarIcon { get; set; }        // 星座のアイコン画像URL

            [JsonPropertyName("starImage")]
            public string StarImage { get; set; }       // 星座のイラスト画像URL
        }
    }
}

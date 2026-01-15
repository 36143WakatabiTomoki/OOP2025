using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Stargaze {
    public class Constellation { //画面サイズ 2000x1200

        // 基本情報
        [JsonPropertyName("id")]
        public int Id { get; set; }                 // 星座ID

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
        public int EclipticalFlag { get; set; }     // 横道星座かどうか (1=横道)

        [JsonPropertyName("ptolemyFlag")]
        public int PtolemyFlag { get; set; }        // プトレマイオスの48星座か

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

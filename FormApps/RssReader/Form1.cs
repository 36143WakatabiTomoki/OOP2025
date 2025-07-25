using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RssReader {
    public partial class Form1 : Form {

        private List<ItemData> items = new List<ItemData>();

        Dictionary<string, string> addDefaultRss = new Dictionary<string, string> {
            { "default", "https://news.yahoo.co.jp/rss/topics/top-picks.xml" },
            { "国内", "https://news.yahoo.co.jp/rss/topics/domestic.xml" },
            { "国際", "https://news.yahoo.co.jp/rss/topics/world.xml" },
            { "経済", "https://news.yahoo.co.jp/rss/topics/business.xml" },
            { "エンタメ", "https://news.yahoo.co.jp/rss/topics/entertainment.xml" },
            { "スポーツ", "https://news.yahoo.co.jp/rss/topics/sports.xml" },
            { "IT", "https://news.yahoo.co.jp/rss/topics/it.xml" },
            { "科学", "https://news.yahoo.co.jp/rss/topics/science.xml" },
            { "地域", "https://news.yahoo.co.jp/rss/topics/local.xml" },
        };

        public Form1() {
            InitializeComponent();
            //var addDefaultRss1 = new ItemData {
            //    Title = "default",
            //    Link = "https://news.yahoo.co.jp/rss/topics/top-picks.xml"
            //};
            cbUrl.DataSource = addDefaultRss.Select(x => x.Key).ToList();
            cbUrl.SelectedItem = null;
            //cbUrl.Items.Add(items[0].Title);


            tbMask();
        }

        private async void btRssGet_Click(object sender, EventArgs e) {
            if (cbUrl.Text != string.Empty) {
                using (var hc = new HttpClient()) {
                    var xml = await hc.GetStringAsync(linkReturn(cbUrl.Text));
                    XDocument xdoc = XDocument.Parse(xml);  //RSSの取得

                    //RSSを解析して必要な要素を取得
                    items = xdoc.Root.Descendants("item")
                        .Select(x =>
                            new ItemData {
                                Title = (string?)x.Element("title"),
                                Link = (string?)x.Element("link")
                            }).ToList();
                }
                //リストボックスへタイトルを変更
                lbTitles.Items.Clear();
                items.ForEach(item => lbTitles.Items.Add(item.Title ?? "データなし"));
            }
        }

        //タイトルを選択（クリック）したときに呼ばれるイベントハンドラ
        private void lbTitles_Click(object sender, EventArgs e) {
            if (lbTitles.SelectedItem is not null) {
                wvRssLink.Source = new Uri(items[lbTitles.SelectedIndex].Link);
            }
        }

        private void btGo_Click(object sender, EventArgs e) {
            wvRssLink.GoForward();
        }

        private void btBack_Click(object sender, EventArgs e) {
            wvRssLink.GoBack();
        }

        private void btStar_Click(object sender, EventArgs e) {
            if (tbUrl.Text != "" && cbUrl.Text != "") {
                if (!addDefaultRss.ContainsKey(tbUrl.Text)) {
                    addDefaultRss.Add(tbUrl.Text, cbUrl.Text);
                    cbUrl.DataSource = addDefaultRss.Select(x => x.Key).ToList();
                    tbUrl.Text = string.Empty;
                }
            }
        }

        private void wvRssLink_SourceChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e) {
            tbMask();
        }

        private void tbMask() {
            btGo.Enabled = wvRssLink.CanGoForward;
            btBack.Enabled = wvRssLink.CanGoBack;
        }

        //private void cbUrl_Click(object sender, EventArgs e) {
        //    if (cbUrl.SelectedItem is not null) {
        //        cbUrl.Text = items[cbUrl.SelectedIndex].Link;
        //    }
        //}

        public static bool IsValidUrl(string url) {
            return Uri.IsWellFormedUriString(url, UriKind.Absolute);
        }


        private string linkReturn(string checkLink) {
            if (addDefaultRss.ContainsKey(checkLink)) {
                return addDefaultRss[checkLink];
            }
            if(!IsValidUrl(checkLink)) {
                checkLink = "https://news.yahoo.co.jp/rss/topics/top-picks.xml";
            }
            return checkLink;
        }

        private void btStarRemove_Click(object sender, EventArgs e) {
            if (cbUrl.SelectedItem is not null) {
                addDefaultRss.Remove(cbUrl.Text);
                cbUrl.DataSource = null;
                cbUrl.DataSource = addDefaultRss.Select(x => x.Key).ToList();
            }
        }

        private void lbTitles_DrawItem(object sender, DrawItemEventArgs e) {
            var idx = e.Index;                                                      //描画対象の行
            if (idx == -1) return;                                                  //範囲外なら何もしない
            var sts = e.State;                                                      //セルの状態
            var fnt = e.Font;                                                       //フォント
            var _bnd = e.Bounds;                                                    //描画範囲(オリジナル)
            var bnd = new RectangleF(_bnd.X, _bnd.Y, _bnd.Width, _bnd.Height);      //描画範囲(描画用)
            var txt = (string)lbTitles.Items[idx];                                  //リストボックス内の文字
            var bsh = new SolidBrush(lbTitles.ForeColor);                           //文字色
            var sel = (DrawItemState.Selected == (sts & DrawItemState.Selected));   //選択行か
            var odd = (idx % 2 == 1);                                               //奇数行か
            var fore = Brushes.White;                                               //偶数行の背景色
            var bak = Brushes.AliceBlue;                                            //奇数行の背景色

            e.DrawBackground();                                                     //背景描画

            //奇数項目の背景色を変える（選択行は除く）
            if (odd && !sel) {
                e.Graphics.FillRectangle(bak, bnd);
            } else if (!odd && !sel) {
                e.Graphics.FillRectangle(fore, bnd);
            }

            //文字を描画
            e.Graphics.DrawString(txt, fnt, bsh, bnd);
        }
    }
}//https://news.yahoo.co.jp/rss/topics/top-picks.xml

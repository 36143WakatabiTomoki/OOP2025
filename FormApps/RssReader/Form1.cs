using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RssReader {
    public partial class Form1 : Form {

        private List<ItemData> items = new List<ItemData>();

        Dictionary<string, string> addDefaultRss = new Dictionary<string, string> {
            { "default", "https://news.yahoo.co.jp/rss/topics/top-picks.xml" },
            { "����", "https://news.yahoo.co.jp/rss/topics/domestic.xml" },
            { "����", "https://news.yahoo.co.jp/rss/topics/domestic.xml" },
            { "�o��", "https://news.yahoo.co.jp/rss/topics/domestic.xml" },
            { "�G���^��", "https://news.yahoo.co.jp/rss/topics/domestic.xml" },
            { "�X�|�[�c", "https://news.yahoo.co.jp/rss/topics/domestic.xml" },
            { "IT", "https://news.yahoo.co.jp/rss/topics/domestic.xml" },
            { "�Ȋw", "https://news.yahoo.co.jp/rss/topics/domestic.xml" },
            { "�n��", "https://news.yahoo.co.jp/rss/topics/domestic.xml" },
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
                    XDocument xdoc = XDocument.Parse(xml);  //RSS�̎擾

                    //RSS����͂��ĕK�v�ȗv�f���擾
                    items = xdoc.Root.Descendants("item")
                        .Select(x =>
                            new ItemData {
                                Title = (string?)x.Element("title"),
                                Link = (string?)x.Element("link")
                            }).ToList();
                }
                //���X�g�{�b�N�X�փ^�C�g����ύX
                lbTitles.Items.Clear();
                items.ForEach(item => lbTitles.Items.Add(item.Title ?? "�f�[�^�Ȃ�"));
            }
        }

        //�^�C�g����I���i�N���b�N�j�����Ƃ��ɌĂ΂��C�x���g�n���h��
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

        private string linkReturn(string checkLink) {
            if(addDefaultRss.ContainsKey(checkLink)) {
                return addDefaultRss[checkLink];
            }
            return checkLink;
        }
    }
}//https://news.yahoo.co.jp/rss/topics/top-picks.xml

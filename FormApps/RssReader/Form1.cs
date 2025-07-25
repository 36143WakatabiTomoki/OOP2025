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
            { "����", "https://news.yahoo.co.jp/rss/topics/world.xml" },
            { "�o��", "https://news.yahoo.co.jp/rss/topics/business.xml" },
            { "�G���^��", "https://news.yahoo.co.jp/rss/topics/entertainment.xml" },
            { "�X�|�[�c", "https://news.yahoo.co.jp/rss/topics/sports.xml" },
            { "IT", "https://news.yahoo.co.jp/rss/topics/it.xml" },
            { "�Ȋw", "https://news.yahoo.co.jp/rss/topics/science.xml" },
            { "�n��", "https://news.yahoo.co.jp/rss/topics/local.xml" },
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
            var idx = e.Index;                                                      //�`��Ώۂ̍s
            if (idx == -1) return;                                                  //�͈͊O�Ȃ牽�����Ȃ�
            var sts = e.State;                                                      //�Z���̏��
            var fnt = e.Font;                                                       //�t�H���g
            var _bnd = e.Bounds;                                                    //�`��͈�(�I���W�i��)
            var bnd = new RectangleF(_bnd.X, _bnd.Y, _bnd.Width, _bnd.Height);      //�`��͈�(�`��p)
            var txt = (string)lbTitles.Items[idx];                                  //���X�g�{�b�N�X���̕���
            var bsh = new SolidBrush(lbTitles.ForeColor);                           //�����F
            var sel = (DrawItemState.Selected == (sts & DrawItemState.Selected));   //�I���s��
            var odd = (idx % 2 == 1);                                               //��s��
            var fore = Brushes.White;                                               //�����s�̔w�i�F
            var bak = Brushes.AliceBlue;                                            //��s�̔w�i�F

            e.DrawBackground();                                                     //�w�i�`��

            //����ڂ̔w�i�F��ς���i�I���s�͏����j
            if (odd && !sel) {
                e.Graphics.FillRectangle(bak, bnd);
            } else if (!odd && !sel) {
                e.Graphics.FillRectangle(fore, bnd);
            }

            //������`��
            e.Graphics.DrawString(txt, fnt, bsh, bnd);
        }
    }
}//https://news.yahoo.co.jp/rss/topics/top-picks.xml

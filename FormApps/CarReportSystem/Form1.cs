using System.ComponentModel;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using static CarReportSystem.CarReport;

namespace CarReportSystem {
    public partial class Form1 : Form {
        // カーレポート管理用リスト
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        //設定クラスのインスタンスを生成
        Settings setting = Settings.getInstance();

        public Form1() {
            InitializeComponent();
            dgvRecord.DataSource = listCarReports;
        }

        private void btPicOpen_Click(object sender, EventArgs e) {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK) {
                pbPicture.Image = Image.FromFile(ofdPicFileOpen.FileName);
            }
        }

        private void btPicDelete_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }

        private void btRecordAdd_Click(object sender, EventArgs e) {
            tsslbMessage.Text = "";

            if (cbAuthor.Text == "" || cbCarName.Text == "") {
                tsslbMessage.Text = "記録者、または車名が未登録です";
                return;
            }

            var carReport = new CarReport {
                Date = dtpDate.Value,
                Author = cbAuthor.Text,
                Maker = getRadioButtonMaker(),
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                Picture = pbPicture.Image
            };
            listCarReports.Add(carReport);
            setCbAuthor(cbAuthor.Text);
            setCbCarName(cbCarName.Text);
            InputItemsAllClear();
        }

        //入力項目をすべてクリア
        private void InputItemsAllClear() {
            dtpDate.Value = DateTime.Today;
            cbAuthor.Text = "";
            cbCarName.Text = "";
            tbReport.Text = "";
            pbPicture.Image = null;

            rbOther.Checked = true;
            rbOther.Checked = false;
        }

        private MakerGroup getRadioButtonMaker() {
            if (rbToyota.Checked)
                return MakerGroup.トヨタ;
            if (rbNissan.Checked)
                return MakerGroup.日産;
            if (rbHonda.Checked)
                return MakerGroup.ホンダ;
            if (rbSubaru.Checked)
                return MakerGroup.スバル;
            if (rbImport.Checked)
                return MakerGroup.輸入車;

            return MakerGroup.その他;
        }

        private void dgvRecord_Click(object sender, EventArgs e) {
            if (dgvRecord.RowCount == 0) {
                return;
            } else {
                dtpDate.Value = (DateTime)dgvRecord.CurrentRow.Cells["Date"].Value;
                cbAuthor.Text = dgvRecord.CurrentRow.Cells["Author"].Value.ToString();
                setRadioButtonMaker((MakerGroup)dgvRecord.CurrentRow.Cells["Maker"].Value);
                cbCarName.Text = dgvRecord.CurrentRow.Cells["CarName"].Value.ToString();
                tbReport.Text = dgvRecord.CurrentRow.Cells["Report"].Value.ToString();
                pbPicture.Image = (Image)dgvRecord.CurrentRow.Cells["Picture"].Value;
                //setCbAuthor(dgvRecord.CurrentRow.Cells["Author"].Value.ToString());
                //setCbCarName(dgvRecord.CurrentRow.Cells["CarName"].Value.ToString());
            }
        }

        //指定したメーカーのラジオボタンをセット
        private void setRadioButtonMaker(MakerGroup targetMaker) {
            switch (targetMaker) {
                case MakerGroup.トヨタ:
                    rbToyota.Checked = true;
                    break;
                case MakerGroup.日産:
                    rbNissan.Checked = true;
                    break;
                case MakerGroup.ホンダ:
                    rbHonda.Checked = true;
                    break;
                case MakerGroup.スバル:
                    rbSubaru.Checked = true;
                    break;
                case MakerGroup.輸入車:
                    rbImport.Checked = true;
                    break;
                case MakerGroup.その他:
                    rbOther.Checked = true;
                    break;
                default:
                    break;
            }
        }

        //記録者の履歴をコンボボックスへ登録（重複なし）
        private void setCbAuthor(string author) {
            if (!cbAuthor.Items.Contains(author)) {
                cbAuthor.Items.Add(author);
            }
        }

        //車名の履歴をコンボボックスへ登録（重複なし）
        private void setCbCarName(string carName) {
            if (!cbCarName.Items.Contains(carName)) {
                cbCarName.Items.Add(carName);
            }
        }

        //新規追加のイベントハンドラ
        private void btNewRecord_Click(object sender, EventArgs e) {
            InputItemsAllClear();
        }

        //修正ボタンのイベントハンドラ
        private void btRecordModify_Click(object sender, EventArgs e) {
            if (dgvRecord.RowCount == 0 || !dgvRecord.CurrentRow.Selected) {
                return;
            } else {
                dgvRecord.CurrentRow.Cells["Date"].Value = dtpDate.Value;
                dgvRecord.CurrentRow.Cells["Author"].Value = cbAuthor.Text;
                dgvRecord.CurrentRow.Cells["Maker"].Value = getRadioButtonMaker();
                dgvRecord.CurrentRow.Cells["CarName"].Value = cbCarName.Text;
                dgvRecord.CurrentRow.Cells["Report"].Value = tbReport.Text;
                dgvRecord.CurrentRow.Cells["Picture"].Value = pbPicture.Image;

                //dgvRecord.Refresh();    //データグリッドビューの更新
            }
        }

        //削除ボタンのイベントハンドラ
        private void btRecordDelete_Click(object sender, EventArgs e) {
            //カーレポート管理用リストから、
            //該当するデータを削除する
            if (dgvRecord.RowCount == 0 || !dgvRecord.CurrentRow.Selected) {
                return;
            } else {
                listCarReports.RemoveAt(dgvRecord.CurrentRow.Index);
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            InputItemsAllClear();

            //交互に色を設定（データグリッドビュー）
            dgvRecord.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvRecord.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan;

            //設定ファイルを読み込み背景色を変更する（逆シリアル化）
            if (File.Exists("setting.xml")) {
                try {
                    using (var reader = XmlReader.Create("setting.xml")) {
                        var serializer = new XmlSerializer(typeof(Settings));
                        var settings = serializer.Deserialize(reader) as Settings;
                        //背景色設定
                        BackColor = Color.FromArgb(Settings.getInstance().MainFormBackColor);
                        //設定クラスのインスタンスにも現在の設定色を設定
                        setting.MainFormBackColor = BackColor.ToArgb();
                    }
                }
                catch (Exception ex) {
                    tsslbMessage.Text = "設定ファイス読み込みエラー";
                    MessageBox.Show(ex.Message); //より具体的なエラーを出力
                }
            } else {
                tsslbMessage.Text = "設定ファイルがありません";
            }

        }

        private void tsmiExit_Click(object sender, EventArgs e) {
            Close();
        }

        private void tsmiAbout_Click(object sender, EventArgs e) {
            fmVersion fmv = new fmVersion();
            fmv.ShowDialog();
        }

        private void tsmiColorMenu_Click(object sender, EventArgs e) {
            if (cdColor.ShowDialog() == DialogResult.OK) {
                BackColor = cdColor.Color;

                //設定ファイルへ保存
                setting.MainFormBackColor = cdColor.Color.ToArgb();     //背景色を設定インスタンスへ設定
            }
        }

        //ファイルセーブ処理
        private void reportSaveFile() {
            if (sfdReportFileSave.ShowDialog() == DialogResult.OK) {
                try {
                    //バイナリ形式でシリアル化
#pragma warning disable SYSLIB0011
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011

                    using (FileStream fs = File.Open(
                            sfdReportFileSave.FileName, FileMode.Create)) {
                        bf.Serialize(fs, listCarReports);
                    }
                }
                catch (Exception ex) {
                    tsslbMessage.Text = "ファイル書き出しエラー";
                    MessageBox.Show(ex.Message);//より具体的なエラーを出力
                }
            }
        }

        //ファイルオープン処理
        private void reportOpenFile() {
            if (ofdReportFileOpen.ShowDialog() == DialogResult.OK) {
                try {
                    //逆シリアル化でバイナリ形式を取り込む
#pragma warning disable SYSLIB0011 // 型またはメンバーが旧型式です
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // 型またはメンバーが旧型式です
                    using (FileStream fs = File.Open(
                            ofdReportFileOpen.FileName, FileMode.Open, FileAccess.Read)) {

                        listCarReports = (BindingList<CarReport>)bf.Deserialize(fs);
                        dgvRecord.DataSource = listCarReports;

                        cbAuthor.Items.Clear();
                        cbCarName.Items.Clear();

                        //コンボボックスに登録
                        foreach (var report in listCarReports) {
                            setCbAuthor(report.Author);
                            setCbCarName(report.CarName);
                        }
                    }
                }
                catch (Exception) {
                    tsslbMessage.Text = "ファイル形式が違います";

                }
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e) {
            reportSaveFile();
        }

        private void 開くToolStripMenuItem_Click(object sender, EventArgs e) {
            reportOpenFile();
        }

        //フォームが閉じたら呼ばれる
        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            //設定ファイルへ色情報を保存する処理（シリアル化）
            try {
                using (var writer = XmlWriter.Create("setting.xml")) {
                    var serializer = new XmlSerializer(setting.GetType());
                    serializer.Serialize(writer, setting);
                }
            }
            catch (Exception ex) {
                tsslbMessage.Text = "設定ファイス書き出しエラー";
                MessageBox.Show(ex.Message); //より具体的なエラーを出力
            }

        }

        private void cbCarName_SelectedIndexChanged(object sender, EventArgs e) {

        }
    }
}

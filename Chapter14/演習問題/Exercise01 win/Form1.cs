using System.Text;
using System.Threading.Tasks;

namespace Exercise01_win {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            
        }

        private async void button1_Click(object sender, EventArgs e) {
            var readText = File.ReadLinesAsync("ëñÇÍÉÅÉçÉX.txt");
            var rt = await text(readText);
            textBox1.Text = rt;
        }

        private async Task<string> text(IAsyncEnumerable<string> text) {
            var st = new StringBuilder();
            await Task.Run(async () => {
                await foreach (var item in text) {
                    st.AppendLine(item);
                    await Task.Delay(10);
                }
            });
            return st.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static ColorChecker.MyColor;

namespace ColorChecker
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //すべてのスライダーから呼ばれるイベントハンドラー
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            //colorAreaの色（背景色）は、スライダーで指定したRGBの色を表示する
            colorArea.Background = new SolidColorBrush(Color.FromRgb((byte)rSlider.Value, (byte)gSlider.Value, (byte)bSlider.Value));
        }

        private void stockButton_Click(object sender, RoutedEventArgs e) {
            stockList.Items.Add("R: " + ((int)rSlider.Value) + " G: " + ((int)gSlider.Value) + " B: " + ((int)bSlider.Value));
            
        }

        private void stockList_Selected(object sender, RoutedEventArgs e) {

        }
    }
}

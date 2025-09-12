using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
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
        MyColor currentColor;

        Color loadColor = Color.FromRgb(0, 0, 0);   //起動時の色

        public MainWindow()
        {
            InitializeComponent();

            DataContext = GetColorList();
        }

        private MyColor[] GetColorList() {
            return typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Select(i => new MyColor() { Color = (Color)i.GetValue(null), Name = i.Name }).ToArray();
        }

        //すべてのスライダーから呼ばれるイベントハンドラー
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            //colorAreaの色（背景色）は、スライダーで指定したRGBの色を表示する
            currentColor = new MyColor {
                Color = Color.FromRgb((byte)rSlider.Value, (byte)gSlider.Value, (byte)bSlider.Value),
                Name = ((MyColor[])DataContext).Where(c => c.Color.R == (byte)rSlider.Value
                                                        && c.Color.G == (byte)gSlider.Value
                                                        && c.Color.B == (byte)bSlider.Value).Select(x => x.Name).FirstOrDefault()
            };
            colorArea.Background = new SolidColorBrush(currentColor.Color);

            colorSelectComboBox.SelectedIndex = GetColorToIndex(currentColor.Color);
        }

        private void stockButton_Click(object sender, RoutedEventArgs e) {
            if(stockList.Items.Contains(currentColor)) {
                MessageBox.Show("既に登録済みです！", "ColorChecker", MessageBoxButton.OK, MessageBoxImage.Warning);
            } else {
                stockList.Items.Insert(0, currentColor);
            }
        }

        //コンボボックスから色を選択
        private void colorSelectComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if(colorSelectComboBox.SelectedIndex == -1) {
                return;
            }
            var mycolor = (MyColor)((ComboBox)sender).SelectedItem;
            getSliderValue(mycolor.Color);
            currentColor.Color = Color.FromRgb((byte)rSlider.Value, (byte)gSlider.Value, (byte)bSlider.Value);
            currentColor.Name = mycolor.Name;
        }

        public void getSliderValue(Color color) {
            rSlider.Value = color.R;
            gSlider.Value = color.G;
            bSlider.Value = color.B;
        }

        private void stockList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var selectList = (MyColor)((ListBox)sender).SelectedItem;
            getSliderValue(selectList.Color);
        }

        //windowが表示されるタイミングで呼ばれる
        private void Window_Loaded(object sender, RoutedEventArgs e) {
            colorSelectComboBox.SelectedIndex = GetColorToIndex(loadColor);
        }

        //色情報から色配列のインデックスを取得する
        private int GetColorToIndex(Color color) {
            return ((MyColor[])DataContext).ToList().FindIndex(c => c.Color.Equals(color));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using static ColorChecker.MainWindow;

namespace ColorChecker
{
    public struct MyColor
    {
        public Color Color { get; set; }
        public string Name { get; set; }
        //public override string ToString() {
        //    return "R: " + ((int)rSlider.Value) + " G: " + ((int)gSlider.Value) + " B: " + ((int)bSlider.Value); //書き換える
        //}
    }
}

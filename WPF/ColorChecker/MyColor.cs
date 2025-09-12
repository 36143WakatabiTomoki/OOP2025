using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using static ColorChecker.MainWindow;
using System.Reflection;

namespace ColorChecker
{
    public struct MyColor
    {
        public Color Color { get; set; }
        public string Name { get; set; }
        public override string ToString() {
            return Name ?? "R: " + ((int)Color.R) + " G: " + ((int)Color.G) + " B: " + ((int)Color.B); //書き換える
        }
    }
}

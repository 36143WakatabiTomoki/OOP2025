using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnitConverter
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btChaange_Click(object sender, EventArgs e) {
            int num1 = int.Parse(tbNum1.Text);
            double num2 = num1 * 0.3048;
            tbNum2.Text = num2.ToString();
        }

        private void btCalc_Click(object sender, EventArgs e) {
            nudAmari.Value = nudNum1.Value % nudNum2.Value;
            nudAnswer.Value = nudNum1.Value / nudNum2.Value;
        }
    }
}

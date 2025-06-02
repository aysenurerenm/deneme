using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yazilimYapimiProjeOdevi
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = Form4.sendCorrectCount;
            textBox1.Text = x.ToString();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
}

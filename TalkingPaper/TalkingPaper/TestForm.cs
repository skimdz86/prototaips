using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TalkingPaper
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            Griglia g = new Griglia("test", 3, 4);
            String s = g.getCoordFromIndex(6);
            int t = g.getIndexFromCoord("B3");
            labelTest1.Text = "indice: 6 --> coord: " + s;
            labelTest2.Text = "coord: B3 --> indice: " + t.ToString();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {

        }

    }
}

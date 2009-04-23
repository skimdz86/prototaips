using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TalkingPaper
{
    public partial class FormVideo : Form
    {
        public FormVideo()
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 90, true);
        }

        private void FormVideo_Load(object sender, EventArgs e)
        {

        }
    }
}
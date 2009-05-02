using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TalkingPaper
{
    public partial class FormSchema : Form
    {
        public FormSchema()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
        }

        private void pictureBoxPost1_Click(object sender, EventArgs e)
        {
            if (textBoxPost.Visible == false)
            {
                textBoxPost.Visible = true;
                this.pictureBoxPost2.Visible = true;
            }
            else
            {
                textBoxPost.Visible = false;
                this.pictureBoxPost2.Visible = false;
            }
                

        }
    }
}
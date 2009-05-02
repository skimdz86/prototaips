using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TalkingPaper.Welcome
{
    public partial class IndexForm : Form
    {
        public IndexForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
        }

        private void Index_Load(object sender, EventArgs e)
        {

        }

        private void mainButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mainButton3_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            new ChildHomeForm().Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }

        private void mainButton1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            new RegistrationForm().Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }

    }
}

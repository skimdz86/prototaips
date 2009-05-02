using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TalkingPaper.Welcome
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void mainButton1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            new IndexForm().Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }

        private void mainButton2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            new ChildHomeForm().Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TalkingPaper
{
    
    public partial class WelcomePre : Form
    {
        public WelcomePre()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            textBox1.Visible = false;
            button1.Enabled = true;
            button2.Enabled = true;
            Esci.Enabled = true;
        }

        private void Esci_Click(object sender, EventArgs e)
        {
            global.inizio.Close();
            this.Close();
        }

   /*     private void button1_Click(object sender, EventArgs e)
        {
            TalkingPaper.global.rfid=false;
            this.Cursor = Cursors.WaitCursor;
            Welcome n = new Welcome(this);
            n.setTech("bc");//barcode
            n.Show();
            this.Cursor = Cursors.Default;
            this.Hide();
            global.inizio = this;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TalkingPaper.global.rfid = true;
            this.Cursor = Cursors.WaitCursor;
            Welcome n = new Welcome(this);
            n.setTech("rf");//rfid
            n.Show();
            this.Cursor = Cursors.Default;
            this.Hide();
            global.inizio = this;
        }
        */
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            textBox1.Visible = false;
            button1.Enabled = true;
            button2.Enabled = true;
            Esci.Enabled = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            textBox1.Visible = false;
            button1.Enabled = true;
            button2.Enabled = true;
            Esci.Enabled = true;
        }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TalkingPaper.ControlLogic;

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
            if (textBox2.Text == textBox3.Text)
            {
                LoginControl logc = new LoginControl();
                if (logc.registration(textBox1.Text, textBox2.Text))
                {
                    new ChildHomeForm().Show();
                    this.Cursor = Cursors.Default;
                    this.Visible = false;
                }
                else
                {
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    MessageBox.Show("C'è stato un errore! Prego reinserire i dati");
                }
            }
            else 
            {
                textBox2.Clear();
                textBox3.Clear();
                MessageBox.Show("Le password non coincidono! Reinserirle prego");
            }
        }
    }
}

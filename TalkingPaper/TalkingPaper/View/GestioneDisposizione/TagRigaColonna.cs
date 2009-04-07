using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TalkingPaper.GestioneDisposizione
{
    public partial class TagRigaColonna : Form
    {
        private string directory_principale;
        private FormAmministrazione amministrazione;
        
        public TagRigaColonna(FormAmministrazione amministrazione, string directory_principale)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 60, true);
            this.amministrazione = amministrazione;
            this.directory_principale = directory_principale;
            button1.Cursor = Cursors.Hand;
            button2.Cursor = Cursors.Hand;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            amministrazione.Visible = true;
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == null) || (textBox1.Text.CompareTo("") == 0)) {
                MessageBox.Show("Non hai inserito i tag presenti in una riga");
            }
            else if ((textBox2.Text == null) || (textBox2.Text.CompareTo("") == 0))
            {
                MessageBox.Show("Non hai inserito i tag presenti in una colonna");
            }
            else
            {
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    int riga = Int32.Parse(textBox1.Text);
                    int colonna = Int32.Parse(textBox2.Text);
                    if (colonna > 6)
                    {
                        MessageBox.Show("Le righe possono essere al massimo 6");
                        this.Cursor = Cursors.Default;
                    }
                    else
                    {
                        TaggingDellaParete n = new TaggingDellaParete(null, amministrazione, directory_principale, riga, colonna);
                        n.Show();
                        this.Cursor = Cursors.Default;
                        this.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Devi inserire dei numeri");
                    this.Cursor = Cursors.Default;
                }

            }
        }


        private void Indietro_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Close();
            this.Cursor = Cursors.Default;
            //componenti.Visible = true;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TalkingPaper.RfidCode
{
    public partial class BenvenutoRFID : FormSchema
    {
        private string directoryprincipale;
        private string database = "talkingpaper2";
        private Welcome inizio;

        public BenvenutoRFID(Welcome inizio)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 70, true);
            this.inizio = inizio;
            //textBox1.Text = "Benvenuto!\r\nIn questa fase\r\npotrai associare\r\nil codice a barre\r\nal tuo cartellon" +
               // "e!\r\nBuon Lavoro!!!!";
            //textBox1.Select(0, 0);
            button1.Cursor = Cursors.Hand;
            Entra.Cursor = Cursors.Hand;
            Esci.Cursor = Cursors.Hand;
        }

        private void BenvenutoBarCode_Load(object sender, EventArgs e)
        {
            this.directoryprincipale = Directory.GetCurrentDirectory();
        }

        private void Esci_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //this.Visible = false;
            QuestionRFID richiesta = new QuestionRFID(this,inizio);
            richiesta.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;

        }

        private void Entra_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            this.Cursor = Cursors.WaitCursor;
            ScegliMostraRFID mostre = new ScegliMostraRFID(directoryprincipale, this, database);
            mostre.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            FormScegliPosterRFID nuo= new FormScegliPosterRFID(null,this,-1,null,null,directoryprincipale,database);
            //this.Visible = false;
            nuo.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }

        public Welcome getInizio() {
            return inizio;
        }

        
    }
}
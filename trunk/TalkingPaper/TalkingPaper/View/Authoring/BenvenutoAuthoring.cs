using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TalkingPaper.Authoring
{
    public partial class BenvenutoAuthoring : FormSchema
    {
        private string directory_principale;
        private string database = "talkingpaper2";
        private Welcome inizio;
        private GestioneDisposizione.BenvenutoGestioneDisposizione benvenuto_ges;

        public BenvenutoAuthoring(Welcome inizio, string directory_principale, GestioneDisposizione.BenvenutoGestioneDisposizione benvenuto_ges)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 70, true);
            this.inizio = inizio;
            this.directory_principale = directory_principale;
            this.benvenuto_ges = benvenuto_ges;
            //textBox1.Text = "Benvenuto!\r\nIn questa fase\r\npotrai associare\r\nil codice a barre\r\nal tuo cartellon" +
            // "e!\r\nBuon Lavoro!!!!";
            //textBox1.Select(0, 0);
            button1.Cursor = Cursors.Hand;
            Entra.Cursor = Cursors.Hand;
            Menu.Cursor = Cursors.Hand;
        }

        private void BenvenutoAuthoring_Load(object sender, EventArgs e)
        {
            //this.directoryprincipale = Directory.GetCurrentDirectory();
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //this.Visible = false;
            QuestionCambiaGriglia richiesta = new QuestionCambiaGriglia(this, inizio);
            richiesta.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;

        }

        private void Entra_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            this.Cursor = Cursors.WaitCursor;
            ScegliMostraAuthoring mostre = new ScegliMostraAuthoring(directory_principale, this, database,benvenuto_ges);
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
            FormScegliPosterAuthoring nuo = new FormScegliPosterAuthoring(null, this, -1, null, null, directory_principale, database,null);
            //this.Visible = false;
            nuo.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }

        public Welcome getInizio()
        {
            return inizio;
        }


    }
}
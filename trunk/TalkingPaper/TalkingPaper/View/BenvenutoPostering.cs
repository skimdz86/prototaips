using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace TalkingPaper.Postering
{
    public partial class BenvenutoPostering : FormSchema
    {
        private string directoryprincipale;
        private string database = "talkingpaper2";
        private Welcome inizio;
        private TalkingPaper.BarCode.BenvenutoBarCode benvenuto_bar;
        private TalkingPaper.RfidCode.BenvenutoRFID benvenuto_rfid;
        private TalkingPaper.BarCode.FormVisualizzaElementi visualizza_bar;
        private TalkingPaper.RfidCode.FormVisualizzaElementiRFID visualizza_rfid;

        public BenvenutoPostering(Welcome inizio, TalkingPaper.BarCode.BenvenutoBarCode benvenuto_bar, TalkingPaper.RfidCode.BenvenutoRFID benvenuto_rfid, TalkingPaper.BarCode.FormVisualizzaElementi visualizza_bar, TalkingPaper.RfidCode.FormVisualizzaElementiRFID visualizza_rfid,string directory_principale)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 70, true);
            //textBox1.Select(0, 0);
            this.inizio = inizio;
            this.directoryprincipale = directory_principale;
            this.benvenuto_bar = benvenuto_bar;
            this.benvenuto_rfid = benvenuto_rfid;
            this.visualizza_bar = visualizza_bar;
            this.visualizza_rfid = visualizza_rfid;
            Esci.Cursor = Cursors.Hand;
            SingoloPoster.Cursor = Cursors.Hand;
            ModificaSingoli.Cursor = Cursors.Hand;
            MostreEsistenti.Cursor = Cursors.Hand;
            NuovaMostra.Cursor = Cursors.Hand;
            button1.Cursor = Cursors.Hand;
            progressBar1.Visible = false;
        }

        private void BenvenutoPostering_Load(object sender, EventArgs e)
        {
            //this.directoryprincipale = Directory.GetCurrentDirectory();
        }

        private void Esci_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            this.Cursor = Cursors.WaitCursor;
            QuestionPostering richiesta = new QuestionPostering(this,inizio,null,benvenuto_bar,benvenuto_rfid,visualizza_bar,visualizza_rfid);
            richiesta.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;

        }

        private void Entra_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            this.Cursor = Cursors.WaitCursor;
            CreaNuovaMostra nuova = new CreaNuovaMostra(this,directoryprincipale,benvenuto_bar,benvenuto_rfid,visualizza_bar,visualizza_rfid);
            nuova.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void MostreEsistenti_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Si crea la mostra per esempio partendo da 1001 storia");
            this.Cursor = Cursors.WaitCursor;
            PosterDaStoria nuooo = new PosterDaStoria(directoryprincipale,this,false,-1,null,null,null,null,null,null);
            //this.Visible = false;
            nuooo.Visible = true;
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            //progressBar1.Visible = true;
            //progressBar1.Show();
            //progressBar1.Increment(10);
            this.Cursor = Cursors.WaitCursor;
            ScegliMostraPostering nuova = new ScegliMostraPostering(this, directoryprincipale,benvenuto_bar,benvenuto_rfid,visualizza_bar,visualizza_rfid,progressBar1);
            //nuova.Show();
            //progressBar1.Value = progressBar1.Minimum;
            //progressBar1.Visible = false;
            //this.Visible = false;
            //this.timer1.Enabled = true;
            //progressBar1.Value = progressBar1.Maximum;
            nuova.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
            //progressBar1.Value = progressBar1.Minimum;
            //progressBar1.Visible = false;
        }

        private void SingoloPoster_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            NuovoPoster nuovo = new NuovoPoster(null, this, null, -1, null, directoryprincipale,benvenuto_bar,benvenuto_rfid,visualizza_bar,visualizza_rfid);
            //this.Visible = false;
            nuovo.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }

        private void ModificaSingoli_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            PosterDellaMostra nuova = new PosterDellaMostra(this, null, -1, null, directoryprincipale,benvenuto_bar,benvenuto_rfid,visualizza_bar,visualizza_rfid);
            //this.Visible = false;
            nuova.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }

        public Welcome GetInizio() {
            return inizio;
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           /* progressBar1.Increment(1);
            if (progressBar1.Value == progressBar1.Maximum) {
                progressBar1.Value = progressBar1.Minimum;
            }*/
            /*if (cpb3.Value == cpb3.Maximum)
                cpb3.Value = cpb3.Minimum;*/
        }

        private void Esci_Click_1(object sender, EventArgs e)
        {
            TalkingPaper.global.start.Show();
            this.Close();
        }

        private void SingoloPoster_Click_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            NuovoPoster nuovo = new NuovoPoster(null, this, null, -1, null, directoryprincipale, benvenuto_bar, benvenuto_rfid, visualizza_bar, visualizza_rfid);
            //this.Visible = false;
            nuovo.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }

        private void ModificaSingoli_Click_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            PosterDellaMostra nuova = new PosterDellaMostra(this, null, -1, null, directoryprincipale, benvenuto_bar, benvenuto_rfid, visualizza_bar, visualizza_rfid);
            //this.Visible = false;
            nuova.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }

    }
}
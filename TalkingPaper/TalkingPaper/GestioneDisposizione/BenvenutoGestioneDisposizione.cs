using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace TalkingPaper.GestioneDisposizione
{
    public partial class BenvenutoGestioneDisposizione : FormSchema
    {
        //private string directoryprincipale;
        private string database = "talkingpaper2";
        private Welcome inizio;
        /*private TalkingPaper.BarCode.BenvenutoBarCode benvenuto_bar;
        private TalkingPaper.RfidCode.BenvenutoRFID benvenuto_rfid;
        private TalkingPaper.BarCode.FormVisualizzaElementi visualizza_bar;
        private TalkingPaper.RfidCode.FormVisualizzaElementiRFID visualizza_rfid;
        private TalkingPaper.Authoring.BenvenutoAuthoring benvenuto_aut;*/
        private TalkingPaper.Authoring.FormVisualizzaElementiAuthoring visualizza_aut;
        private string directory_principale;

        public BenvenutoGestioneDisposizione(Welcome inizio, /*TalkingPaper.Authoring.BenvenutoAuthoring benvenuto_aut,*/TalkingPaper.Authoring.FormVisualizzaElementiAuthoring visualizza_aut,string directory_principale)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 70, true);
            //textBox1.Select(0, 0);
            this.inizio = inizio;
            this.directory_principale = directory_principale;
            /*this.benvenuto_bar = benvenuto_bar;
            this.benvenuto_rfid = benvenuto_rfid;
            this.visualizza_bar = visualizza_bar;
            this.visualizza_rfid = visualizza_rfid;*/
            //this.benvenuto_aut = benvenuto_aut;
            this.visualizza_aut = visualizza_aut;
            Menu.Cursor = Cursors.Hand;
            //button2.Cursor = Cursors.Hand;
            //SingoloPoster.Cursor = Cursors.Hand;
            ModificaSingoli.Cursor = Cursors.Hand;
            //TagNuovoPannello.Cursor = Cursors.Hand;
            //NuovaConfigurazione.Cursor = Cursors.Hand;
            button1.Cursor = Cursors.Hand;
            
            /*progressBar1.Visible = false;
            TagNuovoPannello.Visible = false;
            TagNuovoPannello.Enabled = false;
            NuovaConfigurazione.Visible = false;
            gB.Visible = false;
            NuovaConfigurazione.Enabled = false;*/
        }

        private void BenvenutoPostering_Load(object sender, EventArgs e)
        {
            //this.directoryprincipale = Directory.GetCurrentDirectory();
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            this.Cursor = Cursors.WaitCursor;
            //QuestionPostering richiesta = new QuestionPostering(this, inizio, null, benvenuto_aut,visualizza_aut);
            //richiesta.Show();
            global.home.Show();
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
            TaggingDellaParete n = new TaggingDellaParete(this,null,directory_principale,0,0);
            n.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            //progressBar1.Visible = true;
            //progressBar1.Show();
            //progressBar1.Increment(10);
            //this.Cursor = Cursors.WaitCursor;
            //ScegliMostraPostering nuova = new ScegliMostraPostering(this, directoryprincipale,benvenuto_aut,visualizza_aut, progressBar1);
            //nuova.Show();
            //progressBar1.Value = progressBar1.Minimum;
            //progressBar1.Visible = false;
            //this.Visible = false;
            //this.timer1.Enabled = true;
            //progressBar1.Value = progressBar1.Maximum;
            //nuova.Show();
            //this.Cursor = Cursors.Default;
            //this.Visible = false;
            //progressBar1.Value = progressBar1.Minimum;
            //progressBar1.Visible = false;
            this.Cursor = Cursors.WaitCursor;
            NuovoPoster n = new NuovoPoster(inizio,null, this, /*null,*/ -1, null, directory_principale,  visualizza_aut);
            n.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }

        private void SingoloPoster_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            NuovoPoster nuovo = new NuovoPoster(this.inizio,null, this, /*null,*/ -1, null, directory_principale, visualizza_aut);
            //this.Visible = false;
            nuovo.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }

        private void ModificaSingoli_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            PosterDellaMostra nuova = new PosterDellaMostra(this, /*null,*/ -1, null, directory_principale, visualizza_aut,null,null,null);
            //this.Visible = false;
            nuova.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }

        public Welcome GetInizio()
        {
            return inizio;
        }

       

        

        
    }
}
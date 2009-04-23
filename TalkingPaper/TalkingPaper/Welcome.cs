using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Collections;
using RFIDlibrary;
using NHibernate;
using NHibernate.Cfg;
using QuartzTypeLib;



namespace TalkingPaper
{
    public partial class Welcome : FormSchema
    {
        private string directoryprincipale;
        private string database = "talkingpaper2";
        private ArrayList iscritti = new ArrayList();

    //    private string TecnologiaDaUsare;

        public Welcome()
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 80, true);

            this.directoryprincipale = Directory.GetCurrentDirectory();
            button1.Cursor = Cursors.Hand;
            button2.Cursor = Cursors.Hand;
            Admin.Cursor = Cursors.Hand;
            Esci.Cursor = Cursors.Hand;
        }

        private void Esci_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void postering_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            this.Cursor = Cursors.WaitCursor;
            TalkingPaper.Postering.BenvenutoPostering nuov = new TalkingPaper.Postering.BenvenutoPostering(this,null,null,null,null,directoryprincipale);
            nuov.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }

        private void BarCodeTagging_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            this.Cursor = Cursors.WaitCursor;
            TalkingPaper.BarCode.BenvenutoBarCode n = new TalkingPaper.BarCode.BenvenutoBarCode(this);
            n.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }

        private void RFIDTagging_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            this.Cursor = Cursors.WaitCursor;
            TalkingPaper.RfidCode.BenvenutoRFID nu = new TalkingPaper.RfidCode.BenvenutoRFID(this);
            nu.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }

        private void EsecuzioneBarCodePoster_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            this.Cursor = Cursors.WaitCursor;
            ElencoPosterEsecuzioneSingolo el = new ElencoPosterEsecuzioneSingolo(null, this, -1, null, null, directoryprincipale, database, "barcode");
            //FormEsecuzioneBarcodePoster nuova = new FormEsecuzioneBarcodePoster(1,this);
            el.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }

        private void EsecuzioneRFIDPoster_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            this.Cursor = Cursors.WaitCursor;
            ElencoPosterEsecuzioneSingolo el = new ElencoPosterEsecuzioneSingolo(null, this, -1, null, null, directoryprincipale, database, "rfid");
            //FormEsecuzioneRfidPoster nuov = new FormEsecuzioneRfidPoster(2,this);
            el.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //Welcome2 n = new Welcome2(this,directoryprincipale);
            TalkingPaper.Postering.BenvenutoPostering n = new TalkingPaper.Postering.BenvenutoPostering(this, null, null, null, null, directoryprincipale);
            n.Show();
            this.Visible = false;
            this.Cursor = Cursors.Default;

        }

        private void button2_Click(object sender, EventArgs e)
        {
           this.Cursor = Cursors.WaitCursor;
           TalkingPaper.GestioneDisposizione.BenvenutoGestioneDisposizione n = new TalkingPaper.GestioneDisposizione.BenvenutoGestioneDisposizione(this, null, null, directoryprincipale);
           n.Show();
           this.Cursor = Cursors.Default;
           this.Visible = false;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            LoginAdmin n = new LoginAdmin(this, directoryprincipale);
            n.Show();
            this.Visible = false;
            this.Cursor = Cursors.Default;
        }

        private void parlaLibero_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ElencoPosterEsecuzioneSingolo el;
            if (global.rfid == false) //barcode
                el = new ElencoPosterEsecuzioneSingolo(null, this, -1, null, null, directoryprincipale, database, "barcode");
            else //rfid
                el = new ElencoPosterEsecuzioneSingolo(null, this, -1, null, null, directoryprincipale, database, "rfid");
            el.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }

        private void parlaSchema_Click(object sender, EventArgs e)
        {
            if (global.rfid == true) //rfid
            {
                this.Cursor = Cursors.WaitCursor;
                ElencoPosterEsecuzioneSingoloModello el = new ElencoPosterEsecuzioneSingoloModello(null, this, -1, null, null, directoryprincipale, database, "rfid");
                el.Show();
                this.Cursor = Cursors.Default;
                this.Visible = false;
            }

        }

        private void Welcome_Load(object sender, EventArgs e)
        {
            global.rfid = true;
            global.home = this;
            global.inizio = this;
        }

        

    }
}
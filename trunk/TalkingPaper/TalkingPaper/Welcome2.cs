using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TalkingPaper
{
    public partial class Welcome2 : FormSchema
    {

        private string directoryprincipale;
        private string database = "talkingpaper2";
        private Welcome beginning;


        public Welcome2(Welcome beginning, string directoryprincipale)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 80, true);
            this.directoryprincipale = directoryprincipale;
            this.beginning = beginning;
            postering.Cursor = Cursors.Hand;
            BarCodeTagging.Cursor = Cursors.Hand;
            RFIDTagging.Cursor = Cursors.Hand;
            EsecuzioneBarCodePoster.Cursor = Cursors.Hand;
            EsecuzioneRFIDPoster.Cursor = Cursors.Hand;
            Esci.Cursor = Cursors.Hand;
            //Authoring.Cursor = Cursors.Hand;
        }

        private void Esci_Click(object sender, EventArgs e)
        {
            beginning.Visible = true;
            this.Close();
        }

        private void postering_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            this.Cursor = Cursors.WaitCursor;
            TalkingPaper.Postering.BenvenutoPostering nuov = new TalkingPaper.Postering.BenvenutoPostering(beginning,null,null,null,null,directoryprincipale);
            nuov.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }

        private void BarCodeTagging_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            this.Cursor = Cursors.WaitCursor;
            TalkingPaper.BarCode.BenvenutoBarCode n = new TalkingPaper.BarCode.BenvenutoBarCode(beginning);
            n.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }

        private void RFIDTagging_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            this.Cursor = Cursors.WaitCursor;
            TalkingPaper.RfidCode.BenvenutoRFID nu = new TalkingPaper.RfidCode.BenvenutoRFID(beginning);
            nu.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }

        private void EsecuzioneBarCodePoster_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            this.Cursor = Cursors.WaitCursor;
            ElencoPosterEsecuzioneSingolo el = new ElencoPosterEsecuzioneSingolo(null, beginning, -1, null, null, directoryprincipale, database, "barcode");
            //FormEsecuzioneBarcodePoster nuova = new FormEsecuzioneBarcodePoster(1,this);
            el.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }

        private void EsecuzioneRFIDPoster_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            this.Cursor = Cursors.WaitCursor;
            ElencoPosterEsecuzioneSingolo el = new ElencoPosterEsecuzioneSingolo(null, beginning, -1, null, null, directoryprincipale, database, "rfid");
            //FormEsecuzioneRfidPoster nuov = new FormEsecuzioneRfidPoster(2,this);
            el.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            /*this.Cursor = Cursors.WaitCursor;
            TalkingPaper.GestioneDisposizione.BenvenutoGestioneDisposizione n = new TalkingPaper.GestioneDisposizione.BenvenutoGestioneDisposizione(this, null, null);
            n.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;*/
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //add by mac
            if (pictureBoxPost2.Visible = true)
            {
                pictureBoxPost2.Visible = true;
                textBoxPost.Visible = true;
            }
            else {
                pictureBoxPost2.Visible = true;
                textBoxPost.Visible = true;
            }


        }


    }
}
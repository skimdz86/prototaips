using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TalkingPaper.Postering
{
    public partial class QuestionPostering : Form
    {
        BenvenutoPostering benvenuto;
        private Welcome inizio;
        private ComponentiDelPoster componenti_poster;
        private TalkingPaper.BarCode.BenvenutoBarCode benvenuto_bar;
        private TalkingPaper.RfidCode.BenvenutoRFID benvenuto_rfid;
        private TalkingPaper.BarCode.FormVisualizzaElementi visualizza_bar;
        private TalkingPaper.RfidCode.FormVisualizzaElementiRFID visualizza_rfid;

        public QuestionPostering(BenvenutoPostering benvenuto, Welcome inizio,ComponentiDelPoster componenti_poster, TalkingPaper.BarCode.BenvenutoBarCode benvenuto_bar, TalkingPaper.RfidCode.BenvenutoRFID benvenuto_rfid, TalkingPaper.BarCode.FormVisualizzaElementi visualizza_bar, TalkingPaper.RfidCode.FormVisualizzaElementiRFID visualizza_rfid)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 45, true);
            this.componenti_poster = componenti_poster;
            this.benvenuto_bar = benvenuto_bar;
            this.benvenuto_rfid = benvenuto_rfid;
            this.visualizza_bar = visualizza_bar;
            this.visualizza_rfid = visualizza_rfid;
            this.benvenuto = benvenuto;
            this.Show();
            this.inizio = inizio;
            Si.Cursor = Cursors.Hand;
            Annulla.Cursor = Cursors.Hand;
        }

        private void QuestionPostering_Load(object sender, EventArgs e)
        {

        }

        private void Si_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if ((benvenuto != null)&&(inizio!=null))
            {
                benvenuto.Close();
                this.Close();
                if (componenti_poster != null) {
                    componenti_poster.Close();
                }
                inizio.Visible = true;
            }
            else if ((benvenuto_bar != null) && (benvenuto_bar.getInizio() != null)) {
                if (componenti_poster != null) {
                    componenti_poster.Close();
                }
                this.Close();
                benvenuto_bar.getInizio().Visible = true;
            }
            else if ((benvenuto_rfid != null) && (benvenuto_rfid.getInizio() != null)) {
                if (componenti_poster != null) {
                    componenti_poster.Close();
                }
                this.Close();
                benvenuto_rfid.getInizio().Visible = true;
            }
            this.Cursor = Cursors.Default;
        }

        private void Annulla_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (componenti_poster != null) {
                componenti_poster.Visible = true;
                this.Close();
            }
            else if (benvenuto != null)
            {
                benvenuto.Visible = true;
                this.Close();
            }
            this.Cursor = Cursors.Default;
            
        }

        private void QuestionPostering_Load_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Si_Click_1(object sender, EventArgs e)
        {

        }

        private void Annulla_Click_1(object sender, EventArgs e)
        {

        }

    }
}
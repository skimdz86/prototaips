using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TalkingPaper.GestioneDisposizione
{
    public partial class QuestionPostering : Form
    {
        BenvenutoGestioneDisposizione benvenuto;
        private Welcome inizio;
        private ComponentiDelPoster componenti_poster;
        /*private TalkingPaper.BarCode.BenvenutoBarCode benvenuto_bar;
        private TalkingPaper.RfidCode.BenvenutoRFID benvenuto_rfid;
        private TalkingPaper.BarCode.FormVisualizzaElementi visualizza_bar;
        private TalkingPaper.RfidCode.FormVisualizzaElementiRFID visualizza_rfid;*/
        private TalkingPaper.Authoring.BenvenutoAuthoring benvenuto_aut;
        private TalkingPaper.Authoring.FormVisualizzaElementiAuthoring visualizza_aut;

        public QuestionPostering(BenvenutoGestioneDisposizione benvenuto, Welcome inizio, ComponentiDelPoster componenti_poster, TalkingPaper.Authoring.BenvenutoAuthoring benvenuto_aut, TalkingPaper.Authoring.FormVisualizzaElementiAuthoring visualizza_aut)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 45, true);
            this.componenti_poster = componenti_poster;
            /*this.benvenuto_bar = benvenuto_bar;
            this.benvenuto_rfid = benvenuto_rfid;
            this.visualizza_bar = visualizza_bar;
            this.visualizza_rfid = visualizza_rfid;*/
            this.benvenuto_aut = benvenuto_aut;
            this.visualizza_aut = visualizza_aut;
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
            if ((benvenuto != null) && (inizio != null))
            {
                benvenuto.Close();
                this.Close();
                if (componenti_poster != null)
                {
                    componenti_poster.Close();
                }
                inizio.Visible = true;
            }
            else if ((benvenuto_aut != null) && (benvenuto_aut.getInizio() != null))
            {
                if (componenti_poster != null)
                {
                    componenti_poster.Close();
                }
                this.Close();
                benvenuto_aut.getInizio().Visible = true;
            }
            else if (inizio != null) {
                inizio.Visible = true;
                this.Close();
            }
            /*else if ((benvenuto_rfid != null) && (benvenuto_rfid.getInizio() != null))
            {
                if (componenti_poster != null)
                {
                    componenti_poster.Close();
                }
                this.Close();
                benvenuto_rfid.getInizio().Visible = true;
            }*/
            this.Cursor = Cursors.Default;
        }

        private void Annulla_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (componenti_poster != null)
            {
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

    }
}
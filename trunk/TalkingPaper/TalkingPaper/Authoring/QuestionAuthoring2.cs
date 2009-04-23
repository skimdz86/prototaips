using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TalkingPaper.Authoring
{
    public partial class QuestionAuthoring2 : Form
    {
        BenvenutoAuthoring benvenuto;
        FormVisualizzaElementiAuthoring visualizza_elementi;
        private TalkingPaper.GestioneDisposizione.ComponentiDelPoster componenti_pos;
        private TalkingPaper.GestioneDisposizione.BenvenutoGestioneDisposizione benvenuto_pos;
        private GestioneDisposizione.BenvenutoGestioneDisposizione benvenuto_ges;
        //private TalkingPaper.BarCode.BenvenutoBarCode benvenuto_bar;

        public QuestionAuthoring2(BenvenutoAuthoring benvenuto, FormVisualizzaElementiAuthoring visualizza_elementi, TalkingPaper.GestioneDisposizione.ComponentiDelPoster componenti_pos, TalkingPaper.GestioneDisposizione.BenvenutoGestioneDisposizione benvenuto_pos, GestioneDisposizione.BenvenutoGestioneDisposizione benvenuto_ges)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 45, true);
            //this.benvenuto_bar = benvenuto_bar;
            this.benvenuto_pos = benvenuto_pos;
            this.benvenuto = benvenuto;
            this.visualizza_elementi = visualizza_elementi;
            this.benvenuto_ges = benvenuto_ges;
            this.componenti_pos = componenti_pos;
            Si.Cursor = Cursors.Hand;
            Annulla.Cursor = Cursors.Hand;
        }

        private void QuestionAuthoring2_Load(object sender, EventArgs e)
        {

        }

        private void Si_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //this.Close();
            if (benvenuto_ges != null)
            {
                if (visualizza_elementi != null)
                {
                    visualizza_elementi.Close();
                }
                if (benvenuto_ges.GetInizio() != null)
                {
                    benvenuto_ges.GetInizio().Visible = true;
                }
                benvenuto_ges.Close();
            }
            if (benvenuto != null)
            {
                if (visualizza_elementi != null)
                {
                    visualizza_elementi.Close();
                }
                if (benvenuto.getInizio() != null)
                {
                    benvenuto.getInizio().Visible = true;
                }
                benvenuto.Close();
            }
            if (componenti_pos != null)
            {
                TalkingPaper.GestioneDisposizione.BenvenutoGestioneDisposizione ben = componenti_pos.GetBenvenuto();
                if (ben != null)
                {
                    Welcome wel = ben.GetInizio();
                    if (wel != null)
                    {
                        if (visualizza_elementi != null)
                        {
                            visualizza_elementi.Close();
                        }
                        wel.Visible = true; ;
                    }
                    //componenti_pos.Close();
                    ben.Close();
                    //wel.Close();
                }
                componenti_pos.Close();
            } if (benvenuto_pos != null)
            {
                if (benvenuto_pos.GetInizio() != null)
                {
                    benvenuto_pos.GetInizio().Visible = true; ;
                }
                benvenuto_pos.Close();
            }
            /*if (benvenuto_bar != null)
            {
                if (benvenuto_bar.getInizio() != null)
                {
                    benvenuto_bar.getInizio().Visible = true;
                }
                benvenuto_bar.Close();
            }*/
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void Annulla_Click(object sender, EventArgs e)
        {
            visualizza_elementi.Visible = true;
            this.Close();
        }

        private void QuestionAuthoring2_Load_1(object sender, EventArgs e)
        {

        }

    }
}
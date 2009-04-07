using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TalkingPaper.RfidCode
{
    public partial class QuestionRFID2 : Form
    {
        BenvenutoRFID benvenuto;
        FormVisualizzaElementiRFID visualizza_elementi;
        private TalkingPaper.Postering.ComponentiDelPoster componenti_pos;
        private TalkingPaper.Postering.BenvenutoPostering benvenuto_pos;
        private TalkingPaper.BarCode.BenvenutoBarCode benvenuto_bar;

        public QuestionRFID2(BenvenutoRFID benvenuto, FormVisualizzaElementiRFID visualizza_elementi, TalkingPaper.Postering.ComponentiDelPoster componenti_pos, TalkingPaper.Postering.BenvenutoPostering benvenuto_pos,TalkingPaper.BarCode.BenvenutoBarCode benvenuto_bar)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 45, true);
            this.benvenuto_bar = benvenuto_bar;
            this.benvenuto_pos = benvenuto_pos;
            this.benvenuto = benvenuto;
            this.visualizza_elementi = visualizza_elementi;
            this.componenti_pos = componenti_pos;
            Si.Cursor = Cursors.Hand;
            Annulla.Cursor = Cursors.Hand;
        }

        private void QuestionRFID2_Load(object sender, EventArgs e)
        {

        }

        private void Si_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //this.Close();
            if (benvenuto != null)
            {
                if (visualizza_elementi != null)
                {
                    visualizza_elementi.Close();
                }
                if (benvenuto.getInizio() != null) {
                    benvenuto.getInizio().Visible = true;
                }
                benvenuto.Close();
            }
            if (componenti_pos != null) {
                TalkingPaper.Postering.BenvenutoPostering ben = componenti_pos.GetBenvenuto();
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
            } if (benvenuto_pos != null) {
                if (benvenuto_pos.GetInizio() != null) {
                    benvenuto_pos.GetInizio().Visible = true; ;
                }
                benvenuto_pos.Close();
            }
            if (benvenuto_bar != null) {
                if (benvenuto_bar.getInizio() != null) {
                    benvenuto_bar.getInizio().Visible = true;
                }
                benvenuto_bar.Close();
            }
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void Annulla_Click(object sender, EventArgs e)
        {
            visualizza_elementi.Visible = true;
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
 
    }
}
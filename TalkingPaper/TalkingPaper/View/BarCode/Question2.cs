using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TalkingPaper.BarCode
{
    public partial class Question2 : Form
    {
        private BenvenutoBarCode benvenuto;
        FormVisualizzaElementi visualizza_elementi;
        private TalkingPaper.Postering.ComponentiDelPoster componenti_pos;
        private TalkingPaper.Postering.BenvenutoPostering benvenuto_pos;
        private TalkingPaper.RfidCode.BenvenutoRFID benvenuto_rfid;

        public Question2(BenvenutoBarCode benvenuto, FormVisualizzaElementi visualizza_elementi, TalkingPaper.Postering.ComponentiDelPoster componenti_pos,TalkingPaper.Postering.BenvenutoPostering benvenuto_pos,TalkingPaper.RfidCode.BenvenutoRFID benvenuto_rfid)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 45, true);
            this.benvenuto_rfid = benvenuto_rfid;
            this.benvenuto = benvenuto;
            this.benvenuto_pos = benvenuto_pos;
            this.visualizza_elementi = visualizza_elementi;
            this.componenti_pos = componenti_pos;
            Si.Cursor = Cursors.Hand;
            Annulla.Cursor = Cursors.Hand;
        }

        private void Question2_Load(object sender, EventArgs e)
        {

        }

        private void Si_Click(object sender, EventArgs e)
        {
            //this.Close();
            this.Cursor = Cursors.WaitCursor;
            if (benvenuto != null)
            {
                if (visualizza_elementi != null)
                {
                    visualizza_elementi.Close();
                }
                if (benvenuto.getInizio() != null)
                {
                    benvenuto.getInizio().Visible=true;
                }
                benvenuto.Close();
            }
            if (componenti_pos != null)
            {
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
            } if (benvenuto_pos != null)
            {
                if (benvenuto_pos.GetInizio() != null)
                {
                    benvenuto_pos.GetInizio().Visible=true;
                }
                benvenuto_pos.Close();
            }
            if (benvenuto_rfid != null) {
                if (benvenuto_rfid.getInizio() != null) {
                    benvenuto_rfid.getInizio().Visible = true;
                }
                benvenuto_rfid.Close();
            }
            this.Cursor = Cursors.Default;
            this.Close();
            
        }

        private void Annulla_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            visualizza_elementi.Visible = true;
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
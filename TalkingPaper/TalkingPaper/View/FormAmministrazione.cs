using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using RFIDlibrary;
using NHibernate;
using NHibernate.Cfg;
using QuartzTypeLib;
using System.Xml;


namespace TalkingPaper
{
    public partial class FormAmministrazione : Form
    {
        private Welcome beginning;
        private string user;
        private string directoryprincipale;
        
        public FormAmministrazione(Welcome beginning, string user,string directoryprincipale)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 75, true);
            this.user = user;
            this.beginning = beginning;
            this.directoryprincipale = directoryprincipale;
            label1.Text = label1.Text + " " + user;
            button1.Cursor = Cursors.Hand;
            button2.Cursor = Cursors.Hand;
            button3.Cursor = Cursors.Hand;
            button4.Cursor = Cursors.Hand;
            button5.Cursor = Cursors.Hand;
            button6.Cursor = Cursors.Hand;
            button7.Cursor = Cursors.Hand;
            button8.Cursor = Cursors.Hand;
            //this.directoryprincipale = Directory.GetCurrentDirectory();
            //label1.Text = label1.Text + " " + user;
        }

        private void FormAmministrazione_Load(object sender, EventArgs e)
        {
            if(global.rfid==true)
                this.label4.Text = "Stai Utilizzando: Rfid";
            else
                this.label4.Text = "Stai Utilizzando: Codice a Barre";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            beginning.Visible = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            NuovoAmministratore n = new NuovoAmministratore(this,directoryprincipale);
            n.Show();
            this.Visible = false;
            this.Cursor = Cursors.Default;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Config.FormRfidConfig n = new TalkingPaper.Config.FormRfidConfig(this,directoryprincipale);
            n.Show();
            this.Visible = false;
            this.Cursor = Cursors.Default;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //GestioneDisposizione.TaggingDellaParete n = new TalkingPaper.GestioneDisposizione.TaggingDellaParete(null, this);
            GestioneDisposizione.TagRigaColonna n = new TalkingPaper.GestioneDisposizione.TagRigaColonna(this, directoryprincipale);
            n.Show();
            this.Visible = false;
            this.Cursor = Cursors.Default;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            GestioneDisposizione.ScegliPannelloPerConfigurazione n = new GestioneDisposizione.ScegliPannelloPerConfigurazione(directoryprincipale, null,this);
            n.Show();
            this.Visible = false;
            this.Cursor = Cursors.Default;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Authoring.EliminaAmministratore n = new TalkingPaper.Authoring.EliminaAmministratore(this, directoryprincipale,user);
            n.Show();
            this.Visible = false;
            this.Cursor = Cursors.Default;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            FiltroStorie n = new FiltroStorie(this, directoryprincipale);
            n.Show();
            this.Visible = false;
            this.Cursor = Cursors.Default;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            TalkingPaper.global.rfid = false;
            this.Cursor = Cursors.WaitCursor;
            this.Cursor = Cursors.Default;
            this.label4.Text = "Stai Utilizzando: Codice a Barre";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            TalkingPaper.global.rfid = true;
            this.Cursor = Cursors.WaitCursor;
            this.Cursor = Cursors.Default;
            this.label4.Text = "Stai Utilizzando: Rfid";
        }

        private void Funzionalita_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = !groupBox4.Visible;
            groupBox5.Visible = !groupBox5.Visible;
            groupBox6.Visible = !groupBox6.Visible;
            label4.Visible = !label4.Visible;
            if (groupBox4.Visible == true)
                Funzionalita.Text = "Funzionalita di Base";
            else
                Funzionalita.Text = "Funzionalita Avanzate";
        }

    }
}
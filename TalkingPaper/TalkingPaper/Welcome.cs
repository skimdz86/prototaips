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
            
            button2.Cursor = Cursors.Hand;
            Admin.Cursor = Cursors.Hand;
            Esci.Cursor = Cursors.Hand;
        }

        private void Esci_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
           this.Cursor = Cursors.WaitCursor;
           TalkingPaper.GestioneDisposizione.BenvenutoGestioneDisposizione n = new TalkingPaper.GestioneDisposizione.BenvenutoGestioneDisposizione(this, null, directoryprincipale);
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

       private void parlaSchema_Click(object sender, EventArgs e)
        {
            if (global.rfid == true) //rfid
            {
                this.Cursor = Cursors.WaitCursor;
                ElencoPosterEsecuzioneSingoloModello el = new ElencoPosterEsecuzioneSingoloModello(/*null,*/ this, -1, null, null, directoryprincipale, database, "rfid");
                if (!(el.IsDisposed))
                {
                    el.Show();
                    this.Visible = false;
                }
                this.Cursor = Cursors.Default;
                
            }

        }

        private void Welcome_Load(object sender, EventArgs e)
        {
            global.rfid = true;
            global.home = this;
            global.inizio = this;
        }

        private void test_button_Click(object sender, EventArgs e)
        {
            TalkingPaper.TestForm f = new TalkingPaper.TestForm();
            f.Show();
        }

        

    }
}
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
using TalkingPaper.Common;



namespace TalkingPaper.Welcome
{
    public partial class ChildHomeForm : Common.FormSchema
    {
        private string directoryprincipale;
        private string database = "talkingpaper2";
        private ArrayList iscritti = new ArrayList();

    //    private string TecnologiaDaUsare;

        public ChildHomeForm()
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 80, true);

            this.directoryprincipale = Directory.GetCurrentDirectory();
            
            button2.Cursor = Cursors.Hand;
            
            Esci.Cursor = Cursors.Hand;
        }

        private void Esci_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
           this.Cursor = Cursors.WaitCursor;
           TalkingPaper.Authoring.NuovoCartelloneForm n = new TalkingPaper.Authoring.NuovoCartelloneForm();
           n.Show();
           this.Cursor = Cursors.Default;
           this.Visible = false;
        }



        private void parlaSchema_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Execution.ElencoCartelloniForm el = new Execution.ElencoCartelloniForm(/*null,*/ this, -1, null, null, directoryprincipale, database, "rfid");
            if (!(el.IsDisposed))
            {
                el.Show();
                this.Visible = false;
            }
            this.Cursor = Cursors.Default;
        }

        private void Welcome_Load(object sender, EventArgs e)
        {
            Global.home = this;
            //global.inizio = this;
        }

        private void test_button_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            TalkingPaper.Authoring.ModificaCartelloneForm mod = new TalkingPaper.Authoring.ModificaCartelloneForm();
            mod.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }

        

    }
}
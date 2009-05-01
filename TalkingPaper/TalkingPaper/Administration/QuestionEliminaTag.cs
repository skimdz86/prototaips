using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using NHibernate;
using NHibernate.Cfg;
using QuartzTypeLib;
using System.Xml;


namespace TalkingPaper.Administration
{
    public partial class QuestionEliminaTag : Form
    {
        private TaggaGrigliaForm tagging;
        private DataGridView ElencoTag;
        private int colonna;
        private int riga;
        private ArrayList inseriti;
        private string selezionato;
        
        public QuestionEliminaTag(TaggaGrigliaForm tagging,DataGridView ElencoTag,int colonna,int riga,ArrayList inseriti)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 45, true);
            //this.selezionato = selezionato;
            this.tagging = tagging;
            this.ElencoTag = ElencoTag;
            this.colonna = colonna;
            this.riga = riga;
            this.inseriti = inseriti;
        }

        private void QuestionEliminaTag_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            for (int i = 0; i < inseriti.Count; i=i+3) {
                if (((String)inseriti[i]).CompareTo(((String)ElencoTag[colonna, riga].Value)) == 0) {
                    inseriti.RemoveAt(i + 2);
                    inseriti.RemoveAt(i+1);
                    inseriti.RemoveAt(i);
                }
            }
            ElencoTag[colonna, riga].Style.BackColor = Color.BlanchedAlmond;
            ElencoTag[colonna, riga].Value = null;
            selezionato = "Ok";
            tagging.Visible = true;
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ElencoTag[colonna, riga].Style.BackColor = Color.Coral;
            ElencoTag[colonna, riga].Selected = false;
            selezionato = "No";
            tagging.Visible = true;
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }

        public string GetSelezionato() {
            return selezionato;
        }
    }
}
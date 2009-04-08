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


namespace TalkingPaper.Authoring
{
    public partial class EliminaAmministratore : Form
    {
        private ArrayList tutti_utenti = new ArrayList();
        private string user="";
        private FormAmministrazione amministrazione;
        private string directoryprincipale;
        private string user1;
        
        public EliminaAmministratore(FormAmministrazione amministrazione,string directoryprincipale,string user1)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 90, false);
            this.directoryprincipale = directoryprincipale;
            this.amministrazione = amministrazione;
            this.user1 = user1;
            button1.Cursor = Cursors.Hand;
            button2.Cursor = Cursors.Hand;
            CaricaPosterConfigurazioni();
            if (tutti_utenti.Count == 2)
            {
                label2.Visible = true;
                ElencoTag.Visible = false;
                button1.Enabled = false;
            }
            else {
                label2.Visible = false;
                ElencoTag.Visible = true;
                InizializzaDataGrid();
            }
        }

        private void EliminaAmministratore_Load(object sender, EventArgs e)
        {

        }

        private void InizializzaDataGrid()
        {
            Font font = new Font("Arial", 16);
            //textBox1.Click += new EventHandler(textBox1_Click);
            ElencoTag.ColumnCount = 4;
            //ElencoTag.CellClick += new DataGridViewCellEventHandler(ElencoTag_CellClick);
            ElencoTag.CellContentClick += new DataGridViewCellEventHandler(ElencoTag_CellContentClick);
            //ElencoTag.ColumnCount = tag_per_riga + 1;
            //ElencoTag.Rows.Add(tag_per_colonna + 1);
            //ElencoTag.Rows[0].DefaultCellStyle.ForeColor = Color.BlueViolet;
            //ElencoTag.Columns[0].DefaultCellStyle.ForeColor = Color.BlueViolet;
            //ElencoTag.Rows[0].DefaultCellStyle.Font = font;
            //ElencoTag.Columns[0].DefaultCellStyle.Font = font;
            ElencoTag.Columns[0].Visible = false;
            ElencoTag.Rows.Add("  ", "Utente", "  ", "Seleziona");
            ElencoTag.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
            ElencoTag.Rows[0].DefaultCellStyle.Font = font;
            ElencoTag.Rows.Add();
            ElencoTag.CellMouseEnter += new DataGridViewCellEventHandler(ElencoTag_CellMouseEnter);
            ElencoTag[1, 1].Selected = true;
            RiempiDataGrid();
        }

        private void CaricaPosterConfigurazioni()
        {
            try
            {
                string nome_file = directoryprincipale + "UtentiAmministratori" + ".xml";
                XmlTextReader iscritto = new XmlTextReader(nome_file);
                //bool fine = false;
                int i = -1;
                //int j = 1;
                while ((iscritto.Read()))
                {
                    if (iscritto.NodeType == XmlNodeType.Element)
                    {
                        if (iscritto.LocalName.Equals("User"))
                        {
                            //string id = (String)iscritto.GetAttribute("ID");
                            string ins = (string)iscritto.ReadString();
                            //GestioneDisposizione.PannelliConfigurazione p = new GestioneDisposizione.PannelliConfigurazione(id, ins);
                            //tutti_poster.Add(p);
                            tutti_utenti.Add(ins);
                            i++;
                            /*if ((nome_pannello.CompareTo(ins) == 0) && (id_pannello.CompareTo(id) == 0))
                            {
                                posizione = i;
                            }*/
                            //string id = (String)iscritto.GetAttribute("ID");

                            //pannelli.Add(id);
                        }
                        if (iscritto.LocalName.Equals("Password"))
                        {
                            string conf = (String)iscritto.ReadString();
                            //((GestioneDisposizione.PannelliConfigurazione)tutti_poster[i]).InserisciConfigurazione(conf);
                            tutti_utenti.Add(conf);
                            i++;
                        }
                    }
                }
                iscritto.Close();
                //esiste = true;
            }
            catch
            {
                //esiste = false;
            }
        }

        private void RiempiDataGrid() {
            int riga = 2;
            for (int i = 0; i < tutti_utenti.Count - 2; i=i+2) {
                /*if (user1.CompareTo(((string)tutti_utenti[i])) != 0)
                {*/
                    ElencoTag.Rows.Add(tutti_utenti[i + 1], tutti_utenti[i], null, null);
                    DataGridViewCheckBoxCell cella = new DataGridViewCheckBoxCell();
                    cella.Value = false;
                    //modify.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    cella.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    ElencoTag[3, riga] = cella;
                    riga += 2;
                    ElencoTag.Rows.Add();
                //}
            }
        }

        private void ElencoTag_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 3) && (ElencoTag[e.ColumnIndex, e.RowIndex].Value != null) && (ElencoTag[e.ColumnIndex, e.RowIndex] != null))
            {
                if ((bool)ElencoTag[e.ColumnIndex, e.RowIndex].Value == false)
                {
                    ElencoTag[e.ColumnIndex, e.RowIndex].Value = true;
                    user = (string)ElencoTag[1, e.RowIndex].Value;
                }
                else if ((bool)ElencoTag[e.ColumnIndex, e.RowIndex].Value == true)
                {
                    ElencoTag[e.ColumnIndex, e.RowIndex].Value = false;
                    user = "";
                }
                for (int i = 2; i < ElencoTag.Rows.Count; i++)
                {
                    if ((ElencoTag[3, i].Value != null) && (ElencoTag[3, i] != null) && (i != e.RowIndex))
                    {
                        ElencoTag[3, i].Value = false;
                    }
                }
            }
        }

        private void ScriviFileXml() {
            try
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.NewLineOnAttributes = true;
                XmlWriter wr = XmlWriter.Create(directoryprincipale + "UtentiAmministratori" + ".xml");
                wr.WriteStartDocument();
                wr.WriteStartElement("Amministratori");
                for (int i = 0; i < tutti_utenti.Count; i=i+2) {
                    if (((string)tutti_utenti[i]).CompareTo(user) != 0) {
                        wr.WriteStartElement("Utente");
                        wr.WriteStartElement("User");
                        wr.WriteString((string)tutti_utenti[i]);
                        wr.WriteEndElement();
                        wr.WriteStartElement("Password");
                        wr.WriteString((string)tutti_utenti[i+1]);
                        wr.WriteEndElement();
                        wr.WriteEndElement();
                    }
                
                }
                wr.WriteEndElement();  
                wr.WriteEndDocument();
                wr.Flush();
                wr.Close();
                MessageBox.Show("Amministratore Eliminato");
            }
            catch
            { 
            
            }
        
        }

        private void ElencoTag_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 3) && (e.RowIndex != 0))
            {
                if (ElencoTag[e.ColumnIndex, e.RowIndex].Value != null)
                {
                    ElencoTag.Cursor = Cursors.Hand;
                }
                else
                    ElencoTag.Cursor = Cursors.Default;
            }
            else
                ElencoTag.Cursor = Cursors.Default;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            amministrazione.Visible = true;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (user.CompareTo("") == 0)
            {
                MessageBox.Show("Non hai selezionato nessun utente");
            }
            else {
                ScriviFileXml();
                amministrazione.Visible = true;
                this.Close();
            }
        }

        private void indietro_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void grouppoControl_Enter(object sender, EventArgs e)
        {

        }

        private void Menu_Click(object sender, EventArgs e)
        {
            QuestionCambiaGriglia richiesta = new QuestionCambiaGriglia(null, global.home);
            richiesta.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }


    }
}
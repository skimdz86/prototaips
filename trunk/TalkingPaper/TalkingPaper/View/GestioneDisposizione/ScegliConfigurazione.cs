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

namespace TalkingPaper.GestioneDisposizione
{
    public partial class ScegliConfigurazione : Form
    {
        private int tag_per_riga;
        private int tag_per_colonna;
        private string directory_principale;
        private string id_pannello;
        private string nome_pannello;
        private ArrayList inseriti = new ArrayList();
        private ArrayList tutti_poster = new ArrayList();
        private BenvenutoGestioneDisposizione benvenuto;
        private int posizione;
        private FormAmministrazione amministrazione;

        private char[] alfabeto ={ 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'Z' };
        
        public ScegliConfigurazione(string nome_pannello,string id_pannello,BenvenutoGestioneDisposizione benvenuto,FormAmministrazione amministrazione,int tag_per_riga,int tag_per_colonna)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 98, true);
            this.directory_principale = Directory.GetCurrentDirectory();
            this.amministrazione = amministrazione;
            this.id_pannello = id_pannello;
            this.nome_pannello = nome_pannello;
            this.tag_per_colonna = tag_per_colonna;
            this.tag_per_riga = tag_per_riga;
            textBox3.Text = nome_pannello;
            textBox2.Text = id_pannello;
            this.benvenuto = benvenuto;
            button1.Cursor = Cursors.Hand;
            button2.Cursor = Cursors.Hand;
            InizializzaDataGrid();
            CaricaPosterConfigurazioni();
            this.Show();
        }

        private void ScegliConfigurazione_Load(object sender, EventArgs e)
        {
            try
            {
                string nome_file = directory_principale + "Griglia" + nome_pannello+id_pannello + ".xml";
                XmlTextReader iscritto = new XmlTextReader(nome_file);
                bool fine = false;
                int i = 1;
                int j = 1;
                while ((iscritto.Read()) && (fine == false))
                {
                    if (iscritto.NodeType == XmlNodeType.Element)
                    {
                        if (iscritto.LocalName.Equals(alfabeto[i - 1].ToString() + j.ToString()))
                        {
                            string ins = (String)iscritto.ReadString();
                            if (ins.CompareTo("Nessun Valore") != 0)
                            {
                                //string ins = (String)iscritto.ReadString();
                                inseriti.Add(ins);
                                inseriti.Add((String)alfabeto[i - 1].ToString());
                                inseriti.Add((int)j);
                            }
                            i++;
                        }
                    }
                    if (i > tag_per_colonna)
                    {
                        j++;
                        i = 1;
                    }
                    if (j > tag_per_riga)
                    {
                        fine = true;
                    }
                }
                //esiste = true;
            }
            catch
            {
                //esiste = false;
            }
        }

        private void CaricaPosterConfigurazioni() {
            try
            {
                string nome_file = directory_principale + "PannelliTaggati" + ".xml";
                XmlTextReader iscritto = new XmlTextReader(nome_file);
                bool fine = false;
                int i = -1;
                int j = 1;
                while ((iscritto.Read()))
                {
                    if (iscritto.NodeType == XmlNodeType.Element)
                    {
                        if (iscritto.LocalName.Equals("NomePannello"))
                        {
                            string id = (String)iscritto.GetAttribute("ID");
                            string ri = (String)iscritto.GetAttribute("TAG_PER_RIGA");
                            string co = (String)iscritto.GetAttribute("TAG_PER_COLONNA");
                            string ins = (string)iscritto.ReadString();
                            PannelliConfigurazione p = new PannelliConfigurazione(id, ins,ri,co);
                            tutti_poster.Add(p);
                            i++;
                            if ((nome_pannello.CompareTo(ins) == 0) && (id_pannello.CompareTo(id) == 0)) {
                                posizione = i;
                            }
                            //string id = (String)iscritto.GetAttribute("ID");
                            
                            //pannelli.Add(id);
                        }
                        if (iscritto.LocalName.Equals("Configurazione"))
                        {
                            string conf = (String)iscritto.ReadString();
                            ((PannelliConfigurazione)tutti_poster[i]).InserisciConfigurazione(conf);
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

        private void InizializzaDataGrid()
        {
            //int valore = 0;
            Font font = new Font("Arial", 16);
            //textBox1.Click += new EventHandler(textBox1_Click);
            ElencoTag.CellClick += new DataGridViewCellEventHandler(ElencoTag_CellClick);
            ElencoTag.ColumnCount = tag_per_riga + 1;
            ElencoTag.Rows.Add(tag_per_colonna + 1);
            ElencoTag.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
            ElencoTag.Columns[0].DefaultCellStyle.ForeColor = Color.Red;
            ElencoTag.Rows[0].DefaultCellStyle.Font = font;
            ElencoTag.Columns[0].DefaultCellStyle.Font = font;
            for (int i = 1; i <= tag_per_colonna; i++)
            {
                ElencoTag[0, i].Value = i;
            }
            for (int j = 1; j <= tag_per_riga; j++)
            {
                ElencoTag.Columns[j].Width = 110;
                ElencoTag[j, 0].Value = alfabeto[j - 1];
            }
        }

        private void ElencoTag_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex != 0) && (e.ColumnIndex != 0)) {
                if ((ElencoTag[e.ColumnIndex, e.RowIndex].Style.BackColor == Color.BlanchedAlmond) || (ElencoTag[e.ColumnIndex, e.RowIndex].Style.BackColor.Name.CompareTo("0")==0))
                {
                    ElencoTag[e.ColumnIndex, e.RowIndex].Selected = false;
                    ElencoTag[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Coral;
                }
                else {
                    ElencoTag[e.ColumnIndex, e.RowIndex].Selected = false;
                    ElencoTag[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.BlanchedAlmond;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ArrayList inseriti = new ArrayList();
            this.Cursor = Cursors.WaitCursor;
            if ((textBox1.Text == null) || (textBox1.Text.CompareTo("") == 0))
            {
                MessageBox.Show("Non hai inserito il nome della configurazione");
                this.Cursor = Cursors.Default;
            }
            else if ((textBox2.Text == null) || (textBox2.Text.CompareTo("") == 0)){
                MessageBox.Show("Non hai inserito il tag del pannello");
                this.Cursor = Cursors.Default;
            }else {
                ((PannelliConfigurazione)tutti_poster[posizione]).InserisciConfigurazione(textBox1.Text);
                int i = 1;
                int j = 1;
                try
                {
                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Indent = true;
                    settings.NewLineOnAttributes = true;
                    XmlWriter wr = XmlWriter.Create(directory_principale + "Griglia" + nome_pannello+textBox2.Text +textBox1.Text+ ".xml", settings);
                    wr.WriteStartDocument();
                    wr.WriteStartElement("GrigliaTaggata");
                    wr.WriteStartElement("NomePannello");
                    wr.WriteStartAttribute("ID");
                    wr.WriteString(id_pannello);
                    wr.WriteEndAttribute();
                    wr.WriteString(nome_pannello);
                    wr.WriteStartElement("Configurazione",textBox1.Text);
                    int indice = 0;
                    bool trovato = false;
                    try
                    {
                        for (i = 1; i <= tag_per_colonna; i++) {
                            for (j = 1; j <= tag_per_riga; j++) {
                                if (ElencoTag[j, i].Style.BackColor == Color.Coral)
                                {
                                    for (int k = 0; k < inseriti.Count; k = k + 3)
                                    {
                                        if (((String)inseriti[k + 1]).CompareTo(alfabeto[j - 1].ToString()) == 0)
                                        {
                                            if (((int)inseriti[k + 2]) == i)
                                            {
                                                wr.WriteStartElement("", (String)inseriti[k + 1] + (ElencoTag[0, i].Value.ToString()), "");
                                                wr.WriteStartAttribute("Usato");
                                                wr.WriteString("true");
                                                wr.WriteEndAttribute();
                                                string ins = (String)inseriti[k];
                                                wr.WriteString(ins);
                                                //wr.WriteAttributeString("Utilizzato", "false");
                                                wr.WriteEndElement();
                                                trovato = true;
                                                indice++;
                                            }
                                        }
                                    }
                                    if (trovato == false)
                                    {
                                        wr.WriteStartElement("", alfabeto[j - 1].ToString() + (ElencoTag[0, i].Value.ToString()), "");
                                        wr.WriteStartAttribute("Usato");
                                        wr.WriteString("false");
                                        wr.WriteEndAttribute();
                                        wr.WriteString("Non Usato");
                                        //wr.WriteAttributeString("Utilizzato", "false");
                                        wr.WriteEndElement();
                                        indice++;
                                    }
                                    trovato = false;
                                }
                                else
                                {
                                    wr.WriteStartElement("", alfabeto[j - 1].ToString() + (ElencoTag[0, i].Value.ToString()), "");
                                    wr.WriteStartAttribute("Usato");
                                    wr.WriteString("false");
                                    wr.WriteEndAttribute();
                                    wr.WriteString("Non Usato");
                                    //wr.WriteAttributeString("Utilizzato", "false");
                                    wr.WriteEndElement();
                                    indice++;
                                }
                            }
                        }
                    }
                    catch { 
                    
                    }

                    wr.WriteEndElement();
                    wr.WriteEndElement();
                    wr.WriteEndElement();
                    wr.WriteEndDocument();
                    wr.Flush();
                    wr.Close();
                }
                catch { 
                
                }
                try
                {
                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Indent = true;
                    settings.NewLineOnAttributes = true;
                    XmlWriter wr = XmlWriter.Create(directory_principale + "PannelliTaggati" + ".xml");
                    wr.WriteStartDocument();
                    wr.WriteStartElement("GrigliaTaggata");
                    wr.WriteStartElement("Pannelli");
                    foreach (PannelliConfigurazione p in tutti_poster)
                    {
                        wr.WriteStartElement("NomePannello");
                        wr.WriteAttributeString("ID", textBox2.Text);
                        wr.WriteAttributeString("TAG_PER_RIGA", p.GetTagRiga());
                        wr.WriteAttributeString("TAG_PER_COLONNA", p.GetTagColonna());
                        wr.WriteString(p.GetNome());
                        //WriteString(p.GetNome());
                        //wr.WriteStartElement("Configurazione", textBox1.Text);
                        for (int h = 0; h < p.GetConffigurazioniCount(); h++) {
                            wr.WriteStartElement("Configurazione");
                            wr.WriteString(p.GetConfigurazione(h));
                            wr.WriteEndElement();
                        }
                        wr.WriteEndElement();
                    }
                    wr.WriteEndElement();
                    wr.WriteEndElement();
                    wr.WriteEndDocument();
                    wr.Flush();
                    wr.Close();
                }
                catch { 
                
                }
                this.Cursor = Cursors.Default;
                MessageBox.Show("Configurazione Salvata");
                if (benvenuto != null)
                {
                    benvenuto.Visible = true;
                }
                else if (amministrazione != null) {
                    amministrazione.Visible = true;
                }
                this.Close();
            }
            this.Cursor = Cursors.Default;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (benvenuto != null)
            {
                benvenuto.Visible = true;
            }
            else if (amministrazione != null) {
                amministrazione.Visible = true;
            }
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void Indietro_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (benvenuto != null)
            {
                benvenuto.Visible = true;
            }
            else if (amministrazione != null)
            {
                amministrazione.Visible = true;
            }
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void ElencoTag_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex != 0) && (e.ColumnIndex != 0))
            {
                if ((ElencoTag[e.ColumnIndex, e.RowIndex].Style.BackColor == Color.BlanchedAlmond) || (ElencoTag[e.ColumnIndex, e.RowIndex].Style.BackColor.Name.CompareTo("0") == 0))
                {
                    ElencoTag[e.ColumnIndex, e.RowIndex].Selected = false;
                    ElencoTag[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Coral;
                }
                else
                {
                    ElencoTag[e.ColumnIndex, e.RowIndex].Selected = false;
                    ElencoTag[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.BlanchedAlmond;
                }
            }
        }
    }
}
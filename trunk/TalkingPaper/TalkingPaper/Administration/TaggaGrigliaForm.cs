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
    public partial class TaggaGrigliaForm : Form
    {
        private ControlLogic.AdministrationControl control;
        private Reader.IReader reader;
        Model.Griglia griglia;
        private int riga = 1;
        private int colonna = 1;
        private ArrayList inseriti = new ArrayList();
        private ArrayList pannelli = new ArrayList();
        private ArrayList tutti_poster = new ArrayList();
              
        private char[] alfabeto ={ 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'Z' };

        public TaggaGrigliaForm(Model.Griglia griglia)
        {
            InitializeComponent();
            //RidimensionaForm n = new RidimensionaForm(this, 98, true);
            this.griglia = griglia;
            ok.Cursor = Cursors.Hand;
            annulla.Cursor = Cursors.Hand;

            control.inizializzaTagging(this,reader);

            //Gestione Eventi
            reader.readerStatusUpdate += rfid_StatusUpdateEvent;
            
            ElencoTag.CellClick += new DataGridViewCellEventHandler(ElencoTag_CellClick);
        }
                
        public void inizializzaDataGrid()
        {
            Font font = new Font("Arial", 16);
            ElencoTag.ColumnCount = griglia.getNumColonne() + 1;
            ElencoTag.Rows.Add(griglia.getNumRighe() + 1);
            ElencoTag.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
            ElencoTag.Columns[0].DefaultCellStyle.ForeColor = Color.Red;
            ElencoTag.Rows[0].DefaultCellStyle.Font = font;
            ElencoTag.Columns[0].DefaultCellStyle.Font = font;
            for (int i = 1; i <= griglia.getNumRighe(); i++)
            {
                ElencoTag[0, i].Value = i;
            }
            for (int j = 1; j <= griglia.getNumColonne(); j++)
            {
                ElencoTag.Columns[j].Width = 110;
                ElencoTag[j, 0].Value = alfabeto[j - 1];
            }
        }

        void rfid_StatusUpdateEvent(string id)
        {
            ElencoTag[colonna, riga].Selected = true;

            if (((colonna <= griglia.getNumColonne()) && (riga <= griglia.getNumRighe())) || ((colonna != -1) && (riga != -1)))
            {

                for (int i = 0; i < inseriti.Count; i = i + 3)
                {
                    if (((String)inseriti[i]).Equals(id))
                    {
                        MessageBox.Show("Tag " + id + " già inserito in " + inseriti[i + 1].ToString() + inseriti[i + 2].ToString());
                        return;
                    }
                }

                ElencoTag[colonna, riga].Style.BackColor = Color.Coral;
                ElencoTag[colonna,riga].Value = id;

                inseriti.Add(id);
                inseriti.Add(alfabeto[riga - 1]);
                inseriti.Add(colonna);
                ElencoTag[colonna,riga].Selected = false;
                colonna++;
                if (colonna > griglia.getNumColonne())
                {
                    if (riga >= griglia.getNumRighe())
                    {
                        riga = -1;
                        colonna = -1;
                    }
                    else
                    {
                        riga++;
                        colonna = 1;
                    }
                }
            }
        }

        private void ok_Click(object sender, EventArgs e)
        {

            control.salvaGriglia(griglia,ElencoTag);
            control.goHome(this);
            /*bool esiste = false;
            this.Cursor = Cursors.WaitCursor;
            if (esiste == true)
            {  //controllo non gestito (c'è un abbozzo di controllo, ma è commentato nella loro ultima versione)
                MessageBox.Show("Esiste già una griglia con questo codice");
            }
            else
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.NewLineOnAttributes = true;
                if ((textBox2.Text == null) || (textBox2.Text.CompareTo("") == 0))
                {
                    MessageBox.Show("Non hai inserito il nome del pannello");
                }
                else
                {

                    try
                    {
                        XmlWriter wr = XmlWriter.Create(directory_principale + "Griglia" + textBox2.Text + ".xml", settings);
                        wr.WriteStartDocument();
                        wr.WriteStartElement("GrigliaTaggata");
                        wr.WriteStartElement("NomePannello");
                        /*wr.WriteStartAttribute("ID");
                        wr.WriteString(textBox1.Text);
                        wr.WriteEndAttribute();
                        wr.WriteStartAttribute("TAG_PER_RIGA");
                        wr.WriteString(tag_per_riga.ToString());
                        wr.WriteEndAttribute();
                        wr.WriteStartAttribute("TAG_PER_COLONNA");
                        wr.WriteString(tag_per_colonna.ToString());
                        wr.WriteEndAttribute();*/
                        /*
                        wr.WriteAttributeString("TAG_PER_RIGA", tag_per_riga.ToString());
                        wr.WriteAttributeString("TAG_PER_COLONNA", tag_per_colonna.ToString());
                        wr.WriteString(textBox2.Text);
                        int indice = 0;
                        for (int i = 1; i <= tag_per_colonna; i++)
                        {
                            for (int j = 1; j <= tag_per_riga; j++)
                            {
                                try
                                {
                                    
                                    string colonna = ElencoTag[j, 0].Value.ToString(); //legge il valore A, B, .... della colonna
                                    if (ElencoTag[j, i].Value != null)
                                    {
                                        
                                        wr.WriteStartElement("", colonna + (ElencoTag[0, i].Value.ToString()), "");
                                        wr.WriteStartAttribute("Usato");
                                        wr.WriteString("false");
                                        wr.WriteEndAttribute();
                                        wr.WriteString(ElencoTag[j, i].Value.ToString());
                                        wr.WriteEndElement();
                                    }
                                    else {
                                        wr.WriteElementString(colonna + (ElencoTag[0, i].Value.ToString()), "Nessun Valore");
                                    }
                                    indice++;
                                }
                                catch
                                {
                                    string colonna = ElencoTag[j, 0].Value.ToString();
                                    wr.WriteElementString(colonna + (ElencoTag[0, i].Value.ToString()), "NessunValore");
                                    indice++;
                                }
                            }
                        }
                        wr.WriteEndElement();
                        wr.WriteEndElement();
                        wr.WriteEndDocument();
                        wr.Flush();
                        wr.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Errore nella creazione del file");
                    }
                    try
                    {
                        Authoring.PannelliConfigurazione p = new Authoring.PannelliConfigurazione(textBox2.Text, tag_per_riga.ToString(), tag_per_colonna.ToString());
                        tutti_poster.Add(p);
                        XmlWriterSettings settings2 = new XmlWriterSettings();
                        settings2.Indent = true;
                        settings2.NewLineOnAttributes = true;
                        XmlWriter wr = XmlWriter.Create(directory_principale + "PannelliTaggati" + ".xml");
                        wr.WriteStartDocument();
                        wr.WriteStartElement("GrigliaTaggata");
                        wr.WriteStartElement("Pannelli");
                        foreach (Authoring.PannelliConfigurazione p1 in tutti_poster)
                        {
                            wr.WriteStartElement("NomePannello");
                            wr.WriteAttributeString("ID", p1.GetId());
                            wr.WriteAttributeString("TAG_PER_RIGA", p1.GetTagRiga());
                            wr.WriteAttributeString("TAG_PER_COLONNA", p1.GetTagColonna());
                            wr.WriteString(p1.GetNome());
                            //wr.WriteStartElement("Configurazione", textBox1.Text);
                            for (int i = 0; i < p.GetConffigurazioniCount(); i++)
                            {
                                wr.WriteStartElement("Configurazione");
                                wr.WriteString(p1.GetConfigurazione(i));
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
                    catch
                    {

                    }
                    MessageBox.Show("Nuovo Pannello Salvato");
                    //if (benvenuto != null)
                    //{
                   //     benvenuto.Visible = true;
                   // }
                   // else if (amministrazione != null)
                   // {
                   //     amministrazione.Visible = true;
                   // }
                    writeConfig();
                    this.Cursor = Cursors.Default;
                    this.Close();
                }
            }
            this.Cursor = Cursors.Default;*/
        }

        

        private void ElencoTag_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int i, j;
            for (i = 1; i <= griglia.getNumRighe(); i++) // se c'è qualche cella che risulta autoselezionata, la deseleziono
            {
                for (j = 1; j <= griglia.getNumColonne(); j++)
                {
                    if (ElencoTag[i, j].Style.BackColor == Color.Coral &&  String.IsNullOrEmpty(ElencoTag[i, j].Value.ToString()) == true)
                        ElencoTag[i, j].Style.BackColor = Color.BlanchedAlmond;
                }
            }
            if ((ElencoTag[e.ColumnIndex, e.RowIndex] != null) && (ElencoTag[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex != 0) && (e.RowIndex != 0))
            {
                ElencoTag[e.ColumnIndex, e.RowIndex].Value = null;
                ElencoTag[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.BlanchedAlmond;
                ElencoTag[e.ColumnIndex, e.RowIndex].Selected = true;
                riga = e.RowIndex;
                colonna = e.ColumnIndex;
            }
            else
            {
                if ((e.ColumnIndex != 0) && (e.RowIndex != 0))
                {
                    ElencoTag[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Yellow;
                    ElencoTag[e.ColumnIndex, e.RowIndex].Selected = true;
                    riga = e.RowIndex;
                    colonna = e.ColumnIndex;
                }
            }
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    this.Cursor = Cursors.WaitCursor;
        //    if (benvenuto != null)
        //  {
        //        benvenuto.Visible = true;
        //    }
        //    else if (amministrazione != null)
         //   {
        //        amministrazione.Visible = true;
        //    }
        //    this.Cursor = Cursors.Default;
        //    this.Close();
        //}

        
        /*private void writeConfig()
        {
            this.Cursor = Cursors.WaitCursor;
            
            DateTime baseTime = new DateTime(2000, 1, 1, 0, 0, 0);
            DateTime nowInUTC = DateTime.UtcNow;
            string nome_conf = "conf"+(nowInUTC - baseTime).Ticks / 10000;

            string nome_pannello = textBox2.Text;
            
            


            if(true) {
                ((Authoring.PannelliConfigurazione)tutti_poster[tutti_poster.Count - 1]).InserisciConfigurazione(nome_conf);
                int i = 1;
                int j = 1;
               // try
                {
                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Indent = true;
                    settings.NewLineOnAttributes = true;
                    
                    
                    

                    XmlWriter wr = XmlWriter.Create(directory_principale + "Griglia" + nome_pannello + id_pannello + nome_conf + ".xml", settings);
                    wr.WriteStartDocument();
                    wr.WriteStartElement("GrigliaTaggata");
                    wr.WriteStartElement("NomePannello");
                    wr.WriteStartAttribute("ID");
                    wr.WriteString(id_pannello);
                    wr.WriteEndAttribute();
                    wr.WriteString(nome_pannello);
                    wr.WriteStartElement("Configurazione", nome_conf);
                    int indice = 0;
                    bool trovato = false;
                    for (i = 1; i <= tag_per_colonna; i++) {
                        for (j = 1; j <= tag_per_riga; j++) {
                                if (ElencoTag[j, i].Value != null && String.IsNullOrEmpty(ElencoTag[j, i].Value.ToString()) == false)
                                { 
                                    for (int k = 0; k < inseriti.Count; k = k + 3) //una riga per volta
                                    {
                                        
                                        if ((inseriti[k + 1].ToString()).CompareTo(alfabeto[j - 1].ToString()) == 0 && (int)inseriti[k + 2] == i)
                                        {
                                                wr.WriteStartElement("", inseriti[k + 1].ToString() + (ElencoTag[0, i].Value.ToString()), "");
                                                wr.WriteStartAttribute("Usato");
                                                wr.WriteString("true");
                                                wr.WriteEndAttribute();
                                                string ins = (String)inseriti[k];
                                                wr.WriteString(ins);
                                                wr.WriteEndElement();
                                                trovato = true;
                                                indice++;
                                        }
                                    } //end for

                                    if (trovato == false) //il valore presente nella cella non è stato trovato nell'array
                                    {
                                        wr.WriteStartElement("", alfabeto[j - 1].ToString() + (ElencoTag[0, i].Value.ToString()), "");
                                        wr.WriteStartAttribute("Usato");
                                        wr.WriteString("false");
                                        wr.WriteEndAttribute();
                                        wr.WriteString("Non Usato");
                                        wr.WriteEndElement();
                                        indice++;
                                    }

                                    trovato = false; //risetto trovato a falso
                                }
                                else //nella cella della griglia non è presente nessun valore!
                                {
                                    wr.WriteStartElement("", alfabeto[j - 1].ToString() + (ElencoTag[0, i].Value.ToString()), "");
                                    wr.WriteStartAttribute("Usato");
                                    wr.WriteString("false");
                                    wr.WriteEndAttribute();
                                    wr.WriteString("Non Usato");
                                    wr.WriteEndElement();
                                    indice++;
                                }
                            }
                    }

                    wr.WriteEndElement();
                    wr.WriteEndElement();
                    wr.WriteEndElement();
                    wr.WriteEndDocument();
                    wr.Flush();
                    wr.Close();
             }
                {
                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Indent = true;
                    settings.NewLineOnAttributes = true;
                    XmlWriter wr = XmlWriter.Create(directory_principale + "PannelliTaggati" + ".xml");
                    wr.WriteStartDocument();
                    wr.WriteStartElement("GrigliaTaggata");
                    wr.WriteStartElement("Pannelli");
                    foreach (Authoring.PannelliConfigurazione p in tutti_poster)
                    {
                        wr.WriteStartElement("NomePannello");
                        wr.WriteAttributeString("ID", p.GetId());
                        wr.WriteAttributeString("TAG_PER_RIGA", p.GetTagRiga());
                        wr.WriteAttributeString("TAG_PER_COLONNA", p.GetTagColonna());
                        wr.WriteString(p.GetNome());
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
                this.Cursor = Cursors.Default;
                MessageBox.Show("Configurazione Salvata");
              //  if (benvenuto != null)
              //  {
             //       benvenuto.Visible = true;
             //   }
             //   else if (amministrazione != null) {
            //        amministrazione.Visible = true;
             //   }
           //     this.Close();
            }

            this.Cursor = Cursors.Default;
        }*/

        private void annulla_Click(object sender, EventArgs e)
        {
            control.goBack(this);
        }
    }
}
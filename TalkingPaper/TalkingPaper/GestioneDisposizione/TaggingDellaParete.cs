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

namespace TalkingPaper.GestioneDisposizione
{
    public partial class TaggingDellaParete : Form
    {
        private int tag_per_riga;
        private int tag_per_colonna;
        private Reader.IReader reader;
        private int rfid_num;
        private string oldId = "0"; // serve per capire se il tag è quello del precedente o no
        private NHibernateManager nh_mng;
        private int riga_scritta = 1;
        private int colonna_scritta = 1;
        private int riga = 1;
        private int colonna = 1;
        private ArrayList inseriti = new ArrayList();
        private ArrayList pannelli = new ArrayList();
        private ArrayList tutti_poster = new ArrayList();
        private string selezionato = "No";
        private int riga_sel = -1;
        private int colonna_sel = -1;
        private QuestionEliminaTag el;
        private string directory_principale;
        private bool selected1 = false;
        private bool selected2 = false;
        private BenvenutoGestioneDisposizione benvenuto;
        private FormAmministrazione amministrazione;

        private char[] alfabeto ={ 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'Z' };

        public TaggingDellaParete(BenvenutoGestioneDisposizione benvenuto, FormAmministrazione amministrazione, string directory_principale, int tag_per_riga, int tag_per_colonna)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 98, true);
            this.directory_principale = directory_principale;
            this.benvenuto = benvenuto;
            this.amministrazione = amministrazione;
            this.tag_per_colonna = tag_per_colonna;
            this.tag_per_riga = tag_per_riga;
            button1.Cursor = Cursors.Hand;
            button2.Cursor = Cursors.Hand;
            nh_mng = new NHibernateManager();
            reader = new Reader.DumbReader();
            rfid_num = reader.connect();
            if (rfid_num <= 0)
            {
                //Qualcosa non ha funzionato, rifare...
                MessageBox.Show("Errore di collegamento con il RFID Reader.\nControllare che sia correttamente collegato al computer\nTerminazione forzata del programma.", "ATTENZIONE",
MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                string error = "Errore in costruttore FormEsecuzione: probabilmente l'RFID reader non è correttamente collegato al computer";
                
            }
            else
            {
                Console.WriteLine("SONO in costruttore di FormEsecuzione, tutto ok");
                //this.richTextBox1.Text += "\nInizializzazione Form: OK ";
            }
            InizializzaDataGrid();
            CaricaPosterConfigurazioni();
            this.Show();
            timer1.Interval = 1000;
            timer1.Start();

        }

        private void CaricaPosterConfigurazioni()
        {
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
                            iscritto.MoveToNextAttribute();
                            string ri = (String)iscritto.GetAttribute("TAG_PER_RIGA");
                            iscritto.MoveToNextAttribute();
                            string co = (String)iscritto.GetAttribute("TAG_PER_COLONNA");
                            string ins = (string)iscritto.ReadString();
                            PannelliConfigurazione p = new PannelliConfigurazione(id, ins, ri, co);
                            tutti_poster.Add(p);
                            i++;

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
            textBox1.Click += new EventHandler(textBox1_Click);
            //textBox2.Click += new EventHandler(textBox_Click);
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

        void timer1_Tick(object sender, EventArgs e)
        {
            reader.readerStatusUpdate += rfid_StatusUpdateEvent;
            //rfid_cfg.StatusUpdateEvent += new RFIDlibrary.RFIDConfigurator.StatusUpdateDelegate(rfid_StatusUpdateEvent);
            //int tag_letto = rfid_cfg.letturaID(rfid_num);
        }

        void rfid_StatusUpdateEvent(string id)
        {

            if (oldId.Equals(id) == true)
            {
                //non fare niente
                Console.WriteLine("Id già letto, non eseguo alcuna operazione");
                //this.richTextBox1.Text += "\nTag già letto: non eseguo alcuna operazione";

            }
            else if (oldId.Equals(id) == false)
            {
                bool presente1 = false;
                if (selezionato.CompareTo("Ok") == 0)
                {
                    ElencoTag[colonna_sel, riga_sel].Selected = true;
                }
                else
                {
                    try
                    {
                        ElencoTag[colonna, riga].Selected = true;
                    }
                    catch
                    {
                    }
                }
                try
                {
                    if (textBox1.Text.CompareTo(id) == 0)
                    {
                        presente1 = true;
                    }
                }
                catch
                {
                    presente1 = false;
                }
                if (presente1 == false)
                {
                    for (int i = 0; i < inseriti.Count; i = i + 3)
                    {
                        if (((String)inseriti[i]).CompareTo(id) == 0)
                        {
                            MessageBox.Show("Tag " + id + " già inserito in " + inseriti[i + 1].ToString() + inseriti[i + 2].ToString());
                            presente1 = true;
                        }
                    }
                }
                if (presente1 == false)
                {
                    if (selected1 == true)
                    {
                        textBox1.Text = id;
                        selected1 = false;
                    }
                }
                if ((colonna <= tag_per_riga) && (riga <= tag_per_colonna))
                {
                    bool presente = false;
                    oldId = id;
                    try
                    {
                        if (textBox1.Text.CompareTo(id) == 0)
                        {
                            presente = true;
                        }
                    }
                    catch
                    {
                        presente = false;
                    }
                    if (presente == false)
                    {
                        for (int i = 0; i < inseriti.Count; i = i + 3)
                        {
                            if (((String)inseriti[i]).CompareTo(id) == 0)
                            {
                                MessageBox.Show("Tag " + id + " già inserito in " + inseriti[i + 1].ToString() + inseriti[i + 2].ToString());
                                presente = true;
                            }
                        }
                    }
                    if (presente == false)
                    {
                        if (selected1 == true)
                        {
                            textBox1.Text = id;
                            selected1 = false;
                        }
                        else
                        {
                            if ((riga_sel != -1) && (colonna_sel != -1))
                            {
                                ElencoTag[colonna_sel, riga_sel].Style.BackColor = Color.Coral;
                                ElencoTag[colonna_sel, riga_sel].Value = id;
                                inseriti.Add(id);
                                inseriti.Add(alfabeto[colonna_sel - 1]);
                                inseriti.Add(riga_sel);
                                ElencoTag[colonna_sel, riga_sel].Selected = false;
                                riga_sel = -1;
                                colonna_sel = -1;
                                if ((colonna == 1) && (riga == 1))
                                {
                                    colonna++;
                                }
                                //selezionato = "No";
                            }
                            else
                            {
                                ElencoTag[colonna, riga].Style.BackColor = Color.Coral;
                                ElencoTag[colonna, riga].Value = id;
                                //ElencoTag[colonna, riga].Style.BackColor = Color.Coral;
                                inseriti.Add(id);
                                inseriti.Add(alfabeto[colonna - 1]);
                                inseriti.Add(riga);
                                ElencoTag[colonna, riga].Selected = false;
                                colonna++;
                            }
                            //colonna++;
                            
                            //if (colonna > tag_per_colonna)
                            if (colonna > tag_per_colonna)
                            {
                                riga++;
                                colonna = 1;
                            }
                            if (riga > tag_per_riga)
                            {
                                riga_sel = -1;
                                colonna_sel = -1;
                            }
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool esiste = false;
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
                if ((textBox1.Text == null) || (textBox1.Text.CompareTo("") == 0))
                {
                    MessageBox.Show("Non hai inserito l'identificativo del pannello");
                    
                }
                else if ((textBox2.Text == null) || (textBox2.Text.CompareTo("") == 0))
                {
                    MessageBox.Show("Non hai inserito il nome del pannello");
                }
                else
                {

                    try
                    {
                        XmlWriter wr = XmlWriter.Create(directory_principale + "Griglia" + textBox2.Text + textBox1.Text + ".xml", settings);
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
                        wr.WriteAttributeString("ID", textBox1.Text);
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
                        PannelliConfigurazione p = new PannelliConfigurazione(textBox1.Text, textBox2.Text, tag_per_riga.ToString(), tag_per_colonna.ToString());
                        tutti_poster.Add(p);
                        XmlWriterSettings settings2 = new XmlWriterSettings();
                        settings2.Indent = true;
                        settings2.NewLineOnAttributes = true;
                        XmlWriter wr = XmlWriter.Create(directory_principale + "PannelliTaggati" + ".xml");
                        wr.WriteStartDocument();
                        wr.WriteStartElement("GrigliaTaggata");
                        wr.WriteStartElement("Pannelli");
                        foreach (PannelliConfigurazione p1 in tutti_poster)
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
                    if (benvenuto != null)
                    {
                        benvenuto.Visible = true;
                    }
                    else if (amministrazione != null)
                    {
                        amministrazione.Visible = true;
                    }
                    writeConfig();
                    this.Cursor = Cursors.Default;
                    this.Close();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
            selected1 = true;
            textBox1.BackColor = Color.Yellow;

            //deseleziono la datagrid
            int i, j;
            for (i = 1; i <= tag_per_colonna; i++) 
                for (j = 1; j <= tag_per_riga; j++)
                {
                    ElencoTag[j, i].Selected = false;
                    /*if (ElencoTag[j, i].Value!=null && String.IsNullOrEmpty(ElencoTag[j, i].Value.ToString()) == true)
                        ElencoTag[j, i].Style.BackColor = Color.BlanchedAlmond;
                    else
                    {
                        if (ElencoTag[j, i].Value != null && String.IsNullOrEmpty(ElencoTag[j, i].Value.ToString()) != true)
                            ElencoTag[j, i].Style.BackColor = Color.Coral;
                    }*/
                }

        }

        private void ElencoTag_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*if ((ElencoTag[e.ColumnIndex, e.RowIndex] != null) && (ElencoTag[e.ColumnIndex, e.RowIndex].Value != null)) {
                QuestionEliminaTag el = new QuestionEliminaTag(this, ElencoTag, e.ColumnIndex, e.RowIndex,inseriti);
            }*/
        }

        private void ElencoTag_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.BackColor = Color.Gainsboro;
            int i, j;
            for (i = 1; i <= tag_per_colonna; i++) // se c'è qualche cella che risulta autoselezionata, la deseleziono
            {
                for (j = 1; j <= tag_per_riga; j++)
                {
                    if (ElencoTag[j, i].Style.BackColor == Color.Coral &&  String.IsNullOrEmpty(ElencoTag[j, i].Value.ToString()) == true)
                        ElencoTag[j, i].Style.BackColor = Color.BlanchedAlmond;
                }
            }
            if ((ElencoTag[e.ColumnIndex, e.RowIndex] != null) && (ElencoTag[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex != 0) && (e.RowIndex != 0))
            {
                ElencoTag[e.ColumnIndex, e.RowIndex].Value = null;
                ElencoTag[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.BlanchedAlmond;
                ElencoTag[e.ColumnIndex, e.RowIndex].Selected = true;
                riga_sel = e.RowIndex;
                colonna_sel = e.ColumnIndex;
            }
            else
            {
                if ((e.ColumnIndex != 0) && (e.RowIndex != 0))
                {
                    ElencoTag[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Yellow;
                    ElencoTag[e.ColumnIndex, e.RowIndex].Selected = true;
                    riga_sel = e.RowIndex;
                    colonna_sel = e.ColumnIndex;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void Indietro_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Close();
            this.Cursor = Cursors.Default;
            //componenti.Visible = true;
        }

        private void writeConfig()
        {
            this.Cursor = Cursors.WaitCursor;
            
            DateTime baseTime = new DateTime(2000, 1, 1, 0, 0, 0);
            DateTime nowInUTC = DateTime.UtcNow;
            string nome_conf = "conf"+(nowInUTC - baseTime).Ticks / 10000;

            string nome_pannello = textBox2.Text;
            string id_pannello = textBox1.Text;
            


            if(true) {
                ((PannelliConfigurazione)tutti_poster[tutti_poster.Count - 1]).InserisciConfigurazione(nome_conf);
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
                    foreach (PannelliConfigurazione p in tutti_poster)
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
    }
}
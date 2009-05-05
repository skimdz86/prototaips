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
    public partial class ListaGriglieForm : FormSchema
    {
        private int tag_per_riga;
        private int tag_per_colonna;
        private ArrayList tutti_poster = new ArrayList();
        private ArrayList poster_authoring = new ArrayList();
        private string directory_principale;
        private int id_mostra;
        private int id_poster;
        private string nome_poster;
        //private BenvenutoAuthoring partenza;
        private Authoring.ModificaCartelloneForm scelta_poster;
        private int indice_combo;
        private string nome_combo;
        string id_pannello = "";
        string nome_pannello="";
        string configurazione = "";
        string provenienza;
        private int tot_elementi = 0;
        //private Authoring.BenvenutoGestioneDisposizione benvenuto_ges;
        private Authoring.ElementoGriglia[,] matrice;
        private char[] alfabeto ={ 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'Z' };
        //private NHibernateManager nh_manager;
        private int selected = 0;// di default sceglie la prima
        private ArrayList configList = new ArrayList();
        private ArrayList configList2 = new ArrayList();

        public ListaGriglieForm()
        {
            InitializeComponent();
            //RidimensionaForm n = new RidimensionaForm(this, 90, true);
            
            label3.Visible = false;
            annulla.Cursor = Cursors.Hand;
            CaricaPosterConfigurazioni();
            CaricaComboBox();
            LeggiPosterCreati();
            ok.Enabled = false;
            ok.Cursor = Cursors.Default;
            //CreaMatrice();

        }


        private void LeggiPosterCreati(){
            try
            {
                XmlTextReader iscritto = new XmlTextReader(directory_principale + "PosterAuthoring" + ".xml");
                //bool fine = false;
                while ((iscritto.Read()))
                {
                    if (iscritto.NodeType == XmlNodeType.Element)
                    {
                        if (iscritto.LocalName.Equals("IDposter"))
                        {
                            //string id = (String)iscritto.GetAttribute("ID");
                            string ins = (string)iscritto.ReadString();
                            //string id = (String)iscritto.GetAttribute("ID");
                            poster_authoring.Add(ins);
                            //pannelli.Add(id);
                        } 
                        if (iscritto.LocalName.Equals("IDpannello"))
                        {
                            //string id = (String)iscritto.GetAttribute("ID");
                            string ins = (string)iscritto.ReadString();
                            //string id = (String)iscritto.GetAttribute("ID");
                            poster_authoring.Add(ins);
                            //pannelli.Add(id);
                        }
                        if (iscritto.LocalName.Equals("NomePannello"))
                        {
                            //string id = (String)iscritto.GetAttribute("ID");
                            string ins = (string)iscritto.ReadString();
                            //string id = (String)iscritto.GetAttribute("ID");
                            poster_authoring.Add(ins);
                            //pannelli.Add(id);
                        }
                        if (iscritto.LocalName.Equals("Configurazione"))
                        {
                            //string id = (String)iscritto.GetAttribute("ID");
                            string ins = (string)iscritto.ReadString();
                            //string id = (String)iscritto.GetAttribute("ID");
                            poster_authoring.Add(ins);
                            //pannelli.Add(id);
                        }
                    }
                }
                iscritto.Close();
            }
            catch
            {

            }
        }

        private void LeggiRigaColonna(string nome_pa,string id_pa)
        {
            try
            {
                string nome_file = directory_principale + "Griglia" + nome_pa + id_pa + ".xml";
                XmlTextReader iscritto = new XmlTextReader(nome_file);
                bool fine = false;
                //int i = 1;
                //int j = 1;
                while ((iscritto.Read()) && (fine == false))
                {
                    if (iscritto.NodeType == XmlNodeType.Element)
                    {
                        if (iscritto.LocalName.Equals("NomePannello"))
                        {
                            string righe = iscritto.GetAttribute("TAG_PER_RIGA");
                            string colonne = iscritto.GetAttribute("TAG_PER_COLONNA"); ;
                            tag_per_riga = Int32.Parse(righe);
                            tag_per_colonna = Int32.Parse(colonne);
                            matrice = new Authoring.ElementoGriglia[tag_per_colonna + 1,tag_per_riga + 1];
                            fine = true;

                        }
                    }
                }
                //esiste = true;
            }
            catch
            {
                //esiste = false;
            }

        }

        private void CreaFilePosterCreati() {
            try
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.NewLineOnAttributes = true;
                XmlWriter wr = XmlWriter.Create(directory_principale + "PosterAuthoring" + ".xml", settings);
                wr.WriteStartDocument();
                wr.WriteStartElement("PosterCreatiConAuthoring");
                wr.WriteStartElement("IDposter");
                //wr.WriteStartAttribute("ID");
                //wr.WriteString(id_pannello);
                //wr.WriteEndAttribute();
                wr.WriteString(id_poster.ToString());
                wr.WriteStartElement("IDpannello");
                wr.WriteString(id_pannello);
                wr.WriteEndElement();
                wr.WriteStartElement("NomePannello");
                wr.WriteString(nome_pannello);
                wr.WriteEndElement();
                wr.WriteStartElement("Configurazione");
                wr.WriteString(configurazione);
                wr.WriteEndElement();
                wr.WriteEndElement();
                
                
                try
                {
                    for (int i = 0; i < poster_authoring.Count; i=i+4)
                    {
                        wr.WriteStartElement("IDposter");
                        wr.WriteString(((string)poster_authoring[i]));
                        wr.WriteStartElement("IDpannello");
                        wr.WriteString((string)poster_authoring[i+1]);
                        wr.WriteEndElement();
                        wr.WriteStartElement("NomePannello");
                        wr.WriteString((string)poster_authoring[i+2]);
                        wr.WriteEndElement();
                        wr.WriteStartElement("Configurazione");
                        wr.WriteString((string)poster_authoring[i+3]);
                        wr.WriteEndElement();
                        wr.WriteEndElement();
                    }
                    wr.WriteEndElement();
                    wr.WriteEndDocument();
                    wr.Flush();
                    wr.Close();
                }
                catch
                {

                }
            }
            catch { 
            
            }
        }
        
        private void CreaMatrice() { 
     //       try{
            {
                string nome_file = directory_principale + "Griglia" + nome_pannello + id_pannello + configurazione + ".xml";
                XmlTextReader iscritto = new XmlTextReader(nome_file);
                bool fine = false;
                int i = 1;
                int j = 1;
                while ((iscritto.Read()) && (fine == false))
                {
                    if (iscritto.NodeType == XmlNodeType.Element)
                    {
                        if (iscritto.LocalName.Equals(alfabeto[j - 1].ToString() + i.ToString()))
                            {
                                string ins = (String)iscritto.ReadString();
                                    if (ins.CompareTo("Non Usato") != 0)
                                    {
                                        Authoring.ElementoGriglia n = new Authoring.ElementoGriglia(id_pannello, nome_pannello, configurazione, nome_poster, id_poster, -1, null, alfabeto[j-1].ToString(), i, ins,false);
                                        matrice[i, j] = n;
                                    }
                                    else {
                                        Authoring.ElementoGriglia n = new Authoring.ElementoGriglia(id_pannello, nome_pannello, configurazione, nome_poster, id_poster, -1, null, alfabeto[j - 1].ToString(), i, ins,false);
                                        matrice[i, j] = n;;
                                    }
                                    j++;
                                }
                            }
                           
                            if (j > tag_per_riga)
                            {

                                i++;
                                j = 1;
                                
                            }
                            if (i > tag_per_colonna)
                            {
                                fine = true;
                            }
                        }
                        iscritto.Close();
                    }
                    //esiste = true;
              //  catch
              //  {
                    //esiste = false;
              //  }        
        }
        
        private void ScriviFileXml() {
            try
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.NewLineOnAttributes = true;
                XmlWriter wr = XmlWriter.Create(directory_principale + "Griglia" + nome_pannello + id_pannello + configurazione + id_poster.ToString() + ".xml");
                wr.WriteStartDocument();
                wr.WriteStartElement("GrigliaTaggata");
                wr.WriteStartElement("NomePannello");
                wr.WriteStartAttribute("ID");
                wr.WriteString(id_pannello);
                wr.WriteEndAttribute();
                wr.WriteString(nome_pannello);
                wr.WriteStartElement("Configurazione");
                wr.WriteString(configurazione);
                wr.WriteStartElement("Poster");
                wr.WriteString(id_poster.ToString());
                foreach (Authoring.ElementoGriglia el in matrice)
                {
                    if (el != null)
                    {
                        wr.WriteStartElement(el.getColonna() + el.GetRiga().ToString());
                        wr.WriteStartAttribute("ID");
                        wr.WriteString(el.GetTagContenuto());
                        wr.WriteEndAttribute();
                        if (el.GetUtilizzato() == true)
                        {
                            wr.WriteStartElement("IDcontenuto");
                            wr.WriteString(el.GetIdContenuto().ToString());
                            wr.WriteEndElement();
                            wr.WriteStartElement("NomeContenuto");
                            wr.WriteString(el.GetNomeContenuto());
                            wr.WriteEndElement();
                            wr.WriteStartElement("Utilizzato");
                            wr.WriteString(el.GetUtilizzato().ToString());
                            wr.WriteEndElement();
                        }
                        else
                        {
                            wr.WriteStartElement("Utilizzato");
                            wr.WriteString(el.GetUtilizzato().ToString());
                            wr.WriteEndElement();
                        }
                        wr.WriteEndElement();
                    }
                }
                wr.WriteEndElement();
                wr.WriteEndElement();
                wr.WriteEndElement();
                wr.WriteEndElement();
                wr.WriteEndDocument();
                wr.Flush();
                wr.Close();
            }
            catch
            {

            }
        }

        private void CaricaComboBox() {
            int i = 0;
            foreach (Authoring.PannelliConfigurazione p in tutti_poster) {
                Label lab = new Label();
                Label lab2 = new Label();
                lab.Text = (String)p.GetNome();
                lab2.Text = " (" + p.GetTagColonna() + "x" + p.GetTagRiga() + ")";
                lab.Visible = true;
                lab2.Visible = true;
                lab.BackColor = Color.Orange;
                lab2.BackColor = Color.Orange;
                lab.ForeColor = Color.White;
                lab2.ForeColor = Color.White;
                lab.Size = new System.Drawing.Size(175, 25);
                lab.AutoSize = false;
                lab2.AutoSize = true;
                lab.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lab2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lab.Click += new System.EventHandler(Label_Click);
                lab2.Click += new System.EventHandler(Label2_Click);
                
                lab.Location = new System.Drawing.Point(25, 5 + i * 35);
                lab2.Location = new System.Drawing.Point(200, 5 + i * 35);
                
                //lab.Location = new System.Drawing.Point(25, 165 + i * 35);
                //lab2.Location = new System.Drawing.Point(200, 165 + i * 35);

                i++;
                //comboBox1.Items.Add((String)p.GetNome());
                configList.Add(lab);
                configList2.Add(lab2);
                this.pannello.Controls.Add(lab);
                this.pannello.Controls.Add(lab2);
                //this.Controls.Add(lab);
                //this.Controls.Add(lab2);
                
            }

        }

        private void CaricaPosterConfigurazioni()
        {
            try
            {
                string nome_file = directory_principale + "PannelliTaggati" + ".xml";
                XmlTextReader iscritto = new XmlTextReader(nome_file);
                
                int i = -1;
                
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
                            Authoring.PannelliConfigurazione p = new Authoring.PannelliConfigurazione(id, ins,ri,co);
                            tutti_poster.Add(p);
                            i++;
                            /*if ((nome_pannello.CompareTo(ins) == 0) && (id_pannello.CompareTo(id) == 0))
                            {
                                posizione = i;
                            }*/
                            //string id = (String)iscritto.GetAttribute("ID");

                            //pannelli.Add(id);
                        }
                        if (iscritto.LocalName.Equals("Configurazione"))
                        {
                            string conf = (String)iscritto.ReadString();
                            ((Authoring.PannelliConfigurazione)tutti_poster[i]).InserisciConfigurazione(conf);
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
 
        private void InizializzaDataGrid2(string f)
        {
            //int valore = 0;
            Font font = new Font("Arial", 16);
            ElencoTag2.Rows.Clear();
            tot_elementi = 0;
            //textBox1.Click += new EventHandler(textBox1_Click);
            ElencoTag2.CellClick += new DataGridViewCellEventHandler(ElencoTag_CellContentClick);
            ElencoTag2.CellMouseEnter += new DataGridViewCellEventHandler(ElencoTag_CellMouseEnter);
            ElencoTag2.ColumnCount = tag_per_riga + 1;
            ElencoTag2.Rows.Add(tag_per_colonna + 1);
            ElencoTag2.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
            ElencoTag2.Columns[0].DefaultCellStyle.ForeColor = Color.Red;
            ElencoTag2.Rows[0].DefaultCellStyle.Font = font;
            ElencoTag2.Columns[0].DefaultCellStyle.Font = font;
            for (int i = 1; i <= tag_per_colonna; i++)
            {
                ElencoTag2[0, i].Value = i;
            }
            for (int j = 1; j <= tag_per_riga; j++)
            {
                ElencoTag2.Columns[j].Width = 90;
                ElencoTag2[j, 0].Value = alfabeto[j - 1];
            }
            RiempiDataGrid2(f);
        }

        private void RiempiDataGrid2(string file)
        {
            //string nome_file = directory_principale + "Griglia" + nome_pannello + id_pannello + configurazione + ".xml";
            XmlTextReader iscritto = new XmlTextReader(file);
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
                        if (ins.CompareTo("Non Usato") != 0)
                        {
                            ElencoTag2[i, j].Style.BackColor = Color.Coral;  //ElencoTag2[colonna, riga]
                            tot_elementi++;
                        }
                        i++; //quando trova un elemento valido (A1, B1, ..., A2,B2, ... ) incrementa il numero della riga
                    }
                } //end if
                //completamento per riga

                if (i > tag_per_riga) //quando finisce la scansione della prima colonna passa alla successiva
                {
                    j++;
                    i = 1;
                }
                if (j > tag_per_colonna)  //ha finito il numero delle righe
                {
                    fine = true;
                }
            }

            iscritto.Close();
        }

   /*     private void InizializzaDataGrid3(string f)
        {
            //int valore = 0;
            Font font = new Font("Arial", 16);
            ElencoTag3.Rows.Clear();
            tot_elementi = 0;
            //textBox1.Click += new EventHandler(textBox1_Click);
            ElencoTag3.CellClick += new DataGridViewCellEventHandler(ElencoTag_CellContentClick);
            ElencoTag3.CellMouseEnter += new DataGridViewCellEventHandler(ElencoTag_CellMouseEnter);
            ElencoTag3.ColumnCount = tag_per_riga + 1;
            ElencoTag3.Rows.Add(tag_per_colonna + 1);
            ElencoTag3.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
            ElencoTag3.Columns[0].DefaultCellStyle.ForeColor = Color.Red;
            ElencoTag3.Rows[0].DefaultCellStyle.Font = font;
            ElencoTag3.Columns[0].DefaultCellStyle.Font = font;
            for (int i = 1; i <= tag_per_colonna; i++)
            {
                ElencoTag3[0, i].Value = i;
            }
            for (int j = 1; j <= tag_per_riga; j++)
            {
                ElencoTag3.Columns[j].Width = 90;
                ElencoTag3[j, 0].Value = alfabeto[j - 1];
            }
            RiempiDataGrid3(f);
        }

        private void RiempiDataGrid3(string file)
        {
            //string nome_file = directory_principale + "Griglia" + nome_pannello + id_pannello + configurazione + ".xml";
            XmlTextReader iscritto = new XmlTextReader(file);
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
                        if (ins.CompareTo("Non Usato") != 0)
                        {
                            //string ins = (String)iscritto.ReadString();
                            //inseriti.Add(ins);
                            //inseriti.Add((String)alfabeto[i - 1].ToString());
                            //inseriti.Add((int)j);
                            //ElementoGriglia n = new ElementoGriglia(id_pannello, nome_pannello, configurazione, nome_poster, id_poster, -1, null, alfabeto[i - 1].ToString(), j, ins, false);
                            //matrice[i, j] = n;
                            ElencoTag3[i, j].Style.BackColor = Color.Coral;
                            tot_elementi++;
                        }
                        else
                        {
                            //ElementoGriglia n = new ElementoGriglia(id_pannello, nome_pannello, configurazione, nome_poster, id_poster, -1, null, alfabeto[i - 1].ToString(), j, ins, false);
                            //matrice[i, j] = n;
                            //ElencoTag[i, j].Style.BackColor = Color.Coral;
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
            iscritto.Close();
        }

        private void InizializzaDataGrid4(string f)
        {
            //int valore = 0;
            Font font = new Font("Arial", 16);
            ElencoTag4.Rows.Clear();
            tot_elementi = 0;
            //textBox1.Click += new EventHandler(textBox1_Click);
            ElencoTag4.CellClick += new DataGridViewCellEventHandler(ElencoTag_CellContentClick);
            ElencoTag4.CellMouseEnter += new DataGridViewCellEventHandler(ElencoTag_CellMouseEnter);
            ElencoTag4.ColumnCount = tag_per_riga + 1;
            ElencoTag4.Rows.Add(tag_per_colonna + 1);
            ElencoTag4.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
            ElencoTag4.Columns[0].DefaultCellStyle.ForeColor = Color.Red;
            ElencoTag4.Rows[0].DefaultCellStyle.Font = font;
            ElencoTag4.Columns[0].DefaultCellStyle.Font = font;
            for (int i = 1; i <= tag_per_colonna; i++)
            {
                ElencoTag4[0, i].Value = i;
            }
            for (int j = 1; j <= tag_per_riga; j++)
            {
                ElencoTag4.Columns[j].Width = 90;
                ElencoTag4[j, 0].Value = alfabeto[j - 1];
            }
            RiempiDataGrid4(f);
        }

        private void RiempiDataGrid4(string file)
        {
            //string nome_file = directory_principale + "Griglia" + nome_pannello + id_pannello + configurazione + ".xml";
            XmlTextReader iscritto = new XmlTextReader(file);
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
                        if (ins.CompareTo("Non Usato") != 0)
                        {
                            //string ins = (String)iscritto.ReadString();
                            //inseriti.Add(ins);
                            //inseriti.Add((String)alfabeto[i - 1].ToString());
                            //inseriti.Add((int)j);
                            //ElementoGriglia n = new ElementoGriglia(id_pannello, nome_pannello, configurazione, nome_poster, id_poster, -1, null, alfabeto[i - 1].ToString(), j, ins, false);
                            //matrice[i, j] = n;
                            ElencoTag4[i, j].Style.BackColor = Color.Coral;
                            tot_elementi++;
                        }
                        else
                        {
                            //ElementoGriglia n = new ElementoGriglia(id_pannello, nome_pannello, configurazione, nome_poster, id_poster, -1, null, alfabeto[i - 1].ToString(), j, ins, false);
                            //matrice[i, j] = n;
                            //ElencoTag[i, j].Style.BackColor = Color.Coral;
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
            iscritto.Close();
        }

*/       
        private void ElencoTag_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*if ((e.ColumnIndex == 3) && (ElencoTag[e.ColumnIndex, e.RowIndex].Value != null) && (ElencoTag[e.ColumnIndex, e.RowIndex] != null)) {
                if ((bool)ElencoTag[e.ColumnIndex, e.RowIndex].Value == false) {
                    ElencoTag[e.ColumnIndex, e.RowIndex].Value = true;
                    string nome_pannello2 = ((GestioneDisposizione.PannelliConfigurazione)tutti_poster[indice_combo]).GetNome();
                    string id_pannello2 = ((GestioneDisposizione.PannelliConfigurazione)tutti_poster[indice_combo]).GetId();
                    string con = (string)ElencoTag[1, e.RowIndex].Value;
                    string nome_file = directory_principale + "Griglia" + nome_pannello2 + id_pannello2 + con+ ".xml";
                    //LeggiFilePerPreviewGriglia(nome_file);
                    LeggiRigaColonna(nome_pannello2, id_pannello2);
                    InizializzaDataGrid2(nome_file);
                    label4.Text = "Totale Componenti = " + tot_elementi.ToString();
                    label4.Visible = true;
                }
                else if ((bool)ElencoTag[e.ColumnIndex, e.RowIndex].Value == true) {
                    ElencoTag[e.ColumnIndex, e.RowIndex].Value = false;
                }
                for (int i = 2; i < ElencoTag.Rows.Count; i++) {
                    if ((ElencoTag[3, i].Value != null) && (ElencoTag[3, i] != null)&&(i!=e.RowIndex)) {
                        ElencoTag[3, i].Value = false;
                    }
                }
            }*/
        }

        private void ElencoTag_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            /*if ((e.ColumnIndex == 3)&&(e.RowIndex!=0))
            {
                if (ElencoTag[e.ColumnIndex, e.RowIndex].Value != null)
                {
                    ElencoTag.Cursor = Cursors.Hand;
                }
                else
                    ElencoTag.Cursor = Cursors.Default;
            }
            else
                ElencoTag.Cursor = Cursors.Default;*/
        }

        private void ok_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            for (int j = 0; j < tutti_poster.Count;j++)
            {
                if ((nome_combo.CompareTo(((Authoring.PannelliConfigurazione)tutti_poster[indice_combo]).GetNome())==0)){
                    nome_pannello=((Authoring.PannelliConfigurazione)tutti_poster[indice_combo]).GetNome();
                    id_pannello = ((Authoring.PannelliConfigurazione)tutti_poster[indice_combo]).GetId();
                    configurazione = ((Authoring.PannelliConfigurazione)tutti_poster[indice_combo]).GetConfigurazione(selected);
                }
            }
            CreaMatrice();
            CreaFilePosterCreati();
            ScriviFileXml();
            //PosizionaComponentiForm n = new PosizionaComponentiForm(/*null,*/  id_poster, nome_poster, -1, directory_principale, "talkingpaper2", benvenuto_ges, id_pannello, nome_pannello, configurazione, null, benvenuto_ges, provenienza, id_mostra, scelta_poster);
            //n.Show();
            //GestioneDisposizione.ComponentiDelPoster n = new TalkingPaper.GestioneDisposizione.ComponentiDelPoster(benvenuto_ges, scelta_poster, id_mostra, id_poster, nome_poster, directory_principale, provenienza, null,id_pannello,nome_pannello,configurazione);
            //n.Show();
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void EliminaPoster() {
            /*using (ISession tempS = nh_manager.Session)
            using (ITransaction tempT = tempS.BeginTransaction())
            {
                try
                {
                    IQuery q = tempS.CreateQuery("FROM Poster as pt WHERE pt.IDposter=:Pos");
                    int idd_mostra;
                    Mostra mm = new Mostra();
                    q.SetParameter("Pos", id_poster);
                    Poster3 poster = new Poster3();
                    poster = (Poster3)q.List()[0];
                    try
                    {
                        idd_mostra = poster.Mostra.IDmostra;
                        IQuery q2 = tempS.CreateQuery("FROM Mostra as ms WHERE ms.IDmostra=:Mos");
                        q2.SetParameter("Mos", idd_mostra);
                        mm = (Mostra)q2.List()[0];
                        mm.PosterLista.Remove(poster);
                        tempS.Update(mm);
                        tempS.Flush();
                    }
                    catch { }
                    tempS.Delete(poster);
                    //MessageBox.Show("Poster Eliminato");
                    tempT.Commit();
                }
                catch 
                {
                    tempT.Rollback();
                    Console.WriteLine("Eccezione in Scegli Mostra");
                }
                finally
                {
                    tempS.Close();
                }
            }*/
        
        }

        private void annulla_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            EliminaPoster();
            if (scelta_poster != null)
            {
                scelta_poster.Visible = true;
            }
            //else if (benvenuto_ges != null) {
           //     benvenuto_ges.Visible = true;
            //}
            /*else if (partenza != null) { 
                partenza.Visible=true;
            }*/
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void ElencoTag2_Click(object sender, EventArgs e)
        {

            groupBox2.BackColor = System.Drawing.Color.Red;
           /* groupBox3.BackColor = System.Drawing.Color.DarkOrange;
            groupBox4.BackColor = System.Drawing.Color.DarkOrange;*/
            selected = 0;
        }

    /*    private void ElencoTag3_Click(object sender, EventArgs e)
        {
            groupBox2.BackColor = System.Drawing.Color.DarkOrange;
            groupBox3.BackColor = System.Drawing.Color.Red;
            groupBox4.BackColor = System.Drawing.Color.DarkOrange;
            groupBox5.BackColor = System.Drawing.Color.DarkOrange;
            groupBox6.BackColor = System.Drawing.Color.DarkOrange;
            groupBox7.BackColor = System.Drawing.Color.DarkOrange;
            selected = 1;
        }

        private void ElencoTag4_Click(object sender, EventArgs e)
        {
            groupBox2.BackColor = System.Drawing.Color.DarkOrange;
            groupBox3.BackColor = System.Drawing.Color.DarkOrange;
            groupBox4.BackColor = System.Drawing.Color.Red;
            groupBox5.BackColor = System.Drawing.Color.DarkOrange;
            groupBox6.BackColor = System.Drawing.Color.DarkOrange;
            groupBox7.BackColor = System.Drawing.Color.DarkOrange;
            selected = 2;
        }*/
   
        private void Label_Click(object sender, System.EventArgs e)
        {
            foreach (Label lab in configList)
                lab.BackColor = System.Drawing.Color.Orange;

            foreach (Label lab in configList2)
                lab.BackColor = System.Drawing.Color.Orange;

            ((Label)sender).BackColor = System.Drawing.Color.Red;
            
            bool trovato = false;
            string selezionato = ((Label)sender).Text;

            nome_combo = ((Label)sender).Text;
            indice_combo = configList.IndexOf(sender);
            ((Label)configList2[indice_combo]).BackColor = System.Drawing.Color.Red;
            
            groupBox2.Visible = false;
            //groupBox3.Visible = false;
            //groupBox4.Visible = false;
            label3.Visible = true;
            label4.Visible = false;
            
            foreach (Authoring.PannelliConfigurazione p in tutti_poster)
            {
                if (((String)p.GetNome()).CompareTo(selezionato) == 0)
                {
                    for (int i = 0; i < p.GetConffigurazioniCount(); i++)
                    {
                        string nome_pannello2 = ((Authoring.PannelliConfigurazione)p).GetNome();
                        string id_pannello2 = ((Authoring.PannelliConfigurazione)p).GetId();
                        string nome_file = directory_principale + "Griglia" + nome_pannello2 + id_pannello2 + p.GetConfigurazione(i) + ".xml";
                        //LeggiFilePerPreviewGriglia(nome_file);
                        LeggiRigaColonna(nome_pannello2, id_pannello2);
                        switch(i) {
                            case 0:
                                InizializzaDataGrid2(nome_file);
                                groupBox2.Visible = true;
                                ElencoTag2.Visible = true;
                                label3.Visible = false;
                                trovato = true;
                                ok.Enabled = true;
                                ok.Cursor = Cursors.Hand;
                                break;
                           /* case 1:
                                InizializzaDataGrid3(nome_file);
                                groupBox3.Visible = true;
                                ElencoTag3.Visible = true;
                                break;
                            case 2:
                                InizializzaDataGrid4(nome_file);
                                groupBox4.Visible = true;
                                ElencoTag4.Visible = true;
                                break;*/
                        }
                        //label4.Text = "Totale Componenti = " + tot_elementi.ToString();
                    }
                }
            }
            if (trovato == false)
            {
                label4.Visible = false;
                label3.Visible = true;
                ok.Enabled = false;
                ok.Cursor = Cursors.Default;
            }
        }

        private void Label2_Click(object sender, System.EventArgs e)
        {
            foreach (Label lab in configList)
                lab.BackColor = System.Drawing.Color.Orange;

            foreach (Label lab in configList2)
                lab.BackColor = System.Drawing.Color.Orange;

            ((Label)sender).BackColor = System.Drawing.Color.Red;
            
            bool trovato = false;
            

            indice_combo = configList2.IndexOf(sender);
            nome_combo = ((Label)configList[indice_combo]).Text;
            string selezionato = nome_combo;
            ((Label)configList[indice_combo]).BackColor = System.Drawing.Color.Red;

            groupBox2.Visible = false;
            /*groupBox3.Visible = false;
            groupBox4.Visible = false;*/
            label3.Visible = true;
            label4.Visible = false;

            foreach (Authoring.PannelliConfigurazione p in tutti_poster)
            {
                if (((String)p.GetNome()).CompareTo(selezionato) == 0)
                {
                    for (int i = 0; i < p.GetConffigurazioniCount(); i++)
                    {
                        string nome_pannello2 = ((Authoring.PannelliConfigurazione)p).GetNome();
                        string id_pannello2 = ((Authoring.PannelliConfigurazione)p).GetId();
                        string nome_file = directory_principale + "Griglia" + nome_pannello2 + id_pannello2 + p.GetConfigurazione(i) + ".xml";
                        //LeggiFilePerPreviewGriglia(nome_file);
                        LeggiRigaColonna(nome_pannello2, id_pannello2);
                        switch (i)
                        {
                            case 0:
                                InizializzaDataGrid2(nome_file);
                                groupBox2.Visible = true;
                                ElencoTag2.Visible = true;
                                label3.Visible = false;
                                trovato = true;
                                ok.Enabled = true;
                                ok.Cursor = Cursors.Hand;
                                break;
                          /*  case 1:
                                InizializzaDataGrid3(nome_file);
                                groupBox3.Visible = true;
                                ElencoTag3.Visible = true;
                                break;
                            case 2:
                                InizializzaDataGrid4(nome_file);
                                groupBox4.Visible = true;
                                ElencoTag4.Visible = true;
                                break;
                            */
                        }
                        //label4.Text = "Totale Componenti = " + tot_elementi.ToString();
                    }
                }
            }
            if (trovato == false)
            {
                label4.Visible = false;
                label3.Visible = true;
                ok.Enabled = false;
                ok.Cursor = Cursors.Default;
            }
        }

    }
}
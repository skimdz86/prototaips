using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.OleDb;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Media;
using QuartzTypeLib;
using NHibernate;
using NHibernate.Cfg;
using System.Xml;


namespace TalkingPaper.Authoring
{
    public partial class AuthoringInsterting : FormSchema
    {
        private int tag_per_riga;
        private int tag_per_colonna;
        private FormVisualizzaElementiAuthoring elenco_elementi;
        //private FormScegliPosterAuthoring scelta_poster;
        //private BenvenutoAuthoring partenza;
        private int rfid_num;
        private Reader.IReader reader;
        private int id_componente;
        private int poster;
        private string nome_poster;
        private int cod_mostra;
        private string directory_principale;
        private string database;
        private Bitmap immagine_modifica_code;
        private Bitmap immagine_code;
        private string oldid;
        private string id_pannello;
        private string nome_pannello;
        private bool esiste;
        private string configurazione;
        private string nome_componente;
        //private DataGridView ElencoRisorse;
        //private int riga;
        //private int colonna;
        private NHibernateManager nh_manager;
        private Bitmap taggato;
        //private TalkingPaper.GestioneDisposizione.ComponentiDelPoster componenti_pos;
        private TalkingPaper.GestioneDisposizione.BenvenutoGestioneDisposizione benvenuto_pos;
        private char[] alfabeto ={ 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'Z' };
        private ElementoGriglia[,] matrice;
        private int num = 0;
        private ArrayList cont_modificati = new ArrayList();
        private GestioneDisposizione.BenvenutoGestioneDisposizione benvenuto_ges;
        //private ElementoGriglia[,] matrice;
        //private TalkingPaper.BarCode.BenvenutoBarCode benvenuto_bar;

        //FormVisualizzaElementi elenco_elementi,int id_componente,FormScegliPoster scelta_poster,BenvenutoBarCode partenza,int poster,string nome_poster,int cod_mostra,string directory_principale,string database
        public AuthoringInsterting(FormVisualizzaElementiAuthoring elenco_elementi, int id_componente, string nome_componente, /*FormScegliPosterAuthoring scelta_poster, BenvenutoAuthoring partenza,*/ int poster, string nome_poster, int cod_mostra, string directory_principale, string database, /*TalkingPaper.GestioneDisposizione.ComponentiDelPoster componenti_pos,*/ TalkingPaper.GestioneDisposizione.BenvenutoGestioneDisposizione benvenuto_pos, string id_pannello, string nome_pannello, string configurazione, GestioneDisposizione.BenvenutoGestioneDisposizione benvenuto_ges)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 90, true);
            oldid = " ";
            reader = new Reader.DumbReader();
            reader.connect();
            //this.matrice = matrice;
            this.configurazione=configurazione;
            this.id_pannello = id_pannello;
            this.nome_pannello = nome_pannello;
            this.benvenuto_ges = benvenuto_ges;
            this.elenco_elementi = elenco_elementi;
            this.benvenuto_pos = benvenuto_pos;
            //this.componenti_pos = componenti_pos;
            this.id_componente = id_componente;
            this.nome_componente = nome_componente;
            //this.scelta_poster = scelta_poster;
            //this.partenza = partenza;
            this.poster = poster;
            this.nome_poster = nome_poster;
            this.cod_mostra = cod_mostra;
            this.directory_principale = directory_principale;
            this.database = database;
            //this.benvenuto_bar = benvenuto_bar;
            this.nh_manager = new NHibernateManager();
            immagine_modifica_code = new Bitmap(directory_principale + @"/Images/Icons/SelezionaPannello.gif");
            immagine_code = new Bitmap(directory_principale + @"/Images/Icons/coding.gif");
            taggato = new Bitmap(directory_principale + @"/Images/Icons/virgoletta.gif");

            //timer.Interval = 1000;
            //timer.Start();
            //timer.Tick += new EventHandler(timer_Tick);
            //Suggerimento.Select(0, 0);
            Salva.Cursor = Cursors.Hand;
            Annulla.Cursor = Cursors.Hand;
            LeggiRigaColonna();

           /* if (rfid_mng.exist() == true)
            {
                rfid_prop = rfid_mng.read_config_rfid_xml();
                rfid_num = rfid_cfg.connect(Convert.ToInt32(rfid_prop.PortReader), rfid_prop.ComunicationframeReader,
                    rfid_prop.BaudrateReader, (short)Convert.ToInt16(rfid_prop.TimeoutReader));
                if (rfid_num <= 0)
                {
                    //Qualcosa non ha funzionato, rifare...
                    MessageBox.Show("SONO in costruttore, qualcosa nn ha funzionato...", "ATTENZIONE",
MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    Console.WriteLine("SONO in costruttore di FormEsecuzione, tutto ok");
                }
            }
            else
            {
                Console.WriteLine("Problema nel recupero delle informazioni del RFID");

                /*
                 * Si potrebbe far aprire la Rfid Configurator Form...
                 * */
            //}
            esiste=System.IO.File.Exists(directory_principale + "Griglia" + nome_pannello + id_pannello + configurazione + poster.ToString() + ".xml");
            InizializzaDataGrid();
        }

        private void LeggiRigaColonna() {
            try
            {
                string nome_file = directory_principale + "Griglia" + nome_pannello + id_pannello + ".xml";
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
                            matrice = new ElementoGriglia[tag_per_colonna + 1, tag_per_riga + 1];
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

        private void InizializzaDataGrid() {
            //int valore = 0;
            Font font = new Font("Arial", 16);
            //textBox1.Click += new EventHandler(textBox1_Click);
            ElencoTag.CellClick += new DataGridViewCellEventHandler(ElencoTag_CellContentClick);
            ElencoTag.CellMouseEnter += new DataGridViewCellEventHandler(ElencoTag_CellMouseEnter);
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
            RiempiDataGrid();
        }

        private void RiempiDataGrid() {
            try
            {
                string nome_file;
                if (esiste == true)
                {
                    nome_file = directory_principale + "Griglia" + nome_pannello + id_pannello + configurazione + poster.ToString() + ".xml";
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
                                string id = (String)iscritto.GetAttribute("ID");
                                bool trov=iscritto.ReadToDescendant("IDcontenuto");
                                if (trov==false)
                                {
                                    if (id.CompareTo("Non Usato") != 0)
                                    {
                                        ElementoGriglia n = new ElementoGriglia(id_pannello, nome_pannello, configurazione, nome_poster, poster, -1, null, alfabeto[i - 1].ToString(), j, id, false);
                                        matrice[i, j] = n;
                                        ElencoTag[i, j].Style.BackColor = Color.Coral;
                                    }
                                    else {
                                        ElementoGriglia n = new ElementoGriglia(id_pannello, nome_pannello, configurazione, nome_poster, poster, -1, null, alfabeto[i - 1].ToString(), j, id, false);
                                        matrice[i, j] = n;
                                    }
                                }
                                else if (trov==true){
                                    string id_cont = iscritto.ReadString();
                                    int id1_cont = Int32.Parse(id_cont);
                                    iscritto.ReadToFollowing("NomeContenuto");
                                    string nome_cont = iscritto.ReadString();
                                    ElementoGriglia n = new ElementoGriglia(id_pannello, nome_pannello, configurazione, nome_poster, poster, id1_cont, nome_cont, alfabeto[i - 1].ToString(), j, id, true);
                                    matrice[i, j] = n;
                                    ElencoTag[i, j].Style.BackColor = Color.Coral;
                                    ElencoTag[i, j].Value = nome_cont;
                                }
                                j++;
                            }
                        }
                        if (i > tag_per_colonna)
                        {
                            fine = true;
                      
                        }
                        if (j > tag_per_riga)
                        {
                            //fine = true;
                            i++;
                            j = 1;
                        }
                    }
                    iscritto.Close();
                }
                else
                {

                    nome_file = directory_principale + "Griglia" + nome_pannello + id_pannello + configurazione + ".xml";
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
                                if (ins.CompareTo("Non Usato") != 0)
                                {
                                    //string ins = (String)iscritto.ReadString();
                                    /*inseriti.Add(ins);
                                    inseriti.Add((String)alfabeto[i - 1].ToString());
                                    inseriti.Add((int)j);*/
                                    ElementoGriglia n = new ElementoGriglia(id_pannello, nome_pannello, configurazione, nome_poster, poster, -1, null, alfabeto[i - 1].ToString(), j, ins,false);
                                    matrice[i, j] = n;
                                    ElencoTag[i, j].Style.BackColor = Color.Coral;
                                }
                                else {
                                    ElementoGriglia n = new ElementoGriglia(id_pannello, nome_pannello, configurazione, nome_poster, poster, -1, null, alfabeto[i - 1].ToString(), j, ins,false);
                                    matrice[i, j] = n;
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
                //esiste = true;
            }
            catch
            {
                //esiste = false;
            }
        }

        private void ElencoTag_CellClick(object sender, DataGridViewCellEventArgs e)
        { 
        
        }

        private void ElencoTag_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (ElencoTag[e.ColumnIndex,e.RowIndex].Style.BackColor==Color.Coral)
            {
                    ElencoTag.Cursor = Cursors.Hand;
            }
            else
                ElencoTag.Cursor = Cursors.Default;
        }

        private void CodeInsterting_Load(object sender, EventArgs e)
        {
            elenco_elementi.Visible = false;
        }


        #region Gestisci Eventi

        void rfid_StatusUpdateEvent(string id)
        {
            //this.textBox1.Text = id;
        }

        private void Annulla_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            elenco_elementi.Visible = true;
            this.Cursor = Cursors.Default;
            this.Visible = false; ;
        }

        private void Salva_Click(object sender, EventArgs e)
        {
            using (ISession tempS = nh_manager.Session)
            using (ITransaction tempT = tempS.BeginTransaction())
            {
                    try
                    {
                        for (int h = 0; h < cont_modificati.Count; h++)
                        {
                            Contenuto contenuto = new Contenuto();
                            int con = (int)cont_modificati[h];
                            IQuery q = tempS.CreateQuery("FROM Contenuto as cont WHERE cont.IDcontenuto=:content AND cont.Poster.IDposter = :poster");
                            q.SetParameter("content", (int)cont_modificati[h]);
                            q.SetParameter("poster", poster);
                            contenuto = (Contenuto)q.List()[0];
                            contenuto.Rfidtag = "0";
                            //devo controllare che non sia già stato inserito uno stesso tag per lo stesso poster
                            tempS.Update(contenuto);
                            tempS.Flush();
                        }
                        tempT.Commit();
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Eccez " + exc.Message);
                    }
                    finally
                    {
                        tempS.Close();
                    }
            }
            try
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.NewLineOnAttributes = true;
                XmlWriter wr = XmlWriter.Create(directory_principale + "Griglia" + nome_pannello + id_pannello + configurazione + poster.ToString() + ".xml");
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
                wr.WriteString(poster.ToString());
                foreach (ElementoGriglia el in matrice)
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
                        //wr.WriteStartElement("Configurazione", textBox1.Text);
                        if (el.GetUtilizzato() == true)
                        {
                            using (ISession tempS = nh_manager.Session)
                            //using (ITransaction tempT = tempS.BeginTransaction())
                            {
                                try
                                {
                                    Contenuto contenuto = new Contenuto();
                                    IQuery q = tempS.CreateQuery("FROM Contenuto as cont WHERE cont.IDcontenuto=:content AND cont.Poster.IDposter = :poster");
                                    q.SetParameter("content", el.GetIdContenuto());
                                    q.SetParameter("poster", poster);
                                    contenuto = (Contenuto)q.List()[0];
                                    if (el.GetTagContenuto().CompareTo("Non Usato") != 0)
                                    {
                                        contenuto.Rfidtag = el.GetTagContenuto();
                                    }
                                    else
                                    {
                                        contenuto.Rfidtag = "0";
                                    }
                                    //devo controllare che non sia già stato inserito uno stesso tag per lo stesso poster
                                    tempS.Update(contenuto);
                                    tempS.Flush();
                                    //tempT.Commit();
                                }
                                catch (Exception exc)
                                {
                                    MessageBox.Show("Eccez " + exc.Message);
                                }
                                finally
                                {
                                    tempS.Close();
                                }
                            }
                        }
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
            this.Cursor = Cursors.WaitCursor;
            FormVisualizzaElementiAuthoring n = new FormVisualizzaElementiAuthoring(poster, nome_poster, cod_mostra, directory_principale, database, benvenuto_pos, id_pannello, nome_pannello, configurazione, this,benvenuto_ges);
            n.Show();
            //this.Visible = false;
            this.Close();
            elenco_elementi.Close();
            this.Cursor = Cursors.Default;

            /*if (((textBox1.Text).CompareTo("")) == 0)
            {
                MessageBox.Show("Non hai inserito il codice del tag");
            }
            else
            {
                if (oldid.Equals(textBox1.Text) == false)
                {
                    Contenuto contenuto = new Contenuto();
                    oldid = textBox1.Text;
                    using (ISession tempS = nh_manager.Session)
                    //using (ITransaction tempT = tempS.BeginTransaction())
                    {
                        try
                        {
                            //se esiste già un contenuto con quel tag...
                            IQuery q1 = tempS.CreateQuery("FROM Contenuto as cont WHERE cont.Rfidtag=:content AND cont.Poster.IDposter = :poster");
                            q1.SetParameter("content", textBox1.Text);
                            q1.SetParameter("poster", poster);
                            contenuto = (Contenuto)q1.List()[0];

                            MessageBox.Show("Hai già inserito questo tag per questo poster, nel contenuto\n " + contenuto.Nome);
                            textBox1.Clear();

                        }
                        catch (Exception ex) // se non ci sono elementi, va bene:
                        {

                            try
                            {
                                IQuery q = tempS.CreateQuery("FROM Contenuto as cont WHERE cont.IDcontenuto=:content AND cont.Poster.IDposter = :poster");
                                q.SetParameter("content", id_componente);
                                q.SetParameter("poster", poster);
                                contenuto = (Contenuto)q.List()[0];
                                contenuto.Rfidtag = textBox1.Text;
                                //devo controllare che non sia già stato inserito uno stesso tag per lo stesso poster
                                tempS.Update(contenuto);
                                tempS.Flush();
                                elenco_elementi.Close();
                                FormVisualizzaElementiAuthoring nuo = new FormVisualizzaElementiAuthoring(scelta_poster, partenza, poster, nome_poster, cod_mostra, directory_principale, database, componenti_pos, benvenuto_pos,id_pannello,nome_pannello);
                                this.Close();
                                nuo.Show();
                                //tempT.Commit();
                            }
                            catch (Exception exc)
                            {
                                MessageBox.Show("Eccez " + exc.Message);
                            }
                        }
                        finally
                        {
                            tempS.Close();
                        }
                    }
                    /*Contenuto contenuto = new Contenuto();
                    using (ISession tempS = nh_manager.Session)
                    using (ITransaction tempT = tempS.BeginTransaction())
                    {
                        try
                        {
                            IQuery q = tempS.CreateQuery("FROM Contenuto as cont WHERE cont.IDcontenuto=:content");
                            q.SetParameter("content", id_componente);
                            contenuto = (Contenuto)q.List()[0];
                            contenuto.Rfidtag = textBox1.Text;
                            tempS.Update(contenuto);
                            tempS.Flush();
                            tempT.Commit();
                        }
                        catch (Exception ex)
                        {
                            tempT.Rollback();
                            Console.WriteLine("Eccezione in Scegli Mostra");
                        }
                        finally
                        {
                            tempS.Close();
                        }
                    }*/
                    /* DataGridViewImageCell immagine_codice = new DataGridViewImageCell();
                     if ((textBox1.Text).CompareTo("0") == 0)
                     {
                         immagine_codice.Value = immagine_code;
                     }
                     else
                     {
                         immagine_codice.Value = immagine_modifica_code;
                     }
                     ElencoRisorse[colonna, riga] = immagine_codice;
                     elenco_elementi.Visible = true;
                     this.Close();*/
                    /*elenco_elementi.Close();
                    FormVisualizzaElementiRFID nuo = new FormVisualizzaElementiRFID(scelta_poster, partenza, poster, nome_poster, cod_mostra, directory_principale, database);
                    this.Close();
                    nuo.Show();*/
                /*}
                else
                {
                    Console.WriteLine("Id già letto, old = " + oldid + " e nuovo " + textBox1.Text);
                }
            }
            this.Cursor = Cursors.Default;*/
        }

        void timer_Tick(object sender, EventArgs e)
        {
            reader.readerStatusUpdate += rfid_StatusUpdateEvent;
            //rfid_cfg.StatusUpdateEvent += new RFIDlibrary.RFIDConfigurator.StatusUpdateDelegate(rfid_StatusUpdateEvent);
            //int tag_letto = rfid_cfg.letturaID(rfid_num);
            //Console.WriteLine("In timer_tick, tag_letto = " + tag_letto +"\nvediamo un po'...");
            //this.richTextBox1.Text += "\aciao\r";
            //this.textBox1.Focus();
        }
        #endregion

        private void AuthoringInsterting_Load(object sender, EventArgs e)
        {

        }

        private void ElencoTag_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bool gia_presente = false;
            ElencoTag[e.ColumnIndex, e.RowIndex].Selected = false;
            string colonna = "";
            int riga = -1;
            foreach (ElementoGriglia el in matrice)
            {
                if (el != null)
                {
                    if (el.GetUtilizzato() == true)
                    {
                        if ((el.GetIdContenuto() == id_componente) && (nome_componente.CompareTo(el.GetNomeContenuto()) == 0))
                        {
                            gia_presente = true;
                            riga = el.GetRiga();
                            colonna = el.getColonna();
                        }
                    }
                }
            }
            if (ElencoTag[e.ColumnIndex, e.RowIndex].Style.BackColor == Color.Coral)
            {
                this.Enabled = false;
                if (num == 0)
                {
                    num = 1;
                    if ((ElencoTag[e.ColumnIndex, e.RowIndex].Value != null) && (((String)ElencoTag[e.ColumnIndex, e.RowIndex].Value).CompareTo(nome_componente) == 0))
                    {
                        DialogResult n = MessageBox.Show("Vuoi eliminare questo contenuto ?", "", MessageBoxButtons.YesNo);
                        if (n == DialogResult.Yes)
                        {
                            ElencoTag[e.ColumnIndex, e.RowIndex].Selected = false;
                            ElencoTag[e.ColumnIndex, e.RowIndex].Value = null;
                            int id_co = (int)((ElementoGriglia)matrice[e.ColumnIndex, e.RowIndex]).GetIdContenuto();
                            cont_modificati.Add((int)((ElementoGriglia)matrice[e.ColumnIndex, e.RowIndex]).GetIdContenuto());
                            ((ElementoGriglia)matrice[e.ColumnIndex, e.RowIndex]).SetIdContenuto(-1);
                            ((ElementoGriglia)matrice[e.ColumnIndex, e.RowIndex]).SetNomeContenuto(null);
                            ((ElementoGriglia)matrice[e.ColumnIndex, e.RowIndex]).SetUtilizzato(false);
                            num = 0;
                        }
                        else
                        {
                            ElencoTag[e.ColumnIndex, e.RowIndex].Selected = false;
                        }
                    }
                    else if ((ElencoTag[e.ColumnIndex, e.RowIndex].Value != null) && (((String)ElencoTag[e.ColumnIndex, e.RowIndex].Value).CompareTo(nome_componente) != 0))
                    {
                        //ElencoTag[e.ColumnIndex, e.RowIndex].Value = nome_componente;
                        //Richiesta n = new Richiesta(this,matrice);
                        //this.Visible = false;
                        //n.Show();
                        //bool o = n.GetModifica();
                        if (gia_presente == false)
                        {
                            DialogResult n = MessageBox.Show("Sei sicuro di voler sostituire il contenuto " + ElencoTag[e.ColumnIndex, e.RowIndex].Value.ToString() + "con il contenuto " + nome_componente + "?", "", MessageBoxButtons.YesNo);
                            if (n == DialogResult.Yes)
                            {
                                ElencoTag[e.ColumnIndex, e.RowIndex].Selected = false;
                                cont_modificati.Add((int)(((ElementoGriglia)matrice[e.ColumnIndex, e.RowIndex]).GetIdContenuto()));
                                ((ElementoGriglia)matrice[e.ColumnIndex, e.RowIndex]).SetIdContenuto(id_componente);
                                ((ElementoGriglia)matrice[e.ColumnIndex, e.RowIndex]).SetNomeContenuto(nome_componente);
                                ((ElementoGriglia)matrice[e.ColumnIndex, e.RowIndex]).SetUtilizzato(true);
                                ElencoTag[e.ColumnIndex, e.RowIndex].Value = nome_componente;
                            }
                            else
                            {
                                ElencoTag[e.ColumnIndex, e.RowIndex].Selected = false;
                                num = 0;
                            }
                        }
                    }
                    else
                    {
                        ElencoTag[e.ColumnIndex, e.RowIndex].Selected = false;
                        /*bool gia_presente = false;
                        string colonna="";
                        int riga=-1;
                        foreach (ElementoGriglia el in matrice) {
                            if (el != null)
                            {
                                if (el.GetUtilizzato() == true)
                                {
                                    if ((el.GetIdContenuto() == id_componente) && (nome_componente.CompareTo(el.GetNomeContenuto()) == 0))
                                    {
                                        gia_presente = true;
                                        riga = el.GetRiga();
                                        colonna = el.getColonna();
                                    }
                                }
                            }
                        }*/
                        //ElencoTag[e.ColumnIndex, e.RowIndex].Selected = false;
                        if (gia_presente == false)
                        {
                            ElencoTag[e.ColumnIndex, e.RowIndex].Value = nome_componente;
                            int id_co = id_componente;
                            ((ElementoGriglia)matrice[e.ColumnIndex, e.RowIndex]).SetIdContenuto(id_componente);
                            ((ElementoGriglia)matrice[e.ColumnIndex, e.RowIndex]).SetNomeContenuto(nome_componente);
                            ((ElementoGriglia)matrice[e.ColumnIndex, e.RowIndex]).SetUtilizzato(true);
                            num = 0;
                        }
                        else
                        {
                            MessageBox.Show("Il contenuto è già inserito in " + colonna.ToString() + riga.ToString());
                            num = 0;
                        }
                    }
                    this.Enabled = true;
                }
                else
                {
                    num = 0;
                    this.Enabled = true;
                }
            }
        }

        private void indietro_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Cursor = Cursors.Default;
            this.Close();
        }

        /*private void Menu_Click(object sender, EventArgs e)
        {
            QuestionCambiaGriglia richiesta = new QuestionCambiaGriglia(partenza, global.home);
            richiesta.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }*/
    }
}
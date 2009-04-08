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
using RFIDlibrary;
using System.Xml;


namespace TalkingPaper.GestioneDisposizione
{
    public partial class ComponentiDelPoster : FormSchema
    {
        private int tag_per_riga;
        private int tag_per_colonna;
        private BenvenutoGestioneDisposizione benvenuto;
        private PosterDellaMostra poster;
        private TalkingPaper.NHibernateManager nh_manager;
        private int id_mostra;
        private int id_poster;
        private string nome_poster;
        private string directory_principale;
        private IList contenuti;
        private Bitmap play_audio;
        private Bitmap modifica;
        private Bitmap elimina;
        private Bitmap play_video;
        private Bitmap testo;
        private Bitmap preview_immagine;
        private Bitmap pausa;
        private Bitmap stop;
        private Bitmap riprendi;
        private ArrayList audio_video;
        /*private TalkingPaper.BarCode.BenvenutoBarCode benvenuto_bar;
        private TalkingPaper.RfidCode.BenvenutoRFID benvenuto_rfid;
        private TalkingPaper.BarCode.FormVisualizzaElementi visualizza_bar;
        private TalkingPaper.RfidCode.FormVisualizzaElementiRFID visualizza_rfid;*/
        private TalkingPaper.Authoring.BenvenutoAuthoring benvenuto_aut;
        private TalkingPaper.Authoring.FormVisualizzaElementiAuthoring visualizza_aut;
        private string id_pannello;
        private string nome_pannello;
        private string configurazione;
        private string database = "talkingpaper2";
        private int tot_elementi = 0;
        private char[] alfabeto ={ 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'Z' };
        private string provenienza;

        public ComponentiDelPoster(BenvenutoGestioneDisposizione benvenuto, PosterDellaMostra poster, int id_mostra, int id_poster, string nome_poster, string directory_principale, string provenienza, TalkingPaper.Authoring.BenvenutoAuthoring benvenuto_aut,TalkingPaper.Authoring.FormVisualizzaElementiAuthoring visualizza_aut,string id_pannello, string nome_pannello,string configurazione)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 99, true);
            this.audio_video = new ArrayList();
            audio_video.Add(null);
            audio_video.Add(null);
            this.provenienza = provenienza;
            this.id_pannello = id_pannello;
            this.nome_pannello = nome_pannello;
            this.configurazione = configurazione;
            //this.visualizza_rfid = visualizza_rfid;
            //this.visualizza_bar = visualizza_bar;
            this.benvenuto = benvenuto;
            //this.benvenuto_bar = benvenuto_bar;
            //this.benvenuto_rfid = benvenuto_rfid;
            this.benvenuto_aut = benvenuto_aut;
            this.visualizza_aut = visualizza_aut;
            this.poster = poster;
            this.id_mostra = id_mostra;
            this.id_poster = id_poster;
            this.nome_poster = nome_poster;
            this.directory_principale = directory_principale;
            this.nh_manager = new NHibernateManager();
            play_audio = new Bitmap(directory_principale + @"/Images/Icons/nota2.gif");
            modifica = new Bitmap(directory_principale + @"/Images/Icons/modifica3.gif");
            elimina = new Bitmap(directory_principale + @"/Images/Icons/elimina_cestino.gif");
            play_video = new Bitmap(directory_principale + @"/Images/Icons/play_video.gif");
            testo = new Bitmap(directory_principale + @"/Images/Icons/preview _testo.gif");
            preview_immagine = new Bitmap(directory_principale + @"/Images/Icons/preview_immagine.gif");
            pausa = new Bitmap(directory_principale + @"/Images/Icons/Pause.bmp");
            stop = new Bitmap(directory_principale + @"/Images/Icons/Stop.bmp");
            riprendi = new Bitmap(directory_principale + @"/Images/Icons/Play.bmp");
            this.sottotitolo.Text = this.sottotitolo.Text + '"' + nome_poster + '"';
            Esci.Cursor = Cursors.Hand;
            button1.Cursor = Cursors.Hand;
            button2.Cursor = Cursors.Hand;
            button3.Cursor = Cursors.Hand;
            button4.Cursor = Cursors.Hand;
            //button5.Cursor = Cursors.Hand;
            //AggiungiAMostra.Cursor = Cursors.Hand;
            AggiungiControllo.Cursor = Cursors.Hand;
            /*if (id_mostra == -1)
            {
                AggiungiAMostra.Visible = true;
            }*/
            if ((benvenuto == null) && (poster == null) && (provenienza != null) && (id_mostra != -1))
            {
                button2.Visible = false;
                //AggiungiAMostra.Visible = false;
            }
            if ((visualizza_aut != null) || (visualizza_aut != null))
            {
                //AggiungiAMostra.Visible = false;
            }
            if (provenienza != null)
            {
                /*AggiungiAMostra.Visible = false;
                if (provenienza.CompareTo("rfid") == 0)
                {
                    button4.Visible = false;
                }
                else if (provenienza.CompareTo("barcode") == 0)
                {
                    button5.Visible = false;
                }*/
            }
            //textBox1.Select(0,0);
            InterrogaDB();
            Controlli();
            if ((benvenuto != null) && (poster == null))
            {
                //button2.Text = "Torna alla finestra di benvenuto";
                button2.Text = "Indietro";
            }
            else if (poster != null)
            {
                //button2.Text = "Torna all'elenco dei poster";
                button2.Text = "Indietro";
            }
            else
            {
                button2.Visible = false;
            }
            label5.Text = "Pannello associato = " + nome_pannello;
            label6.Text = "Configurazione = " + configurazione;
            LeggiRigaColonna();
            string nome_file = directory_principale + "Griglia" + nome_pannello+ id_pannello + configurazione + ".xml";
            InizializzaDataGrid2(nome_file);
        }

        private void ComponentiDelPoster_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Authoring.FormVisualizzaElementiAuthoring n = new TalkingPaper.Authoring.FormVisualizzaElementiAuthoring(null, benvenuto_aut, id_poster, nome_poster, -1, directory_principale, database, this, benvenuto, id_pannello, nome_pannello, configurazione, null, benvenuto,provenienza, id_mostra, poster);
            n.Show();
            this.Cursor = Cursors.Default;
            this.Close();
        }

    private void LeggiRigaColonna()
        {
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
                            //matrice = new ElementoGriglia[tag_per_colonna + 1, tag_per_riga + 1];
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

        private void InizializzaDataGrid2(string f)
        {
            //int valore = 0;
            Font font = new Font("Arial", 8);
            ElencoTag2.Rows.Clear();
            tot_elementi = 0;
            //textBox1.Click += new EventHandler(textBox1_Click);
            //ElencoTag2.CellClick += new DataGridViewCellEventHandler(ElencoTag_CellContentClick);
            //ElencoTag2.CellMouseEnter += new DataGridViewCellEventHandler(ElencoTag_CellMouseEnter);
            ElencoTag2.ReadOnly = true;
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
                            //string ins = (String)iscritto.ReadString();
                            /*inseriti.Add(ins);
                            inseriti.Add((String)alfabeto[i - 1].ToString());
                            inseriti.Add((int)j);*/
                            //ElementoGriglia n = new ElementoGriglia(id_pannello, nome_pannello, configurazione, nome_poster, id_poster, -1, null, alfabeto[i - 1].ToString(), j, ins, false);
                            //matrice[i, j] = n;
                            ElencoTag2[i, j].Style.BackColor = Color.Coral;
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
            label4.Text = "Totale Componenti = " + tot_elementi.ToString();
        }


        private void InterrogaDB()
        {
            using (ISession tempS = nh_manager.Session)
            using (ITransaction tempT = tempS.BeginTransaction())
            {
                try
                {
                    IQuery q = tempS.CreateQuery("FROM Contenuto as cont WHERE cont.Poster=:Pos");
                    q.SetParameter("Pos", id_poster);
                    contenuti = q.List();
                    tempT.Commit();
                    int non_controlli = 0;
                    foreach (Contenuto c in contenuti)
                    {
                        if (c.Tipo.Tipo.CompareTo("Controllo") != 0)
                        {
                            non_controlli++;
                        }
                    }
                    if (non_controlli == 0)
                    {
                        label2.Visible = true;
                        ElencoRisorse.Visible = false;
                        ElencoTag2.Visible = false;
                        label4.Visible = false;
                    }
                    else
                    {
                        label2.Visible = false;
                        ElencoRisorse.Visible = true;
                        ElencoTag2.Visible = true;
                        label4.Visible = true;
                        //mostre = new ArrayList();
                        //mostre = (ArrayList)mostre_sel;

                        // Setting della DataGrid
                        ElencoRisorse.ColumnCount = 13;
                        ElencoRisorse.ColumnHeadersVisible = false;
                        ElencoRisorse.Columns[0].Visible = false;
                        //DataGridViewRow riga = new DataGridViewRow();
                        ElencoRisorse.Rows.Add("NUM", "  ", "NOME", "  ", "AUDIO/VIDEO", "  ", "IMMAGINE", "  ", "TESTO", "  ", "MODIFICA", "  ", "ELIMINA"); // ,"  ", "ELIMINA");
                        ElencoRisorse.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
                        ElencoRisorse.Rows.Add();
                        ElencoRisorse.CellMouseEnter += new DataGridViewCellEventHandler(ElencoRisorse_CellMouseEnter);

                        // Riempimento della DataGrid
                        int riga = 2;
                        foreach (Contenuto p in contenuti)
                        {
                            if (p.Tipo.Tipo.CompareTo("Controllo") != 0)
                            {
                                ElencoRisorse.Rows.Add(p.IDcontenuto, null, p.Nome, null, null, null, null, null, null, null, null, null, null);
                                try
                                {
                                    if (p.RisorsaMultimediale.Path.Contains("audio"))
                                    {
                                        DataGridViewImageCell play = new DataGridViewImageCell();
                                        play.Value = play_audio;
                                        play.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                        ElencoRisorse[4, riga] = play;
                                        audio_video.Add("audio");
                                        audio_video.Add(null);
                                    }
                                    else
                                    {
                                        DataGridViewImageCell play = new DataGridViewImageCell();
                                        play.Value = play_video;
                                        play.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                        ElencoRisorse[4, riga] = play;
                                        audio_video.Add("video");
                                        audio_video.Add("video");
                                    }
                                }
                                catch (Exception eeee)
                                {

                                }
                                foreach (Altrarisorsa ris in p.AltrarisorsaLista)
                                {
                                    if (ris.Tipo.CompareTo("testo") == 0)
                                    {
                                        DataGridViewImageCell play_testo = new DataGridViewImageCell();
                                        play_testo.Value = testo;
                                        play_testo.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                        ElencoRisorse[8, riga] = play_testo;
                                    }
                                    else if (ris.Tipo.CompareTo("immagine") == 0)
                                    {
                                        DataGridViewImageCell preview_img = new DataGridViewImageCell();
                                        preview_img.Value = preview_immagine;
                                        preview_img.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                        ElencoRisorse[6, riga] = preview_img;
                                    }
                                }
                                DataGridViewImageCell delete = new DataGridViewImageCell();
                                delete.Value = elimina;
                                delete.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                DataGridViewImageCell modify = new DataGridViewImageCell();
                                modify.Value = modifica;
                                modify.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                ElencoRisorse[10, riga] = modify;
                                ElencoRisorse[12, riga] = delete;
                                audio_video.Add("immagine_testo");
                                audio_video.Add("immagine_testo");
                                ElencoRisorse.Rows.Add();
                                riga += 2;
                            }
                        }


                        /* // Creazione e riempimento della DataGrid
                        ElencoRisorse.ColumnCount = 7;
                        ElencoRisorse.ColumnHeadersVisible = false;
                        DataGridViewRow riga = new DataGridViewRow();
                        ElencoRisorse.Rows.Add("NUM", "  ", "POSTER", "  ", "     ","  ","     ");
                        ElencoRisorse.Rows.Add();
                        ElencoRisorse.CellClick += new DataGridViewCellEventHandler(this.ClickSullaTabella);*/

                    }
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
            }
        }

        private void Controlli()
        {
            /* ElencoControlli1.ColumnCount = 7;
             ElencoControlli1.ColumnHeadersVisible = false;
             ElencoControlli1.Columns[0].Visible = false;
             //DataGridViewRow riga = new DataGridViewRow();
             ElencoControlli1.Rows.Add("NUM", "  ", "NOME", "  ", "ICONA", "  ", "ELIMINA");
             ElencoControlli1.Rows.Add();
             ElencoControlli1.CellClick += new DataGridViewCellEventHandler(this.ClickSullaTabellaDeiControlli);*/
            ElencoControlli1.CellMouseEnter += new DataGridViewCellEventHandler(ElencoControlli1_CellMouseEnter);

            // Riempimento della DataGrid
            //int riga = 2;
            int num_controllo = 1;
            IList controlli;
            DataGridViewImageCell pause = new DataGridViewImageCell();
            DataGridViewImageCell resume = new DataGridViewImageCell();
            DataGridViewImageCell stopp = new DataGridViewImageCell();
            //DataGridViewImageCell eliminare = new DataGridViewImageCell();
            using (ISession tempS = nh_manager.Session)
            using (ITransaction tempT = tempS.BeginTransaction())
            {
                try
                {
                    IQuery q = tempS.CreateQuery("FROM Contenuto as cont WHERE cont.Poster=:Pos");
                    q.SetParameter("Pos", id_poster);
                    controlli = q.List();
                    tempT.Commit();
                    foreach (Contenuto c in controlli)
                    {
                        if (c.Tipo.Tipo.CompareTo("Controllo") == 0)
                        {
                            if (num_controllo == 1)
                            {
                                ElencoControlli1.ColumnCount = 5;
                                ElencoControlli1.ColumnHeadersVisible = false;
                                ElencoControlli1.Columns[0].Visible = false;
                                //DataGridViewRow riga = new DataGridViewRow();
                                //ElencoControlli1.Rows.Add("NUM", "  ", "NOME", "  ", "ICONA", "  ", "ELIMINA");
                                //ElencoControlli1.Rows.Add();
                                // ElencoControlli1.CellClick += new DataGridViewCellEventHandler(this.ClickSullaTabellaDeiControlli1);
                                ElencoControlli1.Rows.Add(c.IDcontenuto, null, c.Nome, null, null);
                                ElencoControlli1.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
                                ElencoControlli1.Rows.Add();
                                ElencoControlli1.Rows.Add();
                                ElencoControlli1[4, 1].Value = "elimina";
                                if (c.Tipo.Descrizione.CompareTo("Pausa") == 0)
                                {
                                    //DataGridViewImageCell delete = new DataGridViewImageCell();
                                    pause.Value = pausa;
                                    pause.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli1[2, 2] = pause;
                                }
                                else if (c.Tipo.Descrizione.CompareTo("Stop") == 0)
                                {
                                    stopp.Value = stop;
                                    stopp.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli1[2, 2] = stopp;
                                }
                                else if (c.Tipo.Descrizione.CompareTo("Play") == 0)
                                {
                                    resume.Value = riprendi;
                                    resume.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli1[2, 2] = resume;
                                }
                                DataGridViewImageCell eliminare = new DataGridViewImageCell();
                                eliminare.Value = elimina;
                                eliminare.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                ElencoControlli1[4, 2] = eliminare;
                                //riga += 2;
                                //num_controllo = 2;
                            }
                            if (num_controllo == 2)
                            {
                                ElencoControlli2.ColumnCount = 5;
                                ElencoControlli2.ColumnHeadersVisible = false;
                                ElencoControlli2.Columns[0].Visible = false;
                                //DataGridViewRow riga = new DataGridViewRow();
                                //ElencoControlli1.Rows.Add("NUM", "  ", "NOME", "  ", "ICONA", "  ", "ELIMINA");
                                //ElencoControlli1.Rows.Add();
                                //ElencoControlli2.CellClick += new DataGridViewCellEventHandler(this.ClickSullaTabellaDeiControlli2);
                                ElencoControlli2.CellMouseEnter += new DataGridViewCellEventHandler(ElencoControlli2_CellMouseEnter);
                                ElencoControlli2.Rows.Add(c.IDcontenuto, null, c.Nome, null, null);
                                ElencoControlli2.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
                                ElencoControlli2.Rows.Add();
                                ElencoControlli2.Rows.Add();
                                ElencoControlli2[4, 1].Value = "elimina";
                                if (c.Tipo.Descrizione.CompareTo("Pausa") == 0)
                                {
                                    //DataGridViewImageCell delete = new DataGridViewImageCell();
                                    pause.Value = pausa;
                                    pause.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli2[2, 2] = pause;
                                }
                                else if (c.Tipo.Descrizione.CompareTo("Stop") == 0)
                                {
                                    stopp.Value = stop;
                                    stopp.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli2[2, 2] = stopp;
                                }
                                else if (c.Tipo.Descrizione.CompareTo("Play") == 0)
                                {
                                    resume.Value = riprendi;
                                    resume.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli2[2, 2] = resume;
                                }
                                DataGridViewImageCell eliminare = new DataGridViewImageCell();
                                eliminare.Value = elimina;
                                eliminare.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                ElencoControlli2[4, 2] = eliminare;
                                //riga += 2;
                                //num_controllo = 3;
                            }
                            if (num_controllo == 3)
                            {
                                ElencoControlli3.ColumnCount = 5;
                                ElencoControlli3.ColumnHeadersVisible = false;
                                ElencoControlli3.Columns[0].Visible = false;
                                //DataGridViewRow riga = new DataGridViewRow();
                                //ElencoControlli1.Rows.Add("NUM", "  ", "NOME", "  ", "ICONA", "  ", "ELIMINA");
                                //ElencoControlli1.Rows.Add();
                                //ElencoControlli3.CellClick += new DataGridViewCellEventHandler(this.ClickSullaTabellaDeiControlli3);
                                ElencoControlli3.CellMouseEnter += new DataGridViewCellEventHandler(ElencoControlli3_CellMouseEnter);
                                ElencoControlli3.Rows.Add(c.IDcontenuto, null, c.Nome, null, null);
                                ElencoControlli3.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
                                ElencoControlli3.Rows.Add();
                                ElencoControlli3.Rows.Add();
                                ElencoControlli3[4, 1].Value = "elimina";
                                if (c.Tipo.Descrizione.CompareTo("Pausa") == 0)
                                {
                                    //DataGridViewImageCell delete = new DataGridViewImageCell();
                                    pause.Value = pausa;
                                    pause.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli3[2, 2] = pause;
                                }
                                else if (c.Tipo.Descrizione.CompareTo("Stop") == 0)
                                {
                                    stopp.Value = stop;
                                    stopp.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli3[2, 2] = stopp;
                                }
                                else if (c.Tipo.Descrizione.CompareTo("Play") == 0)
                                {
                                    resume.Value = riprendi;
                                    resume.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli3[2, 2] = resume;
                                }
                                DataGridViewImageCell eliminare = new DataGridViewImageCell();
                                eliminare.Value = elimina;
                                eliminare.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                ElencoControlli3[4, 2] = eliminare;
                                //riga += 2;
                                num_controllo = 3;
                            }
                            num_controllo++;
                        }
                        // num_controllo++;
                    }
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
            }
        }

        private void ClickSullaTabellaDeiControlli1(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 4) && (e.RowIndex == 2))
            {
                this.Cursor = Cursors.WaitCursor;
                QuestionEliminaComponente nuovo = new QuestionEliminaComponente(this, (int)ElencoControlli1[0, 0].Value, benvenuto, poster, id_mostra, id_poster, nome_poster, directory_principale, provenienza, benvenuto_aut,visualizza_aut,id_pannello,nome_pannello,configurazione);
                //this.Visible = false;
                nuovo.Show();
                this.Cursor = Cursors.Default;
                this.Visible = false;
                /* string descrizione_controllo;
                 descrizione_controllo = (String)ElencoControlli1[2, 0].Value;
                 using (ISession tempS = nh_manager.Session)
                 using (ITransaction tempT = tempS.BeginTransaction())
                 {
                     try
                     {
                         Tipologia tipo = new Tipologia();
                         Poster posterr = new Poster();
                         Contenuto da_eliminare = new Contenuto();
                         IQuery q = tempS.CreateQuery("FROM Tipologia as tp WHERE tp.Descrizione=:Des");
                         q.SetParameter("Des", descrizione_controllo);
                         tipo = (Tipologia)q.List()[0];
                         tempS.Flush();
                         IQuery q2 = tempS.CreateQuery("FROM Poster as pt WHERE pt.IDposter=:Pos");
                         q2.SetParameter("Pos", id_poster);
                         posterr = (Poster)q2.List()[0];
                         tempS.Flush();
                         foreach (Contenuto cont in posterr.ContenutoLista) {
                             if (cont.Tipo.IDtipologia == tipo.IDtipologia) {
                                 //posterr.ContenutoLista.Remove(cont);
                                 //tempS.Delete(cont);
                                 //tempS.Flush();
                                 da_eliminare = cont;
                             }
                         }
                         posterr.ContenutoLista.Remove(da_eliminare);
                         tempS.Delete(da_eliminare);
                         tempS.Flush();
                         tempS.Update(posterr);
                         tempS.Flush();
                         tempT.Commit();
                         this.Close();
                         this.Close();
                         ComponentiDelPoster nuova_form = new ComponentiDelPoster(benvenuto, poster, id_mostra, id_poster, nome_poster, directory_principale);
                         nuova_form.Show();
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
            }
        }

        private void ClickSullaTabellaDeiControlli2(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 4) && (e.RowIndex == 2))
            {
                this.Cursor = Cursors.WaitCursor;
                QuestionEliminaComponente nuovo = new QuestionEliminaComponente(this, (int)ElencoControlli2[0, 0].Value, benvenuto, poster, id_mostra, id_poster, nome_poster, directory_principale, provenienza, benvenuto_aut,visualizza_aut,id_pannello,nome_pannello,configurazione);
                //this.Visible = false;
                nuovo.Show();
                this.Cursor = Cursors.Default;
                this.Visible = false;
                /*string descrizione_controllo;
                descrizione_controllo = (String)ElencoControlli2[2, 0].Value;
                using (ISession tempS = nh_manager.Session)
                using (ITransaction tempT = tempS.BeginTransaction())
                {
                    try
                    {
                        Tipologia tipo = new Tipologia();
                        Poster posterr = new Poster();
                        Contenuto da_eliminare = new Contenuto();
                        IQuery q = tempS.CreateQuery("FROM Tipologia as tp WHERE tp.Descrizione=:Des");
                        q.SetParameter("Des", descrizione_controllo);
                        tipo = (Tipologia)q.List()[0];
                        tempS.Flush();
                        IQuery q2 = tempS.CreateQuery("FROM Poster as pt WHERE pt.IDposter=:Pos");
                        q2.SetParameter("Pos", id_poster);
                        posterr = (Poster)q2.List()[0];
                        tempS.Flush();
                        foreach (Contenuto cont in posterr.ContenutoLista)
                        {
                            if (cont.Tipo.IDtipologia == tipo.IDtipologia)
                            {
                                //posterr.ContenutoLista.Remove(cont);
                                //tempS.Delete(cont);
                                //tempS.Flush();
                                da_eliminare = cont;
                            }
                        }
                        posterr.ContenutoLista.Remove(da_eliminare);
                        tempS.Delete(da_eliminare);
                        tempS.Flush();
                        tempS.Update(posterr);
                        tempS.Flush();
                        tempT.Commit();
                        this.Close();
                        this.Close();
                        ComponentiDelPoster nuova_form = new ComponentiDelPoster(benvenuto, poster, id_mostra, id_poster, nome_poster, directory_principale);
                        nuova_form.Show();
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
            }
        }

        private void ClickSullaTabellaDeiControlli3(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 4) && (e.RowIndex == 2))
            {
                this.Cursor = Cursors.WaitCursor;
                QuestionEliminaComponente nuovo = new QuestionEliminaComponente(this, (int)ElencoControlli3[0, 0].Value, benvenuto, poster, id_mostra, id_poster, nome_poster, directory_principale, provenienza, benvenuto_aut,visualizza_aut,id_pannello,nome_pannello,configurazione);
                //this.Visible = false;
                nuovo.Show();
                this.Cursor = Cursors.Default;
                this.Visible = false;
                /*string descrizione_controllo;
                descrizione_controllo = (String)ElencoControlli3[2, 0].Value;
                using (ISession tempS = nh_manager.Session)
                using (ITransaction tempT = tempS.BeginTransaction())
                {
                    try
                    {
                        Tipologia tipo = new Tipologia();
                        Poster posterr = new Poster();
                        Contenuto da_eliminare = new Contenuto();
                        IQuery q = tempS.CreateQuery("FROM Tipologia as tp WHERE tp.Descrizione=:Des");
                        q.SetParameter("Des", descrizione_controllo);
                        tipo = (Tipologia)q.List()[0];
                        tempS.Flush();
                        IQuery q2 = tempS.CreateQuery("FROM Poster as pt WHERE pt.IDposter=:Pos");
                        q2.SetParameter("Pos", id_poster);
                        posterr = (Poster)q2.List()[0];
                        tempS.Flush();
                        foreach (Contenuto cont in posterr.ContenutoLista)
                        {
                            if (cont.Tipo.IDtipologia == tipo.IDtipologia)
                            {
                                //posterr.ContenutoLista.Remove(cont);
                                //tempS.Delete(cont);
                                //tempS.Flush();
                                da_eliminare = cont;
                            }
                        }
                        posterr.ContenutoLista.Remove(da_eliminare);
                        tempS.Delete(da_eliminare);
                        tempS.Flush();
                        tempS.Update(posterr);
                        tempS.Flush();
                        tempT.Commit();
                        this.Close();
                        this.Close();
                        ComponentiDelPoster nuova_form = new ComponentiDelPoster(benvenuto, poster, id_mostra, id_poster, nome_poster, directory_principale);
                        nuova_form.Show();
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
            }
        }

        private void ElencoControlli1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex == 2) && (e.ColumnIndex == 4))
            {
                ElencoControlli1.Cursor = Cursors.Hand;
            }
            else
                ElencoControlli1.Cursor = Cursors.Default;
        }

        private void ElencoControlli2_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex == 2) && (e.ColumnIndex == 4))
            {
                ElencoControlli2.Cursor = Cursors.Hand;
            }
            else
                ElencoControlli2.Cursor = Cursors.Default;
        }

        private void ElencoControlli3_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex == 2) && (e.ColumnIndex == 4))
            {
                ElencoControlli3.Cursor = Cursors.Hand;
            }
            else
                ElencoControlli3.Cursor = Cursors.Default;
        }

        private void ElencoRisorse_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 4) || (e.ColumnIndex == 6) || (e.ColumnIndex == 8) || (e.ColumnIndex == 10) || (e.ColumnIndex == 12))
            {
                if (ElencoRisorse[e.ColumnIndex, e.RowIndex].Value != null)
                {
                    ElencoRisorse.Cursor = Cursors.Hand;
                }
                else
                    ElencoRisorse.Cursor = Cursors.Default;
            }
            else
                ElencoRisorse.Cursor = Cursors.Default;
        }

      
        public BenvenutoGestioneDisposizione GetBenvenuto()
        {
            return benvenuto;
        }

        private void ElencoRisorse_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Esci_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if ((benvenuto != null) && (benvenuto.GetInizio() != null))
            {
                QuestionPostering n = new QuestionPostering(benvenuto, benvenuto.GetInizio(), this, benvenuto_aut,visualizza_aut);
                this.Visible = false;
                n.Show();
            }
            else
            {
                QuestionPostering n = new QuestionPostering(benvenuto, null, this, benvenuto_aut,visualizza_aut);
                this.Visible = false;
                n.Show();
            }
            this.Cursor = Cursors.Default;
        }


        
    }
}
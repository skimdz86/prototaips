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
    public partial class FormVisualizzaElementiAuthoring : FormSchema
    {
        private int tag_per_riga;
        private int tag_per_colonna;
        //private FormScegliPosterAuthoring scelta_poster;
        //private BenvenutoAuthoring partenza;
        private int poster;
        private string nome_poster;
        private string database;
        private int cod_mostra;
        private string directory_principale;
        private ArrayList componenti;
        private bool esecuzione = false;
        private QuartzTypeLib.FilgraphManager graphManager;
        private QuartzTypeLib.IMediaControl mc = null;
        private IMediaEvent m_objMediaEvent = null;
        private IMediaEventEx m_objMediaEventEx = null;
        private IMediaPosition m_objMediaPosition = null;
        private IMediaControl m_objMediaControl = null;
        private bool paused = false;
        private int riga_pausa;
        private Bitmap play_audio;
        private Bitmap modifica;
        private Bitmap elimina;
        private Bitmap play_video;
        private Bitmap testo;
        private Bitmap preview_immagine;
        private Bitmap pausa;
        private Bitmap stop;
        private Bitmap riprendi;
        private Bitmap taggato;
        private Bitmap non_taggato;
        private NHibernateManager nh_manager;
        //private TalkingPaper.GestioneDisposizione.ComponentiDelPoster componenti_pos;
        private TalkingPaper.GestioneDisposizione.BenvenutoGestioneDisposizione benvenuto_pos;
        private string id_pannello;
        private string nome_pannello;
        private string configurazione;
        //private AuthoringInsterting inserimento;
        private GestioneDisposizione.BenvenutoGestioneDisposizione benvenuto_ges;
        private char[] alfabeto ={ 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'Z' };
        private bool esiste;
        private ElementoGriglia[,] matrice;
        private int num = 0;
        private int id_contenuto_selezionato;
        private string nome_contenuto_selezionato;
        private int num_colonne;
        private int num_righe;
        private ArrayList cont_modificati = new ArrayList();


        //occhio a queste!!!
        private int id_mosta;
        private GestioneDisposizione.PosterDellaMostra posterMostra; 
        private string provenienza;



        public FormVisualizzaElementiAuthoring(/*FormScegliPosterAuthoring scelta_poster, BenvenutoAuthoring partenza,*/ int poster, string nome_poster, int cod_mostra, string directory_principale, string database, /*TalkingPaper.GestioneDisposizione.ComponentiDelPoster componenti_pos,*/ TalkingPaper.GestioneDisposizione.BenvenutoGestioneDisposizione benvenuto_pos, string id_pannello, string nome_pannello, string configurazione, AuthoringInsterting inserimento, GestioneDisposizione.BenvenutoGestioneDisposizione benvenuto_ges, String provenienza, int id_mostra, GestioneDisposizione.PosterDellaMostra posterMostra)
        {
            InitializeComponent();
            this.id_mosta=id_mostra;
            this.posterMostra = posterMostra;
            this.provenienza = provenienza;
            Size groupSize = groupBox2.Size;
            Size el1Size = ElencoControlli1.Size;
            Size el2Size = ElencoControlli2.Size;
            Size el3Size = ElencoControlli3.Size;

            RidimensionaForm n = new RidimensionaForm(this, 1, true);
            groupBox2.Size = groupSize;
            ElencoControlli1.Size = el1Size;
            ElencoControlli2.Size = el2Size;
            ElencoControlli3.Size = el3Size;
            this.nh_manager = new NHibernateManager();
            //this.componenti_pos = componenti_pos;
            //this.inserimento = inserimento;
            this.configurazione = configurazione;
            this.benvenuto_pos = benvenuto_pos;
            //this.scelta_poster = scelta_poster;
            //this.partenza = partenza;
            this.poster = poster;
            this.cod_mostra = cod_mostra;
            this.nome_poster = nome_poster;
            this.directory_principale = directory_principale;
            this.database = database;
            this.id_pannello = id_pannello;
            this.nome_pannello = nome_pannello;
            this.benvenuto_ges = benvenuto_ges;
            //this.benvenuto_bar = benvenuto_bar;
            play_audio = new Bitmap(directory_principale + @"/Images/Icons/nota.gif");
            modifica = new Bitmap(directory_principale + @"/Images/Icons/SelezionaPannello2.gif");
            taggato = new Bitmap(directory_principale + @"/Images/Icons/virgoletta.gif");
            non_taggato = new Bitmap(directory_principale + @"/Images/Icons/non_taggato.gif");
            elimina = new Bitmap(directory_principale + @"/Images/Icons/elimina.gif");
            play_video = new Bitmap(directory_principale + @"/Images/Icons/play_video.gif");
            testo = new Bitmap(directory_principale + @"/Images/Icons/preview _testo.gif");
            preview_immagine = new Bitmap(directory_principale + @"/Images/Icons/preview_immagine.gif");
            pausa = new Bitmap(directory_principale + @"/Images/Icons/Pause.bmp");
            stop = new Bitmap(directory_principale + @"/Images/Icons/Stop.bmp");
            riprendi = new Bitmap(directory_principale + @"/Images/Icons/Play.bmp");
            this.sottotitolo.Text = this.sottotitolo.Text + " - " + nome_poster;
            Termina.Cursor = Cursors.Hand;
            button1.Cursor = Cursors.Hand;
            /*if (benvenuto_pos != null) {
                Indietro.Visible = false;
            }
            if (componenti_pos != null)
            {
                Indietro.Text = "Modifica";
           //     groupBox3.Visible = false;
           //     button2.Visible = false;
            }
            else
            {
                Indietro.Text = "Indietro";
            //    groupBox3.Visible = true;
            //    button2.Visible = true;
            }*/
            //label5.Text = "Pannello associato = " + nome_pannello;
            //label6.Text = "Configurazione = " + configurazione;
            InterrogaDB();
            LeggiRigaColonna();
            esiste = System.IO.File.Exists(directory_principale + "Griglia" + nome_pannello + id_pannello + configurazione + poster.ToString() + ".xml");
            InizializzaDataGrid2();
        }


        public FormVisualizzaElementiAuthoring(/*FormScegliPosterAuthoring scelta_poster, BenvenutoAuthoring partenza,*/ int poster, string nome_poster, int cod_mostra, string directory_principale, string database, /*TalkingPaper.GestioneDisposizione.ComponentiDelPoster componenti_pos,*/ TalkingPaper.GestioneDisposizione.BenvenutoGestioneDisposizione benvenuto_pos, string id_pannello, string nome_pannello, string configurazione, AuthoringInsterting inserimento, GestioneDisposizione.BenvenutoGestioneDisposizione benvenuto_ges)
        {
            InitializeComponent();
            this.id_mosta = 0;
            this.provenienza = null;

            RidimensionaForm n = new RidimensionaForm(this, 99, true);
            this.nh_manager = new NHibernateManager();
            //this.componenti_pos = componenti_pos;
            //this.inserimento = inserimento;
            this.configurazione = configurazione;
            this.benvenuto_pos = benvenuto_pos;
            //this.scelta_poster = scelta_poster;
            //this.partenza = partenza;
            this.poster = poster;
            this.cod_mostra = cod_mostra;
            this.nome_poster = nome_poster;
            this.directory_principale = directory_principale;
            this.database = database;
            this.id_pannello = id_pannello;
            this.nome_pannello = nome_pannello;
            this.benvenuto_ges = benvenuto_ges;
            //this.benvenuto_bar = benvenuto_bar;
            play_audio = new Bitmap(directory_principale + @"/Images/Icons/nota.gif");
            modifica = new Bitmap(directory_principale + @"/Images/Icons/SelezionaPannello2.gif");
            taggato = new Bitmap(directory_principale + @"/Images/Icons/virgoletta.gif");
            non_taggato = new Bitmap(directory_principale + @"/Images/Icons/non_taggato.gif");
            elimina = new Bitmap(directory_principale + @"/Images/Icons/elimina_cestino.gif");
            play_video = new Bitmap(directory_principale + @"/Images/Icons/play_video.gif");
            testo = new Bitmap(directory_principale + @"/Images/Icons/preview _testo.gif");
            preview_immagine = new Bitmap(directory_principale + @"/Images/Icons/preview_immagine.gif");
            pausa = new Bitmap(directory_principale + @"/Images/Icons/Pause.bmp");
            stop = new Bitmap(directory_principale + @"/Images/Icons/Stop.bmp");
            riprendi = new Bitmap(directory_principale + @"/Images/Icons/Play.bmp");
            this.sottotitolo.Text = this.sottotitolo.Text + " - " + nome_poster;
            Termina.Cursor = Cursors.Hand;
            button1.Cursor = Cursors.Hand;
            /*if (benvenuto_pos != null) {
                Indietro.Visible = false;
            }
            if (componenti_pos != null)
            {
                Indietro.Text = "Modifica";
                //     groupBox3.Visible = false;
                //     button2.Visible = false;
            }
            else
            {
                Indietro.Text = "Indietro";
                //    groupBox3.Visible = true;
                //    button2.Visible = true;
            }*/
           // label5.Text = "Pannello associato = " + nome_pannello;
           // label6.Text = "Configurazione = " + configurazione;
            InterrogaDB();
            LeggiRigaColonna();
            esiste = System.IO.File.Exists(directory_principale + "Griglia" + nome_pannello + id_pannello + configurazione + poster.ToString() + ".xml");
            InizializzaDataGrid2();
        }

        private void FormCodePoster_Load(object sender, EventArgs e)
        {
            //InterrogaDB();
        }

        #region Connessione al DB e DataGrid

    /*    private void CaricaGrigliaDaXml() { 
            try
            {
                bool esiste = esiste = System.IO.File.Exists(directory_principale + "Griglia" + nome_pannello + id_pannello + configurazione + poster.ToString() + ".xml");
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
                            
                            }
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
        */
        // connessione al DB e letture dei dati
        private void InterrogaDB()
        {
            /*using (ISession tempS = nh_manager.Session)
            using (ITransaction tempT = tempS.BeginTransaction())
            {
                try
                {
                    IQuery q = tempS.CreateQuery("FROM Poster as pt WHERE pt.IDposter=:Pos");
                    q.SetParameter("Pos", cod_poster);
                    poster_sel = (Poster)q.List()[0];
                    contenuti_sel = poster_sel.ContenutoLista;
                    if (contenuti_sel.Count == 0)
                    {
                        MessageBox.Show("Non è presente nessun elemento");
                        partenza.Enabled = true;
                        this.Close();
                    }
                    else
                    {
                        componenti = new ArrayList();
                        foreach (Contenuto m in contenuti_sel)
                        {
                            componenti.Add(m.IDcontenuto);
                            componenti.Add(m.Nome);
                            componenti.Add(m.RisorsaMultimediale);
                            componenti.Add(m.Rfidtag);
                        }
                        SetDataGrid();
                    }
                    tempT.Commit();
                }
                catch (Exception e)
                {
                    tempT.Rollback();
                    Console.WriteLine("Eccezione in Scegli Elementi");
                }
                finally
                {
                    tempS.Close();
                }
            }*/
            using (ISession tempS = nh_manager.Session)
            using (ITransaction tempT = tempS.BeginTransaction())
            {
                try
                {
                    Poster3 poster_sel = new Poster3();
                    IQuery q = tempS.CreateQuery("FROM Poster as pt WHERE pt.IDposter=:Pos");
                    q.SetParameter("Pos", poster);
                    poster_sel = (Poster3)q.List()[0];
                    tempS.Flush();
                    tempT.Commit();
                    //contenuti_sel = poster_sel.ContenutoLista;
                    bool contenuti = false;
                    foreach (Contenuto c in poster_sel.ContenutoLista)
                    {
                        if (c.Tipo.Tipo.CompareTo("Controllo") != 0)
                        {
                            contenuti = true;
                        }
                    }
                    if (poster_sel.ContenutoLista.Count == 0)
                    {
                        MessageBox.Show("Non è presente nessun contenuto");
                        //scelta_poster.Visible = true;
                        tempT.Commit();
                    }
                    else if (contenuti == false)
                    {
                        ElencoRisorse.Visible = false;
                        //ElencoTag2.Visible = false;
                        label1.Visible = true;
                        SetDataGrid();
                    }
                    else
                    {
                        SetDataGrid();
                    }

                }
                catch (Exception e)
                {
                    tempT.Rollback();
                    Console.WriteLine("Eccezione in Scegli Elementi");
                }
                finally
                {
                    tempS.Close();
                    //tempT.Commit();
                }
            }
        }

        private string LeggiCoordinatePerImmagine(string id_cont) {
            string coordinata = null;
            int tag_per_riga=0;
            int tag_per_colonna=0;
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
            try
            {
                string nome_file = directory_principale + "Griglia" + nome_pannello + id_pannello + configurazione + poster.ToString() + ".xml";
                bool esiste = esiste = System.IO.File.Exists(nome_file);
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
                            XmlReader sotto_albero=iscritto.ReadSubtree();
                            while (sotto_albero.Read())
                            {
                                if (sotto_albero.NodeType == XmlNodeType.Element)
                                {
                                    if (sotto_albero.LocalName.Equals("IDcontenuto"))
                                    {
                                        string id = sotto_albero.ReadString();
                                        if (id.CompareTo(id_cont) == 0)
                                        {
                                            coordinata = alfabeto[i - 1].ToString() + j.ToString();
                                            fine = true;
                                        }
                                    }
                                }
                            }
                            j++;
                        }
                    }
                    /*if (i > tag_per_colonna)
                    {
                        //j++;
                        //i = 1;
                        fine = true;
                    }*/
                    if (j > tag_per_riga)
                    {
                        //fine = true;
                        i++;
                        j = 1;
                    }
                    if (i > tag_per_colonna)
                    {
                        //j++;
                        //i = 1;
                        fine = true;
                    }
                }
                iscritto.Close();
                return coordinata;
            }
            //esiste = true;
            catch
            {
                //esiste = false;
                return coordinata;
            } 
        }

        // Inizializzazione della DataGrid
        private void SetDataGrid()
        {
            ElencoRisorse.ColumnCount = 13;
            num_colonne = 13;
            num_righe = 0;
            ElencoRisorse.ColumnHeadersVisible = false;
            ElencoRisorse.Columns[0].Visible = false;
            //ElencoRisorse.Columns[1].Visible = false;
            ElencoRisorse.Columns[4].Visible = false;
            ElencoRisorse.Columns[5].Visible = false;
            DataGridViewRow riga = new DataGridViewRow();
            ElencoRisorse.Rows.Add("NUM", " ", "NOME", " ", "POSIZIONA", " ", "AUDIO/VIDEO", " ", "IMMAGINE", " ", "TESTO", " ", "POSIZIONA");
            num_righe++;
            ElencoRisorse.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
            ElencoRisorse.Rows.Add();
            num_righe++;
            
            ElencoRisorse.CellClick += new DataGridViewCellEventHandler(this.ClickSullaTabella);
            ElencoRisorse.CellMouseEnter += new DataGridViewCellEventHandler(ElencoRisorse_CellMouseEnter);
            RiempiDataGrid();
        }



        // Riempimento della DataGrid
        private void RiempiDataGrid()
        {
            int riga = 2;
            int num_controllo = 1;
            DataGridViewImageCell pause = new DataGridViewImageCell();
            DataGridViewImageCell resume = new DataGridViewImageCell();
            DataGridViewImageCell stopp = new DataGridViewImageCell();
            using (ISession tempS = nh_manager.Session)
            using (ITransaction tempT = tempS.BeginTransaction())
            {
                try
                {
                    Poster3 poster_sel = new Poster3();
                    IQuery q = tempS.CreateQuery("FROM Poster as pt WHERE pt.IDposter=:Pos");
                    q.SetParameter("Pos", poster);
                    poster_sel = (Poster3)q.List()[0];
                    tempS.Flush();
                    foreach (Contenuto c in poster_sel.ContenutoLista)
                    {
                        
                        if (c.Tipo.Tipo.CompareTo("Controllo") != 0)
                        {
                            ElencoRisorse.Rows.Add(c.IDcontenuto, null, c.Nome, null, null, null, null, null, null, null, null, null, null);
                            ElencoRisorse[2, riga].Style.BackColor = Color.Red;
                            num_righe++;
                            if (c.RisorsaMultimediale != null)
                            {
                                if ((c.RisorsaMultimediale.Path.CompareTo("\\audio") == 0) || (c.RisorsaMultimediale.Path.CompareTo("/audio") == 0))
                                {
                                    DataGridViewImageCell immagine_audio = new DataGridViewImageCell();
                                    immagine_audio.Value = play_audio;
                                    immagine_audio.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoRisorse[6, riga] = immagine_audio;
                                }
                                else if ((c.RisorsaMultimediale.Path.CompareTo("\\video") == 0) || (c.RisorsaMultimediale.Path.CompareTo("/video") == 0))
                                {
                                    DataGridViewImageCell immagine_audio = new DataGridViewImageCell();
                                    immagine_audio.Value = play_video;
                                    immagine_audio.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoRisorse[6, riga] = immagine_audio;
                                }
                            }
                            if (c.AltrarisorsaLista != null)
                            {
                                foreach (Altrarisorsa a in c.AltrarisorsaLista)
                                {
                                    if ((a.Path.CompareTo("\\Images") == 0) || (a.Path.CompareTo("/Images") == 0))
                                    {
                                        DataGridViewImageCell immagine = new DataGridViewImageCell();
                                        immagine.Value = preview_immagine;
                                        immagine.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                        ElencoRisorse[8, riga] = immagine;
                                    }
                                    else if ((a.Path.CompareTo("\\Testi") == 0) || (a.Path.CompareTo("/Testi") == 0))
                                    {
                                        DataGridViewImageCell testoo = new DataGridViewImageCell();
                                        testoo.Value = testo;
                                        testoo.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                        ElencoRisorse[10, riga] = testoo;
                                    }
                                }
                            }
                            if ((c.Rfidtag != null) && (c.Rfidtag.CompareTo("0") != 0))
                            {
                                DataGridViewImageCell tagged = new DataGridViewImageCell();
                                tagged.Value = taggato;
                                tagged.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                ElencoRisorse[12, riga] = tagged;
                            }
                            else {
                                DataGridViewImageCell tagged = new DataGridViewImageCell();
                                tagged.Value = non_taggato;
                                tagged.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                ElencoRisorse[12, riga] = tagged;
                            }
                            DataGridViewImageCell modify = new DataGridViewImageCell();
                            modify.Value = modifica;
                            modify.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            ElencoRisorse[4, riga] = modify;
                            ElencoRisorse.Rows.Add();
                            num_righe++;
                            riga += 2;
                        }
                        else
                        {
                            if (num_controllo == 1)
                            {
                                ElencoControlli1.ColumnCount = 7;
                                ElencoControlli1.ColumnHeadersVisible = false;
                                ElencoControlli1.Columns[0].Visible = false;
                                ElencoControlli1.Columns[6].Visible = false;
                                ElencoControlli1.CellClick += new DataGridViewCellEventHandler(this.ClickSullaTabellaDeiControlli1); //mod
                                ElencoControlli1.CellMouseEnter += new DataGridViewCellEventHandler(ElencoControlli1_CellMouseEnter); //mod
                                ElencoControlli1.Rows.Add(c.IDcontenuto, null, c.Tipo.Descrizione, null, null, null, null);
                                ElencoControlli1.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
                                ElencoControlli1.Rows.Add();
                                ElencoControlli1.Rows.Add();
                                ElencoControlli1[6, 1].Value = "posiziona";
                                if (c.Tipo.Descrizione.CompareTo("Pausa") == 0)
                                {
                                    pause.Value = pausa;
                                    pause.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli1[2, 2] = pause;
                                }
                                else if (c.Tipo.Descrizione.CompareTo("Play") == 0)
                                {
                                    resume.Value = riprendi;
                                    resume.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli1[2, 2] = resume;
                                }
                                else if (c.Tipo.Descrizione.CompareTo("Stop") == 0)
                                {
                                    stopp.Value = stop;
                                    stopp.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli1[2, 2] = stopp;
                                }
                                if ((c.Rfidtag != null) && (c.Rfidtag.CompareTo("0") != 0))
                                {
                                    DataGridViewImageCell tagged = new DataGridViewImageCell();
                                    tagged.Value = taggato;
                                    tagged.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli1[4, 2] = tagged;
                                }
                                else {
                                    DataGridViewImageCell tagged = new DataGridViewImageCell();
                                    tagged.Value = non_taggato;
                                    tagged.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli1[4, 2] = tagged;
                                }
                                DataGridViewImageCell modify = new DataGridViewImageCell();
                                modify.Value = modifica;
                                modify.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                ElencoControlli1[6, 2] = modify;
                            }
                            else if (num_controllo == 2)
                            {
                                ElencoControlli2.ColumnCount = 7;
                                ElencoControlli2.ColumnHeadersVisible = false;
                                ElencoControlli2.Columns[0].Visible = false;
                                ElencoControlli2.Columns[6].Visible = false;
                                ElencoControlli2.CellClick += new DataGridViewCellEventHandler(this.ClickSullaTabellaDeiControlli2); 
                                ElencoControlli2.CellMouseEnter += new DataGridViewCellEventHandler(ElencoControlli2_CellMouseEnter);
                                ElencoControlli2.Rows.Add(c.IDcontenuto, null, c.Tipo.Descrizione, null, null, null, null);
                                ElencoControlli2.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
                                ElencoControlli2.Rows.Add();
                                ElencoControlli2.Rows.Add();
                                ElencoControlli2[6, 1].Value = "posiziona";
                                if (c.Tipo.Descrizione.CompareTo("Pausa") == 0)
                                {
                                    pause.Value = pausa;
                                    pause.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli2[2, 2] = pause;
                                }
                                else if (c.Tipo.Descrizione.CompareTo("Play") == 0)
                                {
                                    resume.Value = riprendi;
                                    resume.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli2[2, 2] = resume;
                                }
                                else if (c.Tipo.Descrizione.CompareTo("Stop") == 0)
                                {
                                    stopp.Value = stop;
                                    stopp.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli2[2, 2] = stopp;
                                }
                                if ((c.Rfidtag != null) && (c.Rfidtag.CompareTo("0") != 0))
                                {
                                    DataGridViewImageCell tagged = new DataGridViewImageCell();
                                    tagged.Value = taggato;
                                    tagged.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli2[4, 2] = tagged;
                                }
                                else {
                                    DataGridViewImageCell tagged = new DataGridViewImageCell();
                                    tagged.Value = non_taggato;
                                    tagged.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli2[4, 2] = tagged;
                                }
                                DataGridViewImageCell modify = new DataGridViewImageCell();
                                modify.Value = modifica;
                                modify.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                ElencoControlli2[6, 2] = modify;
                            }
                            else if (num_controllo == 3)
                            {
                                ElencoControlli3.ColumnCount = 7;
                                ElencoControlli3.ColumnHeadersVisible = false;
                                ElencoControlli3.Columns[0].Visible = false;
                                ElencoControlli3.Columns[6].Visible = false;
                                //DataGridViewRow riga = new DataGridViewRow();
                                //ElencoControlli1.Rows.Add("NUM", "  ", "NOME", "  ", "ICONA", "  ", "ELIMINA");
                                //ElencoControlli1.Rows.Add();
                                ElencoControlli3.CellClick += new DataGridViewCellEventHandler(this.ClickSullaTabellaDeiControlli3);
                                ElencoControlli3.CellMouseEnter += new DataGridViewCellEventHandler(ElencoControlli3_CellMouseEnter);
                                ElencoControlli3.Rows.Add(c.IDcontenuto, null, c.Tipo.Descrizione, null, null, null, null);
                                ElencoControlli3.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
                                ElencoControlli3.Rows.Add();
                                ElencoControlli3.Rows.Add();
                                ElencoControlli3[6, 1].Value = "posiziona";
                                if (c.Tipo.Descrizione.CompareTo("Pausa") == 0)
                                {
                                    pause.Value = pausa;
                                    pause.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli3[2, 2] = pause;
                                }
                                else if (c.Tipo.Descrizione.CompareTo("Play") == 0)
                                {
                                    resume.Value = riprendi;
                                    resume.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli3[2, 2] = resume;
                                }
                                else if (c.Tipo.Descrizione.CompareTo("Stop") == 0)
                                {
                                    stopp.Value = stop;
                                    stopp.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli3[2, 2] = stopp;
                                }
                                if ((c.Rfidtag != null) && (c.Rfidtag.CompareTo("0") != 0))
                                {
                                    DataGridViewImageCell tagged = new DataGridViewImageCell();
                                    tagged.Value = taggato;
                                    tagged.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli3[4, 2] = tagged;
                                }
                                else {
                                    DataGridViewImageCell tagged = new DataGridViewImageCell();
                                    tagged.Value = non_taggato;
                                    tagged.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli3[4, 2] = tagged;
                                }
                                DataGridViewImageCell modify = new DataGridViewImageCell();
                                modify.Value = modifica;
                                modify.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                ElencoControlli3[6, 2] = modify;
                            }
                            num_controllo++;
                        }
                    }
                    
                }
                catch (Exception e)
                {
                    tempT.Rollback();
                    Console.WriteLine("Eccezione in Scegli Elementi");
                }
                finally
                {
                    tempS.Close();
                    //tempT.Commit();
                }
            }

        }

        private void RiempiDataGrid2()
        {
       //     try
            {
                Font font = new Font("Arial", 12);

                string nome_file;
                if (esiste == true)
                {
                    nome_file = directory_principale + "Griglia" + nome_pannello + id_pannello + configurazione + poster.ToString() + ".xml";
                    Riempi(nome_file, font);
                    
                }
                else
                {

                    nome_file = directory_principale + "Griglia" + nome_pannello + id_pannello + configurazione + ".xml";
                    Riempi(nome_file,font);
                    
                    /*XmlTextReader iscritto = new XmlTextReader(nome_file);
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
                                    
                                    ElementoGriglia n = new ElementoGriglia(id_pannello, nome_pannello, configurazione, nome_poster, poster, -1, null, alfabeto[i - 1].ToString(), j, ins, false);
                                    matrice[i, j] = n;
                                    ElencoTag2[i, j].Style.BackColor = Color.Coral;
                                    //mac
                                    ElencoTag2[i, j].Style.Font = font;
                                }
                                else
                                {
                                    ElementoGriglia n = new ElementoGriglia(id_pannello, nome_pannello, configurazione, nome_poster, poster, -1, null, alfabeto[i - 1].ToString(), j, ins, false);
                                    matrice[i, j] = n;
                                    //ElencoTag[i, j].Style.BackColor = Color.Coral;
                                }
                                i++;
                            }
                        }
                        if (i > tag_per_riga)
                        {
                            j++;
                            i = 1;
                        }
                        if (j > tag_per_colonna)
                        {
                            fine = true;
                        }
                    }
                    iscritto.Close();*/
                }
                //esiste = true;
            }
          //  catch
          //  {
                //esiste = false;
          //  }
        }


        #endregion

        #region gestione eventi

        // gestore degli eventi sulla DataGrid
        private void ElencoRisorse_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex % 2 == 0 && e.ColumnIndex!=0)
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

        private void ClickSullaTabella(object sender, DataGridViewCellEventArgs e)
        {
            /*if ((ElencoRisorse[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 2))
            {
                FormVisualizzaInfoRFID nuova = new FormVisualizzaInfoRFID(this, (int)ElencoRisorse[0, e.RowIndex].Value, directoryprincipale,database);
                nuova.Show();
                this.Visible = false;
            }
            else if ((ElencoRisorse[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 4)) {
                 if ((esecuzione == true)&&(paused == false)) {
                    mc.Stop();
                    esecuzione = false;
                }
                if ((paused == true)&&(riga_pausa==e.RowIndex))
                {
                    mc.Run();
                    esecuzione = true;
                    paused = false;
                }
                else
                {
                    //graphManager = new QuartzTypeLib.FilgraphManager();
                    //mc = (QuartzTypeLib.IMediaControl)graphManager;
                    paused = false;
                    esecuzione = true;
                    using (ISession tempS = nh_manager.Session)
                    using (ITransaction tempT = tempS.BeginTransaction())
                    {
                        try
                        {
                            IQuery q = tempS.CreateQuery("FROM Risorsamultimediale as rm WHERE rm.IDrisorsa=:Ris");
                            q.SetParameter("Ris", ElencoRisorse[0, e.RowIndex].Value);
                            risorsa_sel = (Risorsamultimediale)q.List()[0];
                            if (risorsa_sel == null)
                            {
                                MessageBox.Show("Non è presente nessuna risorsa");
                                partenza.Enabled = true;
                                this.Close();
                            }
                            else
                            {
                                graphManager = new FilgraphManager();
                                graphManager.RenderFile(directoryprincipale + risorsa_sel.Path + "/" + risorsa_sel.Nome);
                                //MessageBox.Show("Partita Risorsa");
                                m_objMediaEvent = graphManager as IMediaEvent;
                                m_objMediaEventEx = graphManager as IMediaEventEx;
                                m_objMediaEventEx.SetNotifyWindow((int)this.Handle, WM_GRAPHNOTIFY, 0);
                                m_objMediaPosition = graphManager as IMediaPosition;
                                mc = graphManager as IMediaControl;
                                //this.Text = "DirectShow - [" + openFileDialog.FileName + "]";

                                mc.Run();
                                m_CurrentStatus = MediaStatus.Running;
                            }
                            tempT.Commit();
                        }
                        catch (Exception ex)
                        {
                            tempT.Rollback();
                            Console.WriteLine("Eccezione in Scegli Elementi");
                        }
                        finally
                        {
                            tempS.Close();
                        }
                    }
                }
            }
            else if ((ElencoRisorse[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 6))
            {
                if (esecuzione == false)
                {
                    MessageBox.Show("Non c'è nessun file in esecuzione");
                }
                else if (paused == false)
                {
                    mc.Pause();
                    esecuzione = true;
                    paused = true;
                    riga_pausa = e.RowIndex;
                    //MessageBox.Show("Pausa");
                }
                else if (paused == true)
                {
                    MessageBox.Show("C'è già un file in pausa");
                }


            }
            else if ((ElencoRisorse[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 8)) {
                if (esecuzione == false)
                {
                    MessageBox.Show("Non c'è nessun file in esecuzione");
                }
                else {
                    mc.Stop();
                    esecuzione = false;
                    paused = false;
                }
            
            }
            else if ((ElencoRisorse[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 10)) {
                if (esecuzione == true) {
                    mc.Stop();
                    esecuzione = false;
                }
                RFIDInsterting nuova = new RFIDInsterting(this, ElencoRisorse,e.RowIndex,e.ColumnIndex,(int)ElencoRisorse[0,e.RowIndex].Value, directoryprincipale,database);
                nuova.Show();
                this.Visible = false;
            }*/
            if ((ElencoRisorse[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 2 || e.ColumnIndex == 12))
            {
                ElencoRisorse[e.ColumnIndex, e.RowIndex].Selected = false;
                if (id_contenuto_selezionato != -1) {
                    for (int i = 0; i < num_colonne; i++)
                    {
                        
                        for (int j = 0; j < num_righe; j++)
                        {
                            if (i == 2&& j%2==0 && j!=0)
                                ElencoRisorse[i, j].Style.BackColor = Color.Red;
                            else
                                ElencoRisorse[i, j].Style.BackColor = Color.BlanchedAlmond;
                        }
                    }
                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            ElencoControlli1[i, j].Style.BackColor = Color.BlanchedAlmond;
                        }
                    }
                    for (int i = 0; i < 7; i++)                      {
                        for (int j = 0; j < 3; j++)
                        {
                            ElencoControlli2[i, j].Style.BackColor = Color.BlanchedAlmond;
                        }
                    }
                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            ElencoControlli3[i, j].Style.BackColor = Color.BlanchedAlmond;
                        }
                    }
                }
                if (id_contenuto_selezionato == (int)ElencoRisorse[0, e.RowIndex].Value && e.RowIndex!=0)
                {
                    id_contenuto_selezionato = -1;
                    nome_contenuto_selezionato = null;
                }
                else
                {
                    id_contenuto_selezionato = (int)ElencoRisorse[0, e.RowIndex].Value;
                    nome_contenuto_selezionato = (string)ElencoRisorse[2, e.RowIndex].Value;
                    for (int i = 0; i < num_colonne; i++)
                    {
                        ElencoRisorse[i, e.RowIndex].Style.BackColor = Color.DeepSkyBlue;
                        id_contenuto_selezionato = (int)ElencoRisorse[0, e.RowIndex].Value;
                        nome_contenuto_selezionato = (string)ElencoRisorse[2, e.RowIndex].Value;
                    }
                }
            }
            else if ((ElencoRisorse[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 6))
            {
                this.Cursor = Cursors.WaitCursor;
                using (ISession tempS = nh_manager.Session)
                using (ITransaction tempT = tempS.BeginTransaction())
                {
                    try
                    {
                        Contenuto con_sel;
                        IQuery q = tempS.CreateQuery("FROM Contenuto as comt WHERE comt.IDcontenuto=:Con");
                        q.SetParameter("Con", ElencoRisorse[0, e.RowIndex].Value);
                        con_sel = (Contenuto)q.List()[0];
                        tempS.Flush();
                        if (con_sel != null)
                        {
                            if ((con_sel.RisorsaMultimediale.Path.CompareTo("\\audio") == 0) || (con_sel.RisorsaMultimediale.Path.CompareTo("/audio") == 0))
                            {
                                TalkingPaper.GestioneDisposizione.PlayAudio nuovo = new TalkingPaper.GestioneDisposizione.PlayAudio(directory_principale + con_sel.RisorsaMultimediale.Path + "\\" + con_sel.RisorsaMultimediale.Nome, null, /*null, null, null,*/ this);
                                this.Enabled = false;
                                nuovo.Show();
                            }
                            else if ((con_sel.RisorsaMultimediale.Path.CompareTo("\\video") == 0) || (con_sel.RisorsaMultimediale.Path.CompareTo("/video") == 0))
                            {
                                TalkingPaper.GestioneDisposizione.PlayVideo nuovo = new TalkingPaper.GestioneDisposizione.PlayVideo(directory_principale + con_sel.RisorsaMultimediale.Path + "\\" + con_sel.RisorsaMultimediale.Nome, null, /*null, /*null, null,*/ this);
                                this.Enabled = false;
                                nuovo.Show();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        tempT.Rollback();
                        Console.WriteLine("Eccezione in Scegli Elementi");
                    }
                    finally
                    {
                        tempS.Close();
                        //tempT.Commit();
                    }
                }
                this.Cursor = Cursors.Default;
            }
            else if ((ElencoRisorse[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 8))
            {
                this.Cursor = Cursors.WaitCursor;
                using (ISession tempS = nh_manager.Session)
                using (ITransaction tempT = tempS.BeginTransaction())
                {
                    try
                    {
                        Contenuto con_sel;
                        IQuery q = tempS.CreateQuery("FROM Contenuto as comt WHERE comt.IDcontenuto=:Con");
                        q.SetParameter("Con", ElencoRisorse[0, e.RowIndex].Value);
                        con_sel = (Contenuto)q.List()[0];
                        tempS.Flush();
                        foreach (Altrarisorsa a in con_sel.AltrarisorsaLista)
                        {
                            if (a.Tipo.CompareTo("immagine") == 0)
                            {
                                string coordinate = LeggiCoordinatePerImmagine(((int)ElencoRisorse[0, e.RowIndex].Value).ToString());
                                GestioneDisposizione.StampaImmagine nuovo = new TalkingPaper.GestioneDisposizione.StampaImmagine(directory_principale + a.Path + "\\" + a.Nome,coordinate);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        tempT.Rollback();
                        Console.WriteLine("Eccezione in Scegli Elementi");
                    }
                    finally
                    {
                        tempS.Close();
                        //tempT.Commit();
                    }
                }
                this.Cursor = Cursors.Default;
            }
            else if ((ElencoRisorse[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 10))
            {
                this.Cursor = Cursors.WaitCursor;
                using (ISession tempS = nh_manager.Session)
                using (ITransaction tempT = tempS.BeginTransaction())
                {
                    try
                    {
                        Contenuto con_sel;
                        IQuery q = tempS.CreateQuery("FROM Contenuto as comt WHERE comt.IDcontenuto=:Con");
                        q.SetParameter("Con", ElencoRisorse[0, e.RowIndex].Value);
                        con_sel = (Contenuto)q.List()[0];
                        tempS.Flush();
                        foreach (Altrarisorsa a in con_sel.AltrarisorsaLista)
                        {
                            if (a.Tipo.CompareTo("testo") == 0)
                            {
                                string estensione = a.Nome.Substring(a.Nome.Length - 4);
                                GestioneDisposizione.NuovoComponente nuovoo = new GestioneDisposizione.NuovoComponente();
                                GestioneDisposizione.StampaTesto nuovo = new GestioneDisposizione.StampaTesto(directory_principale + a.Path + "\\" + a.Nome, estensione, nuovoo);
                                //visualizzato = false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        tempT.Rollback();
                        Console.WriteLine("Eccezione in Scegli Elementi");
                    }
                    finally
                    {
                        tempS.Close();
                        // tempT.Commit();
                    }
                }
                this.Cursor = Cursors.Default;
            }
            else if ((ElencoRisorse[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 4))
            {
                this.Cursor = Cursors.WaitCursor;
                /*if (ElencoRisorse[4, e.RowIndex].Value == null)
                {
                    if (inserimento != null)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        inserimento.Visible = true;
                        //this.Visible = false;
                        //this.Cursor = Cursors.Default;
                    }
                    else
                    {*/
                        AuthoringInsterting codice = new AuthoringInsterting(this, (int)ElencoRisorse[0, e.RowIndex].Value,(string) ElencoRisorse[2, e.RowIndex].Value, poster, nome_poster, cod_mostra, directory_principale, database, benvenuto_pos, id_pannello, nome_pannello, configurazione,benvenuto_ges);
                        this.Visible = false;
                        codice.Show();
                    /*}
                    //this.Visible = false;
                }
                else
                {
                    QuestionEliminaTag nuovaa = new QuestionEliminaTag(this, (int)ElencoRisorse[0, e.RowIndex].Value, scelta_poster, partenza, poster, nome_poster, cod_mostra, directory_principale, database, componenti_pos, benvenuto_pos,id_pannello,nome_pannello,configurazione);
                    //this.Visible = false;
                    nuovaa.Show();
                }*/
                this.Cursor = Cursors.Default;
                this.Visible = false;
            }
        }

        private void ClickSullaTabellaDeiControlli1(object sender, DataGridViewCellEventArgs e)
        {
            if ((ElencoControlli1[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 2 || e.ColumnIndex == 4))
            {
                /*if (ElencoControlli1[4, 2].Value == null)
                {*/
                if (id_contenuto_selezionato != -1)
                {
                    for (int i = 0; i < num_colonne; i++)
                    {
                        for (int j = 0; j < num_righe; j++)
                        {
                            ElencoRisorse[i, j].Style.BackColor = Color.BlanchedAlmond;
                        }
                    }
                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            ElencoControlli1[i, j].Style.BackColor = Color.BlanchedAlmond;
                        }
                    }
                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            ElencoControlli2[i, j].Style.BackColor = Color.BlanchedAlmond;
                        }
                    }
                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            ElencoControlli3[i, j].Style.BackColor = Color.BlanchedAlmond;
                        }
                    }
                }
                ElencoControlli1[e.ColumnIndex, e.RowIndex].Selected = false;
                    this.Cursor = Cursors.WaitCursor;
                    /*AuthoringInsterting codice = new AuthoringInsterting(this, (int)ElencoControlli1[0, 0].Value, (string)ElencoControlli1[2, 0].Value, scelta_poster, partenza, poster, nome_poster, cod_mostra, directory_principale, database, componenti_pos, benvenuto_pos, id_pannello, nome_pannello, configurazione,benvenuto_ges);
                    codice.Show();
                    this.Cursor = Cursors.Default;
                    this.Visible = false;*/
                    if (id_contenuto_selezionato == (int)ElencoControlli1[0, 0].Value)
                    {
                        id_contenuto_selezionato = -1;
                        nome_contenuto_selezionato = null;
                    }
                    else
                    {
                        id_contenuto_selezionato = (int)ElencoControlli1[0, 0].Value;
                        nome_contenuto_selezionato = (string)ElencoControlli1[2, 0].Value;
                        for (int i = 0; i < 7; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                ElencoControlli1[i, j].Style.BackColor = Color.DeepSkyBlue;
                            }
                        }
                    }
                    this.Cursor = Cursors.Default;
                /*}
                else
                {
                    this.Cursor = Cursors.WaitCursor;
                    QuestionEliminaTag nuovaa = new QuestionEliminaTag(this, (int)ElencoControlli1[0, 0].Value, scelta_poster, partenza, poster, nome_poster, cod_mostra, directory_principale, database, componenti_pos, benvenuto_pos,id_pannello,nome_pannello,configurazione);
                    //this.Visible = false;
                    nuovaa.Show();
                    this.Cursor = Cursors.Default;
                    this.Visible = false;
                }*/
            }
        }

        private void ClickSullaTabellaDeiControlli2(object sender, DataGridViewCellEventArgs e){

            if ((ElencoControlli2[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 2 || e.ColumnIndex == 4))
            {
                /*if (ElencoControlli2[4, 2].Value == null)
                {*/
                    /*this.Cursor = Cursors.WaitCursor;
                    AuthoringInsterting codice = new AuthoringInsterting(this, (int)ElencoControlli2[0, 0].Value, (string)ElencoControlli2[2, 0].Value, scelta_poster, partenza, poster, nome_poster, cod_mostra, directory_principale, database, componenti_pos, benvenuto_pos, id_pannello, nome_pannello, configurazione,benvenuto_ges);
                    codice.Show();
                    this.Cursor = Cursors.Default;
                    this.Visible = false;*/
                if (id_contenuto_selezionato != -1)
                {
                    for (int i = 0; i < num_colonne; i++)
                    {
                        for (int j = 0; j < num_righe; j++)
                        {
                            ElencoRisorse[i, j].Style.BackColor = Color.BlanchedAlmond;
                        }
                    }
                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            ElencoControlli1[i, j].Style.BackColor = Color.BlanchedAlmond;
                        }
                    }
                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            ElencoControlli2[i, j].Style.BackColor = Color.BlanchedAlmond;
                        }
                    }
                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            ElencoControlli3[i, j].Style.BackColor = Color.BlanchedAlmond;
                        }
                    }
                }
                ElencoControlli2[e.ColumnIndex, e.RowIndex].Selected = false;
                this.Cursor = Cursors.WaitCursor;
                /*AuthoringInsterting codice = new AuthoringInsterting(this, (int)ElencoControlli1[0, 0].Value, (string)ElencoControlli1[2, 0].Value, scelta_poster, partenza, poster, nome_poster, cod_mostra, directory_principale, database, componenti_pos, benvenuto_pos, id_pannello, nome_pannello, configurazione,benvenuto_ges);
                codice.Show();
                this.Cursor = Cursors.Default;
                this.Visible = false;*/
                if (id_contenuto_selezionato == (int)ElencoControlli2[0, 0].Value)
                {
                    id_contenuto_selezionato = -1;
                    nome_contenuto_selezionato = null;
                }
                else
                {
                    id_contenuto_selezionato = (int)ElencoControlli2[0, 0].Value;
                    nome_contenuto_selezionato = (string)ElencoControlli2[2, 0].Value;
                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            ElencoControlli2[i, j].Style.BackColor = Color.DeepSkyBlue;
                        }
                    }
                }
                this.Cursor = Cursors.Default;
                /*}
                else
                {
                    this.Cursor = Cursors.WaitCursor;
                    QuestionEliminaTag nuovaa = new QuestionEliminaTag(this, (int)ElencoControlli2[0, 0].Value, scelta_poster, partenza, poster, nome_poster, cod_mostra, directory_principale, database, componenti_pos, benvenuto_pos,id_pannello,nome_pannello,configurazione);
                    //this.Visible = false;
                    nuovaa.Show();
                    this.Cursor = Cursors.Default;
                    this.Visible = false;
                }*/
            }
        }

        private void ClickSullaTabellaDeiControlli3(object sender, DataGridViewCellEventArgs e)
        {
            if ((ElencoControlli3[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 2 || e.ColumnIndex == 4))
            {
                /*if (ElencoControlli3[4, 2].Value == null)
                {*/
                    /*this.Cursor = Cursors.WaitCursor;
                    AuthoringInsterting codice = new AuthoringInsterting(this, (int)ElencoControlli3[0, 0].Value, (string)ElencoControlli3[2, 0].Value, scelta_poster, partenza, poster, nome_poster, cod_mostra, directory_principale, database, componenti_pos, benvenuto_pos, id_pannello, nome_pannello, configurazione,benvenuto_ges);
                    codice.Show();
                    this.Cursor = Cursors.Default;
                    this.Visible = false;*/
                ElencoControlli3[e.ColumnIndex, e.RowIndex].Selected = false;
                if (id_contenuto_selezionato != -1)
                {
                    for (int i = 0; i < num_colonne; i++)
                    {
                        for (int j = 0; j < num_righe; j++)
                        {
                            ElencoRisorse[i, j].Style.BackColor = Color.BlanchedAlmond;
                        }
                    }
                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            ElencoControlli2[i, j].Style.BackColor = Color.BlanchedAlmond;
                        }
                    }
                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            ElencoControlli1[i, j].Style.BackColor = Color.BlanchedAlmond;
                        }
                    }
                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            ElencoControlli3[i, j].Style.BackColor = Color.BlanchedAlmond;
                        }
                    }
                }
                this.Cursor = Cursors.WaitCursor;
                /*AuthoringInsterting codice = new AuthoringInsterting(this, (int)ElencoControlli1[0, 0].Value, (string)ElencoControlli1[2, 0].Value, scelta_poster, partenza, poster, nome_poster, cod_mostra, directory_principale, database, componenti_pos, benvenuto_pos, id_pannello, nome_pannello, configurazione,benvenuto_ges);
                codice.Show();
                this.Cursor = Cursors.Default;
                this.Visible = false;*/
                if (id_contenuto_selezionato == (int)ElencoControlli3[0, 0].Value)
                {
                    id_contenuto_selezionato = -1;
                    nome_contenuto_selezionato = null;
                }
                else
                {
                    id_contenuto_selezionato = (int)ElencoControlli3[0, 0].Value;
                    nome_contenuto_selezionato = (string)ElencoControlli3[2, 0].Value;
                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            ElencoControlli3[i, j].Style.BackColor = Color.DeepSkyBlue;
                        }
                    }
                }
                this.Cursor = Cursors.Default;
                /*}
                else
                {
                    this.Cursor = Cursors.WaitCursor;
                    QuestionEliminaTag nuovaa = new QuestionEliminaTag(this, (int)ElencoControlli3[0, 0].Value, scelta_poster, partenza, poster, nome_poster, cod_mostra, directory_principale, database, componenti_pos, benvenuto_pos,id_pannello,nome_pannello,configurazione);
                    //this.Visible = false;
                    nuovaa.Show();
                    this.Cursor = Cursors.Default;
                    this.Visible = false;
                }*/
            }
        }

        private void ElencoControlli1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 2 || e.ColumnIndex == 4) && (ElencoControlli1[e.ColumnIndex, e.RowIndex].Value != null))
            {
                ElencoControlli1.Cursor = Cursors.Hand;
            }
            else
                ElencoControlli1.Cursor = Cursors.Default;
        }

        private void ElencoControlli2_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 2 || e.ColumnIndex == 4) && (ElencoControlli2[e.ColumnIndex, e.RowIndex].Value != null))
            {
                ElencoControlli2.Cursor = Cursors.Hand;
            }
            else
                ElencoControlli2.Cursor = Cursors.Default;
        }

        private void ElencoControlli3_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 2 || e.ColumnIndex == 4) && (ElencoControlli3[e.ColumnIndex, e.RowIndex].Value != null))
            {
                ElencoControlli3.Cursor = Cursors.Hand;
            }
            else
                ElencoControlli3.Cursor = Cursors.Default;
        }


        // gestore eventi nel caso in cui termina l'esecuzione del file senza premere tasti
        /*protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_GRAPHNOTIFY)
            {
                int lEventCode;
                int lParam1, lParam2;

                while (true)
                {
                    try
                    {
                        m_objMediaEventEx.GetEvent(out lEventCode,
                            out lParam1,
                            out lParam2,
                            0);

                        m_objMediaEventEx.FreeEventParams(lEventCode, lParam1, lParam2);

                        if (lEventCode == EC_COMPLETE)
                        {
                            mc.Stop();
                            m_objMediaPosition.CurrentPosition = 0;
                            //MessageBox.Show("Si è fermato");
                            esecuzione = false;
                            // m_CurrentStatus = MediaStatus.Stopped;
                            //UpdateStatusBar();
                            //UpdateToolBar();
                        }
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }
                base.WndProc(ref m);
            }

            base.WndProc(ref m);
        }*/

        private void FormVisualizzaElementiRFID_Load(object sender, EventArgs e)
        {

        }

        private void Termina_Click(object sender, EventArgs e)
        {
            /*if (esecuzione == true)
            {
                mc.Stop();
                esecuzione = false;
            }
            this.Visible = false;
            QuestionRFID2 nuova = new QuestionRFID2(partenza, this);
            nuova.Show();*/
            //this.Visible = false;
            this.Cursor = Cursors.WaitCursor;
            Salvataggio();
            //QuestionAuthoring2 nuova = new QuestionAuthoring2(partenza, this, componenti_pos, benvenuto_pos,benvenuto_ges);
            //nuova.Show();
            global.home.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }

        private void Indietro_Click(object sender, EventArgs e)
        {
            /* if (esecuzione == true)
             {
                 mc.Stop();
                 esecuzione = false;
             }
             scelta_poster.Visible = true;
             this.Close();*/
            this.Cursor = Cursors.WaitCursor;
            Salvataggio();
            /*if (componenti_pos == null)
            {
                scelta_poster.Visible = true;
                this.Cursor = Cursors.Default;
                this.Close();
            }
            else
            {*/
                //componenti_pos.Visible = true;
                this.Cursor = Cursors.Default;
                this.Close();
            //}
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            /*if ((componenti_pos != null) && (componenti_pos.GetBenvenuto() != null))
            {
                this.Cursor = Cursors.WaitCursor;
                Salvataggio();
                TalkingPaper.GestioneDisposizione.BenvenutoGestioneDisposizione nn = componenti_pos.GetBenvenuto();
                FormEsecuzioneRfidPoster n = new FormEsecuzioneRfidPoster(poster, nn.GetInizio(),directory_principale);
                //this.Close();
                n.Show();
                this.Cursor = Cursors.Default;
                this.Close();
            }
            /*else if ((partenza != null) && (partenza.getInizio() != null))
            {
                this.Cursor = Cursors.WaitCursor;
                Salvataggio();
                FormEsecuzioneRfidPoster n = new FormEsecuzioneRfidPoster(poster, partenza.getInizio(),directory_principale);
                //this.Close();
                n.Show();
                this.Cursor = Cursors.Default;
                this.Close();
            }
             
            else if ((benvenuto_pos != null) && (benvenuto_pos.GetInizio() != null))
            {
                this.Cursor = Cursors.WaitCursor;
                Salvataggio();
                FormEsecuzioneRfidPoster n = new FormEsecuzioneRfidPoster(poster, benvenuto_pos.GetInizio(),directory_principale);
                //this.Close();
                n.Show();
                this.Cursor = Cursors.Default;
                this.Close();
            }
            else*/ if ((benvenuto_ges != null) && (benvenuto_ges.GetInizio() != null))
            {
                this.Cursor = Cursors.WaitCursor;
                Salvataggio();
                FormEsecuzioneRfidPoster n = new FormEsecuzioneRfidPoster(poster,benvenuto_ges.GetInizio(),directory_principale);
                //this.Close();
                n.Show();
                this.Cursor = Cursors.Default;
                this.Close();
            }
        }

        

        #region Gestione Posizionamento

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

        private void InizializzaDataGrid2()
        {
            //int valore = 0;
            Font font = new Font("Arial", 12);
            //textBox1.Click += new EventHandler(textBox1_Click);
            ElencoTag2.CellClick += new DataGridViewCellEventHandler(ElencoTag2_CellContentClick);
            ElencoTag2.CellMouseEnter += new DataGridViewCellEventHandler(ElencoTag2_CellMouseEnter);
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
                ElencoTag2.Columns[j].Width = (int)(110*global.percentScale);
                ElencoTag2[j, 0].Value = alfabeto[j - 1];
            }
            RiempiDataGrid2();
        }

       
        private void ElencoTag2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bool gia_presente = false;
            ElencoTag2[e.ColumnIndex, e.RowIndex].Selected = false;
            string colonna = "";
            int riga = -1;
            foreach (ElementoGriglia el in matrice)
            {
                if (el != null)
                {
                    if (el.GetUtilizzato() == true)
                    {
                        if ((el.GetIdContenuto() == id_contenuto_selezionato) && (nome_contenuto_selezionato.CompareTo(el.GetNomeContenuto()) == 0))
                        {
                            gia_presente = true;
                            riga = el.GetRiga();
                            colonna = el.getColonna();
                        }
                    }
                }
            }
            if (ElencoTag2[e.ColumnIndex, e.RowIndex].Style.BackColor == Color.Coral)
            {
                this.Enabled = false;
                if (num == 0)
                {
                    num = 1;
                    if (((ElencoTag2[e.ColumnIndex, e.RowIndex].Value != null) && ((id_contenuto_selezionato == 0) || (id_contenuto_selezionato == -1))))// && (((String)ElencoTag2[e.ColumnIndex, e.RowIndex].Value).CompareTo(nome_contenuto_selezionato) == 0))
                    {
                        DialogResult n = MessageBox.Show("Vuoi eliminare questo contenuto ?", "", MessageBoxButtons.YesNo);
                        if (n == DialogResult.Yes)
                        {
                            ElencoTag2[e.ColumnIndex, e.RowIndex].Selected = false;
                            ElencoTag2[e.ColumnIndex, e.RowIndex].Value = null;
                            int id_co = (int)((ElementoGriglia)matrice[e.RowIndex,e.ColumnIndex]).GetIdContenuto();
                            cont_modificati.Add((int)((ElementoGriglia)matrice[e.RowIndex,e.ColumnIndex]).GetIdContenuto());
                            ((ElementoGriglia)matrice[e.RowIndex,e.ColumnIndex]).SetIdContenuto(-1);
                            ((ElementoGriglia)matrice[e.RowIndex,e.ColumnIndex]).SetNomeContenuto(null);
                            ((ElementoGriglia)matrice[e.RowIndex,e.ColumnIndex]).SetUtilizzato(false);
                            SalvataggioCoordinateImmagine();
                            if (id_co == (int)ElencoControlli1[0, 0].Value)
                            {
                                DataGridViewImageCell im = new DataGridViewImageCell();
                                im.Value = non_taggato;
                                im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                ElencoControlli1[4, 2] = im;
                            }
                            else if (id_co == (int)ElencoControlli2[0, 0].Value)
                            {
                                DataGridViewImageCell im = new DataGridViewImageCell();
                                im.Value = non_taggato;
                                im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                ElencoControlli2[4, 2] = im;
                            }
                            else if (id_co == (int)ElencoControlli3[0, 0].Value)
                            {
                                DataGridViewImageCell im = new DataGridViewImageCell();
                                im.Value = non_taggato;
                                im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                ElencoControlli3[4, 2] = im;
                            }
                            else
                            {
                                for (int j = 0; j < num_righe; j++)
                                {
                                    try
                                    {
                                       /* if (((int)ElencoRisorse[0, j].Value) == id_co)
                                        {
                                            ElencoRisorse[4, j].Value = null;
                                        }
                                        else*/ if (((int)ElencoRisorse[0, j].Value) == id_co)
                                        {
                                            DataGridViewImageCell im = new DataGridViewImageCell();
                                            im.Value = non_taggato;
                                            im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                            ElencoRisorse[12, j] = im;
                                        }
                                    }
                                    catch
                                    {

                                    }
                                }
                            }
                            num = 0;
                        }
                        else
                        {
                            ElencoTag2[e.ColumnIndex, e.RowIndex].Selected = false;
                        }
                    }
                    else if ((ElencoTag2[e.ColumnIndex, e.RowIndex].Value != null) && (((String)ElencoTag2[e.ColumnIndex, e.RowIndex].Value).CompareTo(nome_contenuto_selezionato) != 0)&&(id_contenuto_selezionato!=-1))
                    {
                        //ElencoTag[e.ColumnIndex, e.RowIndex].Value = nome_componente;
                        //Richiesta n = new Richiesta(this,matrice);
                        //this.Visible = false;
                        //n.Show();
                        //bool o = n.GetModifica();
                        if (gia_presente == false)
                        {
                            DialogResult n = MessageBox.Show("Sei sicuro di voler sostituire il contenuto " + ElencoTag2[e.ColumnIndex, e.RowIndex].Value.ToString() + " con il contenuto " + nome_contenuto_selezionato + "?", "", MessageBoxButtons.YesNo);
                            if (n == DialogResult.Yes)
                            {
                                ElencoTag2[e.ColumnIndex, e.RowIndex].Selected = false;
                                cont_modificati.Add((int)(((ElementoGriglia)matrice[e.RowIndex,e.ColumnIndex]).GetIdContenuto()));
                                int id_c = (((ElementoGriglia)matrice[e.RowIndex, e.ColumnIndex]).GetIdContenuto());
                                ((ElementoGriglia)matrice[e.RowIndex, e.ColumnIndex]).SetIdContenuto(id_contenuto_selezionato);
                                ((ElementoGriglia)matrice[e.RowIndex, e.ColumnIndex]).SetNomeContenuto(nome_contenuto_selezionato);
                                ((ElementoGriglia)matrice[e.RowIndex, e.ColumnIndex]).SetUtilizzato(true);
                                ElencoTag2[e.ColumnIndex, e.RowIndex].Value = nome_contenuto_selezionato;
                                SalvataggioCoordinateImmagine();
                                if (id_c == (int)ElencoControlli1[0, 0].Value) {
                                    DataGridViewImageCell im = new DataGridViewImageCell();
                                    im.Value = non_taggato;
                                    im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli1[4, 2] = im;

                                }
                                else if ((id_contenuto_selezionato == (int)ElencoControlli1[0, 0].Value)) {
                                    DataGridViewImageCell im = new DataGridViewImageCell();
                                    im.Value = taggato;
                                    im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli1[4, 2] = im;
                                }
                                if (id_c == (int)ElencoControlli2[0, 0].Value)
                                {
                                    DataGridViewImageCell im = new DataGridViewImageCell();
                                    im.Value = non_taggato;
                                    im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli2[4, 2] = im;

                                }
                                else if ((id_contenuto_selezionato == (int)ElencoControlli2[0, 0].Value))
                                {
                                    DataGridViewImageCell im = new DataGridViewImageCell();
                                    im.Value = taggato;
                                    im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli2[4, 2] = im;
                                }
                                if (id_c == (int)ElencoControlli3[0, 0].Value)
                                {
                                    DataGridViewImageCell im = new DataGridViewImageCell();
                                    im.Value = non_taggato;
                                    im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli3[4, 2] = im;
                                }
                                else if ((id_contenuto_selezionato == (int)ElencoControlli3[0, 0].Value))
                                {
                                    DataGridViewImageCell im = new DataGridViewImageCell();
                                    im.Value = taggato;
                                    im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli3[4, 2] = im;
                                }
                                    for (int j = 0; j < num_righe; j++)
                                    {
                                        try
                                        {
                                            if (((int)ElencoRisorse[0, j].Value) == id_c)
                                            {
                                                DataGridViewImageCell im = new DataGridViewImageCell();
                                                im.Value = non_taggato;
                                                im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                                ElencoRisorse[12, j] = im;
                                            }
                                            else if (((int)ElencoRisorse[0, j].Value) == id_contenuto_selezionato)
                                            {
                                                DataGridViewImageCell im = new DataGridViewImageCell();
                                                im.Value = taggato;
                                                im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                                ElencoRisorse[12, j] = im;
                                            }
                                        }
                                        catch
                                        {

                                        }
                                    }
                            }
                            else
                            {
                                ElencoTag2[e.ColumnIndex, e.RowIndex].Selected = false;
                                num = 0;
                            }
                        }
                    }
                    else
                    {
                        ElencoTag2[e.ColumnIndex, e.RowIndex].Selected = false;
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
                        if ((gia_presente == false)&&(nome_contenuto_selezionato!=null)&&(id_contenuto_selezionato!=-1))
                        {
                            ElencoTag2[e.ColumnIndex, e.RowIndex].Value = nome_contenuto_selezionato;
                            int id_co = id_contenuto_selezionato;
                            ((ElementoGriglia)matrice[e.RowIndex,e.ColumnIndex]).SetIdContenuto(id_contenuto_selezionato);
                            ((ElementoGriglia)matrice[e.RowIndex,e.ColumnIndex]).SetNomeContenuto(nome_contenuto_selezionato);
                            ((ElementoGriglia)matrice[e.RowIndex,e.ColumnIndex]).SetUtilizzato(true);
                            SalvataggioCoordinateImmagine();
                            if (id_co == (int)ElencoControlli1[0, 0].Value)
                            {
                                DataGridViewImageCell im = new DataGridViewImageCell();
                                im.Value = taggato;
                                im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                ElencoControlli1[4, 2] = im;
                            }
                            else if (id_co == (int)ElencoControlli2[0, 0].Value)
                            {
                                DataGridViewImageCell im = new DataGridViewImageCell();
                                im.Value = taggato;
                                im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                ElencoControlli2[4, 2] = im;
                            }
                            else if (id_co == (int)ElencoControlli3[0, 0].Value)
                            {
                                DataGridViewImageCell im = new DataGridViewImageCell();
                                im.Value = taggato;
                                im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                ElencoControlli3[4, 2] = im;
                            }
                            else
                            {
                                for (int j = 0; j < num_righe; j++)
                                {
                                    try
                                    {
                                       /* if (((int)ElencoRisorse[0, j].Value) == id_co)
                                        {
                                            ElencoRisorse[4, j].Value = null;
                                        }
                                        else*/ if (((int)ElencoRisorse[0, j].Value) == id_contenuto_selezionato)
                                        {
                                            DataGridViewImageCell im = new DataGridViewImageCell();
                                            im.Value = taggato;
                                            im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                            ElencoRisorse[12, j] = im;
                                        }
                                    }
                                    catch
                                    {

                                    }
                                }
                            }
                            num = 0;
                        }
                        else if ((nome_contenuto_selezionato != null)&&(id_contenuto_selezionato!=-1))
                        {
                            DialogResult n = MessageBox.Show("Il contenuto è già inserito in " + colonna.ToString() + riga.ToString()+", vuoi spostarlo in qui?", "", MessageBoxButtons.YesNo);
                            if (n == DialogResult.Yes)
                            {
                                ElencoTag2[e.ColumnIndex, e.RowIndex].Selected = false;
                                cont_modificati.Add((int)(((ElementoGriglia)matrice[e.RowIndex,e.ColumnIndex]).GetIdContenuto()));
                                int id_c = (((ElementoGriglia)matrice[e.RowIndex, e.ColumnIndex]).GetIdContenuto());
                                ((ElementoGriglia)matrice[e.RowIndex, e.ColumnIndex]).SetIdContenuto(id_contenuto_selezionato);
                                ((ElementoGriglia)matrice[e.RowIndex, e.ColumnIndex]).SetNomeContenuto(nome_contenuto_selezionato);
                                ((ElementoGriglia)matrice[e.RowIndex, e.ColumnIndex]).SetUtilizzato(true);
                                ElencoTag2[e.ColumnIndex, e.RowIndex].Value = nome_contenuto_selezionato;
                                ElencoTag2[e.ColumnIndex, e.RowIndex].Selected = false;
                                //ElencoTag2[e.ColumnIndex, e.RowIndex].Value = null;
                                //int id_co = (int)((ElementoGriglia)matrice[e.ColumnIndex, e.RowIndex]).GetIdContenuto();
                                int colo = -1;
                                for (int k = 0; k < alfabeto.Length; k++) {
                                    if (((((char)alfabeto[k]).ToString()).CompareTo(colonna)) == 0) {
                                        colo = k+1;
                                    }
                                }
                                cont_modificati.Add((int)((ElementoGriglia)matrice[riga,colo]).GetIdContenuto());
                                ((ElementoGriglia)matrice[riga,colo]).SetIdContenuto(-1);
                                ((ElementoGriglia)matrice[riga,colo]).SetNomeContenuto(null);
                                ((ElementoGriglia)matrice[riga,colo]).SetUtilizzato(false);
                                ElencoTag2[colo, riga].Value = null;
                                SalvataggioCoordinateImmagine();
                                if (id_c == (int)ElencoControlli1[0, 0].Value) {
                                    DataGridViewImageCell im = new DataGridViewImageCell();
                                    im.Value = non_taggato;
                                    im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli1[4, 2] = im;
                                }
                                else if ((int)ElencoControlli1[0, 0].Value == id_contenuto_selezionato) {
                                    DataGridViewImageCell im = new DataGridViewImageCell();
                                    im.Value = taggato;
                                    im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli1[4, 2] = im;
                                }
                                if (id_c == (int)ElencoControlli2[0, 0].Value)
                                {
                                    DataGridViewImageCell im = new DataGridViewImageCell();
                                    im.Value = non_taggato;
                                    im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli2[4, 2] = im;
                                }
                                else if ((int)ElencoControlli2[0, 0].Value == id_contenuto_selezionato)
                                {
                                    DataGridViewImageCell im = new DataGridViewImageCell();
                                    im.Value = taggato;
                                    im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli2[4, 2] = im;
                                }
                                if (id_c == (int)ElencoControlli3[0, 0].Value)
                                {
                                    DataGridViewImageCell im = new DataGridViewImageCell();
                                    im.Value = non_taggato;
                                    im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli3[4, 2] = im;
                                }
                                else if ((int)ElencoControlli3[0, 0].Value == id_contenuto_selezionato)
                                {
                                    DataGridViewImageCell im = new DataGridViewImageCell();
                                    im.Value = taggato;
                                    im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli3[4, 2] = im;
                                }
                                for (int j = 0; j < num_righe; j++)
                                {
                                    try
                                    {
                                        if (((int)ElencoRisorse[0, j].Value) == id_c)
                                        {
                                            DataGridViewImageCell im = new DataGridViewImageCell();
                                            im.Value = non_taggato;
                                            im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                            ElencoRisorse[12, j] = im;
                                        }
                                        else if (((int)ElencoRisorse[0, j].Value) == id_contenuto_selezionato)
                                        {
                                            DataGridViewImageCell im = new DataGridViewImageCell();
                                            im.Value = taggato;
                                            im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                            ElencoRisorse[12, j] = im;
                                        }
                                    }
                                    catch
                                    {

                                    }
                                }
                                num = 0;
                            }
                            else
                            {
                                ElencoTag2[e.ColumnIndex, e.RowIndex].Selected = false;
                                num = 0;
                            }
                            //MessageBox.Show("Il contenuto è già inserito in " + colonna.ToString() + riga.ToString()+", vuoi spostarlo in qui?");
                        }
                    }
                    this.Enabled = true;
                }
                else
                {
                    num = 0;
                    this.Enabled = true;
                }
                for (int i = 0; i < num_colonne; i++)
                {
                    for (int j = 0; j < num_righe; j++)
                    {
                        ElencoRisorse[i, j].Style.BackColor = Color.BlanchedAlmond;
                    }
                }
                for (int i = 0; i < 7; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        ElencoControlli1[i, j].Style.BackColor = Color.BlanchedAlmond;
                    }
                }
                for (int i = 0; i < 7; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        ElencoControlli2[i, j].Style.BackColor = Color.BlanchedAlmond;
                    }
                }
                for (int i = 0; i < 7; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        ElencoControlli3[i, j].Style.BackColor = Color.BlanchedAlmond;
                    }
                }
                id_contenuto_selezionato = -1;
                nome_contenuto_selezionato = null;
            }
        }

        private void ElencoTag2_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (ElencoTag2[e.ColumnIndex, e.RowIndex].Style.BackColor == Color.Coral)
            {
                ElencoTag2.Cursor = Cursors.Hand;
            }
            else
                ElencoTag2.Cursor = Cursors.Default;
        }

        private void Salvataggio() {
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
            //this.Cursor = Cursors.WaitCursor;
            //FormVisualizzaElementiAuthoring n = new FormVisualizzaElementiAuthoring(scelta_poster, partenza, poster, nome_poster, cod_mostra, directory_principale, database, componenti_pos, benvenuto_pos, id_pannello, nome_pannello, configurazione, this, benvenuto_ges);
            //n.Show();
            //this.Visible = false;
            //this.Close();
            //elenco_elementi.Close();
            //this.Cursor = Cursors.Default;

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


        #endregion

        private void SalvataggioCoordinateImmagine() {

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
                        wr.WriteStartElement(el.getColonna()+el.GetRiga().ToString());
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

        private void controlButton1_Click(object sender, EventArgs e)
        {
            Salvataggio();
            this.Cursor = Cursors.WaitCursor;
            //this.Visible = false;
            TalkingPaper.GestioneDisposizione.NuovoComponente nuovo = new TalkingPaper.GestioneDisposizione.NuovoComponente(benvenuto_ges, posterMostra, null, nome_poster, this.id_mosta, poster, false, -1, "", directory_principale, provenienza,  this, id_pannello, nome_pannello, configurazione, tag_per_riga, tag_per_colonna);
            nuovo.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }

        /*private void button3_Click(object sender, EventArgs e)
        {
            Salvataggio();
            this.Cursor = Cursors.WaitCursor;
            TalkingPaper.GestioneDisposizione.PosterDaStoria nuovo = new TalkingPaper.GestioneDisposizione.PosterDaStoria(directory_principale, benvenuto_ges, true, poster, provenienza, this, null, id_pannello, nome_pannello, configurazione);
            nuovo.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }*/

        /*private void Menu_Click(object sender, EventArgs e)
        {
            QuestionCambiaGriglia richiesta = new QuestionCambiaGriglia(partenza, global.home);
            richiesta.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }*/

        private void Menu_Click_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Salvataggio();
            global.home.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }

        private void FormVisualizzaElementiAuthoring_Load(object sender, EventArgs e)
        {
            eliminaComp.setAlignment(true);
            cambiaGriglia.setAlignment(true);

            //TalkingPaper.RidimensionaForm.ReScaleTab(ElencoControlli1, global.percentScale);
            //TalkingPaper.RidimensionaForm.ReScaleTab(ElencoControlli2, global.percentScale);
            //TalkingPaper.RidimensionaForm.ReScaleTab(ElencoControlli3, global.percentScale);
            TalkingPaper.RidimensionaForm.ReScaleTab(ElencoTag2, global.percentScale);
            TalkingPaper.RidimensionaForm.ReScaleTab(ElencoRisorse, global.percentScale);
            
        }

        /*private void cambiaGriglia_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Salvataggio();
            QCambiaGriglia n = new QCambiaGriglia(this);
            n.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }*/

        private void Riempi(String nome_file, Font font)
        {
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
                        string id = (String)iscritto.GetAttribute("ID");
                        bool trov = iscritto.ReadToDescendant("IDcontenuto");
                        if (trov == false)
                        {
                            if (id.CompareTo("Non Usato") != 0)
                            { //usato
                                ElementoGriglia n = new ElementoGriglia(id_pannello, nome_pannello, configurazione, nome_poster, poster, -1, null, alfabeto[j - 1].ToString(), i, id, false);
                                matrice[i, j] = n;
                                ElencoTag2[j, i].Style.BackColor = Color.Coral;
                                //mac
                                ElencoTag2[j, i].Style.Font = font;

                            }
                            else
                            { //non usato
                                ElementoGriglia n = new ElementoGriglia(id_pannello, nome_pannello, configurazione, nome_poster, poster, -1, null, alfabeto[j - 1].ToString(), i, id, false);
                                matrice[i, j] = n;
                            }
                        }
                        else if (trov == true)
                        {
                            string id_cont = iscritto.ReadString();
                            int id1_cont = Int32.Parse(id_cont);
                            iscritto.ReadToFollowing("NomeContenuto");
                            string nome_cont = iscritto.ReadString();
                            ElementoGriglia n = new ElementoGriglia(id_pannello, nome_pannello, configurazione, nome_poster, poster, id1_cont, nome_cont, alfabeto[j - 1].ToString(), i, id, true);
                            matrice[i, j] = n;
                            ElencoTag2[j, i].Style.BackColor = Color.Coral;
                            ElencoTag2[j, i].Value = nome_cont;
                            //mac
                            ElencoTag2[j, i].Style.Font = font;
                        }
                        j++;
                    }
                }
                if (j > tag_per_riga)
                {
                    //fine = true;
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

        }
}
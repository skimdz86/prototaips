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

namespace TalkingPaper.RfidCode
{
    public partial class FormVisualizzaElementiRFID : FormSchema
    {
        /*private FormScegliPosterRFID scelta_poster;
        private BenvenutoRFID partenza;
        private Risorsamultimediale risorsa_sel;
        private int cod_poster;
        private string nome_poster;
        private string database;
        private int cod_mostra;
        private string directoryprincipale;
        private Bitmap image_sound;
        private Bitmap image_stop_sound;
        private Bitmap image_code;
        private Bitmap immagine_modifica_code;
        private Bitmap immagine_pausa_sound;
        private ArrayList componenti;
        private bool esecuzione = false;
        private QuartzTypeLib.FilgraphManager graphManager;
        private QuartzTypeLib.IMediaControl mc;
        private TalkingPaper.NHibernateManager nh_manager;
        private IList contenuti_sel;
        private Poster poster_sel;
        private bool paused=false;
        private int riga_pausa;

        private FilgraphManager m_objFilterGraph = null;
        private IBasicAudio m_objBasicAudio = null;
        private IVideoWindow m_objVideoWindow = null;
        private IMediaEvent m_objMediaEvent = null;
        private IMediaEventEx m_objMediaEventEx = null;
        private IMediaPosition m_objMediaPosition = null;
        private IMediaControl m_objMediaControl = null;

        private const int WM_APP = 0x8000;
        private const int WM_GRAPHNOTIFY = WM_APP + 1;
        private const int EC_COMPLETE = 0x01;
        private const int WS_CHILD = 0x40000000;
        private const int WS_CLIPCHILDREN = 0x2000000;

        enum MediaStatus { None, Stopped, Paused, Running };
        private MediaStatus m_CurrentStatus = MediaStatus.None;*/

        private FormScegliPosterRFID scelta_poster;
        private BenvenutoRFID partenza;
        private int poster;
        private string nome_poster;
        private string database;
        private int cod_mostra;
        private string directory_principale;
        /*private Bitmap image_sound;
        private Bitmap image_stop_sound;
        private Bitmap immagine_pausa_sound;
        private Bitmap image_code;
        private Bitmap immagine_modifica_code;*/
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
        private NHibernateManager nh_manager;
        private TalkingPaper.Postering.ComponentiDelPoster componenti_pos;
        private TalkingPaper.Postering.BenvenutoPostering benvenuto_pos;
        private TalkingPaper.BarCode.BenvenutoBarCode benvenuto_bar;


        public FormVisualizzaElementiRFID(FormScegliPosterRFID scelta_poster,BenvenutoRFID partenza, int poster, string nome_poster, int cod_mostra, string directory_principale, string database,TalkingPaper.Postering.ComponentiDelPoster componenti_pos,TalkingPaper.Postering.BenvenutoPostering benvenuto_pos,TalkingPaper.BarCode.BenvenutoBarCode benvenuto_bar)
        {
            /*InitializeComponent();
            this.scelta_poster = scelta_poster;
            this.partenza = partenza;
            this.cod_poster = poster;
            this.cod_mostra = cod_mostra;
            this.nome_poster = nome_poster;
            this.directoryprincipale = directory_principale;
            this.database = database;
            this.nh_manager = new NHibernateManager();
            play_audio = new Bitmap(directory_principale + @"/Images/Icons/nota2.gif");
            modifica = new Bitmap(directory_principale + @"/Images/Icons/SelezionaPannello2.gif");
            taggato = new Bitmap(directory_principale + @"/Images/Icons/virgoletta.gif");
            elimina = new Bitmap(directory_principale + @"/Images/Icons/elimina_cestino.gif");
            play_video = new Bitmap(directory_principale + @"/Images/Icons/play_video.gif");
            testo = new Bitmap(directory_principale + @"/Images/Icons/preview _testo.gif");
            preview_immagine = new Bitmap(directory_principale + @"/Images/Icons/preview_immagine.gif");
            pausa = new Bitmap(directory_principale + @"/Images/Icons/Pause.bmp");
            stop = new Bitmap(directory_principale + @"/Images/Icons/Stop.bmp");
            riprendi = new Bitmap(directory_principale + @"/Images/Icons/Play.bmp");
            Fase.Text = Fase.Text + " - " + nome_poster;
            InterrogaDB();*/
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 99, true);
            this.nh_manager = new NHibernateManager();
            this.componenti_pos = componenti_pos;
            this.benvenuto_pos = benvenuto_pos;
            this.scelta_poster = scelta_poster;
            this.partenza = partenza;
            this.poster = poster;
            this.cod_mostra = cod_mostra;
            this.nome_poster = nome_poster;
            this.directory_principale = directory_principale;
            this.database = database;
            this.benvenuto_bar = benvenuto_bar;
            play_audio = new Bitmap(directory_principale + @"/Images/Icons/nota2.gif");
            modifica = new Bitmap(directory_principale + @"/Images/Icons/SelezionaPannello2.gif");
            taggato = new Bitmap(directory_principale + @"/Images/Icons/virgoletta.gif");
            elimina = new Bitmap(directory_principale + @"/Images/Icons/elimina_cestino.gif");
            play_video = new Bitmap(directory_principale + @"/Images/Icons/play_video.gif");
            testo = new Bitmap(directory_principale + @"/Images/Icons/preview _testo.gif");
            preview_immagine = new Bitmap(directory_principale + @"/Images/Icons/preview_immagine.gif");
            pausa = new Bitmap(directory_principale + @"/Images/Icons/Pause.bmp");
            stop = new Bitmap(directory_principale + @"/Images/Icons/Stop.bmp");
            riprendi = new Bitmap(directory_principale + @"/Images/Icons/Play.bmp");
            Fase.Text = Fase.Text + " - " + nome_poster;
            Termina.Cursor = Cursors.Hand;
            Indietro.Cursor = Cursors.Hand;
            button1.Cursor = Cursors.Hand;
            button2.Cursor = Cursors.Hand;
            /*if (benvenuto_pos != null) {
                Indietro.Visible = false;
            }*/
            if (componenti_pos != null)
            {
                Indietro.Text = "Modifica Poster";
                button2.Visible = false;
            }
            else {
                Indietro.Text = "Indietro";
                button2.Visible = true;
            }
            InterrogaDB();
        }

        private void FormCodePoster_Load(object sender, EventArgs e)
        {
            //InterrogaDB();
        }

         #region Connessione al DB e DataGrid

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
                    Poster poster_sel = new Poster();
                    IQuery q = tempS.CreateQuery("FROM Poster as pt WHERE pt.IDposter=:Pos");
                    q.SetParameter("Pos", poster);
                    poster_sel = (Poster)q.List()[0];
                    tempS.Flush();
                    tempT.Commit();
                    //contenuti_sel = poster_sel.ContenutoLista;
                    bool contenuti = false;
                    foreach (Contenuto c in poster_sel.ContenutoLista) {
                        if (c.Tipo.Tipo.CompareTo("Controllo") != 0) {
                            contenuti = true;
                        }
                    }
                    if (poster_sel.ContenutoLista.Count == 0) {
                        MessageBox.Show("Non è presente nessun contenuto");
                        scelta_poster.Visible = true;
                        tempT.Commit();
                    }
                    else if (contenuti == false)
                    {
                        ElencoRisorse.Visible = false;
                        label1.Visible = true;
                        SetDataGrid();
                    }
                    else {
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

        // Inizializzazione della DataGrid
        private void SetDataGrid()
        {
            ElencoRisorse.ColumnCount = 13;
            ElencoRisorse.ColumnHeadersVisible = false;
            ElencoRisorse.Columns[0].Visible = false;
            DataGridViewRow riga = new DataGridViewRow();
            ElencoRisorse.Rows.Add("NUM", " ", "NOME", " ", "TAGGED", " ", "AUDIO/VIDEO", " ", "IMMAGINE", " ", "TESTO", " ", "AGGIUNGI/ELIMINA TAG");
            ElencoRisorse.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
            ElencoRisorse.Rows.Add();
            ElencoRisorse.CellClick += new DataGridViewCellEventHandler(this.ClickSullaTabella);
            ElencoRisorse.CellMouseEnter += new DataGridViewCellEventHandler(ElencoRisorse_CellMouseEnter);
            RiempiDataGrid();
        }



        // Riempimento della DataGrid
        private void RiempiDataGrid()
        {
            /*int riga = 2;
            for (int i = 0; i < componenti.Count; i = i + 4)
            {
                DataGridViewImageCell immagine_suono = new DataGridViewImageCell();
                immagine_suono.Value = image_sound;
                DataGridViewImageCell immagine_pausa = new DataGridViewImageCell();
                immagine_pausa.Value = immagine_pausa_sound;
                DataGridViewImageCell immagine_stop_suono = new DataGridViewImageCell();
                immagine_stop_suono.Value = image_stop_sound;
                DataGridViewImageCell immagine_codice = new DataGridViewImageCell();
                if ((((String)componenti[i + 3]).CompareTo("0")) == 0)
                {
                    immagine_codice.Value = image_code;
                }
                else {
                    immagine_codice.Value = immagine_modifica_code;
                }
                ElencoRisorse.Rows.Add((int)componenti[i], null, (String)componenti[i + 1], null, null, null, null,null,null,null,null);
                ElencoRisorse[4, riga] = immagine_suono;
                ElencoRisorse[6, riga] = immagine_pausa;
                ElencoRisorse[8, riga] = immagine_stop_suono;
                ElencoRisorse[10, riga] = immagine_codice;
                ElencoRisorse.Rows.Add();
                riga += 2;
            }*/
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
                    Poster poster_sel = new Poster();
                    IQuery q = tempS.CreateQuery("FROM Poster as pt WHERE pt.IDposter=:Pos");
                    q.SetParameter("Pos", poster);
                    poster_sel = (Poster)q.List()[0];
                    tempS.Flush();
                    foreach (Contenuto c in poster_sel.ContenutoLista) {
                        if (c.Tipo.Tipo.CompareTo("Controllo") != 0)
                        {
                            ElencoRisorse.Rows.Add(c.IDcontenuto, null, c.Nome, null, null, null, null, null, null, null, null, null, null);
                            if (c.RisorsaMultimediale != null)
                            {
                                if ((c.RisorsaMultimediale.Path.CompareTo("\\audio") == 0) || (c.RisorsaMultimediale.Path.CompareTo("/audio")==0))
                                {
                                    DataGridViewImageCell immagine_audio = new DataGridViewImageCell();
                                    immagine_audio.Value = play_audio;
                                    immagine_audio.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoRisorse[6, riga] = immagine_audio;
                                }
                                else if ((c.RisorsaMultimediale.Path.CompareTo("\\video") == 0) || (c.RisorsaMultimediale.Path.CompareTo("/video")==0))
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
                                ElencoRisorse[4, riga] = tagged;
                            }
                            DataGridViewImageCell modify = new DataGridViewImageCell();
                            modify.Value = modifica;
                            modify.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            ElencoRisorse[12, riga] = modify;
                            ElencoRisorse.Rows.Add();
                            riga += 2;
                        }
                        else
                        {
                            if (num_controllo == 1)
                            {
                                ElencoControlli1.ColumnCount = 7;
                                ElencoControlli1.ColumnHeadersVisible = false;
                                ElencoControlli1.Columns[0].Visible = false;
                                //DataGridViewRow riga = new DataGridViewRow();
                                //ElencoControlli1.Rows.Add("NUM", "  ", "NOME", "  ", "ICONA", "  ", "ELIMINA");
                                //ElencoControlli1.Rows.Add();
                                ElencoControlli1.CellClick += new DataGridViewCellEventHandler(this.ClickSullaTabellaDeiControlli1);
                                ElencoControlli1.CellMouseEnter += new DataGridViewCellEventHandler(ElencoControlli1_CellMouseEnter);
                                ElencoControlli1.Rows.Add(c.IDcontenuto, null, c.Tipo.Descrizione, null, null, null, null);
                                ElencoControlli1.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
                                ElencoControlli1.Rows.Add();
                                ElencoControlli1.Rows.Add();
                                ElencoControlli1[6, 1].Value = "modifica tag";
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
                                //DataGridViewRow riga = new DataGridViewRow();
                                //ElencoControlli1.Rows.Add("NUM", "  ", "NOME", "  ", "ICONA", "  ", "ELIMINA");
                                //ElencoControlli1.Rows.Add();
                                ElencoControlli2.CellClick += new DataGridViewCellEventHandler(this.ClickSullaTabellaDeiControlli2);
                                ElencoControlli2.CellMouseEnter += new DataGridViewCellEventHandler(ElencoControlli2_CellMouseEnter);
                                ElencoControlli2.Rows.Add(c.IDcontenuto, null, c.Tipo.Descrizione, null, null, null, null);
                                ElencoControlli2.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
                                ElencoControlli2.Rows.Add();
                                ElencoControlli2.Rows.Add();
                                ElencoControlli2[6, 1].Value = "modifica tag";
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
                                //DataGridViewRow riga = new DataGridViewRow();
                                //ElencoControlli1.Rows.Add("NUM", "  ", "NOME", "  ", "ICONA", "  ", "ELIMINA");
                                //ElencoControlli1.Rows.Add();
                                ElencoControlli3.CellClick += new DataGridViewCellEventHandler(this.ClickSullaTabellaDeiControlli3);
                                ElencoControlli3.CellMouseEnter += new DataGridViewCellEventHandler(ElencoControlli3_CellMouseEnter);
                                ElencoControlli3.Rows.Add(c.IDcontenuto, null, c.Tipo.Descrizione, null, null, null, null);
                                ElencoControlli3.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
                                ElencoControlli3.Rows.Add();
                                ElencoControlli3.Rows.Add();
                                ElencoControlli3[6, 1].Value = "modifica tag";
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
        #endregion

       #region gestione eventi

        // gestore degli eventi sulla DataGrid
        private void ElencoRisorse_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 6) || (e.ColumnIndex == 8) || (e.ColumnIndex == 10) || (e.ColumnIndex == 12))
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
            if ((ElencoRisorse[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 6)) {
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
                            if (con_sel != null) {
                                if ((con_sel.RisorsaMultimediale.Path.CompareTo("\\audio") == 0) || (con_sel.RisorsaMultimediale.Path.CompareTo("/audio") == 0)) {
                                    TalkingPaper.Postering.PlayAudio nuovo = new TalkingPaper.Postering.PlayAudio(directory_principale + con_sel.RisorsaMultimediale.Path + "\\" + con_sel.RisorsaMultimediale.Nome, null, null, null, null, this);
                                    this.Enabled = false;
                                    nuovo.Show();
                                }
                                else if ((con_sel.RisorsaMultimediale.Path.CompareTo("\\video") == 0) || (con_sel.RisorsaMultimediale.Path.CompareTo("/video") == 0)) {
                                    TalkingPaper.Postering.PlayVideo nuovo = new TalkingPaper.Postering.PlayVideo(directory_principale + con_sel.RisorsaMultimediale.Path + "\\" + con_sel.RisorsaMultimediale.Nome, null, null, null, null, this);
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
                else if ((ElencoRisorse[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 8)) {
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
                            foreach (Altrarisorsa a in con_sel.AltrarisorsaLista) {
                                if (a.Tipo.CompareTo("immagine") == 0) {
                                    Postering.StampaImmagine nuovo = new TalkingPaper.Postering.StampaImmagine(directory_principale + a.Path + "\\" + a.Nome);
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
                else if ((ElencoRisorse[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 10)) {
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
                                    Postering.NuovoComponente nuovoo = new TalkingPaper.Postering.NuovoComponente();
                                    Postering.StampaTesto nuovo = new TalkingPaper.Postering.StampaTesto(directory_principale + a.Path + "\\" + a.Nome, estensione, nuovoo);
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
                else if ((ElencoRisorse[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 12)) {
                    this.Cursor = Cursors.WaitCursor;
                    if (ElencoRisorse[4, e.RowIndex].Value == null)
                    {
                        RFIDInsterting codice = new RFIDInsterting(this, (int)ElencoRisorse[0, e.RowIndex].Value, scelta_poster, partenza, poster, nome_poster, cod_mostra, directory_principale, database,componenti_pos,benvenuto_pos,benvenuto_bar);
                        codice.Show();
                        //this.Visible = false;
                    }
                    else
                    {
                        QuestionEliminaTag nuovaa = new QuestionEliminaTag(this,(int)ElencoRisorse[0, e.RowIndex].Value,scelta_poster,partenza,poster,nome_poster,cod_mostra,directory_principale,database,componenti_pos,benvenuto_pos,benvenuto_bar);
                        //this.Visible = false;
                        nuovaa.Show();
                    }
                    this.Cursor = Cursors.Default;
                    this.Visible = false;
                }
        }

        private void ClickSullaTabellaDeiControlli1(object sender, DataGridViewCellEventArgs e)
        {
            if ((ElencoControlli1[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 6))
            {
                if (ElencoControlli1[4, 2].Value == null)
                {
                    this.Cursor = Cursors.WaitCursor;
                    RFIDInsterting codice = new RFIDInsterting(this, (int)ElencoControlli1[0, 0].Value, scelta_poster, partenza, poster, nome_poster, cod_mostra, directory_principale, database,componenti_pos,benvenuto_pos,benvenuto_bar);
                    codice.Show();
                    this.Cursor = Cursors.Default;
                    this.Visible = false;
                }
                else
                {
                    this.Cursor = Cursors.WaitCursor;
                    QuestionEliminaTag nuovaa = new QuestionEliminaTag(this, (int)ElencoControlli1[0, 0].Value, scelta_poster, partenza, poster, nome_poster, cod_mostra, directory_principale, database,componenti_pos,benvenuto_pos,benvenuto_bar);
                    //this.Visible = false;
                    nuovaa.Show();
                    this.Cursor = Cursors.Default;
                    this.Visible = false;
                }
            }
        }

        private void ClickSullaTabellaDeiControlli2(object sender, DataGridViewCellEventArgs e)
        {
            if ((ElencoControlli2[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 6))
            {
                if (ElencoControlli2[4, 2].Value == null)
                {
                    this.Cursor = Cursors.WaitCursor;
                    RFIDInsterting codice = new RFIDInsterting(this, (int)ElencoControlli2[0, 0].Value, scelta_poster, partenza, poster, nome_poster, cod_mostra, directory_principale, database,componenti_pos,benvenuto_pos,benvenuto_bar);
                    codice.Show();
                    this.Cursor = Cursors.Default;
                    this.Visible = false;
                }
                else
                {
                    this.Cursor = Cursors.WaitCursor;
                    QuestionEliminaTag nuovaa = new QuestionEliminaTag(this, (int)ElencoControlli2[0, 0].Value, scelta_poster, partenza, poster, nome_poster, cod_mostra, directory_principale, database,componenti_pos,benvenuto_pos,benvenuto_bar);
                    //this.Visible = false;
                    nuovaa.Show();
                    this.Cursor = Cursors.Default;
                    this.Visible = false;
                }
            }
        }

        private void ClickSullaTabellaDeiControlli3(object sender, DataGridViewCellEventArgs e)
        {
            if ((ElencoControlli3[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 6))
            {
                if (ElencoControlli3[4, 2].Value == null)
                {
                    this.Cursor = Cursors.WaitCursor;
                    RFIDInsterting codice = new RFIDInsterting(this, (int)ElencoControlli3[0,0].Value, scelta_poster, partenza, poster, nome_poster, cod_mostra, directory_principale, database,componenti_pos,benvenuto_pos,benvenuto_bar);
                    codice.Show();
                    this.Cursor = Cursors.Default;
                    this.Visible = false;
                }
                else
                {
                    this.Cursor = Cursors.WaitCursor;
                    QuestionEliminaTag nuovaa = new QuestionEliminaTag(this, (int)ElencoControlli3[0,0].Value, scelta_poster, partenza, poster, nome_poster, cod_mostra, directory_principale, database,componenti_pos,benvenuto_pos,benvenuto_bar);
                    //this.Visible = false;
                    nuovaa.Show();
                    this.Cursor = Cursors.Default;
                    this.Visible = false;
                }
            }
        }

        private void ElencoControlli1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 6) && (ElencoControlli1[e.ColumnIndex, e.RowIndex].Value != null))
            {
                ElencoControlli1.Cursor = Cursors.Hand;
            }
            else
                ElencoControlli1.Cursor = Cursors.Default;
        }

        private void ElencoControlli2_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 6) && (ElencoControlli2[e.ColumnIndex, e.RowIndex].Value != null))
            {
                ElencoControlli2.Cursor = Cursors.Hand;
            }
            else
                ElencoControlli2.Cursor = Cursors.Default;
        }

        private void ElencoControlli3_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 6) && (ElencoControlli3[e.ColumnIndex, e.RowIndex].Value != null))
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
            QuestionRFID2 nuova = new QuestionRFID2(partenza, this,componenti_pos,benvenuto_pos,benvenuto_bar);
            nuova.Show();
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
            if (componenti_pos == null)
            {
                scelta_poster.Visible = true;
                this.Cursor = Cursors.Default;
                this.Close();
            }
            else {
                componenti_pos.Visible = true;
                this.Cursor = Cursors.Default;
                this.Close();
            }
        }

       #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            if ((componenti_pos != null)&&(componenti_pos.GetBenvenuto()!=null))
            {
                this.Cursor = Cursors.WaitCursor;
                TalkingPaper.Postering.BenvenutoPostering nn = componenti_pos.GetBenvenuto();
                FormEsecuzioneRfidPoster n = new FormEsecuzioneRfidPoster(poster, nn.GetInizio(),directory_principale);
                //this.Close();
                n.Show();
                this.Cursor = Cursors.Default;
                this.Close();
            }
            else if ((partenza != null)&&(partenza.getInizio()!=null)) {
                this.Cursor = Cursors.WaitCursor;
                FormEsecuzioneRfidPoster n = new FormEsecuzioneRfidPoster(poster, partenza.getInizio(),directory_principale);
                //this.Close();
                n.Show();
                this.Cursor = Cursors.Default;
                this.Close();
            }
            else if ((benvenuto_pos != null)&&(benvenuto_pos.GetInizio()!=null)) {
                this.Cursor = Cursors.WaitCursor;
                FormEsecuzioneRfidPoster n = new FormEsecuzioneRfidPoster(poster, benvenuto_pos.GetInizio(),directory_principale);
                //this.Close();
                n.Show();
                this.Cursor = Cursors.Default;
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (componenti_pos != null) {
                componenti_pos.Close();
            }
            TalkingPaper.Postering.ComponentiDelPoster n = new TalkingPaper.Postering.ComponentiDelPoster(benvenuto_pos,null, cod_mostra, poster, nome_poster, directory_principale,"rfid",null,partenza,null,this);
            //this.Close();
            n.Show();
            this.Cursor = Cursors.Default;
            this.Close();
        }

        
    }
}
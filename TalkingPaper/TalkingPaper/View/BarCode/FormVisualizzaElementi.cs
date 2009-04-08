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

namespace TalkingPaper.BarCode
{
    public partial class FormVisualizzaElementi : FormSchema
    {
        private FormScegliPoster scelta_poster;
        private BenvenutoBarCode partenza;
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
        //private QuartzTypeLib.FilgraphManager graphManager;
        private QuartzTypeLib.IMediaControl mc=null;
        /*private IMediaEvent m_objMediaEvent = null;
        private IMediaEventEx m_objMediaEventEx = null;
        private IMediaPosition m_objMediaPosition = null;
        private IMediaControl m_objMediaControl = null;
        private bool paused = false;
        private int riga_pausa;*/
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
        private ArrayList controlli11;
        private ArrayList componenti_non_controlli;
        private TalkingPaper.Postering.ComponentiDelPoster componenti_pos;
        private TalkingPaper.Postering.BenvenutoPostering benvenuto_pos;
        private TalkingPaper.RfidCode.BenvenutoRFID benvenuto_rfid;

        /*private const int WM_APP = 0x8000;
        private const int WM_GRAPHNOTIFY = WM_APP + 1;
        private const int EC_COMPLETE = 0x01;
        private const int WS_CHILD = 0x40000000;
        private const int WS_CLIPCHILDREN = 0x2000000;

        enum MediaStatus { None, Stopped, Paused, Running };
        private MediaStatus m_CurrentStatus = MediaStatus.None;*/


        public FormVisualizzaElementi(FormScegliPoster scelta_poster, BenvenutoBarCode partenza, int poster, string nome_poster, int cod_mostra, string directory_principale, string database, TalkingPaper.Postering.ComponentiDelPoster componenti_pos, TalkingPaper.Postering.BenvenutoPostering benvenuto_pos,TalkingPaper.RfidCode.BenvenutoRFID benvenuto_rfid)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 99, true);
            //this.visualizza_poster = visualizza_poster;
            this.scelta_poster = scelta_poster;
            this.partenza = partenza;
            this.benvenuto_pos = benvenuto_pos;
            this.poster = poster;
            this.cod_mostra = cod_mostra;
            this.nome_poster = nome_poster;
            this.directory_principale = directory_principale;
            this.database = database;
            this.componenti_pos = componenti_pos;
            this.benvenuto_rfid = benvenuto_rfid;
            /*image_sound = new Bitmap(directoryprincipale + @"/Images/Icons/nota.gif");
            image_stop_sound = new Bitmap(directoryprincipale + @"/Images/Icons/stop.gif");
            image_code = new Bitmap(directoryprincipale + @"/Images/Icons/coding.gif");
            immagine_modifica_code = new Bitmap(directoryprincipale + @"/Images/Icons/SelezionaPannello.gif");
            immagine_pausa_sound = new Bitmap(directoryprincipale + @"/Images/Icons/nota.gif");*/
            play_audio = new Bitmap(directory_principale + @"/Images/Icons/nota.gif");
            modifica = new Bitmap(directory_principale + @"/Images/Icons/SelezionaPannello2.gif");
            taggato = new Bitmap(directory_principale + @"/Images/Icons/virgoletta.gif");
            elimina = new Bitmap(directory_principale + @"/Images/Icons/elimina_.gif");
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
            /*if (componenti_pos != null)
            {
                Indietro.Text = "Modifica Poster";
            }
            else
            {
                Indietro.Text = "Indietro";
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

        private void ElencoPoster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

         #region Connessione al DB e DataGrid

        // connessione al DB e letture dei dati
        private void InterrogaDB()
        {
            controlli11 = new ArrayList();
            componenti_non_controlli= new ArrayList();
            MySqlConnection connection13;
            connection13 = new MySqlConnection("server=localhost; username=root; password=root; database=" + database);
            connection13.Open();
            MySqlCommand myC13 = new MySqlCommand("SELECT IDtipologia, Descrizione, Tipo FROM tipologia WHERE Tipo=?Tipo");
            myC13.Connection = connection13;
            myC13.Parameters.Add("?Tipo", MySqlDbType.String, 50).Value = "Controllo";
            MySqlDataReader dr12 = myC13.ExecuteReader();
            while (dr12.Read()) {
                controlli11.Add((int)dr12.GetInt32(0));
                controlli11.Add((String)dr12.GetString(1));
                controlli11.Add((String)dr12.GetString(2));
            }
            connection13.Close();
            dr12.Close();
            MySqlConnection connection;
            connection = new MySqlConnection("server=localhost; username=root; password=root; database="+database);
            connection.Open();
            MySqlCommand myC = new MySqlCommand("SELECT IDcontenuto, Nome, RisorsaMultimediale, Barcode, Tipo FROM contenuto WHERE Poster=?Poster");
            myC.Connection = connection;
            myC.Parameters.Add("?Poster", MySqlDbType.Int32, 50).Value = poster;
            MySqlDataReader dr2 = myC.ExecuteReader();
            if (dr2.HasRows == true)
            {
                componenti = new ArrayList();
                while (dr2.Read())
                {
                    componenti.Add((int)dr2.GetInt32(0));
                    componenti.Add((String)dr2.GetString(1));
                    try
                    {
                        componenti.Add((int)dr2.GetInt32(2));
                    }
                    catch (Exception e){
                        componenti.Add((int)-1);
                    }
                    //componenti.Add((int)dr2.GetInt32(2));
                    componenti.Add((String)dr2.GetString(3));
                    componenti.Add((int)dr2.GetInt32(4));
                }
                //bool solo_controlli=true;
                bool trovato = false;
                for (int i = 0; i < componenti.Count; i=i+5) {
                    for (int j = 0; j < controlli11.Count;j=j+3){
                        if (((int)componenti[i + 4])==(int)controlli11[j])
                        {
                            //solo_controlli = false;
                            trovato = true;
                        }
                    }
                    if (trovato == false) {
                        componenti_non_controlli.Add((int)componenti[i]);
                        componenti_non_controlli.Add((String)componenti[i+1]);
                        componenti_non_controlli.Add((int)componenti[i+2]);
                        componenti_non_controlli.Add((String)componenti[i+3]);
                        componenti_non_controlli.Add((int)componenti[i+4]);
                    }
                    trovato = false;
                }
                if (componenti_non_controlli.Count==0)
                {
                    ElencoRisorse.Visible = false;
                    label1.Visible = true;
                    SetDataGrid();
                }
                else
                {
                    SetDataGrid();
                }
            }
            else
            {
                MessageBox.Show("Non è presente nessun contenuto");
                scelta_poster.Visible = true;
                connection.Close();
                dr2.Close();
                this.Close();
            }
            connection.Close();
            dr2.Close();
        }

        // Inizializzazione della DataGrid
        private void SetDataGrid()
        {
            ElencoRisorse.ColumnCount = 13;
            ElencoRisorse.ColumnHeadersVisible = false;
            ElencoRisorse.Columns[0].Visible = false;
            DataGridViewRow riga = new DataGridViewRow();
            ElencoRisorse.Rows.Add("NUM", " ", "NOME", " ","TAGGED"," ", "AUDIO/VIDEO", " ", "IMMAGINE", " ", "TESTO", " ", "AGGIUNGI/ELIMINA TAG");
            ElencoRisorse.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
            ElencoRisorse.Rows.Add();
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
            for (int i = 0; i < componenti.Count; i = i + 5)
            {
                MySqlConnection connection4;
                connection4 = new MySqlConnection("server=localhost; username=root; password=root; database=" + database);
                connection4.Open();
                MySqlCommand myC5 = new MySqlCommand("SELECT Descrizione,Tipo FROM tipologia WHERE IDtipologia=?Tip");
                myC5.Connection = connection4;
                myC5.Parameters.Add("?Tip", MySqlDbType.Int32, 50).Value = (int)componenti[i + 4];
                MySqlDataReader dr5 = myC5.ExecuteReader();
                dr5.Read();
                string descrizione = (String)dr5.GetString(0);
                string tipo = (String)dr5.GetString(1);
                if (tipo.CompareTo("Controllo")!=0)
                {
                    ElencoRisorse.Rows.Add((int)componenti[i], null, (String)componenti[i + 1], null, null, null, null, null, null, null, null, null, null);
                    MySqlConnection connection;
                    connection = new MySqlConnection("server=localhost; username=root; password=root; database=" + database);
                    connection.Open();
                    MySqlCommand myC = new MySqlCommand("SELECT Path FROM risorsamultimediale WHERE IDrisorsa=?Ris");
                    myC.Connection = connection;
                    myC.Parameters.Add("?Ris", MySqlDbType.Int32, 50).Value = (int)componenti[i + 2];
                    MySqlDataReader dr2 = myC.ExecuteReader();
                    dr2.Read();
                    string path = "";
                    try
                    {
                        path = (String)dr2.GetString(0);
                    }
                    catch (Exception exce) {
                        path = "";
                    }
                    connection.Close();
                    dr2.Close();
                    //dr2.Dispose();
                    //DataGridViewImageCell immagine_audio = new DataGridViewImageCell();
                    if ((path.CompareTo("\\audio") == 0) || (path.CompareTo("/audio") == 0))
                    {
                        DataGridViewImageCell immagine_audio = new DataGridViewImageCell();
                        immagine_audio.Value = play_audio;
                        immagine_audio.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        ElencoRisorse[6, riga] = immagine_audio;
                    }
                    else if ((path.CompareTo("\\video") == 0) || (path.CompareTo("/video") == 0))
                    {
                        DataGridViewImageCell immagine_audio = new DataGridViewImageCell();
                        immagine_audio.Value = play_video;
                        immagine_audio.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        ElencoRisorse[6, riga] = immagine_audio;
                    }
                    //immagine_audio.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    //ElencoRisorse[6, riga] = immagine_audio;
                    ArrayList altre = new ArrayList();
                    MySqlConnection connection2;
                    connection2 = new MySqlConnection("server=localhost; username=root; password=root; database=" + database);
                    connection2.Open();
                    MySqlCommand myC2 = new MySqlCommand("SELECT IDaltra FROM altra_contenuto WHERE IDcontenuto=?Con");
                    myC2.Connection = connection2;
                    myC2.Parameters.Add("?Con", MySqlDbType.Int32, 50).Value = (int)componenti[i];
                    MySqlDataReader dr3 = myC2.ExecuteReader();
                    while (dr3.Read())
                    {
                        altre.Add((int)dr3.GetInt32(0));
                    }
                    connection2.Close();
                    dr3.Close();
                    for (int j = 0; j < altre.Count; j++)
                    {
                        MySqlConnection connection3;
                        connection3 = new MySqlConnection("server=localhost; username=root; password=root; database=" + database);
                        connection3.Open();
                        MySqlCommand myC3 = new MySqlCommand("SELECT Path FROM altrarisorsa WHERE IDaltra=?Altra");
                        myC3.Connection = connection3;
                        myC3.Parameters.Add("?Altra", MySqlDbType.Int32, 50).Value = (int)altre[j];
                        MySqlDataReader dr4 = myC3.ExecuteReader();
                        dr4.Read();
                        string path2 = (String)dr4.GetString(0);
                        if ((path2.CompareTo("\\Images") == 0) || (path2.CompareTo("/Images") == 0))
                        {
                            DataGridViewImageCell immagine = new DataGridViewImageCell();
                            immagine.Value = preview_immagine;
                            immagine.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            ElencoRisorse[8, riga] = immagine;
                        }
                        else
                        {
                            DataGridViewImageCell testoo = new DataGridViewImageCell();
                            testoo.Value = testo;
                            testoo.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            ElencoRisorse[10, riga] = testoo;
                        }
                    }
                    if ((((String)componenti[i + 3]).CompareTo("0")) != 0)
                    {
                        DataGridViewImageCell tagged = new DataGridViewImageCell();
                        tagged.Value = taggato;
                        tagged.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        ElencoRisorse[4, riga] = tagged;
                        /*DataGridViewImageCell modify = new DataGridViewImageCell();
                        modify.Value = modifica;
                        ElencoRisorse[12, riga] = modify;*/
                    }
                    DataGridViewImageCell modify = new DataGridViewImageCell();
                    modify.Value = modifica;
                    modify.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    ElencoRisorse[12, riga] = modify;

                    //string path = (String)dr3.GetString(0);
                    /*DataGridViewImageCell immagine_suono = new DataGridViewImageCell();
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
                    else
                    {
                        immagine_codice.Value = immagine_modifica_code;
                    }*/
                    //ElencoRisorse.Rows.Add((int)componenti[i], null, (String)componenti[i + 1], null, null, null, null, null, null, null, null);
                    /*ElencoRisorse[4, riga] = immagine_suono;
                    ElencoRisorse[6, riga] = immagine_pausa;
                    ElencoRisorse[8, riga] = immagine_stop_suono;
                    ElencoRisorse[10, riga] = immagine_codice;*/
                    ElencoRisorse.Rows.Add();
                    riga += 2;
                }
                else { 
                    //Gestione dei componenti di controllo
                    /*MySqlConnection connection;
                    connection = new MySqlConnection("server=localhost; username=root; password=root; database=" + database);
                    connection.Open();
                    MySqlCommand myC = new MySqlCommand("SELECT Descrizione,Tipo FROM tipologia WHERE IDtipologia=?Tip");
                    myC.Connection = connection;
                    myC.Parameters.Add("?Tip", MySqlDbType.Int32, 50).Value = (int)componenti[i + 2];
                    MySqlDataReader dr2 = myC.ExecuteReader();*/
                    if (num_controllo == 1) {
                        ElencoControlli1.ColumnCount = 7;
                        ElencoControlli1.ColumnHeadersVisible = false;
                        ElencoControlli1.Columns[0].Visible = false;
                        //DataGridViewRow riga = new DataGridViewRow();
                        //ElencoControlli1.Rows.Add("NUM", "  ", "NOME", "  ", "ICONA", "  ", "ELIMINA");
                        //ElencoControlli1.Rows.Add();
                        ElencoControlli1.CellClick += new DataGridViewCellEventHandler(this.ClickSullaTabellaDeiControlli1);
                        ElencoControlli1.CellMouseEnter += new DataGridViewCellEventHandler(ElencoControlli1_CellMouseEnter);
                        ElencoControlli1.Rows.Add((int)componenti[i], null, descrizione, null, null,null,null);
                        ElencoControlli1.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
                        ElencoControlli1.Rows.Add();
                        ElencoControlli1.Rows.Add();
                        ElencoControlli1[6, 1].Value = "modifica tag";
                        if (descrizione.CompareTo("Pausa") == 0) {
                            pause.Value = pausa;
                            pause.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            ElencoControlli1[2, 2] = pause;
                        }
                        else if (descrizione.CompareTo("Play") == 0) {
                            resume.Value = riprendi;
                            resume.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            ElencoControlli1[2, 2] = resume;
                        }
                        else if (descrizione.CompareTo("Stop") == 0) {
                            stopp.Value = stop;
                            stopp.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            ElencoControlli1[2, 2] = stopp;
                        }
                        if (((String)componenti[i + 3]).CompareTo("0") != 0) {
                            DataGridViewImageCell tagged = new DataGridViewImageCell();
                            tagged.Value = taggato;
                            tagged.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            ElencoControlli1[4, 2] = tagged;
                        }
                        /*if ((((String)componenti[i + 3]).CompareTo("0")) != 0)
                        {
                            DataGridViewImageCell tagged = new DataGridViewImageCell();
                            tagged.Value = taggato;
                            tagged.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            ElencoRisorse[4, riga] = tagged;
                            /*DataGridViewImageCell modify = new DataGridViewImageCell();
                            modify.Value = modifica;
                            ElencoRisorse[12, riga] = modify;
                        }*/
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
                        ElencoControlli2.Rows.Add((int)componenti[i], null, descrizione, null, null, null, null);
                        ElencoControlli2.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
                        ElencoControlli2.Rows.Add();
                        ElencoControlli2.Rows.Add();
                        ElencoControlli2[6, 1].Value = "modifica tag";
                        if (descrizione.CompareTo("Pausa") == 0)
                        {
                            pause.Value = pausa;
                            pause.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            ElencoControlli2[2, 2] = pause;
                        }
                        else if (descrizione.CompareTo("Play") == 0)
                        {
                            resume.Value = riprendi;
                            resume.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            ElencoControlli2[2, 2] = resume;
                        }
                        else if (descrizione.CompareTo("Stop") == 0)
                        {
                            stopp.Value = stop;
                            stopp.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            ElencoControlli2[2, 2] = stopp;
                        }
                        if (((String)componenti[i + 3]).CompareTo("0") != 0)
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
                        ElencoControlli3.Rows.Add((int)componenti[i], null, descrizione, null, null, null, null);
                        ElencoControlli3.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
                        ElencoControlli3.Rows.Add();
                        ElencoControlli3.Rows.Add();
                        ElencoControlli3[6, 1].Value = "modifica tag";
                        if (descrizione.CompareTo("Pausa") == 0)
                        {
                            pause.Value = pausa;
                            pause.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            ElencoControlli3[2, 2] = pause;
                        }
                        else if (descrizione.CompareTo("Play") == 0)
                        {
                            resume.Value = riprendi;
                            resume.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            ElencoControlli3[2, 2] = resume;
                        }
                        else if (descrizione.CompareTo("Stop") == 0)
                        {
                            stopp.Value = stop;
                            stopp.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            ElencoControlli3[2, 2] = stopp;
                        }
                        if (((String)componenti[i + 3]).CompareTo("0") != 0)
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
        #endregion

       #region gestione eventi

        // gestore degli eventi sulla DataGrid
        private void ElencoRisorse_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((ElencoRisorse[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 6))
            {
                ElencoRisorse.Cursor = Cursors.Hand;
            }
            else if ((ElencoRisorse[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 8))
            {
                ElencoRisorse.Cursor = Cursors.Hand;
            }
            else if ((ElencoRisorse[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 10))
            {
                ElencoRisorse.Cursor = Cursors.Hand;
            }
            else if ((ElencoRisorse[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 12))
            {
                ElencoRisorse.Cursor = Cursors.Hand;
            }
            else
                ElencoRisorse.Cursor = Cursors.Default;
        }

        private void ClickSullaTabella(object sender, DataGridViewCellEventArgs e)
        {
            if ((ElencoRisorse[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 6)) {
                this.Cursor = Cursors.WaitCursor;
                //play_audio/video
                MySqlConnection connection2;
                connection2 = new MySqlConnection("server=localhost; username=root; password=root; database=" + database);
                connection2.Open();
                MySqlCommand myC2 = new MySqlCommand("SELECT RisorsaMultimediale FROM contenuto WHERE IDcontenuto=?Con");
                myC2.Connection = connection2;
                myC2.Parameters.Add("?Con", MySqlDbType.Int32, 50).Value = (int)(ElencoRisorse[0,e.RowIndex].Value);
                MySqlDataReader dr3 = myC2.ExecuteReader();
                dr3.Read();
                int risorsa = (int)dr3.GetInt32(0);
                connection2.Close();
                dr3.Close();
                MySqlConnection connection3;
                connection3 = new MySqlConnection("server=localhost; username=root; password=root; database=" + database);
                connection3.Open();
                MySqlCommand myC3 = new MySqlCommand("SELECT Nome,Path FROM risorsamultimediale WHERE IDrisorsa=?Ris");
                myC3.Connection = connection3;
                myC3.Parameters.Add("?Ris", MySqlDbType.Int32, 50).Value = risorsa;
                MySqlDataReader dr4 = myC3.ExecuteReader();
                dr4.Read();
                string nome = (String)dr4.GetString(0);
                string path = (String)dr4.GetString(1);
                if ((path.CompareTo("\\audio") == 0) || (path.CompareTo("/audio") == 0))
                {
                    TalkingPaper.Postering.PlayAudio nuovo = new TalkingPaper.Postering.PlayAudio(directory_principale + path + "\\" + nome, null, null, this,null,null);
                    this.Enabled = false;
                    nuovo.Show();
                }
                else
                {
                    TalkingPaper.Postering.PlayVideo nuovo = new TalkingPaper.Postering.PlayVideo(directory_principale + path + "\\" + nome, null, null, this,null,null);
                    this.Enabled = false;
                    nuovo.Show();
                }
                //TalkingPaper.Postering.PlayAudio nuovo = new TalkingPaper.Postering.PlayAudio(directory_principale+path+"\\"+nome, null, null, this);
                //this.Enabled = false;
                //nuovo.Show();
                this.Cursor = Cursors.Default;
            }
            else if ((ElencoRisorse[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 8)) { 
                //immagine
                this.Cursor = Cursors.WaitCursor;
                MySqlConnection connection2;
                connection2 = new MySqlConnection("server=localhost; username=root; password=root; database=" + database);
                connection2.Open();
                MySqlCommand myC2 = new MySqlCommand("SELECT IDaltra FROM altra_contenuto WHERE IDcontenuto=?Con");
                myC2.Connection = connection2;
                myC2.Parameters.Add("?Con", MySqlDbType.Int32, 50).Value = (int)(ElencoRisorse[0, e.RowIndex].Value);
                MySqlDataReader dr3 = myC2.ExecuteReader();
                ArrayList risorse = new ArrayList();
                while (dr3.Read())
                {
                    risorse.Add((int)dr3.GetInt32(0));
                }
                connection2.Close();
                dr3.Close();
                bool visualizzato = false;
                for (int i = 0; i < risorse.Count; i++)
                {
                    MySqlConnection connection3;
                    connection3 = new MySqlConnection("server=localhost; username=root; password=root; database=" + database);
                    connection3.Open();
                    MySqlCommand myC3 = new MySqlCommand("SELECT Nome,Path,Tipo FROM altrarisorsa WHERE IDaltra=?Ris");
                    myC3.Connection = connection3;
                    myC3.Parameters.Add("?Ris", MySqlDbType.Int32, 50).Value = risorse[i];
                    MySqlDataReader dr4 = myC3.ExecuteReader();
                    dr4.Read();
                    //bool visualizzato = false;
                    string nome = (String)dr4.GetString(0);
                    string path = (String)dr4.GetString(1);
                    string tipo = (String)dr4.GetString(2);
                    if ((tipo.CompareTo("immagine") == 0)&&(visualizzato==false)) {
                        Postering.StampaImmagine nuovo = new TalkingPaper.Postering.StampaImmagine(directory_principale + path + "\\" + nome);
                        visualizzato = false;
                    }
                }
                this.Cursor = Cursors.Default;
            }
            else if ((ElencoRisorse[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 10)) { 
                //testo
                this.Cursor = Cursors.WaitCursor;
                MySqlConnection connection2;
                connection2 = new MySqlConnection("server=localhost; username=root; password=root; database=" + database);
                connection2.Open();
                MySqlCommand myC2 = new MySqlCommand("SELECT IDaltra FROM altra_contenuto WHERE IDcontenuto=?Con");
                myC2.Connection = connection2;
                myC2.Parameters.Add("?Con", MySqlDbType.Int32, 50).Value = (int)(ElencoRisorse[0, e.RowIndex].Value);
                MySqlDataReader dr3 = myC2.ExecuteReader();
                ArrayList risorse = new ArrayList();
                while (dr3.Read())
                {
                    risorse.Add((int)dr3.GetInt32(0));
                }
                connection2.Close();
                dr3.Close();
                bool visualizzato = false;
                for (int i = 0; i < risorse.Count; i++)
                {
                    MySqlConnection connection3;
                    connection3 = new MySqlConnection("server=localhost; username=root; password=root; database=" + database);
                    connection3.Open();
                    MySqlCommand myC3 = new MySqlCommand("SELECT Nome,Path,Tipo FROM altrarisorsa WHERE IDaltra=?Ris");
                    myC3.Connection = connection3;
                    myC3.Parameters.Add("?Ris", MySqlDbType.Int32, 50).Value = risorse[i];
                    MySqlDataReader dr4 = myC3.ExecuteReader();
                    dr4.Read();
                    //bool visualizzato = false;
                    string nome = (String)dr4.GetString(0);
                    string path = (String)dr4.GetString(1);
                    string tipo = (String)dr4.GetString(2);
                    string estensione= nome.Substring(nome.Length - 4, 4);
                    if ((tipo.CompareTo("testo") == 0) && (visualizzato == false))
                    {
                        Postering.NuovoComponente nuovoo = new TalkingPaper.Postering.NuovoComponente();
                        Postering.StampaTesto nuovo = new TalkingPaper.Postering.StampaTesto(directory_principale + path + "\\" + nome, estensione, nuovoo);
                        visualizzato = false;
                    }
                }
                this.Cursor = Cursors.Default;
            }
            else if ((ElencoRisorse[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 12)) { 
                //aggiungi/modifica tag --> la colonna 4 è quella tagged
                this.Cursor = Cursors.WaitCursor;
                if (ElencoRisorse[4, e.RowIndex].Value == null)
                {
                    CodeInsterting codice = new CodeInsterting(this, (int)ElencoRisorse[0,e.RowIndex].Value,scelta_poster,partenza,poster,nome_poster,cod_mostra,directory_principale,database,componenti_pos,benvenuto_pos,benvenuto_rfid);
                    codice.Show();
                    this.Visible = false;
                }
                else {
                    QuestionEliminaTag nuovaa = new QuestionEliminaTag(this, (int)ElencoRisorse[0, e.RowIndex].Value,scelta_poster,partenza,poster,nome_poster,cod_mostra,directory_principale,database,componenti_pos,benvenuto_pos,benvenuto_rfid);
                    this.Visible = false;
                    nuovaa.Show();
                }
                this.Cursor = Cursors.Default;
            }
           // "NUM", " ", "NOME", " ","TAGGED"," ", "AUDIO/VIDEO", " ", "IMMAGINE", " ", "TESTO", " ", "AGGIUNGI/ELIMINA TAG"
            /*if ((ElencoRisorse[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 2))
            {
                FormVisualizzaInfo nuova = new FormVisualizzaInfo(this, (int)ElencoRisorse[0, e.RowIndex].Value, directory_principale,database);
                nuova.Show();
                this.Visible = false;
            }
            else if ((ElencoRisorse[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 4)) {
                if ((esecuzione == true)&&(paused == false)) {
                    mc.Stop();
                    esecuzione = false;
                }
                if ((paused == true) && (riga_pausa == e.RowIndex))
                {
                    mc.Run();
                    esecuzione = true;
                    paused = false;
                }
                else { 
                    //graphManager = new QuartzTypeLib.FilgraphManager();
                    //mc = (QuartzTypeLib.IMediaControl)graphManager;
                    paused = false;
                    esecuzione = true;
                    MySqlConnection connection;
                    connection = new MySqlConnection("server=localhost; username=root; password=root; database="+database);
                    connection.Open();
                    MySqlCommand myC = new MySqlCommand("SELECT Nome,Path FROM risorsamultimediale WHERE IDrisorsa=?IDrisorsa");
                    myC.Connection = connection;
                    myC.Parameters.Add("?IDrisorsa", MySqlDbType.Int32, 50).Value = ElencoRisorse[0,e.RowIndex].Value;
                    MySqlDataReader dr2 = myC.ExecuteReader();
                    dr2.Read();

                    graphManager = new FilgraphManager();
                    graphManager.RenderFile(directory_principale+dr2.GetString(1)+"/"+dr2.GetString(0));
                    m_objMediaEvent = graphManager as IMediaEvent;
                    m_objMediaEventEx = graphManager as IMediaEventEx;
                    m_objMediaEventEx.SetNotifyWindow((int)this.Handle, WM_GRAPHNOTIFY, 0);
                    m_objMediaPosition = graphManager as IMediaPosition;
                    mc = graphManager as IMediaControl;
                    //this.Text = "DirectShow - [" + openFileDialog.FileName + "]";


                    mc.Run();
                    m_CurrentStatus = MediaStatus.Running;
                }
            
             }
            else if ((ElencoRisorse[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 6))
            {
                if (esecuzione == false)
                {
                    MessageBox.Show("Non c'è nessun file in esecuzione");
                }
                else if(paused == false)
                {
                    mc.Pause();
                    esecuzione = true;
                    paused = true;
                    riga_pausa = e.RowIndex;
                    //MessageBox.Show("Pausa");
                }
                else if (paused == true) {
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
                if ((esecuzione == true)) {
                    mc.Stop();
                    esecuzione = false;
                }
                CodeInsterting nuova = new CodeInsterting(this, ElencoRisorse,e.RowIndex,e.ColumnIndex,(int)ElencoRisorse[0,e.RowIndex].Value, directory_principale,database);
                nuova.Show();
                this.Visible = false;
            }*/
        }

        private void ClickSullaTabellaDeiControlli1(object sender, DataGridViewCellEventArgs e) 
        {
            if ((ElencoControlli1[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 6)) {
                if (ElencoControlli1[4, 2].Value == null)
                {
                    this.Cursor = Cursors.WaitCursor;
                    CodeInsterting codice = new CodeInsterting(this, (int)ElencoControlli1[0,0].Value,scelta_poster,partenza,poster,nome_poster,cod_mostra,directory_principale,database,componenti_pos,benvenuto_pos,benvenuto_rfid);
                    codice.Show();
                    this.Cursor = Cursors.Default;
                    this.Visible = false;
                }
                else
                {
                    this.Cursor = Cursors.WaitCursor;
                    QuestionEliminaTag nuovaa = new QuestionEliminaTag(this, (int)ElencoControlli1[0,0].Value, scelta_poster, partenza, poster, nome_poster, cod_mostra, directory_principale, database,componenti_pos,benvenuto_pos,benvenuto_rfid);
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
                    CodeInsterting codice = new CodeInsterting(this, (int)ElencoControlli2[0, 0].Value, scelta_poster, partenza, poster, nome_poster, cod_mostra, directory_principale, database,componenti_pos,benvenuto_pos,benvenuto_rfid);
                    codice.Show();
                    this.Cursor = Cursors.Default;
                    this.Visible = false;
                }
                else
                {
                    this.Cursor = Cursors.WaitCursor;
                    QuestionEliminaTag nuovaa = new QuestionEliminaTag(this, (int)ElencoControlli2[0, 0].Value, scelta_poster, partenza, poster, nome_poster, cod_mostra, directory_principale, database,componenti_pos,benvenuto_pos,benvenuto_rfid);
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
                    CodeInsterting codice = new CodeInsterting(this, (int)ElencoControlli3[0, 0].Value, scelta_poster, partenza, poster, nome_poster, cod_mostra, directory_principale, database,componenti_pos,benvenuto_pos,benvenuto_rfid);
                    codice.Show();
                    this.Cursor = Cursors.Default;
                    this.Visible = false;
                }
                else
                {
                    this.Cursor = Cursors.WaitCursor;
                    QuestionEliminaTag nuovaa = new QuestionEliminaTag(this, (int)ElencoControlli3[0, 0].Value, scelta_poster, partenza, poster, nome_poster, cod_mostra, directory_principale, database,componenti_pos,benvenuto_pos,benvenuto_rfid);
                    //this.Visible = false;
                    nuovaa.Show();
                    this.Cursor = Cursors.Default;
                    this.Visible = false;
                }
            }
        }

        private void ElencoControlli1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((ElencoControlli1[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 6))
            {
                ElencoControlli1.Cursor = Cursors.Hand;
            }
            else
                ElencoControlli1.Cursor = Cursors.Default;
        }

        private void ElencoControlli2_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((ElencoControlli2[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 6))
            {
                ElencoControlli2.Cursor = Cursors.Hand;
            }
            else
                ElencoControlli2.Cursor = Cursors.Default;
        }

        private void ElencoControlli3_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((ElencoControlli3[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 6))
            {
                ElencoControlli3.Cursor = Cursors.Hand;
            }
            else
                ElencoControlli3.Cursor = Cursors.Default;
        }

        private void Indietro_Click(object sender, EventArgs e)
        {
            /*if (esecuzione== true) {
                mc.Stop();
                esecuzione = false;
            }
            if (componenti_pos == null)
            {
                scelta_poster.Visible = true;
                this.Close();
            }
            else {
                componenti_pos.Visible = true;
                this.Close();
            }*/
            this.Cursor = Cursors.WaitCursor;
            if (componenti_pos == null)
            {
                scelta_poster.Visible = true;
                //this.Close();
            }
            else
            {
                componenti_pos.Visible = true;
                //this.Close();
            }
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void Termina_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (esecuzione == true)
            {
                mc.Stop();
                esecuzione = false;
            }
            //this.Visible = false;
            Question2 nuova = new Question2(partenza,this,componenti_pos,benvenuto_pos,benvenuto_rfid);
            nuova.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
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
                //base.WndProc(ref m);
            }

            //base.WndProc(ref m);
        }*/
        #endregion


        private void button1_Click(object sender, EventArgs e)
        {
            if (global.rfid == false)
            {
                if ((componenti_pos != null) && (componenti_pos.GetBenvenuto() != null))
                {
                    this.Cursor = Cursors.WaitCursor;
                    TalkingPaper.Postering.BenvenutoPostering nn = componenti_pos.GetBenvenuto();
                    FormEsecuzioneBarcodePoster n = new FormEsecuzioneBarcodePoster(poster, nn.GetInizio());
                    //this.Close();
                    n.Show();
                    this.Cursor = Cursors.Default;
                    this.Close();
                }
                else if ((partenza != null) && (partenza.getInizio() != null))
                {
                    this.Cursor = Cursors.WaitCursor;
                    FormEsecuzioneBarcodePoster n = new FormEsecuzioneBarcodePoster(poster, partenza.getInizio());
                    //this.Close();
                    n.Show();
                    this.Cursor = Cursors.Default;
                    this.Close();
                }
                else if ((benvenuto_pos != null) && (benvenuto_pos.GetInizio() != null))
                {
                    this.Cursor = Cursors.WaitCursor;
                    FormEsecuzioneBarcodePoster n = new FormEsecuzioneBarcodePoster(poster, benvenuto_pos.GetInizio());
                    //this.Close();
                    n.Show();
                    this.Cursor = Cursors.Default;
                    this.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (componenti_pos != null) {
                componenti_pos.Close();
            }
            TalkingPaper.Postering.ComponentiDelPoster n = new TalkingPaper.Postering.ComponentiDelPoster(benvenuto_pos, null, -1, poster, nome_poster, directory_principale,"barcode",partenza,null,this,null);
                //this.Visible=false;
            //this.Close();
            n.Show();
            this.Cursor = Cursors.Default;
            this.Close();
        }

    }
}
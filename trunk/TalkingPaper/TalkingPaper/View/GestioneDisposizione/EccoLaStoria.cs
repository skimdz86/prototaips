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

namespace TalkingPaper.GestioneDisposizione
{
    public partial class EccoLaStoria : FormSchema
    {
        private PosterDaStoria poster_da_storia;
        private TalkingPaper.NHibernateManager nh_manager;
        private BenvenutoGestioneDisposizione benvenuto;
        private int id_progetto;
        private string directory_origine;
        private string directory_principale;
        private string directory_temporanea;
        private string database = "prova";
        private bool modifica;
        private ArrayList page_start;
        private ArrayList page_story;
        private ArrayList page_text;
        private Bitmap preview_immagine;
        private Bitmap preview_audio;
        private Bitmap preview_testo;
        private Bitmap preview_video;
        private Bitmap virgoletta;
        private int riga_poster = 0;
        private int id_poster;
        private string provenienza;
        /*private TalkingPaper.BarCode.BenvenutoBarCode benvenuto_bar;
        private TalkingPaper.RfidCode.BenvenutoRFID benvenuto_rfid;
        private TalkingPaper.BarCode.FormVisualizzaElementi visualizza_bar;
        private TalkingPaper.RfidCode.FormVisualizzaElementiRFID visualizza_rfid;*/
        private TalkingPaper.Authoring.BenvenutoAuthoring benvenuto_aut;
        private TalkingPaper.Authoring.FormVisualizzaElementiAuthoring visualizza_aut;
        private TalkingPaper.GestioneDisposizione.ComponentiDelPoster componenti_poster;
        private string id_pannello;
        private string nome_pannello;
        private string configurazione;


        public EccoLaStoria(int id_progetto, string directory_principale, PosterDaStoria poster_da_storia, BenvenutoGestioneDisposizione benvenuto, bool modifica, int id_poster, string provenienza,TalkingPaper.Authoring.BenvenutoAuthoring benvenuto_aut, TalkingPaper.Authoring.FormVisualizzaElementiAuthoring visualizza_aut, TalkingPaper.GestioneDisposizione.ComponentiDelPoster componenti_poster,string id_pannello, string nome_pannello,string configurazione)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 90, true);
            this.poster_da_storia = poster_da_storia;
            this.componenti_poster = componenti_poster;
            this.provenienza = provenienza;
            this.id_pannello = id_pannello;
            this.nome_pannello = nome_pannello;
            this.configurazione = configurazione;
            //this.benvenuto_bar = benvenuto_bar;
            //this.benvenuto_rfid = benvenuto_rfid;
            this.benvenuto_aut = benvenuto_aut;
            this.visualizza_aut = visualizza_aut;
            this.directory_principale = directory_principale;
            this.id_progetto = id_progetto;
            this.modifica = modifica;
            this.benvenuto = benvenuto;
            this.id_poster = id_poster;
            //this.visualizza_bar = visualizza_bar;
            //this.visualizza_rfid = visualizza_rfid;
            this.directory_origine = directory_principale+"\\1001Storia\\editor\\media\\";
            page_start = new ArrayList();
            page_story = new ArrayList();
            page_text = new ArrayList();
            this.nh_manager = new NHibernateManager();
            //label1.Visible = false;
            preview_testo = new Bitmap(directory_principale + @"/Images/Icons/preview _testo_piccola.gif");
            preview_immagine = new Bitmap(directory_principale + @"/Images/Icons/preview_immagine3.gif");
            preview_audio = new Bitmap(directory_principale + @"/Images/Icons/nota2piccola.gif");
            preview_video = new Bitmap(directory_principale + @"/Images/Icons/play_video_piccola.gif");
            virgoletta = new Bitmap(directory_principale + @"/Images/Icons/virgoletta.gif");
            this.directory_temporanea = directory_principale + @"/Temp";
            System.IO.Directory.CreateDirectory(directory_temporanea);
            //InitializeComponent();
            Indietro.Cursor = Cursors.Hand;
            Aggiungi.Cursor = Cursors.Hand;
            Togli.Cursor = Cursors.Hand;
            OK.Cursor = Cursors.Hand;
            treeView1.Cursor = Cursors.Hand;
            PreviewPoster.CellMouseEnter += new DataGridViewCellEventHandler(PreviewPoster_CellMouseEnter);
            ElencoContenuti.CellMouseEnter += new DataGridViewCellEventHandler(ElencoContenuti_CellMouseEnter);
            if (modifica == true)
            {
                OK.Text = "Salva Modifiche";
                //Modif.Visible = true;
            }
            CreaAlbero();
        }

        private void EccoLaStoria_Load(object sender, EventArgs e)
        {
            if (modifica == true)
            {
                PreviewPoster.Visible = true;
                label3.Visible = true;
                //mostre = new ArrayList();
                //mostre = (ArrayList)mostre_sel;
                // Setting della DataGrid
                PreviewPoster.ColumnCount = 6;
                PreviewPoster.Columns[5].Visible = false;
                //DataGridViewCheckBoxColumn colonna_chek = new DataGridViewCheckBoxColumn();
                //ElencoContenuti.Columns.Add(colonna_chek);
                PreviewPoster.ColumnHeadersVisible = false;
                //PreviewPoster.Columns[0].Visible = false;
                //DataGridViewRow riga = new DataGridViewRow();
                //ElencoContenuti.Rows.Add("ID", "  ", "AUDIO", "  "); // ,"  ", "ELIMINA");
                //ElencoContenuti.Rows.Add("ID", "  ", "IMMAGINE", "  "); // ,"  ", "ELIMINA");
                //ElencoContenuti.Rows.Add("ID", "  ", "TESTO", "  "); // ,"  ", "ELIMINA");
                //ElencoContenuti.Rows.Add();
                //ElencoContenuti.CellClick +
                //PreviewPoster.Rows.Add("  ", "  ", nome_componente, "  ", "  ");
                //label2.Visible = false;
                //label1.Visible = true;
                //label1.Text = label2.Text + "      ";
                /*DataGridViewCheckBoxCell check = new DataGridViewCheckBoxCell();
                check.Value = false;
                PreviewPoster[4, riga_poster] = check;
                riga_poster++;*/
                using (ISession tempS = nh_manager.Session)
                using (ITransaction tempT = tempS.BeginTransaction())
                {
                    try
                    {
                        IList contenuti;
                        IQuery q = tempS.CreateQuery("FROM Contenuto as cont WHERE cont.Poster=:Pos");
                        q.SetParameter("Pos", id_poster);
                        contenuti = q.List();
                        if (contenuti.Count != 0)
                        {
                            foreach (Contenuto c in contenuti)
                            {
                                if (c.Tipo.Tipo.CompareTo("Controllo") != 0)
                                {
                                    PreviewPoster.Rows.Add("  ", "  ", c.Nome, "  ", "  ", c.IDcontenuto);
                                    //PreviewPoster.Rows.Add(c.IDcontenuto, "  ", c.Nome, "  ", "  ", "  ");
                                    DataGridViewCheckBoxCell check = new DataGridViewCheckBoxCell();
                                    check.Value = false;
                                    PreviewPoster[4, riga_poster] = check;
                                    riga_poster++;
                                    try
                                    {
                                        DataGridViewImageCell aud_vid = new DataGridViewImageCell();
                                        if (c.Tipo.Descrizione.CompareTo("Musica") == 0)
                                        {
                                            PreviewPoster.Rows.Add("audio", null, c.RisorsaMultimediale.Path + "/" + c.RisorsaMultimediale.Nome, null, null, null);
                                            aud_vid.Value = preview_audio;
                                        }
                                        else if (c.Tipo.Descrizione.CompareTo("Video") == 0)
                                        {
                                            PreviewPoster.Rows.Add("video", null, c.RisorsaMultimediale.Path + "/" + c.RisorsaMultimediale.Nome, null, null, null);
                                            aud_vid.Value = preview_video;
                                        }
                                        /*DataGridViewImageCell usato = new DataGridViewImageCell();
                                        usato.Value = virgoletta;
                                        ElencoContenuti[6, i] = usato;*/
                                        //DataGridViewImageCell aud = new DataGridViewImageCell();
                                        //aud.Value = preview_audio;
                                        PreviewPoster[4, riga_poster] = aud_vid;
                                        riga_poster++;
                                        /*else
                                        {
                                            DataGridViewImageCell img = new DataGridViewImageCell();
                                            img.Value = preview_immagine;
                                            PreviewPoster[4, riga_poster] = img;
                                        }*/
                                        // riga_poster++;
                                    }
                                    catch (Exception eeee)
                                    {

                                    }
                                    if (c.AltrarisorsaLista.Count != 0)
                                    {
                                        foreach (Altrarisorsa a in c.AltrarisorsaLista)
                                        {
                                            if (a.Tipo.CompareTo("immagine") == 0)
                                            {
                                                PreviewPoster.Rows.Add("immagine", null, a.Path + "/" + a.Nome, null, null, null);
                                                DataGridViewImageCell img = new DataGridViewImageCell();
                                                img.Value = preview_immagine;
                                                PreviewPoster[4, riga_poster] = img;
                                                riga_poster++;
                                            }
                                            else if (a.Tipo.CompareTo("testo") == 0)
                                            {
                                                PreviewPoster.Rows.Add("testo", null, a.Path + "/" + a.Nome, null, null, null);
                                                DataGridViewImageCell tee = new DataGridViewImageCell();
                                                tee.Value = preview_testo;
                                                PreviewPoster[4, riga_poster] = tee;
                                                riga_poster++;
                                            }
                                        }
                                    }
                                    PreviewPoster.Rows.Add();
                                    riga_poster++;
                                }
                            }
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
        }

        private void CreaAlbero()
        {
            int argomenti = 1;
            int sotto_argomenti = 1;
            MySqlConnection connection;
            connection = new MySqlConnection("server=localhost; username=root; password=root; database=" + database);
            connection.Open();
            MySqlCommand myC = new MySqlCommand("SELECT ID,type FROM page WHERE projectID=?IDp");
            myC.Connection = connection;
            myC.Parameters.Add("?IDp", MySqlDbType.Int32, 50).Value = id_progetto;
            /*myC.Parameters.Add("?ID2", MySqlDbType.Int32, 50).Value = 151;
            myC.Parameters.Add("?ID3", MySqlDbType.Int32, 50).Value = 153;
            myC.Parameters.Add("?ID4", MySqlDbType.Int32, 50).Value = 154;
            myC.Parameters.Add("?ID5", MySqlDbType.Int32, 50).Value = 156;
            myC.Parameters.Add("?ID6", MySqlDbType.Int32, 50).Value = 249;
            myC.Parameters.Add("?ID7", MySqlDbType.Int32, 50).Value = 253;*/
            MySqlDataReader dr2 = myC.ExecuteReader();
            while (dr2.Read())
            {
                if (((String)dr2.GetString(1)).CompareTo("startpage") == 0)
                {
                    page_start.Add((int)dr2.GetInt32(0));
                    //page_start.Add((string)dr2.GetString(1));
                }
                else if (((String)dr2.GetString(1)).CompareTo("storypage") == 0)
                {
                    page_story.Add((int)dr2.GetInt32(0));
                    //page_story.Add((string)dr2.GetString(1));
                }
                else if (((String)dr2.GetString(1)).CompareTo("textpage") == 0)
                {
                    page_text.Add((int)dr2.GetInt32(0));
                    //page_text.Add((string)dr2.GetString(1));
                }
            }
            connection.Close();
            foreach (int id_page in page_start)
            {
                string nome_start;
                int id_in_start;
                MySqlConnection connection2;
                connection2 = new MySqlConnection("server=localhost; username=root; password=root; database=" + database);
                connection2.Open();
                MySqlCommand myC2 = new MySqlCommand("SELECT ID,title FROM startpage WHERE pageID=?IDp");
                myC2.Connection = connection2;
                myC2.Parameters.Add("?IDp", MySqlDbType.Int32, 50).Value = id_page;
                MySqlDataReader dr3 = myC2.ExecuteReader();
                if (dr3.Read())
                {
                    id_in_start = (int)dr3.GetInt32(0);
                    string nome_start1 = (String)dr3.GetString(1);
                    nome_start = TalkingPaper.Postering.PulisciStringa.Pulizia(nome_start1);
                    TreeNode nodo = new TreeNode(argomenti.ToString() + " " + nome_start, id_page, 0); // 0=start, 1=story, 2=text
                    treeView1.Nodes.Add(nodo);
                    argomenti++;
                }
                /*ArrayList media_id = new ArrayList();
                MySqlConnection connection2;
                connection2 = new MySqlConnection("server=localhost; username=root; password=root; database=" + database);
                connection2.Open();
                MySqlCommand myC2 = new MySqlCommand("SELECT ID FROM media WHERE pageID=?IDp");
                myC2.Connection = connection2;
                myC2.Parameters.Add("?IDp", MySqlDbType.Int32, 50).Value = id_start;
                MySqlDataReader dr3 = myC2.ExecuteReader();
                while (dr3.Read()) {
                    media_id.Add((int)dr3.GetInt32(0));
                }*/
                connection2.Close();
            }
            foreach (int id_page in page_story)
            {
                string nome_story;
                int id_in_story;
                int pid;
                MySqlConnection connection3;
                connection3 = new MySqlConnection("server=localhost; username=root; password=root; database=" + database);
                connection3.Open();
                MySqlCommand myC3 = new MySqlCommand("SELECT ID,title,PID FROM storypage WHERE pageID=?IDp");
                myC3.Connection = connection3;
                myC3.Parameters.Add("?IDp", MySqlDbType.Int32, 50).Value = id_page;
                MySqlDataReader dr4 = myC3.ExecuteReader();
                if (dr4.Read())
                {
                    id_in_story = (int)dr4.GetInt32(0);
                    string nome_story1 = (String)dr4.GetString(1);
                    nome_story = TalkingPaper.Postering.PulisciStringa.Pulizia(nome_story1);
                    try
                    {
                        pid = (int)dr4.GetInt32(2);
                    }
                    catch (Exception e)
                    {
                        TreeNode nodo = new TreeNode(argomenti.ToString() + " " + nome_story, id_page, 1);
                        treeView1.Nodes.Add(nodo);
                        MySqlConnection connection4;
                        connection4 = new MySqlConnection("server=localhost; username=root; password=root; database=" + database);
                        connection4.Open();
                        MySqlCommand myC4 = new MySqlCommand("SELECT ID,title,pageID FROM storypage WHERE PID=?Pid");
                        myC4.Connection = connection4;
                        myC4.Parameters.Add("?Pid", MySqlDbType.Int32, 50).Value = id_in_story;
                        MySqlDataReader dr5 = myC4.ExecuteReader();
                        while (dr5.Read())
                        {
                            string nome_sotto_arg = (string)dr5.GetString(1);
                            string sotto_arg = TalkingPaper.Postering.PulisciStringa.Pulizia(nome_sotto_arg);
                            //TreeNode figlio = new TreeNode(argomenti.ToString()+"."+sotto_argomenti.ToString()+" "+(string)dr5.GetString(1),(int) dr5.GetInt32(2),1);
                            TreeNode figlio = new TreeNode(argomenti.ToString() + "." + sotto_argomenti.ToString() + " " + sotto_arg, (int)dr5.GetInt32(2), 1);
                            nodo.Nodes.Add(figlio);
                            sotto_argomenti++;
                        }
                        argomenti++;
                        sotto_argomenti = 1;
                        connection4.Close();
                    }
                    //argomenti++;
                }
                connection3.Close();
            }
            foreach (int id_page in page_text)
            {
                string nome_text;
                int id_in_text;
                MySqlConnection connection5;
                connection5 = new MySqlConnection("server=localhost; username=root; password=root; database=" + database);
                connection5.Open();
                MySqlCommand myC5 = new MySqlCommand("SELECT ID,title,text FROM textpage WHERE pageID=?IDp");
                myC5.Connection = connection5;
                myC5.Parameters.Add("?IDp", MySqlDbType.Int32, 50).Value = id_page;
                MySqlDataReader dr6 = myC5.ExecuteReader();
                while (dr6.Read())
                {
                    string nome_text1 = (string)dr6.GetString(1);
                    nome_text = TalkingPaper.Postering.PulisciStringa.Pulizia(nome_text1);
                    //TreeNode nodo = new TreeNode(argomenti.ToString()+" "+(string)dr6.GetString(1), id_page, 2);
                    TreeNode nodo = new TreeNode(argomenti.ToString() + " " + nome_text, id_page, 2);
                    treeView1.Nodes.Add(nodo);
                    argomenti++;
                }
                connection5.Close();
            }
        }

        private void Indietro_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (System.IO.Directory.Exists(directory_temporanea))
            {
                System.IO.Directory.Delete(directory_temporanea, true);
            }
            poster_da_storia.Visible = true;
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ElencoContenuti.Rows.Clear();
            label1.Visible = false;
            label2.Visible = false;
            bool beccato = false;
            if (PreviewPoster.Rows.Count != 0)
            {
                for (int i = 0; i < PreviewPoster.Rows.Count; i++)
                {
                    if (PreviewPoster[2, i].Value != null)
                    {
                        int indice = e.Node.Text.IndexOf(" ");
                        string nome_componente = e.Node.Text.Substring(indice + 1);
                        if (((string)PreviewPoster[2, i].Value).CompareTo(nome_componente) == 0)
                        {
                            label1.Text = e.Node.Text + "        ";
                            label1.Visible = true;

                        }
                    }
                }
            }
            if (beccato == false)
            {
                label2.Visible = true;
                label2.Text = e.Node.Text;
            }
            //int riga = 0;
            // sono in una start page
            if (e.Node.SelectedImageIndex == 0)
            {
                int riga = 0;
                ElencoContenuti.Visible = true;
                //mostre = new ArrayList();
                //mostre = (ArrayList)mostre_sel;
                // Setting della DataGrid
                ElencoContenuti.ColumnCount = 7;
                //DataGridViewCheckBoxColumn colonna_chek = new DataGridViewCheckBoxColumn();
                //ElencoContenuti.Columns.Add(colonna_chek);
                ElencoContenuti.ColumnHeadersVisible = false;
                ElencoContenuti.Columns[0].Visible = false;
                //DataGridViewRow riga = new DataGridViewRow();
                //ElencoContenuti.Rows.Add("ID", "  ", "AUDIO", "  "); // ,"  ", "ELIMINA");
                //ElencoContenuti.Rows.Add("ID", "  ", "IMMAGINE", "  "); // ,"  ", "ELIMINA");
                //ElencoContenuti.Rows.Add("ID", "  ", "TESTO", "  "); // ,"  ", "ELIMINA");
                //ElencoContenuti.Rows.Add();
                //ElencoContenuti.CellClick += new DataGridViewCellEventHandler(this.ClickSullaTabella);
                MySqlConnection connection2;
                connection2 = new MySqlConnection("server=localhost; username=root; password=root; database=" + database);
                connection2.Open();
                MySqlCommand myC2 = new MySqlCommand("SELECT ID FROM media WHERE pageID=?IDp");
                myC2.Connection = connection2;
                myC2.Parameters.Add("?IDp", MySqlDbType.Int32, 50).Value = e.Node.ImageIndex;
                MySqlDataReader dr3 = myC2.ExecuteReader();
                if (dr3.HasRows == true)
                {
                    dr3.Read();
                    int id_media = (int)dr3.GetInt32(0);
                    MySqlConnection connection3;
                    connection3 = new MySqlConnection("server=localhost; username=root; password=root; database=" + database);
                    connection3.Open();
                    MySqlCommand myC3 = new MySqlCommand("SELECT audiofilesrc FROM presentation WHERE mediaID=?Mid");
                    myC3.Connection = connection3;
                    myC3.Parameters.Add("?Mid", MySqlDbType.Int32, 50).Value = id_media;
                    MySqlDataReader dr4 = myC3.ExecuteReader();
                    ElencoContenuti.Rows.Add("ID", "  ", "AUDIO", "  ", "  ", "  ", "  "); // ,"  ", "ELIMINA");
                    riga++;
                    ElencoContenuti.Rows.Add(); // ,"  ", "ELIMINA");
                    //ElencoContenuti.Columns.Add(colonna_chek);
                    ElencoContenuti[2, riga].Value = (string)dr4.GetString(1);
                    DataGridViewCheckBoxCell cella = new DataGridViewCheckBoxCell();
                    cella.Value = false;
                    ElencoContenuti[4, riga] = cella;
                    DataGridViewImageCell audio = new DataGridViewImageCell();
                    audio.Value = preview_audio;
                    ElencoContenuti[6, riga] = audio;
                    // bool beccato = false;
                    if (PreviewPoster.Rows.Count != 0)
                    {
                        for (int i = 0; i < PreviewPoster.Rows.Count; i++)
                        {
                            if (PreviewPoster[2, i].Value != null)
                            {
                                //int indice = e.Node.Text.IndexOf(" ");
                                //string nome_componente = e.Node.Text.Substring(indice + 1);
                                if (((string)PreviewPoster[2, i].Value).CompareTo((string)ElencoContenuti[2, riga].Value) == 0)
                                {
                                    //label1.Text = e.Node.Text + "        ";
                                    //label1.Visible = true;
                                    DataGridViewImageCell presente = new DataGridViewImageCell();
                                    presente.Value = virgoletta;
                                    ElencoContenuti[6, riga] = presente;

                                }
                            }
                        }
                    }
                    riga++;
                    connection3.Close();
                }
                connection2.Close();
                MySqlConnection connection;
                connection = new MySqlConnection("server=localhost; username=root; password=root; database=" + database);
                connection.Open();
                MySqlCommand myC = new MySqlCommand("SELECT ID,bannerimagesrc FROM startpage WHERE pageID=?IDp");
                myC.Connection = connection;
                myC.Parameters.Add("?IDp", MySqlDbType.Int32, 50).Value = e.Node.ImageIndex;
                MySqlDataReader dr2 = myC.ExecuteReader();
                if (dr2.HasRows == true)
                {
                    dr2.Read();
                    ElencoContenuti.Rows.Add(); // ,"  ", "ELIMINA");
                    riga++;
                    ElencoContenuti.Rows.Add("ID", "  ", "IMMAGINE", "  ", "  ", "  "); // ,"  ", "ELIMINA");
                    riga++;
                    //ElencoContenuti.Rows.Add(); // ,"  ", "ELIMINA");
                    //ElencoContenuti.Columns.Add(colonna_chek);
                    ElencoContenuti.Rows.Add();
                    ElencoContenuti[2, riga].Value = (string)dr2.GetString(1);
                    DataGridViewCheckBoxCell cella = new DataGridViewCheckBoxCell();
                    cella.Value = false;
                    ElencoContenuti[4, riga] = cella;
                    DataGridViewImageCell immagine = new DataGridViewImageCell();
                    immagine.Value = preview_immagine;
                    ElencoContenuti[5, riga] = immagine;
                    if (PreviewPoster.Rows.Count != 0)
                    {
                        for (int i = 0; i < PreviewPoster.Rows.Count; i++)
                        {
                            if (PreviewPoster[2, i].Value != null)
                            {
                                //int indice = e.Node.Text.IndexOf(" ");
                                //string nome_componente = e.Node.Text.Substring(indice + 1);
                                if (((string)PreviewPoster[2, i].Value).CompareTo((string)ElencoContenuti[2, riga].Value) == 0)
                                {
                                    //label1.Text = e.Node.Text + "        ";
                                    //label1.Visible = true;
                                    DataGridViewImageCell presente = new DataGridViewImageCell();
                                    presente.Value = virgoletta;
                                    ElencoContenuti[6, riga] = presente;

                                }
                            }
                        }
                    }
                    riga++;
                }
                connection.Close();
            }
            //sono in una story page
            else if (e.Node.SelectedImageIndex == 1)
            {
                int riga = 0;
                int id_presentation = -1;
                ElencoContenuti.Visible = true;
                //mostre = new ArrayList();
                //mostre = (ArrayList)mostre_sel;
                // Setting della DataGrid
                ElencoContenuti.ColumnCount = 7;
                //DataGridViewCheckBoxColumn colonna_chek = new DataGridViewCheckBoxColumn();
                //ElencoContenuti.Columns.Add(colonna_chek);
                ElencoContenuti.ColumnHeadersVisible = false;
                ElencoContenuti.Columns[0].Visible = false;
                //DataGridViewRow riga = new DataGridViewRow();
                //ElencoContenuti.Rows.Add("ID", "  ", "AUDIO", "  "); // ,"  ", "ELIMINA");
                //ElencoContenuti.Rows.Add("ID", "  ", "IMMAGINE", "  "); // ,"  ", "ELIMINA");
                //ElencoContenuti.Rows.Add("ID", "  ", "TESTO", "  "); // ,"  ", "ELIMINA");
                //ElencoContenuti.Rows.Add();
                //ElencoContenuti.CellClick += new DataGridViewCellEventHandler(this.ClickSullaTabella);
                MySqlConnection connection2;
                connection2 = new MySqlConnection("server=localhost; username=root; password=root; database=" + database);
                connection2.Open();
                MySqlCommand myC2 = new MySqlCommand("SELECT ID FROM media WHERE pageID=?IDp");
                myC2.Connection = connection2;
                myC2.Parameters.Add("?IDp", MySqlDbType.Int32, 50).Value = e.Node.ImageIndex;
                MySqlDataReader dr3 = myC2.ExecuteReader();
                if (dr3.HasRows == true)
                {
                    dr3.Read();
                    int id_media = (int)dr3.GetInt32(0);
                    MySqlConnection connection3;
                    connection3 = new MySqlConnection("server=localhost; username=root; password=root; database=" + database);
                    connection3.Open();
                    MySqlCommand myC3 = new MySqlCommand("SELECT ID,audiofilesrc FROM presentation WHERE mediaID=?Mid");
                    myC3.Connection = connection3;
                    myC3.Parameters.Add("?Mid", MySqlDbType.Int32, 50).Value = id_media;
                    MySqlDataReader dr4 = myC3.ExecuteReader();
                    ElencoContenuti.Rows.Add("ID", "  ", "AUDIO", "  ", "  ", "  "); // ,"  ", "ELIMINA");
                    //ElencoContenuti[4, riga].Value = null;
                    riga++;
                    ElencoContenuti.Rows.Add(); // ,"  ", "ELIMINA");
                    //ElencoContenuti.Columns.Add(colonna_chek);
                    dr4.Read();
                    id_presentation = (int)dr4.GetInt32(0);
                    ElencoContenuti[2, riga].Value = (string)dr4.GetString(1);
                    DataGridViewCheckBoxCell cella = new DataGridViewCheckBoxCell();
                    ElencoContenuti[4, riga] = cella;
                    cella.Value = false;
                    DataGridViewImageCell audio = new DataGridViewImageCell();
                    audio.Value = preview_audio;
                    ElencoContenuti[5, riga] = audio;
                    if (PreviewPoster.Rows.Count != 0)
                    {
                        for (int i = 0; i < PreviewPoster.Rows.Count; i++)
                        {
                            if (PreviewPoster[2, i].Value != null)
                            {
                                //int indice = e.Node.Text.IndexOf(" ");
                                //string nome_componente = e.Node.Text.Substring(indice + 1);
                                if (((string)PreviewPoster[2, i].Value).CompareTo((string)ElencoContenuti[2, riga].Value) == 0)
                                {
                                    //label1.Text = e.Node.Text + "        ";
                                    //label1.Visible = true;
                                    DataGridViewImageCell presente = new DataGridViewImageCell();
                                    presente.Value = virgoletta;
                                    ElencoContenuti[6, riga] = presente;

                                }
                            }
                        }
                    }
                    riga++;
                    connection3.Close();
                }
                connection2.Close();
                if (id_presentation != -1)
                {
                    //connection2.Close();
                    MySqlConnection connection;
                    connection = new MySqlConnection("server=localhost; username=root; password=root; database=" + database);
                    connection.Open();
                    MySqlCommand myC = new MySqlCommand("SELECT ID,imageFilesrc FROM presentationimage WHERE presentationID=?IDp");
                    myC.Connection = connection;
                    myC.Parameters.Add("?IDp", MySqlDbType.Int32, 50).Value = id_presentation;
                    MySqlDataReader dr2 = myC.ExecuteReader();
                    if (dr2.HasRows == true)
                    {
                        ElencoContenuti.Rows.Add(); // ,"  ", "ELIMINA");
                        riga++;
                        ElencoContenuti.Rows.Add("ID", "  ", "IMMAGINE", "  ", "  ", "  "); // ,"  ", "ELIMINA");
                        riga++;
                        while (dr2.Read())
                        {
                            ElencoContenuti.Rows.Add();
                            ElencoContenuti[2, riga].Value = (string)dr2.GetString(1);
                            DataGridViewCheckBoxCell cella = new DataGridViewCheckBoxCell();
                            cella.Value = false;
                            ElencoContenuti[4, riga] = cella;
                            DataGridViewImageCell immagine = new DataGridViewImageCell();
                            immagine.Value = preview_immagine;
                            ElencoContenuti[5, riga] = immagine;
                            if (PreviewPoster.Rows.Count != 0)
                            {
                                for (int i = 0; i < PreviewPoster.Rows.Count; i++)
                                {
                                    if (PreviewPoster[2, i].Value != null)
                                    {
                                        //int indice = e.Node.Text.IndexOf(" ");
                                        //string nome_componente = e.Node.Text.Substring(indice + 1);
                                        if (((string)PreviewPoster[2, i].Value).CompareTo((string)ElencoContenuti[2, riga].Value) == 0)
                                        {
                                            //label1.Text = e.Node.Text + "        ";
                                            //label1.Visible = true;
                                            DataGridViewImageCell presente = new DataGridViewImageCell();
                                            presente.Value = virgoletta;
                                            ElencoContenuti[6, riga] = presente;

                                        }
                                    }
                                }
                            }
                            riga++;
                        }
                        //ElencoContenuti.Rows.Add(); // ,"  ", "ELIMINA");
                        //ElencoContenuti.Columns.Add(colonna_chek);
                    }
                    connection.Close();
                }

                //PARTE AGGIUNTA
                //connection2.Close();
                MySqlConnection connection10;
                connection10 = new MySqlConnection("server=localhost; username=root; password=root; database=" + database);
                connection10.Open();
                MySqlCommand myC10 = new MySqlCommand("SELECT pageID,text FROM storypage WHERE pageID=?IDp");
                myC10.Connection = connection10;
                myC10.Parameters.Add("?IDp", MySqlDbType.Int32, 50).Value = e.Node.ImageIndex;
                MySqlDataReader dr10 = myC10.ExecuteReader();
                int num_testo = -1;
                if (dr10.HasRows == true)
                {
                    ElencoContenuti.Rows.Add(); // ,"  ", "ELIMINA");
                    riga++;
                    ElencoContenuti.Rows.Add("ID", "  ", "TESTO", "  ", "  ", "  "); // ,"  ", "ELIMINA");
                    riga++;
                    while (dr10.Read())
                    {
                        string testo1 = dr10.GetString(1);
                        string testo = TalkingPaper.Postering.PulisciStringa.Pulizia(testo1);
                        num_testo++;
                        //MessageBox.Show(testo);
                        //System.IO.Directory.CreateDirectory(
                        System.IO.StreamWriter file = new System.IO.StreamWriter(directory_temporanea + "/testo" + dr10.GetInt32(0).ToString() + num_testo.ToString() + ".doc", false);
                        file.WriteLine(testo);
                        file.Close();
                        ElencoContenuti.Rows.Add();
                        ElencoContenuti[2, riga].Value = "/testo" + dr10.GetInt32(0).ToString() + num_testo.ToString() + ".doc";
                        DataGridViewCheckBoxCell cella = new DataGridViewCheckBoxCell();
                        cella.Value = false;
                        ElencoContenuti[4, riga] = cella;
                        DataGridViewImageCell tessto = new DataGridViewImageCell();
                        tessto.Value = preview_testo;
                        ElencoContenuti[5, riga] = tessto;
                        if (PreviewPoster.Rows.Count != 0)
                        {
                            for (int i = 0; i < PreviewPoster.Rows.Count; i++)
                            {
                                if (PreviewPoster[2, i].Value != null)
                                {
                                    //int indice = e.Node.Text.IndexOf(" ");
                                    //string nome_componente = e.Node.Text.Substring(indice + 1);
                                    if (((string)PreviewPoster[2, i].Value).CompareTo((string)ElencoContenuti[2, riga].Value) == 0)
                                    {
                                        //label1.Text = e.Node.Text + "        ";
                                        //label1.Visible = true;
                                        DataGridViewImageCell presente = new DataGridViewImageCell();
                                        presente.Value = virgoletta;
                                        ElencoContenuti[6, riga] = presente;

                                    }
                                }
                            }
                        }
                        riga++;
                    }
                    //ElencoContenuti.Rows.Add(); // ,"  ", "ELIMINA");
                    //ElencoContenuti.Columns.Add(colonna_chek);
                }
                connection10.Close();
                //FINE PARTE AGGIUNTA
            }
            //sono in una text page
            else if (e.Node.SelectedImageIndex == 2)
            {
                int riga = 0;
                int id_presentation = -1;
                ElencoContenuti.Visible = true;
                //mostre = new ArrayList();
                //mostre = (ArrayList)mostre_sel;
                // Setting della DataGrid
                ElencoContenuti.ColumnCount = 7;
                //DataGridViewCheckBoxColumn colonna_chek = new DataGridViewCheckBoxColumn();
                //ElencoContenuti.Columns.Add(colonna_chek);
                ElencoContenuti.ColumnHeadersVisible = false;
                ElencoContenuti.Columns[0].Visible = false;
                //DataGridViewRow riga = new DataGridViewRow();
                //ElencoContenuti.Rows.Add("ID", "  ", "AUDIO", "  "); // ,"  ", "ELIMINA");
                //ElencoContenuti.Rows.Add("ID", "  ", "IMMAGINE", "  "); // ,"  ", "ELIMINA");
                //ElencoContenuti.Rows.Add("ID", "  ", "TESTO", "  "); // ,"  ", "ELIMINA");
                //ElencoContenuti.Rows.Add();
                //ElencoContenuti.CellClick += new DataGridViewCellEventHandler(this.ClickSullaTabella);
                int num_testo = -1;
                MySqlConnection connection11;
                connection11 = new MySqlConnection("server=localhost; username=root; password=root; database=" + database);
                connection11.Open();
                MySqlCommand myC11 = new MySqlCommand("SELECT pageID,text FROM textpage WHERE pageID=?IDp");
                myC11.Connection = connection11;
                myC11.Parameters.Add("?IDp", MySqlDbType.Int32, 50).Value = e.Node.ImageIndex;
                MySqlDataReader dr8 = myC11.ExecuteReader();
                if (dr8.HasRows)
                {
                    ElencoContenuti.Rows.Add("ID", "  ", "TESTO", "  ", "  ", "  "); // ,"  ", "ELIMINA");
                    riga++;
                    while (dr8.Read())
                    {
                        string testo1 = dr8.GetString(1);
                        string testo = TalkingPaper.Postering.PulisciStringa.Pulizia(testo1);
                        num_testo++;
                        //MessageBox.Show(testo);
                        //System.IO.Directory.CreateDirectory(
                        System.IO.StreamWriter file = new System.IO.StreamWriter(directory_temporanea + "/testo" + dr8.GetInt32(0).ToString() + num_testo.ToString() + ".doc", false);
                        file.WriteLine(testo);
                        file.Close();
                        ElencoContenuti.Rows.Add();
                        ElencoContenuti[2, riga].Value = "/testo" + dr8.GetInt32(0).ToString() + num_testo.ToString() + ".doc";
                        DataGridViewCheckBoxCell cella = new DataGridViewCheckBoxCell();
                        cella.Value = false;
                        ElencoContenuti[4, riga] = cella;
                        DataGridViewImageCell tessto = new DataGridViewImageCell();
                        tessto.Value = preview_testo;
                        ElencoContenuti[5, riga] = tessto;
                        if (PreviewPoster.Rows.Count != 0)
                        {
                            for (int i = 0; i < PreviewPoster.Rows.Count; i++)
                            {
                                if (PreviewPoster[2, i].Value != null)
                                {
                                    //int indice = e.Node.Text.IndexOf(" ");
                                    //string nome_componente = e.Node.Text.Substring(indice + 1);
                                    if (((string)PreviewPoster[2, i].Value).CompareTo((string)ElencoContenuti[2, riga].Value) == 0)
                                    {
                                        //label1.Text = e.Node.Text + "        ";
                                        //label1.Visible = true;
                                        DataGridViewImageCell presente = new DataGridViewImageCell();
                                        presente.Value = virgoletta;
                                        ElencoContenuti[6, riga] = presente;

                                    }
                                }
                            }
                        }
                        riga++;
                    }
                    connection11.Close();
                    dr8.Close();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void ElencoContenuti_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 4) || (e.ColumnIndex == 5))
            {
                if (ElencoContenuti[e.ColumnIndex, e.RowIndex].Value != null)
                {
                    ElencoContenuti.Cursor = Cursors.Hand;
                }
                else
                    ElencoContenuti.Cursor = Cursors.Default;
            }
            else
                ElencoContenuti.Cursor = Cursors.Default;
        }

        private void PreviewPoster_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                if (PreviewPoster[e.ColumnIndex, e.RowIndex].Value != null)
                {
                    PreviewPoster.Cursor = Cursors.Hand;
                }
                else
                    PreviewPoster.Cursor = Cursors.Default;
            }
            else
                PreviewPoster.Cursor = Cursors.Default;
        }

        private void ElencoContenuti_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //this.Cursor = Cursors.WaitCursor;
            if ((ElencoContenuti[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 4))
            {
                this.Cursor = Cursors.WaitCursor;
                if ((Boolean)ElencoContenuti[e.ColumnIndex, e.RowIndex].Value == true)
                {
                    ElencoContenuti[e.ColumnIndex, e.RowIndex].Value = false;
                }
                else
                {
                    int indice_sup = -1;
                    int indice_inf = -1;
                    bool trovato = false;
                    bool trovato2 = false;
                    string header = "";
                    int i = e.RowIndex - 1;
                    int j = e.RowIndex + 1;
                    while (trovato == false)
                    {
                        try
                        {
                            string val = (String)ElencoContenuti[2, i].Value;
                            if (val == null)
                            {
                                trovato = true;
                                indice_sup = i;
                            }
                        }
                        catch (Exception exxx)
                        {
                            trovato = true;
                            indice_sup = i;
                        }
                        /*if ((((String)ElencoContenuti[2, i]).CompareTo("AUDIO"))){
                            indice_sup = i;
                            trovato = true;
                            header="audio";
                        }
                        else if(((String)ElencoContenuti[2, i]).CompareTo("IMMAGINE")){
                            indice_sup = i;
                            trovato = true;
                            header="immagine";
                        }*/
                        i--;
                    }
                    while (trovato2 == false)
                    {
                        try
                        {
                            string val = (string)ElencoContenuti[2, j].Value;
                            if (val == null)
                            {
                                indice_inf = j;
                                trovato2 = true;
                            }
                        }
                        catch (Exception excx)
                        {
                            indice_inf = j;
                            trovato2 = true;
                        }
                        /*if ((((String)ElencoContenuti[2, i]).CompareTo("TESTO")) || (((String)ElencoContenuti[2, i]).CompareTo("IMMAGINE")))
                        {
                            indice_inf = j;
                            trovato = true;
                        }*/
                        j++;
                    }
                    //ElencoContenuti[4, e.RowIndex].Value = true;
                    for (int k = indice_sup + 2; k < indice_inf; k++)
                    {
                        ElencoContenuti[4, k].Value = false;
                    }
                    ElencoContenuti[4, e.RowIndex].Value = true;
                }
                this.Cursor = Cursors.Default;
            }
            else if ((ElencoContenuti[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 5))
            {
                this.Cursor = Cursors.WaitCursor;
                string tipo = "";
                bool trovato = false;
                int i = e.RowIndex;
                while (trovato == false)
                {
                    if ((((string)(ElencoContenuti[2, i].Value)).CompareTo("AUDIO")) == 0)
                    {
                        trovato = true;
                        tipo = "audio";
                    }
                    else if ((((string)(ElencoContenuti[2, i].Value)).CompareTo("IMMAGINE")) == 0)
                    {
                        trovato = true;
                        tipo = "immagine";
                    }
                    else if ((((string)(ElencoContenuti[2, i].Value)).CompareTo("TESTO")) == 0)
                    {
                        trovato = true;
                        tipo = "testo";
                    }
                    i--;
                }
                if (tipo.CompareTo("audio") == 0)
                {
                    PlayAudio aud = new PlayAudio(directory_origine + (string)ElencoContenuti[2, e.RowIndex].Value, null, null, null, this, null);
                    //this.Enabled = false;
                    aud.Show();
                    this.Cursor = Cursors.Default;
                    this.Enabled = false;
                }
                else if (tipo.CompareTo("immagine") == 0)
                {
                    StampaImmagine img = new StampaImmagine(directory_origine + (string)ElencoContenuti[2, e.RowIndex].Value + ".rex.jpg",null);
                    this.Cursor = Cursors.Default;

                }
                else if (tipo.CompareTo("testo") == 0)
                {
                    //StampaImmagine img = new StampaImmagine(directory_origine + (string)ElencoContenuti[2, e.RowIndex].Value + ".rex.jpg");
                    string tipooo = ((string)ElencoContenuti[2, e.RowIndex].Value).Substring(((string)ElencoContenuti[2, e.RowIndex].Value).Length - 4);
                    NuovoComponente nuovo = new NuovoComponente();
                    StampaTesto tes = new StampaTesto(directory_temporanea + "/" + (string)ElencoContenuti[2, e.RowIndex].Value, tipooo, nuovo);
                    this.Cursor = Cursors.Default;

                }
            }
            this.Cursor = Cursors.Default;
        }

        private void Aggiungi_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (modifica == false)
            {
                PreviewPoster.Visible = true;
                label3.Visible = true;
                //mostre = new ArrayList();
                //mostre = (ArrayList)mostre_sel;
                // Setting della DataGrid
                PreviewPoster.ColumnCount = 6;
                //DataGridViewCheckBoxColumn colonna_chek = new DataGridViewCheckBoxColumn();
                //ElencoContenuti.Columns.Add(colonna_chek);
                PreviewPoster.ColumnHeadersVisible = false;
                //PreviewPoster.Columns[0].Visible = false;
                //DataGridViewRow riga = new DataGridViewRow();
                //ElencoContenuti.Rows.Add("ID", "  ", "AUDIO", "  "); // ,"  ", "ELIMINA");
                //ElencoContenuti.Rows.Add("ID", "  ", "IMMAGINE", "  "); // ,"  ", "ELIMINA");
                //ElencoContenuti.Rows.Add("ID", "  ", "TESTO", "  "); // ,"  ", "ELIMINA");
                //ElencoContenuti.Rows.Add();
                //ElencoContenuti.CellClick += new DataGridViewCellEventHandler(this.ClickSullaTabella);
            }
            string nome_componente;
            if (label1.Visible == true)
            {
                //string nome_componente;
                int indice = label1.Text.IndexOf(" ");
                nome_componente = label1.Text.Substring(indice + 1);
            }
            else
            {
                //string nome_componente;
                int indice = label2.Text.IndexOf(" ");
                nome_componente = label2.Text.Substring(indice + 1);
            }
            string tipo_risorsa = "";
            //int riga_poster = 0;
            PreviewPoster.Rows.Add("  ", "  ", nome_componente, "  ", "  ", null);
            label2.Visible = false;
            label1.Visible = true;
            label1.Text = label2.Text + "      ";
            DataGridViewCheckBoxCell check = new DataGridViewCheckBoxCell();
            check.Value = false;
            PreviewPoster[4, riga_poster] = check;
            riga_poster++;
            for (int i = 0; i < ElencoContenuti.Rows.Count; i++)
            {
                try
                {
                    if (((string)ElencoContenuti[2, i].Value).CompareTo("AUDIO") == 0)
                    {
                        tipo_risorsa = "audio";
                    }
                    else if (((string)ElencoContenuti[2, i].Value).CompareTo("IMMAGINE") == 0)
                    {
                        tipo_risorsa = "immagine";
                    }
                    else if (((string)ElencoContenuti[2, i].Value).CompareTo("TESTO") == 0)
                    {
                        tipo_risorsa = "testo";
                    }
                    else if (((ElencoContenuti[2, i].Value != null)))
                    {
                        bool segnato = (bool)ElencoContenuti[4, i].Value;
                        if (segnato == true)
                        {
                            PreviewPoster.Rows.Add(tipo_risorsa, null, (String)ElencoContenuti[2, i].Value, null, null, null);
                            DataGridViewImageCell usato = new DataGridViewImageCell();
                            usato.Value = virgoletta;
                            ElencoContenuti[6, i] = usato;
                            if (tipo_risorsa.CompareTo("audio") == 0)
                            {
                                DataGridViewImageCell aud = new DataGridViewImageCell();
                                aud.Value = preview_audio;
                                PreviewPoster[4, riga_poster] = aud;
                            }
                            else if (tipo_risorsa.CompareTo("immagine") == 0)
                            {
                                DataGridViewImageCell img = new DataGridViewImageCell();
                                img.Value = preview_immagine;
                                PreviewPoster[4, riga_poster] = img;
                            }
                            else if (tipo_risorsa.CompareTo("testo") == 0)
                            {
                                DataGridViewImageCell tes = new DataGridViewImageCell();
                                tes.Value = preview_testo;
                                PreviewPoster[4, riga_poster] = tes;
                            }
                            riga_poster++;
                            ElencoContenuti[4, i].Value = false;
                        }
                    }
                }
                catch (Exception eeee)
                {

                }

            }
            PreviewPoster.Rows.Add();
            riga_poster++;
            this.Cursor = Cursors.Default;
        }

        private void PreviewPoster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((PreviewPoster[4, e.RowIndex].Value != null) && (e.ColumnIndex == 4))
            {
                this.Cursor = Cursors.WaitCursor;
                string tipologia = "";
                try
                {
                    bool segnato = (bool)PreviewPoster[4, e.RowIndex].Value;
                    tipologia = "check";
                    //Bitmap bit = (Bitmap)PreviewPoster[4, e.RowIndex].Value;
                    //tipologia = "icona";
                }
                catch (Exception excep)
                {
                    try
                    {
                        Bitmap bit = (Bitmap)PreviewPoster[4, e.RowIndex].Value;
                        tipologia = "icona";
                    }
                    catch (Exception excepti)
                    {

                    }
                }
                this.Cursor = Cursors.Default;
                if (tipologia.CompareTo("check") == 0)
                {
                    this.Cursor = Cursors.WaitCursor;
                    if ((bool)PreviewPoster[4, e.RowIndex].Value == true)
                    {
                        PreviewPoster[4, e.RowIndex].Value = false;
                    }
                    else
                    {
                        int riga_segnato = -1;
                        bool trovato = false;
                        for (int i = 0; i < PreviewPoster.Rows.Count; i++)
                        {
                            try
                            {
                                bool segnato = (bool)PreviewPoster[4, i].Value;
                                if (segnato == true)
                                {
                                    riga_segnato = i;
                                    trovato = true;
                                }
                            }
                            catch (Exception exs)
                            {

                            }
                        }
                        if (trovato == true)
                        {
                            PreviewPoster[4, riga_segnato].Value = false;
                        }
                        PreviewPoster[4, e.RowIndex].Value = true;
                    }
                    this.Cursor = Cursors.Default;
                }
                else if (tipologia.CompareTo("icona") == 0)
                {
                    //MessageBox.Show("Icona");
                    if (((string)PreviewPoster[0, e.RowIndex].Value).CompareTo("audio") == 0)
                    {
                        try
                        {
                            this.Cursor = Cursors.WaitCursor;
                            PlayAudio aud = new PlayAudio(directory_origine + (string)PreviewPoster[2, e.RowIndex].Value, null, null, null, this, null);
                            //this.Enabled = false;
                            aud.Show();
                            this.Cursor = Cursors.Default;
                            this.Enabled = false;

                        }
                        catch (Exception exce)
                        {
                            this.Cursor = Cursors.WaitCursor;
                            PlayAudio aud = new PlayAudio(directory_principale + (string)PreviewPoster[2, e.RowIndex].Value, null, null, null, this, null);
                            //this.Enabled = false;
                            aud.Show();
                            this.Cursor = Cursors.Default;
                            this.Enabled = false;
                        }
                    }
                    else if (((string)PreviewPoster[0, e.RowIndex].Value).CompareTo("video") == 0)
                    {
                        try
                        {
                            this.Cursor = Cursors.WaitCursor;
                            PlayVideo vid = new PlayVideo(directory_origine + (string)PreviewPoster[2, e.RowIndex].Value, null, null, null, this, null);
                            //PlayAudio aud = new PlayAudio(directory_origine + (string)PreviewPoster[2, e.RowIndex].Value, null, null, null, this);
                            //this.Enabled = false;
                            vid.Show();
                            this.Cursor = Cursors.Default;
                            this.Enabled = false;
                        }
                        catch (Exception exce)
                        {
                            this.Cursor = Cursors.WaitCursor;
                            PlayVideo vid = new PlayVideo(directory_principale + (string)PreviewPoster[2, e.RowIndex].Value, null, null, null, this, null);
                            //PlayAudio aud = new PlayAudio(directory_origine + (string)PreviewPoster[2, e.RowIndex].Value, null, null, null, this);
                            //this.Enabled = false;
                            vid.Show();
                            this.Cursor = Cursors.Default;
                            this.Enabled = false;
                            /*PlayAudio aud = new PlayAudio(directory_principale + (string)PreviewPoster[2, e.RowIndex].Value, null, null, null, this);
                            this.Enabled = false;
                            aud.Show();*/
                        }
                    }
                    else if (((string)PreviewPoster[0, e.RowIndex].Value).CompareTo("immagine") == 0)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        try
                        {
                            StampaImmagine img = new StampaImmagine(directory_origine + (string)PreviewPoster[2, e.RowIndex].Value + ".rex.jpg",null);
                        }
                        catch (Exception exc)
                        {
                            StampaImmagine img = new StampaImmagine(directory_principale + (string)PreviewPoster[2, e.RowIndex].Value,null);
                        }
                        this.Cursor = Cursors.Default;
                    }
                    else if (((string)PreviewPoster[0, e.RowIndex].Value).CompareTo("testo") == 0)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        try
                        {
                            string tipo = ((string)PreviewPoster[2, e.RowIndex].Value).Substring(((string)PreviewPoster[2, e.RowIndex].Value).Length - 4);
                            NuovoComponente nu = new NuovoComponente();
                            StampaTesto testt = new StampaTesto(directory_temporanea + (string)PreviewPoster[2, e.RowIndex].Value, tipo, nu);
                        }
                        catch (Exception except)
                        {
                            string tipo = ((string)PreviewPoster[2, e.RowIndex].Value).Substring(((string)PreviewPoster[2, e.RowIndex].Value).Length - 4);
                            NuovoComponente nu = new NuovoComponente();
                            StampaTesto testt = new StampaTesto(directory_principale + (string)PreviewPoster[2, e.RowIndex].Value, tipo, nu);
                        }
                        this.Cursor = Cursors.Default;
                    }
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void Togli_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int row_index = -1;
            int last_row_index = -1;
            for (int i = 0; i < PreviewPoster.Rows.Count; i++)
            {
                bool segnato;
                //int row_index;
                try
                {
                    segnato = (bool)PreviewPoster[4, i].Value;
                    if (segnato == true)
                    {
                        row_index = i;
                    }
                }
                catch (Exception exceptionn)
                {

                }
            }
            bool tro = false;
            if (row_index != -1)
            {
                for (int j = row_index; (j < PreviewPoster.Rows.Count) && (tro == false); j++)
                {
                    try
                    {
                        string valore = (string)PreviewPoster[0, j].Value;
                        if (valore == null)
                        {
                            last_row_index = j;
                            tro = true;
                        }
                    }
                    catch (Exception excer)
                    {
                        last_row_index = j;
                        tro = true;
                    }
                }
                int h = row_index;
                for (int k = row_index; k <= last_row_index; k++)
                {
                    PreviewPoster.Rows.RemoveAt(h);
                    riga_poster--;
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            /*Poster poster = new Poster();
            ArrayList contenuti= new ArrayList();
            for (int i = 0; i < PreviewPoster.Rows.Count; i++) {
                try
                {
                    Contenuto contenuto = new Contenuto();
               
                }
                catch (Exception ex){ 
                
                }
            }*/
            this.Cursor = Cursors.WaitCursor;
            NuovoPosterDaStoria nuovo = new NuovoPosterDaStoria(id_progetto, directory_principale, poster_da_storia, benvenuto, this, PreviewPoster, directory_origine, modifica, id_poster, directory_temporanea, provenienza, benvenuto_aut,visualizza_aut,componenti_poster,id_pannello,nome_pannello,configurazione);
            //this.Visible = false;
            /*if ((componenti_poster != null) && (componenti_poster.Disposing == false))
            {
                componenti_poster.Close();
            }*/
            nuovo.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }


        private void Menu_Click(object sender, EventArgs e)
        {
            QuestionPostering richiesta = new QuestionPostering(benvenuto, global.home, componenti_poster, benvenuto_aut, visualizza_aut);
            richiesta.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }
    }
}
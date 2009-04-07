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
using System.Drawing.Printing;
using Microsoft.Office.Interop.Word;
using System.Reflection;
using System.Xml;



namespace TalkingPaper.GestioneDisposizione
{
    public partial class NuovoComponente : FormSchema
    {
        private int tag_per_riga;
        private int tag_per_colonna;
        private Authoring.FormVisualizzaElementiAuthoring componenti_poster;
        private BenvenutoGestioneDisposizione benvenuto;
        private PosterDellaMostra poster;
        private int id_mostra;
        private int id_poster;
        private string directory_principale;
        private string nome_poster;
        private TalkingPaper.NHibernateManager nh_manager;
        private bool audio;
        private bool video;
        private bool testo;
        private bool immagine;
        private bool modifica;
        private int id_contenuto;
        private string nome_contenuto;
        private string provenienza;
        /*private TalkingPaper.BarCode.BenvenutoBarCode benvenuto_bar;
        private TalkingPaper.RfidCode.BenvenutoRFID benvenuto_rfid;
        private TalkingPaper.BarCode.FormVisualizzaElementi visualizza_bar;
        private TalkingPaper.RfidCode.FormVisualizzaElementiRFID visualizza_rfid;*/
        private TalkingPaper.Authoring.BenvenutoAuthoring benvenuto_aut;
        private TalkingPaper.Authoring.FormVisualizzaElementiAuthoring visualizza_aut;
        private string id_pannello;
        private string nome_pannello;
        private string configurazione;
        private Authoring.ElementoGriglia[,] matrice;
        private char[] alfabeto ={ 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'Z' };

        public NuovoComponente() { }

//        public NuovoComponente(BenvenutoGestioneDisposizione benvenuto, PosterDellaMostra poster, ComponentiDelPoster componenti_poster, string nome_poster, int id_mostra, int id_poster, bool modifica, int id_contenuto, string nome_contenuto, string directory_principale, string provenienza, TalkingPaper.Authoring.BenvenutoAuthoring benvenuto_aut, TalkingPaper.Authoring.FormVisualizzaElementiAuthoring visualizza_aut, string id_pannello, string nome_pannello, string configurazione,int tag_per_riga, int tag_per_colonna)
        public NuovoComponente(BenvenutoGestioneDisposizione benvenuto, PosterDellaMostra poster, Authoring.FormVisualizzaElementiAuthoring componenti_poster, string nome_poster, int id_mostra, int id_poster, bool modifica, int id_contenuto, string nome_contenuto, string directory_principale, string provenienza, TalkingPaper.Authoring.BenvenutoAuthoring benvenuto_aut, TalkingPaper.Authoring.FormVisualizzaElementiAuthoring visualizza_aut, string id_pannello, string nome_pannello, string configurazione, int tag_per_riga, int tag_per_colonna)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 70, true);
            this.tag_per_colonna = tag_per_colonna;
            this.tag_per_riga = tag_per_riga;
            matrice = new Authoring.ElementoGriglia[tag_per_colonna + 1, tag_per_riga + 1];
            this.provenienza = provenienza;
            this.id_pannello = id_pannello;
            this.nome_pannello = nome_pannello;
            this.configurazione = configurazione;
            /*this.benvenuto_bar = benvenuto_bar;
            this.benvenuto_rfid = benvenuto_rfid;
            this.visualizza_bar = visualizza_bar;
            this.visualizza_rfid = visualizza_rfid;*/
            this.benvenuto_aut = benvenuto_aut;
            this.visualizza_aut = visualizza_aut;
            this.benvenuto = benvenuto;
            this.nome_contenuto = nome_contenuto;
            this.poster = poster;
            this.modifica = modifica;
            this.componenti_poster = componenti_poster;
            this.id_mostra = id_mostra;
            this.id_poster = id_poster;
            this.nome_poster = nome_poster;
            this.directory_principale = directory_principale;
            this.id_contenuto = id_contenuto;
            this.nh_manager = new NHibernateManager();
            SfogliaAudio.Cursor = Cursors.Hand;
            SfogliaImmagine.Cursor = Cursors.Hand;
            SfogliaTesto.Cursor = Cursors.Hand;
            SfogliaVideo.Cursor = Cursors.Hand;
            PreviewAudio.Cursor = Cursors.Hand;
            PreviewImmagine.Cursor = Cursors.Hand;
            PreviewTesto.Cursor = Cursors.Hand;
            PreviewVideo.Cursor = Cursors.Hand;
            EliminaAudio.Cursor = Cursors.Hand;
            EliminaImmagine.Cursor = Cursors.Hand;
            EliminaTesto.Cursor = Cursors.Hand;
            EliminaVideo.Cursor = Cursors.Hand;
            Salva.Cursor = Cursors.Hand;
            Annulla.Cursor = Cursors.Hand;
            if (modifica == true)
            {
                this.sottotitolo.Text = "Modifica del componente " + '"' + nome_contenuto + '"';
                LeggiFileXml();
                //label1.Visible = false;
                //textBox1.Visible = false;
                textBox1.Text = nome_contenuto;
                textBox1.Focus();
                textBox1.SelectionStart = 0;
                textBox1.SelectionLength = 0;
                using (ISession tempS = nh_manager.Session)
                using (ITransaction tempT = tempS.BeginTransaction())
                {
                    try
                    {
                        Contenuto conte = new Contenuto();
                        IQuery q = tempS.CreateQuery("FROM Contenuto as cont WHERE cont.IDcontenuto=:Con");
                        q.SetParameter("Con", id_contenuto);
                        conte = (Contenuto)q.List()[0];
                        if (conte.Tipo.Descrizione.CompareTo("Musica") == 0)
                        {
                            textBox2.Text = directory_principale + conte.RisorsaMultimediale.Path + "/" + conte.RisorsaMultimediale.Nome;
                            EliminaAudio.Visible = true;
                            PreviewAudio.Visible = true;
                        }
                        else if (conte.Tipo.Descrizione.CompareTo("Video") == 0)
                        {
                            textBox4.Text = directory_principale + conte.RisorsaMultimediale.Path + "/" + conte.RisorsaMultimediale.Nome;
                            EliminaVideo.Visible = true;
                            PreviewVideo.Visible = true;
                        }
                        foreach (Altrarisorsa a in conte.AltrarisorsaLista)
                        {
                            if (a.Tipo.CompareTo("immagine") == 0)
                            {
                                textBox5.Text = directory_principale + a.Path + "/" + a.Nome;
                                EliminaImmagine.Visible = true;
                                PreviewImmagine.Visible = true;
                            }
                            else if (a.Tipo.CompareTo("testo") == 0)
                            {
                                textBox6.Text = directory_principale + a.Path + "/" + a.Nome;
                                EliminaTesto.Visible = true;
                                PreviewTesto.Visible = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        tempT.Rollback();
                        Console.WriteLine("Eccezione in Salva Poster");
                    }
                    finally
                    {
                        tempS.Close();
                    }
                }
            }
            else
            {
                this.sottotitolo.Text = this.sottotitolo.Text + " " + nome_poster;
            }
        }

        #region Gestione Eventi

        private void Annulla_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.visualizza_aut.Visible = true;
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void SfogliaAudio_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //string disco
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Audio Files|*.wma;*.wav;*.mp2;*.mp3";
            // openFileDialog.InitialDirectory = "";
            if (DialogResult.OK == openFileDialog.ShowDialog())
            {
                string path = openFileDialog.FileName;
                textBox2.Text = path;
                textBox4.Text = "";
                EliminaAudio.Visible = true;
                PreviewAudio.Visible = true;
                EliminaVideo.Visible = false;
                PreviewVideo.Visible = false;
                //MessageBox.Show(path.Length.ToString());
                //int indice=path.LastIndexOf("\\");
                //int lunghezza= path.Length-(indice+1);
                //string file = path.Substring(indice+1,lunghezza);
                //MessageBox.Show(indice.ToString());
                //MessageBox.Show(path);
                //MessageBox.Show(file);
            }
            this.Cursor = Cursors.Default;
        }


        private void SfogliaVideo_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //string disco
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Video Files|*.mpg;*.avi;*.mov;*.wmv";
            // openFileDialog.InitialDirectory = "";
            if (DialogResult.OK == openFileDialog.ShowDialog())
            {
                string path = openFileDialog.FileName;
                textBox4.Text = path;
                textBox2.Text = "";
                EliminaVideo.Visible = true;
                PreviewVideo.Visible = true;
                EliminaAudio.Visible = false;
                PreviewAudio.Visible = false;
                //MessageBox.Show(path.Length.ToString());
                //int indice=path.LastIndexOf("\\");
                //int lunghezza= path.Length-(indice+1);
                //string file = path.Substring(indice+1,lunghezza);
                //MessageBox.Show(indice.ToString());
                //MessageBox.Show(path);
                //MessageBox.Show(file);
            }
            this.Cursor = Cursors.Default;
        }

        private void SfogliaImmagine_Click(object sender, EventArgs e)
        {
            //string disco
            this.Cursor = Cursors.WaitCursor;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.bmp;*.gif;*.jpg;*.png;*.tif";
            // openFileDialog.InitialDirectory = "";
            if (DialogResult.OK == openFileDialog.ShowDialog())
            {
                string path = openFileDialog.FileName;
                textBox5.Text = path;
                EliminaImmagine.Visible = true;
                PreviewImmagine.Visible = true;
                //MessageBox.Show(path.Length.ToString());
                //int indice=path.LastIndexOf("\\");
                //int lunghezza= path.Length-(indice+1);
                //string file = path.Substring(indice+1,lunghezza);
                //MessageBox.Show(indice.ToString());
                //MessageBox.Show(path);
                //MessageBox.Show(file);
            }
            this.Cursor = Cursors.Default;
        }

        private void SfogliaTesto_Click(object sender, EventArgs e)
        {
            //string disco
            this.Cursor = Cursors.WaitCursor;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files|*.txt;*.doc;*.rtf";
            // openFileDialog.InitialDirectory = "";
            if (DialogResult.OK == openFileDialog.ShowDialog())
            {
                string path = openFileDialog.FileName;
                textBox6.Text = path;
                EliminaTesto.Visible = true;
                PreviewTesto.Visible = true;
                //MessageBox.Show(path.Length.ToString());
                //int indice=path.LastIndexOf("\\");
                //int lunghezza= path.Length-(indice+1);
                //string file = path.Substring(indice+1,lunghezza);
                //MessageBox.Show(indice.ToString());
                //MessageBox.Show(path);
                //MessageBox.Show(file);
            }
            this.Cursor = Cursors.Default;
        }

        private void EliminaAudio_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            textBox2.Text = "";
            EliminaAudio.Visible = false;
            PreviewAudio.Visible = false;
            this.Cursor = Cursors.Default;
        }

        private void EliminaVideo_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            textBox4.Text = "";
            EliminaVideo.Visible = false;
            PreviewVideo.Visible = false;
            this.Cursor = Cursors.Default;
        }

        private void EliminaImmagine_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            textBox5.Text = "";
            EliminaImmagine.Visible = false;
            PreviewImmagine.Visible = false;
            this.Cursor = Cursors.Default;
        }

        private void EliminaTesto_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            textBox6.Text = "";
            EliminaTesto.Visible = false;
            PreviewTesto.Visible = false;
            this.Cursor = Cursors.Default;
        }

        private void PreviewAudio_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int indice = textBox2.Text.LastIndexOf("\\");
            int lenght = textBox2.Text.Length - (indice + 1);
            string nome_file = textBox2.Text.Substring(indice + 1, lenght);
            this.Enabled = false;
            PlayAudio nuovo = new PlayAudio(textBox2.Text, this, null, null, null, null);
            nuovo.Show();
            this.Cursor = Cursors.Default;
        }

        private void PreviewVideo_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int indice = textBox4.Text.LastIndexOf("\\");
            int lenght = textBox4.Text.Length - (indice + 1);
            string nome_file = textBox4.Text.Substring(indice + 1, lenght);
            this.Enabled = false;
            PlayVideo nuovo = new PlayVideo(textBox4.Text, this, null, null, null, null);
            nuovo.Show();
            this.Cursor = Cursors.Default;
        }

        /* private void Doc_PrintPage(object sender, PrintPageEventArgs e)
         {
             System.Drawing.Font font = new System.Drawing.Font("Arial", 30);

             float x = e.MarginBounds.Left;
             float y = e.MarginBounds.Top;

             float lineHeight = font.GetHeight(e.Graphics);

             for (int i = 0; i < 5; i++)
             {
                 e.Graphics.DrawString("This is line " + i.ToString(), font, Brushes.Black, x, y);
                 y += lineHeight;
             }
             y += lineHeight;

             e.Graphics.DrawImage(Image.FromFile(textBox5.Text), x, y);

         }
         */

        private void PreviewImmagine_Click(object sender, EventArgs e)
        {
            //this.Enabled = false;
            //PreviewImmagine nuovo = new PreviewImmagine(textBox5.Text,this,null);
            //nuovo.Show();
            this.Cursor = Cursors.WaitCursor;
            StampaImmagine img = new StampaImmagine(textBox5.Text,null);
            this.Cursor = Cursors.Default;

            /*PrintDocument doc = new PrintDocument();
            doc.PrintPage += this.Doc_PrintPage;

            PrintDialog dlgSettings = new PrintDialog();
            dlgSettings.Document = doc;

            if (dlgSettings.ShowDialog() == DialogResult.OK)
            {
                doc.Print();
            }

            /* StreamReader streamToPrint = new StreamReader (textBox5.Text);
            try {
                PrintDocument doc = new PrintDocument();
                
                TextFilePrintDocument pd = new TextFilePrintDocument(streamToPrint);

                if (storedPageSettings != null) {
                    pd.DefaultPageSettings = storedPageSettings ;
                }

                PrintPreviewDialog dlg = new PrintPreviewDialog() ;
                dlg.Document = pd;
                dlg.ShowDialog();

            } finally {
                streamToPrint.Close() ;
            }

            //this.Enabled = false;
            //PreviewImmagine nuovo = new PreviewImmagine(textBox5.Text,this,null);
            //nuovo.Show();*/
        }

        private void PreviewTesto_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string tipo = textBox6.Text.Substring(((textBox6.Text.Length) - 4), 4);
            StampaTesto nuovo = new StampaTesto(textBox6.Text, tipo, this);
            this.Cursor = Cursors.Default;
        }

        private void Salva_Click(object sender, EventArgs e)
        {
            if ((textBox2.Text != null) && (textBox2.Text.CompareTo("") != 0) || (textBox4.Text != null) && (textBox4.Text.CompareTo("") != 0))
            {
                this.Cursor = Cursors.WaitCursor;
                using (ISession tempS = nh_manager.Session)
                using (ITransaction tempT = tempS.BeginTransaction())
                {
                    try
                    {
                        //Risorsamultimediale nuova = new Risorsamultimediale();
                        //nuova.PosterLista = new List();
                        int indice;
                        int indice5;
                        int indice_ufficiale2;
                        string nome_risorsa = "";
                        string tipo = "";
                        string descrizione_tipologia = "";
                        string path = "";
                        string estensione = "";
                        if ((textBox2.Text != null) && (textBox2.Text.CompareTo("") != 0))
                        {
                            tipo = "audio";
                            path = "\\audio";
                            indice = textBox2.Text.LastIndexOf("\\");
                            indice5 = textBox2.Text.LastIndexOf("/");
                            if (indice >= indice5)
                            {
                                indice_ufficiale2 = indice;
                            }
                            else
                            {
                                indice_ufficiale2 = indice5;
                            }
                            descrizione_tipologia = "Musica";
                            nome_risorsa = textBox2.Text.Substring(indice_ufficiale2 + 1);
                            estensione = textBox2.Text.Substring(textBox2.Text.Length - 4);
                            try
                            {
                                System.IO.File.Copy(textBox2.Text, directory_principale + @"/audio/" + nome_risorsa, false);
                            }
                            catch (Exception exc)
                            {
                                //MessageBox.Show("File audio già associato ad un'altra risorsa");
                                //NuovoComponente form = new NuovoComponente(componenti_poster, nome_poster, id_mostra, id_poster, modifica, directory_principale);
                                //form.Show();
                                //this.Close();
                            }
                        }
                        else
                        {
                            tipo = "video";
                            path = "\\video";
                            descrizione_tipologia = "Video";
                            indice = textBox4.Text.LastIndexOf("\\");
                            indice5 = textBox4.Text.LastIndexOf("/");
                            if (indice >= indice5)
                            {
                                indice_ufficiale2 = indice;
                            }
                            else
                            {
                                indice_ufficiale2 = indice5;
                            }
                            nome_risorsa = textBox4.Text.Substring(indice_ufficiale2 + 1);
                            estensione = textBox4.Text.Substring(textBox4.Text.Length - 4);
                            try
                            {
                                System.IO.File.Copy(textBox4.Text, directory_principale + @"/video/" + nome_risorsa, false);
                            }
                            catch (Exception exce)
                            {
                                /*MessageBox.Show("File video già associato ad un'altra risorsa");
                                NuovoComponente form = new NuovoComponente(benvenuto, poster, componenti_poster, nome_poster, id_mostra, id_poster, modifica, id_contenuto, nome_contenuto, directory_principale);
                                form.Show();
                                this.Close();*/
                            }
                        }
                        IList risorse_sel;
                        Risorsamultimediale risorsa = new Risorsamultimediale();
                        //Risorsamultimediale risorsa2 = new Risorsamultimediale();
                        risorsa.Nome = nome_risorsa;
                        risorsa.Path = path;
                        risorsa.Estensione = estensione;
                        risorsa.Dimensione = 0;
                        tempS.Save(risorsa);
                        //tempT.Commit();
                        tempS.Flush();
                        Altrarisorsa immagine = new Altrarisorsa();
                        if ((textBox5.Text != null) && (textBox5.Text.CompareTo("") != 0))
                        {
                            //Altrarisorsa immagine = new Altrarisorsa();
                            string tipo2 = "";
                            string path2 = "";
                            int indice2;
                            int indice4;
                            int indice_ufficiale;
                            string nome_risorsa2 = "";
                            tipo2 = "immagine";
                            path2 = "\\Images";
                            //indice2 = textBox5.Text.LastIndexOf("\\");
                            indice2 = textBox5.Text.LastIndexOf("\\");
                            indice4 = textBox5.Text.LastIndexOf("/");
                            if (indice2 >= indice4)
                            {
                                indice_ufficiale = indice2;
                            }
                            else
                            {
                                indice_ufficiale = indice4;
                            }
                            nome_risorsa2 = textBox5.Text.Substring(indice_ufficiale + 1);
                            //estensione = textBox2.Text.Substring(textBox2.Text.Length - 4);
                            try
                            {
                                System.IO.File.Copy(textBox5.Text, directory_principale + @"/Images/" + nome_risorsa2, false);
                            }
                            catch (Exception exc)
                            {
                                //MessageBox.Show("File audio già associato ad un'altra risorsa");
                                //NuovoComponente form = new NuovoComponente(componenti_poster, nome_poster, id_mostra, id_poster, modifica, directory_principale);
                                //form.Show();
                                //this.Close();
                            }
                            immagine.Nome = nome_risorsa2;
                            immagine.Path = path2;
                            immagine.Tipo = tipo2;
                            tempS.Save(immagine);
                            //tempT.Commit();
                            tempS.Flush();
                        }
                        Altrarisorsa testo = new Altrarisorsa();
                        if ((textBox6.Text != null) && (textBox6.Text.CompareTo("") != 0))
                        {
                            //Altrarisorsa testo = new Altrarisorsa();
                            string tipo3 = "";
                            string path3 = "";
                            int indice3;
                            int indice6;
                            int indice_ufficiale3;
                            string nome_risorsa3 = "";
                            tipo3 = "testo";
                            path3 = "\\Testi";
                            //indice3 = textBox6.Text.LastIndexOf("\\");
                            indice3 = textBox6.Text.LastIndexOf("\\");
                            indice6 = textBox6.Text.LastIndexOf("/");
                            if (indice3 >= indice6)
                            {
                                indice_ufficiale3 = indice3;
                            }
                            else
                            {
                                indice_ufficiale3 = indice6;
                            }
                            nome_risorsa3 = textBox6.Text.Substring(indice_ufficiale3 + 1);
                            //estensione = textBox2.Text.Substring(textBox2.Text.Length - 4);
                            try
                            {
                                System.IO.File.Copy(textBox6.Text, directory_principale + @"/Testi/" + nome_risorsa3, false);
                            }
                            catch (Exception exc)
                            {
                                //MessageBox.Show("File audio già associato ad un'altra risorsa");
                                //NuovoComponente form = new NuovoComponente(componenti_poster, nome_poster, id_mostra, id_poster, modifica, directory_principale);
                                //form.Show();
                                //this.Close();
                            }
                            testo.Nome = nome_risorsa3;
                            testo.Path = path3;
                            testo.Tipo = tipo3;
                            tempS.Save(testo);
                            //tempT.Commit();
                            tempS.Flush();
                        }
                        /*Altrarisorsa text = new Altrarisorsa();
                        Altrarisorsa imag = new Altrarisorsa();
                        IQuery q5 = tempS.CreateQuery("FROM Altrarisorsa as al");
                        IList risorsa_sel = q5.List();
                        int i=0;
                        foreach (Altrarisorsa a in risorsa_sel)
                        {
                            if ((risorsa_sel.Count) - 2 == i) {
                                imag = a;
                            }
                            else if ((risorsa_sel.Count) - 1 == i) {
                                text = a;
                            }
                            i++;
                        }
                         */
                        /*Contenuto contenuto = new Contenuto();
                        contenuto.AltrarisorsaLista = new ArrayList();
                        contenuto.AltrarisorsaLista.Insert(0, immagine);
                        contenuto.AltrarisorsaLista.Insert(1, testo);
                        //contenuto.AltrarisorsaLista.Add(testo);
                        contenuto.Barcode = "0";
                        contenuto.Livello = 0;
                        contenuto.Nome = textBox1.Text;
                        contenuto.Ordine = 0;
                        contenuto.Rfidtag = "0";
                        contenuto.RisorsaMultimediale = risorsa;*/
                        Tipologia tipologia = new Tipologia();
                        IQuery q = tempS.CreateQuery("FROM Tipologia as tp WHERE tp.Descrizione=:Des");
                        q.SetParameter("Des", descrizione_tipologia);
                        tipologia = (Tipologia)q.List()[0];
                        //contenuto.Tipo = tipologia;
                        Poster poster2 = new Poster();
                        IQuery q2 = tempS.CreateQuery("FROM Poster as pt WHERE pt.IDposter=:Pos");
                        q2.SetParameter("Pos", id_poster);
                        poster2 = (Poster)q2.List()[0];
                        //contenuto.Poster = poster2;
                        //tempS.Save(contenuto);
                        //tempS.Flush();
                        /*Contenuto content = new Contenuto();
                        IList contenuti_selz;
                        IQuery q3 = tempS.CreateQuery("FROM Contenuto as cont");
                        //q3.SetParameter("Pos", id_poster);
                        contenuti_selz = q3.List();
                        foreach (Contenuto c in contenuti_selz) {
                            content = c;
                        }
                        immagine.ContenutoLista = new ArrayList();
                        immagine.ContenutoLista.Add(content);
                        testo.ContenutoLista = new ArrayList();
                        testo.ContenutoLista.Add(content);*/
                        if (modifica == false)
                        {
                            Contenuto contenuto = new Contenuto();
                            contenuto.AltrarisorsaLista = new ArrayList();
                            if ((textBox5.Text != null) && (textBox5.Text.CompareTo("") != 0))
                            {
                                contenuto.AltrarisorsaLista.Add(immagine);
                            }
                            if ((textBox6.Text != null) && (textBox6.Text.CompareTo("") != 0))
                            {
                                contenuto.AltrarisorsaLista.Add(testo);
                            }
                            //contenuto.AltrarisorsaLista.Add(testo);
                            contenuto.Barcode = "0";
                            contenuto.Livello = 0;
                            contenuto.Nome = textBox1.Text;
                            contenuto.Ordine = 0;
                            contenuto.Rfidtag = "0";
                            contenuto.RisorsaMultimediale = risorsa;
                            contenuto.Tipo = tipologia;
                            contenuto.Poster = poster2;
                            Contenuto content = new Contenuto();
                            IList contenuti_selz;
                            IQuery q3 = tempS.CreateQuery("FROM Contenuto as cont");
                            //q3.SetParameter("Pos", id_poster);
                            contenuti_selz = q3.List();
                            foreach (Contenuto c in contenuti_selz)
                            {
                                content = c;
                            }
                            if ((textBox5.Text != null) && (textBox5.Text.CompareTo("") != 0))
                            {
                                immagine.ContenutoLista = new ArrayList();
                                immagine.ContenutoLista.Add(content);
                                tempS.Update(immagine);
                                //tempT.Commit();
                                tempS.Flush();
                            }
                            if ((textBox6.Text != null) && (textBox6.Text.CompareTo("") != 0))
                            {
                                testo.ContenutoLista = new ArrayList();
                                testo.ContenutoLista.Add(content);
                                tempS.Update(testo);
                                //tempT.Commit();
                                tempS.Flush();
                            }
                            //tempS.Update(immagine);
                            //tempT.Commit();
                            //tempS.Flush();
                            //tempS.Update(testo);
                            //tempT.Commit();
                            //tempS.Flush();
                            tempS.Save(contenuto);
                        }
                        else
                        {
                            Contenuto contenuto = new Contenuto();
                            IQuery q4 = tempS.CreateQuery("FROM Contenuto as Cont WHERE Cont.IDcontenuto=:Con");
                            q4.SetParameter("Con", id_contenuto);
                            contenuto = (Contenuto)q4.List()[0];
                            contenuto.AltrarisorsaLista = new ArrayList();
                            if ((textBox5.Text != null) && (textBox5.Text.CompareTo("") != 0))
                            {
                                contenuto.AltrarisorsaLista.Add(immagine);
                            }
                            if ((textBox6.Text != null) && (textBox6.Text.CompareTo("") != 0))
                            {
                                contenuto.AltrarisorsaLista.Add(testo);
                            }
                            //contenuto.AltrarisorsaLista.Add(testo);
                            contenuto.Nome = textBox1.Text;
                            contenuto.Barcode = "0";
                            contenuto.Livello = 0;
                            //contenuto.Nome = textBox1.Text;
                            contenuto.Ordine = 0;
                            contenuto.Rfidtag = "0";
                            contenuto.RisorsaMultimediale = risorsa;
                            contenuto.Tipo = tipologia;
                            contenuto.Poster = poster2;
                            /*Contenuto con_eliminare = new Contenuto();
                            IQuery q4 = tempS.CreateQuery("FROM Contenuto as Cont WHERE Cont.IDcontenuto=:Con");
                            q4.SetParameter("Con", id_contenuto);
                            con_eliminare = (Contenuto)q4.List()[0];*/
                            tempS.Update(contenuto);
                        }
                        //tempS.Update(immagine);
                        //tempT.Commit();
                        //tempS.Flush();
                        //tempS.Update(testo);
                        //tempT.Commit();
                        //tempS.Flush();
                        //tempS.Save(contenuto);
                        //tempS.Save(contenuto);
                        // tempT.Commit();
                        // tempS.Flush();
                        // tempS.Flush();

                        //Controllo se l'utente vuole fare una modifica --> se si elimino il componente precedente
                        /*if (modifica == true) {
                            Contenuto contenuto = new Contenuto();
                            contenuto.AltrarisorsaLista = new ArrayList();
                            contenuto.AltrarisorsaLista.Insert(0, immagine);
                            contenuto.AltrarisorsaLista.Insert(1, testo);
                            //contenuto.AltrarisorsaLista.Add(testo);
                            contenuto.Barcode = "0";
                            contenuto.Livello = 0;
                            contenuto.Nome = textBox1.Text;
                            contenuto.Ordine = 0;
                            contenuto.Rfidtag = "0";
                            contenuto.RisorsaMultimediale = risorsa;
                            contenuto.Tipo = tipologia;
                            contenuto.Poster = poster2;
                            Contenuto con_eliminare = new Contenuto();
                            IQuery q4 = tempS.CreateQuery("FROM Contenuto as Cont WHERE Cont.IDcontenuto=:Con");
                            q4.SetParameter("Con", id_contenuto);
                            con_eliminare = (Contenuto)q4.List()[0];
                            tempS.Delete(con_eliminare);
                        }*/
                        tempT.Commit();
                        tempS.Flush();
                        // seleziono tutte le risorse e recupero l'id assegnato all'audio/video inserito

                        /*IQuery q = tempS.CreateQuery("FROM Risorsamultimediale as rs");
                        risorse_sel = q.List();
                        foreach (Risorsamultimediale m in risorse_sel) {
                            (Risorsamultimediale)risorsa2 = m;
                        }
                        //MessageBox.Show("Risorsa creata");
                        //IQuery q = tempS.CreateQuery("FROM Poster as pt WHERE ");
                        //q.SetParameter("Pos", cod_poster); tipo,poster
                        //mostra_sel = q.List();
                        Contenuto contenuto = new Contenuto();
                        Tipologia tipologia = new Tipologia();
                        contenuto.Nome = textBox1.Text;
                        contenuto.Livello = 0;
                        contenuto.Ordine = 0;
                        contenuto.Rfidtag = "0";
                        contenuto.Barcode = "0";
                        contenuto.RisorsaMultimediale = risorsa2;
                        if (tipo.CompareTo("video") == 0) {
                            IQuery q2 = tempS.CreateQuery("FROM Tipologia as tp");
                            IList tipologia_sel;
                            tipologia_sel = q2.List();
                            foreach (Tipologia t in tipologia_sel) {
                                if (t.Descrizione.CompareTo("Video")==0) {
                                    tipologia = t;
                                }
                            }
                        }
                        else if (tipo.CompareTo("audio") == 0) {
                            IQuery q2 = tempS.CreateQuery("FROM Tipologia as tp");
                            IList tipologia_sel;
                            tipologia_sel = q2.List();
                            foreach (Tipologia t in tipologia_sel)
                            {
                                if (t.Descrizione.CompareTo("Audio")==0)
                                {
                                    tipologia = t;
                                }
                            }
                        }*/

                        /* contenuto.Tipo = tipologia;
                        IQuery q3 = tempS.CreateQuery("FROM Poster as pt WHERE pt.IDposter=:Pos");
                        q3.SetParameter("Pos",id_poster);
                        Poster poster_sel=(Poster)q.List()[0];
                        contenuto.Poster = poster_sel;
                        tempS.Save(contenuto);
                        tempT.Commit();
                        int id_immagine;
                        int id_testo;
                        Altrarisorsa imag;
                        Altrarisorsa text;
                        IQuery q4 = tempS.CreateQuery("FROM Contenuto as cont");
                        IList contenuto_sel;
                        Contenuto content = new Contenuto();
                        contenuto_sel = q.List();
                        foreach (Contenuto c in contenuto_sel) {
                            content = c;
                        }
                        if (((textBox5.Text.CompareTo("")) != 0) && (textBox5.Text != null)) {
                            Altrarisorsa altra = new Altrarisorsa();
                            int index = textBox5.Text.LastIndexOf("\\");
                            string name_risorsa = textBox5.Text.Substring(index + 1);
                            altra.Nome = name_risorsa;
                            altra.Path="/Images";
                            altra.Tipo = "Immagine";
                            //altra.ContenutoLista = content;
                            tempS.Save(altra);
                            tempT.Commit();
                            IQuery q5 = tempS.CreateQuery("FROM Altrarisorsa as al");
                            IList risorsa_sel = q5.List();
                            foreach (Altrarisorsa a in risorsa_sel) {
                                imag = a;
                            }
                        }
                        if (((textBox6.Text.CompareTo("")) != 0) && (textBox6.Text != null))
                        {
                            Altrarisorsa altra = new Altrarisorsa();
                            int index = textBox6.Text.LastIndexOf("\\");
                            string name_risorsa = textBox6.Text.Substring(index + 1);
                            altra.Nome = name_risorsa;
                            altra.Path = "/Testi";
                            altra.Tipo = "Testo";
                            //altra.ContenutoLista = content;
                            tempS.Save(altra);
                            tempT.Commit();
                            IQuery q6 = tempS.CreateQuery("FROM Altrarisorsa as al");
                            IList text_sel = q6.List();
                            foreach (Altrarisorsa t in text_sel)
                            {
                                text = t;
                            }
                        }*/
                        //MANCA SALVATAGGIO IN ALTRA_CONTENUTO
                        //tempT.Commit();
                        /*int id_ultima = ((Mostra)mostra_sel[mostra_sel.Count - 1]).IDmostra;
                        string nome_mostra = ((Mostra)mostra_sel[mostra_sel.Count - 1]).Nome;
                        PosterDellaMostra poster = new PosterDellaMostra(benvenuto, null, id_ultima, nome_mostra, directory_principale);
                        poster.Show();
                        this.Close();*/

                    }
                    catch (Exception ex)
                    {
                        tempT.Rollback();
                        Console.WriteLine("Eccezione in Salva Poster");
                    }
                    finally
                    {
                        tempS.Close();
                        if (modifica == true)
                        {
                            ModificaFileXml();
                        }
                        ComponentiDelPoster nuovaa = new ComponentiDelPoster(benvenuto, poster, id_mostra, id_poster, nome_poster, directory_principale, provenienza,benvenuto_aut,visualizza_aut,id_pannello,nome_pannello,configurazione);
                        nuovaa.Show();
                        if (componenti_poster!=null)
                            componenti_poster.Close();
                        this.Cursor = Cursors.Default;
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Non hai inserito nè l'audio nè il video");
                this.Cursor = Cursors.Default;
            }
            this.Cursor = Cursors.Default;
        }

        private void ModificaFileXml() {
            try
            {
                string nome_file = directory_principale + "Griglia" + nome_pannello + id_pannello + configurazione + id_poster.ToString() + ".xml";
                bool esiste = System.IO.File.Exists(nome_file);
                if (esiste == true)
                {
                    //nome_file = directory_principale + "Griglia" + nome_pannello + id_pannello + configurazione + poster.ToString() + ".xml";
                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Indent = true;
                    settings.NewLineOnAttributes = true;
                    XmlWriter wr = XmlWriter.Create(nome_file);
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
                                if (el.GetIdContenuto() == id_contenuto)
                                {
                                    wr.WriteString(textBox1.Text);
                                }
                                else
                                {
                                    wr.WriteString(el.GetNomeContenuto());
                                }
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
            }
            catch
            {
                //esiste = false;
            }

        }

        private void LeggiFileXml() {
            try
            {
                string nome_file = directory_principale + "Griglia" + nome_pannello + id_pannello + configurazione + id_poster.ToString() + ".xml";
                bool esiste = System.IO.File.Exists(nome_file);
                if (esiste == true)
                {
                    //nome_file = directory_principale + "Griglia" + nome_pannello + id_pannello + configurazione + poster.ToString() + ".xml";
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
                                bool trov = iscritto.ReadToDescendant("IDcontenuto");
                                if (trov == false)
                                {
                                    if (id.CompareTo("Non Usato") != 0)
                                    {
                                       Authoring. ElementoGriglia n = new Authoring.ElementoGriglia(id_pannello.ToString(), nome_pannello, configurazione, nome_poster, id_poster, -1, null, alfabeto[i - 1].ToString(), j, id, false);
                                        matrice[i, j] = n;
                                        //ElencoTag[i, j].Style.BackColor = Color.Coral;
                                    }
                                    else
                                    {
                                        Authoring.ElementoGriglia n = new Authoring.ElementoGriglia(id_pannello.ToString(), nome_pannello, configurazione, nome_poster, id_poster, -1, null, alfabeto[i - 1].ToString(), j, id, false);
                                        matrice[i, j] = n;
                                    }
                                }
                                else if (trov == true)
                                {
                                    string id_cont = iscritto.ReadString();
                                    int id1_cont = Int32.Parse(id_cont);
                                    iscritto.ReadToFollowing("NomeContenuto");
                                    string nome_cont = iscritto.ReadString();
                                    Authoring.ElementoGriglia n = new Authoring.ElementoGriglia(id_pannello.ToString(), nome_pannello, configurazione, nome_poster, id_poster, id1_cont, nome_cont, alfabeto[i - 1].ToString(), j, id, true);
                                    matrice[i, j] = n;
                                    //ElencoTag[i, j].Style.BackColor = Color.Coral;
                                    //ElencoTag[i, j].Value = nome_cont;
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
            }
            catch
            {
                //esiste = false;
            }
        }

        #endregion

        private void indietro_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.visualizza_aut.Visible = true;
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void NuovoComponente_Load(object sender, EventArgs e)
        {
            this.PreviewAudio.setAlignment(true);
            this.PreviewVideo.setAlignment(true);
            this.PreviewImmagine.setAlignment(true);
            this.PreviewTesto.setAlignment(true);
            this.EliminaTesto.setAlignment(true);
            this.EliminaImmagine.setAlignment(true);
            this.EliminaVideo.setAlignment(true);
            this.EliminaAudio.setAlignment(true);
            this.SfogliaTesto.setAlignment(true);
            this.SfogliaImmagine.setAlignment(true);
            this.SfogliaVideo.setAlignment(true);
            this.SfogliaAudio.setAlignment(true);



            this.PreviewAudio.Visible = false;
            this.PreviewVideo.Visible = false;
            this.PreviewImmagine.Visible = false;
            this.PreviewTesto.Visible = false;
            this.EliminaTesto.Visible = false;
            this.EliminaImmagine.Visible = false;
            this.EliminaVideo.Visible = false;
            this.EliminaAudio.Visible = false;
        }

    }
}
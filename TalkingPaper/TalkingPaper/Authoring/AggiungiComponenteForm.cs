using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Media;
using QuartzTypeLib;

using System.Drawing.Printing;
using Microsoft.Office.Interop.Word;
using System.Reflection;
using System.Xml;
using TalkingPaper.Common;
using TalkingPaper.Model;



namespace TalkingPaper.Authoring
{
    public partial class AggiungiComponenteForm : FormSchema
    {
        private int tag_per_riga;
        private int tag_per_colonna;
        private Authoring.PosizionaComponentiForm componenti_poster;
        //private Authoring.BenvenutoGestioneDisposizione benvenuto;
        private ModificaCartelloneForm poster;
        private int id_mostra;
        private int id_poster;
        private string directory_principale;
        private string nome_poster;
    //    private TalkingPaper.NHibernateManager nh_manager;
        
        private bool modifica;
        private int id_contenuto;
        private string nome_contenuto;
        private string provenienza;
        /*private TalkingPaper.BarCode.BenvenutoBarCode benvenuto_bar;
        private TalkingPaper.RfidCode.BenvenutoRFID benvenuto_rfid;
        private TalkingPaper.BarCode.FormVisualizzaElementi visualizza_bar;
        private TalkingPaper.RfidCode.FormVisualizzaElementiRFID visualizza_rfid;
        private TalkingPaper.Authoring.BenvenutoAuthoring benvenuto_aut;*/
        private TalkingPaper.Authoring.PosizionaComponentiForm visualizza_aut;
        private string id_pannello;
        private string nome_pannello;
        private string configurazione;
        private Authoring.ElementoGriglia[,] matrice;
        private char[] alfabeto ={ 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'Z' };
        private Contenuto contenuto;
        

        
//        public NuovoComponente(BenvenutoGestioneDisposizione benvenuto, PosterDellaMostra poster, ComponentiDelPoster componenti_poster, string nome_poster, int id_mostra, int id_poster, bool modifica, int id_contenuto, string nome_contenuto, string directory_principale, string provenienza, TalkingPaper.Authoring.BenvenutoAuthoring benvenuto_aut, TalkingPaper.Authoring.FormVisualizzaElementiAuthoring visualizza_aut, string id_pannello, string nome_pannello, string configurazione,int tag_per_riga, int tag_per_colonna)
        //public AggiungiComponenteForm(Authoring.BenvenutoGestioneDisposizione benvenuto, ModificaCartelloneForm poster, Authoring.PosizionaComponentiForm componenti_poster, string nome_poster, int id_mostra, int id_poster, bool modifica, int id_contenuto, string nome_contenuto, string directory_principale, string provenienza, /*TalkingPaper.Authoring.BenvenutoAuthoring benvenuto_aut,*/ TalkingPaper.Authoring.PosizionaComponentiForm visualizza_aut, string id_pannello, string nome_pannello, string configurazione, int tag_per_riga, int tag_per_colonna)
        public AggiungiComponenteForm(Contenuto cont)
        {
            InitializeComponent();
            
            //this.tag_per_colonna = tag_per_colonna;
            //this.tag_per_riga = tag_per_riga;
            matrice = new Authoring.ElementoGriglia[tag_per_colonna + 1, tag_per_riga + 1];

            contenuto = cont;

            //this.provenienza = provenienza;
            //this.id_pannello = id_pannello;
            //this.nome_pannello = nome_pannello;
            //this.configurazione = configurazione;
            /*this.benvenuto_bar = benvenuto_bar;
            this.benvenuto_rfid = benvenuto_rfid;
            this.visualizza_bar = visualizza_bar;
            this.visualizza_rfid = visualizza_rfid;*/
            //this.benvenuto_aut = benvenuto_aut;
            //this.visualizza_aut = visualizza_aut;
            //this.benvenuto = benvenuto;
            //this.nome_contenuto = nome_contenuto;
            //this.poster = poster;
            //this.modifica = modifica;
            //this.componenti_poster = componenti_poster;
            //this.id_mostra = id_mostra;
           // this.id_poster = id_poster;
           // this.nome_poster = nome_poster;
           // this.directory_principale = directory_principale;
           // this.id_contenuto = id_contenuto;
      //      this.nh_manager = new NHibernateManager();
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
            
            if (modifica == true)
            {
                this.sottotitolo.Text = "Modifica del componente " + '"' + nome_contenuto + '"';
                LeggiFileXml();
                //label1.Visible = false;
                //textBox1.Visible = false;
                nomeBox.Text = nome_contenuto;
                nomeBox.Focus();
                nomeBox.SelectionStart = 0;
                nomeBox.SelectionLength = 0;
            //    using (ISession tempS = nh_manager.Session)
            //    using (ITransaction tempT = tempS.BeginTransaction())
               /* {
                    try
                    {
                        Contenuto2 conte = new Contenuto2();
                        IQuery q = tempS.CreateQuery("FROM Contenuto as cont WHERE cont.IDcontenuto=:Con");
                        q.SetParameter("Con", id_contenuto);
                        conte = (Contenuto2)q.List()[0];
                        if (conte.Tipo.Descrizione.CompareTo("Musica") == 0)
                        {
                            suonoBox.Text = directory_principale + conte.RisorsaMultimediale.Path + "/" + conte.RisorsaMultimediale.Nome;
                            EliminaAudio.Visible = true;
                            PreviewAudio.Visible = true;
                        }
                        else if (conte.Tipo.Descrizione.CompareTo("Video") == 0)
                        {
                            videoBox.Text = directory_principale + conte.RisorsaMultimediale.Path + "/" + conte.RisorsaMultimediale.Nome;
                            EliminaVideo.Visible = true;
                            PreviewVideo.Visible = true;
                        }
                        foreach (Altrarisorsa a in conte.AltrarisorsaLista)
                        {
                            if (a.Tipo.CompareTo("immagine") == 0)
                            {
                                immagineBox.Text = directory_principale + a.Path + "/" + a.Nome;
                                EliminaImmagine.Visible = true;
                                PreviewImmagine.Visible = true;
                            }
                            else if (a.Tipo.CompareTo("testo") == 0)
                            {
                                testoBox.Text = directory_principale + a.Path + "/" + a.Nome;
                                EliminaTesto.Visible = true;
                                PreviewTesto.Visible = true;
                            }
                        }
                    }
                    catch 
                    {
                        tempT.Rollback();
                        Console.WriteLine("Eccezione in Salva Poster");
                    }
                    finally
                    {
                        tempS.Close();
                    }
                }*/
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
                suonoBox.Text = path;
               // videoBox.Text = "";
                contenuto.setAudioPath(path);
               // contenuto.setVideoPath(null);
                EliminaAudio.Visible = true;
                PreviewAudio.Visible = true;
              //  EliminaVideo.Visible = false;
              //  PreviewVideo.Visible = false;
                
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
                videoBox.Text = path;
               // suonoBox.Text = "";
                contenuto.setVideoPath(path);
               // contenuto.setAudioPath(null);
                EliminaVideo.Visible = true;
                PreviewVideo.Visible = true;
               // EliminaAudio.Visible = false;
               // PreviewAudio.Visible = false;
                
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
                immagineBox.Text = path;
                contenuto.setImagePath(path);
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
                testoBox.Text = path;
                contenuto.setTextPath(path);
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
            suonoBox.Text = "";
            contenuto.setAudioPath(null);
            EliminaAudio.Visible = false;
            PreviewAudio.Visible = false;
            this.Cursor = Cursors.Default;
        }

        private void EliminaVideo_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            videoBox.Text = "";
            contenuto.setVideoPath(null);
            EliminaVideo.Visible = false;
            PreviewVideo.Visible = false;
            this.Cursor = Cursors.Default;
        }

        private void EliminaImmagine_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            immagineBox.Text = "";
            contenuto.setImagePath(null);
            EliminaImmagine.Visible = false;
            PreviewImmagine.Visible = false;
            this.Cursor = Cursors.Default;
        }

        private void EliminaTesto_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            testoBox.Text = "";
            contenuto.setTextPath(null);
            EliminaTesto.Visible = false;
            PreviewTesto.Visible = false;
            this.Cursor = Cursors.Default;
        }

        private void PreviewAudio_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int indice = suonoBox.Text.LastIndexOf("\\");
            int lenght = suonoBox.Text.Length - (indice + 1);
            string nome_file = suonoBox.Text.Substring(indice + 1, lenght);
            if (File.Exists(suonoBox.Text))
            {
                this.Enabled = false;
                PlayAudio nuovo = new PlayAudio(suonoBox.Text, this, /*null, null, null,*/ null);
                nuovo.Show();
                this.Cursor = Cursors.Default;
            }
            else MessageBox.Show("Il file non esiste più");
        }

        private void PreviewVideo_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int indice = videoBox.Text.LastIndexOf("\\");
            int lenght = videoBox.Text.Length - (indice + 1);
            string nome_file = videoBox.Text.Substring(indice + 1, lenght);
            if (File.Exists(videoBox.Text))
            {
                this.Enabled = false;
                PlayVideo nuovo = new PlayVideo(videoBox.Text, this, /*null, null, null,*/ null);
                nuovo.Show();
                this.Cursor = Cursors.Default;
            }
            else MessageBox.Show("Il file non esiste più");
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
            StampaImmagine img = new StampaImmagine(immagineBox.Text,null);
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
            string tipo = testoBox.Text.Substring(((testoBox.Text.Length) - 4), 4);
            StampaTesto nuovo = new StampaTesto(testoBox.Text, tipo, this);
            this.Cursor = Cursors.Default;
        }

        private void Salva_Click(object sender, EventArgs e)
        {
            if ((suonoBox.Text != null) && (suonoBox.Text.CompareTo("") != 0) || (videoBox.Text != null) && (videoBox.Text.CompareTo("") != 0))
            {
                this.Cursor = Cursors.WaitCursor;
              
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
                                    wr.WriteString(nomeBox.Text);
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
            this.PreviewAudio.Visible = false;
            this.PreviewVideo.Visible = false;
            this.PreviewImmagine.Visible = false;
            this.PreviewTesto.Visible = false;
            this.EliminaTesto.Visible = false;
            this.EliminaImmagine.Visible = false;
            this.EliminaVideo.Visible = false;
            this.EliminaAudio.Visible = false;
        }

        private void home_Click(object sender, EventArgs e)
        {
            NavigationControl.goHome(this);
        }

        private void ok_Click(object sender, EventArgs e)
        {
            if (nomeBox.Text == "") MessageBox.Show("Devi inserire un nome per il contenuto!");
            else if (nomeBox.Text == "Play") MessageBox.Show("Il nome non puo essere Play");
            else if (nomeBox.Text == "Pausa") MessageBox.Show("Il nome non puo essere Pausa");
            else if (nomeBox.Text == "Stop") MessageBox.Show("Il nome non puo essere Stop");
            else if (suonoBox.Text == "" && videoBox.Text == "") MessageBox.Show("Devi inserire almeno un contenuto fra suono e video");
            else if (suonoBox.Text != "" && videoBox.Text != "") MessageBox.Show("Non puoi inserire insieme un suono e un video, cancellane uno dei due");
            else
            {
                contenuto.setNomeContenuto(nomeBox.Text);
                NavigationControl.goBack(this);
            }
        }

        private void annulla_Click_1(object sender, EventArgs e)
        {
            NavigationControl.goBack(this);
        }

    }
}
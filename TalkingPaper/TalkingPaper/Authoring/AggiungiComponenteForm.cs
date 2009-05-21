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
        private Contenuto contenuto;
        private Contenuto tempCont;

        private ControlLogic.AuthoringControl control;

        public AggiungiComponenteForm(Contenuto contenuto)
        {
            InitializeComponent();

            
            this.contenuto = contenuto;
            control = new ControlLogic.AuthoringControl();

            tempCont = new Contenuto(contenuto.getNomeContenuto(), contenuto.getAudioPath(), contenuto.getVideoPath(), contenuto.getImagePath(), contenuto.getTextPath());
            tempCont.setCoordinate(contenuto.getCoordinate());
            /*contenuto.setNomeContenuto(cont.getNomeContenuto());
            contenuto.setAudioPath(cont.getAudioPath());
            contenuto.setVideoPath(cont.getVideoPath());
            contenuto.setImagePath(cont.getImagePath());
            contenuto.setTextPath(cont.getTextPath());
            contenuto.setCoordinate(cont.getCoordinate());*/


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
                       
        }

        #region Gestione Eventi

        private void Annulla_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
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
            StampaImmagine img = new StampaImmagine(immagineBox.Text, null);
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

        /* private void Salva_Click(object sender, EventArgs e)
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
         } */

        #endregion


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
            if (contenuto != null)
            {
                MessageBox.Show(contenuto.getCoordinate()[0].ToString() + contenuto.getCoordinate()[1].ToString() + contenuto.getAudioPath());
                nomeBox.Text = tempCont.getNomeContenuto();
                if (tempCont.getAudioPath() != null)
                {
                    MessageBox.Show(contenuto.getCoordinate()[0].ToString() + contenuto.getCoordinate()[1].ToString() + contenuto.getAudioPath());
                    suonoBox.Text = tempCont.getAudioPath();
                    EliminaAudio.Visible = true;
                    PreviewAudio.Visible = true;
                }
                if (tempCont.getVideoPath() != null)
                {
                    MessageBox.Show(contenuto.getCoordinate()[0].ToString() + contenuto.getCoordinate()[1].ToString() + contenuto.getAudioPath());
                    videoBox.Text = tempCont.getVideoPath();
                    EliminaVideo.Visible = true;
                    PreviewVideo.Visible = true;
                }
                if (tempCont.getImagePath() != null)
                {
                    immagineBox.Text = tempCont.getImagePath();
                    EliminaImmagine.Visible = true;
                    PreviewImmagine.Visible = true;
                }
                if (tempCont.getTextPath() != null)
                {
                    testoBox.Text = tempCont.getTextPath();
                    EliminaTesto.Visible = true;
                    PreviewTesto.Visible = true;
                }
            }
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
                if (contenuto.getAudioPath() == null) { contenuto.setAudioPath(tempCont.getAudioPath()); }
                if (contenuto.getVideoPath() == null) { contenuto.setVideoPath(tempCont.getVideoPath()); }
                if (contenuto.getImagePath() == null) { contenuto.setImagePath(tempCont.getImagePath()); }
                if (contenuto.getTextPath() == null) { contenuto.setTextPath(tempCont.getTextPath()); }
                contenuto.setCoordinate(tempCont.getCoordinate());
                MessageBox.Show(contenuto.getNomeContenuto() + contenuto.getCoordinate()[0].ToString() + contenuto.getCoordinate()[1].ToString() + contenuto.getAudioPath());
                NavigationControl.goBack(this);
            }
        }

        private void annulla_Click(object sender, EventArgs e)
        {
            NavigationControl.goBack(this);
        }

    }
}
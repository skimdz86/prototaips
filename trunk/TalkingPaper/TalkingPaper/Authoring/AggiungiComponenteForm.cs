using System;
using TalkingPaper.Common;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace TalkingPaper.Authoring
{
    public partial class AggiungiComponenteForm : FormSchema
    {
        private Model.Contenuto contenuto;

        private List<Model.Contenuto> listaContenuti;

        private ControlLogic.AuthoringControl control;

        public AggiungiComponenteForm(Model.Contenuto contenuto, List<Model.Contenuto> listaContenuti)
        {
            try
            {
                InitializeComponent();

                this.listaContenuti = listaContenuti;
                this.contenuto = contenuto;

                control = new ControlLogic.AuthoringControl();

                //verifico se sto aggiungendo un nuovo contenuto o ne sto modificando uno già inserito
                if ((contenuto != null) && (contenuto.getNomeContenuto() != null))
                {
                    //contenuto già inserito da modificare
                    nomeBox.Text = contenuto.getNomeContenuto();
                    if (contenuto.getAudioPath() != null)
                    {
                        suonoBox.Text = contenuto.getAudioPath();
                        EliminaAudio.Visible = true;
                        PreviewAudio.Visible = true;
                    }
                    if (contenuto.getVideoPath() != null)
                    {
                        videoBox.Text = contenuto.getVideoPath();
                        EliminaVideo.Visible = true;
                        PreviewVideo.Visible = true;
                    }
                    if (contenuto.getImagePath() != null)
                    {
                        immagineBox.Text = contenuto.getImagePath();
                        EliminaImmagine.Visible = true;
                        PreviewImmagine.Visible = true;
                    }
                    if (contenuto.getTextPath() != null)
                    {
                        testoBox.Text = contenuto.getTextPath();
                        EliminaTesto.Visible = true;
                        PreviewTesto.Visible = true;
                    }

                }
          
            }
            catch (Exception e) { MessageBox.Show(e.Message); }       
        }

        private void SfogliaAudio_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Audio Files|*.wma;*.wav;*.mp2;*.mp3";
            
            if (DialogResult.OK == openFileDialog.ShowDialog())
            {
                suonoBox.Text = openFileDialog.FileName;
                EliminaAudio.Visible = true;
                PreviewAudio.Visible = true;
            }
        }


        private void SfogliaVideo_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Video Files|*.mpg;*.avi;*.mov;*.wmv";
            
            if (DialogResult.OK == openFileDialog.ShowDialog())
            {
                videoBox.Text = openFileDialog.FileName;
                EliminaVideo.Visible = true;
                PreviewVideo.Visible = true;
                
            }
            
        }

        private void SfogliaImmagine_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.bmp;*.gif;*.jpg;*.png;*.tif";
            if (DialogResult.OK == openFileDialog.ShowDialog())
            {
                immagineBox.Text = openFileDialog.FileName;
                EliminaImmagine.Visible = true;
                PreviewImmagine.Visible = true;
            }
            
        }

        private void SfogliaTesto_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files|*.txt;*.doc;*.rtf";
            if (DialogResult.OK == openFileDialog.ShowDialog())
            {
                testoBox.Text = openFileDialog.FileName;
                EliminaTesto.Visible = true;
                PreviewTesto.Visible = true;
            }
        }

        private void EliminaAudio_Click(object sender, EventArgs e)
        {
            suonoBox.Text = "";
            EliminaAudio.Visible = false;
            PreviewAudio.Visible = false;
        }

        private void EliminaVideo_Click(object sender, EventArgs e)
        {
            videoBox.Text = "";
            EliminaVideo.Visible = false;
            PreviewVideo.Visible = false;
        }

        private void EliminaImmagine_Click(object sender, EventArgs e)
        {
            immagineBox.Text = "";
            EliminaImmagine.Visible = false;
            PreviewImmagine.Visible = false;
        }

        private void EliminaTesto_Click(object sender, EventArgs e)
        {
            testoBox.Text = "";
            EliminaTesto.Visible = false;
            PreviewTesto.Visible = false;
        }

        private void PreviewAudio_Click(object sender, EventArgs e)
        {
            if (File.Exists(suonoBox.Text))
            {
                PlayAudio playAudio = new PlayAudio(suonoBox.Text);
                NavigationControl.showDialog(playAudio);
            }
            else MessageBox.Show("Il file non esiste piu'");
        }

        private void PreviewVideo_Click(object sender, EventArgs e)
        {
            if (File.Exists(videoBox.Text))
            {
                PlayVideo playVideo = new PlayVideo(videoBox.Text);
                NavigationControl.showDialog(playVideo);
            }
            else MessageBox.Show("Il file non esiste piu'");
        }

        private void PreviewImmagine_Click(object sender, EventArgs e)
        {
            if (File.Exists(immagineBox.Text))
            {
                control.anteprimaImmagine(immagineBox.Text);
            }
            else MessageBox.Show("Il file non esiste piu'");
        }

        private void PreviewTesto_Click(object sender, EventArgs e)
        {
            if (File.Exists(testoBox.Text))
            {
                control.anteprimaTesto(testoBox.Text);
            }
            else MessageBox.Show("Il file non esiste piu'");
        }
        
        private void home_Click(object sender, EventArgs e)
        {
            NavigationControl.goHome(this);
        }

        private void ok_Click(object sender, EventArgs e)
        {
            //verifico che tutti i dati necessari siano stati inseriti correttamente
            if (nomeBox.Text == "") MessageBox.Show("Devi inserire un nome per il contenuto!");
            else if (nomeBox.Text.Length > 15) MessageBox.Show("Il nome può essere al massimo di 15 lettere o numeri");
            else if (nomeBox.Text == "Play") MessageBox.Show("Il nome non puo essere Play");
            else if (nomeBox.Text == "Pausa") MessageBox.Show("Il nome non puo essere Pausa");
            else if (nomeBox.Text == "Stop") MessageBox.Show("Il nome non puo essere Stop");
            else if (suonoBox.Text == "" && videoBox.Text == "") MessageBox.Show("Devi inserire almeno un contenuto fra suono e video");
            else if (suonoBox.Text != "" && videoBox.Text != "") MessageBox.Show("Non puoi inserire insieme un suono e un video, cancellane uno dei due");
            else
            {
                //caso 1: contenuto nuovo
                if (Global.isEmpty(contenuto.getNomeContenuto()))
                {
                    //verifico che il nome non sia già stato utilizzato per un altro contenuto
                    if (control.getIndexFromNomeContenuto(listaContenuti, nomeBox.Text) >= 0)
                    {
                        MessageBox.Show("Esiste già un componente con questo nome!");
                        return;
                    }
                    else
                    {
                        aggiornaContenuto();
                        listaContenuti.Add(contenuto);
                    }
                }
                //caso 2: contenuto in modifica
                else if (listaContenuti.Contains(contenuto))
                {
                    //se il nome non è stato modificato aggiorno direttamente
                    if (nomeBox.Text.Equals(contenuto.getNomeContenuto()))
                    {
                        aggiornaContenuto();
                    }
                    else
                    {
                        //verifico che il nome non sia già stato utilizzato per un altro contenuto
                        if (control.getIndexFromNomeContenuto(listaContenuti, nomeBox.Text) >= 0)
                        {
                            MessageBox.Show("Esiste già un componente con questo nome!");
                            return;
                        }
                        else
                        {
                            aggiornaContenuto();
                        }
                    }
                }
                NavigationControl.goBack(this);
            }
        }

        /// <summary>
        /// Metodo per l'aggiornamento del contenuto in base ai file che sono stati scelti nella dialog
        /// </summary>
        private void aggiornaContenuto()
        {
            contenuto.setNomeContenuto(nomeBox.Text);
            contenuto.setAudioPath(suonoBox.Text);
            contenuto.setVideoPath(videoBox.Text);
            contenuto.setImagePath(immagineBox.Text);
            contenuto.setTextPath(testoBox.Text);
        }

        private void annulla_Click(object sender, EventArgs e)
        {
            NavigationControl.goBack(this);
        }

        private void help_Click(object sender, EventArgs e)
        {
            HelpFormSchema helpForm = new HelpFormSchema("Grazie ai bottoni laterali puoi inoltre eliminare o vedere/sentire un'anteprima del contenuto scelto.\nE' obbligatorio inserire un suono o un video. NON è consentito inserire ENTRAMBI. Se vuoi puoi selezionare dei contenuti da stampare: un immagine, del testo o entrambi. Nel caso scegliessi entrambi, verranno stampati uno dopo l'altro nella stessa pagina se possibile, altrimenti il testo continuerà nelle pagine seguenti.\nAttenzione: il testo da inserire può essere un semplice documento di testo oppure un file Word.");
            NavigationControl.showDialog(helpForm);
        }

    }
}
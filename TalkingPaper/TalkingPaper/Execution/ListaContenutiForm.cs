using System;
using TalkingPaper.Common;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace TalkingPaper.Execution
{
    public partial class ListaContenutiForm : FormSchema
    {
        private ControlLogic.ExecutionControl control;
        private List<Model.Contenuto> listaContenuti;
        private string nomePoster;
        private string contenutoSelezionato;
        private Label lastLabelClicked;
        

        public ListaContenutiForm(string nomePoster)
        {
            InitializeComponent();

            control = new ControlLogic.ExecutionControl();
            this.nomePoster = nomePoster;
            
            caricaLista();
        }

        /// <summary>
        /// Carica una lista di contenuti che è possibile stampare
        /// </summary>
        private void caricaLista()
        {
            try
            {
                Model.Poster poster;
                int i = 0;
                noContenuti.Visible = true;
                anteprima.Visible = false;
                stampa.Visible = false;

                poster = control.getPoster(nomePoster);

                listaContenuti = poster.getContenuti();

                if (!(listaContenuti == null) && !(listaContenuti.Count == 0))
                {
                    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListaContenutiForm));
                    foreach (Model.Contenuto contenuto in listaContenuti)
                    {
                        //verifico che siano contenuti validi
                        if (!(contenuto.getNomeContenuto().Equals("Play")) && !(contenuto.getNomeContenuto().Equals("Pausa")) && !(contenuto.getNomeContenuto().Equals("Stop"))
                            && (Global.isNotEmpty(contenuto.getTextPath()) || Global.isNotEmpty(contenuto.getImagePath())))
                        {
                            noContenuti.Visible = false;
                            anteprima.Visible = true;
                            stampa.Visible = true;

                            Label nome = new Label();
                            nome.Text = contenuto.getNomeContenuto();
                            nome.Tag = contenuto.getNomeContenuto();
                            nome.BackColor = Color.Orange;
                            nome.ForeColor = Color.White;
                            nome.Size = new System.Drawing.Size(550, 30);
                            nome.AutoSize = false;
                            nome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            nome.Location = new System.Drawing.Point(25, 5 + i * 45);
                            nome.TextAlign = ContentAlignment.MiddleLeft;
                            nome.Click += new EventHandler(nome_Click);
                            nome.Visible = true;
                            

                            pannello.Controls.Add(nome);

                            if (Global.isNotEmpty(contenuto.getImagePath()))
                            {
                                Label immagine = new Label();
                                immagine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                                immagine.Image = new Bitmap(((System.Drawing.Image)(resources.GetObject("immagine_img.Image"))), 30, 30);
                                immagine.Size = new Size(30, 30);
                                immagine.Location = new System.Drawing.Point(600, 5 + i * 45);
                                pannello.Controls.Add(immagine);
                            }
                            if (Global.isNotEmpty(contenuto.getTextPath()))
                            {
                                Label immagine = new Label();
                                immagine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                                immagine.Image = new Bitmap(((System.Drawing.Image)(resources.GetObject("immagine_testo.Image"))), 30, 30);
                                immagine.Size = new Size(30, 30);
                                immagine.Location = new System.Drawing.Point(650, 5 + i * 45);
                                pannello.Controls.Add(immagine);
                            }

                            
                            i++;
                        }
                    }
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        void nome_Click(object sender, EventArgs e)
        {
            if (lastLabelClicked != null) lastLabelClicked.BackColor = System.Drawing.Color.Orange;


            if (lastLabelClicked == ((Label)sender))
                lastLabelClicked = null;
            else
            {
                ((Label)sender).BackColor = System.Drawing.Color.Red;
                lastLabelClicked = ((Label)sender);
            }
        }

        void stampa_Click(object sender, EventArgs e)
        {
            if (lastLabelClicked != null)
            {
                try
                {
                    contenutoSelezionato = (string)lastLabelClicked.Tag;
                    Model.Contenuto contenuto = control.getPoster(nomePoster).getContenutoFromName(contenutoSelezionato);
                    if (contenuto != null)
                    {
                        //se il contenuto contiene solo testo
                        if ((Global.isNotEmpty(contenuto.getTextPath())) && (Global.isEmpty(contenuto.getImagePath())))
                        {
                            if (File.Exists(contenuto.getTextPath()))
                            {
                                try
                                {
                                    control.stampaTesto(contenuto.getTextPath(), contenuto.getCoordinate());
                                }
                                catch (UnauthorizedAccessException)
                                {
                                    MessageBox.Show("Accesso non autorizzato alla risorsa " + contenuto.getTextPath());
                                }
                            }
                            else MessageBox.Show("Il file " + contenuto.getTextPath() + " non esiste più");
                        }
                        //se il contenuto contiene solo una immagine
                        else if ((Global.isNotEmpty(contenuto.getImagePath())) && (Global.isEmpty(contenuto.getTextPath())))
                        {
                            if (File.Exists(contenuto.getImagePath()))
                            {
                                try
                                {
                                    control.stampaImmagine(contenuto.getImagePath(), contenuto.getCoordinate());
                                }
                                catch (UnauthorizedAccessException)
                                {
                                    MessageBox.Show("Accesso non autorizzato alla risorsa " + contenuto.getTextPath());
                                }
                            }
                            else MessageBox.Show("Il file " + contenuto.getImagePath() + " non esiste più");
                        }
                        //se il contenuto contiene sia testo che immagine
                        else if ((Global.isNotEmpty(contenuto.getImagePath())) && (Global.isNotEmpty(contenuto.getTextPath())))
                        {
                            if (File.Exists(contenuto.getTextPath()) && File.Exists(contenuto.getImagePath()))
                            {
                                try
                                {
                                    control.stampaTestoImmagine(contenuto.getTextPath(), contenuto.getImagePath(), contenuto.getCoordinate());
                                }
                                catch (UnauthorizedAccessException)
                                {
                                    MessageBox.Show("Accesso non autorizzato alla risorsa " + contenuto.getTextPath());
                                }
                            }
                            else if (!File.Exists(contenuto.getTextPath())) MessageBox.Show("Il file " + contenuto.getTextPath() + " non esiste più");
                            else MessageBox.Show("Il file " + contenuto.getImagePath() + " non esiste più");
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }

            }
            else { MessageBox.Show("Non hai selezionato un contenuto"); }
        }

        void anteprima_Click(object sender, EventArgs e)
        {
            if (lastLabelClicked != null)
            {
                try
                {
                    contenutoSelezionato = (string)lastLabelClicked.Tag;
                    Model.Contenuto contenuto = control.getPoster(nomePoster).getContenutoFromName(contenutoSelezionato);
                    if (contenuto != null)
                    {
                        //se il contenuto contiene solo testo
                        if ((Global.isNotEmpty(contenuto.getTextPath())) && (Global.isEmpty(contenuto.getImagePath())))
                        {
                            if (File.Exists(contenuto.getTextPath()))
                            {
                                try
                                {
                                    control.anteprimaTesto(contenuto.getTextPath(), contenuto.getCoordinate());
                                }
                                catch (UnauthorizedAccessException)
                                {
                                    MessageBox.Show("Accesso non autorizzato alla risorsa " + contenuto.getTextPath());
                                }
                            }
                            else MessageBox.Show("Il file " + contenuto.getTextPath() + " non esiste più");
                        }
                        //se il contenuto contiene solo una immagine
                        else if ((Global.isNotEmpty(contenuto.getImagePath())) && (Global.isEmpty(contenuto.getTextPath())))
                        {
                            if (File.Exists(contenuto.getImagePath()))
                            {
                                try
                                {
                                    control.anteprimaImmagine(contenuto.getImagePath(), contenuto.getCoordinate());
                                }
                                catch (UnauthorizedAccessException)
                                {
                                    MessageBox.Show("Accesso non autorizzato alla risorsa " + contenuto.getTextPath());
                                }
                            }
                            else MessageBox.Show("Il file " + contenuto.getImagePath() + " non esiste più");
                        }
                        //se il contenuto contiene sia testo che immagine
                        else if ((Global.isNotEmpty(contenuto.getTextPath())) && (Global.isNotEmpty(contenuto.getImagePath())))
                        {
                            if (File.Exists(contenuto.getTextPath()) && File.Exists(contenuto.getImagePath()))
                            {
                                try
                                {
                                    control.anteprimaTestoImmagine(contenuto.getTextPath(), contenuto.getImagePath(), contenuto.getCoordinate());
                                }
                                catch (UnauthorizedAccessException)
                                {
                                    MessageBox.Show("Accesso non autorizzato alla risorsa " + contenuto.getTextPath());
                                }
                            }
                            else if (!File.Exists(contenuto.getTextPath())) MessageBox.Show("Il file " + contenuto.getTextPath() + " non esiste più");
                            else MessageBox.Show("Il file " + contenuto.getImagePath() + " non esiste più");
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }

            }
            else
            {
                MessageBox.Show("Non hai selezionato un contenuto");
            }
        }

        

        private void ok_Click(object sender, EventArgs e)
        {
            NavigationControl.goHome(this);
        }
       
        private void annulla_Click(object sender, EventArgs e)
        {
            NavigationControl.goBack(this);
        }

        private void home_Click(object sender, EventArgs e)
        {
            NavigationControl.goHome(this);
        }

        private void help_Click(object sender, EventArgs e)
        {
            HelpFormSchema helpForm = new HelpFormSchema("Grazie al pulsante \"Anteprima\", puoi controllare se testi e immagini scelti verranno stampati come desideri. \nPremendo il pulsante \"Stampa\", invece, si aprirà una nuova finestra che permetterà di eseguire la stampa vera e propria.");
            NavigationControl.showDialog(helpForm);
        }

                
    }
}
using System;
using TalkingPaper.Common;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

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
                            nome.Text = contenuto.getNomeContenuto() + " (" + (contenuto.getAudioPath() != null ? 'A'.ToString() : "") + (contenuto.getVideoPath() != null ? 'V'.ToString() : "") + (contenuto.getImagePath() != null ? " I" : "") + (contenuto.getTextPath() != null ? " T" : "") + ")";
                            nome.Tag = contenuto.getNomeContenuto();
                            nome.BackColor = Color.Orange;
                            nome.ForeColor = Color.White;
                            nome.Size = new System.Drawing.Size(500, 30);
                            nome.AutoSize = false;
                            nome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            nome.Location = new System.Drawing.Point(25, 5 + i * 45);
                            nome.TextAlign = ContentAlignment.MiddleLeft;
                            nome.Click += new EventHandler(nome_Click);
                            nome.Visible = true;
                            
                            pannello.Controls.Add(nome);

                            
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
                        if ((Global.isNotEmpty(contenuto.getTextPath())) && (Global.isEmpty(contenuto.getImagePath())))
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
                        else if ((Global.isNotEmpty(contenuto.getTextPath())) && (Global.isEmpty(contenuto.getTextPath())))
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
                        else if ((Global.isNotEmpty(contenuto.getTextPath())) && (Global.isNotEmpty(contenuto.getTextPath())))
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
                        if ((Global.isNotEmpty(contenuto.getTextPath())) && (Global.isEmpty(contenuto.getImagePath())))
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
                        else if ((Global.isNotEmpty(contenuto.getTextPath())) && (Global.isEmpty(contenuto.getTextPath())))
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
                        else if ((Global.isNotEmpty(contenuto.getTextPath())) && (Global.isNotEmpty(contenuto.getTextPath())))
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
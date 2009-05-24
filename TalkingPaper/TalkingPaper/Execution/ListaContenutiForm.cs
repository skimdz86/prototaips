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

                poster = control.getPoster(nomePoster);

                listaContenuti = poster.getContenuti();

                if (!(listaContenuti == null) && !(listaContenuti.Count == 0))
                {
                    foreach (Model.Contenuto contenuto in listaContenuti)
                    {
                        //verifico che siano contenuti validi
                        if (!(contenuto.getNomeContenuto().Equals("Play")) && !(contenuto.getNomeContenuto().Equals("Pausa")) && !(contenuto.getNomeContenuto().Equals("Stop"))
                            && !((contenuto.getTextPath() == null) && (contenuto.getImagePath() == null)))
                        {
                            noContenuti.Visible = false;
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
                            nome.Visible = true;

                            Button stampa = new Button();
                            stampa.Text = "Anteprima e Stampa";
                            stampa.Tag = nome.Tag;
                            stampa.BackColor = System.Drawing.Color.Yellow;
                            stampa.Cursor = System.Windows.Forms.Cursors.Hand;
                            stampa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold);
                            stampa.Location = new System.Drawing.Point(550, i * 45);
                            stampa.Size = new System.Drawing.Size(240, 40);
                            stampa.Click += new EventHandler(stampa_Click);
                            stampa.Visible = true;

                            pannello.Controls.Add(nome);

                            pannello.Controls.Add(stampa);
                            i++;
                        }
                    }
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        void stampa_Click(object sender, EventArgs e)
        {
            try
            {
                contenutoSelezionato = (string)((Button)sender).Tag;
                Model.Contenuto contenuto = control.getPoster(nomePoster).getContenutoFromName(contenutoSelezionato);
                if (contenuto != null)
                {
                    if (((contenuto.getTextPath() != null) && !(contenuto.getTextPath().Equals(""))) && ((contenuto.getImagePath() == null) || (contenuto.getImagePath().Equals(""))))
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
                    else if (((contenuto.getImagePath() != null) && !(contenuto.getImagePath().Equals(""))) && ((contenuto.getTextPath() == null) || (contenuto.getTextPath().Equals(""))))
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
                    else if (((contenuto.getImagePath() != null) && !(contenuto.getImagePath().Equals(""))) && ((contenuto.getTextPath() != null) && !(contenuto.getTextPath().Equals(""))))
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

        

        private void ok_Click(object sender, EventArgs e)
        {
            
        }
       
        private void annulla_Click(object sender, EventArgs e)
        {
            NavigationControl.goBack(this);
        }

        private void home_Click(object sender, EventArgs e)
        {
            NavigationControl.goHome(this);
        }

        
    }
}
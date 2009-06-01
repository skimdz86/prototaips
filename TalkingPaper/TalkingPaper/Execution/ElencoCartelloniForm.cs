using System.Collections.Generic;
using System.Windows.Forms;
using System;
using TalkingPaper.Common;
using System.Drawing;

namespace TalkingPaper.Execution
{
    public partial class ElencoCartelloniForm : FormSchema
    {
        private List<Model.Poster> listaPoster;
        private string posterSelezionato;
        private Label lastLabelClicked;
        private ControlLogic.ExecutionControl control;

        public ElencoCartelloniForm()
        {
            InitializeComponent();

            control = new ControlLogic.ExecutionControl();

            ok.Cursor = Cursors.Default;
            ok.Enabled = false;

            caricaLista();
        }

        /// <summary>
        /// Metodo per caricare all'interno di un pannello la lista dei cartelloni creati
        /// </summary>
        private void caricaLista()
        {
            try
            {
                int i = 0;
                noPoster.Visible = false;
                listaPoster = control.getListaPoster();
                if (listaPoster == null)
                {
                    noPoster.Visible = true;
                }
                else
                {
                    foreach (Model.Poster poster in listaPoster)
                    {
                        Label nome = new Label();
                        if (poster.getUsername() != "")
                        {
                            nome.Text = poster.getNome() + " ( " + poster.getDescrizione() + " )" + "  Classe: " + poster.getUsername() + "";
                        }
                        else { nome.Text = poster.getNome() + " ( " + poster.getDescrizione() + " )"; }
                        nome.Tag = poster.getNome();
                        nome.BackColor = Color.Orange;
                        nome.ForeColor = Color.White;
                        nome.Size = new System.Drawing.Size(907, 25);
                        nome.AutoSize = false;
                        nome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        nome.Click += new System.EventHandler(poster_Click);
                        nome.Location = new System.Drawing.Point(25, 5 + i++ * 35);
                        nome.Visible = true;

                        pannello.Controls.Add(nome);
                    }
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        private void ok_Click(object sender, EventArgs e)
        {
            if (posterSelezionato != null)
            {
                EsecuzioneCartelloneForm esecuzione = new EsecuzioneCartelloneForm(posterSelezionato);
                NavigationControl.goTo(this, esecuzione);
            }
            else
            {
                //throw new Exception("Errore sul controllo del tasto ok");
                MessageBox.Show("Errore sul controllo del tasto ok");
            }
        }

        private void annulla_Click(object sender, EventArgs e)
        {
            NavigationControl.goBack(this);
        }

        private void home_Click(object sender, EventArgs e)
        {
            NavigationControl.goHome(this);
        }

        private void ElencoCartelloniForm_VisibleChanged(object sender, EventArgs e)
        {
            //aggiornamento della grafica quando la finestra diventa visibile
            if (Visible)
            {
                pannello.Controls.Clear();
                ok.Enabled = false;
                ok.Cursor = Cursors.Default;
                caricaLista();
            }
        }

        private void poster_Click(object sender, System.EventArgs e)
        {
            posterSelezionato = (string)((Label)sender).Tag;

            if (lastLabelClicked != null) lastLabelClicked.BackColor = System.Drawing.Color.Orange;
            ((Label)sender).BackColor = System.Drawing.Color.Red;
            lastLabelClicked = ((Label)sender);

            ok.Enabled = true;
            ok.Cursor = Cursors.Hand;
        }

        private void help_Click(object sender, EventArgs e)
        {
            HelpFormSchema helpForm = new HelpFormSchema("");
            NavigationControl.showDialog(helpForm);
        }
    }
}
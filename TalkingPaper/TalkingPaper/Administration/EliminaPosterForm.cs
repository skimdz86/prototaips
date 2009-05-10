using System;
using TalkingPaper.Common;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace TalkingPaper.Administration
{
    public partial class EliminaPosterForm : Common.FormSchema
    {
        private ControlLogic.AdministrationControl control;
        private List<Model.Poster> listaPoster;
        private string posterSelezionato;
        private Label lastLabelClicked;

        private char[] alfabeto = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'Z' };

        public EliminaPosterForm()
        {
            InitializeComponent();

            elimina.Cursor = Cursors.Default;
            annulla.Cursor = Cursors.Hand;
            elimina.Enabled = false;

            control = new ControlLogic.AdministrationControl();
            
            caricaLista();
        }

        private void caricaLista()
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
                    nome.Text = poster.getNome() + " ( " + poster.getDescrizione() + " )";
                    nome.Tag = poster.getNome();
                    nome.BackColor = Color.Orange;
                    nome.ForeColor = Color.White;
                    nome.Size = new System.Drawing.Size(175, 25);
                    nome.AutoSize = false;
                    nome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    nome.Click += new System.EventHandler(poster_Click);
                    nome.Location = new System.Drawing.Point(25, 5 + i++ * 35);
                    nome.Visible = true;

                    pannello.Controls.Add(nome);
                }
            }

        }

        private void elimina_Click(object sender, EventArgs e)
        {
            if (posterSelezionato != null)
            {
                control.rimuoviPoster(posterSelezionato);
                pannello.Controls.Clear();
                elimina.Enabled = false;
                elimina.Cursor = Cursors.Default;
                caricaLista();
            }
            else
            {
                throw new Exception("Errore sul controllo del tasto ok");
            }
        }

        private void annulla_Click(object sender, EventArgs e)
        {
            NavigationControl.goBack(this);
        }

        private void poster_Click(object sender, System.EventArgs e)
        {
            posterSelezionato = (string)((Label)sender).Tag;

            if (lastLabelClicked != null) lastLabelClicked.BackColor = System.Drawing.Color.Orange;
            ((Label)sender).BackColor = System.Drawing.Color.Red;
            lastLabelClicked = ((Label)sender);

            elimina.Enabled = true;
            elimina.Cursor = Cursors.Hand;
        }
    }
}
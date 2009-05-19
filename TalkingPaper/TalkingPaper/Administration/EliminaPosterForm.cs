using System;
using TalkingPaper.Common;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace TalkingPaper.Administration
{
    public partial class EliminaPosterForm : FormSchema
    {
        private ControlLogic.AdministrationControl control;
        private List<Model.Poster> listaPoster;
        private string posterSelezionato;
        private Label lastLabelClicked;

        public EliminaPosterForm()
        {
            InitializeComponent();

            ok.Cursor = Cursors.Default;
            ok.Enabled = false;

            control = new ControlLogic.AdministrationControl();
            
            //caricaLista();
        }

        private void caricaLista()
        {
            int i = 0;
            noPoster.Visible = false;
            listaPoster = control.getListaPoster();
            if ((listaPoster == null) || (listaPoster.Count == 0))
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
                    nome.Size = new System.Drawing.Size(500, 25);
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
                QuestionSchema question = new QuestionSchema("Vuoi eliminare il poster " + posterSelezionato + " ?", this,null);
                NavigationControl.showDialog(question);
                
                
            }
            else
            {
                throw new Exception("Errore sul controllo del tasto ok");
            }
        }
        public void questionAnswer(string param,string response)
        {
            if (response.Equals("yes"))
            {
                bool result;
                result = control.rimuoviPoster(posterSelezionato);
                if (result == false)
                {
                    throw new Exception("Impossibile eliminare il poster");
                }
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

            ok.Enabled = true;
            ok.Cursor = Cursors.Hand;
        }

        private void home_Click(object sender, EventArgs e)
        {
            NavigationControl.goHome(this);
        }

        private void EliminaPosterForm_Activated(object sender, EventArgs e)
        {
            if (Visible)
            {
                pannello.Controls.Clear();
                ok.Enabled = false;
                ok.Cursor = Cursors.Default;
                caricaLista();
            }
        }
    }
}
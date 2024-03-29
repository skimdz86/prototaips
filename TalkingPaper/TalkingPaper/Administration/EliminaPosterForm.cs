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
            try
            {
                InitializeComponent();

                ok.Cursor = Cursors.Default;
                ok.Enabled = false;

                control = new ControlLogic.AdministrationControl();
                
                //caricaLista();
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }
        /// <summary>
        /// Crea la lista dei poster trovati
        /// </summary>
        private void caricaLista()
        {
            try
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

        private void elimina_Click(object sender, EventArgs e)
        {
            if (posterSelezionato != null)
            {
                QuestionSchema question = new QuestionSchema("Vuoi eliminare il poster " + posterSelezionato + " ?", this,null);
                NavigationControl.showDialog(question);
                
                
            }
            else
            {
                MessageBox.Show("Errore sul controllo del tasto ok");
            }
        }
        /// <summary>
        /// Cancella il poster selezionato se la risposta nel dialog � stata positiva
        /// </summary>
        /// <param name="param"></param>
        /// <param name="response"></param>
        public void questionAnswer(string param,string response)
        {
            Model.Poster pTemp = control.getPoster(posterSelezionato);//serve come backup del poster in caso di errori
            try
            {
                if (response.Equals("yes"))
                {
                    bool result;
                    result = control.rimuoviPoster(posterSelezionato);
                    if (result == false)
                    {
                        throw new Exception("Impossibile eliminare il poster");
                    }
                    if (System.IO.Directory.Exists(Global.directoryPrincipale + "\\Poster\\" + posterSelezionato + "\\")) System.IO.Directory.Delete(Global.directoryPrincipale + "\\Poster\\" + posterSelezionato + "\\", true);//cancella la cartella con i contenuti associati
                    
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); control.salvaPoster(pTemp); /*� il restore del poster se c'� errore nella delete directory*/}
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
            try
            {
                if (Visible)
                {
                    pannello.Controls.Clear();
                    ok.Enabled = false;
                    ok.Cursor = Cursors.Default;
                    caricaLista();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void help_Click(object sender, EventArgs e)
        {
            HelpFormSchema helpForm = new HelpFormSchema("Attenzione: l'eliminazione del cartellone � definitiva, e verranno cancellati anche tutti i contenuti associati ad esso.");
            NavigationControl.showDialog(helpForm);
        }
    }
}
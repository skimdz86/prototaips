using System;
using TalkingPaper.Common;
using TalkingPaper.Model;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;

namespace TalkingPaper.Authoring
{
    public partial class ModificaCartelloneForm : FormSchema
    {
        private Label lastLabelClicked;

        public ModificaCartelloneForm()
        {
            InitializeComponent();
            caricaElencoPoster();
        }

        private void home_Click(object sender, EventArgs e)
        {
            NavigationControl.goHome(this);
        }

        private void annulla_Click(object sender, EventArgs e)
        {
            NavigationControl.goBack(this);
        }

        /// <summary>
        /// Carica in un pannello la lista dei poster già creati, tra i quali scegliere quello
        /// da modificare
        /// </summary>
        private void caricaElencoPoster()
        {
            try
            {
                List<Poster> listaPoster = new List<Poster>();

                listaPoster = Global.dataHandler.getListaPoster();

                
                if (listaPoster == null || listaPoster.Count == 0)
                {
                    //se la lista di poster è vuota
                    noPoster.Visible = true;
                }
                else
                {
                    //inserisco tutti i poster presenti in lista all'interno del pannello
                    int i = 0;
                    foreach (Poster p in listaPoster)
                    {
                        Label nome = new Label();
                        if (p.getUsername() != "")
                        {
                            nome.Text = p.getNome() + " ( " + p.getDescrizione() + " )" + "  Classe: " + p.getUsername() + "";
                        }
                        else { nome.Text = p.getNome() + " ( " + p.getDescrizione() + " )"; }
                        nome.Tag = p.getNome();
                        nome.BackColor = Color.Orange;
                        nome.ForeColor = Color.White;
                        nome.Size = new System.Drawing.Size(907, 25);
                        nome.AutoSize = false;
                        nome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        nome.Click += new System.EventHandler(nomePoster_Click);
                        nome.Location = new System.Drawing.Point(25, 5 + i++ * 35);
                        nome.Visible = true;

                        elencoPoster.Controls.Add(nome);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void nomePoster_Click(object sender, EventArgs e)
        {
            if (((Label)sender).BackColor == Color.Red)
            {
                ((Label)sender).BackColor = Color.Orange;
                lastLabelClicked = null;
            }
            else
            {
                if (lastLabelClicked != null) lastLabelClicked.BackColor = System.Drawing.Color.Orange;
                ((Label)sender).BackColor = System.Drawing.Color.Red;
                lastLabelClicked = ((Label)sender);
            }
        }

        private void ok_Click(object sender, EventArgs e)
        {
            try
            {
                if (lastLabelClicked != null)
                {
                    string nomePoster = (String)lastLabelClicked.Tag;
                    Poster p = Global.dataHandler.getPoster(nomePoster);
                    PosizionaComponentiForm posizionaComp = new PosizionaComponentiForm(p.getNome(), p.getDescrizione(), p.getUsername(), p.getNomeGriglia());
                    NavigationControl.goTo(this, posizionaComp);
                }
                else
                {
                    MessageBox.Show("Devi selezionare un cartellone!");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void help_Click(object sender, EventArgs e)
        {
            HelpFormSchema helpForm = new HelpFormSchema("Non è disponibile un aiuto per questa schermata");
            NavigationControl.showDialog(helpForm);
        }


    }
}
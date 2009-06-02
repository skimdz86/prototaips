using System;
using TalkingPaper.Common;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace TalkingPaper.Execution
{
    public partial class ListaPosterForm : FormSchema
    {
        private ControlLogic.ExecutionControl control;
        private List<Model.Poster> listaPoster;
        private string posterSelezionato;
        private Label lastLabelClicked;

        public ListaPosterForm()
        {
            InitializeComponent();

            ok.Cursor = Cursors.Default;
            ok.Enabled = false;

            control = new ControlLogic.ExecutionControl();
            
            caricaLista();
        }

        /// <summary>
        /// Carica una lista di poster tra i quali scegliere quello che contiene i contenuti
        /// che si vuole stampare
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

        private void ok_Click(object sender, EventArgs e)
        {
            if (Global.isNotEmpty(posterSelezionato))
            {
                ListaContenutiForm listaComp = new ListaContenutiForm(posterSelezionato);
                NavigationControl.goTo(this, listaComp);
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

        private void help_Click(object sender, EventArgs e)
        {
            HelpFormSchema helpForm = new HelpFormSchema("Non è disponibile un aiuto per questa schermata");
            NavigationControl.showDialog(helpForm);
        }

        
    }
}
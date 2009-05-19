using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Media;
using System.Xml;
using TalkingPaper.Common;
using TalkingPaper.Model;

namespace TalkingPaper.Authoring
{
    public partial class ModificaCartelloneForm : FormSchema
    {
        //private int id_mostra;
        //private string nome_mostra;
        //private string directory_principale;
        //private Bitmap immagine_modifica_poster;
        //private Bitmap elimina;
        //private List<Model.Poster> poster_authoring;
        //private TalkingPaper.Authoring.PosizionaComponentiForm visualizza_aut;
        //private string id_pannello;
        //private string nome_pannello;
        //private string configurazione;

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

        private void caricaElencoPoster()
        {
            List<Poster> listaPoster = new List<Poster>();

            listaPoster = Global.dataHandler.getListaPoster();

            if (listaPoster == null || listaPoster.Count == 0)
            {
                noPoster.Visible = true;
            }
            else
            {

                int i = 0;
                foreach (Poster p in listaPoster)
                {
                    Label nome = new Label();
                    nome.Text = p.getNome();
                    nome.BackColor = Color.Orange;
                    nome.ForeColor = Color.White;
                    nome.Size = new System.Drawing.Size(500, 25);
                    nome.AutoSize = false;
                    nome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    nome.Click += new System.EventHandler(nomePoster_Click);
                    nome.Location = new System.Drawing.Point(25, 5 + i++ * 35);
                    nome.Visible = true;

                    elencoPoster.Controls.Add(nome);
                }
            }
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
            if (lastLabelClicked != null)
            {
                string nomePoster = lastLabelClicked.Text;
                Poster p = Global.dataHandler.getPoster(nomePoster);

                PosizionaComponentiForm posizionaComp = new PosizionaComponentiForm(p.getNome(), p.getDescrizione(), p.getUsername(), p.getNomeGriglia());
                NavigationControl.goTo(this, posizionaComp);
            }
            else
            {
                //TODO: msgbox: DEVI SELEZIONARE UN POSTER
            }

        }


    }
}
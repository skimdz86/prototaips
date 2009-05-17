using System;
using TalkingPaper.Common;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using TalkingPaper.Model;
using System.Collections.Generic;

namespace TalkingPaper.Authoring
{
    public partial class PosizionaComponentiForm : FormSchema
    {
        private ControlLogic.AuthoringControl control;
        private string nomePoster;
        private string descrizionePoster;
        private string nomeClasse;
        private string nomeGriglia;
        private Model.Griglia griglia;


        //private FormScegliPosterAuthoring scelta_poster;
        //private BenvenutoAuthoring partenza;

        private String directoryPrincipale = "../..";//temporaneo, per farlo andare
        
        private Bitmap pausa;
        private Bitmap stop;
        private Bitmap riprendi;
        private Bitmap taggato;
        private Bitmap non_taggato;
        private Label lastLabelClicked;
    
        private int id_contenuto_selezionato;
        private string nome_contenuto_selezionato;
        private int num_colonne;
        private int num_righe;
            
        
        private ArrayList cont_modificati = new ArrayList();


        //occhio a queste!!!
        private int id_mosta;
        private Authoring.ModificaCartelloneForm posterMostra;
        private string provenienza;

        
        private Contenuto contenuto;
        private List<Contenuto> listaContenuti = new List<Contenuto>();


        public PosizionaComponentiForm(string nomePoster, string descrizionePoster, string nomeClasse, string nomeGriglia)
        {
            InitializeComponent();

            this.nomePoster = nomePoster;
            this.descrizionePoster = descrizionePoster;
            this.nomeClasse = nomeClasse;
            this.nomeGriglia = nomeGriglia;

            control = new ControlLogic.AuthoringControl();

            if ((nomeGriglia == null) || (nomeGriglia.Equals("")))
            {
                throw new Exception("Non � stata selezionata una griglia");
            }
            else griglia = control.getGriglia(nomeGriglia);

            taggato = new Bitmap(directoryPrincipale + "/Images/Icons/virgoletta.gif");
            non_taggato = new Bitmap(directoryPrincipale + "/Images/Icons/non_taggato.gif");
            pausa = new Bitmap(directoryPrincipale + "/Images/Pause.png");
            stop = new Bitmap(directoryPrincipale + "/Images/Stop.png");
            riprendi = new Bitmap(directoryPrincipale + "/Images/Play.png");
            taggato = new Bitmap(Global.directoryPrincipale + "/Images/Icons/virgoletta.gif");
            non_taggato = new Bitmap(Global.directoryPrincipale + "/Images/Icons/non_taggato.gif");
            pausa = new Bitmap(Global.directoryPrincipale + "/Images/Pause.png");
            stop = new Bitmap(Global.directoryPrincipale + "/Images/Stop.png");
            riprendi = new Bitmap(Global.directoryPrincipale + "/Images/Play.png");

            contenuto = new Contenuto();

            

            //TODO
            //inizializzare listaContenuti (con i cont del poster)
            //

            disegnaGriglia();

            //controllo se il poster 'nomePoster' esiste gi�: non dovrebbe servire piu
           // bool b = Global.dataHandler.existPoster(nomePoster);
           // if (b) 
           // {
                Poster p = Global.dataHandler.getPoster(nomePoster);
                if (p.getNome() != null)
                {
                    listaContenuti = p.getContenuti();
                    listaContenuti.AddRange(p.getContenuti());
                    riempiGriglia(p);
                }
           // }

           /* if (p != null)
            {
                if (p.getNome() != null)
                {
                    listaContenuti = p.getContenuti();
                    riempiGriglia(p);
                }
            }
            p = null;*/  //Ma p=null a che serviva???

            ricaricaElencoRisorse();

        }

        private void riempiGriglia(Poster p)
        {
            foreach (Contenuto c in listaContenuti)
            {
                string coord = c.getCoordinate();
                
                if (coord.Equals("00") || coord.Equals("") || coord == null) throw new Exception("Contenuto non previsto");

                int col = coord[0] - 'A' + 1;
                int row = coord[1] - '1' + 1;

                schemaGriglia[col, row].Value = c.getNomeContenuto();
            }
        }

        private void nomeRisorsa_Click(object sender, System.EventArgs e)
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

        private void ricaricaElencoRisorse()
        {
            int i = 0;
            foreach (Contenuto c in listaContenuti)
            {
                Label nome = new Label();
                nome.Text = c.getNomeContenuto() + "(" + (c.getAudioPath() != null ? 'A'.ToString() : "") + (c.getVideoPath() != null ? 'V'.ToString() : "") + (c.getImagePath() != null ? " I" : "") + (c.getTextPath() != null ? " T" : "")+")";
                nome.Tag = c.getNomeContenuto();
                nome.BackColor = Color.Orange;
                nome.ForeColor = Color.White;
                nome.Size = new System.Drawing.Size(175, 25);
                nome.AutoSize = false;
                nome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                nome.Click += new System.EventHandler(nomeRisorsa_Click);
                nome.Location = new System.Drawing.Point(25, 5 + i++ * 35);
                nome.Visible = true;
                nome.MouseDown += new MouseEventHandler(label_MouseDown);

                ElencoRisorse.Controls.Add(nome);
            }

        }

        private void disegnaGriglia()
        {
            schemaGriglia.Rows.Clear();
            schemaGriglia.Columns.Clear();

            schemaGriglia.ColumnCount = griglia.getNumColonne() + 1;
            schemaGriglia.Rows.Add(griglia.getNumRighe() + 1);

            schemaGriglia.Rows[0].Height = 35;
            schemaGriglia.Columns[0].Width = 50;

            schemaGriglia[0, 0].Style.BackColor = Color.ForestGreen;
            schemaGriglia[0, 0].Style.SelectionBackColor = Color.ForestGreen;

            Font font = new Font("Arial", 16);

            //header righe
            for (int i = 1; i <= griglia.getNumRighe(); i++)
            {
                schemaGriglia[0, i].Value = i;
                schemaGriglia[0, i].Style.Font = font;
                schemaGriglia[0, i].Style.BackColor = Color.ForestGreen;
                schemaGriglia[0, i].Style.SelectionBackColor = Color.ForestGreen;
            }

            //header colonne
            for (int j = 1; j <= griglia.getNumColonne(); j++)
            {
                schemaGriglia.Columns[j].Width = 120;
                schemaGriglia[j, 0].Value = (char)('A' + j - 1);
                schemaGriglia[j, 0].Style.Font = font;
                schemaGriglia[j, 0].Style.BackColor = Color.ForestGreen;
                schemaGriglia[j, 0].Style.SelectionBackColor = Color.ForestGreen;
            }

            //singole celle
            font = new Font("Arial", 12);
            for (int i = 0; i < (griglia.getNumRighe() * griglia.getNumColonne()); i++)
            {
                int c = (i % griglia.getNumColonne()) + 1;
                int r = (i / griglia.getNumColonne()) + 1;

                //celle valide
                if (!(griglia.getTagFromIndex(i).Equals("")))
                {
                    schemaGriglia[c, r].Style.Font = font;
                    schemaGriglia[c, r].Style.BackColor = Color.White;
                    schemaGriglia[c, r].Style.ForeColor = Color.Black;
                    schemaGriglia[c, r].Style.SelectionBackColor = Color.PowderBlue;
                    schemaGriglia[c, r].Style.SelectionForeColor = Color.Black;
                }
                //celle non valide (no tag)
                else
                {
                    schemaGriglia[c, r].Style.BackColor = Color.Gray;
                    schemaGriglia[c, r].Style.SelectionBackColor = Color.Gray;
                }
            }

            

        }

        private void home_Click(object sender, EventArgs e)
        {
            NavigationControl.goHome(this);
        }

        private void annulla_Click(object sender, EventArgs e)
        {
            NavigationControl.goBack(this);
        }

        private void ok_Click(object sender, EventArgs e)
        {
            Poster poster = new Poster(nomePoster, descrizionePoster, nomeClasse, nomeGriglia);
            List<Contenuto> listaUtile = control.getListWithUsefulContents(listaContenuti);
            poster.setContenuti(listaUtile);

            //TODO: SALVARE IL POSTER IN XML
            //listaUtile contiene solo i contenuti che vanno salvati (perch� associati alla griglia)
            //la dimensione di listaUtile dipende dai contenuti

            Global.dataHandler.removePoster(nomePoster);

            Global.dataHandler.setPoster(poster);

            NavigationControl.goHome(this);
        }

        private void aggiungi_Click(object sender, EventArgs e)
        {
            AggiungiComponenteForm aggiungiComp = new AggiungiComponenteForm(contenuto);
            NavigationControl.goTo(this, aggiungiComp);
        }


        private void PosizionaComponentiForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true && contenuto.getNomeContenuto() != null)
            {
                listaContenuti.Add(new Contenuto(contenuto.getNomeContenuto(),contenuto.getAudioPath(),contenuto.getVideoPath(),contenuto.getImagePath(),contenuto.getTextPath()));
            }
            contenuto.resetContenuto();
            ricaricaElencoRisorse();
        }

        private void schemaGriglia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int col = e.ColumnIndex;
            DataGridView grid = (DataGridView)sender;

            //click su un header
            if (row == 0 || col == 0) return;

            //inserisco un contenuto in una cella
            if (lastLabelClicked != null)
            {
                string nome;
                string coord;
                int index;
                string tag;

                if (lastLabelClicked.Text != "Play" && lastLabelClicked.Text != "Pausa" && lastLabelClicked.Text != "Stop")
                {
                    int x = lastLabelClicked.Text.IndexOf('(');
                    nome = lastLabelClicked.Text.Substring(0, x);      

                    tag = griglia.getTagFromNumericCoord(col, row);

                    //faccio qualcosa solo se posso associare il contenuto alla cella (c'� il tag!)
                    if (tag.Equals("") == false)
                    {
                        index = control.getIndexFromNomeContenuto(listaContenuti, nome);
                        if (index == -1) throw new Exception("Contenuto non trovato in listaContenuti");

                        //il contenuto era gi� associato: cancello l'associazione precedente
                        if (listaContenuti[index].getCoordinate().Equals("00") == false)
                        {
                            coord = listaContenuti[index].getCoordinate();
                            int c = coord[0] - 'A' + 1;
                            int r = coord[1] - '1' + 1;
                            schemaGriglia[c, r].Value = null;
                        }

                        coord = control.getStringCoordFromNumericCoord(col, row);
                        listaContenuti[index].setCoordinate(coord);

                        grid[col, row].Value = nome;
                        lastLabelClicked.BackColor = Color.Orange;
                        lastLabelClicked = null;
                    }
                }
                else 
                { 
                    nome = lastLabelClicked.Text; 
                    tag = griglia.getTagFromNumericCoord(col, row);

                    //faccio qualcosa solo se posso associare il contenuto alla cella (c'� il tag!)
                    if (tag.Equals("") == false)
                    {
                        listaContenuti.Add(new Contenuto(lastLabelClicked.Text,null,null,null,null));
                      //  index = control.getIndexFromNomeContenuto(listaContenuti, nome);
                       // if (index == -1) throw new Exception("Contenuto non trovato in listaContenuti");

                        //il contenuto era gi� associato: cancello l'associazione precedente
                      //  if (listaContenuti[index].getCoordinate().Equals("00") == false)
                     //   {
                      //      coord = listaContenuti[index].getCoordinate();
                        //    int c = coord[0] - 'A' + 1;
                          //  int r = coord[1] - '1' + 1;
                            //schemaGriglia[c, r].Value = null;
                       // }

                        coord = control.getStringCoordFromNumericCoord(col, row);
                        listaContenuti[listaContenuti.Count-1].setCoordinate(coord);

                        grid[col, row].Value = nome;
                        lastLabelClicked.BackColor = Color.Orange;
                        lastLabelClicked = null;
                        }
                }
            }
            //elimino un contenuto da una cella
            else if (lastLabelClicked == null && grid[col, row].Value != null)
            {
                string nome = grid[col, row].Value.ToString();
                int index = control.getIndexFromNomeContenuto(listaContenuti, nome);

                listaContenuti[index].setCoordinate("00");
                grid[col, row].Value = null;
            }


            

        }

        private void label_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ((Label)sender).DoDragDrop(((Label)sender).Tag, DragDropEffects.Move);
                
            }       
        }

        private void schemaGriglia_DragDrop(object sender, DragEventArgs e)
        {
            String nome = e.Data.GetData(DataFormats.Text).ToString();
            Point point = schemaGriglia.PointToClient(new Point(e.X, e.Y));
            DataGridView.HitTestInfo info = schemaGriglia.HitTest(point.X, point.Y);

            int row = info.RowIndex;
            int col = info.ColumnIndex;

            //click su un header
            if (row == 0 || col == 0) return;

            string coord;
            int index;

            string tag = griglia.getTagFromNumericCoord(col, row);

            //faccio qualcosa solo se posso associare il contenuto alla cella (c'� il tag!)
            if (tag.Equals("") == false)
            {
                if ((nome.Equals("Play")) || (nome.Equals("Pausa")) || (nome.Equals("Stop")) )
                {
                    schemaGriglia[col, row].Value = nome;
                }
                else
                {
                    index = control.getIndexFromNomeContenuto(listaContenuti, nome);
                    if (index == -1) throw new Exception("Contenuto non trovato in listaContenuti");

                    //il contenuto era gi� associato: cancello l'associazione precedente
                    if (listaContenuti[index].getCoordinate().Equals("00") == false)
                    {
                        coord = listaContenuti[index].getCoordinate();
                        int c = coord[0] - 'A' + 1;
                        int r = coord[1] - '1' + 1;
                        schemaGriglia[c, r].Value = null;
                    }

                    coord = control.getStringCoordFromNumericCoord(col, row);
                    listaContenuti[index].setCoordinate(coord);

                    schemaGriglia[col, row].Value = nome;
                    lastLabelClicked.BackColor = Color.Orange;
                    lastLabelClicked = null;
                }
            }



        }

        private void schemaGriglia_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        

        private void label1_Click(object sender, EventArgs e)
        {
            lastLabelClicked = label1;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            lastLabelClicked = label2;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            lastLabelClicked = label3;
        }

    }
}
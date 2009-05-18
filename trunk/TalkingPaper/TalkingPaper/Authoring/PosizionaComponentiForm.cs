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
        private int clickOffsetX, clickOffsetY;
        private int posizioneStartX, posizioneStartY;
        private Label dragging;
        private Label lastLabelClicked;
    
        //private FormScegliPosterAuthoring scelta_poster;
        //private BenvenutoAuthoring partenza;

        
        
        
            
        
        private ArrayList cont_modificati = new ArrayList();


        

        
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
                throw new Exception("Non è stata selezionata una griglia");
            }
            else griglia = control.getGriglia(nomeGriglia);

            
         //   taggato = new Bitmap(Global.directoryPrincipale + "/Images/virgoletta.gif");
          //  non_taggato = new Bitmap(Global.directoryPrincipale + "/Images/non_taggato.gif");
            

            contenuto = new Contenuto();

            

            //TODO
            //inizializzare listaContenuti (con i cont del poster)
            //

            disegnaGriglia();

            //controllo se il poster 'nomePoster' esiste già: non dovrebbe servire piu
           // bool b = Global.dataHandler.existPoster(nomePoster);
           // if (b) 
           // {
           Poster p = Global.dataHandler.getPoster(nomePoster);
           if (p.getNome() != null)
           {
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

            

        }

        private void riempiGriglia(Poster p)
        {
            foreach (Contenuto c in listaContenuti)
            {
                int[] coord = c.getCoordinate();
                
                if (coord == null || coord[0] == 0 || coord[1] == 0) throw new Exception("Contenuto non previsto");

                int row = coord[0];
                int col = coord[1];

                schemaGriglia[col, row].Value = c.getNomeContenuto();
            }
        }

        private void ricaricaElencoRisorse()
        {
            ElencoRisorse.Controls.Clear();
            int i = 0;
            foreach (Contenuto c in listaContenuti)
            {
                if ((c.getNomeContenuto() != "Play") && (c.getNomeContenuto() != "Pausa") && (c.getNomeContenuto() != "Stop"))
                {
                    Label nome = new Label();
                    nome.Text = c.getNomeContenuto() + "(" + (c.getAudioPath() != null ? 'A'.ToString() : "") + (c.getVideoPath() != null ? 'V'.ToString() : "") + (c.getImagePath() != null ? " I" : "") + (c.getTextPath() != null ? " T" : "") + ")";
                    nome.Tag = c.getNomeContenuto();
                    nome.BackColor = Color.Orange;
                    nome.ForeColor = Color.White;
                    nome.Size = new System.Drawing.Size(175, 25);
                    nome.AutoSize = false;
                    nome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    nome.Location = new System.Drawing.Point(25, 5 + i++ * 35);
                    nome.Visible = true;
                    nome.MouseDown += new MouseEventHandler(label_MouseDown);
                    ElencoRisorse.Controls.Add(nome);
                }
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
            //listaUtile contiene solo i contenuti che vanno salvati (perchè associati alla griglia)
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
                int[] coord;
                int index;
                string tag;

                if (lastLabelClicked.Text != "Play" && lastLabelClicked.Text != "Pausa" && lastLabelClicked.Text != "Stop")
                {
                    int x = lastLabelClicked.Text.IndexOf('(');
                    nome = lastLabelClicked.Text.Substring(0, x);      

                    tag = griglia.getTagFromNumericCoord(col, row);

                    //faccio qualcosa solo se posso associare il contenuto alla cella (c'è il tag!)
                    if (tag.Equals("") == false)
                    {
                        index = control.getIndexFromNomeContenuto(listaContenuti, nome);
                        if (index == -1) throw new Exception("Contenuto non trovato in listaContenuti");

                        //il contenuto era già associato: cancello l'associazione precedente
                        coord = listaContenuti[index].getCoordinate();
                        if ((coord[0] != 0) && (coord[1] != 0))
                        {
                            
                            int r = coord[0];
                            int c = coord[1];
                            schemaGriglia[c, r].Value = null;
                        }
                        coord = new int[2] { row, col };
                        
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

                    //faccio qualcosa solo se posso associare il contenuto alla cella (c'è il tag!)
                    if (tag.Equals("") == false)
                    {
                      //il contenuto era già associato: cancello l'associazione precedente
                        for (int i = 0; i < listaContenuti.Count; i++) 
                        {
                            if (((Contenuto)listaContenuti[i]).getNomeContenuto() == nome) 
                            {
                                coord = listaContenuti[i].getCoordinate();
                                int r = coord[0];
                                int c = coord[1];
                                schemaGriglia[c, r].Value = null;
                            }
                        }
                       
                        listaContenuti.Add(new Contenuto(lastLabelClicked.Text, null, null, null, null));
                        coord = new int[2] { row, col };
                        listaContenuti[listaContenuti.Count-1].setCoordinate(coord);

                        grid[col, row].Value = nome;
                        lastLabelClicked.BackColor = Color.Orange;
                        lastLabelClicked = null;
                        }
                }
            }
            //elimino un contenuto da una cella
            else if (grid[col, row].Value != null)
            {
                string nome = grid[col, row].Value.ToString();
                int index = control.getIndexFromNomeContenuto(listaContenuti, nome);
                int[] coord = new int[2] { 0, 0 };
                listaContenuti[index].setCoordinate(coord);
                grid[col, row].Value = null;
                grid[col, row].Selected = false;
            }


            

        }

        private void label_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (((Label)sender).Image == null)
                {
                    if (((Label)sender).BackColor == Color.Red)
                    {
                        ((Label)sender).BackColor = Color.Orange;
                        lastLabelClicked = null;
                    }
                    else
                    {
                        if ((lastLabelClicked != null) && (lastLabelClicked.Image == null)) lastLabelClicked.BackColor = System.Drawing.Color.Orange;
                        ((Label)sender).BackColor = Color.Red;
                        lastLabelClicked = ((Label)sender);
                    }
                }
                else
                {
                    if ((lastLabelClicked != null) && (lastLabelClicked.Image == null)) 
                        lastLabelClicked.BackColor = System.Drawing.Color.Orange;
                    lastLabelClicked = ((Label)sender);
                }
                ((Label)sender).DoDragDrop(((Label)sender).Tag, DragDropEffects.Move);
            }       
        }

        private void schemaGriglia_DragDrop(object sender, DragEventArgs e)
        {
            String nome = e.Data.GetData(DataFormats.Text).ToString();
            Point point = schemaGriglia.PointToClient(new Point(e.X,e.Y));
            DataGridView.HitTestInfo info = schemaGriglia.HitTest(point.X,point.Y);

            int row = info.RowIndex;
            int col = info.ColumnIndex;

            //click su un header
            if (row <= 0 || col <= 0) return;

            int[] coord = new int[2];
            int index;

            string tag = griglia.getTagFromNumericCoord(col, row);

            //faccio qualcosa solo se posso associare il contenuto alla cella (c'è il tag!)
            if (tag.Equals("") == false)
            {
                if ((nome.Equals("Play")) || (nome.Equals("Pausa")) || (nome.Equals("Stop")) )
                {
                    nome = lastLabelClicked.Text; 
                    tag = griglia.getTagFromNumericCoord(col, row);

                    //faccio qualcosa solo se posso associare il contenuto alla cella (c'è il tag!)
                    if (tag.Equals("") == false)
                    {

                        //il contenuto era già associato: cancello l'associazione precedente
                        for (int i = 0; i < listaContenuti.Count; i++)
                        {
                            if (((Contenuto)listaContenuti[i]).getNomeContenuto() == nome)
                            {
                                coord = listaContenuti[i].getCoordinate();
                                int r = coord[0];
                                int c = coord[1];
                                schemaGriglia[c, r].Value = null;
                            }
                        }

                        listaContenuti.Add(new Contenuto(lastLabelClicked.Text, null, null, null, null));
                        coord = new int[2] { row, col };
                        listaContenuti[listaContenuti.Count - 1].setCoordinate(coord);

                        schemaGriglia[col, row].Value = nome;
                    }      
                }
                else
                {
                    index = control.getIndexFromNomeContenuto(listaContenuti, nome);
                    if (index == -1) throw new Exception("Contenuto non trovato in listaContenuti");

                    //il contenuto era già associato: cancello l'associazione precedente
                    coord = listaContenuti[index].getCoordinate();
                    if ( (coord[0] != 0) && (coord[1] != 0))
                    {
                        
                        int r = coord[0];
                        int c = coord[1];
                        schemaGriglia[c, r].Value = null;
                    }

                    coord[0] = row;
                    coord[1] = col;
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

        

    }
}
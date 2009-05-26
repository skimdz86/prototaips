using System;
using TalkingPaper.Common;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
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
        
        private Label lastLabelClicked;
    
        
        
        private List<Model.Contenuto> listaContenuti;

        private Model.Contenuto[,] matrix;


        public PosizionaComponentiForm(string nomePoster, string descrizionePoster, string nomeClasse, string nomeGriglia)
        {
            try
            {
                InitializeComponent();

                this.nomePoster = nomePoster;
                this.descrizionePoster = descrizionePoster;
                this.nomeClasse = nomeClasse;
                this.nomeGriglia = nomeGriglia;

                control = new ControlLogic.AuthoringControl();

                if (Global.isEmpty(nomeGriglia))
                {
                    throw new Exception("Non � stata selezionata una griglia");
                }
                else griglia = control.getGriglia(nomeGriglia);

                disegnaGriglia();

                listaContenuti = new List<Model.Contenuto>();
                matrix = new Model.Contenuto[griglia.getNumRighe()+1,griglia.getNumColonne()+1];

                Model.Poster poster = Global.dataHandler.getPoster(nomePoster);

                if ((poster != null) && (poster.getNome() != null))
                {
                    List<Model.Contenuto> contenuti = poster.getContenuti();
                    if (contenuti != null)
                    {
                        foreach (Model.Contenuto contenuto in contenuti)
                        {
                            int[] coord = contenuto.getCoordinate();
                            if (coord != null)
                            {
                                matrix[coord[0], coord[1]] = contenuto;
                                if (!(contenuto.getNomeContenuto().Equals("Play")) && !(contenuto.getNomeContenuto().Equals("Pausa")) && !(contenuto.getNomeContenuto().Equals("Stop")))
                                    listaContenuti.Add(contenuto);
                            }
                        }
                        
                    }
                    
                }
                
                
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        private void riempiGriglia()
        {
            
            for (int i = 1; i <= matrix.GetUpperBound(0); i++)
            {
                for (int j = 1; j <= matrix.GetUpperBound(1); j++)
                {
                    if ((matrix[i, j] != null) && (matrix[i, j].getNomeContenuto() != null))
                        schemaGriglia[j, i].Value = matrix[i, j].getNomeContenuto();
                    else
                        schemaGriglia[j, i].Value = null;
                }
            }
        }

        private void ricaricaElencoRisorse()
        {
            ElencoRisorse.Controls.Clear();
            ElencoRisorse.Columns.Clear();
            ElencoRisorse.Rows.Clear();
            int i = 0;
            foreach (Model.Contenuto contenuto in listaContenuti)
            {
                if (contenuto != null)
                {
                    Label nome = new Label();
                    nome.Text = contenuto.getNomeContenuto() + "(" + (contenuto.getAudioPath() != null ? 'A'.ToString() : "") + (contenuto.getVideoPath() != null ? 'V'.ToString() : "") + (contenuto.getImagePath() != null ? " I" : "") + (contenuto.getTextPath() != null ? " T" : "") + ")";
                    nome.Tag = contenuto.getNomeContenuto();
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
            try
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
                    if (Global.isNotEmpty(griglia.getTagFromIndex(i)))
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
            catch (Exception e) { MessageBox.Show(e.Message); }

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
            try
            {
                Model.Poster poster = new Model.Poster(nomePoster, descrizionePoster, nomeClasse, nomeGriglia);
                List<Model.Contenuto> lista = new List<TalkingPaper.Model.Contenuto>();

                for (int i = 1; i <= matrix.GetUpperBound(0); i++)
                {
                    for (int j = 1; j <= matrix.GetUpperBound(1); j++)
                    {
                        if ((matrix[i, j] != null) && (matrix[i, j].getNomeContenuto() != null))
                            lista.Add(matrix[i, j]);
                    }
                }
                               
                poster.setContenuti(lista);
                
                Global.dataHandler.setPoster(poster);

                NavigationControl.goHome(this);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void aggiungi_Click(object sender, EventArgs e)
        {
            Model.Contenuto contenutoVuoto = new Model.Contenuto();
            AggiungiComponenteForm aggiungiComp = new AggiungiComponenteForm(contenutoVuoto, listaContenuti);
            NavigationControl.goTo(this, aggiungiComp);
        }


        private void PosizionaComponentiForm_VisibleChanged(object sender, EventArgs e)
        {
            lastLabelClicked = null;
                      
            if (this.Visible == true)
            {
                //if ((contenutoTrasferito != null) && Global.isNotEmpty(contenutoTrasferito.getNomeContenuto()) && (!(listaContenuti.Contains(contenutoTrasferito))))
                //    listaContenuti.Add(contenutoTrasferito);
                
                /*int c=0;
                int indexC=-1;
                for (int w = 0; w < listaContenuti.Count; w++)
                {
                    if (contenuto.getCoordinate() == listaContenuti[w].getCoordinate()) { c++; indexC = w; }
                }
                if (c == 0) listaContenuti.Add(new Model.Contenuto(contenuto.getNomeContenuto(), contenuto.getAudioPath(), contenuto.getVideoPath(), contenuto.getImagePath(), contenuto.getTextPath()));
                else if (c > 0) 
                {
                    listaContenuti[indexC] = new Model.Contenuto(contenuto.getNomeContenuto(), contenuto.getAudioPath(), contenuto.getVideoPath(), contenuto.getImagePath(), contenuto.getTextPath());
                    listaContenuti[indexC].setCoordinate(contenuto.getCoordinate());
                    
                }*/
                ricaricaElencoRisorse();
                riempiGriglia();
            }
            
        }

        private void schemaGriglia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int row = e.RowIndex;
                int col = e.ColumnIndex;

                //click su un header
                if (row == 0 || col == 0) return;

                //inserisco un contenuto in una cella
                if (lastLabelClicked != null)
                {
                    String nomeLabel = (string)lastLabelClicked.Tag;

                    lastLabelClicked.BackColor = Color.Orange;

                    aggiuntaComponente(nomeLabel, row, col);
                    riempiGriglia();
                }
                //elimino un contenuto da una cella
                else if (schemaGriglia[col, row].Value != null)
                {
                    schemaGriglia[col, row].Selected = false;
                    matrix[row, col] = null;
                    riempiGriglia();
                }
                lastLabelClicked = null;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }


        private void aggiuntaComponente(String nomeLabel, int row, int col)
        {
            int[] coord;
            Model.Contenuto contenuto;

            //faccio qualcosa solo se posso associare il contenuto alla cella (c'� il tag!)
            if (!(schemaGriglia[col, row].Style.BackColor == Color.Gray))
            {

                for (int i = 1; i <= matrix.GetUpperBound(0); i++)
                {
                    for (int j = 1; j <= matrix.GetUpperBound(1); j++)
                    {
                        if ((matrix[i, j] != null) && (matrix[i, j].getNomeContenuto() != null))
                        {
                            if (matrix[i, j].getNomeContenuto().Equals(nomeLabel))
                            {
                                matrix[i, j] = null;
                            }
                        }
                    }
                }

                coord = new int[2] { row, col };

                if (nomeLabel == "Play")
                {
                    matrix[row, col] = new Model.Contenuto("Play", null, null, null, null);
                    matrix[row, col].setCoordinate(coord);
                    play.BackColor = System.Drawing.Color.Empty;
                }
                else if (nomeLabel == "Pausa")
                {
                    matrix[row, col] = new Model.Contenuto("Pausa", null, null, null, null);
                    matrix[row, col].setCoordinate(coord);
                    pausa.BackColor = System.Drawing.Color.Empty;
                }
                else if (nomeLabel == "Stop")
                {
                    matrix[row, col] = new Model.Contenuto("Stop", null, null, null, null);
                    matrix[row, col].setCoordinate(coord);
                    stop.BackColor = System.Drawing.Color.Empty;
                }
                else
                {
                    contenuto = control.getContenutoFromNome(listaContenuti, nomeLabel);
                    if (contenuto != null)
                    {
                        matrix[row, col] = contenuto;
                        matrix[row, col].setCoordinate(coord);
                    }
                }

            }
        }

        private void label_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (((Label)sender).Image == null)
                {
                    if (lastLabelClicked == (Label)sender)
                    {
                        ((Label)sender).BackColor = Color.Orange;
                        lastLabelClicked = null;
                    }
                    else
                    {
                        if ((lastLabelClicked != null) && (lastLabelClicked.Image == null))
                        {
                            lastLabelClicked.BackColor = Color.Orange;
                        }
                        else if ((lastLabelClicked != null) && (lastLabelClicked.Image != null))
                        {
                            lastLabelClicked.BackColor = Color.Empty;
                        }

                        ((Label)sender).BackColor = Color.Red;
                        lastLabelClicked = ((Label)sender);

                    }

                }
                else
                {
                    if (lastLabelClicked == (Label)sender)
                    {
                        ((Label)sender).BackColor = Color.Empty;
                        lastLabelClicked = null;
                    }
                    else
                    {
                        if ((lastLabelClicked != null) && (lastLabelClicked.Image == null))
                        {
                            lastLabelClicked.BackColor = Color.Orange;
                        }
                        else if ((lastLabelClicked != null) && (lastLabelClicked.Image != null))
                        {
                            lastLabelClicked.BackColor = Color.Empty;
                        }

                        ((Label)sender).BackColor = Color.Orange;
                        lastLabelClicked = ((Label)sender);
                    }
                }
                ((Label)sender).DoDragDrop(((Label)sender).Tag, DragDropEffects.Move);
            }       
        }

        private void schemaGriglia_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                String nomeLabel = e.Data.GetData(DataFormats.Text).ToString();
                Point point = schemaGriglia.PointToClient(new Point(e.X, e.Y));
                DataGridView.HitTestInfo info = schemaGriglia.HitTest(point.X, point.Y);

                int row = info.RowIndex;
                int col = info.ColumnIndex;

                //click su un header
                if (row <= 0 || col <= 0) return;

                aggiuntaComponente(nomeLabel, row, col);
                riempiGriglia();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void schemaGriglia_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void modifica_Click(object sender, EventArgs e)
        {
            if ((lastLabelClicked != null) && (lastLabelClicked.Tag != null))
            {
                if (!(lastLabelClicked.Tag.Equals("Play")) && !(lastLabelClicked.Tag.Equals("Pausa")) && !(lastLabelClicked.Tag.Equals("Stop")))
                {
                    String nomeContenuto = (String)lastLabelClicked.Tag;
                    Model.Contenuto contenutoTrasferito = control.getContenutoFromNome(listaContenuti, nomeContenuto);

                    AggiungiComponenteForm modificaComp = new AggiungiComponenteForm(contenutoTrasferito,listaContenuti);
                    NavigationControl.goTo(this, modificaComp);
                }
                else MessageBox.Show("Non puoi modificare i componenti di controllo");
            }
            else { MessageBox.Show("Non hai selezionato un contenuto"); }
            
        }

        private void elimina_Click(object sender, EventArgs e)
        {
            if ((lastLabelClicked != null) && (lastLabelClicked.Tag != null))
            {
                if (!(lastLabelClicked.Tag.Equals("Play")) && !(lastLabelClicked.Tag.Equals("Pausa")) && !(lastLabelClicked.Tag.Equals("Stop")))
                {
                    String nomeContenuto = (String)lastLabelClicked.Tag;
                    Model.Contenuto contenuto = control.getContenutoFromNome(listaContenuti, nomeContenuto);
                    if (contenuto != null)
                    {
                        listaContenuti.Remove(contenuto);

                        for (int i = 1; i <= matrix.GetUpperBound(0); i++)
                        {
                            for (int j = 1; j <= matrix.GetUpperBound(1); j++)
                            {
                                if ((matrix[i, j] != null) && (matrix[i, j].getNomeContenuto() != null))
                                {
                                    if (matrix[i, j] == contenuto)
                                        matrix[i, j] = null;
                                }

                            }
                        }

                        riempiGriglia();

                        ElencoRisorse.Controls.Remove(lastLabelClicked);
                        lastLabelClicked = null;
                        ricaricaElencoRisorse();
                        
                    }
                    else
                    {
                        ElencoRisorse.Controls.Remove(lastLabelClicked);
                        lastLabelClicked = null;
                        ricaricaElencoRisorse();
                    }
                }
                else MessageBox.Show("Non puoi eliminare i componenti di controllo");
            }
            else { MessageBox.Show("Non hai selezionato un contenuto"); }
        }

        

    }
}
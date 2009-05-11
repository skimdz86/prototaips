using System;
using TalkingPaper.Common;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

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

        private int tag_per_riga;
        private int tag_per_colonna;
        //private FormScegliPosterAuthoring scelta_poster;
        //private BenvenutoAuthoring partenza;
        private int poster;
        private string nome_poster;
        private string database;
        private int cod_mostra;
        private ElementoGriglia[,] matrice;
        private String directoryPrincipale = "../..";//temporaneo, per farlo andare
        private Bitmap pausa;
        private Bitmap stop;
        private Bitmap riprendi;
        private Bitmap taggato;
        private Bitmap non_taggato;
      //  private NHibernateManager nh_manager;
        //private TalkingPaper.GestioneDisposizione.ComponentiDelPoster componenti_pos;
        //private TalkingPaper.Authoring.BenvenutoGestioneDisposizione benvenuto_pos;
        private string id_pannello;
        private string nome_pannello;
        private string configurazione;
        //private AuthoringInsterting inserimento;
        //private Authoring.BenvenutoGestioneDisposizione benvenuto_ges;
        private char[] alfabeto = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'Z' };
        private bool esiste;
        //private ElementoGriglia[,] SchemaGriglia;
        private int num = 0;
        private int id_contenuto_selezionato;
        private string nome_contenuto_selezionato;
        private int num_colonne;
        private int num_righe;
        private ArrayList cont_modificati = new ArrayList();


        //occhio a queste!!!
        private int id_mosta;
        private Authoring.ModificaCartelloneForm posterMostra;
        private string provenienza;



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

            taggato = new Bitmap(directoryPrincipale + "/Images/Icons/virgoletta.gif");
            non_taggato = new Bitmap(directoryPrincipale + "/Images/Icons/non_taggato.gif");
            pausa = new Bitmap(directoryPrincipale + "/Images/Icons/Pause.bmp");
            stop = new Bitmap(directoryPrincipale + "/Images/Icons/Stop.bmp");
            riprendi = new Bitmap(directoryPrincipale + "/Images/Icons/Play.bmp");

            disegnaGriglia();

        }

        

        // Inizializzazione della DataGrid
        private void SetDataGrid()
        {
            ElencoRisorse.ColumnCount = 13;
            num_colonne = 13;
            num_righe = 0;
            ElencoRisorse.ColumnHeadersVisible = false;
            ElencoRisorse.Columns[0].Visible = false;
            //ElencoRisorse.Columns[1].Visible = false;
            ElencoRisorse.Columns[4].Visible = false;
            ElencoRisorse.Columns[5].Visible = false;
            DataGridViewRow riga = new DataGridViewRow();
            ElencoRisorse.Rows.Add("NUM", " ", "NOME", " ", "POSIZIONA", " ", "AUDIO/VIDEO", " ", "IMMAGINE", " ", "TESTO", " ", "POSIZIONA");
            num_righe++;
            ElencoRisorse.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
            ElencoRisorse.Rows.Add();
            num_righe++;

            ElencoRisorse.CellClick += new DataGridViewCellEventHandler(this.ClickSullaTabella);
            ElencoRisorse.CellMouseEnter += new DataGridViewCellEventHandler(ElencoRisorse_CellMouseEnter);
            
        }



       

        

        // gestore degli eventi sulla DataGrid
        private void ElencoRisorse_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex % 2 == 0 && e.ColumnIndex != 0)
            {
                if (ElencoRisorse[e.ColumnIndex, e.RowIndex].Value != null)
                {
                    ElencoRisorse.Cursor = Cursors.Hand;
                }
                else
                    ElencoRisorse.Cursor = Cursors.Default;
            }
            else
                ElencoRisorse.Cursor = Cursors.Default;
        }

        private void ClickSullaTabella(object sender, DataGridViewCellEventArgs e)
        {
           
            if ((ElencoRisorse[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 2 || e.ColumnIndex == 12))
            {
                ElencoRisorse[e.ColumnIndex, e.RowIndex].Selected = false;
                if (id_contenuto_selezionato != -1)
                {
                    for (int i = 0; i < num_colonne; i++)
                    {

                        for (int j = 0; j < num_righe; j++)
                        {
                            if (i == 2 && j % 2 == 0 && j != 0)
                                ElencoRisorse[i, j].Style.BackColor = Color.Red;
                            else
                                ElencoRisorse[i, j].Style.BackColor = Color.BlanchedAlmond;
                        }
                    }
                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            ElencoControlli1[i, j].Style.BackColor = Color.BlanchedAlmond;
                        }
                    }
                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            ElencoControlli2[i, j].Style.BackColor = Color.BlanchedAlmond;
                        }
                    }
                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            ElencoControlli3[i, j].Style.BackColor = Color.BlanchedAlmond;
                        }
                    }
                }
                if (id_contenuto_selezionato == (int)ElencoRisorse[0, e.RowIndex].Value && e.RowIndex != 0)
                {
                    id_contenuto_selezionato = -1;
                    nome_contenuto_selezionato = null;
                }
                else
                {
                    id_contenuto_selezionato = (int)ElencoRisorse[0, e.RowIndex].Value;
                    nome_contenuto_selezionato = (string)ElencoRisorse[2, e.RowIndex].Value;
                    for (int i = 0; i < num_colonne; i++)
                    {
                        ElencoRisorse[i, e.RowIndex].Style.BackColor = Color.DeepSkyBlue;
                        id_contenuto_selezionato = (int)ElencoRisorse[0, e.RowIndex].Value;
                        nome_contenuto_selezionato = (string)ElencoRisorse[2, e.RowIndex].Value;
                    }
                }
            }
        }

        private void ClickSullaTabellaDeiControlli1(object sender, DataGridViewCellEventArgs e)
        {
            if ((ElencoControlli1[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 2 || e.ColumnIndex == 4))
            {
                /*if (ElencoControlli1[4, 2].Value == null)
                {*/
                if (id_contenuto_selezionato != -1)
                {
                    for (int i = 0; i < num_colonne; i++)
                    {
                        for (int j = 0; j < num_righe; j++)
                        {
                            ElencoRisorse[i, j].Style.BackColor = Color.BlanchedAlmond;
                        }
                    }
                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            ElencoControlli1[i, j].Style.BackColor = Color.BlanchedAlmond;
                        }
                    }
                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            ElencoControlli2[i, j].Style.BackColor = Color.BlanchedAlmond;
                        }
                    }
                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            ElencoControlli3[i, j].Style.BackColor = Color.BlanchedAlmond;
                        }
                    }
                }
                ElencoControlli1[e.ColumnIndex, e.RowIndex].Selected = false;
                this.Cursor = Cursors.WaitCursor;
                /*AuthoringInsterting codice = new AuthoringInsterting(this, (int)ElencoControlli1[0, 0].Value, (string)ElencoControlli1[2, 0].Value, scelta_poster, partenza, poster, nome_poster, cod_mostra, directory_principale, database, componenti_pos, benvenuto_pos, id_pannello, nome_pannello, configurazione,benvenuto_ges);
                codice.Show();
                this.Cursor = Cursors.Default;
                this.Visible = false;*/
                if (id_contenuto_selezionato == (int)ElencoControlli1[0, 0].Value)
                {
                    id_contenuto_selezionato = -1;
                    nome_contenuto_selezionato = null;
                }
                else
                {
                    id_contenuto_selezionato = (int)ElencoControlli1[0, 0].Value;
                    nome_contenuto_selezionato = (string)ElencoControlli1[2, 0].Value;
                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            ElencoControlli1[i, j].Style.BackColor = Color.DeepSkyBlue;
                        }
                    }
                }
                this.Cursor = Cursors.Default;
                /*}
                else
                {
                    this.Cursor = Cursors.WaitCursor;
                    QuestionEliminaTag nuovaa = new QuestionEliminaTag(this, (int)ElencoControlli1[0, 0].Value, scelta_poster, partenza, poster, nome_poster, cod_mostra, directory_principale, database, componenti_pos, benvenuto_pos,id_pannello,nome_pannello,configurazione);
                    //this.Visible = false;
                    nuovaa.Show();
                    this.Cursor = Cursors.Default;
                    this.Visible = false;
                }*/
            }
        }

        private void ClickSullaTabellaDeiControlli2(object sender, DataGridViewCellEventArgs e)
        {

            if ((ElencoControlli2[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 2 || e.ColumnIndex == 4))
            {
                /*if (ElencoControlli2[4, 2].Value == null)
                {*/
                /*this.Cursor = Cursors.WaitCursor;
                AuthoringInsterting codice = new AuthoringInsterting(this, (int)ElencoControlli2[0, 0].Value, (string)ElencoControlli2[2, 0].Value, scelta_poster, partenza, poster, nome_poster, cod_mostra, directory_principale, database, componenti_pos, benvenuto_pos, id_pannello, nome_pannello, configurazione,benvenuto_ges);
                codice.Show();
                this.Cursor = Cursors.Default;
                this.Visible = false;*/
                if (id_contenuto_selezionato != -1)
                {
                    for (int i = 0; i < num_colonne; i++)
                    {
                        for (int j = 0; j < num_righe; j++)
                        {
                            ElencoRisorse[i, j].Style.BackColor = Color.BlanchedAlmond;
                        }
                    }
                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            ElencoControlli1[i, j].Style.BackColor = Color.BlanchedAlmond;
                        }
                    }
                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            ElencoControlli2[i, j].Style.BackColor = Color.BlanchedAlmond;
                        }
                    }
                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            ElencoControlli3[i, j].Style.BackColor = Color.BlanchedAlmond;
                        }
                    }
                }
                ElencoControlli2[e.ColumnIndex, e.RowIndex].Selected = false;
                this.Cursor = Cursors.WaitCursor;
                /*AuthoringInsterting codice = new AuthoringInsterting(this, (int)ElencoControlli1[0, 0].Value, (string)ElencoControlli1[2, 0].Value, scelta_poster, partenza, poster, nome_poster, cod_mostra, directory_principale, database, componenti_pos, benvenuto_pos, id_pannello, nome_pannello, configurazione,benvenuto_ges);
                codice.Show();
                this.Cursor = Cursors.Default;
                this.Visible = false;*/
                if (id_contenuto_selezionato == (int)ElencoControlli2[0, 0].Value)
                {
                    id_contenuto_selezionato = -1;
                    nome_contenuto_selezionato = null;
                }
                else
                {
                    id_contenuto_selezionato = (int)ElencoControlli2[0, 0].Value;
                    nome_contenuto_selezionato = (string)ElencoControlli2[2, 0].Value;
                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            ElencoControlli2[i, j].Style.BackColor = Color.DeepSkyBlue;
                        }
                    }
                }
                this.Cursor = Cursors.Default;
                /*}
                else
                {
                    this.Cursor = Cursors.WaitCursor;
                    QuestionEliminaTag nuovaa = new QuestionEliminaTag(this, (int)ElencoControlli2[0, 0].Value, scelta_poster, partenza, poster, nome_poster, cod_mostra, directory_principale, database, componenti_pos, benvenuto_pos,id_pannello,nome_pannello,configurazione);
                    //this.Visible = false;
                    nuovaa.Show();
                    this.Cursor = Cursors.Default;
                    this.Visible = false;
                }*/
            }
        }

        private void ClickSullaTabellaDeiControlli3(object sender, DataGridViewCellEventArgs e)
        {
            if ((ElencoControlli3[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 2 || e.ColumnIndex == 4))
            {
                /*if (ElencoControlli3[4, 2].Value == null)
                {*/
                /*this.Cursor = Cursors.WaitCursor;
                AuthoringInsterting codice = new AuthoringInsterting(this, (int)ElencoControlli3[0, 0].Value, (string)ElencoControlli3[2, 0].Value, scelta_poster, partenza, poster, nome_poster, cod_mostra, directory_principale, database, componenti_pos, benvenuto_pos, id_pannello, nome_pannello, configurazione,benvenuto_ges);
                codice.Show();
                this.Cursor = Cursors.Default;
                this.Visible = false;*/
                ElencoControlli3[e.ColumnIndex, e.RowIndex].Selected = false;
                if (id_contenuto_selezionato != -1)
                {
                    for (int i = 0; i < num_colonne; i++)
                    {
                        for (int j = 0; j < num_righe; j++)
                        {
                            ElencoRisorse[i, j].Style.BackColor = Color.BlanchedAlmond;
                        }
                    }
                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            ElencoControlli2[i, j].Style.BackColor = Color.BlanchedAlmond;
                        }
                    }
                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            ElencoControlli1[i, j].Style.BackColor = Color.BlanchedAlmond;
                        }
                    }
                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            ElencoControlli3[i, j].Style.BackColor = Color.BlanchedAlmond;
                        }
                    }
                }
                this.Cursor = Cursors.WaitCursor;
                /*AuthoringInsterting codice = new AuthoringInsterting(this, (int)ElencoControlli1[0, 0].Value, (string)ElencoControlli1[2, 0].Value, scelta_poster, partenza, poster, nome_poster, cod_mostra, directory_principale, database, componenti_pos, benvenuto_pos, id_pannello, nome_pannello, configurazione,benvenuto_ges);
                codice.Show();
                this.Cursor = Cursors.Default;
                this.Visible = false;*/
                if (id_contenuto_selezionato == (int)ElencoControlli3[0, 0].Value)
                {
                    id_contenuto_selezionato = -1;
                    nome_contenuto_selezionato = null;
                }
                else
                {
                    id_contenuto_selezionato = (int)ElencoControlli3[0, 0].Value;
                    nome_contenuto_selezionato = (string)ElencoControlli3[2, 0].Value;
                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            ElencoControlli3[i, j].Style.BackColor = Color.DeepSkyBlue;
                        }
                    }
                }
                this.Cursor = Cursors.Default;
                /*}
                else
                {
                    this.Cursor = Cursors.WaitCursor;
                    QuestionEliminaTag nuovaa = new QuestionEliminaTag(this, (int)ElencoControlli3[0, 0].Value, scelta_poster, partenza, poster, nome_poster, cod_mostra, directory_principale, database, componenti_pos, benvenuto_pos,id_pannello,nome_pannello,configurazione);
                    //this.Visible = false;
                    nuovaa.Show();
                    this.Cursor = Cursors.Default;
                    this.Visible = false;
                }*/
            }
        }

        
        
        private void disegnaGriglia()
        {
            Font font = new Font("Arial", 16);

            schemaGriglia.Rows.Clear();

            schemaGriglia.ColumnCount = griglia.getNumColonne() + 1;
            schemaGriglia.Rows.Add(griglia.getNumRighe() + 1);

            schemaGriglia.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
            schemaGriglia.Columns[0].DefaultCellStyle.ForeColor = Color.Red;
            schemaGriglia.Rows[0].DefaultCellStyle.Font = font;
            schemaGriglia.Columns[0].DefaultCellStyle.Font = font;

            for (int i = 1; i <= griglia.getNumRighe(); i++)
            {
                schemaGriglia[0, i].Value = i;
            }
            for (int j = 1; j <= griglia.getNumColonne(); j++)
            {
                schemaGriglia.Columns[j].Width = 90;
                schemaGriglia[j, 0].Value = alfabeto[j - 1];
            }
            for (int i = 0; i < (griglia.getNumRighe() * griglia.getNumColonne()); i++)
            {
                if (!(griglia.getTagFromIndex(i).Equals("")))
                {
                    schemaGriglia[(i % griglia.getNumColonne()) + 1, (i / griglia.getNumColonne()) + 1].Style.BackColor = Color.Coral;
                }
            }

        }




        private void ElencoTag2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bool gia_presente = false;
            schemaGriglia[e.ColumnIndex, e.RowIndex].Selected = false;
            string colonna = "";
            int riga = -1;
            foreach (ElementoGriglia el in matrice)
            {
                if (el != null)
                {
                    if (el.GetUtilizzato() == true)
                    {
                        if ((el.GetIdContenuto() == id_contenuto_selezionato) && (nome_contenuto_selezionato.CompareTo(el.GetNomeContenuto()) == 0))
                        {
                            gia_presente = true;
                            riga = el.GetRiga();
                            colonna = el.getColonna();
                        }
                    }
                }
            }
            if (schemaGriglia[e.ColumnIndex, e.RowIndex].Style.BackColor == Color.Coral)
            {
                this.Enabled = false;
                if (num == 0)
                {
                    num = 1;
                    if (((schemaGriglia[e.ColumnIndex, e.RowIndex].Value != null) && ((id_contenuto_selezionato == 0) || (id_contenuto_selezionato == -1))))// && (((String)ElencoTag2[e.ColumnIndex, e.RowIndex].Value).CompareTo(nome_contenuto_selezionato) == 0))
                    {
                        DialogResult n = MessageBox.Show("Vuoi eliminare questo contenuto ?", "", MessageBoxButtons.YesNo);
                        if (n == DialogResult.Yes)
                        {
                            schemaGriglia[e.ColumnIndex, e.RowIndex].Selected = false;
                            schemaGriglia[e.ColumnIndex, e.RowIndex].Value = null;
                            int id_co = (int)((ElementoGriglia)matrice[e.RowIndex, e.ColumnIndex]).GetIdContenuto();
                            cont_modificati.Add((int)((ElementoGriglia)matrice[e.RowIndex, e.ColumnIndex]).GetIdContenuto());
                            ((ElementoGriglia)matrice[e.RowIndex, e.ColumnIndex]).SetIdContenuto(-1);
                            ((ElementoGriglia)matrice[e.RowIndex, e.ColumnIndex]).SetNomeContenuto(null);
                            ((ElementoGriglia)matrice[e.RowIndex, e.ColumnIndex]).SetUtilizzato(false);
                            
                            if (id_co == (int)ElencoControlli1[0, 0].Value)
                            {
                                DataGridViewImageCell im = new DataGridViewImageCell();
                                im.Value = non_taggato;
                                im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                ElencoControlli1[4, 2] = im;
                            }
                            else if (id_co == (int)ElencoControlli2[0, 0].Value)
                            {
                                DataGridViewImageCell im = new DataGridViewImageCell();
                                im.Value = non_taggato;
                                im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                ElencoControlli2[4, 2] = im;
                            }
                            else if (id_co == (int)ElencoControlli3[0, 0].Value)
                            {
                                DataGridViewImageCell im = new DataGridViewImageCell();
                                im.Value = non_taggato;
                                im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                ElencoControlli3[4, 2] = im;
                            }
                            else
                            {
                                for (int j = 0; j < num_righe; j++)
                                {
                                    try
                                    {
                                        /* if (((int)ElencoRisorse[0, j].Value) == id_co)
                                         {
                                             ElencoRisorse[4, j].Value = null;
                                         }
                                         else*/
                                        if (((int)ElencoRisorse[0, j].Value) == id_co)
                                        {
                                            DataGridViewImageCell im = new DataGridViewImageCell();
                                            im.Value = non_taggato;
                                            im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                            ElencoRisorse[12, j] = im;
                                        }
                                    }
                                    catch
                                    {

                                    }
                                }
                            }
                            num = 0;
                        }
                        else
                        {
                            schemaGriglia[e.ColumnIndex, e.RowIndex].Selected = false;
                        }
                    }
                    else if ((schemaGriglia[e.ColumnIndex, e.RowIndex].Value != null) && (((String)schemaGriglia[e.ColumnIndex, e.RowIndex].Value).CompareTo(nome_contenuto_selezionato) != 0) && (id_contenuto_selezionato != -1))
                    {
                        //ElencoTag[e.ColumnIndex, e.RowIndex].Value = nome_componente;
                        //Richiesta n = new Richiesta(this,matrice);
                        //this.Visible = false;
                        //n.Show();
                        //bool o = n.GetModifica();
                        if (gia_presente == false)
                        {
                            DialogResult n = MessageBox.Show("Sei sicuro di voler sostituire il contenuto " + schemaGriglia[e.ColumnIndex, e.RowIndex].Value.ToString() + " con il contenuto " + nome_contenuto_selezionato + "?", "", MessageBoxButtons.YesNo);
                            if (n == DialogResult.Yes)
                            {
                                schemaGriglia[e.ColumnIndex, e.RowIndex].Selected = false;
                                cont_modificati.Add((int)(((ElementoGriglia)matrice[e.RowIndex, e.ColumnIndex]).GetIdContenuto()));
                                int id_c = (((ElementoGriglia)matrice[e.RowIndex, e.ColumnIndex]).GetIdContenuto());
                                ((ElementoGriglia)matrice[e.RowIndex, e.ColumnIndex]).SetIdContenuto(id_contenuto_selezionato);
                                ((ElementoGriglia)matrice[e.RowIndex, e.ColumnIndex]).SetNomeContenuto(nome_contenuto_selezionato);
                                ((ElementoGriglia)matrice[e.RowIndex, e.ColumnIndex]).SetUtilizzato(true);
                                schemaGriglia[e.ColumnIndex, e.RowIndex].Value = nome_contenuto_selezionato;
                                
                                if (id_c == (int)ElencoControlli1[0, 0].Value)
                                {
                                    DataGridViewImageCell im = new DataGridViewImageCell();
                                    im.Value = non_taggato;
                                    im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli1[4, 2] = im;

                                }
                                else if ((id_contenuto_selezionato == (int)ElencoControlli1[0, 0].Value))
                                {
                                    DataGridViewImageCell im = new DataGridViewImageCell();
                                    im.Value = taggato;
                                    im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli1[4, 2] = im;
                                }
                                if (id_c == (int)ElencoControlli2[0, 0].Value)
                                {
                                    DataGridViewImageCell im = new DataGridViewImageCell();
                                    im.Value = non_taggato;
                                    im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli2[4, 2] = im;

                                }
                                else if ((id_contenuto_selezionato == (int)ElencoControlli2[0, 0].Value))
                                {
                                    DataGridViewImageCell im = new DataGridViewImageCell();
                                    im.Value = taggato;
                                    im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli2[4, 2] = im;
                                }
                                if (id_c == (int)ElencoControlli3[0, 0].Value)
                                {
                                    DataGridViewImageCell im = new DataGridViewImageCell();
                                    im.Value = non_taggato;
                                    im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli3[4, 2] = im;
                                }
                                else if ((id_contenuto_selezionato == (int)ElencoControlli3[0, 0].Value))
                                {
                                    DataGridViewImageCell im = new DataGridViewImageCell();
                                    im.Value = taggato;
                                    im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli3[4, 2] = im;
                                }
                                for (int j = 0; j < num_righe; j++)
                                {
                                    try
                                    {
                                        if (((int)ElencoRisorse[0, j].Value) == id_c)
                                        {
                                            DataGridViewImageCell im = new DataGridViewImageCell();
                                            im.Value = non_taggato;
                                            im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                            ElencoRisorse[12, j] = im;
                                        }
                                        else if (((int)ElencoRisorse[0, j].Value) == id_contenuto_selezionato)
                                        {
                                            DataGridViewImageCell im = new DataGridViewImageCell();
                                            im.Value = taggato;
                                            im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                            ElencoRisorse[12, j] = im;
                                        }
                                    }
                                    catch
                                    {

                                    }
                                }
                            }
                            else
                            {
                                schemaGriglia[e.ColumnIndex, e.RowIndex].Selected = false;
                                num = 0;
                            }
                        }
                    }
                    else
                    {
                        schemaGriglia[e.ColumnIndex, e.RowIndex].Selected = false;
                        /*bool gia_presente = false;
                        string colonna="";
                        int riga=-1;
                        foreach (ElementoGriglia el in matrice) {
                            if (el != null)
                            {
                                if (el.GetUtilizzato() == true)
                                {
                                    if ((el.GetIdContenuto() == id_componente) && (nome_componente.CompareTo(el.GetNomeContenuto()) == 0))
                                    {
                                        gia_presente = true;
                                        riga = el.GetRiga();
                                        colonna = el.getColonna();
                                    }
                                }
                            }
                        }*/
                        //ElencoTag[e.ColumnIndex, e.RowIndex].Selected = false;
                        if ((gia_presente == false) && (nome_contenuto_selezionato != null) && (id_contenuto_selezionato != -1))
                        {
                            schemaGriglia[e.ColumnIndex, e.RowIndex].Value = nome_contenuto_selezionato;
                            int id_co = id_contenuto_selezionato;
                            ((ElementoGriglia)matrice[e.RowIndex, e.ColumnIndex]).SetIdContenuto(id_contenuto_selezionato);
                            ((ElementoGriglia)matrice[e.RowIndex, e.ColumnIndex]).SetNomeContenuto(nome_contenuto_selezionato);
                            ((ElementoGriglia)matrice[e.RowIndex, e.ColumnIndex]).SetUtilizzato(true);
                            
                            if (id_co == (int)ElencoControlli1[0, 0].Value)
                            {
                                DataGridViewImageCell im = new DataGridViewImageCell();
                                im.Value = taggato;
                                im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                ElencoControlli1[4, 2] = im;
                            }
                            else if (id_co == (int)ElencoControlli2[0, 0].Value)
                            {
                                DataGridViewImageCell im = new DataGridViewImageCell();
                                im.Value = taggato;
                                im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                ElencoControlli2[4, 2] = im;
                            }
                            else if (id_co == (int)ElencoControlli3[0, 0].Value)
                            {
                                DataGridViewImageCell im = new DataGridViewImageCell();
                                im.Value = taggato;
                                im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                ElencoControlli3[4, 2] = im;
                            }
                            else
                            {
                                for (int j = 0; j < num_righe; j++)
                                {
                                    try
                                    {
                                        /* if (((int)ElencoRisorse[0, j].Value) == id_co)
                                         {
                                             ElencoRisorse[4, j].Value = null;
                                         }
                                         else*/
                                        if (((int)ElencoRisorse[0, j].Value) == id_contenuto_selezionato)
                                        {
                                            DataGridViewImageCell im = new DataGridViewImageCell();
                                            im.Value = taggato;
                                            im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                            ElencoRisorse[12, j] = im;
                                        }
                                    }
                                    catch
                                    {

                                    }
                                }
                            }
                            num = 0;
                        }
                        else if ((nome_contenuto_selezionato != null) && (id_contenuto_selezionato != -1))
                        {
                            DialogResult n = MessageBox.Show("Il contenuto è già inserito in " + colonna.ToString() + riga.ToString() + ", vuoi spostarlo in qui?", "", MessageBoxButtons.YesNo);
                            if (n == DialogResult.Yes)
                            {
                                schemaGriglia[e.ColumnIndex, e.RowIndex].Selected = false;
                                cont_modificati.Add((int)(((ElementoGriglia)matrice[e.RowIndex, e.ColumnIndex]).GetIdContenuto()));
                                int id_c = (((ElementoGriglia)matrice[e.RowIndex, e.ColumnIndex]).GetIdContenuto());
                                ((ElementoGriglia)matrice[e.RowIndex, e.ColumnIndex]).SetIdContenuto(id_contenuto_selezionato);
                                ((ElementoGriglia)matrice[e.RowIndex, e.ColumnIndex]).SetNomeContenuto(nome_contenuto_selezionato);
                                ((ElementoGriglia)matrice[e.RowIndex, e.ColumnIndex]).SetUtilizzato(true);
                                schemaGriglia[e.ColumnIndex, e.RowIndex].Value = nome_contenuto_selezionato;
                                schemaGriglia[e.ColumnIndex, e.RowIndex].Selected = false;
                                //ElencoTag2[e.ColumnIndex, e.RowIndex].Value = null;
                                //int id_co = (int)((ElementoGriglia)matrice[e.ColumnIndex, e.RowIndex]).GetIdContenuto();
                                int colo = -1;
                                for (int k = 0; k < alfabeto.Length; k++)
                                {
                                    if (((((char)alfabeto[k]).ToString()).CompareTo(colonna)) == 0)
                                    {
                                        colo = k + 1;
                                    }
                                }
                                cont_modificati.Add((int)((ElementoGriglia)matrice[riga, colo]).GetIdContenuto());
                                ((ElementoGriglia)matrice[riga, colo]).SetIdContenuto(-1);
                                ((ElementoGriglia)matrice[riga, colo]).SetNomeContenuto(null);
                                ((ElementoGriglia)matrice[riga, colo]).SetUtilizzato(false);
                                schemaGriglia[colo, riga].Value = null;
                                
                                if (id_c == (int)ElencoControlli1[0, 0].Value)
                                {
                                    DataGridViewImageCell im = new DataGridViewImageCell();
                                    im.Value = non_taggato;
                                    im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli1[4, 2] = im;
                                }
                                else if ((int)ElencoControlli1[0, 0].Value == id_contenuto_selezionato)
                                {
                                    DataGridViewImageCell im = new DataGridViewImageCell();
                                    im.Value = taggato;
                                    im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli1[4, 2] = im;
                                }
                                if (id_c == (int)ElencoControlli2[0, 0].Value)
                                {
                                    DataGridViewImageCell im = new DataGridViewImageCell();
                                    im.Value = non_taggato;
                                    im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli2[4, 2] = im;
                                }
                                else if ((int)ElencoControlli2[0, 0].Value == id_contenuto_selezionato)
                                {
                                    DataGridViewImageCell im = new DataGridViewImageCell();
                                    im.Value = taggato;
                                    im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli2[4, 2] = im;
                                }
                                if (id_c == (int)ElencoControlli3[0, 0].Value)
                                {
                                    DataGridViewImageCell im = new DataGridViewImageCell();
                                    im.Value = non_taggato;
                                    im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli3[4, 2] = im;
                                }
                                else if ((int)ElencoControlli3[0, 0].Value == id_contenuto_selezionato)
                                {
                                    DataGridViewImageCell im = new DataGridViewImageCell();
                                    im.Value = taggato;
                                    im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli3[4, 2] = im;
                                }
                                for (int j = 0; j < num_righe; j++)
                                {
                                    try
                                    {
                                        if (((int)ElencoRisorse[0, j].Value) == id_c)
                                        {
                                            DataGridViewImageCell im = new DataGridViewImageCell();
                                            im.Value = non_taggato;
                                            im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                            ElencoRisorse[12, j] = im;
                                        }
                                        else if (((int)ElencoRisorse[0, j].Value) == id_contenuto_selezionato)
                                        {
                                            DataGridViewImageCell im = new DataGridViewImageCell();
                                            im.Value = taggato;
                                            im.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                            ElencoRisorse[12, j] = im;
                                        }
                                    }
                                    catch
                                    {

                                    }
                                }
                                num = 0;
                            }
                            else
                            {
                                schemaGriglia[e.ColumnIndex, e.RowIndex].Selected = false;
                                num = 0;
                            }
                            //MessageBox.Show("Il contenuto è già inserito in " + colonna.ToString() + riga.ToString()+", vuoi spostarlo in qui?");
                        }
                    }
                    this.Enabled = true;
                }
                else
                {
                    num = 0;
                    this.Enabled = true;
                }
                for (int i = 0; i < num_colonne; i++)
                {
                    for (int j = 0; j < num_righe; j++)
                    {
                        ElencoRisorse[i, j].Style.BackColor = Color.BlanchedAlmond;
                    }
                }
                for (int i = 0; i < 7; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        ElencoControlli1[i, j].Style.BackColor = Color.BlanchedAlmond;
                    }
                }
                for (int i = 0; i < 7; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        ElencoControlli2[i, j].Style.BackColor = Color.BlanchedAlmond;
                    }
                }
                for (int i = 0; i < 7; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        ElencoControlli3[i, j].Style.BackColor = Color.BlanchedAlmond;
                    }
                }
                id_contenuto_selezionato = -1;
                nome_contenuto_selezionato = null;
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
            //TO DO
            NavigationControl.goHome(this);
        }

        private void aggiungi_Click(object sender, EventArgs e)
        {
            AggiungiComponenteForm aggiungiComp = new AggiungiComponenteForm();
            NavigationControl.goTo(this, aggiungiComp);
        }



    }
}
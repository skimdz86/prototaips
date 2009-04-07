using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Collections;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System.Xml;

namespace TalkingPaper.BarCode
{
    public partial class FormScegliPoster : FormSchema
    {
        private string directoryprincipale;
        private ScegliMostra FormMostre;
        private BenvenutoBarCode partenza;
        private int cod_mostra;
        private string nome_mostra;
        private string autore_mostra;
        private string database;
        private ArrayList poster;
        //private Bitmap image;
        private Bitmap immagine_modifica_poster;
        private ArrayList poster_authoring = new ArrayList();

        public FormScegliPoster(ScegliMostra FormMostre, BenvenutoBarCode partenza, int cod_mostra,string nome_mostra, string autore_mostra, string directory_principale, string database)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 90, true);
            this.FormMostre = FormMostre;
            this.partenza = partenza;
            this.cod_mostra = cod_mostra;
            this.nome_mostra = nome_mostra;
            this.autore_mostra = autore_mostra;
            this.directoryprincipale = directory_principale;
            this.database = database;
            Fase.Text = Fase.Text + " della mostra " + nome_mostra;
            immagine_modifica_poster = new Bitmap(directory_principale + @"/Images/Icons/modifica3.gif");
            //image = new Bitmap(directoryprincipale + @"/Images/Icons/SelezionaPannello2.gif");
            //textBox1.Select(0,0);
            Indietro.Cursor = Cursors.Hand;
        }

        private void FormScegliPoster_Load(object sender, EventArgs e)
        {
            InterrogaDB();
        }

        private void LetturaPosterAuthoring()
        {
            try
            {
                XmlTextReader iscritto = new XmlTextReader(directoryprincipale + "PosterAuthoring" + ".xml");
                //bool fine = false;
                while ((iscritto.Read()))
                {
                    if (iscritto.NodeType == XmlNodeType.Element)
                    {
                        if (iscritto.LocalName.Equals("IDposter"))
                        {
                            //string id = (String)iscritto.GetAttribute("ID");
                            string ins = (string)iscritto.ReadString();
                            //string id = (String)iscritto.GetAttribute("ID");
                            poster_authoring.Add(ins);
                            //pannelli.Add(id);
                        }
                    }
                }
                iscritto.Close();
            }
            catch
            {
            }
        }


        #region Connessione al DB e DataGrid

        // connessione al DB e letture dei dati
        private void InterrogaDB()
        {
            if (cod_mostra != -1)
            {
                MySqlConnection connection;
                connection = new MySqlConnection("server=localhost; username=root; password=root; database=" + database);
                connection.Open();
                MySqlCommand myC = new MySqlCommand("SELECT IDposter, Nome, Descrizione, Ordine FROM poster WHERE Mostra=?Mostra");
                myC.Connection = connection;
                myC.Parameters.Add("?Mostra", MySqlDbType.Int32, 50).Value = cod_mostra;
                MySqlDataReader dr2 = myC.ExecuteReader();
                if (dr2.HasRows == true)
                {
                    poster = new ArrayList();
                    while (dr2.Read())
                    {
                        poster.Add((int)dr2.GetInt32(0));
                        poster.Add((String)dr2.GetString(1));
                        poster.Add((String)dr2.GetString(2));
                        poster.Add((int)dr2.GetInt32(3));
                    }
                    SetDataGrid();
                }
                else
                {
                    MessageBox.Show("Non è presente nessun poster");
                    FormMostre.Visible = true;
                    connection.Close();
                    dr2.Close();
                    this.Close();
                }
                connection.Close();
                dr2.Close();
            }
            else {
                LetturaPosterAuthoring();
                MySqlConnection connection;
                connection = new MySqlConnection("server=localhost; username=root; password=root; database=" + database);
                connection.Open();
                MySqlCommand myC = new MySqlCommand("SELECT IDposter, Nome, Descrizione, Ordine,Mostra FROM poster");
                myC.Connection = connection;
                //myC.Parameters.Add("?Mostra", MySqlDbType.Int32, 50).Value = null;
                MySqlDataReader dr2 = myC.ExecuteReader();
                if (dr2.HasRows == true)
                {
                    poster = new ArrayList();
                    while (dr2.Read())
                    {
                        try
                        {
                            string nuova = (String)dr2.GetString(4);
                        }
                        catch(Exception e)
                        {
                            bool tr = false;
                            int id_pt=((int)dr2.GetInt32(0));
                            for (int i = 0; i < poster_authoring.Count; i++)
                            {
                                if (Int32.Parse(((string)poster_authoring[i])) == id_pt)
                                {
                                    tr = true;
                                }
                            }
                            if (tr == false)
                            {
                                //poster.Add((int)dr2.GetInt32(0));
                                poster.Add(id_pt);
                                poster.Add((String)dr2.GetString(1));
                                poster.Add((String)dr2.GetString(2));
                                poster.Add((int)dr2.GetInt32(3));
                                //MessageBox.Show((String)dr2.GetString(4));
                            }
                        }
                    }
                    SetDataGrid();
                }
                else
                {
                    MessageBox.Show("Non è presente nessun poster");
                    partenza.Visible = true;
                    connection.Close();
                    dr2.Close();
                    this.Close();
                }
                connection.Close();
                dr2.Close();
            }
        }

        // Inizializzazione della DataGrid
        private void SetDataGrid()
        {
            ElencoPoster.ColumnCount = 7;
            ElencoPoster.ColumnHeadersVisible = false;
            ElencoPoster.Columns[0].Visible = false;
            DataGridViewRow riga = new DataGridViewRow();
            ElencoPoster.Rows.Add("NUMERO", "  ","NOME","  ", "DESCRIZIONE", "  ","VISUALIZZA COMPONENTI");
            ElencoPoster.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
            ElencoPoster.Rows.Add();
            ElencoPoster.CellClick += new DataGridViewCellEventHandler(this.ClickSullaTabella);
            ElencoPoster.CellMouseEnter += new DataGridViewCellEventHandler(ElencoPoster_CellMouseEnter);
            RiempiDataGrid();
        }



        // Riempimento della DataGrid
        private void RiempiDataGrid()
        {
            int riga = 2;
            for (int i = 0; i < poster.Count; i = i + 4)
            {
                DataGridViewImageCell modify = new DataGridViewImageCell();
                modify.Value = immagine_modifica_poster;
                modify.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                ElencoPoster.Rows.Add((int)poster[i], null, (String)poster[i + 1], null, (String)poster[i+2],null,null);
                ElencoPoster[6, riga] = modify;
                ElencoPoster.Rows.Add();
                riga += 2;
            }

        }
        #endregion

        #region gestione eventi

        // gestore degli eventi sulla DataGrid
        private void ElencoPoster_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((ElencoPoster[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 6))
            {
                ElencoPoster.Cursor = Cursors.Hand;
            }
            else
                ElencoPoster.Cursor = Cursors.Default;
        }          

        private void ClickSullaTabella(object sender, DataGridViewCellEventArgs e)
        {
            if ((ElencoPoster[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 6))
            {
                this.Cursor = Cursors.WaitCursor;
                //this.Visible = false;
                FormVisualizzaElementi nuova = new FormVisualizzaElementi(this, partenza, (int)ElencoPoster[0, e.RowIndex].Value, (string)ElencoPoster[2, e.RowIndex].Value, cod_mostra, directoryprincipale,database,null,null,null);
                nuova.Show();
                this.Cursor = Cursors.Default;
                this.Visible = false;
            }
        }

        private void Indietro_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (FormMostre != null)
            {
                FormMostre.Visible = true;
            }
            else {
                partenza.Visible = true;
            }
            this.Cursor = Cursors.Default;
            this.Close();
        }
        #endregion

        private void Menu_Click(object sender, EventArgs e)
        {
            Question richiesta = new Question(partenza, global.home);
            richiesta.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }
    }
}
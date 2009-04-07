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

namespace TalkingPaper.BarCode
{
    public partial class ScegliMostra : FormSchema
    {
        private string directoryprincipale;
        private BenvenutoBarCode FormBenvenuto;
        private ArrayList mostre;
        private Bitmap image;
        private string database;
        private Bitmap immagine_modifica_mostra;
        //private Bitmap elimina;

        # region CaricaForm
        public ScegliMostra(string directory, BenvenutoBarCode benvenuto, string database)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 90, true);
            this.Show();
            this.directoryprincipale = directory;
            this.database=database;
            FormBenvenuto = benvenuto;
            immagine_modifica_mostra = new Bitmap(directory + @"/Images/Icons/modifica3.gif");
            Indietro.Cursor = Cursors.Hand;
            //Indietro.Cursor = Cursors.Hand;
            //elimina = new Bitmap(directory + @"/Images/Icons/elimina_cestino.gif");
            InterrogaDB();
        }

        private void ScegliMostra_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Connessione al DB e DataGrid

        // connessione al DB e letture dei dati
        private void InterrogaDB() {
            MySqlConnection connection;
            connection = new MySqlConnection("server=localhost; username=root; password=root; database="+database);
            connection.Open();
            MySqlCommand myC = new MySqlCommand("SELECT IDmostra, Nome, Autore,DataInizio FROM mostra");
            myC.Connection = connection;
            MySqlDataReader dr2 = myC.ExecuteReader();
            if (dr2.HasRows == true)
            {
                mostre = new ArrayList();
                while (dr2.Read())
                {
                    mostre.Add((int)dr2.GetInt32(0));
                    mostre.Add((String)dr2.GetString(1));
                    mostre.Add((String)dr2.GetString(2));
                    mostre.Add((DateTime)dr2.GetDateTime(3));
                }
                SetDataGrid();
            }
            else {
                MessageBox.Show("Non è presente nessuna mostra");
                FormBenvenuto.Enabled = true;
                connection.Close();
                dr2.Close();
                this.Close();
            }
            connection.Close();
            dr2.Close();
        }
        
        // Inizializzazione della DataGrid
        private void SetDataGrid() {
            ElencoMostre.ColumnCount = 9;
            ElencoMostre.ColumnHeadersVisible = false;
            ElencoMostre.Columns[0].Visible = false;
            DataGridViewRow riga= new DataGridViewRow();
            //ElencoMostre.Rows.Add("NUMERO", "     ","TITOLO", "     ", "AUTORE", "     ", "     ");
            ElencoMostre.Rows.Add("NUM", "  ", "MOSTRA", "  ", "AUTORE", "  ", "CREAZIONE", "  ", "VISUALIZZA POSTER");
            ElencoMostre.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
            ElencoMostre.Rows.Add();
            ElencoMostre.CellClick += new DataGridViewCellEventHandler(this.ClickSullaTabella);
            ElencoMostre.CellMouseEnter += new DataGridViewCellEventHandler(ElencoMostre_CellMouseEnter);
            RiempiDataGrid();
        }
        
        
        
        // Riempimento della DataGrid
        private void RiempiDataGrid() {
            int riga=2;
            for (int i = 0; i < mostre.Count; i=i+4) {
                DataGridViewImageCell modify = new DataGridViewImageCell();
                modify.Value = immagine_modifica_mostra;
                modify.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                ElencoMostre.Rows.Add((int)mostre[i],null,(String)mostre[i+1],null,(String)mostre[i+2],null,(DateTime)mostre[i+3],null,null);
                ElencoMostre[8, riga] = modify;
                //ElencoMostre[8,riga].
                //ElencoMostre[10, riga] = immagine;
                ElencoMostre.Rows.Add();
                riga+= 2;
            }

        }
        #endregion

        # region gestione eventi
        // gestore degli eventi sulla DataGrid

        private void ElencoMostre_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((ElencoMostre[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 8))
            {
                ElencoMostre.Cursor = Cursors.Hand;
            }
            else
                ElencoMostre.Cursor = Cursors.Default;
        }
        
        private void ClickSullaTabella(object sender, DataGridViewCellEventArgs e)
        {
            if ((ElencoMostre[e.ColumnIndex, e.RowIndex].Value != null)&&(e.ColumnIndex==8))
            {
                //this.Visible = false;
                this.Cursor = Cursors.WaitCursor;
                FormScegliPoster nuova = new FormScegliPoster(this,FormBenvenuto, (int)ElencoMostre[0,e.RowIndex].Value,(string)ElencoMostre[2,e.RowIndex].Value,(string)ElencoMostre[4,e.RowIndex].Value,directoryprincipale,database);
                nuova.Show();
                this.Cursor = Cursors.Default;
                this.Visible = false;
            }
        }
       
        // gestione Button Indietro per uscire
        private void Indietro_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            FormBenvenuto.Visible = true;
            this.Cursor = Cursors.Default;
            this.Close();
        }
        #endregion

        private void Menu_Click(object sender, EventArgs e)
        {
            Question richiesta = new Question(FormBenvenuto, global.home);
            richiesta.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }
    }
}
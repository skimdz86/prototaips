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
using NHibernate;
using NHibernate.Cfg;
using RFIDlibrary;

namespace TalkingPaper.RfidCode
{
    public partial class ScegliMostraRFID : FormSchema
    {
        private string directoryprincipale;
        private BenvenutoRFID FormBenvenuto;
        private ArrayList mostre;
        private Bitmap image;
        private string database;
        private TalkingPaper.NHibernateManager nh_manager;
        private IList mostra_sel;
        private Bitmap immagine_modifica_mostra;

        # region CaricaForm
        public ScegliMostraRFID(string directory, BenvenutoRFID benvenuto, string database)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 90, true);
            nh_manager = new NHibernateManager();
            this.Show();
            this.directoryprincipale = directory;
            this.database=database;
            FormBenvenuto = benvenuto;
            immagine_modifica_mostra = new Bitmap(directory + @"/Images/Icons/modifica3.gif");
            Indietro.Cursor = Cursors.Hand;
            //image = new Bitmap(directoryprincipale + @"/Images/Icons/SelezionaMostra.gif");
            InterrogaDB();
        }

        private void ScegliMostra_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Connessione al DB e DataGrid

        // connessione al DB e letture dei dati
        private void InterrogaDB() {
            using (ISession tempS= nh_manager.Session)
            using (ITransaction tempT = tempS.BeginTransaction())
            {
                try
                {
                    IQuery q = tempS.CreateQuery("FROM Mostra as ms");
                    mostra_sel = q.List();
                    //tempT.Commit();
                    if (mostra_sel.Count == 0)
                    {
                        MessageBox.Show("Non è presente nessuna mostra");
                        FormBenvenuto.Enabled = true;
                        this.Close();
                    }
                    else {
                        mostre = new ArrayList();
                        foreach (Mostra m in mostra_sel)
                        {
                            mostre.Add(m.IDmostra);
                            mostre.Add(m.Nome);
                            mostre.Add(m.Autore);
                            mostre.Add(m.DataInizio);
                        }
                        SetDataGrid();
                    }
                    tempT.Commit();
                }
                catch (Exception e)
                {
                    tempT.Rollback();
                    Console.WriteLine("Eccezione in Scegli Mostra");
                }
                finally
                {
                    tempS.Close();
                }
             }
        }
        
        // Inizializzazione della DataGrid
        private void SetDataGrid() {
            ElencoMostre.ColumnCount = 9;
            ElencoMostre.ColumnHeadersVisible = false;
            ElencoMostre.Columns[0].Visible = false;
            DataGridViewRow riga= new DataGridViewRow();
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
                ElencoMostre.Rows.Add((int)mostre[i], null, (String)mostre[i + 1], null, (String)mostre[i + 2], null, (DateTime)mostre[i + 3], null, null);
                ElencoMostre[8, riga] = modify;
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
                FormScegliPosterRFID nuova = new FormScegliPosterRFID(this,FormBenvenuto, (int)ElencoMostre[0,e.RowIndex].Value,(string)ElencoMostre[2,e.RowIndex].Value,(string)ElencoMostre[4,e.RowIndex].Value,directoryprincipale,database);
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
            QuestionRFID richiesta = new QuestionRFID(FormBenvenuto, global.home);
            richiesta.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }
    }
}
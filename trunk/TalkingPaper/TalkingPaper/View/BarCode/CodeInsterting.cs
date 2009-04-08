using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.OleDb;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Media;
using QuartzTypeLib;
using NHibernate;
using NHibernate.Cfg;

namespace TalkingPaper.BarCode
{
    public partial class CodeInsterting : FormSchema
    {
        private FormVisualizzaElementi elenco_elementi;
        private FormScegliPoster scelta_poster;
        private BenvenutoBarCode partenza;
        private int id_componente;
        private int poster;
        private string nome_poster;
        private int cod_mostra;
        private string directory_principale;
        private string database;
        private Bitmap immagine_modifica_code;
        private Bitmap immagine_code;
        //private DataGridView ElencoRisorse;
        //private int riga;
        //private int colonna;
        //private NHibernateManager nh_manager;
        private Bitmap taggato;
        private TalkingPaper.Postering.ComponentiDelPoster componenti_pos;
        private TalkingPaper.Postering.BenvenutoPostering benvenuto_pos;
        private TalkingPaper.RfidCode.BenvenutoRFID benvenuto_rfid;
        
        //FormScegliPoster scelta_poster,BenvenutoBarCode partenza, int poster, string nome_poster, int cod_mostra, string directory_principale, string database
        public CodeInsterting(FormVisualizzaElementi elenco_elementi, int id_componente, FormScegliPoster scelta_poster, BenvenutoBarCode partenza, int poster, string nome_poster, int cod_mostra, string directory_principale, string database, TalkingPaper.Postering.ComponentiDelPoster componenti_pos, TalkingPaper.Postering.BenvenutoPostering benvenuto_pos,TalkingPaper.RfidCode.BenvenutoRFID benvenuto_rfid)
            //(FormVisualizzaElementi elenco_elementi, DataGridView ElencoRisorse, int riga, int colonna, int id_contenuto, string directory_principale, string database)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 55, true);
            this.benvenuto_pos = benvenuto_pos;
            this.componenti_pos = componenti_pos;
            this.elenco_elementi = elenco_elementi;
            this.id_componente = id_componente;
            this.scelta_poster = scelta_poster;
            this.partenza = partenza;
            this.poster = poster;
            this.nome_poster = nome_poster;
            this.cod_mostra = cod_mostra;
            this.directory_principale = directory_principale;
            this.database = database;
            this.benvenuto_rfid = benvenuto_rfid;
            //this.riga = riga;
            //this.ElencoRisorse = ElencoRisorse;
            //this.colonna = colonna;
            //textBox1.Select(0,0);
            immagine_modifica_code = new Bitmap(directory_principale + @"/Images/Icons/SelezionaPannello.gif");
            immagine_code = new Bitmap(directory_principale + @"/Images/Icons/coding.gif");
            taggato = new Bitmap(directory_principale + @"/Images/Icons/virgoletta.gif");
            //Suggerimento.Select(0,0);
            Salva.Cursor = Cursors.Hand;
            Annulla.Cursor = Cursors.Hand;
        }

        private void CodeInsterting_Load(object sender, EventArgs e)
        {
            elenco_elementi.Visible=false;
        }


        #region Gestisci Eventi
        private void Annulla_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            elenco_elementi.Visible = true;
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void Salva_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (((textBox1.Text).CompareTo("")) == 0)
            {
                MessageBox.Show("Non hai inserito il codice del tag");
            }
            else if (textBox1.Text.Length != 7) {
                MessageBox.Show("Il codice deve essere di 7 caratteri");
            }
            else
            {
                MySqlConnection connection;
                connection = new MySqlConnection("server=localhost; username=root; password=root; database=" + database);
                connection.Open();
                MySqlCommand myC = new MySqlCommand("UPDATE contenuto SET Barcode=?Barcode WHERE IDcontenuto=?IDcontenuto");
                myC.Connection = connection;
                myC.Parameters.Add("?Barcode", MySqlDbType.String, 50).Value = textBox1.Text;
                myC.Parameters.Add("?IDcontenuto", MySqlDbType.Int32, 50).Value = id_componente;
                int dr2 = myC.ExecuteNonQuery();
                connection.Close();
                DataGridViewImageCell tagg = new DataGridViewImageCell();
                /*if ((textBox1.Text).CompareTo("0") == 0)
                {
                    immagine_codice.Value = immagine_code;
                }
                else
                {
                    immagine_codice.Value = immagine_modifica_code;
                }*/
                tagg.Value = taggato;
                tagg.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //ElencoRisorse[4, riga] = tagg;
                elenco_elementi.Close();
                FormVisualizzaElementi nuo = new FormVisualizzaElementi(scelta_poster, partenza, poster, nome_poster, cod_mostra, directory_principale, database,componenti_pos,benvenuto_pos,benvenuto_rfid);
                this.Close();
                nuo.Show();
            }
            this.Cursor = Cursors.Default;
        }
        #endregion  

        private void indietro_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Cursor = Cursors.Default;
            this.Close();
        }
    }
}
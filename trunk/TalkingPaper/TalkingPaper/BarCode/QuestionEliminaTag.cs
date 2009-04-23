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

namespace TalkingPaper.BarCode
{
    public partial class QuestionEliminaTag : Form
    {
        private FormScegliPoster scelta_poster;
        private BenvenutoBarCode partenza;
        private FormVisualizzaElementi elementi;
        private int id_contenuto;
        private int poster;
        private string nome_poster;
        private int cod_mostra;
        private string directory_principale;
        private string database;
        private TalkingPaper.Postering.ComponentiDelPoster componenti_pos;
        private TalkingPaper.Postering.BenvenutoPostering benvenuto_pos;
        private TalkingPaper.RfidCode.BenvenutoRFID benvenuto_rfid;
        
        //int poster, string nome_poster, int cod_mostra, string directory_principale, string database
        //(FormScegliPoster scelta_poster,BenvenutoBarCode partenza, int poster, string nome_poster, int cod_mostra, string directory_principale, string database

        public QuestionEliminaTag(FormVisualizzaElementi elementi, int id_contenuto, FormScegliPoster scelta_poster, BenvenutoBarCode partenza, int poster, string nome_poster, int cod_mostra, string directory_principale, string database, TalkingPaper.Postering.ComponentiDelPoster componenti_pos,TalkingPaper.Postering.BenvenutoPostering benvenuto_pos,TalkingPaper.RfidCode.BenvenutoRFID benvenuto_rfid)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 45, true);
            this.benvenuto_rfid = benvenuto_rfid;
            this.elementi = elementi;
            this.benvenuto_pos=benvenuto_pos;
            this.id_contenuto = id_contenuto;
            this.scelta_poster = scelta_poster;
            this.partenza = partenza;
            this.poster = poster;
            this.nome_poster = nome_poster;
            this.cod_mostra = cod_mostra;
            this.directory_principale = directory_principale;
            this.database = database;
            Si.Cursor = Cursors.Hand;
            Annulla.Cursor = Cursors.Hand;
        }

        private void Si_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            MySqlConnection connection;
            connection = new MySqlConnection("server=localhost; username=root; password=root; database=" + database);
            connection.Open();
            MySqlCommand myC = new MySqlCommand("UPDATE contenuto SET Barcode=?Barcode WHERE IDcontenuto=?IDcontenuto");
            myC.Connection = connection;
            myC.Parameters.Add("?Barcode", MySqlDbType.Int32, 50).Value = 0;
            myC.Parameters.Add("?IDcontenuto", MySqlDbType.Int32, 50).Value = id_contenuto;
            int dr2 = myC.ExecuteNonQuery();
            connection.Close();
            elementi.Close();
            FormVisualizzaElementi nuoova = new FormVisualizzaElementi(scelta_poster, partenza, poster, nome_poster, cod_mostra, directory_principale, database,componenti_pos,benvenuto_pos,benvenuto_rfid);
            //this.Close();
            nuoova.Show();
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void Annulla_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            elementi.Visible = true;
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void QuestionEliminaTag_Load(object sender, EventArgs e)
        {

        }
    }
}
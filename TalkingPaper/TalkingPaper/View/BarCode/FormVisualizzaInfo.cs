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
    public partial class FormVisualizzaInfo : FormSchema
    {
        private FormVisualizzaElementi visualizza_elementi;
        private int id_contenuto;
        private string directoryprincipale;
        private string descrizione;
        private string descrizione_tipologia;
        private string tipologia;
        private string nome_risorsa;
        private string path_risorsa;
        private string esetensione_risorsa;
        private string database;
        
        public FormVisualizzaInfo(FormVisualizzaElementi visualizza_elementi, int id_contenuto, string directoryprincipale, string database)
        {
            InitializeComponent();
            this.visualizza_elementi = visualizza_elementi;
            this.id_contenuto = id_contenuto;
            this.directoryprincipale = directoryprincipale;
            this.database = database;
        }

        private void FormVisualizzaInfo_Load(object sender, EventArgs e)
        {
            InterrogaDB();
        }

        #region Connessione al DB e Riempimento TextBox

        private void InterrogaDB(){
            MySqlConnection connection;
            MySqlConnection connection2;
            MySqlConnection connection3;
            connection = new MySqlConnection("server=localhost; username=root; password=root; database="+database);
            connection.Open();
            MySqlCommand myC = new MySqlCommand("SELECT Tipo,RisorsaMultimediale, Nome FROM contenuto WHERE IDcontenuto=?IDcontenuto");
            myC.Connection = connection;
            myC.Parameters.Add("?IDcontenuto", MySqlDbType.Int32, 50).Value = id_contenuto;
            MySqlDataReader dr2 = myC.ExecuteReader();
            dr2.Read();
            int tipo=dr2.GetInt32(0);
            int risorsa = dr2.GetInt32(1);
            descrizione= dr2.GetString(2);
            dr2.Close();
            connection.Close();
            connection2 = new MySqlConnection("server=localhost; username=root; password=root; database="+database);
            connection2.Open();
            MySqlCommand myC2 = new MySqlCommand("SELECT Descrizione, Tipo FROM tipologia WHERE IDtipologia=?IDtipologia");
            myC2.Connection = connection2;
            myC2.Parameters.Add("?IDtipologia", MySqlDbType.Int32, 50).Value = tipo;
            MySqlDataReader dr3 = myC2.ExecuteReader();
            dr3.Read();
            descrizione_tipologia = dr3.GetString(0);
            tipologia = dr3.GetString(1);
            dr3.Close();
            connection2.Close();
            connection3 = new MySqlConnection("server=localhost; username=root; password=root; database="+database);
            connection3.Open();
            MySqlCommand myC3 = new MySqlCommand("SELECT Nome, Path, Estensione FROM risorsamultimediale WHERE IDrisorsa=?IDrisorsa");
            myC3.Connection = connection3;
            myC3.Parameters.Add("?IDrisorsa", MySqlDbType.Int32, 50).Value = risorsa;
            MySqlDataReader dr4 = myC3.ExecuteReader();
            dr4.Read();
            nome_risorsa = dr4.GetString(0);
            path_risorsa = dr4.GetString(1);
            esetensione_risorsa = dr4.GetString(2);
            dr4.Close();
            connection3.Close();
            RiempiTextBox();
        }

        private void RiempiTextBox() {
            textBox1.Text = descrizione;
            textBox2.Text = tipologia;
            textBox3.Text = nome_risorsa;
            textBox4.Text = esetensione_risorsa;
            textBox5.Text = path_risorsa;
        }



        #endregion

        private void OK_Click(object sender, EventArgs e)
        {
            visualizza_elementi.Visible = true;
            this.Close();
        }
    }
}
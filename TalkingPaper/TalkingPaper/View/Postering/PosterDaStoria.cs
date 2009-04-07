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
using RFIDlibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using RFIDlibrary;
using NHibernate;
using NHibernate.Cfg;
using QuartzTypeLib;
using System.Xml;

namespace TalkingPaper.Postering
{
    public partial class PosterDaStoria : FormSchema
    {
        private string database = "prova";
        private string directory_principale;
        private int id_poster;
        private bool modifica;
        private Bitmap immagine_modifica_mostra;
        private BenvenutoPostering benvenuto;
        private string provenienza;
        private TalkingPaper.BarCode.BenvenutoBarCode benvenuto_bar;
        private TalkingPaper.RfidCode.BenvenutoRFID benvenuto_rfid;
        private TalkingPaper.BarCode.FormVisualizzaElementi visualizza_bar;
        private TalkingPaper.RfidCode.FormVisualizzaElementiRFID visualizza_rfid;
        private TalkingPaper.Postering.ComponentiDelPoster visualizza_poster;

        public PosterDaStoria(string directory_principale, BenvenutoPostering benvenuto, bool modifica, int id_poster, string provenienza, TalkingPaper.BarCode.BenvenutoBarCode benvenuto_bar, TalkingPaper.RfidCode.BenvenutoRFID benvenuto_rfid, TalkingPaper.BarCode.FormVisualizzaElementi visualizza_bar, TalkingPaper.RfidCode.FormVisualizzaElementiRFID visualizza_rfid,TalkingPaper.Postering.ComponentiDelPoster visualizza_poster)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 90, true);
            this.benvenuto = benvenuto;
            this.benvenuto_bar = benvenuto_bar;
            this.benvenuto_rfid = benvenuto_rfid;
            this.visualizza_bar = visualizza_bar;
            this.visualizza_rfid = visualizza_rfid;
            this.provenienza = provenienza;
            this.directory_principale = directory_principale;
            this.modifica = modifica;
            this.id_poster = id_poster;
            this.visualizza_poster = visualizza_poster;
            //button1.Cursor = Cursors.Hand;
            immagine_modifica_mostra = new Bitmap(directory_principale + @"/Images/Icons/modifica3.gif");
            //InitializeComponent();
            button1.Cursor = Cursors.Hand;
            /*if (benvenuto == null)
            {
                button1.Visible = false;
            }*/
            RiempiDataGrid();
        }

        private void PosterDaStoria_Load(object sender, EventArgs e)
        {

        }

        private void RiempiDataGrid() {
            //label2.Visible = false;
            ElencoStorie.Visible = true;
            //mostre = new ArrayList();
            //mostre = (ArrayList)mostre_sel;

            // Setting della DataGrid
            ElencoStorie.ColumnCount = 7;
            ElencoStorie.ColumnHeadersVisible = false;
            ElencoStorie.Columns[0].Visible = false;
            //DataGridViewRow riga = new DataGridViewRow();
            ElencoStorie.Rows.Add("ID PROG.", "  ", "NOME", "  ","DATA CREAZIONE","  ","SCEGLI"); // ,"  ", "ELIMINA");
            ElencoStorie.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
            ElencoStorie.Rows.Add();
            ElencoStorie.CellClick += new DataGridViewCellEventHandler(this.ClickSullaTabella);
            ElencoStorie.CellMouseEnter += new DataGridViewCellEventHandler(ElencoStorie_CellMouseEnter);
            string nome_file = directory_principale + "StorieImportate.xml";
            bool esiste = System.IO.File.Exists(nome_file);
            if (esiste == true)
            {
                try
                {
                    XmlTextReader iscritto = new XmlTextReader(directory_principale + "StorieImportate" + ".xml");
                    //bool fine = false;
                    int rigaaa = 2;
                    //int j = 1;
                    while (iscritto.Read())
                    {
                        if (iscritto.NodeType == XmlNodeType.Element)
                        {
                            if (iscritto.LocalName.Equals("ID"))
                            {
                                //string id = (String)iscritto.GetAttribute("ID");
                                //bool trov = iscritto.ReadToDescendant("IDcontenuto");
                                ElencoStorie.Rows.Add();
                                string id = (String)iscritto.ReadString();
                                ElencoStorie[0, rigaaa].Value = Int32.Parse(id);
                            }
                            else if (iscritto.LocalName.Equals("Nome"))
                            {
                                //string id = (String)iscritto.GetAttribute("ID");
                                //bool trov = iscritto.ReadToDescendant("IDcontenuto");
                                //ElencoStorie.Rows.Add();
                                string id = (String)iscritto.ReadString();
                                ElencoStorie[2, rigaaa].Value = id;
                            }
                            else if (iscritto.LocalName.Equals("TimeStamp"))
                            {
                                //string id = (String)iscritto.GetAttribute("ID");
                                //bool trov = iscritto.ReadToDescendant("IDcontenuto");
                                //ElencoStorie.Rows.Add();
                                string id = (String)iscritto.ReadString();
                                ElencoStorie[4, rigaaa].Value = id;
                                DataGridViewImageCell immagine_modifica = new DataGridViewImageCell();
                                immagine_modifica.Value = immagine_modifica_mostra;
                                immagine_modifica.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                ElencoStorie[6, rigaaa] = immagine_modifica;
                                ElencoStorie.Rows.Add();
                                rigaaa += 2;
                            }
                        }
                    }
                }
                catch { 
                
                }
            }
            else
            {
                MySqlConnection connection;
                connection = new MySqlConnection("server=localhost; username=root; password=root; database=" + database);
                connection.Open();
                MySqlCommand myC = new MySqlCommand("SELECT ID,name,timestamp FROM project WHERE ((ID=?ID1)OR(ID=?ID2)OR(ID=?ID3)OR(ID=?ID4)OR(ID=?ID5)OR(ID=?ID6)OR(ID=?ID7))");
                myC.Connection = connection;
                myC.Parameters.Add("?ID1", MySqlDbType.Int32, 50).Value = 150;
                myC.Parameters.Add("?ID2", MySqlDbType.Int32, 50).Value = 151;
                myC.Parameters.Add("?ID3", MySqlDbType.Int32, 50).Value = 153;
                myC.Parameters.Add("?ID4", MySqlDbType.Int32, 50).Value = 154;
                myC.Parameters.Add("?ID5", MySqlDbType.Int32, 50).Value = 156;
                myC.Parameters.Add("?ID6", MySqlDbType.Int32, 50).Value = 249;
                myC.Parameters.Add("?ID7", MySqlDbType.Int32, 50).Value = 253;
                MySqlDataReader dr2 = myC.ExecuteReader();
                int riga = 2;
                while (dr2.Read())
                {
                    ElencoStorie.Rows.Add((int)dr2.GetInt32(0), null, (String)dr2.GetString(1), null, (DateTime)dr2.GetDateTime(2));
                    DataGridViewImageCell immagine_modifica = new DataGridViewImageCell();
                    immagine_modifica.Value = immagine_modifica_mostra;
                    immagine_modifica.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    ElencoStorie[6, riga] = immagine_modifica;
                    ElencoStorie.Rows.Add();
                    riga += 2;
                }
            }
        }

        private void ElencoStorie_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                if (ElencoStorie[e.ColumnIndex, e.RowIndex].Value != null)
                {
                    ElencoStorie.Cursor = Cursors.Hand;
                }
                else
                    ElencoStorie.Cursor = Cursors.Default;
            }
            else
                ElencoStorie.Cursor = Cursors.Default;
        }

        private void ClickSullaTabella(object sender, DataGridViewCellEventArgs e)
        {
            if ((ElencoStorie[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 6)) {
                //this.Visible = false;
                this.Cursor = Cursors.WaitCursor;
                EccoLaStoria nuova = new EccoLaStoria((int)ElencoStorie[0, e.RowIndex].Value, directory_principale,this,benvenuto,modifica,id_poster,provenienza,benvenuto_bar,benvenuto_rfid,visualizza_bar,visualizza_rfid,visualizza_poster);
                nuova.Show();
                this.Cursor = Cursors.Default;
                this.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (visualizza_poster != null) {
                visualizza_poster.Visible = true;
                this.Cursor = Cursors.Default;
                this.Close();
            }
            else if (benvenuto != null)
            {
                benvenuto.Visible = true;
                this.Cursor = Cursors.Default;
                this.Close();
            }
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            QuestionPostering richiesta = new QuestionPostering(benvenuto, global.home, null, benvenuto_bar, benvenuto_rfid, visualizza_bar, visualizza_rfid);
            richiesta.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }



    }
}
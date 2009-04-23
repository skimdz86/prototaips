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

namespace TalkingPaper
{
    public partial class FiltroStorie : FormSchema
    {
        private string database = "prova";
        private string directory_principale;
        private FormAmministrazione amministrazione;

        public FiltroStorie(FormAmministrazione amministrazione, string directory_principale)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 90, true);
            this.amministrazione = amministrazione;
            this.directory_principale = directory_principale;
            button1.Cursor = Cursors.Hand;
            button2.Cursor = Cursors.Hand;
            RiempiDataGrid();
        }

        private void FiltroStorie_Load(object sender, EventArgs e)
        {

        }

        private void RiempiDataGrid()
        {
            //label2.Visible = false;
            ElencoStorie.Visible = true;
            //mostre = new ArrayList();
            //mostre = (ArrayList)mostre_sel;

            // Setting della DataGrid
            ElencoStorie.ColumnCount = 7;
            ElencoStorie.ColumnHeadersVisible = false;
            //ElencoStorie.Columns[0].Visible = false;
            //DataGridViewRow riga = new DataGridViewRow();
            ElencoStorie.Rows.Add("ID PROG.", "  ", "NOME", "  ", "DATA CREAZIONE", "  ", "IMPORTA"); // ,"  ", "ELIMINA");
            ElencoStorie.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
            ElencoStorie[0, 0].Selected = false;
            ElencoStorie.Rows.Add();
            ElencoStorie.CellClick += new DataGridViewCellEventHandler(this.ClickSullaTabella);
            ElencoStorie.CellMouseEnter += new DataGridViewCellEventHandler(ElencoStorie_CellMouseEnter);
            MySqlConnection connection;
            connection = new MySqlConnection("server=localhost; username=root; password=root; database=" + database);
            connection.Open();
            MySqlCommand myC = new MySqlCommand("SELECT ID,name,timestamp FROM project");
            myC.Connection = connection;
            /*myC.Parameters.Add("?ID1", MySqlDbType.Int32, 50).Value = 150;
            myC.Parameters.Add("?ID2", MySqlDbType.Int32, 50).Value = 151;
            myC.Parameters.Add("?ID3", MySqlDbType.Int32, 50).Value = 153;
            myC.Parameters.Add("?ID4", MySqlDbType.Int32, 50).Value = 154;
            myC.Parameters.Add("?ID5", MySqlDbType.Int32, 50).Value = 156;
            myC.Parameters.Add("?ID6", MySqlDbType.Int32, 50).Value = 249;
            myC.Parameters.Add("?ID7", MySqlDbType.Int32, 50).Value = 253;*/
            MySqlDataReader dr2 = myC.ExecuteReader();
            int riga = 2;
            while (dr2.Read())
            {
                ElencoStorie.Rows.Add((int)dr2.GetInt32(0), null, (String)dr2.GetString(1), null, (DateTime)dr2.GetDateTime(2));
                /*DataGridViewImageCell immagine_modifica = new DataGridViewImageCell();
                immagine_modifica.Value = immagine_modifica_mostra;*/
                DataGridViewCheckBoxCell cella = new DataGridViewCheckBoxCell();
                cella.Value = false;
                cella.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                ElencoStorie[6, riga] =cella;
                ElencoStorie.Rows.Add();
                riga += 2;
            }
        }

        private void CreaFileXml() {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.NewLineOnAttributes = true;
                XmlWriter wr = XmlWriter.Create(directory_principale + "StorieImportate" + ".xml");
                wr.WriteStartDocument();
                wr.WriteStartElement("ProgettiImportati");
                /*wr.WriteStartElement("Utente");
                wr.WriteStartElement("User");
                wr.WriteString(textBox1.Text);
                wr.WriteEndElement();
                wr.WriteStartElement("Password");
                wr.WriteString(maskedTextBox1.Text);
                wr.WriteEndElement();
                wr.WriteEndElement();*/
                for (int i = 2; i < ElencoStorie.Rows.Count; i = i + 2)
                {
                    if ((bool)ElencoStorie[6, i].Value == true)
                    {
                        wr.WriteStartElement("Progetto");
                        wr.WriteStartElement("ID");
                        //wr.WriteStartElement("User");
                        wr.WriteString(((int)ElencoStorie[0,i].Value).ToString());
                        wr.WriteEndElement();
                        wr.WriteStartElement("Nome");
                        //wr.WriteStartElement("User");
                        wr.WriteString((string)ElencoStorie[2, i].Value);
                        wr.WriteEndElement();
                        wr.WriteStartElement("TimeStamp");
                        //wr.WriteStartElement("User");
                        wr.WriteString(((DateTime)ElencoStorie[4, i].Value).ToString());
                        wr.WriteEndElement();
                        /*wr.WriteStartElement("Password");
                        wr.WriteString((string)iscritti[i + 1]);
                        wr.WriteEndElement();
                        wr.WriteEndElement();*/
                        wr.WriteEndElement();
                    }
                }
                wr.WriteEndElement();
                //wr.WriteEndElement();
                wr.WriteEndDocument();
                wr.Flush();
                wr.Close();
                this.Cursor = Cursors.Default;
                MessageBox.Show("Storie importate");
            }
            catch
            {

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
            if ((ElencoStorie[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 6))
            {
                if ((bool)ElencoStorie[e.ColumnIndex, e.RowIndex].Value == false)
                {
                    ElencoStorie[e.ColumnIndex, e.RowIndex].Value = true;
                }
                else {
                    ElencoStorie[e.ColumnIndex, e.RowIndex].Value = false;
                }
            }
            else { 
                
            }
             /*for (int i = 2; i < ElencoStorie.Rows.Count; i++)
                {
                    if ((ElencoStorie[6, i].Value != null) && (ElencoTag[6, i] != null) && (i != e.RowIndex))
                    {
                        ElencoTag[6, i].Value = false;
                    }
                }
            }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            amministrazione.Visible = true;
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreaFileXml();
            amministrazione.Visible = true;
            this.Close();
        }

        private void ElencoStorie_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //add by mac
            if (pictureBoxPost2.Visible = true)
            {
                pictureBoxPost2.Visible = false;
                textBoxPost.Visible = false;
            }
            else
            {
                pictureBoxPost2.Visible = true;
                textBoxPost.Visible = true;
            }

        }
    }
}
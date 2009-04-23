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

namespace TalkingPaper.GestioneDisposizione
{
    public partial class ScegliPannelloPerConfigurazione : Form
    {
        private string directory_principale;
        private BenvenutoGestioneDisposizione benvenuto;
        private ArrayList pannelli = new ArrayList();
        private Bitmap modifica;
        private FormAmministrazione amministrazione;
        
        public ScegliPannelloPerConfigurazione(string directory_principale, BenvenutoGestioneDisposizione benvenuto,FormAmministrazione amministrazione)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 90, true);
            this.amministrazione = amministrazione;
            button1.Cursor = Cursors.Hand;
            modifica = new Bitmap(directory_principale + @"/Images/Icons/modifica3.gif");
            this.benvenuto = benvenuto;
            this.directory_principale = directory_principale;
            RiempiDataGrid();
        }

        private void ScegliPannelloPerConfigurazione_Load(object sender, EventArgs e)
        {

        }

        private void RiempiDataGrid() {
            Font font = new Font("Arial", 16);
            ElencoPannelli.Visible = true;
            //mostre = new ArrayList();
            //mostre = (ArrayList)mostre_sel;
            // Setting della DataGrid
            ElencoPannelli.ColumnCount = 8;
            ElencoPannelli.ColumnHeadersVisible = false;
            ElencoPannelli.Columns[0].Visible = false;
            //DataGridViewRow riga = new DataGridViewRow();
            ElencoPannelli.Rows.Add("TAG", "  ", "NOME", "  ","RIGHE","  ","COLONNE", "SELEZIONA"); // ,"  ", "ELIMINA");
            ElencoPannelli.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
            ElencoPannelli.Rows[0].DefaultCellStyle.Font = font;
            ElencoPannelli.Rows.Add();
            ElencoPannelli.CellClick += new DataGridViewCellEventHandler(this.ClickSullaTabella);
            ElencoPannelli.CellMouseEnter += new DataGridViewCellEventHandler(ElencoRisorse_CellMouseEnter);
            try
            {
                XmlTextReader iscritto = new XmlTextReader(directory_principale + "PannelliTaggati" + ".xml");
                //bool fine = false;
                while ((iscritto.Read()))
                {
                    if (iscritto.NodeType == XmlNodeType.Element)
                    {
                        if (iscritto.LocalName.Equals("NomePannello"))
                        {
                            string id = (String)iscritto.GetAttribute("ID");
                            string righe = (String)iscritto.GetAttribute("TAG_PER_RIGA");
                            string colonne = (String)iscritto.GetAttribute("TAG_PER_COLONNA");
                            string ins = (String)iscritto.ReadString();
                            //string id = (String)iscritto.GetAttribute("ID");
                            int tag_per_riga = Int32.Parse(righe);
                            int tag_per_colonna = Int32.Parse(colonne);
                            pannelli.Add(ins);
                            pannelli.Add(id);
                            pannelli.Add(tag_per_riga);
                            pannelli.Add(tag_per_colonna);
                        }
                    }
                }
                iscritto.Close();
            }
            catch
            {
            }
            int riga=2;
            for (int i = 0; i < pannelli.Count; i = i + 4) {
                ElencoPannelli.Rows.Add(pannelli[i + 1], null, pannelli[i], null, pannelli[i+2],null,pannelli[i+3],null);
                DataGridViewImageCell im = new DataGridViewImageCell();
                im.Value = modifica;
                ElencoPannelli[7, riga] = im;
                riga += 2;
                ElencoPannelli.Rows.Add();
            }
        }

        private void ElencoRisorse_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 7) && (ElencoPannelli[e.ColumnIndex, e.RowIndex].Value != null))
            {
                this.Cursor = Cursors.Hand;
            }
            else {
                this.Cursor = Cursors.Default;
            }

        }

        private void ClickSullaTabella(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 7) && (ElencoPannelli[e.ColumnIndex, e.RowIndex].Value != null))
            {
                this.Cursor = Cursors.WaitCursor;
                ScegliConfigurazione n = new ScegliConfigurazione((String)ElencoPannelli[2, e.RowIndex].Value.ToString(), (String)ElencoPannelli[0, e.RowIndex].Value.ToString(), benvenuto, amministrazione, (int)ElencoPannelli[4, e.RowIndex].Value, (int)ElencoPannelli[6, e.RowIndex].Value);
                n.Show();
                this.Cursor = Cursors.Default;
                this.Close();
            }
            else { 
            
            }
        }


        private void button7_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (benvenuto != null)
            {
                benvenuto.Visible = true;
            }
            else if (amministrazione != null)
            {
                amministrazione.Visible = true;
            }
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
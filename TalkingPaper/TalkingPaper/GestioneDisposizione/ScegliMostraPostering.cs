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

namespace TalkingPaper.GestioneDisposizione
{
    public partial class ScegliMostraPostering : FormSchema
    {
        private BenvenutoGestioneDisposizione benvenuto;
        private string directory_principale;
        private TalkingPaper.NHibernateManager nh_manager;
        // private ArrayList mostre;
        private Bitmap immagine_modifica_mostra;
        private Bitmap elimina;
        //private IList mostre_sel;
        /*private TalkingPaper.BarCode.BenvenutoBarCode benvenuto_bar;
        private TalkingPaper.RfidCode.BenvenutoRFID benvenuto_rfid;
        private TalkingPaper.BarCode.FormVisualizzaElementi visualizza_bar;
        private TalkingPaper.RfidCode.FormVisualizzaElementiRFID visualizza_rfid;
        private TalkingPaper.Authoring.BenvenutoAuthoring benvenuto_aut;*/
        private TalkingPaper.Authoring.FormVisualizzaElementiAuthoring visualizza_aut;
        private ProgressBar progress_bar;

        public ScegliMostraPostering(BenvenutoGestioneDisposizione benvenuto, string directory_principale, /*TalkingPaper.Authoring.BenvenutoAuthoring benvenuto_aut,*/ TalkingPaper.Authoring.FormVisualizzaElementiAuthoring visualizza_aut, ProgressBar progress_bar)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 90, true);
            this.progress_bar = progress_bar;
            this.benvenuto = benvenuto;
            this.directory_principale = directory_principale;
            /*this.benvenuto_bar = benvenuto_bar;
            this.benvenuto_rfid = benvenuto_rfid;
            this.visualizza_bar = visualizza_bar;
            this.visualizza_rfid = visualizza_rfid;*/
            //this.benvenuto_aut = benvenuto_aut;
            this.visualizza_aut = visualizza_aut;
            this.nh_manager = new NHibernateManager();
            immagine_modifica_mostra = new Bitmap(directory_principale + @"/Images/Icons/modifica3.gif");
            elimina = new Bitmap(directory_principale + @"/Images/Icons/elimina_cestino.gif");
            //textBox1.Select(0, 0);
            if (benvenuto == null)
            {
                button2.Visible = false;
            }
            button2.Cursor = Cursors.Hand;
            InterrogaDB();
        }

        private void ScegliMostraPostering_Load(object sender, EventArgs e)
        {

        }

        private void InterrogaDB()
        {
            using (ISession tempS = nh_manager.Session)
            using (ITransaction tempT = tempS.BeginTransaction())
            {
                try
                {
                    progress_bar.Increment(10);
                    IList mostre_sel;
                    IQuery q = tempS.CreateQuery("FROM Mostra as ms");
                    mostre_sel = q.List();
                    tempT.Commit();
                    progress_bar.Increment(10);
                    if (mostre_sel.Count == 0)
                    {
                        label2.Visible = true;
                        ElencoRisorse.Visible = false;
                        progress_bar.Value = progress_bar.Maximum;
                    }
                    else
                    {
                        label2.Visible = false;
                        ElencoRisorse.Visible = true;
                        //mostre = new ArrayList();
                        //mostre = (ArrayList)mostre_sel;

                        // Setting della DataGrid
                        ElencoRisorse.ColumnCount = 11;
                        ElencoRisorse.ColumnHeadersVisible = false;
                        ElencoRisorse.Columns[0].Visible = false;
                        //DataGridViewRow riga = new DataGridViewRow();
                        ElencoRisorse.Rows.Add("NUM", "  ", "MOSTRA", "  ", "AUTORE", "  ", "CREAZIONE", "  ", "MODIFICA", "  ", "ELIMINA");
                        ElencoRisorse.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
                        ElencoRisorse.Rows.Add();
                        ElencoRisorse.CellClick += new DataGridViewCellEventHandler(this.ClickSullaTabella);
                        ElencoRisorse.CellMouseEnter += new DataGridViewCellEventHandler(ElencoRisorse_CellMouseEnter);
                        progress_bar.Increment(10);

                        // Riempimento della DataGrid
                        int riga = 2;
                        foreach (Mostra m in mostre_sel)
                        {
                            DataGridViewImageCell immagine_modifica = new DataGridViewImageCell();
                            immagine_modifica.Value = immagine_modifica_mostra;
                            immagine_modifica.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            DataGridViewImageCell immagine_elimina = new DataGridViewImageCell();
                            immagine_elimina.Value = elimina;
                            immagine_elimina.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            ElencoRisorse.Rows.Add(m.IDmostra, null, m.Nome, null, m.Autore, null, m.DataInizio, null, null, null, null);
                            ElencoRisorse[8, riga] = immagine_modifica;
                            //ElencoRisorse[8, riga].DataGridView.MouseMove += new MouseEventHandler(this.MoveMouse);
                            //ElencoRisorse.CellMouseUp+=new DataGridViewCellMouseEventHandler(this.MoveMouse);
                            ElencoRisorse[10, riga] = immagine_elimina;
                            ElencoRisorse.Rows.Add();
                            riga += 2;
                            progress_bar.Increment(5);
                        }
                        progress_bar.Increment(10);
                        /* // Creazione e riempimento della DataGrid
                        ElencoRisorse.ColumnCount = 7;
                        ElencoRisorse.ColumnHeadersVisible = false;
                        DataGridViewRow riga = new DataGridViewRow();
                        ElencoRisorse.Rows.Add("NUM", "  ", "POSTER", "  ", "     ","  ","     ");
                        ElencoRisorse.Rows.Add();
                        ElencoRisorse.CellClick += new DataGridViewCellEventHandler(this.ClickSullaTabella);*/

                    }
                }
                catch (Exception ex)
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

        /*  private void SetDataGrid()
          {
              ElencoRisorse.ColumnCount = 5;
              ElencoRisorse.ColumnHeadersVisible = false;
              DataGridViewRow riga = new DataGridViewRow();
              ElencoRisorse.Rows.Add("NUM", "  ", "MOSTRA", "  ","CREAZIONE","  ", "MODIFICA");
              ElencoRisorse.Rows.Add();
              ElencoRisorse.CellClick += new DataGridViewCellEventHandler(this.ClickSullaTabella);
              RiempiDataGrid();
          }

          private void RiempiDataGrid() {
              int riga = 2;
              for (int i = 0; i < mostre.Count; i = i + 4)
              {
                  DataGridViewImageCell immagine_modifica = new DataGridViewImageCell();
                  immagine_modifica.Value = immagine_modifica_mostra;
                
                  ElencoRisorse.Rows.Add((Mostra)mostre.);
                  ElencoRisorse[4, riga] = immagine_suono;
                  ElencoRisorse[6, riga] = immagine_pausa;
                  ElencoRisorse[8, riga] = immagine_stop_suono;
                  ElencoRisorse[10, riga] = immagine_codice;
                  ElencoRisorse.Rows.Add();
                  riga += 2;
              }
          }*/

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            benvenuto.Visible = true;
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void ClickSullaTabella(object sender, DataGridViewCellEventArgs e)
        {
            if ((ElencoRisorse[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 8))
            {
                //this.Visible = false;
                this.Cursor = Cursors.WaitCursor;
                PosterDellaMostra nuova = new PosterDellaMostra(benvenuto, this, (int)ElencoRisorse[0, e.RowIndex].Value, (string)ElencoRisorse[2, e.RowIndex].Value, directory_principale, visualizza_aut,null,null,null);
                nuova.Show();
                this.Cursor = Cursors.Default;
                this.Visible = false;
            }
            else if ((ElencoRisorse[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 10))
            {
                //this.Visible = false;
                this.Cursor = Cursors.WaitCursor;
                QuestionEliminaMostra nuovaaa = new QuestionEliminaMostra(this, (int)ElencoRisorse[0, e.RowIndex].Value, benvenuto, directory_principale, visualizza_aut);
                nuovaaa.Show();
                this.Cursor = Cursors.Default;
                this.Visible = false;
            }
        }
        private void ElencoRisorse_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 8) || (e.ColumnIndex == 10))
            {
                if (ElencoRisorse[e.ColumnIndex, e.RowIndex].Value != null)
                {
                    ElencoRisorse.Cursor = Cursors.Hand;
                }
                else ElencoRisorse.Cursor = Cursors.Default;
            }
            else ElencoRisorse.Cursor = Cursors.Default;
            //ElencoRisorse.Cursor = Cursors.Hand;
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            QuestionPostering richiesta = new QuestionPostering(benvenuto, global.home, null,  visualizza_aut);
            richiesta.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }
    }
}
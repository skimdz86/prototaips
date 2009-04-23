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

namespace TalkingPaper.Postering
{
    public partial class QuestionEliminaPoster : Form
    {
        private PosterDellaMostra elenco_poster;
        private BenvenutoPostering benvenuto;
        private ScegliMostraPostering elenco_mostre;
        private TalkingPaper.NHibernateManager nh_manager;
        private int id_mostra;
        private int id_pannello;
        private string nome_pannello;
        private string nome_mostra;
        private string directory_principale;
        private TalkingPaper.BarCode.BenvenutoBarCode benvenuto_bar;
        private TalkingPaper.RfidCode.BenvenutoRFID benvenuto_rfid;
        private TalkingPaper.BarCode.FormVisualizzaElementi visualizza_bar;
        private TalkingPaper.RfidCode.FormVisualizzaElementiRFID visualizza_rfid;

        public QuestionEliminaPoster(PosterDellaMostra elenco_poster, int id_mostra, int id_pannello, string nome_pannello, BenvenutoPostering benvenuto, ScegliMostraPostering elenco_mostre, string nome_mostra, string directory_principale, TalkingPaper.BarCode.BenvenutoBarCode benvenuto_bar, TalkingPaper.RfidCode.BenvenutoRFID benvenuto_rfid, TalkingPaper.BarCode.FormVisualizzaElementi visualizza_bar, TalkingPaper.RfidCode.FormVisualizzaElementiRFID visualizza_rfid)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 45, true);
            this.elenco_poster = elenco_poster;
            this.id_mostra = id_mostra;
            this.id_pannello = id_pannello;
            this.nome_pannello = nome_pannello;
            this.benvenuto = benvenuto;
            this.elenco_mostre = elenco_mostre;
            this.nome_mostra = nome_mostra;
            this.directory_principale = directory_principale;
            this.visualizza_bar = visualizza_bar;
            this.visualizza_rfid = visualizza_rfid;
            this.benvenuto_bar = benvenuto_bar;
            this.benvenuto_rfid = benvenuto_rfid;
            this.nh_manager = new NHibernateManager();
            Si.Cursor = Cursors.Hand;
            Annulla.Cursor = Cursors.Hand;
        }

        private void Annulla_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //this.Close();
            elenco_poster.Visible = true;
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void Si_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            using (ISession tempS = nh_manager.Session)
            using (ITransaction tempT = tempS.BeginTransaction())
            {
                try
                {
                    IQuery q = tempS.CreateQuery("FROM Poster as pt WHERE pt.IDposter=:Pos");
                    int idd_mostra;
                    Mostra mm = new Mostra();
                    q.SetParameter("Pos",id_pannello);
                    Poster poster = new Poster();
                    poster = (Poster)q.List()[0];
                    try
                    {
                        idd_mostra = poster.Mostra.IDmostra;
                        IQuery q2 = tempS.CreateQuery("FROM Mostra as ms WHERE ms.IDmostra=:Mos");
                        q2.SetParameter("Mos", idd_mostra);
                        mm = (Mostra)q2.List()[0];
                        mm.PosterLista.Remove(poster);
                        tempS.Update(mm);
                        tempS.Flush();
                    }
                    catch { }
                    tempS.Delete(poster);
                    //MessageBox.Show("Poster Eliminato");
                    tempT.Commit();
                    /*if (mostra_sel.PosterLista.Count == 0)
                    {
                        label2.Visible = true;
                        ElencoRisorse.Visible = false;
                    }
                    else
                    {
                        label2.Visible = false;
                        ElencoRisorse.Visible = true;
                        //mostre = new ArrayList();
                        //mostre = (ArrayList)mostre_sel;

                        // Setting della DataGrid
                        ElencoRisorse.ColumnCount = 9;
                        ElencoRisorse.ColumnHeadersVisible = false;
                        //DataGridViewRow riga = new DataGridViewRow();
                        ElencoRisorse.Rows.Add("NUM", "  ", "NOME", "  ", "DESCRIZIONE", "  ", "MODIFICA", "  ", "ELIMINA");
                        ElencoRisorse.Rows.Add();
                        ElencoRisorse.CellClick += new DataGridViewCellEventHandler(this.ClickSullaTabella);

                        // Riempimento della DataGrid
                        int riga = 2;
                        foreach (Poster p in mostra_sel.PosterLista)
                        {
                            DataGridViewImageCell immagine_modifica = new DataGridViewImageCell();
                            immagine_modifica.Value = immagine_modifica_poster;
                            DataGridViewImageCell delete = new DataGridViewImageCell();
                            delete.Value = elimina;
                            ElencoRisorse.Rows.Add(p.IDposter, null, p.Nome, null, p.Descrizione, null, null);
                            ElencoRisorse[6, riga] = immagine_modifica;
                            ElencoRisorse[8, riga] = delete;
                            ElencoRisorse.Rows.Add();
                            riga += 2;
                        }*/

                        /* // Creazione e riempimento della DataGrid
                        ElencoRisorse.ColumnCount = 7;
                        ElencoRisorse.ColumnHeadersVisible = false;
                        DataGridViewRow riga = new DataGridViewRow();
                        ElencoRisorse.Rows.Add("NUM", "  ", "POSTER", "  ", "     ","  ","     ");
                        ElencoRisorse.Rows.Add();
                        ElencoRisorse.CellClick += new DataGridViewCellEventHandler(this.ClickSullaTabella);*/
                }
                catch (Exception ex)
                {
                    tempT.Rollback();
                    Console.WriteLine("Eccezione in Scegli Mostra");
                }
                finally
                {
                    tempS.Close();
                    PosterDellaMostra poster_mostra = new PosterDellaMostra(benvenuto, elenco_mostre, id_mostra, nome_mostra, directory_principale,benvenuto_bar,benvenuto_rfid,visualizza_bar,visualizza_rfid);
                    //this.Close();
                    elenco_poster.Close();
                    poster_mostra.Show();
                    this.Cursor = Cursors.Default;
                    this.Close();
                }
            }
        }

        private void QuestionEliminaPoster_Load(object sender, EventArgs e)
        {

        }

        private void Si_Click_1(object sender, EventArgs e)
        {

        }
    }
}
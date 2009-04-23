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
    public partial class CreaNuovaMostra : FormSchema
    {
        private BenvenutoGestioneDisposizione benvenuto;
        private string directory_principale;
        private TalkingPaper.NHibernateManager nh_manager;
        private DateTime now;
        private IList mostra_sel;
        /*private TalkingPaper.BarCode.BenvenutoBarCode benvenuto_bar;
        private TalkingPaper.RfidCode.BenvenutoRFID benvenuto_rfid;
        private TalkingPaper.BarCode.FormVisualizzaElementi visualizza_bar;
        private TalkingPaper.RfidCode.FormVisualizzaElementiRFID visualizza_rfid;*/
        private TalkingPaper.Authoring.BenvenutoAuthoring benvenuto_aut;
        private TalkingPaper.Authoring.FormVisualizzaElementiAuthoring visualizza_aut;

        public CreaNuovaMostra(BenvenutoGestioneDisposizione benvenuto, string directory_principale, TalkingPaper.Authoring.BenvenutoAuthoring benvenuto_aut, TalkingPaper.Authoring.FormVisualizzaElementiAuthoring visualizza_aut)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 50, true);
            this.benvenuto = benvenuto;
            this.directory_principale = directory_principale;
            /*this.benvenuto_bar = benvenuto_bar;
            this.benvenuto_rfid = benvenuto_rfid;
            this.visualizza_bar = visualizza_bar;
            this.visualizza_rfid = visualizza_rfid;*/
            this.benvenuto_aut = benvenuto_aut;
            this.visualizza_aut = visualizza_aut;
            Crea.Cursor = Cursors.Hand;
            Annulla.Cursor = Cursors.Hand;
            label3.Visible = false;
            Credits.Visible = false;
            this.nh_manager = new NHibernateManager();
            //now = DateTime.Now;
            //textBox1.Select(0,0);
        }

        private void CreaNuovaMostra_Load(object sender, EventArgs e)
        {

        }

        #region Gestione Eventi

        private void Crea_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (Nome.Text == "")
            {
                MessageBox.Show("Inserisci il nome della mostra");
            }
            else if (Autore.Text == "")
            {
                MessageBox.Show("Inserisci l'autore della mostra");
            }
            /*else if (Credits.Text == "")
            {
                MessageBox.Show("Inserisci i credits");
            }*/
            else
            {
                using (ISession tempS = nh_manager.Session)
                using (ITransaction tempT = tempS.BeginTransaction())
                {
                    try
                    {
                        Mostra nuova = new Mostra();
                        now = DateTime.Now;
                        //nuova.PosterLista = new List();
                        nuova.Nome = Nome.Text;
                        nuova.Autore = Autore.Text;
                        //nuova.Credits = Credits.Text;
                        nuova.Credits = "";
                        nuova.DataInizio = now;
                        tempS.Save(nuova);
                        tempS.Flush();
                        // MessageBox.Show("Mostra creata");
                        IQuery q = tempS.CreateQuery("FROM Mostra as ms");
                        //q.SetParameter("Pos", cod_poster);
                        mostra_sel = q.List();
                        tempT.Commit();
                        int id_ultima = ((Mostra)mostra_sel[mostra_sel.Count - 1]).IDmostra;
                        string nome_mostra = ((Mostra)mostra_sel[mostra_sel.Count - 1]).Nome;
                        PosterDellaMostra poster = new PosterDellaMostra(benvenuto, null, id_ultima, nome_mostra, directory_principale,benvenuto_aut,visualizza_aut,null,null,null);
                        poster.Show();
                        this.Cursor = Cursors.Default;
                        this.Close();
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
            this.Cursor = Cursors.Default;
        }

        private void Annulla_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            benvenuto.Visible = true;
            this.Cursor = Cursors.Default;
            this.Close();
        }
        #endregion

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Indietro_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Close();
            this.Cursor = Cursors.Default;
            //componenti.Visible = true;
        }
    }
}
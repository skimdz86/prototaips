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
    public partial class CreaNuovaMostraPerSingolo : FormSchema
    {
        private TalkingPaper.NHibernateManager nh_manager;
        private AggiungiPosterAMostra aggiunta;
        private DateTime now;
        private ComponentiDelPoster componenti;
        private PosterDellaMostra poster;
        private int id_poster;
        private string directory_principale;
        private BenvenutoGestioneDisposizione benvenuto;
       /* private TalkingPaper.BarCode.BenvenutoBarCode benvenuto_bar;
        private TalkingPaper.RfidCode.BenvenutoRFID benvenuto_rfid;
        private TalkingPaper.BarCode.FormVisualizzaElementi visualizza_bar;
        private TalkingPaper.RfidCode.FormVisualizzaElementiRFID visualizza_rfid;
        private TalkingPaper.Authoring.BenvenutoAuthoring benvenuto_aut;*/
        private TalkingPaper.Authoring.FormVisualizzaElementiAuthoring visualizza_aut;

        public CreaNuovaMostraPerSingolo(BenvenutoGestioneDisposizione benvenuto, AggiungiPosterAMostra aggiunta, ComponentiDelPoster componenti, int id_poster, PosterDellaMostra poster, string directory_principale, /*TalkingPaper.Authoring.BenvenutoAuthoring benvenuto_aut,*/ TalkingPaper.Authoring.FormVisualizzaElementiAuthoring visualizza_aut)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 50, true);
            label3.Visible = false;
            Credits.Visible = false;
            /*this.visualizza_bar = visualizza_bar;
            this.benvenuto_bar = benvenuto_bar;
            this.benvenuto_rfid = benvenuto_rfid;
            this.visualizza_rfid = visualizza_rfid;*/
            //this.benvenuto_aut = benvenuto_aut;
            this.visualizza_aut = visualizza_aut;
            this.nh_manager = new NHibernateManager();
            this.aggiunta = aggiunta;
            this.componenti = componenti;
            this.id_poster = id_poster;
            this.poster = poster;
            this.benvenuto = benvenuto;
            Crea.Cursor = Cursors.Hand;
            Annulla.Cursor = Cursors.Hand;
            this.directory_principale = directory_principale;
        }

        private void CreaNuovaMostraPerSingolo_Load(object sender, EventArgs e)
        {

        }

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
                        tempT.Commit();
                        tempS.Flush();
                        MessageBox.Show("Mostra creata");
                        AggiungiPosterAMostra nuovaaa = new AggiungiPosterAMostra(benvenuto, componenti, id_poster, poster, directory_principale,visualizza_aut );
                        aggiunta.Close();
                        //this.Close();
                        nuovaaa.Show();
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
            //this.Close();
            aggiunta.Visible = true;
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void Indietro_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Close();
            this.Cursor = Cursors.Default;
            componenti.Visible = true;
        }

        private void sottotitolo_Click(object sender, EventArgs e)
        {

        }
    }
}
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
    public partial class AggiungiPosterAMostra : FormSchema
    {
        private TalkingPaper.NHibernateManager nh_manager;
        private ComponentiDelPoster componenti;
        private int id_poster;
        private ArrayList id_mostre;
        private PosterDellaMostra poster;
        private BenvenutoPostering benvenuto;
        private string directory_principale;
        //private bool taggato = false;
        private int id_mostra = 0;
        private TalkingPaper.BarCode.BenvenutoBarCode benvenuto_bar;
        private TalkingPaper.RfidCode.BenvenutoRFID benvenuto_rfid;
        private TalkingPaper.BarCode.FormVisualizzaElementi visualizza_bar;
        private TalkingPaper.RfidCode.FormVisualizzaElementiRFID visualizza_rfid;

        public AggiungiPosterAMostra(BenvenutoPostering benvenuto, ComponentiDelPoster componenti,int id_poster,PosterDellaMostra poster, string directory_principale,TalkingPaper.BarCode.BenvenutoBarCode benvenuto_bar, TalkingPaper.RfidCode.BenvenutoRFID benvenuto_rfid, TalkingPaper.BarCode.FormVisualizzaElementi visualizza_bar, TalkingPaper.RfidCode.FormVisualizzaElementiRFID visualizza_rfid)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 40, true);
            this.nh_manager = new NHibernateManager();
            this.componenti = componenti;
            this.id_poster = id_poster;
            this.poster = poster;
            this.benvenuto = benvenuto;
            this.directory_principale = directory_principale;
            this.benvenuto_bar = benvenuto_bar;
            this.benvenuto_rfid = benvenuto_rfid;
            this.visualizza_bar = visualizza_bar;
            this.visualizza_rfid = visualizza_rfid;
            CreaNuova.Cursor = Cursors.Hand;
            Aggiungi.Cursor = Cursors.Hand;
            Annulla.Cursor = Cursors.Hand;
            //bool taggato = false;
            using (ISession tempS = nh_manager.Session)
            using (ITransaction tempT = tempS.BeginTransaction())
            {
                try
                {
                    //Tipologia tipo = new Tipologia();
                    Poster posterr = new Poster();
                    bool taggato = false;
                    //Contenuto da_eliminare = new Contenuto();
                    IQuery q = tempS.CreateQuery("FROM Poster as pt WHERE pt.IDposter=:Pos");
                    q.SetParameter("Pos", id_poster);
                    posterr = (Poster)q.List()[0];
                    foreach (Contenuto c in posterr.ContenutoLista)
                    {
                        if ((c.Barcode.CompareTo("0")!=0) || (c.Rfidtag.CompareTo("0")!=0))
                        {
                            taggato = true;
                        }
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

        private void AggiungiPosterAMostra_Load(object sender, EventArgs e)
        {
            using (ISession tempS = nh_manager.Session)
            using (ITransaction tempT = tempS.BeginTransaction())
            {
                try
                {
                    //ArrayList id_mostre = new ArrayList();
                    id_mostre = new ArrayList();
                    IList mostre;
                    IQuery q = tempS.CreateQuery("FROM Mostra as ms");
                    //string mostre;
                    //q.SetParameter("Pos", id_poster);
                    mostre = q.List();
                    int i=0;
                    foreach (Mostra m in mostre) {
                        //ElencoMostre.DisplayMember = "NOME";
                        //ElencoMostre.ValueMember = m.Nome;
                        ElencoMostre.Items.Insert(i, m.Nome);
                        id_mostre.Add(m.IDmostra);
                        i++;
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

        private void CreaNuova_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //this.Visible = false;
            CreaNuovaMostraPerSingolo nuovaa = new CreaNuovaMostraPerSingolo(benvenuto,this, componenti, id_poster,poster,directory_principale,benvenuto_bar,benvenuto_rfid,visualizza_bar,visualizza_rfid);
            nuovaa.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }

        private void Aggiungi_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int indice = ElencoMostre.SelectedIndex;
            string selezionata = ElencoMostre.SelectedItem.ToString();
            //MessageBox.Show(selezionata);
            id_mostra = (int)id_mostre[indice];
            /*if (taggato == false)
            {*/
                /*int indice = ElencoMostre.SelectedIndex;
                string selezionata = ElencoMostre.SelectedItem.ToString();
                //MessageBox.Show(selezionata);
                id_mostra = (int)id_mostre[indice];
                //MessageBox.Show(id_mostra.ToString());*/
                using (ISession tempS = nh_manager.Session)
                using (ITransaction tempT = tempS.BeginTransaction())
                {
                    try
                    {
                        //ArrayList id_mostre = new ArrayList();
                        int idd_mostra;
                        string nome_mostra;
                        Mostra mostra_sel = new Mostra();
                        Poster poster_sel = new Poster();
                        //IList mostre;
                        IQuery q = tempS.CreateQuery("FROM Mostra as ms WHERE ms.IDmostra=:Mos");
                        //string mostre;
                        q.SetParameter("Mos", id_mostra);
                        mostra_sel = (Mostra)q.List()[0];
                        idd_mostra = mostra_sel.IDmostra;
                        nome_mostra = mostra_sel.Nome;
                        tempS.Flush();
                        IQuery q2 = tempS.CreateQuery("FROM Poster as pt WHERE pt.IDposter=:Pos");
                        //string mostre;
                        q2.SetParameter("Pos", id_poster);
                        poster_sel = (Poster)q2.List()[0];
                        tempS.Flush();
                        poster_sel.Mostra = mostra_sel;
                        tempS.Update(poster_sel);
                        tempT.Commit();
                        tempS.Flush();
                        if (componenti != null)
                        {
                            componenti.Close();
                        }
                        this.Close();
                        if (poster != null)
                        {
                            poster.Close();
                        }
                        //componenti.Close();
                        PosterDellaMostra nuova = new PosterDellaMostra(benvenuto,null,idd_mostra,nome_mostra,directory_principale,benvenuto_bar,benvenuto_rfid,visualizza_bar,visualizza_rfid);
                        nuova.Show();
                        this.Cursor = Cursors.Default;
                    }
                    catch (Exception ex)
                    {
                        tempT.Rollback();
                        Console.WriteLine("Eccezione in Scegli Mostra");
                        this.Cursor = Cursors.Default;
                    }
                    finally
                    {
                        tempS.Close();
                    }
                }
            /*}
            else {
                QuestionPosterTaggato question = new QuestionPosterTaggato(benvenuto,this, componenti, id_poster,id_mostra, poster, directory_principale);
                this.Visible = false;
                question.Show();
            }*/
        }

        private void Annulla_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Close();
            this.Cursor = Cursors.Default;
            componenti.Visible = true;
        }

        private void controlButton1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Close();
            this.Cursor = Cursors.Default;
            componenti.Visible = true;
        }



    }
}
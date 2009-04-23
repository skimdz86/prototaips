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
    public partial class AggiungiControllo : FormSchema
    {
        private ComponentiDelPoster componenti;
        private BenvenutoGestioneDisposizione benvenuto;
        private PosterDellaMostra poster;
        private int id_mostra;
        private int id_poster;
        private string nome_poster;
        private string directory_principale;
        private TalkingPaper.NHibernateManager nh_manager;
        ArrayList non_presenti;
        ArrayList id_non_presenti;
        private string provenienza;
        /*private TalkingPaper.BarCode.BenvenutoBarCode benvenuto_bar;
        private TalkingPaper.RfidCode.BenvenutoRFID benvenuto_rfid;
        private TalkingPaper.BarCode.FormVisualizzaElementi visualizza_bar;
        private TalkingPaper.RfidCode.FormVisualizzaElementiRFID visualizza_rfid;*/
        private TalkingPaper.Authoring.BenvenutoAuthoring benvenuto_aut;
        private TalkingPaper.Authoring.FormVisualizzaElementiAuthoring visualizza_aut;
        private string id_pannello;
        private string nome_pannello;
        private string configurazione;

        public AggiungiControllo(ComponentiDelPoster componenti, BenvenutoGestioneDisposizione benvenuto, PosterDellaMostra poster, int id_mostra, int id_poster, string nome_poster, string directory_principale, string provenienza, TalkingPaper.Authoring.BenvenutoAuthoring benvenuto_aut, TalkingPaper.Authoring.FormVisualizzaElementiAuthoring visualizza_aut,string id_pannello, string nome_pannello,string configurazione)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 40, true);
            this.componenti = componenti;
            this.provenienza = provenienza;
            this.id_pannello = id_pannello;
            this.nome_pannello = nome_pannello;
            this.configurazione = configurazione;
            /*this.benvenuto_bar = benvenuto_bar;
            this.visualizza_bar = visualizza_bar;
            this.visualizza_rfid = visualizza_rfid;
            this.benvenuto_rfid = benvenuto_rfid;*/
            this.benvenuto_aut = benvenuto_aut;
            this.visualizza_aut = visualizza_aut;
            this.benvenuto = benvenuto;
            this.poster = poster;
            this.id_mostra = id_mostra;
            this.id_poster = id_poster;
            this.nome_poster = nome_poster;
            this.directory_principale = directory_principale;
            button1.Cursor = Cursors.Hand;
            button2.Cursor = Cursors.Hand;
            button3.Cursor = Cursors.Hand;
            this.nh_manager = new NHibernateManager();
            //InitializeComponent();
        }

        private void AggiungiControllo_Load(object sender, EventArgs e)
        {
            using (ISession tempS = nh_manager.Session)
            using (ITransaction tempT = tempS.BeginTransaction())
            {
                try
                {
                    //ArrayList id_mostre = new ArrayList();
                    ArrayList presenti = new ArrayList();
                    IList contenuti;
                    IQuery q = tempS.CreateQuery("FROM Contenuto as com WHERE com.Poster=:Pos");
                    //string mostre;
                    q.SetParameter("Pos", id_poster);
                    contenuti = q.List();
                    tempS.Flush();
                    //int i = 0;
                    foreach (Contenuto c in contenuti)
                    {
                        //ElencoMostre.DisplayMember = "NOME";
                        //ElencoMostre.ValueMember = m.Nome;
                        if (c.Tipo.Tipo.CompareTo("Controllo") == 0)
                        {
                            presenti.Add(c.Tipo.Descrizione);
                        }
                        //ElencoMostre.Items.Insert(i, m.Nome);
                        //id_mostre.Add(m.IDmostra);
                        //i++;
                    }
                    IList tutte_tipologie;
                    non_presenti = new ArrayList();
                    id_non_presenti = new ArrayList();
                    IQuery q2 = tempS.CreateQuery("FROM Tipologia as tp WHERE tp.Tipo=:Tip");
                    //string mostre;
                    q2.SetParameter("Tip", "Controllo");
                    tutte_tipologie = q2.List();
                    tempS.Flush();
                    int i = 0;
                    bool presente = false;
                    foreach (Tipologia t in tutte_tipologie)
                    {
                        //ElencoMostre.DisplayMember = "NOME";
                        //ElencoMostre.ValueMember = m.Nome;
                        foreach (String s in presenti)
                        {
                            if (s.CompareTo(t.Descrizione) == 0)
                            {
                                presente = true;
                            }
                        }
                        if (presente == false)
                        {
                            id_non_presenti.Insert(i, t.IDtipologia);
                            non_presenti.Insert(i, t.Descrizione);
                            i++;
                        }
                        /*if (c.Tipo.Tipo.CompareTo("Controllo") == 0)
                        {
                            presenti.Add(c.Tipo.Descrizione);
                        }*/
                        //ElencoMostre.Items.Insert(i, m.Nome);
                        //id_mostre.Add(m.IDmostra);
                        //i++;
                        presente = false;
                    }
                    if (non_presenti.Count == 0)
                    {
                        label1.Visible = false;
                        comboBox1.Visible = false;
                        label2.Visible = true;
                        button1.Visible = false;
                        button2.Visible = false;
                        button3.Visible = true;
                    }
                    else
                    {
                        for (int j = 0; j < non_presenti.Count; j++)
                        {
                            comboBox1.Items.Add((String)non_presenti[j]);
                        }
                    }
                    tempT.Commit();
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int indice = comboBox1.SelectedIndex;
            string selezionata = comboBox1.SelectedItem.ToString();
            int id_tipologia = (int)id_non_presenti[indice];
            using (ISession tempS = nh_manager.Session)
            using (ITransaction tempT = tempS.BeginTransaction())
            {
                try
                {
                    Tipologia ti = new Tipologia();
                    Contenuto con = new Contenuto();
                    Poster pos = new Poster();
                    IQuery q3 = tempS.CreateQuery("FROM Tipologia as tp WHERE tp.IDtipologia=:Tip");
                    //string mostre;
                    q3.SetParameter("Tip", id_tipologia);
                    ti = (Tipologia)q3.List()[0];
                    tempS.Flush();
                    con.Ordine = 0;
                    con.Livello = 0;
                    con.Tipo = ti;
                    con.Nome = ti.Descrizione;
                    con.RisorsaMultimediale = null;
                    con.Rfidtag = "0";
                    con.Barcode = "0";
                    IQuery q4 = tempS.CreateQuery("FROM Poster as pt WHERE pt.IDposter=:Pos");
                    //string mostre;
                    q4.SetParameter("Pos", id_poster);
                    pos = (Poster)q4.List()[0];
                    tempS.Flush();
                    con.Poster = pos;
                    tempS.Save(con);
                    tempT.Commit();
                    ComponentiDelPoster nuovas = new ComponentiDelPoster(benvenuto, poster, id_mostra, id_poster, nome_poster, directory_principale, provenienza,benvenuto_aut,visualizza_aut,id_pannello,nome_pannello,configurazione);
                    //componenti.Close();
                    //this.Close();
                    nuovas.Show();
                    this.Cursor = Cursors.Default;
                    componenti.Close();
                    this.Close();
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            componenti.Visible = true;
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            componenti.Visible = true;
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void sottotitolo_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {

        }
    }
}
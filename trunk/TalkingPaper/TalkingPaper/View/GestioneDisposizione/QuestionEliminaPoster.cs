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
using System.Xml;

namespace TalkingPaper.GestioneDisposizione
{
    public partial class QuestionEliminaPoster : Form
    {
        private PosterDellaMostra elenco_poster;
        private BenvenutoGestioneDisposizione benvenuto;
        private ScegliMostraPostering elenco_mostre;
        private TalkingPaper.NHibernateManager nh_manager;
        private int id_mostra;
        private int id_poster;
        private string nome_poster;
        private string nome_mostra;
        private string directory_principale;
        /*private TalkingPaper.BarCode.BenvenutoBarCode benvenuto_bar;
        private TalkingPaper.RfidCode.BenvenutoRFID benvenuto_rfid;
        private TalkingPaper.BarCode.FormVisualizzaElementi visualizza_bar;
        private TalkingPaper.RfidCode.FormVisualizzaElementiRFID visualizza_rfid;*/
        private TalkingPaper.Authoring.BenvenutoAuthoring benvenuto_aut;
        private TalkingPaper.Authoring.FormVisualizzaElementiAuthoring visualizza_aut;
        private ArrayList poster_creati = new ArrayList();
        private string id_pannello2;
        private string nome_pannello;
        private string configurazione;

        public QuestionEliminaPoster(PosterDellaMostra elenco_poster, int id_mostra, int id_poster, string nome_poster, BenvenutoGestioneDisposizione benvenuto, ScegliMostraPostering elenco_mostre, string nome_mostra, string directory_principale, TalkingPaper.Authoring.BenvenutoAuthoring benvenuto_aut, TalkingPaper.Authoring.FormVisualizzaElementiAuthoring visualizza_aut,string id_pannello2,string nome_pannello,string configurazione)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 45, true);
            this.id_pannello2 = id_pannello2;
            this.nome_pannello = nome_pannello;
            this.configurazione = configurazione;
            this.elenco_poster = elenco_poster;
            this.id_mostra = id_mostra;
            this.id_poster = id_poster;
            this.nome_poster = nome_poster;
            this.benvenuto = benvenuto;
            this.elenco_mostre = elenco_mostre;
            this.nome_mostra = nome_mostra;
            this.directory_principale = directory_principale;
            /*this.visualizza_bar = visualizza_bar;
            this.visualizza_rfid = visualizza_rfid;
            this.benvenuto_bar = benvenuto_bar;
            this.benvenuto_rfid = benvenuto_rfid;*/
            this.benvenuto_aut = benvenuto_aut;
            this.visualizza_aut = visualizza_aut;
            this.nh_manager = new NHibernateManager();
            Si.Cursor = Cursors.Hand;
            Annulla.Cursor = Cursors.Hand;
            button1.Cursor = Cursors.Hand;
            button2.Cursor = Cursors.Hand;
            //CaricaPosterConfigurazioni();
            LeggiPosterCreati();
        }

        private void LeggiPosterCreati()
        {
            try
            {
                XmlTextReader iscritto = new XmlTextReader(directory_principale + "PosterAuthoring" + ".xml");
                //bool fine = false;
                while ((iscritto.Read()))
                {
                    if (iscritto.NodeType == XmlNodeType.Element)
                    {
                        if (iscritto.LocalName.Equals("IDposter"))
                        {
                            //string id = (String)iscritto.GetAttribute("ID");
                            string ins = (string)iscritto.ReadString();
                            //string id = (String)iscritto.GetAttribute("ID");
                            poster_creati.Add(ins);
                            //pannelli.Add(id);
                        }
                        if (iscritto.LocalName.Equals("IDpannello"))
                        {
                            //string id = (String)iscritto.GetAttribute("ID");
                            string ins = (string)iscritto.ReadString();
                            //string id = (String)iscritto.GetAttribute("ID");
                            poster_creati.Add(ins);
                            //pannelli.Add(id);
                        }
                        if (iscritto.LocalName.Equals("NomePannello"))
                        {
                            //string id = (String)iscritto.GetAttribute("ID");
                            string ins = (string)iscritto.ReadString();
                            //string id = (String)iscritto.GetAttribute("ID");
                            poster_creati.Add(ins);
                            //pannelli.Add(id);
                        }
                        if (iscritto.LocalName.Equals("Configurazione"))
                        {
                            //string id = (String)iscritto.GetAttribute("ID");
                            string ins = (string)iscritto.ReadString();
                            //string id = (String)iscritto.GetAttribute("ID");
                            poster_creati.Add(ins);
                            //pannelli.Add(id);
                        }
                    }
                }
                iscritto.Close();
            }
            catch
            {

            }
        }

        private void CreaFilePosterCreati()
        {
            try
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.NewLineOnAttributes = true;
                XmlWriter wr = XmlWriter.Create(directory_principale + "PosterAuthoring" + ".xml", settings);
                wr.WriteStartDocument();
                wr.WriteStartElement("PosterCreatiConAuthoring");
                //wr.WriteStartElement("Configurazione", textBox1.Text);
                //int indice = 0;
                //bool trovato = false;
                try
                {
                    for (int i = 0; i < poster_creati.Count; i = i + 4)
                    {
                        if (Int32.Parse((string)poster_creati[i]) != id_poster)
                        {
                            wr.WriteStartElement("IDposter");
                            wr.WriteString(((string)poster_creati[i]));
                            wr.WriteStartElement("IDpannello");
                            wr.WriteString((string)poster_creati[i + 1]);
                            wr.WriteEndElement();
                            wr.WriteStartElement("NomePannello");
                            wr.WriteString((string)poster_creati[i + 2]);
                            wr.WriteEndElement();
                            wr.WriteStartElement("Configurazione");
                            wr.WriteString((string)poster_creati[i + 3]);
                            wr.WriteEndElement();
                            wr.WriteEndElement();
                        }
                    }
                    wr.WriteEndElement();
                    //wr.WriteEndElement();
                    //wr.WriteEndElement();
                    wr.WriteEndDocument();
                    wr.Flush();
                    wr.Close();
                    if (System.IO.File.Exists(directory_principale + "Griglia" + nome_pannello + id_pannello2 + configurazione + id_poster.ToString() + ".xml"))
                    {
                        System.IO.File.Delete(directory_principale + "Griglia" + nome_pannello + id_pannello2 + configurazione + id_poster.ToString() + ".xml");
                    }
                }
                catch
                {

                }
            }
            catch
            {

            }
        }
        
        /*private void CaricaPosterConfigurazioni()
        {
            try
            {
                string nome_file = directory_principale + "PosterAuthoring" + ".xml";
                XmlTextReader iscritto = new XmlTextReader(nome_file);
                bool fine = false;
                int i = -1;
                int j = 1;
                while ((iscritto.Read()))
                {
                    if (iscritto.NodeType == XmlNodeType.Element)
                    {
                        if (iscritto.LocalName.Equals("IDposter"))
                        {
                            //string id = (String)iscritto.GetAttribute("ID");
                            string ins = (string)iscritto.ReadString();
                            poster_creati.Add(Int32.Parse(ins));
                        }
                    }
                }
                iscritto.Close();
                //esiste = true;
            }
            catch
            {
                //esiste = false;
            }
        }*/

        private void Annulla_Click(object sender, EventArgs e)
        {
           /* this.Cursor = Cursors.WaitCursor;
            //this.Close();
            elenco_poster.Visible = true;
            this.Cursor = Cursors.Default;
            this.Close();*/
        }

        private void Si_Click(object sender, EventArgs e)
        {
            /*this.Cursor = Cursors.WaitCursor;
            using (ISession tempS = nh_manager.Session)
            using (ITransaction tempT = tempS.BeginTransaction())
            {
                try
                {
                    IQuery q = tempS.CreateQuery("FROM Poster as pt WHERE pt.IDposter=:Pos");
                    int idd_mostra;
                    Mostra mm = new Mostra();
                    q.SetParameter("Pos", id_pannello);
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
                    /*try
                    {
                        XmlWriterSettings settings = new XmlWriterSettings();
                        settings.Indent = true;
                        settings.NewLineOnAttributes = true;
                        XmlWriter wr = XmlWriter.Create(directory_principale + "PosterAuthoring" + ".xml");
                        wr.WriteStartDocument();
                        wr.WriteStartElement("PosterCreatiConAuthoring");
                        //wr.WriteStartElement("Pannelli");
                        for (int l = 0; l < poster_creati.Count; l++) {
                            if (((int)poster_creati[l]) != id_pannello)
                            {
                                wr.WriteStartElement("IDposter");
                                wr.WriteString(((int)poster_creati[l]).ToString());
                                wr.WriteEndElement();
                            }
                        }
                        wr.WriteEndElement();
                        wr.WriteEndDocument();
                        wr.Flush();
                        wr.Close();
                    }
                    catch
                    {

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
                    PosterDellaMostra poster_mostra = new PosterDellaMostra(benvenuto, elenco_mostre, id_mostra, nome_mostra, directory_principale, benvenuto_aut,visualizza_aut);
                    //this.Close();
                    elenco_poster.Close();
                    poster_mostra.Show();
                    this.Cursor = Cursors.Default;
                    this.Close();
                }
            }*/
        }

        private void QuestionEliminaPoster_Load(object sender, EventArgs e)
        {

        }

        private void QuestionEliminaPoster_Load_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
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
                    q.SetParameter("Pos", id_poster);
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
                    /*try
                    {
                        XmlWriterSettings settings = new XmlWriterSettings();
                        settings.Indent = true;
                        settings.NewLineOnAttributes = true;
                        XmlWriter wr = XmlWriter.Create(directory_principale + "PosterAuthoring" + ".xml");
                        wr.WriteStartDocument();
                        wr.WriteStartElement("PosterCreatiConAuthoring");
                        //wr.WriteStartElement("Pannelli");
                        for (int l = 0; l < poster_creati.Count; l++)
                        {
                            if (((int)poster_creati[l]) != id_pannello)
                            {
                                wr.WriteStartElement("IDposter");
                                wr.WriteString(((int)poster_creati[l]).ToString());
                                wr.WriteEndElement();
                            }
                        }
                        wr.WriteEndElement();
                        wr.WriteEndDocument();
                        wr.Flush();
                        wr.Close();
                    }
                    catch
                    {

                    }*/
                    CreaFilePosterCreati();
                }
                catch (Exception ex)
                {
                    tempT.Rollback();
                    Console.WriteLine("Eccezione in Scegli Mostra");
                }
                finally
                {
                    tempS.Close();
                    PosterDellaMostra poster_mostra = new PosterDellaMostra(benvenuto, elenco_mostre, id_mostra, nome_mostra, directory_principale, benvenuto_aut, visualizza_aut,null,null,null);
                    //this.Close();
                    elenco_poster.Close();
                    poster_mostra.Show();
                    this.Cursor = Cursors.Default;
                    this.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //this.Close();
            elenco_poster.Visible = true;
            this.Cursor = Cursors.Default;
            this.Close();
        }
    }
}
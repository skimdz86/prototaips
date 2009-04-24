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

namespace TalkingPaper.GestioneDisposizione
{
    public partial class PosterDellaMostra : FormSchema
    {
        private BenvenutoGestioneDisposizione benvenuto;
        //private ScegliMostraPostering elenco_mostre;
        private int id_mostra;
        private string nome_mostra;
        private string directory_principale;
        private TalkingPaper.NHibernateManager nh_manager;
        private Bitmap immagine_modifica_poster;
        private Bitmap elimina;
        private ArrayList poster_authoring = new ArrayList();
        /*private TalkingPaper.BarCode.BenvenutoBarCode benvenuto_bar;
        private TalkingPaper.RfidCode.BenvenutoRFID benvenuto_rfid;
        private TalkingPaper.BarCode.FormVisualizzaElementi visualizza_bar;
        private TalkingPaper.RfidCode.FormVisualizzaElementiRFID visualizza_rfid;
        // private ArrayList poster;
        // private Mostra mostra_sel;
        private TalkingPaper.Authoring.BenvenutoAuthoring benvenuto_aut;*/
        private TalkingPaper.Authoring.FormVisualizzaElementiAuthoring visualizza_aut;
        private string id_pannello;
        private string nome_pannello;
        private string configurazione;

        public PosterDellaMostra(BenvenutoGestioneDisposizione benvenuto, /*ScegliMostraPostering elenco_mostre,*/ int id_mostra, string nome_mostra, string directory_principale, /*TalkingPaper.Authoring.BenvenutoAuthoring benvenuto_aut,*/ TalkingPaper.Authoring.FormVisualizzaElementiAuthoring visualizza_aut, string id_pannello, string nome_pannello, string configurazione)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 90, true);
            this.benvenuto = benvenuto;
            this.id_mostra = id_mostra;
            this.nome_mostra = nome_mostra;
            this.directory_principale = directory_principale;
            //this.elenco_mostre = elenco_mostre;
            this.id_pannello = id_pannello;
            this.nome_pannello = nome_pannello;
            this.configurazione = configurazione;
            /*this.benvenuto_bar = benvenuto_bar;
            this.benvenuto_rfid = benvenuto_rfid;
            this.visualizza_bar = visualizza_bar;
            this.visualizza_rfid = visualizza_rfid;*/
            //this.benvenuto_aut = benvenuto_aut;
            this.visualizza_aut = visualizza_aut;
            this.nh_manager = new NHibernateManager();
            immagine_modifica_poster = new System.Drawing.Bitmap(directory_principale + @"/Images/Icons/modifica3.gif");
            elimina = new Bitmap(directory_principale + @"/Images/Icons/elimina_cestino.gif");
           // label1.Text = "Ecco i poster della mostra " + '"' + nome_mostra + '"';
            //textBox1.Select(0, 0);
            button1.Cursor = Cursors.Hand;
            button2.Cursor = Cursors.Hand;
            if (/*(elenco_mostre == null) && */(id_mostra == -1))
            {
                label2.Text = "Non sono presenti Poster Singoli";
             //   label1.Text = "Ecco i Poster Singoli";
            }
            LeggiPosterCreati();
            InterrogaDB();
        }

        private void PosterDellaMostra_Load(object sender, EventArgs e)
        {
            //InterrogaDB();
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
                            poster_authoring.Add(ins);
                            //pannelli.Add(id);
                        }
                        if (iscritto.LocalName.Equals("IDpannello"))
                        {
                            //string id = (String)iscritto.GetAttribute("ID");
                            string ins = (string)iscritto.ReadString();
                            //string id = (String)iscritto.GetAttribute("ID");
                            poster_authoring.Add(ins);
                            //pannelli.Add(id);
                        }
                        if (iscritto.LocalName.Equals("NomePannello"))
                        {
                            //string id = (String)iscritto.GetAttribute("ID");
                            string ins = (string)iscritto.ReadString();
                            //string id = (String)iscritto.GetAttribute("ID");
                            poster_authoring.Add(ins);
                            //pannelli.Add(id);
                        }
                        if (iscritto.LocalName.Equals("Configurazione"))
                        {
                            //string id = (String)iscritto.GetAttribute("ID");
                            string ins = (string)iscritto.ReadString();
                            //string id = (String)iscritto.GetAttribute("ID");
                            poster_authoring.Add(ins);
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


        private void InterrogaDB()
        {
            if (/*(elenco_mostre != null) ||*/ (id_mostra != -1))
            {
                using (ISession tempS = nh_manager.Session)
                using (ITransaction tempT = tempS.BeginTransaction())
                {
                    try
                    {
                        Mostra mostra_sel;
                        IQuery q = tempS.CreateQuery("FROM Mostra as ms WHERE ms.IDmostra=:Mos");
                        q.SetParameter("Mos", id_mostra);
                        mostra_sel = (Mostra)q.List()[0];
                        tempT.Commit();
                        if (mostra_sel.PosterLista.Count == 0)
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
                            //ElencoPoster.ColumnCount = 11;
                            ElencoRisorse.ColumnHeadersVisible = false;
                            ElencoRisorse.Columns[0].Visible = false;

                            //ElencoPoster.Columns[10].Visible = false;
                            //DataGridViewRow riga = new DataGridViewRow();
                            ElencoRisorse.Rows.Add("NUM", "  ", "NOME", "  ", "DESCRIZIONE", "  ", "MODIFICA", "  ", "ELIMINA"); // ,"  ", "ELIMINA");
                            //ElencoPoster.Rows.Add("NUMERO", "  ", "NOME", "  ", "DESCRIZIONE", "  ", "CONFIGURAZIONE", "  ", "PANNELLO", "VISUALIZZA COMPONENTI", "  ");
                            //ElencoRisorse.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
                            ElencoRisorse.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
                            ElencoRisorse.Rows.Add();
                            ElencoRisorse.CellClick += new DataGridViewCellEventHandler(this.ClickSullaTabella);
                            ElencoRisorse.CellMouseEnter += new DataGridViewCellEventHandler(ElencoRisorse_CellMouseEnter);

                            // Riempimento della DataGrid
                            int riga = 2;
                            foreach (Poster p in mostra_sel.PosterLista)
                            {
                                DataGridViewImageCell immagine_modifica = new DataGridViewImageCell();
                                immagine_modifica.Value = immagine_modifica_poster;
                                immagine_modifica.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                DataGridViewImageCell delete = new DataGridViewImageCell();
                                delete.Value = elimina;
                                delete.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                ElencoRisorse.Rows.Add(p.IDposter, null, p.Nome, null, p.Descrizione, null, null);
                                ElencoRisorse[6, riga] = immagine_modifica;
                                ElencoRisorse[8, riga] = delete;
                                ElencoRisorse.Rows.Add();
                                riga += 2;
                            }

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
            else if (/*(elenco_mostre == null) &&*/ (id_mostra == -1))
            {
                using (ISession tempS = nh_manager.Session)
                using (ITransaction tempT = tempS.BeginTransaction())
                {
                    try
                    {
                        IList poster_sel;
                        IQuery q = tempS.CreateQuery("FROM Poster as pt");
                        //q.SetParameter("Mos", null);
                        poster_sel = q.List();
                        tempT.Commit();
                        int nulli = 0;
                        foreach (Poster p in poster_sel)
                        {
                            if (p.Mostra == null)
                            {
                                for (int i = 0; i < poster_authoring.Count; i=i+4) {
                                    if ((Int32.Parse((string)poster_authoring[i])) == p.IDposter) {
                                        nulli++;
                                    }
                                }
                            }
                        }
                        if (nulli == 0)
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
                            //ElencoRisorse.ColumnCount = 9;
                            ElencoRisorse.ColumnCount = 12;
                            ElencoRisorse.ColumnHeadersVisible = false;
                            ElencoRisorse.Columns[0].Visible = false;
                            ElencoRisorse.Columns[6].Visible = false;
                            ElencoRisorse.Columns[7].Visible = false;
                            ElencoRisorse.Columns[8].Visible = false;
                            ElencoRisorse.Columns[11].Visible = false;
                            //DataGridViewRow riga = new DataGridViewRow();
                            ElencoRisorse.Rows.Add("NUMERO", "  ", "NOME", "  ", "DESCRIZIONE", "  ", "PANNELLO", "  ", "CONFIGURAZIONE", "MODIFICA", "ELIMINA","  ");
                            //ElencoRisorse.Rows.Add("NUM", "  ", "NOME", "  ", "DESCRIZIONE", "  ", "MODIFICA", "  ", "ELIMINA"); // ,"  ", "ELIMINA
                            ElencoRisorse.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
                            /*ElencoRisorse.Rows[0].DefaultCellStyle.SelectionBackColor = Color.Transparent;
                            ElencoRisorse.Rows[0].DefaultCellStyle.SelectionForeColor = Color.Transparent;
                            ElencoRisorse.DefaultCellStyle.SelectionBackColor = Color.Transparent;
                            ElencoRisorse.DefaultCellStyle.SelectionForeColor = Color.Transparent;*/
                            ElencoRisorse.Rows.Add();
                            ElencoRisorse.CellClick += new DataGridViewCellEventHandler(this.ClickSullaTabella);
                            ElencoRisorse.CellMouseEnter += new DataGridViewCellEventHandler(ElencoRisorse_CellMouseEnter);
                            // Riempimento della DataGrid
                            int riga = 2;
                            foreach (Poster p in poster_sel)
                            {
                                if (p.Mostra == null)
                                {
                                    for (int i = 0; i < poster_authoring.Count; i=i+4)
                                    {
                                        if ((Int32.Parse((string)poster_authoring[i])) == p.IDposter)
                                        {
                                            DataGridViewImageCell immagine_modifica = new DataGridViewImageCell();
                                            immagine_modifica.Value = immagine_modifica_poster;
                                            immagine_modifica.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                            DataGridViewImageCell delete = new DataGridViewImageCell();
                                            delete.Value = elimina;
                                            delete.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                            ElencoRisorse.Rows.Add(p.IDposter, null, p.Nome, null, p.Descrizione, null, (string)poster_authoring[i + 2], null, (string)poster_authoring[i + 3], null, null,(string)poster_authoring[i + 1]);
                                            ElencoRisorse[9, riga] = immagine_modifica;
                                            ElencoRisorse[10, riga] = delete;
                                            ElencoRisorse.Rows.Add();
                                            riga += 2;
                                        }
                                    }
                                }
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
        }

        /*private void SetDataGrid () { 
            ElencoRisorse.ColumnCount = 7;
            ElencoRisorse.ColumnHeadersVisible = false;
            DataGridViewRow riga = new DataGridViewRow();
            ElencoRisorse.Rows.Add("NUM", "  ", "POSTER", "  ", "     ","  ","     ");
            ElencoRisorse.Rows.Add();
            ElencoRisorse.CellClick += new DataGridViewCellEventHandler(this.ClickSullaTabella);
        }*/

        private void ElencoRisorse_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((ElencoRisorse[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 9))
            {
                ElencoRisorse.Cursor = Cursors.Hand;
            }
            else if ((ElencoRisorse[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 10))
            {
                ElencoRisorse.Cursor = Cursors.Hand;
            }
            else
                ElencoRisorse.Cursor = Cursors.Default;
        }

        private void ClickSullaTabella(object sender, DataGridViewCellEventArgs e)
        {
            if ((ElencoRisorse[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 9))
            {
                //this.Visible = false;
                this.Cursor = Cursors.WaitCursor;
                //ComponentiDelPoster nuova = new ComponentiDelPoster(benvenuto, this, id_mostra, (int)ElencoRisorse[0, e.RowIndex].Value, (string)ElencoRisorse[2, e.RowIndex].Value, directory_principale, "posterdellamostra", benvenuto_aut, visualizza_aut);
                //nuova.Show();
                Authoring.FormVisualizzaElementiAuthoring n = new Authoring.FormVisualizzaElementiAuthoring(/*null,*/  (int)ElencoRisorse[0, e.RowIndex].Value, (string)ElencoRisorse[2, e.RowIndex].Value, -1, directory_principale, "talkingpaper2", benvenuto, id_pannello, nome_pannello, configurazione, null, benvenuto, "posterdellamostra", id_mostra, this);
                ///ComponentiDelPoster n = new ComponentiDelPoster(benvenuto, this, id_mostra, (int)ElencoRisorse[0, e.RowIndex].Value, (string)ElencoRisorse[2, e.RowIndex].Value, directory_principale, "posterdellamostra",  visualizza_aut, (string)ElencoRisorse[11, e.RowIndex].Value, (string)ElencoRisorse[6, e.RowIndex].Value, (string)ElencoRisorse[8, e.RowIndex].Value);
                //Authoring.FormScegliConfigurazione n = new TalkingPaper.Authoring.FormScegliConfigurazione(null, this, id_mostra, (int)ElencoRisorse[0, e.RowIndex].Value, (string)ElencoRisorse[2, e.RowIndex].Value, directory_principale, "posterdellamostra", benvenuto);
                n.Show();
                this.Cursor = Cursors.Default;
                this.Visible = false;
            }
            else if ((ElencoRisorse[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 10))
            {
                //this.Visible = false;
                this.Cursor = Cursors.WaitCursor;
                QuestionEliminaPoster nuova = new QuestionEliminaPoster(this, id_mostra, (int)ElencoRisorse[0, e.RowIndex].Value, (string)ElencoRisorse[2, e.RowIndex].Value, benvenuto, nome_mostra, directory_principale,  visualizza_aut, (string)ElencoRisorse[11, e.RowIndex].Value, (string)ElencoRisorse[6, e.RowIndex].Value, (string)ElencoRisorse[8, e.RowIndex].Value);
                nuova.Show();
                this.Cursor = Cursors.Default;
                this.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (/*(elenco_mostre == null) &&*/ (id_mostra == -1))
            {
                //this.Close();
                benvenuto.Visible = true;
                this.Cursor = Cursors.Default;
                this.Close();
            }
            /*else /*if (elenco_mostre == null)
            {
                //this.Close();
                ScegliMostraPostering nuova = new ScegliMostraPostering(benvenuto, directory_principale,visualizza_aut, null);
                nuova.Show();
                this.Cursor = Cursors.Default;
                this.Close();
            }
            else
            {
               this.Close();
               elenco_mostre.Visible = true;
               this.Cursor = Cursors.Default;
               this.Close();
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            this.Cursor = Cursors.WaitCursor;
            NuovoPoster nuovo = new NuovoPoster(null,this, benvenuto, id_mostra, nome_mostra, directory_principale, visualizza_aut);
            nuovo.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }


        private void Menu_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //QuestionPostering richiesta = new QuestionPostering(benvenuto, global.start, null, benvenuto_aut, visualizza_aut);
            //richiesta.Show();
            global.home.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }
    }
}
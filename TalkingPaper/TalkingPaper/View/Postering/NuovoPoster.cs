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
    public partial class NuovoPoster : FormSchema
    {
        private PosterDellaMostra mostra;
        private BenvenutoPostering benvenuto;
        ScegliMostraPostering elenco_mostre;
        private int id_mostra;
        private string nome_mostra;
        private string directory_principale;
        private TalkingPaper.NHibernateManager nh_manager;
        private Bitmap immagine_modifica_poster;
        private TalkingPaper.BarCode.BenvenutoBarCode benvenuto_bar;
        private TalkingPaper.RfidCode.BenvenutoRFID benvenuto_rfid;
        private TalkingPaper.BarCode.FormVisualizzaElementi visualizza_bar;
        private TalkingPaper.RfidCode.FormVisualizzaElementiRFID visualizza_rfid;

        public NuovoPoster(PosterDellaMostra mostra, BenvenutoPostering benvenuto, ScegliMostraPostering elenco_mostre, int id_mostra, string nome_mostra, string directory_principale, TalkingPaper.BarCode.BenvenutoBarCode benvenuto_bar, TalkingPaper.RfidCode.BenvenutoRFID benvenuto_rfid, TalkingPaper.BarCode.FormVisualizzaElementi visualizza_bar, TalkingPaper.RfidCode.FormVisualizzaElementiRFID visualizza_rfid)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 50, true);
            this.mostra = mostra;
            this.benvenuto = benvenuto;
            this.elenco_mostre = elenco_mostre;
            this.id_mostra = id_mostra;
            this.nome_mostra = nome_mostra;
            this.directory_principale = directory_principale;
            this.benvenuto_bar = benvenuto_bar;
            this.benvenuto_rfid = benvenuto_rfid;
            this.visualizza_rfid = visualizza_rfid;
            this.visualizza_bar = visualizza_bar;
            this.nh_manager = new NHibernateManager();
            label4.Visible = false;
            Ordine.Visible = false;
            immagine_modifica_poster = new Bitmap(directory_principale + @"/Images/Icons/modifica.gif");
            label1.Text = label1.Text + " " + nome_mostra;
            button1.Cursor = Cursors.Hand;
            button2.Cursor = Cursors.Hand;
            //textBox1.Select(0,0);
            if (elenco_mostre == null) {
                label1.Text = "Inserisci un nuovo Poster Singolo";
            }
        }

        private void NuovoPoster_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //this.Close();
            if (mostra != null)
            {
                mostra.Visible = true;
            }
            else if (benvenuto != null) {
                benvenuto.Visible = true;
            }
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (Nome.Text == "") {
                MessageBox.Show("Inserisci il nome del poster");
            }
            else if ( Descrizione.Text == "") {
                MessageBox.Show("Inserisci la descrizione del poster");
            }
            /*else if (Ordine.Text == "")
            {
                MessageBox.Show("Inserisci l'ordine");
            }*/
            else if((elenco_mostre!=null))
            {
                try
                {
                    //int ordine = Int32.Parse(Ordine.Text);
                    using (ISession tempS = nh_manager.Session)
                    using (ITransaction tempT = tempS.BeginTransaction())
                    {
                        try
                        {
                            Mostra mostra2 = new Mostra();
                            IList tipologia_controlli;
                            IQuery q2 = tempS.CreateQuery("FROM Mostra as ms WHERE ms.IDmostra=:Mos");
                            q2.SetParameter("Mos",id_mostra);
                            mostra2= (Mostra)q2.List()[0];
                            tempS.Flush();
                            IQuery q3 = tempS.CreateQuery("FROM Tipologia as tp");
                            //q2.SetParameter("Mos", id_mostra);
                            tipologia_controlli = q3.List();
                            tempS.Flush();
                            //tempT.Commit();
                            Poster nuovo = new Poster();
                            //nuova.PosterLista = new List();
                            nuovo.Nome = Nome.Text;
                            nuovo.Descrizione = Descrizione.Text;
                            //nuovo.Ordine = ordine;
                            nuovo.Ordine = 0;
                            nuovo.Mostra = mostra2;
                            tempS.Save(nuovo);
                            tempS.Flush();
                            nuovo.ContenutoLista = new ArrayList();
                            foreach (Tipologia tp in tipologia_controlli)
                            {
                                if (tp.Tipo.CompareTo("Controllo") == 0)
                                {
                                    Contenuto contenuto = new Contenuto();
                                    contenuto.Livello = 0;
                                    contenuto.Nome = tp.Descrizione;
                                    contenuto.Ordine = 0;
                                    contenuto.Poster = nuovo;
                                    contenuto.Rfidtag = "0";
                                    contenuto.Barcode = "0";
                                    contenuto.RisorsaMultimediale = null;
                                    contenuto.Tipo = tp;
                                    contenuto.AltrarisorsaLista=null;
                                    tempS.Save(contenuto);
                                    tempS.Flush();
                                    nuovo.ContenutoLista.Add(contenuto);
                                }
                            }
                            tempS.Update(nuovo);
                            tempS.Flush();
                            tempT.Commit();
                            MessageBox.Show("Poster creato");
                            mostra.Close();
                            //this.Close();
                            PosterDellaMostra nuova = new PosterDellaMostra(benvenuto, elenco_mostre, id_mostra, nome_mostra, directory_principale,benvenuto_bar,benvenuto_rfid,visualizza_bar,visualizza_rfid);
                            nuova.Show();
                            this.Cursor = Cursors.Default;
                            this.Close();
                            //IList poster_sel;
                            //IQuery q = tempS.CreateQuery("FROM Poster as pt");
                            //poster_sel = q.List();
                            //tempT.Commit();
                            //int id_poster=0;
                            //DataGridViewImageCell immagine_modifica = new DataGridViewImageCell();
                            //immagine_modifica.Value = immagine_modifica_poster;
                            //foreach (Poster p in poster_sel)
                            //{
                              //  id_poster = p.IDposter;
                            //}
                            //ElencoRisorse.Rows.Add(id_poster, null, Nome.Text, null, Descrizione.Text, null, immagine_modifica);
                            //ElencoRisorse[6, riga] = immagine_modifica;
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
                catch (Exception exc){
                    MessageBox.Show("Nella casella ordine deve essere presente un numero intero");
                }
            }
            else if (elenco_mostre == null) { 
                using (ISession tempS = nh_manager.Session)
                    using (ITransaction tempT = tempS.BeginTransaction())
                    {
                        try
                        {
                            IList tipologia_controlli;
                            IQuery q3 = tempS.CreateQuery("FROM Tipologia as tp");
                            //q2.SetParameter("Mos", id_mostra);
                            tipologia_controlli = q3.List();
                            tempS.Flush();
                            Poster poster = new Poster();
                            poster.Nome = Nome.Text;
                            poster.Descrizione = Descrizione.Text;
                            //nuovo.Ordine = ordine;
                            poster.Ordine = 0;
                            poster.Mostra = null;
                            tempS.Save(poster);
                            tempS.Flush();
                            poster.ContenutoLista = new ArrayList();
                            foreach (Tipologia tp in tipologia_controlli)
                            {
                                if (tp.Tipo.CompareTo("Controllo") == 0)
                                {
                                    Contenuto contenuto = new Contenuto();
                                    contenuto.Livello = 0;
                                    contenuto.Nome = tp.Descrizione;
                                    contenuto.Ordine = 0;
                                    contenuto.Poster = poster;
                                    contenuto.Rfidtag = "0";
                                    contenuto.Barcode = "0";
                                    contenuto.RisorsaMultimediale = null;
                                    contenuto.Tipo = tp;
                                    contenuto.AltrarisorsaLista = null;
                                    tempS.Save(contenuto);
                                    tempS.Flush();
                                    poster.ContenutoLista.Add(contenuto);
                                }
                            }
                            tempS.Update(poster);
                            tempS.Flush();
                            Poster eccolo = new Poster();
                            IList poster_sel;
                            IQuery q4 = tempS.CreateQuery("FROM Poster as pt");
                            //q2.SetParameter("Mos", id_mostra);
                            poster_sel = q4.List();
                            foreach (Poster p in poster_sel) {
                                eccolo = p;
                            }
                            tempS.Flush();
                            tempT.Commit();
                            //poster.Mostra = null;
                            ComponentiDelPoster nuov = new ComponentiDelPoster(benvenuto, null, -1, eccolo.IDposter, eccolo.Nome, directory_principale,null,null,null,null,null);
                            //this.Close();
                            nuov.Show();
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

        private void controlButton1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //this.Close();
            if (mostra != null)
            {
                mostra.Visible = true;
            }
            else if (benvenuto != null)
            {
                benvenuto.Visible = true;
            }
            this.Cursor = Cursors.Default;
            this.Close();
        }
    }
}
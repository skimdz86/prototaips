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
    public partial class ComponentiDelPoster : FormSchema
    {
        private BenvenutoPostering benvenuto;
        private PosterDellaMostra poster;
        private TalkingPaper.NHibernateManager nh_manager;
        private int id_mostra;
        private int id_poster;
        private string nome_poster;
        private string directory_principale;
        private IList contenuti;
        private Bitmap play_audio;
        private Bitmap modifica;
        private Bitmap elimina;
        private Bitmap play_video;
        private Bitmap testo;
        private Bitmap preview_immagine;
        private Bitmap pausa;
        private Bitmap stop;
        private Bitmap riprendi;
        private ArrayList audio_video;
        private TalkingPaper.BarCode.BenvenutoBarCode benvenuto_bar;
        private TalkingPaper.RfidCode.BenvenutoRFID benvenuto_rfid;
        private TalkingPaper.BarCode.FormVisualizzaElementi visualizza_bar;
        private TalkingPaper.RfidCode.FormVisualizzaElementiRFID visualizza_rfid;

        private string provenienza;

        public ComponentiDelPoster(BenvenutoPostering benvenuto, PosterDellaMostra poster, int id_mostra, int id_poster, string nome_poster, string directory_principale, string provenienza, TalkingPaper.BarCode.BenvenutoBarCode benvenuto_bar, TalkingPaper.RfidCode.BenvenutoRFID benvenuto_rfid, TalkingPaper.BarCode.FormVisualizzaElementi visualizza_bar, TalkingPaper.RfidCode.FormVisualizzaElementiRFID visualizza_rfid)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 99, true);
            this.audio_video = new ArrayList();
            audio_video.Add(null);
            audio_video.Add(null);
            this.provenienza = provenienza;
            this.visualizza_rfid = visualizza_rfid;
            this.visualizza_bar = visualizza_bar;
            this.benvenuto = benvenuto;
            this.benvenuto_bar = benvenuto_bar;
            this.benvenuto_rfid = benvenuto_rfid;
            this.poster = poster;
            this.id_mostra = id_mostra;
            this.id_poster = id_poster;
            this.nome_poster = nome_poster;
            this.directory_principale = directory_principale;
            this.nh_manager = new NHibernateManager();
            play_audio = new Bitmap(directory_principale + @"/Images/Icons/nota2.gif");
            modifica = new Bitmap(directory_principale + @"/Images/Icons/modifica3.gif");
            elimina = new Bitmap(directory_principale + @"/Images/Icons/elimina_cestino.gif");
            play_video = new Bitmap(directory_principale + @"/Images/Icons/play_video.gif");
            testo = new Bitmap(directory_principale + @"/Images/Icons/preview _testo.gif");
            preview_immagine = new Bitmap(directory_principale + @"/Images/Icons/preview_immagine.gif");
            pausa = new Bitmap(directory_principale + @"/Images/Icons/Pause.bmp");
            stop = new Bitmap(directory_principale + @"/Images/Icons/Stop.bmp");
            riprendi = new Bitmap(directory_principale + @"/Images/Icons/Play.bmp");
            this.sottotitolo.Text = this.sottotitolo.Text + '"' + nome_poster + '"';
            Esci.Cursor = Cursors.Hand;
            button1.Cursor = Cursors.Hand;
            button2.Cursor = Cursors.Hand;
            button3.Cursor = Cursors.Hand;
            button4.Cursor = Cursors.Hand;
            AggiungiAMostra.Cursor = Cursors.Hand;
            AggiungiControllo.Cursor = Cursors.Hand;
            if (id_mostra == -1) {
                AggiungiAMostra.Visible = true;
            }
            if ((benvenuto == null) && (poster == null)&&(provenienza!=null)&&(id_mostra!=-1)) {
                button2.Visible = false;
                AggiungiAMostra.Visible = false;
            }
            if ((visualizza_bar != null) || (visualizza_rfid != null)) {
                AggiungiAMostra.Visible = false;
            }
            if (provenienza != null)
            {
                /*AggiungiAMostra.Visible = false;
                if (provenienza.CompareTo("rfid") == 0)
                {
                    button4.Visible = false;
                }
                else if (provenienza.CompareTo("barcode") == 0)
                {
                    button5.Visible = false;
                }*/
            }
            //textBox1.Select(0,0);
            InterrogaDB();
            Controlli();
            if ((benvenuto != null) && (poster == null)) {
                button2.Text = "Indietro";
            }
            else if (poster != null)
            {
                button2.Text = "Indietro";
            }
            else {
                button2.Visible = false;
            }
        }

        private void ComponentiDelPoster_Load(object sender, EventArgs e)
        {
            
        }

        private void InterrogaDB() {
            using (ISession tempS = nh_manager.Session)
            using (ITransaction tempT = tempS.BeginTransaction())
            {
                try
                {
                    IQuery q = tempS.CreateQuery("FROM Contenuto as cont WHERE cont.Poster=:Pos");
                    q.SetParameter("Pos", id_poster);
                    contenuti = q.List();
                    tempT.Commit();
                    int non_controlli = 0;
                    foreach (Contenuto c in contenuti) {
                        if (c.Tipo.Tipo.CompareTo("Controllo") != 0) {
                            non_controlli++;
                        }
                    }
                    if (non_controlli == 0)
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
                        ElencoRisorse.ColumnCount = 13;
                        ElencoRisorse.ColumnHeadersVisible = false;
                        ElencoRisorse.Columns[0].Visible = false;
                        //DataGridViewRow riga = new DataGridViewRow();
                        ElencoRisorse.Rows.Add("NUM", "  ", "NOME", "  ", "AUDIO/VIDEO", "  ", "IMMAGINE","  ","TESTO","  ","MODIFICA","  ","ELIMINA"); // ,"  ", "ELIMINA");
                        ElencoRisorse.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
                        ElencoRisorse.Rows.Add();
                        ElencoRisorse.CellClick += new DataGridViewCellEventHandler(this.ClickSullaTabella);
                        ElencoRisorse.CellMouseEnter += new DataGridViewCellEventHandler(ElencoRisorse_CellMouseEnter);

                        // Riempimento della DataGrid
                        int riga = 2;
                        foreach (Contenuto p in contenuti)
                        {
                            if (p.Tipo.Tipo.CompareTo("Controllo") != 0)
                            {
                                ElencoRisorse.Rows.Add(p.IDcontenuto, null, p.Nome, null, null, null, null, null, null, null, null, null, null);
                                try
                                {
                                    if (p.RisorsaMultimediale.Path.Contains("audio"))
                                    {
                                        DataGridViewImageCell play = new DataGridViewImageCell();
                                        play.Value = play_audio;
                                        play.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                        ElencoRisorse[4, riga] = play;
                                        audio_video.Add("audio");
                                        audio_video.Add(null);
                                    }
                                    else
                                    {
                                        DataGridViewImageCell play = new DataGridViewImageCell();
                                        play.Value = play_video;
                                        play.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                        ElencoRisorse[4, riga] = play;
                                        audio_video.Add("video");
                                        audio_video.Add("video");
                                    }
                                }
                                catch (Exception eeee) { 
                                
                                }
                                foreach (Altrarisorsa ris in p.AltrarisorsaLista)
                                {
                                    if (ris.Tipo.CompareTo("testo") == 0)
                                    {
                                        DataGridViewImageCell play_testo = new DataGridViewImageCell();
                                        play_testo.Value = testo;
                                        play_testo.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                        ElencoRisorse[8, riga] = play_testo;
                                    }
                                    else if (ris.Tipo.CompareTo("immagine") == 0)
                                    {
                                        DataGridViewImageCell preview_img = new DataGridViewImageCell();
                                        preview_img.Value = preview_immagine;
                                        preview_img.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                        ElencoRisorse[6, riga] = preview_img;
                                    }
                                }
                                DataGridViewImageCell delete = new DataGridViewImageCell();
                                delete.Value = elimina;
                                delete.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                DataGridViewImageCell modify = new DataGridViewImageCell();
                                modify.Value = modifica;
                                modify.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                ElencoRisorse[10, riga] = modify;
                                ElencoRisorse[12, riga] = delete;
                                audio_video.Add("immagine_testo");
                                audio_video.Add("immagine_testo");
                                ElencoRisorse.Rows.Add();
                                riga += 2;
                            }
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

        private void Controlli() {
           /* ElencoControlli1.ColumnCount = 7;
            ElencoControlli1.ColumnHeadersVisible = false;
            ElencoControlli1.Columns[0].Visible = false;
            //DataGridViewRow riga = new DataGridViewRow();
            ElencoControlli1.Rows.Add("NUM", "  ", "NOME", "  ", "ICONA", "  ", "ELIMINA");
            ElencoControlli1.Rows.Add();
            ElencoControlli1.CellClick += new DataGridViewCellEventHandler(this.ClickSullaTabellaDeiControlli);*/
            ElencoControlli1.CellMouseEnter += new DataGridViewCellEventHandler(ElencoControlli1_CellMouseEnter);

            // Riempimento della DataGrid
            //int riga = 2;
            int num_controllo = 1;
            IList controlli;
            DataGridViewImageCell pause = new DataGridViewImageCell();
            DataGridViewImageCell resume = new DataGridViewImageCell();
            DataGridViewImageCell stopp = new DataGridViewImageCell();
            //DataGridViewImageCell eliminare = new DataGridViewImageCell();
            using (ISession tempS = nh_manager.Session)
            using (ITransaction tempT = tempS.BeginTransaction())
            {
                try
                {
                    IQuery q = tempS.CreateQuery("FROM Contenuto as cont WHERE cont.Poster=:Pos");
                    q.SetParameter("Pos", id_poster);
                    controlli = q.List();
                    tempT.Commit();
                    foreach (Contenuto c in controlli)
                    {
                        if (c.Tipo.Tipo.CompareTo("Controllo") == 0)
                        {
                            if (num_controllo == 1)
                            {
                                ElencoControlli1.ColumnCount = 5;
                                ElencoControlli1.ColumnHeadersVisible = false;
                                ElencoControlli1.Columns[0].Visible = false;
                                //DataGridViewRow riga = new DataGridViewRow();
                                //ElencoControlli1.Rows.Add("NUM", "  ", "NOME", "  ", "ICONA", "  ", "ELIMINA");
                                //ElencoControlli1.Rows.Add();
                               // ElencoControlli1.CellClick += new DataGridViewCellEventHandler(this.ClickSullaTabellaDeiControlli1);
                                ElencoControlli1.Rows.Add(c.IDcontenuto, null, c.Nome, null, null);
                                ElencoControlli1.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
                                ElencoControlli1.Rows.Add();
                                ElencoControlli1.Rows.Add();
                                ElencoControlli1[4, 1].Value = "elimina";
                                if (c.Tipo.Descrizione.CompareTo("Pausa") == 0)
                                {
                                    //DataGridViewImageCell delete = new DataGridViewImageCell();
                                    pause.Value = pausa;
                                    pause.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli1[2, 2] = pause;
                                }
                                else if (c.Tipo.Descrizione.CompareTo("Stop") == 0)
                                {
                                    stopp.Value = stop;
                                    stopp.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli1[2, 2] = stopp;
                                }
                                else if (c.Tipo.Descrizione.CompareTo("Play") == 0)
                                {
                                    resume.Value = riprendi;
                                    resume.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli1[2, 2] = resume;
                                }
                                DataGridViewImageCell eliminare = new DataGridViewImageCell();
                                eliminare.Value = elimina;
                                eliminare.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                ElencoControlli1[4, 2] = eliminare;
                                //riga += 2;
                                //num_controllo = 2;
                            }
                            if (num_controllo == 2)
                            {
                                ElencoControlli2.ColumnCount = 5;
                                ElencoControlli2.ColumnHeadersVisible = false;
                                ElencoControlli2.Columns[0].Visible = false;
                                //DataGridViewRow riga = new DataGridViewRow();
                                //ElencoControlli1.Rows.Add("NUM", "  ", "NOME", "  ", "ICONA", "  ", "ELIMINA");
                                //ElencoControlli1.Rows.Add();
                                //ElencoControlli2.CellClick += new DataGridViewCellEventHandler(this.ClickSullaTabellaDeiControlli2);
                                ElencoControlli2.CellMouseEnter += new DataGridViewCellEventHandler(ElencoControlli2_CellMouseEnter);
                                ElencoControlli2.Rows.Add(c.IDcontenuto, null, c.Nome, null, null);
                                ElencoControlli2.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
                                ElencoControlli2.Rows.Add();
                                ElencoControlli2.Rows.Add();
                                ElencoControlli2[4, 1].Value = "elimina";
                                if (c.Tipo.Descrizione.CompareTo("Pausa") == 0)
                                {
                                    //DataGridViewImageCell delete = new DataGridViewImageCell();
                                    pause.Value = pausa;
                                    pause.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli2[2, 2] = pause;
                                }
                                else if (c.Tipo.Descrizione.CompareTo("Stop") == 0)
                                {
                                    stopp.Value = stop;
                                    stopp.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli2[2, 2] = stopp;
                                }
                                else if (c.Tipo.Descrizione.CompareTo("Play") == 0)
                                {
                                    resume.Value = riprendi;
                                    resume.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli2[2, 2] = resume;
                                }
                                DataGridViewImageCell eliminare = new DataGridViewImageCell();
                                eliminare.Value = elimina;
                                eliminare.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                ElencoControlli2[4, 2] = eliminare;
                                //riga += 2;
                                //num_controllo = 3;
                            }
                            if (num_controllo == 3)
                            {
                                ElencoControlli3.ColumnCount = 5;
                                ElencoControlli3.ColumnHeadersVisible = false;
                                ElencoControlli3.Columns[0].Visible = false;
                                //DataGridViewRow riga = new DataGridViewRow();
                                //ElencoControlli1.Rows.Add("NUM", "  ", "NOME", "  ", "ICONA", "  ", "ELIMINA");
                                //ElencoControlli1.Rows.Add();
                                //ElencoControlli3.CellClick += new DataGridViewCellEventHandler(this.ClickSullaTabellaDeiControlli3);
                                ElencoControlli3.CellMouseEnter += new DataGridViewCellEventHandler(ElencoControlli3_CellMouseEnter);
                                ElencoControlli3.Rows.Add(c.IDcontenuto, null, c.Nome, null, null);
                                ElencoControlli3.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
                                ElencoControlli3.Rows.Add();
                                ElencoControlli3.Rows.Add();
                                ElencoControlli3[4, 1].Value = "elimina";
                                if (c.Tipo.Descrizione.CompareTo("Pausa") == 0)
                                {
                                    //DataGridViewImageCell delete = new DataGridViewImageCell();
                                    pause.Value = pausa;
                                    pause.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli3[2, 2] = pause;
                                }
                                else if (c.Tipo.Descrizione.CompareTo("Stop") == 0)
                                {
                                    stopp.Value = stop;
                                    stopp.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli3[2, 2] = stopp;
                                }
                                else if (c.Tipo.Descrizione.CompareTo("Play") == 0)
                                {
                                    resume.Value = riprendi;
                                    resume.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    ElencoControlli3[2, 2] = resume;
                                }
                                DataGridViewImageCell eliminare = new DataGridViewImageCell();
                                eliminare.Value = elimina;
                                eliminare.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                ElencoControlli3[4, 2] = eliminare;
                                //riga += 2;
                                num_controllo = 3;
                            }
                            num_controllo++;
                        }
                       // num_controllo++;
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

        private void ClickSullaTabellaDeiControlli1(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 4) && (e.RowIndex == 2))
            {
                this.Cursor = Cursors.WaitCursor;
                QuestionEliminaComponente nuovo = new QuestionEliminaComponente(this, (int)ElencoControlli1[0, 0].Value, benvenuto, poster, id_mostra, id_poster, nome_poster, directory_principale,provenienza,benvenuto_bar,benvenuto_rfid,visualizza_bar,visualizza_rfid);
                //this.Visible = false;
                nuovo.Show();
                this.Cursor = Cursors.Default;
                this.Visible = false;
               /* string descrizione_controllo;
                descrizione_controllo = (String)ElencoControlli1[2, 0].Value;
                using (ISession tempS = nh_manager.Session)
                using (ITransaction tempT = tempS.BeginTransaction())
                {
                    try
                    {
                        Tipologia tipo = new Tipologia();
                        Poster posterr = new Poster();
                        Contenuto da_eliminare = new Contenuto();
                        IQuery q = tempS.CreateQuery("FROM Tipologia as tp WHERE tp.Descrizione=:Des");
                        q.SetParameter("Des", descrizione_controllo);
                        tipo = (Tipologia)q.List()[0];
                        tempS.Flush();
                        IQuery q2 = tempS.CreateQuery("FROM Poster as pt WHERE pt.IDposter=:Pos");
                        q2.SetParameter("Pos", id_poster);
                        posterr = (Poster)q2.List()[0];
                        tempS.Flush();
                        foreach (Contenuto cont in posterr.ContenutoLista) {
                            if (cont.Tipo.IDtipologia == tipo.IDtipologia) {
                                //posterr.ContenutoLista.Remove(cont);
                                //tempS.Delete(cont);
                                //tempS.Flush();
                                da_eliminare = cont;
                            }
                        }
                        posterr.ContenutoLista.Remove(da_eliminare);
                        tempS.Delete(da_eliminare);
                        tempS.Flush();
                        tempS.Update(posterr);
                        tempS.Flush();
                        tempT.Commit();
                        this.Close();
                        this.Close();
                        ComponentiDelPoster nuova_form = new ComponentiDelPoster(benvenuto, poster, id_mostra, id_poster, nome_poster, directory_principale);
                        nuova_form.Show();
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
                }*/
            }
        }

        private void ClickSullaTabellaDeiControlli2(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 4) && (e.RowIndex == 2))
            {
                this.Cursor = Cursors.WaitCursor;
                QuestionEliminaComponente nuovo = new QuestionEliminaComponente(this, (int)ElencoControlli2[0, 0].Value, benvenuto, poster, id_mostra, id_poster, nome_poster, directory_principale,provenienza,benvenuto_bar,benvenuto_rfid,visualizza_bar,visualizza_rfid);
                //this.Visible = false;
                nuovo.Show();
                this.Cursor = Cursors.Default;
                this.Visible = false;
                /*string descrizione_controllo;
                descrizione_controllo = (String)ElencoControlli2[2, 0].Value;
                using (ISession tempS = nh_manager.Session)
                using (ITransaction tempT = tempS.BeginTransaction())
                {
                    try
                    {
                        Tipologia tipo = new Tipologia();
                        Poster posterr = new Poster();
                        Contenuto da_eliminare = new Contenuto();
                        IQuery q = tempS.CreateQuery("FROM Tipologia as tp WHERE tp.Descrizione=:Des");
                        q.SetParameter("Des", descrizione_controllo);
                        tipo = (Tipologia)q.List()[0];
                        tempS.Flush();
                        IQuery q2 = tempS.CreateQuery("FROM Poster as pt WHERE pt.IDposter=:Pos");
                        q2.SetParameter("Pos", id_poster);
                        posterr = (Poster)q2.List()[0];
                        tempS.Flush();
                        foreach (Contenuto cont in posterr.ContenutoLista)
                        {
                            if (cont.Tipo.IDtipologia == tipo.IDtipologia)
                            {
                                //posterr.ContenutoLista.Remove(cont);
                                //tempS.Delete(cont);
                                //tempS.Flush();
                                da_eliminare = cont;
                            }
                        }
                        posterr.ContenutoLista.Remove(da_eliminare);
                        tempS.Delete(da_eliminare);
                        tempS.Flush();
                        tempS.Update(posterr);
                        tempS.Flush();
                        tempT.Commit();
                        this.Close();
                        this.Close();
                        ComponentiDelPoster nuova_form = new ComponentiDelPoster(benvenuto, poster, id_mostra, id_poster, nome_poster, directory_principale);
                        nuova_form.Show();
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
                }*/
            }
        }

        private void ClickSullaTabellaDeiControlli3(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 4) && (e.RowIndex == 2))
            {
                this.Cursor = Cursors.WaitCursor;
                QuestionEliminaComponente nuovo = new QuestionEliminaComponente(this, (int)ElencoControlli3[0, 0].Value, benvenuto, poster, id_mostra, id_poster, nome_poster, directory_principale,provenienza,benvenuto_bar,benvenuto_rfid,visualizza_bar,visualizza_rfid);
                //this.Visible = false;
                nuovo.Show();
                this.Cursor = Cursors.Default;
                this.Visible = false;
                /*string descrizione_controllo;
                descrizione_controllo = (String)ElencoControlli3[2, 0].Value;
                using (ISession tempS = nh_manager.Session)
                using (ITransaction tempT = tempS.BeginTransaction())
                {
                    try
                    {
                        Tipologia tipo = new Tipologia();
                        Poster posterr = new Poster();
                        Contenuto da_eliminare = new Contenuto();
                        IQuery q = tempS.CreateQuery("FROM Tipologia as tp WHERE tp.Descrizione=:Des");
                        q.SetParameter("Des", descrizione_controllo);
                        tipo = (Tipologia)q.List()[0];
                        tempS.Flush();
                        IQuery q2 = tempS.CreateQuery("FROM Poster as pt WHERE pt.IDposter=:Pos");
                        q2.SetParameter("Pos", id_poster);
                        posterr = (Poster)q2.List()[0];
                        tempS.Flush();
                        foreach (Contenuto cont in posterr.ContenutoLista)
                        {
                            if (cont.Tipo.IDtipologia == tipo.IDtipologia)
                            {
                                //posterr.ContenutoLista.Remove(cont);
                                //tempS.Delete(cont);
                                //tempS.Flush();
                                da_eliminare = cont;
                            }
                        }
                        posterr.ContenutoLista.Remove(da_eliminare);
                        tempS.Delete(da_eliminare);
                        tempS.Flush();
                        tempS.Update(posterr);
                        tempS.Flush();
                        tempT.Commit();
                        this.Close();
                        this.Close();
                        ComponentiDelPoster nuova_form = new ComponentiDelPoster(benvenuto, poster, id_mostra, id_poster, nome_poster, directory_principale);
                        nuova_form.Show();
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
                }*/
            }
        }

        private void ElencoControlli1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex == 2) && (e.ColumnIndex == 4))
            {
                ElencoControlli1.Cursor = Cursors.Hand;
            }
            else
                ElencoControlli1.Cursor = Cursors.Default;
        }

        private void ElencoControlli2_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex == 2) && (e.ColumnIndex == 4))
            {
                ElencoControlli2.Cursor = Cursors.Hand;
            }
            else
                ElencoControlli2.Cursor = Cursors.Default;
        }

        private void ElencoControlli3_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex == 2) && (e.ColumnIndex == 4))
            {
                ElencoControlli3.Cursor = Cursors.Hand;
            }
            else
                ElencoControlli3.Cursor = Cursors.Default;
        }

        private void ElencoRisorse_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 4) || (e.ColumnIndex == 6) || (e.ColumnIndex == 8) || (e.ColumnIndex == 10) || (e.ColumnIndex == 12))
            {
                if (ElencoRisorse[e.ColumnIndex, e.RowIndex].Value != null)
                {
                    ElencoRisorse.Cursor = Cursors.Hand;
                }
                else
                    ElencoRisorse.Cursor = Cursors.Default;
            }
            else
                ElencoRisorse.Cursor = Cursors.Default;
        }

        private void ClickSullaTabella(object sender, DataGridViewCellEventArgs e)
        {
            if ((ElencoRisorse[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 2))
            {
                //this.Visible = false;
                //MessageBox.Show("Visualizza info sul componente: se c'è Barcode o RFID, Tipo associato (Controllo, Componente),Path Nome ed Estensione della risorsa multimediale,");
                //ComponentiDelPoster nuova = new ComponentiDelPoster(benvenuto, this, id_mostra, (int)ElencoRisorse[0, e.RowIndex].Value, (string)ElencoRisorse[2, e.RowIndex].Value, directory_principale);
                //nuova.Show();
            }
            else if ((ElencoRisorse[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 10))
            {
               /* this.Visible = false;
                QuestionEliminaPoster nuova = new QuestionEliminaPoster(this, id_mostra, (int)ElencoRisorse[0, e.RowIndex].Value, (string)ElencoRisorse[2, e.RowIndex].Value, benvenuto, elenco_mostre, nome_mostra, directory_principale);
                nuova.Show();
                */
                //MessageBox.Show("Forma di modifica");
                //this.Visible = false;
                this.Cursor = Cursors.WaitCursor;
                NuovoComponente nuovo = new NuovoComponente(benvenuto,poster,this, nome_poster, id_mostra, id_poster, true, (int)ElencoRisorse[0,e.RowIndex].Value,(string)ElencoRisorse[2,e.RowIndex].Value,directory_principale,provenienza,benvenuto_bar,benvenuto_rfid,visualizza_bar,visualizza_rfid);
                nuovo.Show();
                this.Cursor = Cursors.Default;
                this.Visible = false;
            }
            else if ((ElencoRisorse[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 4))
            {
                /* this.Visible = false;
                 QuestionEliminaPoster nuova = new QuestionEliminaPoster(this, id_mostra, (int)ElencoRisorse[0, e.RowIndex].Value, (string)ElencoRisorse[2, e.RowIndex].Value, benvenuto, elenco_mostre, nome_mostra, directory_principale);
                 nuova.Show();
                 */
                //MessageBox.Show((String)(audio_video[e.RowIndex]));
                this.Cursor = Cursors.WaitCursor;
                string path="";
                string nome="";
                foreach(Contenuto p in contenuti){
                    if (p.IDcontenuto==(int)ElencoRisorse[0,e.RowIndex].Value){
                        path=p.RisorsaMultimediale.Path;
                        nome=p.RisorsaMultimediale.Nome;
                    }
                }
                //if (((String)audio_video[e.RowIndex]).CompareTo("audio")==0)
                if (path.Contains("audio"))
                {
                    this.Enabled = false;
                    PlayAudio nuovo = new PlayAudio(directory_principale+path + "\\" + nome, null, this,null,null,null);
                    nuovo.Show();
                }
                else
                {
                    this.Enabled = false;
                    PlayVideo nuovo = new PlayVideo(directory_principale+path + "\\" + nome, null, this,null,null,null);
                    nuovo.Show();
                }
                this.Cursor = Cursors.Default;
                //Play suona = new Play(directory_principale+path+"/"+nome);
            }
            else if ((ElencoRisorse[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 12))
            {
                /* this.Visible = false;
                 QuestionEliminaPoster nuova = new QuestionEliminaPoster(this, id_mostra, (int)ElencoRisorse[0, e.RowIndex].Value, (string)ElencoRisorse[2, e.RowIndex].Value, benvenuto, elenco_mostre, nome_mostra, directory_principale);
                 nuova.Show();
                 */
                //MessageBox.Show("Forma di eliminazione");
                this.Cursor = Cursors.WaitCursor;
                //this.Visible = false;
                QuestionEliminaComponente nuovaaa = new QuestionEliminaComponente(this, (int)ElencoRisorse[0, e.RowIndex].Value, benvenuto, poster, id_mostra, id_poster, nome_poster, directory_principale,provenienza,benvenuto_bar,benvenuto_rfid,visualizza_bar,visualizza_rfid);
                nuovaaa.Show();
                this.Cursor = Cursors.Default;
                this.Visible = false;
            }
            else if ((ElencoRisorse[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 6))
            {
                /* this.Visible = false;
                 QuestionEliminaPoster nuova = new QuestionEliminaPoster(this, id_mostra, (int)ElencoRisorse[0, e.RowIndex].Value, (string)ElencoRisorse[2, e.RowIndex].Value, benvenuto, elenco_mostre, nome_mostra, directory_principale);
                 nuova.Show();
                 */
                //MessageBox.Show("Preview Immagine");
                this.Cursor = Cursors.WaitCursor;
                string path_immagine="";
                string nome_immagine="";
                using (ISession tempS = nh_manager.Session)
                using (ITransaction tempT = tempS.BeginTransaction())
                {
                    try
                    {
                        Contenuto con= new Contenuto();
                        IQuery q = tempS.CreateQuery("FROM Contenuto as com WHERE com.IDcontenuto=:Com");
                        q.SetParameter("Com",(int)(ElencoRisorse[0,e.RowIndex].Value));
                        con = (Contenuto)q.List()[0];
                        tempT.Commit();
                        foreach(Altrarisorsa a in con.AltrarisorsaLista){
                            if(a.Tipo.CompareTo("immagine")==0){
                                path_immagine=a.Path;
                                nome_immagine=a.Nome;
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
                StampaImmagine imag = new StampaImmagine(directory_principale+path_immagine+"/"+nome_immagine);
                this.Cursor = Cursors.Default;
            }
            else if ((ElencoRisorse[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 8))
            {
                /* this.Visible = false;
                 QuestionEliminaPoster nuova = new QuestionEliminaPoster(this, id_mostra, (int)ElencoRisorse[0, e.RowIndex].Value, (string)ElencoRisorse[2, e.RowIndex].Value, benvenuto, elenco_mostre, nome_mostra, directory_principale);
                 nuova.Show();
                 */
                //MessageBox.Show("Preview Testo");
                this.Cursor = Cursors.WaitCursor;
                string path_testo="";
                string nome_testo="";
                string tipo_testo = "";
                using (ISession tempS = nh_manager.Session)
                using (ITransaction tempT = tempS.BeginTransaction())
                {
                    try
                    {
                        Contenuto con= new Contenuto();
                        IQuery q = tempS.CreateQuery("FROM Contenuto as com WHERE com.IDcontenuto=:Com");
                        q.SetParameter("Com",(int)(ElencoRisorse[0,e.RowIndex].Value));
                        con = (Contenuto)q.List()[0];
                        tempT.Commit();
                        foreach(Altrarisorsa a in con.AltrarisorsaLista){
                            if(a.Tipo.CompareTo("testo")==0){
                                path_testo=a.Path;
                                nome_testo=a.Nome;
                                tipo_testo=a.Nome.Substring(a.Nome.Length - 4, 4);
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
                NuovoComponente nuovo_comp= new NuovoComponente(benvenuto,poster,this,nome_poster,id_mostra,id_poster,false,-1,"",directory_principale,provenienza,benvenuto_bar,benvenuto_rfid,visualizza_bar,visualizza_rfid);
                StampaTesto test = new StampaTesto(directory_principale + path_testo + "/" + nome_testo, tipo_testo, nuovo_comp);
                this.Cursor = Cursors.Default;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*if (poster != null)
            {
                poster.Visible = true;
            }
            else if (visualizza_bar != null) {
                visualizza_bar.Visible = true;
            }
            else if (visualizza_rfid != null) {
                visualizza_rfid.Visible = true;
            }
            else if (benvenuto != null)
            {
                benvenuto.Visible = true;
            }*/
            this.Cursor = Cursors.WaitCursor;
            if ((benvenuto != null) && (poster == null))
            {
                benvenuto.Visible = true;
            }
            else if (poster != null)
            {
                poster.Visible = true;
            }
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //this.Visible = false;
            NuovoComponente nuovo = new NuovoComponente(benvenuto,poster,this, nome_poster, id_mostra, id_poster, false,-1,"", directory_principale,provenienza,benvenuto_bar,benvenuto_rfid,visualizza_bar,visualizza_rfid);
            nuovo.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }

        private void AggiungiAMostra_Click(object sender, EventArgs e)
        {
            /*bool taggato = false;
            using (ISession tempS = nh_manager.Session)
                using (ITransaction tempT = tempS.BeginTransaction())
                {
                    try
                    {
                        //Tipologia tipo = new Tipologia();
                        Poster posterr = new Poster();
                        //bool taggato = false;
                        //Contenuto da_eliminare = new Contenuto();
                        IQuery q = tempS.CreateQuery("FROM Poster as pt WHERE pt.IDposter=:Pos");
                        q.SetParameter("Pos", id_poster);
                        posterr = (Poster)q.List()[0];
                        foreach (Contenuto c in posterr.ContenutoLista) {
                            if ((c.Barcode != 0) || (c.Rfidtag != 0)) {
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
                if (taggato == false)
                {
                    AggiungiPosterAMostra nuovo = new AggiungiPosterAMostra(benvenuto, this, id_poster, poster, directory_principale);
                    this.Visible = false;
                    nuovo.Show();
                }
                else {
                    QuestionPosterTaggato nuovo = new QuestionPosterTaggato(benvenuto, this, id_poster, poster, directory_principale);
                    this.Visible = false;
                    nuovo.Show();
                }*/
            //BenvenutoPostering benvenuto, PosterDellaMostra poster, int id_mostra, int id_poster, string nome_poster, string directory_principale, string provenienza, TalkingPaper.BarCode.BenvenutoBarCode benvenuto_bar, TalkingPaper.RfidCode.BenvenutoRFID benvenuto_rfid, TalkingPaper.BarCode.FormVisualizzaElementi visualizza_bar, TalkingPaper.RfidCode.FormVisualizzaElementiRFID visualizza_rfid
            this.Cursor = Cursors.WaitCursor;
            AggiungiPosterAMostra nuovo = new AggiungiPosterAMostra(benvenuto, this, id_poster, poster, directory_principale,benvenuto_bar,benvenuto_rfid,visualizza_bar,visualizza_rfid);
            //this.Visible = false;
            nuovo.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }

        private void AggiungiControllo_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //this.Visible = false;
            //BenvenutoPostering benvenuto,PosterDellaMostra poster,int id_mostra, int id_poster, string nome_poster,string directory_principale
            AggiungiControllo nuo= new AggiungiControllo(this,benvenuto,poster,id_mostra,id_poster,nome_poster,directory_principale,provenienza,benvenuto_bar,benvenuto_rfid,visualizza_bar,visualizza_rfid);
            nuo.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            PosterDaStoria nuovo = new PosterDaStoria(directory_principale, benvenuto, true,id_poster,provenienza,benvenuto_bar,benvenuto_rfid,visualizza_bar,visualizza_rfid,this);
            nuovo.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false; ;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (global.rfid == false)
            {
                this.Cursor = Cursors.WaitCursor;
                if (visualizza_rfid != null)
                {
                    visualizza_rfid.Close();
                }
                if (visualizza_bar != null)
                {
                    visualizza_bar.Close();
                }
                TalkingPaper.BarCode.FormVisualizzaElementi n = new TalkingPaper.BarCode.FormVisualizzaElementi(null, benvenuto_bar, id_poster, nome_poster, -1, directory_principale, "talkingpaper2", this, benvenuto, benvenuto_rfid);
                //this.Visible = false;
                n.Show();
                this.Cursor = Cursors.Default;
                this.Visible = false;
            }
            else
            {
                this.Cursor = Cursors.WaitCursor;
                if (visualizza_rfid != null)
                {
                    visualizza_rfid.Close();
                }
                if (visualizza_bar != null)
                {
                    visualizza_bar.Close();
                }
                TalkingPaper.RfidCode.FormVisualizzaElementiRFID ne = new TalkingPaper.RfidCode.FormVisualizzaElementiRFID(null, benvenuto_rfid, id_poster, nome_poster, -1, directory_principale, "talkingpaper2", this, benvenuto, benvenuto_bar);
                //this.Visible = false;
                ne.Show();
                this.Cursor = Cursors.Default;
                this.Visible = false;
            }
        }


        public BenvenutoPostering GetBenvenuto() {
            return benvenuto;
        }

        private void ElencoRisorse_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Esci_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if ((benvenuto != null) && (benvenuto.GetInizio() != null))
            {
                QuestionPostering n = new QuestionPostering(benvenuto, benvenuto.GetInizio(), this, benvenuto_bar, benvenuto_rfid, visualizza_bar, visualizza_rfid);
                this.Visible = false;
                n.Show();
            }
            else
            {
                QuestionPostering n = new QuestionPostering(benvenuto, null, this, benvenuto_bar, benvenuto_rfid, visualizza_bar, visualizza_rfid);
                this.Visible = false;
                n.Show();
            }
            this.Cursor = Cursors.Default;
        }

        private void Esci_Click_1(object sender, EventArgs e)
        {

        }

    }
}
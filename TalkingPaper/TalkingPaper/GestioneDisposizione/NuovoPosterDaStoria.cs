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
    public partial class NuovoPosterDaStoria : FormSchema
    {
        private int id_progetto;
        private DataGridView previewPoster;
        private string directory_principale;
        private string directory_origine;
        private string directory_temporanea;
        private PosterDaStoria poster_da_storia;
        private BenvenutoGestioneDisposizione benvenuto;
        private EccoLaStoria storia;
        private bool modifica;
        private int id_poster;
        private int id_poster2;
        private string nome_poster;
        private TalkingPaper.NHibernateManager nh_manager;
        private string provenienza;
        /*private TalkingPaper.BarCode.BenvenutoBarCode benvenuto_bar;
        private TalkingPaper.RfidCode.BenvenutoRFID benvenuto_rfid;
        private TalkingPaper.BarCode.FormVisualizzaElementi visualizza_bar;
        private TalkingPaper.RfidCode.FormVisualizzaElementiRFID visualizza_rfid;*/
        private TalkingPaper.Authoring.BenvenutoAuthoring benvenuto_aut;
        private TalkingPaper.Authoring.FormVisualizzaElementiAuthoring visualizza_aut;
        private ComponentiDelPoster componenti_poster;
        private string id_pannello;
        private string nome_pannello;
        private string configurazione;

        public NuovoPosterDaStoria(int id_progetto, string directory_principale, PosterDaStoria poster_da_storia, BenvenutoGestioneDisposizione benvenuto, EccoLaStoria storia, DataGridView previewPoster, string directory_origine, bool modifica, int id_poster, string directory_temporanea, string provenienza, TalkingPaper.Authoring.BenvenutoAuthoring benvenuto_aut, TalkingPaper.Authoring.FormVisualizzaElementiAuthoring visualizza_aut, ComponentiDelPoster componenti_poster, string id_pannello, string nome_pannello, string configurazione)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 50, true);
            //this.visualizza_bar = visualizza_bar;
            //this.visualizza_rfid = visualizza_rfid;
            this.previewPoster = previewPoster;
            this.provenienza = provenienza;
            this.benvenuto_aut = benvenuto_aut;
            this.visualizza_aut = visualizza_aut;
            this.id_pannello = id_pannello;
            this.nome_pannello = nome_pannello;
            this.configurazione = configurazione;
            //this.benvenuto_bar = benvenuto_bar;
            //this.benvenuto_rfid = benvenuto_rfid;
            this.id_progetto = id_progetto;
            this.directory_principale = directory_principale;
            this.directory_origine = directory_origine;
            this.directory_temporanea = directory_temporanea;
            this.poster_da_storia = poster_da_storia;
            this.benvenuto = benvenuto;
            this.storia = storia;
            this.modifica = modifica;
            this.id_poster = id_poster;
            this.componenti_poster = componenti_poster;
            this.nh_manager = new NHibernateManager();
            button1.Cursor = Cursors.Hand;
            button2.Cursor = Cursors.Hand;
            if (modifica == true)
            {
                Nome.ReadOnly = true;
                Descrizione.ReadOnly = true;
                using (ISession tempS = nh_manager.Session)
                using (ITransaction tempT = tempS.BeginTransaction())
                {
                    try
                    {
                        //IList tipologia_controlli;
                        Poster post = new Poster();
                        IQuery q3 = tempS.CreateQuery("FROM Poster as pt WHERE pt.IDposter=:Pos");
                        q3.SetParameter("Pos", id_poster);
                        post = (Poster)q3.List()[0];
                        tempS.Flush();
                        tempT.Commit();
                        Nome.Text = post.Nome;
                        Descrizione.Text = post.Descrizione;
                    }
                    catch (Exception exce)
                    {
                        tempT.Rollback();
                    }
                    finally
                    {
                        tempS.Close();
                    }
                }
            }
        }

        private void NuovoPosterDaStoria_Load(object sender, EventArgs e)
        {
           /* ArrayList componenti = new ArrayList();
            for (int i = 0; i < previewPoster.Rows.Count; i++)
            {
                string nome = "";
                string audio = "";
                string immagine = "";
                string testo = "";
               // MessageBox.Show(previewPoster[0, 0].Value.ToString());
                try
                {
                    if (((string)previewPoster[0, i].Value).CompareTo("  ")==0) {
                        if (previewPoster[2, i] != null) {
                            nome = (string)(previewPoster[2, i].Value);
                            MessageBox.Show(nome);
                            try
                            {
                                if ((previewPoster[0, i + 1] != null) && (((string)previewPoster[0, i + 1].Value).CompareTo("audio") == 0))
                                {
                                    audio = (string)(previewPoster[2, i + 1].Value);
                                    MessageBox.Show(audio);
                                    i++;
                                }
                            }
                            catch (Exception ee) { 
                            
                            }
                            try
                            {
                                if ((previewPoster[0, i + 1] != null) && (((string)previewPoster[0, i + 1].Value).CompareTo("immagine") == 0))
                                {
                                    immagine = (string)(previewPoster[2, i + 1].Value);
                                    MessageBox.Show(immagine);
                                    i++;
                                }
                            }
                            catch (Exception eee) { 
                            
                            }
                            try
                            {
                                if ((previewPoster[0, i + 1] != null) && (((string)previewPoster[0, i + 1].Value).CompareTo("testo") == 0))
                                {
                                    testo = (string)(previewPoster[2, i + 1].Value);
                                    MessageBox.Show(testo);
                                    i++;
                                }
                            }
                            catch (Exception eeee) { 
                            
                            }
                            Contenuto contenuto = new Contenuto();
                            contenuto.Nome = nome;
                            contenuto.Livello = 0;
                            contenuto.Ordine = 0;
                            contenuto.Rfidtag = "0";
                            contenuto.Barcode = "0";
                        }
                    }
                }
                catch (Exception except)
                {
                    i++;
                }
            }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            storia.Visible = true;
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ArrayList componenti = new ArrayList();
            this.Cursor = Cursors.WaitCursor;
            ArrayList non_controlli_presenti = new ArrayList();
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
                    //Poster poster2 = new Poster();
                    Poster pos = new Poster();
                    Poster poster = new Poster();
                    if (modifica == true)
                    {
                        //Poster pos = new Poster();
                        IQuery q7 = tempS.CreateQuery("FROM Poster as pt WHERE pt.IDposter=:Pos");
                        q7.SetParameter("Pos", id_poster);
                        pos = (Poster)q7.List()[0];
                        tempS.Flush();
                        ArrayList controlli_presenti = new ArrayList();
                        //ArrayList non_controlli_presenti = new ArrayList();
                        //pos.ContenutoLista.Clear();
                        int lu = pos.ContenutoLista.Count;
                        //MessageBox.Show(lu.ToString());
                        foreach (Contenuto c in pos.ContenutoLista) {
                            if (c.Tipo.Tipo.CompareTo("Controllo") == 0)
                            {
                                controlli_presenti.Add((Contenuto)c);
                            }
                            else
                            {
                                non_controlli_presenti.Add((Contenuto)c);
                                tempS.Delete(c);
                            }
                        }
                        pos.ContenutoLista.Clear();
                        int le = pos.ContenutoLista.Count;
                        pos.ContenutoLista = new ArrayList();
                        //MessageBox.Show(le.ToString());
                        foreach (Contenuto c in controlli_presenti) {
                            pos.ContenutoLista.Add((Contenuto)c);
                        }
                        id_poster2 = pos.IDposter;
                        nome_poster = pos.Nome;
                        tempS.Update(pos);
                    }
                    else
                    {
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
                        //Poster pos = new Poster();
                        IList poster_sel;
                        IQuery q4 = tempS.CreateQuery("FROM Poster as pt");
                        //q2.SetParameter("Mos", id_mostra);
                        poster_sel = q4.List();
                        foreach (Poster p in poster_sel)
                        {
                            pos = p;
                        }
                        tempS.Flush();
                        id_poster2 = pos.IDposter;
                        nome_poster = pos.Nome;
                    }
                    //tempT.Commit();
                    //poster.Mostra = null;
                    /*ComponentiDelPoster nuov = new ComponentiDelPoster(benvenuto, null, -1, eccolo.IDposter, eccolo.Nome, directory_principale);
                    this.Close();
                    nuov.Show();*/
               
                    //Poster pos = new Poster();
                    for (int i = 0; i < previewPoster.Rows.Count; i=i+2)
                    {
                        string nome = "";
                        string audio = "";
                        string video = "";
                        string immagine = "";
                        string testo = "";
                        int id_compooo=-1;
                        // MessageBox.Show(previewPoster[0, 0].Value.ToString());
                        try
                        {
                            if (((string)previewPoster[0, i].Value).CompareTo("  ") == 0)
                            {
                                if (previewPoster[2, i] != null)
                                {
                                    nome = (string)(previewPoster[2, i].Value);
                                    if (previewPoster[5, i].Value != null)
                                    {
                                        id_compooo = (int)(previewPoster[5, i].Value);
                                    }
                                    //MessageBox.Show(nome);
                                    try
                                    {
                                        if ((previewPoster[0, i + 1] != null) && ((previewPoster[0, i + 1].Value != null)))
                                        {
                                            if (((string)previewPoster[0, i + 1].Value).CompareTo("audio") == 0)
                                            {
                                                audio = (string)(previewPoster[2, i + 1].Value);
                                                //MessageBox.Show(audio);
                                                i++;
                                            }
                                        }
                                    }
                                    catch (Exception ee)
                                    {

                                    }
                                    try
                                    {
                                        if ((previewPoster[0, i + 1] != null) && ((previewPoster[0, i + 1].Value != null)))
                                        {
                                            if (((string)previewPoster[0, i + 1].Value).CompareTo("video") == 0)
                                            {
                                                video = (string)(previewPoster[2, i + 1].Value);
                                                //MessageBox.Show(video);
                                                i++;
                                            }
                                        }
                                    }
                                    catch (Exception ee)
                                    {

                                    }
                                    try
                                    {
                                        if ((previewPoster[0, i + 1] != null) && ((previewPoster[0, i + 1].Value != null)))
                                        {
                                            if (((string)previewPoster[0, i + 1].Value).CompareTo("immagine") == 0)
                                            {
                                                immagine = (string)(previewPoster[2, i + 1].Value);
                                                //MessageBox.Show(immagine);
                                                i++;
                                            }
                                        }       
                                    }
                                    catch (Exception eee)
                                    {

                                    }   
                                    try
                                    {
                                        if (((previewPoster[0, i + 1] != null))&&(((string)previewPoster[0, i + 1].Value)!=null))
                                        {
                                            if (((string)previewPoster[0, i + 1].Value).CompareTo("testo") == 0)
                                            {
                                                testo = (string)(previewPoster[2, i + 1].Value);
                                                //MessageBox.Show(testo);
                                                i++;
                                            }
                                        }
                                    }       
                                    catch (Exception eeee)
                                    {

                                    }
                                    Contenuto contenuto = new Contenuto();
                                    Risorsamultimediale risorsa = new Risorsamultimediale();
                                    Altrarisorsa immagine_risorsa = new Altrarisorsa();
                                    Altrarisorsa testo_risorsa = new Altrarisorsa();
                                    bool ok_audio = false;
                                    bool ok_immagine = false;
                                    bool ok_testo = false;
                                    bool ok_video = false;
                                    contenuto.Nome = nome;
                                    contenuto.Livello = 0;
                                    contenuto.Ordine = 0;
                                    Contenuto conte = new Contenuto();
                                    IList conte_sel;
                                    contenuto.Rfidtag = "0";
                                    contenuto.Barcode = "0";
                                    if ((id_compooo != -1)&&(modifica==true))
                                    {
                                        foreach (Contenuto c in non_controlli_presenti) {
                                            if (c.IDcontenuto == id_compooo) {
                                                contenuto.Rfidtag = c.Rfidtag;
                                                contenuto.Barcode = c.Barcode;
                                            }
                                        }
                                    }
                                   
                                    IList tipologie;
                                    IQuery q5 = tempS.CreateQuery("FROM Tipologia as tp");
                                    //q2.SetParameter("Mos", id_mostra);
                                    tipologie = q5.List();
                                    tempS.Flush();
                                    foreach (Tipologia t in tipologie) {
                                        if (audio.CompareTo("") != 0) {
                                            if (t.Descrizione.CompareTo("Musica") == 0) {
                                                contenuto.Tipo = t;
                                            }
                                        }else if (video.CompareTo("")!=0){
                                            if (t.Descrizione.CompareTo("Video") == 0)
                                            {
                                                contenuto.Tipo = t;
                                            }
                                        }
                                        /*else if (audio.CompareTo("") != 0)
                                        {
                                            if (t.Descrizione.CompareTo("Video") == 0)
                                            {
                                                contenuto.Tipo = t;
                                            }
                                        }*/
                                        else if (audio.CompareTo("") == 0)
                                        {
                                            if (t.Descrizione.CompareTo("Altro") == 0)
                                            {
                                                contenuto.Tipo = t;
                                            }
                                        }
                                    }
                                    contenuto.AltrarisorsaLista = new ArrayList();
                                    if (audio.CompareTo("") != 0) {
                                        string nome_audio;
                                        int indice= audio.LastIndexOf("/");
                                        nome_audio = audio.Substring(indice+1);
                                        string estensione = nome_audio.Substring(nome_audio.Length - 4);
                                        //Risorsamultimediale risorsa = new Risorsamultimediale();
                                        risorsa.Dimensione = 0;
                                        risorsa.Estensione = estensione;
                                        risorsa.Nome = nome_audio;
                                        risorsa.Path = "\\audio";
                                        tempS.Save(risorsa);
                                        tempS.Flush();
                                        ok_audio = true;
                                        try
                                        {
                                            System.IO.File.Copy(directory_origine + audio, "D:/Documents and Settings/IO/Documenti/Visual Studio 2005/ProvaMySql/TalkingPaper/TalkingPaper/audio/" + nome_audio, true);
                                            System.IO.File.Copy(directory_origine+audio, directory_principale + @"/audio/" + nome_audio, true);
                                        }
                                        catch (Exception exc)
                                        { 
                                        
                                        }
                                    }
                                    if (video.CompareTo("") != 0)
                                    {
                                        string nome_video;
                                        int indice = video.LastIndexOf("/");
                                        nome_video = video.Substring(indice + 1);
                                        string estensione = nome_video.Substring(nome_video.Length - 4);
                                        //Risorsamultimediale risorsa = new Risorsamultimediale();
                                        risorsa.Dimensione = 0;
                                        risorsa.Estensione = estensione;
                                        risorsa.Nome = nome_video;
                                        risorsa.Path = "\\Video";
                                        tempS.Save(risorsa);
                                        tempS.Flush();
                                        ok_video = true;
                                        try
                                        {
                                            System.IO.File.Copy(directory_origine + video, "D:/Documents and Settings/IO/Documenti/Visual Studio 2005/ProvaMySql/TalkingPaper/TalkingPaper/Video/" + nome_video, true);
                                            System.IO.File.Copy(directory_origine + video, directory_principale + @"/Video/" + nome_video, true);
                                        }
                                        catch (Exception exc)
                                        {

                                        }
                                    }
                                    if (ok_audio == true)
                                    {
                                        contenuto.RisorsaMultimediale = risorsa;
                                    }
                                    else if (ok_video == true)
                                    {
                                        contenuto.RisorsaMultimediale = risorsa;
                                    }
                                    else {
                                        contenuto.RisorsaMultimediale = null;
                                    }
                                    if (immagine.CompareTo("") != 0) {
                                        string nome_immagine;
                                        int indice = immagine.LastIndexOf("/");
                                        nome_immagine = immagine.Substring(indice + 1);
                                        string estensione = nome_immagine.Substring(nome_immagine.Length - 4);
                                        immagine_risorsa.Nome = nome_immagine;
                                        immagine_risorsa.Path="\\Images";
                                        immagine_risorsa.Tipo = "immagine";
                                        tempS.Save(immagine_risorsa);
                                        tempS.Flush();
                                        ok_immagine = true;
                                        try
                                        {
                                            System.IO.File.Copy(directory_origine + immagine + ".rex.jpg", "D:/Documents and Settings/IO/Documenti/Visual Studio 2005/ProvaMySql/TalkingPaper/TalkingPaper/Images/" + nome_immagine, true);
                                            System.IO.File.Copy(directory_origine + immagine + ".rex.jpg", directory_principale + @"/Images/" + nome_immagine, true);
                                        }
                                        catch (Exception exc)
                                        {

                                        }
                                    }
                                    if (ok_immagine == true) {
                                        contenuto.AltrarisorsaLista.Add(immagine_risorsa);
                                    }
                                    if (testo.CompareTo("") != 0)
                                    {
                                        string nome_testo;
                                        int indice = testo.LastIndexOf("/");
                                        nome_testo = testo.Substring(indice + 1);
                                        string estensione = nome_testo.Substring(nome_testo.Length - 4);
                                        testo_risorsa.Nome = nome_testo;
                                        testo_risorsa.Path = "\\Testi";
                                        testo_risorsa.Tipo = "testo";
                                        //tempS.Save(testo_risorsa);
                                        //tempS.Flush();
                                        bool esiste_gia = true;
                                        int numm = 0;
                                        ok_testo = true;
                                        try
                                        {
                                            /*while (esiste_gia = true)
                                            {
                                                if (System.IO.File.Exists(directory_principale + @"/Testi/" + nome_testo) == false)
                                                {
                                                    System.IO.File.Copy(directory_temporanea + testo, "D:/Documents and Settings/IO/Documenti/Visual Studio 2005/ProvaMySql/TalkingPaper/TalkingPaper/Testi/" + nome_testo, false);
                                                    System.IO.File.Copy(directory_temporanea + testo, directory_principale + @"/Testi/" + nome_testo, false);
                                                    esiste_gia = false;
                                                }
                                                else
                                                {
                                                    System.Random rnd = new Random();
                                                    numm = rnd.Next();
                                                    nome_testo = nome_testo + numm.ToString();
                                                }
                                            }*/
                                            System.IO.File.Copy(directory_temporanea + testo, "D:/Documents and Settings/IO/Documenti/Visual Studio 2005/ProvaMySql/TalkingPaper/TalkingPaper/Testi/" + nome_testo, true);
                                            System.IO.File.Copy(directory_temporanea + testo, directory_principale + @"/Testi/" + nome_testo, true);
                                        }
                                        catch (Exception exc)
                                        {

                                        }
                                        //int indice = testo.LastIndexOf("/");
                                        //nome_testo = testo.Substring(indice + 1);
                                        //string estensione = nome_testo.Substring(nome_testo.Length - 4);
                                        //testo_risorsa.Nome = nome_testo;
                                        tempS.Save(testo_risorsa);
                                        tempS.Flush();
                                    }
                                    if (ok_testo == true)
                                    {
                                        contenuto.AltrarisorsaLista.Add(testo_risorsa);
                                    }
                                    contenuto.Poster = pos;
                                    tempS.Save(contenuto);
                                    tempS.Flush();
                                    pos.ContenutoLista.Add(contenuto);
                                }
                            }
                        }
                        catch (Exception except)
                        {
                            //i++;
                        }
                    }
                    tempS.Update(pos);
                    tempS.Flush();
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
            System.IO.Directory.Delete(directory_temporanea,true);
            ComponentiDelPoster componente = new ComponentiDelPoster(benvenuto, null, -1, id_poster2, nome_poster, directory_principale,provenienza,benvenuto_aut,visualizza_aut,id_pannello,nome_pannello,configurazione);
            //storia.Visible = true;
            componente.Show();
            poster_da_storia.Close();
            storia.Close();
            if ((componenti_poster != null) && (componenti_poster.Disposing == false))
            {
                componenti_poster.Close();
            }
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void Nome_TextChanged(object sender, EventArgs e)
        {

        }

        private void Ordine_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Descrizione_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
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
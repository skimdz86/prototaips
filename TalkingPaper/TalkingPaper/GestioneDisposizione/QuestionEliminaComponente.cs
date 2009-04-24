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
    public partial class QuestionEliminaComponente : Form
    {
        private ComponentiDelPoster componenti_poster;
        private int id_componente;
        private BenvenutoGestioneDisposizione benvenuto;
        private PosterDellaMostra poster;
        private int id_mostra;
        private int id_poster;
        private string nome_poster;
        private string directory_principale;
        private TalkingPaper.NHibernateManager nh_manager;
        private string provenienza;
        /*private TalkingPaper.BarCode.BenvenutoBarCode benvenuto_bar;
        private TalkingPaper.RfidCode.BenvenutoRFID benvenuto_rfid;
        private TalkingPaper.BarCode.FormVisualizzaElementi visualizza_bar;
        private TalkingPaper.RfidCode.FormVisualizzaElementiRFID visualizza_rfid;
        private TalkingPaper.Authoring.BenvenutoAuthoring benvenuto_aut;*/
        private TalkingPaper.Authoring.FormVisualizzaElementiAuthoring visualizza_aut;
        private string id_pannello;
        private string nome_pannello;
        private string configurazione;
        private int tag_per_riga;
        private int tag_per_colonna;
        private char[] alfabeto ={ 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'Z' };
        private Authoring.ElementoGriglia[,] matrice;

        public QuestionEliminaComponente(ComponentiDelPoster componenti_poster, int id_componente, BenvenutoGestioneDisposizione benvenuto, PosterDellaMostra poster, int id_mostra, int id_poster, string nome_poster, string directory_principale, string provenienza, /*TalkingPaper.Authoring.BenvenutoAuthoring benvenuto_aut,*/ TalkingPaper.Authoring.FormVisualizzaElementiAuthoring visualizza_aut, string id_pannello, string nome_pannello, string configurazione)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 45, true);
            //this.visualizza_bar = visualizza_bar;
            //this.visualizza_rfid = visualizza_rfid;
            //this.benvenuto_aut = benvenuto_aut;
            this.visualizza_aut = visualizza_aut;
            this.provenienza = provenienza;
            this.id_pannello = id_pannello;
            this.nome_pannello = nome_pannello;
            this.configurazione = configurazione;
            //this.benvenuto_bar = benvenuto_bar;
            //this.benvenuto_rfid = benvenuto_rfid;
            this.componenti_poster = componenti_poster;
            this.id_componente = id_componente;
            this.benvenuto = benvenuto;
            this.poster = poster;
            this.id_mostra = id_mostra;
            this.id_poster = id_poster;
            this.nome_poster = nome_poster;
            this.directory_principale = directory_principale;
            Si.Cursor = Cursors.Hand;
            Annulla.Cursor = Cursors.Hand;
            this.nh_manager = new NHibernateManager();
            LeggiRigaColonna();
            LeggiFileDeiComponenti();
        }

        private void LeggiRigaColonna()
        {
            try
            {
                string nome_file = directory_principale + "Griglia" + nome_pannello + id_pannello + ".xml";
                XmlTextReader iscritto = new XmlTextReader(nome_file);
                bool fine = false;
                //int i = 1;
                //int j = 1;
                while ((iscritto.Read()) && (fine == false))
                {
                    if (iscritto.NodeType == XmlNodeType.Element)
                    {
                        if (iscritto.LocalName.Equals("NomePannello"))
                        {
                            string righe = iscritto.GetAttribute("TAG_PER_RIGA");
                            string colonne = iscritto.GetAttribute("TAG_PER_COLONNA"); ;
                            tag_per_riga = Int32.Parse(righe);
                            tag_per_colonna = Int32.Parse(colonne);
                            matrice = new Authoring.ElementoGriglia[tag_per_colonna + 1, tag_per_riga + 1];
                            fine = true;

                        }
                    }
                }
                //esiste = true;
            }
            catch
            {
                //esiste = false;
            }

        }

        //Bisogna leggere da questo file perchè in caso di eliminazione dei contenuti è necessario modificare il file xml
        private void LeggiFileDeiComponenti()
        {
            try
            {
                string nome_file = directory_principale + "Griglia" + nome_pannello + id_pannello + configurazione + id_poster.ToString() + ".xml";
                bool esiste = System.IO.File.Exists(nome_file);
                if (esiste == true)
                {
                    //nome_file = directory_principale + "Griglia" + nome_pannello + id_pannello + configurazione + poster.ToString() + ".xml";
                    XmlTextReader iscritto = new XmlTextReader(nome_file);
                    bool fine = false;
                    int i = 1;
                    int j = 1;
                    while ((iscritto.Read()) && (fine == false))
                    {
                        if (iscritto.NodeType == XmlNodeType.Element)
                        {
                            if (iscritto.LocalName.Equals(alfabeto[i - 1].ToString() + j.ToString()))
                            {
                                string id = (String)iscritto.GetAttribute("ID");
                                bool trov = iscritto.ReadToDescendant("IDcontenuto");
                                if (trov == false)
                                {
                                    if (id.CompareTo("Non Usato") != 0)
                                    {
                                        Authoring.ElementoGriglia n = new Authoring.ElementoGriglia(id_pannello, nome_pannello, configurazione, nome_poster, id_poster, -1, null, alfabeto[i - 1].ToString(), j, id, false);
                                        matrice[i, j] = n;
                                        //ElencoTag[i, j].Style.BackColor = Color.Coral;
                                    }
                                    else
                                    {
                                        Authoring.ElementoGriglia n = new Authoring.ElementoGriglia(id_pannello, nome_pannello, configurazione, nome_poster, id_poster, -1, null, alfabeto[i - 1].ToString(), j, id, false);
                                        matrice[i, j] = n;
                                    }
                                }
                                else if (trov == true)
                                {
                                    string id_cont = iscritto.ReadString();
                                    int id1_cont = Int32.Parse(id_cont);
                                    iscritto.ReadToFollowing("NomeContenuto");
                                    string nome_cont = iscritto.ReadString();
                                    Authoring.ElementoGriglia n = new Authoring.ElementoGriglia(id_pannello, nome_pannello, configurazione, nome_poster, id_poster, id1_cont, nome_cont, alfabeto[i - 1].ToString(), j, id, true);
                                    matrice[i, j] = n;
                                    //ElencoTag[i, j].Style.BackColor = Color.Coral;
                                    //ElencoTag[i, j].Value = nome_cont;
                                }
                                j++;
                            }
                        }
                        if (i > tag_per_colonna)
                        {
                            fine = true;

                        }
                        if (j > tag_per_riga)
                        {
                            //fine = true;
                            i++;
                            j = 1;
                        }
                    }
                    iscritto.Close();
                }
                //esiste = true;
            }
            catch
            {
                //esiste = false;
            }
        }

        private void ScriviFileDeiComponenti() {
            try
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.NewLineOnAttributes = true;
                XmlWriter wr = XmlWriter.Create(directory_principale + "Griglia" + nome_pannello + id_pannello + configurazione + id_poster.ToString() + ".xml");
                wr.WriteStartDocument();
                wr.WriteStartElement("GrigliaTaggata");
                wr.WriteStartElement("NomePannello");
                wr.WriteStartAttribute("ID");
                wr.WriteString(id_pannello);
                wr.WriteEndAttribute();
                wr.WriteString(nome_pannello);
                wr.WriteStartElement("Configurazione");
                wr.WriteString(configurazione);
                wr.WriteStartElement("Poster");
                wr.WriteString(id_poster.ToString());
                foreach (Authoring.ElementoGriglia el in matrice)
                {
                    if (el != null)
                    {
                        wr.WriteStartElement(el.getColonna() + el.GetRiga().ToString());
                        wr.WriteStartAttribute("ID");
                        wr.WriteString(el.GetTagContenuto());
                        wr.WriteEndAttribute();
                        if (el.GetUtilizzato() == true)
                        {
                            wr.WriteStartElement("IDcontenuto");
                            wr.WriteString(el.GetIdContenuto().ToString());
                            wr.WriteEndElement();
                            wr.WriteStartElement("NomeContenuto");
                            wr.WriteString(el.GetNomeContenuto());
                            wr.WriteEndElement();
                            wr.WriteStartElement("Utilizzato");
                            wr.WriteString(el.GetUtilizzato().ToString());
                            wr.WriteEndElement();
                        }
                        else
                        {
                            wr.WriteStartElement("Utilizzato");
                            wr.WriteString(el.GetUtilizzato().ToString());
                            wr.WriteEndElement();
                        }
                        wr.WriteEndElement();
                        //wr.WriteStartElement("Configurazione", textBox1.Text);
                    }
                }
                wr.WriteEndElement();
                wr.WriteEndElement();
                wr.WriteEndElement();
                wr.WriteEndElement();
                wr.WriteEndDocument();
                wr.Flush();
                wr.Close();
            }
            catch
            {

            }
        }

        private void Si_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            foreach (Authoring.ElementoGriglia el in matrice)
            {
                if (el!=null){
                    if (el.GetIdContenuto() == id_componente) {
                        el.SetIdContenuto(-1);
                        el.SetNomeContenuto(null);
                        el.SetUtilizzato(false);
                    }
                }
            }
            ScriviFileDeiComponenti();
            using (ISession tempS = nh_manager.Session)
            using (ITransaction tempT = tempS.BeginTransaction())
            {
                try
                {
                    Contenuto con = new Contenuto();
                    int idd_pos;
                    Poster pt = new Poster();
                    IQuery q = tempS.CreateQuery("FROM Contenuto as com WHERE com.IDcontenuto=:Com");
                    q.SetParameter("Com", id_componente);
                    con = (Contenuto)q.List()[0];
                    idd_pos = con.Poster.IDposter;
                    IQuery q16 = tempS.CreateQuery("FROM Poster as pos WHERE pos.IDposter=:Pos");
                    q16.SetParameter("Pos", idd_pos);
                    pt = (Poster)q16.List()[0];
                    pt.ContenutoLista.Remove(con);
                    tempS.Flush();
                    tempS.Update(pt);
                    tempS.Flush();
                    tempS.Delete(con);
                    // tempS.Delete(con);
                    tempT.Commit();
                    tempS.Flush();
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
            ComponentiDelPoster nuovas = new ComponentiDelPoster(benvenuto, poster, id_mostra, id_poster, nome_poster, directory_principale, provenienza, visualizza_aut,id_pannello,nome_pannello,configurazione);
            nuovas.Show();
            componenti_poster.Close();
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void Annulla_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            componenti_poster.Visible = true;
            this.Cursor = Cursors.Default;
            this.Close();
        }
    }
}
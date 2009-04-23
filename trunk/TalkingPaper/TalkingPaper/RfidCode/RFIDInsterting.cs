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


namespace TalkingPaper.RfidCode
{
    public partial class RFIDInsterting : FormSchema
    {
        private FormVisualizzaElementiRFID elenco_elementi;
        private FormScegliPosterRFID scelta_poster;
        private BenvenutoRFID partenza;
        private TalkingPaper.Config.RfidProperties rfid_prop;
        private TalkingPaper.Config.Config_manager rfid_mng;
        private int rfid_num;
        private RFIDConfigurator rfid_cfg;
        private int id_componente;
        private int poster;
        private string nome_poster;
        private int cod_mostra;
        private string directory_principale;
        private string database;
        private Bitmap immagine_modifica_code;
        private Bitmap immagine_code;
        private string oldid;
        //private DataGridView ElencoRisorse;
        //private int riga;
        //private int colonna;
        private NHibernateManager nh_manager;
        private Bitmap taggato;
        private TalkingPaper.Postering.ComponentiDelPoster componenti_pos;
        private TalkingPaper.Postering.BenvenutoPostering benvenuto_pos;
        private TalkingPaper.BarCode.BenvenutoBarCode benvenuto_bar;

                              //FormVisualizzaElementi elenco_elementi,int id_componente,FormScegliPoster scelta_poster,BenvenutoBarCode partenza,int poster,string nome_poster,int cod_mostra,string directory_principale,string database
        public RFIDInsterting(FormVisualizzaElementiRFID elenco_elementi, int id_componente, FormScegliPosterRFID scelta_poster, BenvenutoRFID partenza, int poster, string nome_poster, int cod_mostra, string directory_principale, string database, TalkingPaper.Postering.ComponentiDelPoster componenti_pos,TalkingPaper.Postering.BenvenutoPostering benvenuto_pos,TalkingPaper.BarCode.BenvenutoBarCode benvenuto_bar)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 55, true);
            oldid = " ";
            this.directory_principale = directory_principale;
            rfid_cfg = new RFIDConfigurator();
            rfid_mng = new TalkingPaper.Config.Config_manager(directory_principale + @"\Config\");
            this.elenco_elementi = elenco_elementi;
            this.benvenuto_pos = benvenuto_pos;
            this.componenti_pos = componenti_pos;
            this.id_componente = id_componente;
            this.scelta_poster = scelta_poster;
            this.partenza = partenza;
            this.poster = poster;
            this.nome_poster = nome_poster;
            this.cod_mostra = cod_mostra;
            this.database = database;
            this.benvenuto_bar = benvenuto_bar;
            this.nh_manager = new NHibernateManager();
            immagine_modifica_code = new Bitmap(directory_principale + @"/Images/Icons/SelezionaPannello.gif");
            immagine_code = new Bitmap(directory_principale + @"/Images/Icons/coding.gif");
            taggato = new Bitmap(directory_principale + @"/Images/Icons/virgoletta.gif");

            timer.Interval = 1000;
            timer.Start();
            timer.Tick += new EventHandler(timer_Tick);
            //Suggerimento.Select(0, 0);
            Salva.Cursor = Cursors.Hand;
            Annulla.Cursor = Cursors.Hand;

            if (rfid_mng.exist() == true)
            {
                rfid_prop = rfid_mng.read_config_rfid_xml();
                rfid_num = rfid_cfg.connect(Convert.ToInt32(rfid_prop.PortReader), rfid_prop.ComunicationframeReader,
                    rfid_prop.BaudrateReader, (short)Convert.ToInt16(rfid_prop.TimeoutReader));
                if (rfid_num <= 0)
                {
                    //Qualcosa non ha funzionato, rifare...
                    MessageBox.Show("SONO in costruttore, qualcosa nn ha funzionato...", "ATTENZIONE",
MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    Console.WriteLine("SONO in costruttore di FormEsecuzione, tutto ok");
                }
            }
            else
            {
                Console.WriteLine("Problema nel recupero delle informazioni del RFID");

                /*
                 * Si potrebbe far aprire la Rfid Configurator Form...
                 * */
            }

        }

        private void CodeInsterting_Load(object sender, EventArgs e)
        {
            elenco_elementi.Visible=false;
        }


        #region Gestisci Eventi

        void rfid_StatusUpdateEvent(string id)
        {
            this.textBox1.Text = id;
        }

        private void Annulla_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            elenco_elementi.Visible = true;
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void Salva_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (((textBox1.Text).CompareTo("")) == 0)
            {
                MessageBox.Show("Non hai inserito il codice del tag");
            }
            else
            {
                if (oldid.Equals(textBox1.Text) == false)
                {
                    Contenuto contenuto = new Contenuto();
                    oldid = textBox1.Text;
                    using (ISession tempS = nh_manager.Session)
                    //using (ITransaction tempT = tempS.BeginTransaction())
                    {
                        try
                        {
                            //se esiste già un contenuto con quel tag...
                            IQuery q1 = tempS.CreateQuery("FROM Contenuto as cont WHERE cont.Rfidtag=:content AND cont.Poster.IDposter = :poster");
                            q1.SetParameter("content", textBox1.Text);
                            q1.SetParameter("poster", poster);
                            contenuto = (Contenuto)q1.List()[0];

                            MessageBox.Show("Hai già inserito questo tag per questo poster, nel contenuto\n " + contenuto.Nome);
                            textBox1.Clear();

                        }
                        catch (Exception ex) // se non ci sono elementi, va bene:
                        {

                            try
                            {
                                IQuery q = tempS.CreateQuery("FROM Contenuto as cont WHERE cont.IDcontenuto=:content AND cont.Poster.IDposter = :poster");
                                q.SetParameter("content", id_componente);
                                q.SetParameter("poster", poster);
                                contenuto = (Contenuto)q.List()[0];
                                contenuto.Rfidtag = textBox1.Text;
                                //devo controllare che non sia già stato inserito uno stesso tag per lo stesso poster
                                tempS.Update(contenuto);
                                tempS.Flush();
                                elenco_elementi.Close();
                                FormVisualizzaElementiRFID nuo = new FormVisualizzaElementiRFID(scelta_poster, partenza, poster, nome_poster, cod_mostra, directory_principale, database,componenti_pos,benvenuto_pos,benvenuto_bar);
                                this.Close();
                                nuo.Show();
                                //tempT.Commit();
                            }
                            catch (Exception exc)
                            {
                                MessageBox.Show("Eccez " + exc.Message);
                            }
                        }
                        finally
                        {
                            tempS.Close();
                        }
                    }
                    /*Contenuto contenuto = new Contenuto();
                    using (ISession tempS = nh_manager.Session)
                    using (ITransaction tempT = tempS.BeginTransaction())
                    {
                        try
                        {
                            IQuery q = tempS.CreateQuery("FROM Contenuto as cont WHERE cont.IDcontenuto=:content");
                            q.SetParameter("content", id_componente);
                            contenuto = (Contenuto)q.List()[0];
                            contenuto.Rfidtag = textBox1.Text;
                            tempS.Update(contenuto);
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
                    }*/
                    /* DataGridViewImageCell immagine_codice = new DataGridViewImageCell();
                     if ((textBox1.Text).CompareTo("0") == 0)
                     {
                         immagine_codice.Value = immagine_code;
                     }
                     else
                     {
                         immagine_codice.Value = immagine_modifica_code;
                     }
                     ElencoRisorse[colonna, riga] = immagine_codice;
                     elenco_elementi.Visible = true;
                     this.Close();*/
                    /*elenco_elementi.Close();
                    FormVisualizzaElementiRFID nuo = new FormVisualizzaElementiRFID(scelta_poster, partenza, poster, nome_poster, cod_mostra, directory_principale, database);
                    this.Close();
                    nuo.Show();*/
                }
                else
                {
                    Console.WriteLine("Id già letto, old = " + oldid + " e nuovo " + textBox1.Text);
                }
            }
            this.Cursor = Cursors.Default;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            rfid_cfg.StatusUpdateEvent += new RFIDlibrary.RFIDConfigurator.StatusUpdateDelegate(rfid_StatusUpdateEvent);
            int tag_letto = rfid_cfg.letturaID(rfid_num);
            //Console.WriteLine("In timer_tick, tag_letto = " + tag_letto +"\nvediamo un po'...");
            //this.richTextBox1.Text += "\aciao\r";
            this.textBox1.Focus();
        }
        #endregion  

        private void Annulla_Click_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            elenco_elementi.Visible = true;
            this.Cursor = Cursors.Default;
            this.Close();
        }

        

    }
}
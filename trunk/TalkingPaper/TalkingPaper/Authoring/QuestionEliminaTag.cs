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

namespace TalkingPaper.Authoring
{
    public partial class QuestionEliminaTag : Form
    {
        private FormScegliPosterAuthoring scelta_poster;
        private BenvenutoAuthoring partenza;
        private FormVisualizzaElementiAuthoring elementi;
        private int id_contenuto;
        private int poster;
        private string nome_poster;
        private int cod_mostra;
        private string directory_principale;
        private string database;
        private TalkingPaper.NHibernateManager nh_manager;
        private TalkingPaper.GestioneDisposizione.ComponentiDelPoster componenti_pos;
        private TalkingPaper.GestioneDisposizione.BenvenutoGestioneDisposizione benvenuto_pos;
        private string nome_pannello;
        private string id_pannello;
        private string configurazione;
        private GestioneDisposizione.BenvenutoGestioneDisposizione benvenuto_ges;
        //private TalkingPaper.BarCode.BenvenutoBarCode benvenuto_bar;

        public QuestionEliminaTag(FormVisualizzaElementiAuthoring elementi, int id_contenuto, FormScegliPosterAuthoring scelta_poster, BenvenutoAuthoring partenza, int poster, string nome_poster, int cod_mostra, string directory_principale, string database, TalkingPaper.GestioneDisposizione.ComponentiDelPoster componenti_pos, TalkingPaper.GestioneDisposizione.BenvenutoGestioneDisposizione benvenuto_pos, string id_pannello, string nome_pannello, string configurazione, GestioneDisposizione.BenvenutoGestioneDisposizione benvenuto_ges)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 45, true);
            //this.benvenuto_bar = benvenuto_bar;
            this.componenti_pos = componenti_pos;
            this.configurazione = configurazione;
            this.benvenuto_pos = benvenuto_pos;
            this.id_pannello = id_pannello;
            this.nome_pannello = nome_pannello;
            this.benvenuto_ges = benvenuto_ges;
            this.nh_manager = new NHibernateManager();
            this.elementi = elementi;
            this.id_contenuto = id_contenuto;
            this.scelta_poster = scelta_poster;
            this.partenza = partenza;
            this.poster = poster;
            this.nome_poster = nome_poster;
            this.cod_mostra = cod_mostra;
            this.directory_principale = directory_principale;
            this.database = database;
            Si.Cursor = Cursors.Hand;
            Annulla.Cursor = Cursors.Hand;
        }

        private void QuestionEliminaTag_Load(object sender, EventArgs e)
        {

        }

        private void Si_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            using (ISession tempS = nh_manager.Session)
            using (ITransaction tempT = tempS.BeginTransaction())
            {
                try
                {
                    Contenuto con_sel = new Contenuto();
                    IQuery q = tempS.CreateQuery("FROM Contenuto as count WHERE count.IDcontenuto=:Con");
                    q.SetParameter("Con", id_contenuto);
                    con_sel = (Contenuto)q.List()[0];
                    con_sel.Rfidtag = "0";
                    tempS.Update(con_sel);
                    tempT.Commit();
                    tempS.Flush();
                    elementi.Close();
                    FormVisualizzaElementiAuthoring nuoova = new FormVisualizzaElementiAuthoring(scelta_poster, partenza, poster, nome_poster, cod_mostra, directory_principale, database, componenti_pos, benvenuto_pos,id_pannello,nome_pannello,configurazione,null,benvenuto_ges);
                    this.Close();
                    nuoova.Show();
                }
                catch (Exception ex)
                {
                    tempT.Rollback();
                    Console.WriteLine("Eccezione in Scegli Elementi");
                }
                finally
                {
                    tempS.Close();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void Annulla_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            elementi.Visible = true;
            this.Cursor = Cursors.Default;
            this.Close();
        }


    }
}
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
    public partial class QuestionEliminaTag : Form
    {
        private FormScegliPosterRFID scelta_poster;
        private BenvenutoRFID partenza;
        private FormVisualizzaElementiRFID elementi;
        private int id_contenuto;
        private int poster;
        private string nome_poster;
        private int cod_mostra;
        private string directory_principale;
        private string database;
        private TalkingPaper.NHibernateManager nh_manager;
        private TalkingPaper.Postering.ComponentiDelPoster componenti_pos;
        private TalkingPaper.Postering.BenvenutoPostering benvenuto_pos;
        private TalkingPaper.BarCode.BenvenutoBarCode benvenuto_bar;

        public QuestionEliminaTag(FormVisualizzaElementiRFID elementi, int id_contenuto, FormScegliPosterRFID scelta_poster, BenvenutoRFID partenza, int poster, string nome_poster, int cod_mostra, string directory_principale, string database, TalkingPaper.Postering.ComponentiDelPoster componenti_pos,TalkingPaper.Postering.BenvenutoPostering benvenuto_pos,TalkingPaper.BarCode.BenvenutoBarCode benvenuto_bar)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 45, true);
            this.benvenuto_bar = benvenuto_bar;
            this.componenti_pos = componenti_pos;
            this.benvenuto_pos = benvenuto_pos;
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
                    FormVisualizzaElementiRFID nuoova = new FormVisualizzaElementiRFID(scelta_poster, partenza, poster, nome_poster, cod_mostra, directory_principale, database,componenti_pos,benvenuto_pos,benvenuto_bar);
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
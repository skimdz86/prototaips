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
    public partial class QuestionEliminaComponente : Form
    {
        private ComponentiDelPoster componenti_poster;
        private int id_componente;
        private BenvenutoPostering benvenuto;
        private PosterDellaMostra poster;
        private int id_mostra;
        private int id_poster;
        private string nome_poster;
        private string directory_principale;
        private TalkingPaper.NHibernateManager nh_manager;
        private string provenienza;
        private TalkingPaper.BarCode.BenvenutoBarCode benvenuto_bar;
        private TalkingPaper.RfidCode.BenvenutoRFID benvenuto_rfid;
        private TalkingPaper.BarCode.FormVisualizzaElementi visualizza_bar;
        private TalkingPaper.RfidCode.FormVisualizzaElementiRFID visualizza_rfid;

        public QuestionEliminaComponente(ComponentiDelPoster componenti_poster, int id_componente, BenvenutoPostering benvenuto, PosterDellaMostra poster, int id_mostra, int id_poster, string nome_poster, string directory_principale, string provenienza, TalkingPaper.BarCode.BenvenutoBarCode benvenuto_bar, TalkingPaper.RfidCode.BenvenutoRFID benvenuto_rfid, TalkingPaper.BarCode.FormVisualizzaElementi visualizza_bar, TalkingPaper.RfidCode.FormVisualizzaElementiRFID visualizza_rfid)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 45, true);
            this.visualizza_bar = visualizza_bar;
            this.visualizza_rfid = visualizza_rfid;
            this.provenienza = provenienza;
            this.benvenuto_bar = benvenuto_bar;
            this.benvenuto_rfid = benvenuto_rfid;
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
        }

        private void Si_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
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
            ComponentiDelPoster nuovas = new ComponentiDelPoster(benvenuto, poster, id_mostra, id_poster, nome_poster, directory_principale,provenienza,benvenuto_bar,benvenuto_rfid,visualizza_bar,visualizza_rfid);
            nuovas.Show();
            componenti_poster.Close();
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void Annulla_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            componenti_poster.Visible= true;
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void QuestionEliminaComponente_Load(object sender, EventArgs e)
        {

        }

        private void Si_Click_1(object sender, EventArgs e)
        {

        }

        private void Annulla_Click_1(object sender, EventArgs e)
        {

        }
    }
}
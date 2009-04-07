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
    public partial class QuestionEliminaMostra : Form
    {
        private ScegliMostraPostering elenco_mostre;
        private int id_mostra;
        private BenvenutoPostering benvenuto;
        private string directory_principale;
        private TalkingPaper.BarCode.BenvenutoBarCode benvenuto_bar;
        private TalkingPaper.RfidCode.BenvenutoRFID benvenuto_rfid;
        private TalkingPaper.BarCode.FormVisualizzaElementi visualizza_bar;
        private TalkingPaper.RfidCode.FormVisualizzaElementiRFID visualizza_rfid;
        private TalkingPaper.NHibernateManager nh_manager;

        public QuestionEliminaMostra(ScegliMostraPostering elenco_mostre, int id_mostra, BenvenutoPostering benvenuto, string directory_principale, TalkingPaper.BarCode.BenvenutoBarCode benvenuto_bar, TalkingPaper.RfidCode.BenvenutoRFID benvenuto_rfid, TalkingPaper.BarCode.FormVisualizzaElementi visualizza_bar, TalkingPaper.RfidCode.FormVisualizzaElementiRFID visualizza_rfid)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 45, true);
            this.nh_manager = new NHibernateManager();
            this.benvenuto_bar = benvenuto_bar;
            this.benvenuto_rfid = benvenuto_rfid;
            this.visualizza_bar = visualizza_bar;
            this.visualizza_rfid = visualizza_rfid;
            this.elenco_mostre = elenco_mostre;
            this.id_mostra = id_mostra;
            this.benvenuto = benvenuto;
            this.directory_principale = directory_principale;
            Si.Cursor = Cursors.Hand;
            Annulla.Cursor = Cursors.Hand;
        }

        private void Si_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            using (ISession tempS = nh_manager.Session)
            using (ITransaction tempT = tempS.BeginTransaction())
            {
                try
                {
                    IQuery q = tempS.CreateQuery("FROM Mostra as ms WHERE ms.IDmostra=:Mos");
                    q.SetParameter("Mos", id_mostra);
                    Mostra mostra_sel = new Mostra();
                    mostra_sel = (Mostra)q.List()[0];
                    //tempS.Delete(mostra_sel);
                   /* foreach (Poster p in mostra_sel.PosterLista) {
                        tempS.Delete(p);
                        tempS.Flush();
                    }*/
                    tempS.Delete(mostra_sel);
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
                    ScegliMostraPostering nuovaaa = new ScegliMostraPostering(benvenuto, directory_principale,benvenuto_bar,benvenuto_rfid,visualizza_bar,visualizza_rfid,null);
                    elenco_mostre.Close();
                    nuovaaa.Show();
                    this.Cursor = Cursors.Default;
                    this.Close();
                    //nuovaaa.Show();
                }
            }
        }

        private void Annulla_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //this.Close();
            elenco_mostre.Visible = true;
            this.Cursor = Cursors.Default;
            this.Close();
        }



        private void Si_Click_1(object sender, EventArgs e)
        {

        }

        private void Annulla_Click_1(object sender, EventArgs e)
        {

        }
    }
}
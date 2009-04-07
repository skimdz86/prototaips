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
    public partial class QuestionPosterTaggato : Form
    {
        private BenvenutoPostering benvenuto;
        private ComponentiDelPoster componenti;
        private int id_poster;
        private PosterDellaMostra poster;
        private string directory_principale;
        private AggiungiPosterAMostra aggiungi;
        private int id_mostra;
        private TalkingPaper.NHibernateManager nh_manager;

        public QuestionPosterTaggato(BenvenutoPostering benvenuto,AggiungiPosterAMostra aggiungi,ComponentiDelPoster componenti,int id_poster,int id_mostra,PosterDellaMostra poster, string directory_principale)
        {
            InitializeComponent();
            this.benvenuto = benvenuto;
            this.componenti = componenti;
            this.id_poster = id_poster;
            this.poster = poster;
            this.id_mostra = id_mostra;
            this.directory_principale = directory_principale;
            this.aggiungi = aggiungi;
            this.nh_manager = new NHibernateManager();
        }

        private void QuestionPosterTaggato_Load(object sender, EventArgs e)
        {

        }

        private void Si_Click(object sender, EventArgs e)
        {
            using (ISession tempS = nh_manager.Session)
            using (ITransaction tempT = tempS.BeginTransaction())
            {
                try
                {
                    //ArrayList id_mostre = new ArrayList();
                    Mostra mostra_sel = new Mostra();
                    Poster poster_sel = new Poster();
                    //IList mostre;
                    IQuery q = tempS.CreateQuery("FROM Mostra as ms WHERE ms.IDmostra=:Mos");
                    //string mostre;
                    q.SetParameter("Mos", id_mostra);
                    mostra_sel = (Mostra)q.List()[0];
                    tempS.Flush();
                    IQuery q2 = tempS.CreateQuery("FROM Poster as pt WHERE pt.IDposter=:Pos");
                    //string mostre;
                    q2.SetParameter("Pos", id_poster);
                    poster_sel = (Poster)q2.List()[0];
                    tempS.Flush();
                    poster_sel.Mostra = mostra_sel;
                    foreach (Contenuto c in poster_sel.ContenutoLista) {
                        c.Barcode = "0";
                        c.Rfidtag = "0";
                    }
                    tempS.Update(poster_sel);
                    tempT.Commit();
                    tempS.Flush();
                    //componenti.Close();
                    //this.Close();
                    //poster.Close();
                    //PosterDellaMostra nuova = new PosterDellaMostra(benvenuto, null, -1, null, directory_principale);
                    //nuova.Show();
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
            PosterDellaMostra nuova = new PosterDellaMostra(benvenuto, null, -1, null, directory_principale,null,null,null,null);
            this.Close();
            componenti.Close();
            poster.Close();
            nuova.Show();
            
        }

        private void Annulla_Click(object sender, EventArgs e)
        {
            aggiungi.Visible = true;
            this.Close();
        }

    }
}
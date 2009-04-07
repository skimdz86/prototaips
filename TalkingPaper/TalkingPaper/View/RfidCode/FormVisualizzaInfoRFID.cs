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
    public partial class FormVisualizzaInfoRFID : FormSchema
    {
        private FormVisualizzaElementiRFID visualizza_elementi;
        private int id_contenuto;
        private string directoryprincipale;
        private string descrizione;
        private string descrizione_tipologia;
        private string tipologia;
        private string nome_risorsa;
        private string path_risorsa;
        private string esetensione_risorsa;
        private string database;
        private TalkingPaper.NHibernateManager nh_manager;
        private IList contenuti_sel;
        private Contenuto contenuto_sel;
        
        public FormVisualizzaInfoRFID(FormVisualizzaElementiRFID visualizza_elementi, int id_contenuto, string directoryprincipale, string database)
        {
            InitializeComponent();
            this.visualizza_elementi = visualizza_elementi;
            this.id_contenuto = id_contenuto;
            this.directoryprincipale = directoryprincipale;
            this.database = database;
            this.nh_manager = new NHibernateManager();
        }

        private void FormVisualizzaInfo_Load(object sender, EventArgs e)
        {
            InterrogaDB();
        }

        #region Connessione al DB e Riempimento TextBox

        private void InterrogaDB(){

            using (ISession tempS = nh_manager.Session)
            using (ITransaction tempT = tempS.BeginTransaction())
            {
                try
                {
                    IQuery q = tempS.CreateQuery("FROM Contenuto as cont WHERE cont.IDcontenuto=:Cont");
                    q.SetParameter("Cont", id_contenuto);
                    contenuto_sel = (Contenuto)q.List()[0];
                    if (contenuto_sel==null)
                    {
                        MessageBox.Show("Non è presente nessuna informazione");
                        visualizza_elementi.Enabled = true;
                        this.Close();
                    }
                    else
                    {
                        descrizione = contenuto_sel.Nome;
                        descrizione_tipologia = contenuto_sel.Tipo.Descrizione;
                        tipologia = contenuto_sel.Tipo.Tipo;
                        nome_risorsa = contenuto_sel.RisorsaMultimediale.Nome;
                        path_risorsa = contenuto_sel.RisorsaMultimediale.Path;
                        esetensione_risorsa = contenuto_sel.RisorsaMultimediale.Estensione;
                        RiempiTextBox();
                    }
                    tempT.Commit();
                }
                catch (Exception e)
                {
                    tempT.Rollback();
                    Console.WriteLine("Eccezione in Visualizza Informazioni");
                }
                finally
                {
                    tempS.Close();
                }
            }
        }

        private void RiempiTextBox() {
            textBox1.Text = descrizione;
            textBox2.Text = tipologia;
            textBox3.Text = nome_risorsa;
            textBox4.Text = esetensione_risorsa;
            textBox5.Text = path_risorsa;
        }



        #endregion

        private void OK_Click(object sender, EventArgs e)
        {
            visualizza_elementi.Visible = true;
            this.Close();
        }

        
    }
}
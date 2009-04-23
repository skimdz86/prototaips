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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using RFIDlibrary;
using NHibernate;
using NHibernate.Cfg;
using QuartzTypeLib;
using System.Xml;


namespace TalkingPaper.Authoring
{
    public partial class FormScegliPosterAuthoring : FormSchema
    {
        private string directoryprincipale;
        private ScegliMostraAuthoring FormMostre;
        private BenvenutoAuthoring partenza;
        private int cod_mostra;
        private string nome_mostra;
        private string autore_mostra;
        private string database;
        private ArrayList poster;
        //private Bitmap image;
        private Bitmap immagine_modifica_poster;
        private TalkingPaper.NHibernateManager nh_manager;
        private IList poster_sel;
        private Mostra mostra_sel;
        private ArrayList poster_authoring = new ArrayList();
        private GestioneDisposizione.BenvenutoGestioneDisposizione benvenuto_ges;


        public FormScegliPosterAuthoring(ScegliMostraAuthoring FormMostre, BenvenutoAuthoring partenza, int cod_mostra, string nome_mostra, string autore_mostra, string directory_principale, string database,GestioneDisposizione.BenvenutoGestioneDisposizione benvenuto_ges)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 90, true);
            this.FormMostre = FormMostre;
            this.partenza = partenza;
            this.cod_mostra = cod_mostra;
            this.nome_mostra = nome_mostra;
            this.autore_mostra = autore_mostra;
            this.directoryprincipale = directory_principale;
            this.database = database;
            this.benvenuto_ges = benvenuto_ges;
            this.nh_manager = new NHibernateManager();
            if (nome_mostra != null)
            {
                this.sottotitolo.Text = this.sottotitolo.Text + " della tua mostra " + nome_mostra;
            }
            else {
                this.sottotitolo.Text = this.sottotitolo.Text;
            }
            //image = new Bitmap(directoryprincipale + @"/Images/Icons/SelezionaPannello2.gif");
            immagine_modifica_poster = new Bitmap(directory_principale + @"/Images/Icons/modifica3.gif");
            //textBox1.Select(0,0);
            Indietro.Cursor = Cursors.Hand;
            LeggiPosterCreati();
            if (poster_authoring.Count == 0)
            {
                ElencoPoster.Visible = false;
                label1.Visible = true;
            }
            else {
                ElencoPoster.Visible = true;
                label1.Visible = false;
            }
            InterrogaDB();
        }

        private void FormScegliPoster_Load(object sender, EventArgs e)
        {
            //InterrogaDB();
        }

        #region Connessione al DB e DataGrid

        private void LeggiPosterCreati()
        {
            try
            {
                XmlTextReader iscritto = new XmlTextReader(directoryprincipale + "PosterAuthoring" + ".xml");
                //bool fine = false;
                while ((iscritto.Read()))
                {
                    if (iscritto.NodeType == XmlNodeType.Element)
                    {
                        if (iscritto.LocalName.Equals("IDposter"))
                        {
                            //string id = (String)iscritto.GetAttribute("ID");
                            string ins = (string)iscritto.ReadString();
                            //string id = (String)iscritto.GetAttribute("ID");
                            poster_authoring.Add(ins);
                            //pannelli.Add(id);
                        }
                        if (iscritto.LocalName.Equals("IDpannello"))
                        {
                            //string id = (String)iscritto.GetAttribute("ID");
                            string ins = (string)iscritto.ReadString();
                            //string id = (String)iscritto.GetAttribute("ID");
                            poster_authoring.Add(ins);
                            //pannelli.Add(id);
                        }
                        if (iscritto.LocalName.Equals("NomePannello"))
                        {
                            //string id = (String)iscritto.GetAttribute("ID");
                            string ins = (string)iscritto.ReadString();
                            //string id = (String)iscritto.GetAttribute("ID");
                            poster_authoring.Add(ins);
                            //pannelli.Add(id);
                        }
                        if (iscritto.LocalName.Equals("Configurazione"))
                        {
                            //string id = (String)iscritto.GetAttribute("ID");
                            string ins = (string)iscritto.ReadString();
                            //string id = (String)iscritto.GetAttribute("ID");
                            poster_authoring.Add(ins);
                            //pannelli.Add(id);
                        }
                    }
                }
                iscritto.Close();
            }
            catch
            {

            }
        }
        
        
        // connessione al DB e letture dei dati
        private void InterrogaDB()
        {
            using (ISession tempS = nh_manager.Session)
            using (ITransaction tempT = tempS.BeginTransaction())
            {
                if (cod_mostra != -1)
                {
                    try
                    {
                        IQuery q = tempS.CreateQuery("FROM Mostra as ms WHERE ms.IDmostra=:Mos");
                        q.SetParameter("Mos", cod_mostra);
                        mostra_sel = (Mostra)q.List()[0];
                        poster_sel = mostra_sel.PosterLista;
                        if (poster_sel.Count == 0)
                        {
                            MessageBox.Show("Non è presente nessuna mostra");
                            partenza.Enabled = true;
                            this.Close();
                        }
                        else
                        {
                            poster = new ArrayList();
                            foreach (Poster m in poster_sel)
                            {
                                poster.Add(m.IDposter);
                                poster.Add(m.Nome);
                                poster.Add(m.Descrizione);
                                poster.Add(m.Ordine);
                            }
                            SetDataGrid();
                        }
                        tempT.Commit();
                    }
                    catch (Exception e)
                    {
                        tempT.Rollback();
                        Console.WriteLine("Eccezione in Scegli Mostra");
                    }
                    finally
                    {
                        tempS.Close();
                    }
                }
                else
                {
                    try
                    {
                        IQuery q = tempS.CreateQuery("FROM Poster as pt");
                        //q.SetParameter("Mos", cod_mostra);
                        poster_sel = q.List();
                        //poster_sel = mostra_sel.PosterLista;
                        if (poster_sel.Count == 0)
                        {
                            MessageBox.Show("Non è presente nessuna mostra");
                            partenza.Enabled = true;
                            this.Close();
                        }
                        else
                        {
                            poster = new ArrayList();
                            foreach (Poster m in poster_sel)
                            {
                                try
                                {
                                    int nuova = (int)m.Mostra.IDmostra;
                                }
                                catch (Exception e)
                                {
                                    poster.Add(m.IDposter);
                                    poster.Add(m.Nome);
                                    poster.Add(m.Descrizione);
                                    poster.Add(m.Ordine);
                                }
                            }
                            SetDataGrid();
                        }
                        tempT.Commit();
                    }
                    catch (Exception e)
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
        }

        // Inizializzazione della DataGrid
        private void SetDataGrid()
        {
            ElencoPoster.ColumnCount = 11;
            ElencoPoster.ColumnHeadersVisible = false;
            ElencoPoster.Columns[0].Visible = false;
            ElencoPoster.Columns[10].Visible = false;
            DataGridViewRow riga = new DataGridViewRow();
            ElencoPoster.Rows.Add("NUMERO", "  ", "NOME", "  ", "DESCRIZIONE", "  ","PANNELLO","  ","CONFIGURAZIONE", "VISUALIZZA COMPONENTI","  ");
            ElencoPoster.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
            ElencoPoster.Rows.Add();
            ElencoPoster.CellClick += new DataGridViewCellEventHandler(this.ClickSullaTabella);
            ElencoPoster.CellMouseEnter += new DataGridViewCellEventHandler(ElencoPoster_CellMouseEnter);
            RiempiDataGrid();
        }



        // Riempimento della DataGrid
        private void RiempiDataGrid()
        {
            int riga = 2;
            for (int i = 0; i < poster.Count; i = i + 4)
            {
                for (int j = 0; j < poster_authoring.Count; j=j+4)
                {
                    if ((Int32.Parse((string)poster_authoring[j])) == (int)poster[i])
                    {
                        DataGridViewImageCell modify = new DataGridViewImageCell();
                        modify.Value = immagine_modifica_poster;
                        modify.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        ElencoPoster.Rows.Add((int)poster[i], null, (String)poster[i + 1], null, (String)poster[i + 2], null,(string)poster_authoring[j+2], null,(string)poster_authoring[j+3],null,(string)poster_authoring[j+1]);
                        ElencoPoster[9, riga] = modify;
                        ElencoPoster.Rows.Add();
                        riga += 2;
                    }
                }
            }

        }
        #endregion

        #region gestione eventi

        // gestore degli eventi sulla DataGrid
        private void ElencoPoster_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((ElencoPoster[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 9))
            {
                ElencoPoster.Cursor = Cursors.Hand;
            }
            else
                ElencoPoster.Cursor = Cursors.Default;
        }

        private void ClickSullaTabella(object sender, DataGridViewCellEventArgs e)
        {
            if ((ElencoPoster[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 9))
            {
                //this.Visible = false;
                this.Cursor = Cursors.WaitCursor;
                //FormVisualizzaElementiAuthoring nuova = new FormVisualizzaElementiAuthoring(this, partenza, (int)ElencoPoster[0, e.RowIndex].Value, (string)ElencoPoster[2, e.RowIndex].Value, cod_mostra, directoryprincipale, database, null, null);
                FormVisualizzaElementiAuthoring nuova = new FormVisualizzaElementiAuthoring(this, partenza, (int)ElencoPoster[0, e.RowIndex].Value, (string)ElencoPoster[2, e.RowIndex].Value, cod_mostra, directoryprincipale, database, null, null, (string)ElencoPoster[10, e.RowIndex].Value, (string)ElencoPoster[6, e.RowIndex].Value, (string)ElencoPoster[8, e.RowIndex].Value, null, benvenuto_ges);
                //IDataAdapter,nome_mostra,cong
                //FormScegliConfigurazione nuova = new FormScegliConfigurazione(partenza;
                nuova.Show();
                this.Cursor = Cursors.Default;
                this.Visible = false;
            }
        }

        private void Indietro_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (FormMostre != null)
            {
                FormMostre.Visible = true;
            }
            else if (partenza != null)
            {
                partenza.Visible = true;
            }
            else if (benvenuto_ges!=null){
                benvenuto_ges.Visible = true;
            }
            this.Cursor = Cursors.Default;
            this.Close();
        }
        #endregion


        private void FormScegliPosterAuthoring_Load(object sender, EventArgs e)
        {

        }

        private void Menu_Click(object sender, EventArgs e)
        {
            QuestionCambiaGriglia richiesta = new QuestionCambiaGriglia(partenza, global.home);
            richiesta.Show();
            this.Cursor = Cursors.Default;
            this.Visible = false;
        }
    }
}
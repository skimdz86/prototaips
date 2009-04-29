using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Collections;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using NHibernate;
using NHibernate.Cfg;
using System.Xml;


namespace TalkingPaper
{
    public partial class ElencoPosterEsecuzioneSingoloModello : FormSchema
    {
        private string directoryprincipale;
        ///private TalkingPaper.RfidCode.ScegliMostraRFID FormMostre;
        private Welcome partenza;
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
        private string bar_rfid;
        private ArrayList poster_authoring = new ArrayList();




        public ElencoPosterEsecuzioneSingoloModello(/*TalkingPaper.RfidCode.ScegliMostraRFID FormMostre,*/ Welcome partenza, int cod_mostra, string nome_mostra, string autore_mostra, string directory_principale, string database, string bar_rfid)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 90, true);
            ///this.FormMostre = FormMostre;
            this.partenza = partenza;
            this.cod_mostra = cod_mostra;
            this.nome_mostra = nome_mostra;
            this.autore_mostra = autore_mostra;
            this.directoryprincipale = directory_principale;
            this.database = database;
            this.bar_rfid = bar_rfid;
            this.nh_manager = new NHibernateManager();
            Indietro.Cursor = Cursors.Hand;
            if (nome_mostra != null)
                this.sottotitolo.Text = this.sottotitolo + " della mostra " + nome_mostra;
            else
                this.sottotitolo.Text = "Ecco il tuoi poster";
            
            //image = new Bitmap(directoryprincipale + @"/Images/Icons/SelezionaPannello2.gif");
            immagine_modifica_poster = new Bitmap(directory_principale + @"/Images/Icons/modifica3.gif");
            //textBox1.Select(0, 0);
            InterrogaDB();
        }

        private void ElencoPosterEsecuzioneSingolo_Load(object sender, EventArgs e)
        {
            //InterrogaDB();
        }

        private void LetturaPosterAuthoring()
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
                    }
                }
                iscritto.Close();
            }
            catch
            {
            }
        }

        #region Connessione al DB e DataGrid

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
                    LetturaPosterAuthoring();
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
                                    bool tr = false;
                                    for (int i = 0; i < poster_authoring.Count; i++)
                                    {
                                        if (Int32.Parse(((string)poster_authoring[i])) == m.IDposter)
                                        {
                                            tr = true;
                                        }
                                    }
                                    if (tr == true)
                                    {
                                        poster.Add(m.IDposter);
                                        poster.Add(m.Nome);
                                        poster.Add(m.Descrizione);
                                        poster.Add(m.Ordine);
                                    }
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
            ElencoPoster.ColumnCount = 7;
            ElencoPoster.ColumnHeadersVisible = false;
            ElencoPoster.Columns[0].Visible = false;
            DataGridViewRow riga = new DataGridViewRow();
            ElencoPoster.Rows.Add("NUMERO", "  ", "NOME", "  ", "DESCRIZIONE", "  ", "ESEGUI");
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
                DataGridViewImageCell modify = new DataGridViewImageCell();
                modify.Value = immagine_modifica_poster;
                modify.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                ElencoPoster.Rows.Add((int)poster[i], null, (String)poster[i + 1], null, (String)poster[i + 2], null, null);
                ElencoPoster[6, riga] = modify;
                ElencoPoster.Rows.Add();
                riga += 2;
            }

        }
        #endregion

        #region gestione eventi

        // gestore degli eventi sulla DataGrid
        private void ClickSullaTabella(object sender, DataGridViewCellEventArgs e)
        {
            if ((ElencoPoster[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex == 6))
            {
                /*this.Visible = false;
                FormVisualizzaElementiRFID nuova = new FormVisualizzaElementiRFID(this, partenza, (int)ElencoPoster[0, e.RowIndex].Value, (string)ElencoPoster[2, e.RowIndex].Value, cod_mostra, directoryprincipale, database);
                nuova.Show();*/
                
                    //this.Close();
                    //try
                    {
                        FormEsecuzioneRfidPoster n = new FormEsecuzioneRfidPoster((int)ElencoPoster[0, e.RowIndex].Value, partenza,directoryprincipale);
                        n.Show();
                        this.Close();
                        
                    }
                    /*catch
                    {
                        this.Close();
                        partenza.Close();
                    }*/
                
            }
        }

        private void ElencoPoster_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 6))
            {
                if (ElencoPoster[e.ColumnIndex, e.RowIndex].Value != null)
                {
                    ElencoPoster.Cursor = Cursors.Hand;
                }
                else
                    ElencoPoster.Cursor = Cursors.Default;
            }
            else
                ElencoPoster.Cursor = Cursors.Default;
        }

        private void Indietro_Click(object sender, EventArgs e)
        {
            /*if (FormMostre != null)
            {
                FormMostre.Visible = true;
            }
            else
            {*/
                partenza.Visible = true;
            //}
            this.Close();
        }
        #endregion

        private void Indietro_Click_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            partenza.Visible = true;
            this.Cursor = Cursors.Default;
            this.Close();
            //this.Cursor = Cursors.Default;
        }
        private void Indietro_Click_2(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            partenza.Visible = true;
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //add by mac
            if (pictureBoxPost2.Visible = true)
            {
                pictureBoxPost2.Visible = false;
                textBoxPost.Visible = false;
            }
            else
            {
                pictureBoxPost2.Visible = true;
                textBoxPost.Visible = true;
            }

        }
    }
}

/*namespace TalkingPaper
{
    public partial class ElencoPosterEsecuzioneSingolo : FormSchema
    {
        public ElencoPosterEsecuzioneSingolo()
        {
            InitializeComponent();
        }

        private void ElencoPosterEsecuzioneSingolo_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}*/
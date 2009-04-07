using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NHibernate;
using NHibernate.Cfg;

namespace TalkingPaper
{
    public partial class FormStartEsecuzione : FormSchema
    {
        private NHibernateManager nh_mng;
        private Poster poster_current;
        private int cod;

        public FormStartEsecuzione()
        {
            InitializeComponent();
            nh_mng = new NHibernateManager();
            poster_current = new Poster();
            cod = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (ISession tempS = nh_mng.Session)
            {
                try
                {
                    IQuery q = tempS.CreateQuery(
     "from Poster as post");

                    poster_current = (Poster)q.List()[0];
                    //tempT.Commit();
                    Console.WriteLine("Query di ricerca Contenuto by id ok, commit");
                    cod = poster_current.IDposter;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    tempS.Close();
                }

                //FormEsecuzioneRfidPoster nuova = new FormEsecuzioneRfidPoster(cod);
                Welcome n= new Welcome(null);
                FormEsecuzioneBarcodePoster nuova = new FormEsecuzioneBarcodePoster(cod,n);
                //FormEsecuzioneRfidPoster nuova = new FormEsecuzioneRfidPoster(2);
                nuova.Show();
            }
        }


    }
}
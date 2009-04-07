using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NHibernate;
using NHibernate.Cfg;
using System.Collections;
using log4net;


namespace TalkingPaper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //Prova di utilizzo di NHibernate

            //Uso il NHibernateManager...
            //try
            //{
                NHibernateManager mgr = new NHibernateManager();

            try
            {
                
               using (mgr.Session)
                {

                Console.WriteLine("Provo a leggere l'intera tabella dei poster");
                //Interrogo l'intera tabella del db
                IList posterList = mgr.Session.CreateCriteria(typeof(Poster)).List();
                foreach (Poster p in posterList)
                {
                    System.Diagnostics.Debug.WriteLine("Ecco il poster " + p.IDposter + ",  " + p.Descrizione);
                    
                }

                IList mostraList = mgr.Session.CreateCriteria(typeof(Mostra)).List();
                foreach (Mostra m in mostraList)
                {
                    System.Diagnostics.Debug.WriteLine("Ecco la mostra" + m.IDmostra + " nome " + m.Nome + " di autore" + m.Autore);
                    IList a1 = m.PosterLista;

                    foreach (Poster p1 in a1)
                    {
                        System.Diagnostics.Debug.WriteLine("Ecco il poster " + p1.Descrizione + " di numero " + p1.Ordine + "della mostra M " + m.Nome);
                    }

                }
                mgr.Session.Flush();
                mgr.Session.Close();
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
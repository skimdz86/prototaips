using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace TalkingPaper
{
    public partial class FormProvaNH3 : FormSchema
    {
        public FormProvaNH3()
        {
            InitializeComponent();

            //Prova di utilizzo di NHibernate

            //Uso il NHibernateManager...NON va bene, mi perde la session...
            try
            {
                NHibernateManager mgr = new NHibernateManager();

                IList posterList = mgr.get_posters();

                Console.WriteLine("Provo a leggere l'intera tabella dei poster");
                //Interrogo l'intera tabella del db
                foreach (Poster p in posterList)
                {
                    System.Diagnostics.Debug.WriteLine("Ecco il poster " + p.IDposter + ",  " + p.Descrizione);
                }

                Console.WriteLine("Provo a leggere l'intera tabella delle MOstre, con relativi poster");
                IList mostraList = mgr.get_mostre();

                foreach (Mostra m in mostraList)
                {
                    System.Diagnostics.Debug.WriteLine("Ecco la mostra" + m.IDmostra + " nome " + m.Nome + " di autore" + m.Autore);
                    IList a1 = m.PosterLista;

                    foreach (Poster p1 in a1)
                    {
                        System.Diagnostics.Debug.WriteLine("Ecco il poster " + p1.Descrizione + " di numero " + p1.Ordine + "della mostra M " + m.Nome);
                    }
                }
               
            }catch(Exception ex)
            {
                Console.WriteLine("Errore di tipo:\n" + ex.Message);
                MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
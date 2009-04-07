using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using log4net;
using NHibernate;
using NHibernate.Cfg;
using System.Collections;
using System.IO;

namespace TalkingPaper
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            /**
             * Prove per recuperare la directory
             * */

            MessageBox.Show("Directory"+Directory.GetCurrentDirectory());
            // ----------------------------------------
            // Step 1: log4net configuration (optional)
            // ----------------------------------------
            //
            // The first step is to configure log4net, an open source logging
            // framework that can be found at http://logging.apache.org/log4net/.
            // NHibernate uses log4net to output warnings, debug messages, etc.
            // It is strongly recommended that you enable log4net when
            // troubleshooting your application with NHibernate.
            //
            // The statement below instructs log4net to configure itself
            // by loading its settings from the application configuration file.
            // See app.config for more details; however, it is beyond the scope
            // of this sample to discuss log4net in detail.  Refer to the
            // above web site to learn more.
            //
            // This particular sample is configured to write to a log file
            // called log-file.txt.  It will be created in the same folder
            // as the executable.

            log4net.Config.XmlConfigurator.Configure();


            // ---------------------
            // Step 2: Configuration
            // ---------------------
            //
            // A Configuration object manages global settings as well as
            // the mappings between your classes and the database.  You
            // will always create a Configuration object.

            Configuration configuration = new Configuration();

            // The Configure method (without parameters) instructs NHibernate
            // to look for its configuration from app.config.  If no
            // configuration can be found, it then looks for an XML file
            // with the name hibernate.cfg.xml.  This sample uses the XML
            // file instead of app.config.
            //
            // Note: hibernate.cfg.xml has been added as a content file to
            // this project.  The file is configured to be copied to the
            // output folder (check the Copy to Output Directory property
            // of the file from the Solution Explorer panel).

            Console.WriteLine("Loading hibernate.cfg.xml...");
            configuration.Configure();

            // The next step is to load and parse all of the files that
            // define the mappings between your objects and the underlying
            // database.  There are many ways to do this (refer to the
            // NHibernate documentation).  The technique below instructs
            // NHibernate to search for all mapping files that have
            // been embedded in the assembly.

            Console.WriteLine("Loading mapping files in this executable...");
            //configuration.AddAssembly(System.Reflection.Assembly.GetExecutingAssembly());


            // --------------------------------
            // Step 3: Create a Session Factory
            // --------------------------------
            //
            // An ISessionFactory is used to create NHibernate sessions.  A 
            // session represents a connection to the database with all of
            // the functionality provided by NHibernate.  

            ISessionFactory factory = configuration.BuildSessionFactory();
            using (ISession session = factory.OpenSession())
            {
                Console.WriteLine("Provo a leggere l'intera tabella dei poster");
                //Interrogo l'intera tabella del db
                IList posterList = session.CreateCriteria(typeof(Poster)).List();
                foreach (Poster p in posterList)
                {
                    System.Diagnostics.Debug.WriteLine("Ecco il poster " + p.IDposter+ " di numero " + p.Ordine);

                }

                IList mostraList = session.CreateCriteria(typeof(Mostra)).List();
                foreach (Mostra m in mostraList)
                {
                    System.Diagnostics.Debug.WriteLine("Ecco la mostra"+ m.IDmostra + " nome " + m.Nome +" di autore" + m.Autore);
                    IList a1 = m.PosterLista;

                    foreach (Poster p1 in a1)
                    {
                        System.Diagnostics.Debug.WriteLine("Ecco il poster " + p1.Descrizione + " di numero " + p1.Ordine +"della mostra M " + m.Nome);
                    }

                }


            }


            Console.WriteLine("Fine form2, x il momento..");
        }
    }
}
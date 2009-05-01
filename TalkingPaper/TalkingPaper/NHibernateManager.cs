using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using System.Collections;

namespace TalkingPaper
{
    /**
     * Si può utilizzare qst classe per gestire tutto ciò che riguarda NH
     *  - configurazione e utilizzo delle sessioni ( e delle transazioni???? )
     *  - si potrebbero creare delle speci di Wrapper per il gli oggetti memorizzati, 
     *      in cui si espongono i metodi che servono, si scrivono qua tutte le query in HQL, 
     *      così tutte le cose che riguardano HQL sono solo in questa classe.
     * 
     * */
    class NHibernateManager
    {
        public static Configuration configuration;
        public static ISessionFactory factory;
        //public ITransaction transaction;
        private ISession session;


        public ISession Session
        {
            get
            {
                if (session == null || !session.IsOpen)
                {
                    try
                    {
                        session = factory.OpenSession();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Session open error");
                        throw new Exception("The session or the database could not be created\n" + e);
                    }

                    Console.WriteLine("Session open succesfully");
                    return session;
                }
                return session;
            }
        }//fine Isession
        
        public  NHibernateManager()
        {
            try
            {
                // ---------------------
                // Configuration
                // ---------------------
                //
                // A Configuration object manages global settings as well as
                // the mappings between your classes and the database.  You
                // will always create a Configuration object.

                configuration = new Configuration();

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

                //Console.WriteLine("Loading mapping files in this executable...");
                //configuration.AddAssembly(System.Reflection.Assembly.GetExecutingAssembly());

                // --------------------------------
                // Create a Session Factory
                // --------------------------------
                //
                // An ISessionFactory is used to create NHibernate sessions.  A 
                // session represents a connection to the database with all of
                // the functionality provided by NHibernate.  

                factory = configuration.BuildSessionFactory();

            }
            catch (Exception ex)
            {
                throw new Exception("Could not create the NHibernate configuration", ex);

            }
        }//fine costruttore




        //dovrei fare i metodi che wrappano i vari oggetti, magari usando le ITransaction...

        #region Poster

        /// <summary>
        /// This function allow to take all the posters
        /// </summary>
        /// <returns>the works</returns>
        public IList get_posters()
        {
            //sFactory = cfg.ConfigNHibernate(cfg.pConfig.DriverDb);
            IList result = null;

            using (ISession tempS = factory.OpenSession())
            using (ITransaction tempT = tempS.BeginTransaction())
            {
                try
                {
                    IQuery q = tempS.CreateQuery(
                    "select poster " +
                    "from Poster as poster "
                        );
                    result = q.List();
                    tempT.Commit();
                    Console.WriteLine("Query di get_posters eseguita, commit");
                }
                catch (Exception ex)
                {

                    tempT.Rollback();
                    Console.WriteLine("Query di get_posters abortita, rollback.\nMessage = " + ex.Message);
                    throw new Exception("Query di get_posters non riuscita\n", ex);
                }
                finally
                {
                    tempS.Close();
                }
            }
            return result;
        }

        /// <summary>
        /// This function allow to modify the name of a Poster
        /// </summary>
        /// <param name="id">the id of the poster</param>
        public void update_poster(int id , string new_nome)
        {
            Poster3 selected_poster = null;

            using (ISession tempS = factory.OpenSession())
            using (ITransaction tempT = tempS.BeginTransaction())
            {
                try
                {
                    //carica il poster
                    IQuery q = tempS.CreateQuery(
                        "from Poster as poster " +
                        "where poster.IDposter = :id"
                        );
                    q.SetParameter("id", id);
                    selected_poster = (Poster3)q.List()[0];
              
                    selected_poster.Nome = new_nome;

                    tempS.Flush();
                    tempT.Commit();
                    Console.WriteLine("Query di update_poster eseguita, commit");

                }
                catch (Exception ex)
                {
                    tempT.Rollback();
                    Console.WriteLine("Query di update_poster NON eseguita, ROLLBACK");
                    throw new Exception("Query di update_poster non riuscita\n",ex );
                }
                finally
                {
                    tempS.Close();
                }
            }
        }

        /// <summary>
        /// This function allow to delete a Poster
        /// </summary>
        /// <param name="id">the key-id of the Poster</param>
            public void delete_poster( int id ){
            Poster3 selected_poster = null;

            using (ISession tempS = factory.OpenSession())
            using (ITransaction tempT = tempS.BeginTransaction())
            {
                try
                {
                    //carica il poster
                    IQuery q = tempS.CreateQuery(
                        "from Poster as poster " +
                        "where poster.IDposter = :id"
                        );
                    q.SetParameter("id", id);
                    selected_poster = (Poster3)q.List()[0];

                    tempS.Delete(selected_poster);
                    tempS.Flush();
                    tempT.Commit();
                    Console.WriteLine("Query di delete_poster eseguita, commit");

                }
                catch (Exception ex)
                {
                    tempT.Rollback();
                    Console.WriteLine("Query di delete_poster NON eseguita, ROLLBACK");
                    throw new Exception("Query di delete_poster non riuscita\n",ex );
                }
                finally
                {
                    tempS.Close();
                }
            }
        }

        /// <summary>
        /// This function allow to insert a new poster
        /// </summary>
        /// <param name="RFid"></param>
        /// <param name="name"></param>
        //public Work new_poster(string )
        //



        #endregion 

        #region Contenuto




        #endregion

        #region Risorsamultimediale

        public Risorsamultimediale get_risorsa_by_rfid( string rfid)
        {
            /**
             * Da controllare se la query va bene, o se bisogna poi aggiornare anche altre cose..vd frambi e 
             *  la parte su Attribute...
             * */
            Risorsamultimediale ris = null;

            using (ISession tempS = factory.OpenSession())
            using (ITransaction tempT = tempS.BeginTransaction())
            {
                try
                {
                    
                    IQuery q = tempS.CreateQuery(
                    "from Contenuto as cont, Risorsamultimediale as ris "+
                    "where cont.Rfidtag = :rfid");

                    q.SetParameter("rfid", rfid);

                    ris= (Risorsamultimediale)q.List()[0];

                    tempT.Commit();
                    Console.WriteLine("Query di get_risorsa_by_rfid eseguita, commit");

                }
                catch (Exception ex)
                {
                    tempT.Rollback();
                    Console.WriteLine("Query di get_risorsa_by_rfid, rollback.\nMessage = " + ex.Message);
                    throw new Exception("Query di get_risorsa_by_rfid non riuscita\n", ex);
                }
                finally
                {
                    tempS.Close();
                }
            }


            return ris;
        }

        /// <summary>
        /// This function allow to delete a Risorsamultimediale
        /// </summary>
        /// <param name="id">the key-id of the Poster</param>
        public void delete_risorsamultimediale(int id)
        {
            Risorsamultimediale selected_risorsa = null;

            using (ISession tempS = factory.OpenSession())
            using (ITransaction tempT = tempS.BeginTransaction())
            {
                try
                {
                    //carica il poster
                    IQuery q = tempS.CreateQuery(
                        "from Risorsamultimediale as ris " +
                        "where ris.IDrisorsa = :id"
                        );
                    q.SetParameter("id", id);
                    selected_risorsa = (Risorsamultimediale)q.List()[0];

                    tempS.Delete(selected_risorsa);
                    tempS.Flush();
                    tempT.Commit();
                    Console.WriteLine("Query di delete_risorsa eseguita, commit");

                }
                catch (Exception ex)
                {
                    tempT.Rollback();
                    Console.WriteLine("Query di delete_risorsa NON eseguita, ROLLBACK");
                    throw new Exception("Query di delete_risorsa non riuscita\n", ex);
                }
                finally
                {
                    tempS.Close();
                }
            }
        }

        /// <summary>
        /// This function allow to create a new risorsamultimediale
        /// </summary>
        /// <param name="RFId">the serial number of the RFID</param>
        /// <param name="name">the name of the attribute</param>
        /// <param name="type_att">the type of the attribute</param>
        /// <param name="fBin">the binary of the file</param>
        /// <param name="fEst">the extension of the file</param>
        /// <param name="fDim">the dimension of the file</param>
        /// <param name="fName">the name of the file</param>
        public void new_risorsamultimediale( string nome, string path, string est, int dim , IList profilo, IList contenuto)
        {

            using (ISession tempS = factory.OpenSession())
            using (ITransaction tempT = tempS.BeginTransaction())
            {
                Risorsamultimediale nuova = new Risorsamultimediale();
                try
                {
                   
                    nuova.Nome = nome;
                    nuova.Path = path;
                    nuova.Estensione = est;
                    nuova.Dimensione = dim;
                    /*
                     * Non so se sia corretto fare questa operazione!!!
                     * */
                    nuova.ProfiloLista = profilo;
                    nuova.ContenutoLista = contenuto;
                    tempS.Save(nuova);
                    tempS.Flush();
                    tempT.Commit();
                    Console.WriteLine("Query di new_risorsa eseguita, commit");

                }
                catch (Exception ex)
                {
                    tempT.Rollback();
                    Console.WriteLine("Query di new_risorsa NON eseguita, ROLLBACK");
                    throw new Exception("Query di new_risorsa non riuscita\n", ex);
                }
                finally
                {
                    tempS.Close();
                }
            }
        }

        #endregion


        #region Mostra

        /// <summary>
        /// This function allow to take all the mostre
        /// </summary>
        /// <returns>the works</returns>
        public IList get_mostre()
        {
            //sFactory = cfg.ConfigNHibernate(cfg.pConfig.DriverDb);
            IList result = null;

            using (ISession tempS = factory.OpenSession())
            using (ITransaction tempT = tempS.BeginTransaction())
            {
                try
                {
                    IQuery q = tempS.CreateQuery(
                    "select mostra " +
                    "from Mostra as mostra "
                        );
                    result = q.List();
                    tempT.Commit();
                    Console.WriteLine("Query di get_mostre eseguita, commit");
                }
                catch (Exception ex)
                {

                    tempT.Rollback();
                    Console.WriteLine("Query di get_mostra abortita, rollback.\nMessage = " + ex.Message);
                    throw new Exception("Query di get_mostre non riuscita\n", ex);
                }
                finally
                {
                    tempS.Close();
                }
            }
            return result;
        }

        #endregion

    }
}

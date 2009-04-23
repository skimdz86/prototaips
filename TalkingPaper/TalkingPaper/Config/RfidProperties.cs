using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;

namespace TalkingPaper.Config
{
    /**
     * E' la classe che rappresenta i dati per la connessione al Reader.
     *  Esiste in Config_manager il metodo read_config_rfid_xml() che legge il file .xml
     *  dove sono salvate le configurazione e restituisce un oggett RfidProperties
     * */
    class RfidProperties
    {
        private string portReader;
        private string comunicationframeReader;
        private string baudrateReader;
        private string timeoutReader;

        private ISessionFactory sessionfactory = null;

        public RfidProperties()
        { }

        /// <summary>
        /// Set and get the value of the port of reader
        /// </summary>
        public string PortReader
        {
            get { return portReader; }
            set { portReader = value; }
        }

        /// <summary>
        /// Set and get the value of the Comunication Frame
        /// </summary>
        public string ComunicationframeReader
        {
            get { return comunicationframeReader; }
            set { comunicationframeReader = value; }
        }

        /// <summary>
        /// Set and get the value of the Baud Rate
        /// </summary>
        public string BaudrateReader
        {
            get { return baudrateReader; }
            set { baudrateReader = value; }
        }

        /// <summary>
        /// Set and get the value of the Time Out
        /// </summary>
        public string TimeoutReader
        {
            get { return timeoutReader; }
            set { timeoutReader = value; }
        }

        /// <summary>
        /// Set and get the value of the Session Factory
        /// </summary>
        public ISessionFactory SessionFactory
        {
            get { return sessionfactory; }
            set { sessionfactory = value; }
        }

    }
}

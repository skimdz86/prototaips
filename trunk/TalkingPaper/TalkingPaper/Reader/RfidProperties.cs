using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;

namespace TalkingPaper.Reader
{
    /**
     * E' la classe che rappresenta i dati per la connessione al Reader.
     *  Esiste in Config_manager il metodo read_config_rfid_xml() che legge il file .xml
     *  dove sono salvate le configurazione e restituisce un oggett RfidProperties
     * */
    class RfidProperties
    {
        private Int32 Port;
        private string CommunicationFrame;
        private string BaudRate;
        private Int16 Timeout;

        private ISessionFactory sessionfactory = null;

        public RfidProperties()
        { }

        /// <summary>
        /// Set and get the value of the port of reader
        /// </summary>
        public Int32 port
        {
            get { return Port; }
            set { Port = value; }
        }

        /// <summary>
        /// Set and get the value of the Communication Frame
        /// </summary>
        public string communicationFrame
        {
            get { return CommunicationFrame; }
            set { CommunicationFrame = value; }
        }

        /// <summary>
        /// Set and get the value of the Baud Rate
        /// </summary>
        public string baudRate
        {
            get { return BaudRate; }
            set { BaudRate = value; }
        }

        /// <summary>
        /// Set and get the value of the Time Out
        /// </summary>
        public Int16 timeout
        {
            get { return Timeout; }
            set { Timeout = value; }
        }

       

    }
}

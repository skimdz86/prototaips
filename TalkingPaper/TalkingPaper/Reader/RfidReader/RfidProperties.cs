using System;
using System.Collections.Generic;
using System.Text;


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

        //Metodi getters e setters

        public Int32 port
        {
            get { return Port; }
            set { Port = value; }
        }

        public string communicationFrame
        {
            get { return CommunicationFrame; }
            set { CommunicationFrame = value; }
        }

        public string baudRate
        {
            get { return BaudRate; }
            set { BaudRate = value; }
        }

        public Int16 timeout
        {
            get { return Timeout; }
            set { Timeout = value; }
        }

    }
}

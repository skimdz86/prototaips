using RFIDlibrary;
using System;

namespace TalkingPaper.Reader
{
    public class RfidReader : IReader
    {
        private RFIDConfigurator rfid_configurator;
        private RFidConfigManager config_manager;
        private int id_reader = 0;
        private bool isConfigured = false;

        public event ReaderDelegate readerStatusUpdate;

        public RfidReader ()
        {
            try
            {
                rfid_configurator = new RFIDConfigurator();
            }
            catch
            {
                Console.WriteLine("Errore driver con RFID");
            }
            config_manager = new Reader.RFidConfigManager();
            
        }

        bool IReader.configure()
        {
            if (rfid_configurator == null)
            {
                return false;
            }
            RfidProperties properties;
            int port = 0;

            //Provo a far partire il lettore leggendo l'ultima configurazione funzionante
            //leggo la configurazione da file XML \Config\rfid_config.xml
            properties = config_manager.read_config_rfid_xml();
            id_reader = rfid_configurator.connect(properties.port, properties.communicationFrame, properties.baudRate, properties.timeout);
            if (id_reader > 0)
            {
                isConfigured = true;
                return true;
            }
            else
            {
                //faccio la ricerca della porta
                for (port = 3; (id_reader <= 0) && (port < 20); port++)
                {
                    id_reader = rfid_configurator.connect(port, properties.communicationFrame, properties.baudRate, properties.timeout);
                }

                if (id_reader <= 0)
                {
                    //non sono riuscito a configurare
                    return false;
                }
                else
                {
                    //ho trovato una configurazione funzionante e la salvo
                    ////modificato!!!ora passa l'oggetto properties anziche singoli campi! By Dezo
                    properties.port = port - 1;
                    config_manager.configParameter(properties);

                    isConfigured = true;
                    return true;
                }
            }
        }

        string IReader.readValue()
        {
            //eccezione se non è configurato!
            return rfid_configurator.letturaID(id_reader).ToString();
        }

        int IReader.connect()
        {
            RfidProperties properties;
            if (!isConfigured)
            {
                //il lettore non è stato configurato!
                //lancia eccezione
            }

            if (readerStatusUpdate != null) rfid_configurator.StatusUpdateEvent += new RFIDlibrary.RFIDConfigurator.StatusUpdateDelegate(readerStatusUpdate);
            else throw new Exception("Non è stato aggiunto uno statusUpdateReader");
            //leggo la configurazione da file XML \Config\rfid_config.xml
            properties = config_manager.read_config_rfid_xml();
            id_reader = rfid_configurator.connect(properties.port, properties.communicationFrame, properties.baudRate, properties.timeout);

            if (id_reader <= 0)
            {
                //lancia eccezione, non sono riuscito a connettermi e devo riconfigurare
                return id_reader;
            }
            else
            {
                rfid_configurator.letturaID(id_reader);
                return id_reader;
            }
        }

        bool IReader.saveConfiguration(params string[] parameters)
        {
            //controllare correttezza dei parametri ( o lo lascio controllare al config_manager?)
            RfidProperties p = new RfidProperties();
            p.port=Convert.ToInt32(parameters[0]);
            p.communicationFrame=parameters[1];
            p.baudRate=parameters[2];
            p.timeout=Convert.ToInt16(parameters[3]);
            return config_manager.configParameter(p);
        }

        bool IReader.close()
        {
            return true;
        }
    }

}

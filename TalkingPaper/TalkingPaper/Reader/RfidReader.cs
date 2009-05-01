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
            rfid_configurator = new RFIDConfigurator();
            config_manager = new Reader.RFidConfigManager();
            rfid_configurator.StatusUpdateEvent += new RFIDlibrary.RFIDConfigurator.StatusUpdateDelegate(readerStatusUpdate);
        }

        bool IReader.configure()
        {
            RfidProperties properties;
            int port = 0;

            //Provo a far partire il lettore leggendo l'ultima configurazione funzionante
            //leggo la configurazione da file XML \Config\rfid_config.xml
            properties = config_manager.read_config_rfid_xml();
            id_reader = rfid_configurator.connect(properties.port, properties.communicationFrame, properties.baudRate, properties.timeout);

            //Se non va bene questa configurazione faccio la ricerca della porta
            for (port = 1; (id_reader <= 0) && (port < 20); port++)
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
                if (port != 0)
                {
                    //ho trovato una configurazione funzionante e la salvo
                    config_manager.configParameter(port, properties.communicationFrame, properties.baudRate, properties.timeout);
                }
                isConfigured = true;
                return true;
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
            //leggo la configurazione da file XML \Config\rfid_config.xml
            properties = config_manager.read_config_rfid_xml();
            id_reader = rfid_configurator.connect(properties.port, properties.communicationFrame, properties.baudRate, properties.timeout);
            
            if (id_reader <= 0)
            {
                //lancia eccezione, non sono riuscito a connettermi e devo riconfigurare
                return id_reader;                
            }
            else return id_reader;
        }

        bool IReader.saveConfiguration(params string[] parameters)
        {
            //controllare correttezza dei parametri ( o lo lascio controllare al config_manager?)
            return config_manager.configParameter(Convert.ToInt32(parameters[0]), parameters[1], parameters[2], Convert.ToInt16(parameters[3]));
        }

        bool IReader.close()
        {
            return true;
        }
    }

}

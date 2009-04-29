using RFIDlibrary;
using System;

namespace TalkingPaper.Reader
{
    public class RfidReader : IReader
    {
        private RFIDConfigurator rfid_configurator;
        private RFidConfigManager config_manager;
        private int id_reader;

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
            
            //leggo la configurazione da file XML \Config\rfid_config.xml
            properties = config_manager.read_config_rfid_xml();

            //TODO autoricerca della porta!
            
            id_reader = rfid_configurator.connect(properties.port, properties.communicationFrame, properties.baudRate, properties.timeout);
            if (id_reader <= 0)
            {
                //lancia eccezione
                return false;
            }
            else return true;
        }

        string IReader.readValue()
        {
            return rfid_configurator.letturaID(id_reader).ToString();
        }

        int IReader.connect()
        {
            RfidProperties properties;

            //leggo la configurazione da file XML \Config\rfid_config.xml
            properties = config_manager.read_config_rfid_xml();
            
            id_reader = rfid_configurator.connect(properties.port, properties.communicationFrame, properties.baudRate, properties.timeout);
            if (id_reader <= 0)
            {
                //lancia eccezione
                
            }
            return id_reader;
        }

        bool IReader.saveConfiguration(params string[] parameters)
        {
            //controllare correttezza dei parametri
            return config_manager.configParameter(Convert.ToInt32(parameters[0]), parameters[1], parameters[2], Convert.ToInt16(parameters[3]));
        }

    }

}

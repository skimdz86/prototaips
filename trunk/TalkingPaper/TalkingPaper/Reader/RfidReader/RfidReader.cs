using RFIDlibrary;
using System;
using System.IO.Ports;
using System.Windows.Forms;


namespace TalkingPaper.Reader
{
    public class RfidReader : IReader
    {
        private RFIDConfigurator rfid_configurator;
        private RFidConfigManager config_manager;
        private int id_reader = 0;
        private bool isConfigured = false;
        Timer timerRead;

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

        int IReader.configure()
        {
            if (rfid_configurator == null)
            {
                return -1;
            }
            RfidProperties properties;
            int port = 0;
            int portCounter = 0;
            id_reader = 0;
            
            //Provo a far partire il lettore leggendo l'ultima configurazione funzionante
            //leggo la configurazione da file XML \Config\rfid_config.xml
            properties = config_manager.read_config_rfid_xml();
            
            foreach (string portName in SerialPort.GetPortNames())
            {
                if (!(portName.Equals("COM1")))
                {
                    portCounter++;
                    if (portName.Equals("COM" + properties.port)) id_reader = rfid_configurator.connect(properties.port, properties.communicationFrame, properties.baudRate, properties.timeout);
                }
            }

            if (portCounter == 0) //Nessuna porta com attiva
            {
                return portCounter;
            }

            if (id_reader > 0)
            {
                isConfigured = true;
                return portCounter;
            }
            else
            {
                //faccio la ricerca della porta

                foreach (string portName in SerialPort.GetPortNames())
                {
                    if (!(portName.Equals("COM1")))
                    {
                        port = Convert.ToInt32(portName.Substring(3, 1));
                        id_reader = rfid_configurator.connect(port, properties.communicationFrame, properties.baudRate, properties.timeout);
                        if (id_reader > 0)
                        {
                            //sono riuscito a configurare
                            properties.port = port;
                            config_manager.configParameter(properties);
                            isConfigured = true;
                            return portCounter;
                        }
                    }
                }


                //non sono riuscito a configurare
                return portCounter;

            }
        }

        string IReader.readValue()
        {
            return null;
        }

        public int connect()
        {
            RfidProperties properties;
            if (!isConfigured)
            {
                //il lettore non è stato configurato!
                //lancia eccezione
            }

            
            //leggo la configurazione da file XML \Config\rfid_config.xml
            properties = config_manager.read_config_rfid_xml();
            if (rfid_configurator != null) id_reader = rfid_configurator.connect(properties.port, properties.communicationFrame, properties.baudRate, properties.timeout);
            else return -1;
            if (id_reader <= 0)
            {
                //lancia eccezione, non sono riuscito a connettermi e devo riconfigurare
                return 0;
            }
            else
            {
                return id_reader;
            }
        }

        public bool startRead()
        {
            if (rfid_configurator == null)
            {
                return false;
            }
            if (readerStatusUpdate != null) rfid_configurator.StatusUpdateEvent += new RFIDlibrary.RFIDConfigurator.StatusUpdateDelegate(readerStatusUpdate);
            else throw new Exception("Non è stato aggiunto uno statusUpdateReader");
            //avvio la lettura
            
            timerRead = new Timer();
            timerRead.Interval = 1000;
            timerRead.Tick += read;
            timerRead.Start();
            return true;
        }

        public void read(object sender, EventArgs e)
        {
            rfid_configurator.letturaID(id_reader);

        }

        String[] IReader.getConfiguration()
        {
            RfidProperties prop;
            prop = config_manager.read_config_rfid_xml();
            String[] result = { prop.port.ToString(), prop.communicationFrame.ToString(), prop.baudRate.ToString(), prop.timeout.ToString() };
            return result;
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
            if (timerRead != null) timerRead.Stop();
            if (readerStatusUpdate != null)
            {
                rfid_configurator.StatusUpdateEvent -= new RFIDlibrary.RFIDConfigurator.StatusUpdateDelegate(readerStatusUpdate);
                readerStatusUpdate = null;
            }
            return true;
        }
    }

}

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace TalkingPaper.Config
{    
    /// <summary>
    /// Classe per la gestione del file di configurazione
    /// </summary>
    class Config_manager
    {
        private XmlWriterSettings settings;
        private string path;

        /// <summary>
        /// Costruttore
        /// </summary>
        public Config_manager(string path)
        {
            this.path = path;
        }
        public Config_manager()
        {
            path = Directory.GetCurrentDirectory() + @"\Config\";
        }
        
        /// <summary>
        /// This function allow to read the parameter in file XML
        /// </summary>
        /// <returns>return the object RfidProperties</returns>
        public RfidProperties read_config_rfid_xml()
        {
            RfidProperties prop = new RfidProperties();
            FileStream fs = new FileStream(path+"rfid_config.xml", FileMode.Open);
            XmlReader rdr = XmlReader.Create(fs);

            while (!rdr.EOF)
            {
                if (rdr.MoveToContent() == XmlNodeType.Element && rdr.Name == "parameters")
                {
                    rdr.Read();
                    if (rdr.MoveToContent() == XmlNodeType.Element && rdr.Name == "reader")
                    {   
                        rdr.Read();
                        while (rdr.MoveToContent() != XmlNodeType.EndElement)
                        {
                            switch (rdr.Name)
                            {
                                case "port":
                                    prop.PortReader = rdr.ReadElementString();
                                    break;
                                case "comunication_frame":
                                    prop.ComunicationframeReader = rdr.ReadElementString();
                                    break;
                                case "baud_rate":
                                    prop.BaudrateReader = rdr.ReadElementString();
                                    break;
                                case "time_out":
                                    prop.TimeoutReader = rdr.ReadElementString();
                                    break;
                                default: rdr.Read();
                                    break;
                            }
                        } 
                        rdr.Read();
                    }
                }
                else
                {
                    rdr.Read();
                }
            }
            fs.Close();
            return prop;
        }//fine metodo lettura
        

        /// <summary>
        /// This function allow to create the configuration file
        /// </summary>
        /// <param name="port">reader port (COM)</param>
        /// <param name="frame">comunication frame</param>
        /// <param name="rate">baud rate</param>
        /// <param name="to">time out</param>
        /// <returns>true if the file is created</returns>
        public bool configParameter(int port, string frame, string rate, short to )
        {
            settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;

            try
            {
                XmlWriter writer = XmlWriter.Create(path + "rfid_config.xml", settings);

                writer.WriteStartDocument();
                writer.WriteStartElement("parameters");

                writer.WriteStartElement("reader");
                writer.WriteElementString("port", Convert.ToString(port));
                writer.WriteElementString("comunication_frame", frame);
                writer.WriteElementString("baud_rate", rate);
                writer.WriteElementString("time_out", Convert.ToString(to));
                writer.WriteEndElement();

                writer.WriteEndElement();

                writer.WriteEndDocument();

                writer.Flush();
                writer.Close();

                Console.WriteLine("Fine scrittura del file di configurazione rfid");

                return true;
            }
            catch (XmlException xmlExc)
            {
                Console.WriteLine("Errore nella creazione del file di RfidConfig.xml\n " + xmlExc.Message);
                return false;
            }
        }

        /// <summary>
        /// This function allow to verify if the configuration files have been created
        /// </summary>
        /// <returns>true if the files exist false if they don't exist</returns>
        public bool exist()
        {
            Console.WriteLine("Verifico se il file rfid_config.xml esiste nel percorso: "+ path);
            bool exist = false;
            if (!Directory.Exists(path))
            {
                exist = false;
                Console.WriteLine("Il file non esiste");

            }
            else
            {
                exist = true;
                Console.WriteLine("Il file esiste");

            }
            return exist;
        }

    }
}

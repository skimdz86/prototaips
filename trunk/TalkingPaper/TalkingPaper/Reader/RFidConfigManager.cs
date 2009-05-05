using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace TalkingPaper.Reader
{    
    /// <summary>
    /// Classe per la gestione del file di configurazione
    /// </summary>
    class RFidConfigManager
    {
        private XmlWriterSettings settings;
        private string path;
        private String filepath = "/Config/rfid_config.xml";

        /// <summary>
        /// Costruttore
        /// </summary>
        public RFidConfigManager(string path)
        {
            this.path = path;
        }
        public void RFidConfigManager2()
        {
            path = Directory.GetCurrentDirectory() + @"\Config\";
        }
        //nuovo costruttore: autogenera il file se nn c'è
        public RFidConfigManager()
        {
            try
            {
                if(!File.Exists("/Config/rfid_config.xml")) createXMLConfig();

            }catch(IOException e){Console.Write("Erroreeeeeeeeeeeeeeeeeee!");}
        }
        
        //crea il file vuoto (o standard)
        public void createXMLConfig(){
            
            XmlTextWriter writer = new XmlTextWriter(filepath, Encoding.UTF8);
            writer.WriteStartDocument();
            writer.WriteStartElement("parameters");
            writer.WriteStartElement("reader");
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();

            XmlDocument doc = new XmlDocument();
            FileStream stream = new FileStream(filepath, FileMode.Open);
            doc.Load(stream);
            XmlNodeList l=doc.GetElementsByTagName("reader");
            XmlElement xreader=(XmlElement)l[0];

            XmlElement port=(XmlElement)doc.CreateElement("port");
            XmlText tport=(XmlText)doc.CreateTextNode("");
            port.AppendChild(tport);
            XmlElement cf=(XmlElement)doc.CreateElement("communication_frame");
            XmlText tcf=(XmlText)doc.CreateTextNode("");
            cf.AppendChild(tcf);
            XmlElement baud=(XmlElement)doc.CreateElement("baud_rate");
            XmlText tbaud=(XmlText)doc.CreateTextNode("");
            baud.AppendChild(tbaud);
            XmlElement to=(XmlElement)doc.CreateElement("timeout");
            XmlText tto=(XmlText)doc.CreateTextNode("");
            to.AppendChild(tto);

            xreader.AppendChild(port);
            xreader.AppendChild(cf);
            xreader.AppendChild(baud);
            xreader.AppendChild(to);

            stream.Close();
            doc.Save(filepath);
        }
        /// <summary>
        /// This function allow to read the parameter in file XML
        /// </summary>
        /// <returns>return the object RfidProperties</returns>
        public RfidProperties read_config_rfid_xml2()
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
                                    prop.port = Convert.ToInt32(rdr.ReadElementString());
                                    break;
                                case "comunication_frame":
                                    prop.communicationFrame = rdr.ReadElementString();
                                    break;
                                case "baud_rate":
                                    prop.baudRate = rdr.ReadElementString();
                                    break;
                                case "time_out":
                                    prop.timeout = Convert.ToInt16(rdr.ReadElementString());
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
        /// Nuova funzione per lettura xml
        /// </summary>
        /// <returns></returns>
        public RfidProperties read_config_rfid_xml() {

            try
            {
                RfidProperties prop = new RfidProperties();
                XmlDocument doc = new XmlDocument();
                FileStream stream = new FileStream(filepath, FileMode.Open);
                doc.Load(stream);

                XmlNodeList port = doc.GetElementsByTagName("port");
                Int32 temp1 = Convert.ToInt32(port[0].InnerText);
                prop.port = temp1;

                XmlNodeList cf = doc.GetElementsByTagName("communication_frame");
                prop.communicationFrame = cf[0].InnerText;

                XmlNodeList baud = doc.GetElementsByTagName("baud_rate");
                prop.baudRate = baud[0].InnerText;

                XmlNodeList timeout = doc.GetElementsByTagName("timeout");
                Int16 temp2 = Convert.ToInt16(timeout[0].InnerText);
                prop.timeout = temp2;

                stream.Close();
                return prop;
            }
            catch (XmlException e) { return null; }
        }

        /// <summary>
        /// This function allow to create the configuration file
        /// </summary>
        /// <param name="port">reader port (COM)</param>
        /// <param name="frame">comunication frame</param>
        /// <param name="rate">baud rate</param>
        /// <param name="to">time out</param>
        /// <returns>true if the file is created</returns>
        public bool configParameter2(int port, string frame, string rate, short to )
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
        /// nuova funzione scrittura xml
        /// </summary>
        /// <param name="prop"></param>
        /// <returns></returns>
        public bool configParameter(RfidProperties prop) {
            //spero che vada, ma ho il dubbio che la nodelist nn prenda tutti i nodi esistenti nell'xml se nn gli do il sopraelementeo
            try
            {
                XmlDocument doc = new XmlDocument();
                FileStream stream = new FileStream(filepath, FileMode.Open);
                doc.Load(stream);

                XmlNodeList port = doc.GetElementsByTagName("port");
                port[0].InnerText = Convert.ToString(prop.port);

                XmlNodeList cf = doc.GetElementsByTagName("communication_frame");
                cf[0].InnerText = prop.communicationFrame;

                XmlNodeList baud = doc.GetElementsByTagName("baud_rate");
                baud[0].InnerText = prop.baudRate;

                XmlNodeList timeout = doc.GetElementsByTagName("timeout");
                timeout[0].InnerText = Convert.ToString(prop.timeout);

                stream.Close();
                doc.Save(filepath);
                return true;
            }
            catch (XmlException e) { return false; }
        }

        /// <summary>
        /// This function allow to verify if the configuration files have been created
        /// </summary>
        /// <returns>true if the files exist false if they don't exist</returns>
        public bool exist2()
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

        ////nuova exist
        public bool exist()
        {
            Console.WriteLine("Verifico se il file rfid_config.xml esiste nel percorso: " + filepath);
            bool exist = false;
            if (!Directory.Exists(filepath))
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

using System;
using System.IO;
using TalkingPaper.Common;
using System.Xml;
using System.Text;

namespace TalkingPaper.Reader
{    
    class RfidConfigManager
    {
        private String dirpath = Global.directoryPrincipale + "\\Config\\";
        private String filepath = Global.directoryPrincipale+"\\Config\\rfid_config.xml";

        
        public RfidConfigManager()
        {
            try
            {
                if (!(Directory.Exists(dirpath))) {
                    //creazione della cartella che contiene la configurazione, se non esiste
                    Directory.CreateDirectory(dirpath);
                }
                if(!File.Exists(filepath)) 
                    //autogenerazione del file se non esiste
                    createXMLConfig();

            }catch(IOException){ throw new Exception("Errore Di I/O");}
        }
        
        /// <summary>
        /// Metodo per la creazione di un file di configurazione standard
        /// </summary>
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
            XmlText tport=(XmlText)doc.CreateTextNode("2");
            port.AppendChild(tport);
            XmlElement cf=(XmlElement)doc.CreateElement("communication_frame");
            XmlText tcf=(XmlText)doc.CreateTextNode("8E1");
            cf.AppendChild(tcf);
            XmlElement baud=(XmlElement)doc.CreateElement("baud_rate");
            XmlText tbaud=(XmlText)doc.CreateTextNode("38400");
            baud.AppendChild(tbaud);
            XmlElement to=(XmlElement)doc.CreateElement("time_out");
            XmlText tto=(XmlText)doc.CreateTextNode("1000");
            to.AppendChild(tto);

            xreader.AppendChild(port);
            xreader.AppendChild(cf);
            xreader.AppendChild(baud);
            xreader.AppendChild(to);

            stream.Close();
            doc.Save(filepath);
        }
        
        /// <summary>
        /// Metodo per lettura dei dati di configurazione
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

                XmlNodeList timeout = doc.GetElementsByTagName("time_out");
                Int16 temp2 = Convert.ToInt16(timeout[0].InnerText);
                prop.timeout = temp2;

                stream.Close();
                return prop;
            }
            catch (XmlException) { return null; }
        }

        
        /// <summary>
        /// Metodo per il salvataggio dei dati di configurazione
        /// </summary>
        /// <param name="prop"></param>
        /// <returns></returns>
        public bool configParameter(RfidProperties prop) {
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

                XmlNodeList timeout = doc.GetElementsByTagName("time_out");
                timeout[0].InnerText = Convert.ToString(prop.timeout);

                stream.Close();
                doc.Save(filepath);
                return true;
            }
            catch (XmlException) { return false; }
        }

        
        /// <summary>
        /// Metodo per verificare l'esistenza del file di configurazione
        /// </summary>
        /// <returns></returns>
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

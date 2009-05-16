using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using TalkingPaper.Common;

namespace TalkingPaper.Reader
{    
    /// <summary>
    /// Classe per la gestione del file di configurazione
    /// </summary>
    class RFidConfigManager
    {
        
        private String filepath = Global.directoryPrincipale+"\\Config\\rfid_config.xml";

        /// <summary>
        /// Costruttore
        /// </summary>
        //nuovo costruttore: autogenera il file se nn c'è
        public RFidConfigManager()
        {
            try
            {
                if(!File.Exists(filepath)) createXMLConfig();

            }catch(IOException e){ throw new Exception("Erroreeeeeeeeeeeeeeeeeee! Di I/O");}
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
            XmlText tport=(XmlText)doc.CreateTextNode("0");
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

                XmlNodeList timeout = doc.GetElementsByTagName("time_out");
                Int16 temp2 = Convert.ToInt16(timeout[0].InnerText);
                prop.timeout = temp2;

                stream.Close();
                return prop;
            }
            catch (XmlException e) { return null; }
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

                XmlNodeList timeout = doc.GetElementsByTagName("time_out");
                timeout[0].InnerText = Convert.ToString(prop.timeout);

                stream.Close();
                doc.Save(filepath);
                return true;
            }
            catch (XmlException e) { return false; }
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

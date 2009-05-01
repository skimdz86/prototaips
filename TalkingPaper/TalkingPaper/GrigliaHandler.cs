using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace TalkingPaper
{
    class GrigliaHandler : AbstractDataHandler
    {
        String filepath = "???????????????????????????????????????";

        //crea il file
        public void CreateGriglieTaggate()
        {
            XmlTextWriter writer = new XmlTextWriter(filepath, Encoding.UTF8);
            writer.WriteStartDocument();
            writer.WriteStartElement("GriglieTaggate");
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }
        public String setGriglia(Griglia gr)
        {
            String ID = "Generare un id per la griglia, magari casuale";//////////////////
            XmlDocument doc = new XmlDocument();
            FileStream stream = new FileStream(filepath, FileMode.Open);
            doc.Load(stream);
            XmlElement el = doc.CreateElement("Griglia");
            
            el.SetAttribute("Nome", gr.getNome());
            el.SetAttribute("Righe", gr.getNumRighe().ToString());
            el.SetAttribute("Colonne", gr.getNumColonne().ToString());
            doc.DocumentElement.AppendChild(el);
            stream.Close();
            doc.Save(filepath);
            return ID;
        }
        ////////////////////////////////usare funz di yan
        public void InsertTags(String idGriglia, String riga, String colonna, String tag, String filepath)
        {
            //se inserire piu assieme, far passare un arraylist
            XmlDocument doc = new XmlDocument();
            FileStream stream = new FileStream(filepath, FileMode.Open);
            doc.Load(stream);
            XmlNodeList list = doc.GetElementsByTagName("Griglia");
            for (int i = 0; i < list.Count; i++)
            {
                XmlElement temp = (XmlElement)doc.GetElementsByTagName("Griglia")[i];
                if (temp.GetAttribute("ID") == idGriglia)
                {
                    XmlElement el1 = doc.CreateElement(riga + colonna);
                    XmlText rfid = doc.CreateTextNode(tag);
                    el1.AppendChild(rfid);
                    temp.AppendChild(el1);
                    //break;
                }
            }
            stream.Close();
            doc.Save(filepath);
        }


        //utile?
        public void RemoveGriglia(String idGriglia, String filepath)
        {
            XmlDocument doc = new XmlDocument();
            FileStream stream = new FileStream(filepath, FileMode.Open);
            doc.Load(stream);
            XmlNodeList list = doc.GetElementsByTagName("Griglia");
            for (int i = 0; i < list.Count; i++)
            {
                XmlElement rm = (XmlElement)doc.GetElementsByTagName("Griglia")[i];
                if (rm.GetAttribute("ID") == idGriglia)
                {
                    doc.DocumentElement.RemoveChild(rm);
                }
            }
            stream.Close();
            doc.Save(filepath);
        }

        public List<Griglia> getListaGriglie()
        {//forse utile anche bean griglia
            XmlDocument doc = new XmlDocument();
            FileStream stream = new FileStream(filepath, FileMode.Open);
            doc.Load(stream);
            List<Griglia> tempGr = new List<Griglia>();
            XmlNodeList grList = doc.GetElementsByTagName("Griglia");
            for (int i = 0; i < grList.Count; i++)
            {
                XmlElement x = (XmlElement)doc.GetElementsByTagName("Griglia")[i];
                Griglia gr = new Griglia("",0,0);
                gr.setNome(x.GetAttribute("Nome"));
                gr.setNumRighe(x.GetAttribute("Righe"));
                gr.setNumColonne(x.GetAttribute("Colonne"));
                tempGr.Add(gr);
            }
            return tempGr;
        }
        public void ReadGriglia(String id, String filepath)
        {
            ///////ma questa pero è inutile, le caratteristiche le leggo con listagriglie!!!
        }
        public String ReadCella(String id, String filepath, String riga, String colonna)
        {
            XmlDocument doc = new XmlDocument();
            FileStream stream = new FileStream(filepath, FileMode.Open);
            doc.Load(stream);
            String tagtemp = "";
            XmlNodeList list = doc.GetElementsByTagName("Griglia");
            for (int i = 0; i < list.Count; i++)
            {
                XmlElement xel = (XmlElement)doc.GetElementsByTagName("Griglia")[i];
                if (xel.GetAttribute("ID") == id)
                {
                    XmlNodeList tagList = xel.GetElementsByTagName(riga + colonna);
                    XmlElement xt = (XmlElement)tagList.Item(0);//evitato un for inutile, c'è un solo elem tanto, ma forse un altro for puo gestire eccezione
                    tagtemp = xt.InnerText;
                    break;//forse comodo per l'efficienza
                }
            }
            return tagtemp;
        }
    }
}

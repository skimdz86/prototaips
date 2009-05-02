using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Collections;

namespace TalkingPaper.DataAccess
{
    class GrigliaHandler : GeneralDataHandler
    {
        String filepath = "../../Data/Griglie.xml";

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
        public bool setGriglia(Griglia gr)
        {
            //String ID = "Generare un id per la griglia, magari casuale";//////////////////
            XmlDocument doc = new XmlDocument();
            FileStream stream = new FileStream(filepath, FileMode.Open);
            doc.Load(stream);
            XmlElement el = doc.CreateElement("Griglia");
            
            el.SetAttribute("Nome", gr.getNome());
            el.SetAttribute("Righe", gr.getNumRighe().ToString());
            el.SetAttribute("Colonne", gr.getNumColonne().ToString());
            List<String> tempTags = gr.getListaTag();
            for (int i = 0; i < tempTags.Count; i++) {
                if(tempTags[i]!=null){
                XmlElement cella = (XmlElement)doc.CreateElement("Cella");
                cella.SetAttribute("Coordinate",gr.getCoordFromIndex(i));
                XmlText tag = (XmlText)doc.CreateTextNode(tempTags[i]);
                cella.AppendChild(tag);
                el.AppendChild(cella);
                }
            }
            doc.DocumentElement.AppendChild(el);
            stream.Close();
            doc.Save(filepath);
            return true;
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
        {
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
                int r=Convert.ToInt32(x.GetAttribute("Righe"));
                int c = Convert.ToInt32(x.GetAttribute("Colonne"));
                gr.setNumRighe(r);
                gr.setNumColonne(c);
                tempGr.Add(gr);
            }
            return tempGr;
        }
        public Griglia getGriglia(String nome)
        {
            XmlDocument doc = new XmlDocument();
            FileStream stream = new FileStream(filepath, FileMode.Open);
            doc.Load(stream);
            Griglia tempGr = new Griglia("", 0, 0);
            XmlNodeList grList = doc.GetElementsByTagName("Griglia");
            for (int i = 0; i < grList.Count; i++) {
                XmlElement x=(XmlElement)doc.GetElementsByTagName("Griglia")[i];
                if (x.GetAttribute("Nome") == nome) {
                    tempGr.setNome(x.GetAttribute("Nome"));
                    int r=Convert.ToInt32(x.GetAttribute("Righe"));
                    int c=Convert.ToInt32(x.GetAttribute("Colonne"));
                    tempGr.setNumRighe(r);
                    tempGr.setNumColonne(c);
                    XmlNodeList celleList=x.GetElementsByTagName("Cella");
                    List<String> tags=new List<string>(r*c);
                    for(int j=0;j<celleList.Count;j++){
                        XmlElement y=(XmlElement)x.GetElementsByTagName("Cella")[j];
                        if(y.InnerText!=null) tags[j]=y.InnerText;
                    }
                    tempGr.setListaTag(tags);
                }
            }
            return tempGr;
        }

    }
}

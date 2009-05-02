using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace TalkingPaper.DataAccess
{
    class PosterHandler : GeneralDataHandler
    {
        String filepath = "../../Data/Poster.xml";

        public void CreateElencoPoster()
        {
            XmlTextWriter writer = new XmlTextWriter(filepath, Encoding.UTF8);
            writer.WriteStartDocument();
            writer.WriteStartElement("ElencoPoster");
            writer.WriteEndElement();
            writer.WriteEndDocument();///////////nella guida nn c'è ma mi sa che ci va
            writer.Close();
        }
        public bool setPoster(Poster poster)
        {
            //usiamo il nome come ID
            XmlDocument doc = new XmlDocument();
            FileStream stream = new FileStream(filepath, FileMode.Open);
            doc.Load(stream);
            XmlElement el = doc.CreateElement("Poster");
            el.SetAttribute("idUtente", poster.getUsername());
            el.SetAttribute("Nome", poster.getNome());
            el.SetAttribute("idGriglia", poster.getNomeGriglia());
            XmlElement desc = doc.CreateElement("Descrizione");
            XmlText text = doc.CreateTextNode(poster.getDescrizione());
            desc.AppendChild(text);
            el.AppendChild(desc);
            List<Contenuto> tempList = poster.getContenuti();
            for (int i = 0; i < tempList.Count; i++) {
                Contenuto c = (Contenuto)tempList[i];
                XmlElement x = doc.CreateElement("Contenuto");
                x.SetAttribute("Nome", c.getNomeContenuto());
                x.SetAttribute("AudioPath", c.getAudioPath());
                x.SetAttribute("VideoPath", c.getVideoPath());
                x.SetAttribute("ImagePath", c.getImagePath());
                x.SetAttribute("TextPath", c.getTextPath());
                x.SetAttribute("Cella", c.getCoordinate());
                el.AppendChild(x);
            }
            doc.DocumentElement.AppendChild(el);
            stream.Close();
            doc.Save(filepath);
            return true;
        }
        public Poster getPoster(String nomePoster) {

            XmlDocument doc = new XmlDocument();
            FileStream stream = new FileStream(filepath, FileMode.Open);
            doc.Load(stream);
            Poster tempPoster = new Poster("", "", "", "");
            XmlNodeList posList = doc.GetElementsByTagName("Poster");
            for (int i = 0; i < posList.Count; i++)
            {
                XmlElement x = (XmlElement)doc.GetElementsByTagName("Poster")[i];
                if (x.GetAttribute("Nome") == nomePoster)
                {
                    tempPoster.setNome(x.GetAttribute("Nome"));
                    tempPoster.setUsername(x.GetAttribute("idUtente"));
                    tempPoster.setNomeGriglia(x.GetAttribute("idGriglia"));
                    XmlNodeList descList = x.GetElementsByTagName("Descrizione");
                    XmlElement desc=(XmlElement)descList[0];
                    tempPoster.setDescrizione(desc.InnerText);
                    XmlNodeList contList=x.GetElementsByTagName("Contenuto");
                    List<Contenuto> tempCont=new List<Contenuto>();
                    for (int j = 0; j < contList.Count; j++)
                    {
                        XmlElement y = (XmlElement)x.GetElementsByTagName("Contenuto")[j];
                        Contenuto c=new Contenuto("","","","","");
                        c.setNomeContenuto(y.GetAttribute("Nome"));
                        c.setAudioPath(y.GetAttribute("AudioPath"));
                        c.setVideoPath(y.GetAttribute("VideoPath"));
                        c.setImagePath(y.GetAttribute("ImagePath"));
                        c.setTextPath(y.GetAttribute("TextPath"));
                        c.setCoordinate(y.GetAttribute("Cella"));
                        tempCont.Add(c);
                    }
                    tempPoster.setContenuti(tempCont);
                }
            }
            return tempPoster;
        }
        public List<Poster> getListaPoster() {

            XmlDocument doc = new XmlDocument();
            FileStream stream = new FileStream(filepath, FileMode.Open);
            doc.Load(stream);
            List<Poster> tempPos = new List<Poster>();
            XmlNodeList posList = doc.GetElementsByTagName("Poster");
            for (int i = 0; i < posList.Count; i++)
            {
                XmlElement x = (XmlElement)doc.GetElementsByTagName("Poster")[i];
                Poster pos = new Poster("", "", "","");
                pos.setNome(x.GetAttribute("Nome"));
                pos.setUsername(x.GetAttribute("idUtente"));
                pos.setNomeGriglia(x.GetAttribute("idGriglia"));
                XmlNodeList descList = x.GetElementsByTagName("Descrizione");
                XmlElement desc = (XmlElement)descList[0];
                pos.setDescrizione(desc.InnerText);
                tempPos.Add(pos);
            }
            return tempPos;
        }
        public bool removePoster(String nomePoster) {

            XmlDocument doc = new XmlDocument();
            FileStream stream = new FileStream(filepath, FileMode.Open);
            doc.Load(stream);
            XmlNodeList list = doc.GetElementsByTagName("Poster");
            for (int i = 0; i < list.Count; i++)
            {
                XmlElement rm = (XmlElement)doc.GetElementsByTagName("Poster")[i];
                if (rm.GetAttribute("Nome") == nomePoster)
                {
                    doc.DocumentElement.RemoveChild(rm);
                }
            }
            stream.Close();
            doc.Save(filepath);
            return true;
        }
        
    }
}

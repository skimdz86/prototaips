using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using TalkingPaper.Common;

namespace TalkingPaper.DataAccess
{
    class PosterHandler 
    {
        String dirpath = Global.directoryPrincipale + @"/Data/";
        String filepath = Global.directoryPrincipale + @"/Data/Poster.xml";

        public void CreateElencoPoster()
        {
            try
            {
                XmlTextWriter writer = new XmlTextWriter(filepath, Encoding.UTF8);
                writer.WriteStartDocument();
                writer.WriteStartElement("ElencoPoster");
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
            }
            catch (XmlException e) { throw new Exception("Si è verificato un errore. Prego riprovare", e); }
        }
        public bool setPoster(Model.Poster poster)
        {
            try
            {
                if (!(Directory.Exists(dirpath)))
                {
                    Directory.CreateDirectory(dirpath);
                }
                if (!File.Exists(filepath)) CreateElencoPoster();
            }
            catch (IOException e) { throw new Exception("Si è verificato un errore. Prego riprovare", e); }

            try
            {
                //usiamo il nome come ID
                XmlDocument doc = new XmlDocument();
                FileStream stream = new FileStream(filepath, FileMode.Open);
                doc.Load(stream);
                ////controllo nome gia esistente
                XmlNodeList l = doc.GetElementsByTagName("Poster");
                for (int k = 0; k < l.Count;k++ ) {
                    XmlElement xel = (XmlElement)l[k];
                    if (xel.GetAttribute("Nome") == poster.getNome())
                    {
                        doc.DocumentElement.RemoveChild(xel);
                    }
                }
                XmlElement el = doc.CreateElement("Poster");
                el.SetAttribute("idUtente", poster.getUsername());
                el.SetAttribute("Nome", poster.getNome());
                el.SetAttribute("idGriglia", poster.getNomeGriglia());
                XmlElement desc = doc.CreateElement("Descrizione");
                XmlText text = doc.CreateTextNode(poster.getDescrizione());
                desc.AppendChild(text);
                el.AppendChild(desc);
                List<Model.Contenuto> tempList = poster.getContenuti();
                for (int i = 0; i < tempList.Count; i++)
                {
                    Model.Contenuto c = (Model.Contenuto)tempList[i];
                    if (!((c.getCoordinate()[0].ToString() + c.getCoordinate()[1].ToString()).Equals("00")))
                    {
                        XmlElement x = doc.CreateElement("Contenuto");
                        x.SetAttribute("Nome", c.getNomeContenuto());
                        x.SetAttribute("AudioPath", c.getAudioPath());
                        x.SetAttribute("VideoPath", c.getVideoPath());
                        x.SetAttribute("ImagePath", c.getImagePath());
                        x.SetAttribute("TextPath", c.getTextPath());
                        x.SetAttribute("Cella", c.getCoordinate()[0].ToString() + c.getCoordinate()[1].ToString());
                        el.AppendChild(x);
                    }
                }
                doc.DocumentElement.AppendChild(el);
                stream.Close();
                doc.Save(filepath);
                return true;
            }
            catch (XmlException e) { throw new Exception("Si è verificato un errore. Prego riprovare", e); }
        }
        public Model.Poster getPoster(String nomePoster) {

            try
            {
                if (!(Directory.Exists(dirpath)))
                {
                    Directory.CreateDirectory(dirpath);
                }
                if (!File.Exists(filepath)) 
                {
                    CreateElencoPoster();
                    //throw new Exception("Il file non esiste!");
                }
            }
            catch (IOException e) { throw new Exception("Si è verificato un errore. Prego riprovare", e); }

            try
            {
                XmlDocument doc = new XmlDocument();
                FileStream stream = new FileStream(filepath, FileMode.Open);
                doc.Load(stream);
                
                Model.Poster tempPoster = new Model.Poster(null,null,null,null);
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
                        XmlElement desc = (XmlElement)descList[0];
                        tempPoster.setDescrizione(desc.InnerText);
                        XmlNodeList contList = x.GetElementsByTagName("Contenuto");
                        List<Model.Contenuto> tempCont = new List<Model.Contenuto>();
                        for (int j = 0; j < contList.Count; j++)
                        {
                            XmlElement y = (XmlElement)x.GetElementsByTagName("Contenuto")[j];
                            Model.Contenuto c = new Model.Contenuto(null,null,null,null,null);
                            c.setNomeContenuto(y.GetAttribute("Nome"));
                            c.setAudioPath(y.GetAttribute("AudioPath"));
                            c.setVideoPath(y.GetAttribute("VideoPath"));
                            c.setImagePath(y.GetAttribute("ImagePath"));
                            c.setTextPath(y.GetAttribute("TextPath"));
                            String temp = y.GetAttribute("Cella");
                            int[] coord = new int[2];
                            coord[0] = Convert.ToInt32(temp.Substring(0, 1));
                            coord[1] = Convert.ToInt32(temp.Substring(1, 1));
                            c.setCoordinate(coord);
                            tempCont.Add(c);
                        }
                        tempPoster.setContenuti(tempCont);
                    }
                }
                stream.Close();
                return tempPoster;
            }
            catch (XmlException e) { throw new Exception("Si è verificato un errore. Prego riprovare", e); }
        }
        public List<Model.Poster> getListaPoster() {

            try
            {
                if (!(Directory.Exists(dirpath)))
                {
                    Directory.CreateDirectory(dirpath);
                }
                if (!File.Exists(filepath)) 
                {
                    CreateElencoPoster();
                    //throw new Exception("Il file non esiste!"); 
                }
            }
            catch (IOException e) { throw new Exception("Si è verificato un errore. Prego riprovare", e); }

            try
            {
                XmlDocument doc = new XmlDocument();
                FileStream stream = new FileStream(filepath, FileMode.Open);
                doc.Load(stream);
                List<Model.Poster> tempPos = new List<Model.Poster>();
                XmlNodeList posList = doc.GetElementsByTagName("Poster");
                for (int i = 0; i < posList.Count; i++)
                {
                    XmlElement x = (XmlElement)doc.GetElementsByTagName("Poster")[i];
                    Model.Poster pos = new Model.Poster("", "", "", "");
                    pos.setNome(x.GetAttribute("Nome"));
                    pos.setUsername(x.GetAttribute("idUtente"));
                    pos.setNomeGriglia(x.GetAttribute("idGriglia"));
                    XmlNodeList descList = x.GetElementsByTagName("Descrizione");
                    XmlElement desc = (XmlElement)descList[0];
                    pos.setDescrizione(desc.InnerText);
                    tempPos.Add(pos);
                }
                stream.Close();
                return tempPos;
            }
            catch (XmlException e) { throw new Exception("Si è verificato un errore. Prego riprovare", e); }
        }
        public bool removePoster(String nomePoster) {

            try
            {
                if (!(Directory.Exists(dirpath)))
                {
                    Directory.CreateDirectory(dirpath);
                }
                if (!File.Exists(filepath)) 
                {
                    CreateElencoPoster();
                    //throw new Exception("Il file non esiste!"); 
                }
            }
            catch (IOException e) { throw new Exception("Si è verificato un errore. Prego riprovare", e); }

            try
            {
                XmlDocument doc = new XmlDocument();
                FileStream stream = new FileStream(filepath, FileMode.Open);
                doc.Load(stream);
                XmlNodeList list = doc.GetElementsByTagName("Poster");
                int counter=0;
                for (int i = 0; i < list.Count; i++)
                {
                    XmlElement rm = (XmlElement)doc.GetElementsByTagName("Poster")[i];
                    if (rm.GetAttribute("Nome") == nomePoster)
                    {
                        doc.DocumentElement.RemoveChild(rm);
                        counter++;//se alla fine=1 ho rimosso qualcosa
                    }
                }
                if (counter == 0) { Console.Write("Non esiste questo poster!"); stream.Close(); return false; }
                stream.Close();
                doc.Save(filepath);
                return true;
            }
            catch (XmlException e) { throw new Exception("Si è verificato un errore. Prego riprovare", e); }
        }

        public bool existPoster(String nomePoster)
        {
            try
            {
                if (!(Directory.Exists(dirpath)))
                {
                    Directory.CreateDirectory(dirpath);
                }
                if (!File.Exists(filepath)) 
                {
                    CreateElencoPoster();
                    //throw new Exception("Il file non esiste!"); 
                }
            }
            catch (IOException e) { throw new Exception("Si è verificato un errore. Prego riprovare", e); }

            try
            {
                XmlDocument doc = new XmlDocument();
                FileStream stream = new FileStream(filepath, FileMode.Open);
                doc.Load(stream);
                ////controllo nome gia esistente
                XmlNodeList l = doc.GetElementsByTagName("Poster");
                for (int k = 0; k < l.Count; k++)
                {
                    XmlElement xel = (XmlElement)l[k];
                    if (xel.GetAttribute("Nome") == nomePoster)
                    {
                        stream.Close();
                        return true;
                    }
                }
                stream.Close();
                return false;
            }
            catch (XmlException e) { throw new Exception("Si è verificato un errore. Prego riprovare", e); }
        }
        
    }
}

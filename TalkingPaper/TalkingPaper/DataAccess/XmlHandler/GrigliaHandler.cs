using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Collections;

namespace TalkingPaper.DataAccess
{
    class GrigliaHandler
    {
        String filepath = "./Data/Griglie.xml";

        //crea il file
        public void CreateGriglieTaggate()
        {
            try
            {
                XmlTextWriter writer = new XmlTextWriter(filepath, Encoding.UTF8);
                writer.WriteStartDocument();
                writer.WriteStartElement("GriglieTaggate");
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
            }
            catch (XmlException e) { throw new Exception("Errore xml", e); }
        }
        public bool setGriglia(Model.Griglia gr)
        {
            try
            {
                if (!File.Exists(filepath)) CreateGriglieTaggate();
            }
            catch (IOException e) { throw new Exception("Errore di I/O su file", e); }

            try
            {
                //String ID = "Generare un id per la griglia, magari casuale";//////////////////
                XmlDocument doc = new XmlDocument();
                FileStream stream = new FileStream(filepath, FileMode.Open);
                doc.Load(stream);
                ////controllo nome gia esistente
                XmlNodeList l = doc.GetElementsByTagName("Griglia");
                for (int k = 0; k < l.Count; k++) {
                    XmlElement x = (XmlElement)l[k];
                    if (x.GetAttribute("Nome") == gr.getNome())
                    {
                        stream.Close();
                        return false;
                    }
                }
                XmlElement el = doc.CreateElement("Griglia");
                el.SetAttribute("Nome", gr.getNome());
                el.SetAttribute("Righe", gr.getNumRighe().ToString());
                el.SetAttribute("Colonne", gr.getNumColonne().ToString());
                List<String> tempTags = gr.getListaTag();
                for (int i = 0; i < tempTags.Count; i++)
                {
                    if (tempTags[i] != "")
                    {
                        XmlElement cella = (XmlElement)doc.CreateElement("Cella");
                        cella.SetAttribute("Coordinate", gr.getCoordFromIndex(i));
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
            catch (XmlException e) { throw new Exception("Errore xml", e); }
        }
        

        //utile?
        /*public void RemoveGriglia(String idGriglia, String filepath)
        {
            try
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
            catch (XmlException e) { Console.Write(e.StackTrace); }
        }*/

        public List<Model.Griglia> getListaGriglie()
        {
            try
            {
                if (!File.Exists(filepath)) 
                { 
                    CreateGriglieTaggate();
                    throw new Exception("Il file non esiste!"); 
                }
            }
            catch (IOException e) { throw new Exception("Errore di I/O su file", e); }

            try
            {
                XmlDocument doc = new XmlDocument();
                FileStream stream = new FileStream(filepath, FileMode.Open);
                doc.Load(stream);
                List<Model.Griglia> tempGr = new List<Model.Griglia>();
                XmlNodeList grList = doc.GetElementsByTagName("Griglia");
                for (int i = 0; i < grList.Count; i++)
                {
                    XmlElement x = (XmlElement)doc.GetElementsByTagName("Griglia")[i];
                    Model.Griglia gr = new Model.Griglia("", 0, 0);
                    gr.setNome(x.GetAttribute("Nome"));
                    int r = Convert.ToInt32(x.GetAttribute("Righe"));
                    int c = Convert.ToInt32(x.GetAttribute("Colonne"));
                    gr.setNumRighe(r);
                    gr.setNumColonne(c);
                    tempGr.Add(gr);
                }
                stream.Close();
                return tempGr;
            }
            catch (XmlException e) { throw new Exception("Errore xml", e); }
        }
        public Model.Griglia getGriglia(String nome)
        {
            try
            {
                if (!File.Exists(filepath)) 
                {
                    CreateGriglieTaggate();
                    throw new Exception("Il file non esiste!"); 
                }
            }
            catch (IOException e) { throw new Exception("Errore di I/O su file", e); }

            try
            {
                XmlDocument doc = new XmlDocument();
                FileStream stream = new FileStream(filepath, FileMode.Open);
                doc.Load(stream);
                Model.Griglia tempGr = new Model.Griglia("", 0, 0);
                XmlNodeList grList = doc.GetElementsByTagName("Griglia");
                for (int i = 0; i < grList.Count; i++)
                {
                    XmlElement x = (XmlElement)doc.GetElementsByTagName("Griglia")[i];
                    if (x.GetAttribute("Nome") == nome)
                    {
                        tempGr.setNome(x.GetAttribute("Nome"));
                        int r = Convert.ToInt32(x.GetAttribute("Righe"));
                        int c = Convert.ToInt32(x.GetAttribute("Colonne"));
                        tempGr.setNumRighe(r);
                        tempGr.setNumColonne(c);
                        XmlNodeList celleList = x.GetElementsByTagName("Cella");
                        List<String> tags = new List<string>(r * c);
                        //inizializzo la lista a stringhe vuote
                        for (int k = 0; k < r*c; k++) { tags.Add(""); }

                            for (int j = 0; j < celleList.Count; j++)
                            {
                                //////cercare le coord e metterci li il valore
                                XmlElement y = (XmlElement)x.GetElementsByTagName("Cella")[j];
                                String tempCoo = y.GetAttribute("Coordinate");
                                int index = tempGr.getIndexFromCoord(tempCoo);
                                tags[index] = y.InnerText;//ma le coordinate nn le ripassso piu???
                            }
                        tempGr.setListaTag(tags);
                    }
                }
                stream.Close();
                return tempGr;
            }
            catch (XmlException e) { throw new Exception("Errore xml", e); }
        }

    }
}

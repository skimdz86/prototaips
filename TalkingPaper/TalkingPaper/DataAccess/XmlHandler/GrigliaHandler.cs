﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Collections;
using TalkingPaper.Common;

namespace TalkingPaper.DataAccess
{
    class GrigliaHandler
    {
        String dirpath = Global.directoryPrincipale + @"/Data/";
        String filepath = Global.directoryPrincipale + @"/Data/Griglie.xml";

        /// <summary>
        /// Crea il file XML contentente le griglie
        /// </summary>
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
            catch (XmlException e) { throw new Exception("Si è verificato un errore. Prego riprovare", e); }
        }
        /// <summary>
        /// Salva la griglia nel file XML
        /// </summary>
        /// <param name="griglia">E' un oggetto che contiene tutte le informazioni sulla griglia</param>
        /// <returns>True se non ci sono stati errori</returns>
        public bool setGriglia(Model.Griglia gr)
        {
            try
            {
                /*Crea il file XML e la directory se non esistono*/
                if (!(Directory.Exists(dirpath)))
                {
                    Directory.CreateDirectory(dirpath);
                }
                if (!File.Exists(filepath)) CreateGriglieTaggate();
            }
            catch (IOException e) { throw new Exception("Si è verificato un errore. Prego riprovare", e); }

            try
            {
                //L'id della griglia è il suo nome
                XmlDocument doc = new XmlDocument();
                FileStream stream = new FileStream(filepath, FileMode.Open);
                doc.Load(stream);
                ////controllo nome gia esistente
                XmlNodeList l = doc.GetElementsByTagName("Griglia");
                for (int k = 0; k < l.Count; k++) {
                    XmlElement x = (XmlElement)l[k];
                    if (x.GetAttribute("Nome") == gr.getNome())
                    {
                        doc.DocumentElement.RemoveChild(x);
                        
                    }
                }
                XmlElement el = doc.CreateElement("Griglia");
                el.SetAttribute("Nome", gr.getNome());
                el.SetAttribute("Righe", gr.getNumRighe().ToString());
                el.SetAttribute("Colonne", gr.getNumColonne().ToString());
                List<String> tempTags = gr.getListaTag();
                //creo nell'xml una lista di delle contenente ognuna le coordinate e il tag rfid associato
                for (int i = 0; i < tempTags.Count; i++)
                {
                    if (tempTags[i] != "")
                    {
                        XmlElement cella = (XmlElement)doc.CreateElement("Cella");
                        cella.SetAttribute("Coordinate", gr.getCoordFromIndex(i)[0].ToString() + gr.getCoordFromIndex(i)[1].ToString());
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
            catch (XmlException e) { throw new Exception("Si è verificato un errore. Prego riprovare", e); }
        }



        /// <summary>
        /// Ottiene la lista delle griglie presenti
        /// </summary>
        /// <returns>Lista di oggetti di tipo Griglia</returns>
        public List<Model.Griglia> getListaGriglie()
        {
            try
            {
                /*Crea il file XML e la directory se non esistono*/
                if (!(Directory.Exists(dirpath)))
                {
                    Directory.CreateDirectory(dirpath);
                }
                if (!File.Exists(filepath)) 
                { 
                    CreateGriglieTaggate(); 
                }
            }
            catch (IOException e) { throw new Exception("Si è verificato un errore. Prego riprovare", e); }

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
            catch (XmlException e) { throw new Exception("Si è verificato un errore. Prego riprovare", e); }
        }
        /// <summary>
        /// Ottiene l'oggetto griglia
        /// </summary>
        /// <param name="nomeGriglia"></param>
        /// <returns></returns>
        public Model.Griglia getGriglia(String nome)
        {
            try
            {
                /*Crea il file XML e la directory se non esistono*/
                if (!(Directory.Exists(dirpath)))
                {
                    Directory.CreateDirectory(dirpath);
                }
                if (!File.Exists(filepath)) 
                {
                    CreateGriglieTaggate();
                    //throw new Exception("Il file non esiste!"); 
                }
            }
            catch (IOException e) { throw new Exception("Si è verificato un errore. Prego riprovare", e); }

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
                                //////cerco le coordinate e le inserisco negli elementi della lista
                                XmlElement y = (XmlElement)x.GetElementsByTagName("Cella")[j];
                                String tempString = y.GetAttribute("Coordinate");
                                int[] coord = new int[2] { Convert.ToInt32(tempString.Substring(0, 1)), Convert.ToInt32(tempString.Substring(1, 1)) };
                                int index = tempGr.getIndexFromCoord(coord);
                                tags[index] = y.InnerText;
                            }
                        tempGr.setListaTag(tags);
                    }
                }
                stream.Close();
                return tempGr;
            }
            catch (XmlException e) { throw new Exception("Si è verificato un errore. Prego riprovare", e); }
        }

    }
}

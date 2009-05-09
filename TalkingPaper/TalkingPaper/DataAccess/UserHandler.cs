using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace TalkingPaper.DataAccess
{
    class UserHandler 
    {
        String filepath = "../../Data/Users.xml";

        //crea il file
        public bool CreateListaUtenti()
        {
            try
            {
                XmlTextWriter writer = new XmlTextWriter(filepath, Encoding.UTF8);
                writer.WriteStartDocument();
                writer.WriteStartElement("ListaUtenti");
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
                bool b = createAdmin();
                if (b) return true;
                else return false;
            }
            catch (XmlException e) { Console.Write(e.StackTrace); return false; }
        }
        public bool createAdmin(){
            try
            {
                XmlDocument doc = new XmlDocument();
                FileStream stream = new FileStream(filepath, FileMode.Open);
                doc.Load(stream);
                XmlElement el = doc.CreateElement("Utente");
                el.SetAttribute("Login", "admin");
                el.SetAttribute("Password", "admin");
                //el.SetAttribute("Classe", IDClasse);
                el.SetAttribute("FlagAmministratore", "Si");//tipo account è si/no
                doc.DocumentElement.AppendChild(el);
                stream.Close();
                doc.Save(filepath);
                return true;
            }
            catch (XmlException e) { return false; }
        }
        //ereditata
        public bool registraUtente(String login, String password)
        {
            try
            {
                if (!File.Exists(filepath)) CreateListaUtenti();
            }
            catch (IOException e) { return false; }
            
            try
            {
                XmlDocument doc = new XmlDocument();
                FileStream stream = new FileStream(filepath, FileMode.Open);
                doc.Load(stream);
                ////controllo nome gia esistente
                XmlNodeList l = doc.GetElementsByTagName("Utente");
                for (int i = 0; i < l.Count; i++)
                {
                    XmlElement x = (XmlElement)l[i];
                    if (x.GetAttribute("Login") == login)
                    {
                        stream.Close();
                        return false;
                    }
                }
                XmlElement el = doc.CreateElement("Utente");
                el.SetAttribute("Login", login);
                el.SetAttribute("Password", password);
                //el.SetAttribute("Classe", IDClasse);
                el.SetAttribute("FlagAmministratore", "No");//tipo account è si/no
                doc.DocumentElement.AppendChild(el);
                stream.Close();
                doc.Save(filepath);
                return true;
            }
            catch (XmlException e) { return false; }
        }
        ////da vedere se serve
        public bool RemoveUtente(String login, String filepath)
        {
            try
            {
                if (!File.Exists(filepath)) CreateListaUtenti();
            }
            catch (IOException e) { return false; }
            
            try
            {
                XmlDocument doc = new XmlDocument();
                FileStream stream = new FileStream(filepath, FileMode.Open);
                doc.Load(stream);
                XmlNodeList list = doc.GetElementsByTagName("Utente");
                for (int i = 0; i < list.Count; i++)
                {
                    XmlElement rm = (XmlElement)doc.GetElementsByTagName("Utente")[i];
                    if (rm.GetAttribute("Login") == login)
                    {
                        doc.DocumentElement.RemoveChild(rm);
                    }
                }
                stream.Close();
                doc.Save(filepath);
                return true;
            }
            catch (XmlException e) { return false; }
        }
        ////autentica
        public bool autenticaUtente(String login, String password)
        {
            try
            {
                if (!File.Exists(filepath)) { Console.Write("Il file non esiste!Lo creo"); CreateListaUtenti(); }
            }
            catch (IOException e) { return false; }

            try
            {
                Boolean flag = false;
                XmlDocument doc = new XmlDocument();
                FileStream stream = new FileStream(filepath, FileMode.Open);
                doc.Load(stream);
                XmlNodeList loginList = doc.GetElementsByTagName("Utente");
                for (int i = 0; i < loginList.Count; i++)
                {
                    XmlElement temp = (XmlElement)doc.GetElementsByTagName("Utente")[i];
                    if (temp.GetAttribute("Login") == login && temp.GetAttribute("Password") == password)
                    {
                        flag = true;
                    }
                }
                stream.Close();
                return flag;
            }
            catch (XmlException e) { return false; }
        }
        //listautenti
        public List<Model.User> getListaUtenti()
        {
            try
            {
                if (!File.Exists(filepath)) { Console.Write("Il file non esiste!Lo creo"); CreateListaUtenti(); }
            }
            catch (IOException e) { return null; }

            try
            {
                XmlDocument doc = new XmlDocument();
                FileStream stream = new FileStream(filepath, FileMode.Open);
                doc.Load(stream);
                List<Model.User> temp = new List<Model.User>();
                XmlNodeList utList = doc.GetElementsByTagName("Utente");
                bool tempFlag = false;
                for (int i = 0; i < utList.Count; i++)
                {
                    XmlElement x = (XmlElement)doc.GetElementsByTagName("Utente")[i];
                    Model.User ut = new Model.User("", "", false);
                    ut.setUsername(x.GetAttribute("Login"));
                    // ut.setQualcosa(x.GetAttribute("Classe"));
                    if (x.GetAttribute("FlagAmministratore") == "Si") tempFlag = true;
                    ut.setFlagAdmin(tempFlag);
                    //penso che la password pero non debba vederla
                    temp.Add(ut);
                }
                stream.Close();
                return temp;
            }
            catch (XmlException e) { return null; }
        }
        //verifica admin
        public bool isAdmin(String username) {
            
            try
            {
                if (!File.Exists(filepath)) { Console.Write("Il file non esiste!Lo creo"); CreateListaUtenti(); }
            }
            catch (IOException e) { return false; }

            try
            {
                XmlDocument doc = new XmlDocument();
                FileStream stream = new FileStream(filepath, FileMode.Open);
                doc.Load(stream);
                XmlNodeList utList = doc.GetElementsByTagName("Utente");
                for (int i = 0; i < utList.Count; i++)
                {
                    XmlElement x = (XmlElement)doc.GetElementsByTagName("Utente")[i];
                    if (x.GetAttribute("Login") == username)
                    {
                        if (x.GetAttribute("FlagAmministratore") == "Si")
                        {
                            stream.Close();
                            return true;
                        }
                        else
                        {
                            stream.Close();
                            return false;
                        }
                    }
                }
                stream.Close();
                return false;
            }
            catch (XmlException e) { return false; }
        }
    }
}

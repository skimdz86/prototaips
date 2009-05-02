using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace TalkingPaper.DataAccess
{
    class UserHandler : GeneralDataHandler
    {
        String filepath = "../../Data/Users.xml";

        //crea il file
        public void CreateListaUtenti()
        {
            XmlTextWriter writer = new XmlTextWriter(filepath, Encoding.UTF8);
            writer.WriteStartDocument();
            writer.WriteStartElement("ListaUtenti");
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }
        //ereditata
        public bool registraUtente(String login, String password)
        {
            XmlDocument doc = new XmlDocument();
            FileStream stream = new FileStream(filepath, FileMode.Open);
            doc.Load(stream);
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
        ////da vedere se serve
        public void RemoveUtente(String login, String filepath)
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
        }
        ////autentica
        public bool autenticaUtente(String login, String password)
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
            return flag;
        }
        //listautenti
        public List<User> getListaUtenti()
        { 
            XmlDocument doc = new XmlDocument();
            FileStream stream = new FileStream(filepath, FileMode.Open);
            doc.Load(stream);
            List<User> temp = new List<User>();
            XmlNodeList utList = doc.GetElementsByTagName("Utente");
            bool tempFlag = false;
            for (int i = 0; i < utList.Count; i++)
            {
                XmlElement x = (XmlElement)doc.GetElementsByTagName("Utente")[i];
                User ut = new User("","",false);
                ut.setUsername(x.GetAttribute("Login"));
               // ut.setQualcosa(x.GetAttribute("Classe"));
                if (x.GetAttribute("FlagAmministratore") == "Si") tempFlag = true;
                ut.setFlagAdmin(tempFlag);
                //penso che la password pero non debba vederla
                temp.Add(ut);
            }
            return temp;
        }
        //verifica admin
        public bool isAdmin(String username) {
            XmlDocument doc = new XmlDocument();
            FileStream stream = new FileStream(filepath, FileMode.Open);
            doc.Load(stream);
            XmlNodeList utList = doc.GetElementsByTagName("Utente");
            for (int i = 0; i < utList.Count; i++)
            {
                XmlElement x = (XmlElement)doc.GetElementsByTagName("Utente")[i];
                if (x.GetAttribute("Login") == username) {
                    if (x.GetAttribute("FlagAmministratore") == "Si") return true;
                    else return false;
                }
            }
            return false;
        }
    }
}

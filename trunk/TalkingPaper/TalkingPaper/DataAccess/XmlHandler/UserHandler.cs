using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Security.Cryptography;
using TalkingPaper.Common;

namespace TalkingPaper.DataAccess
{
    class UserHandler 
    {
        String dirpath = Global.directoryPrincipale + @"/Data/";
        String filepath = Global.directoryPrincipale + @"/Data/Users.xml";
        String backupPath = Global.directoryPrincipale + @"/backup.dat";

        /// <summary>
        /// crea il file XML che contiene gli utenti
        /// </summary>
        /// <returns>True se non ci sono stati errori</returns>
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
                if (b) 
                return true;
                else return false;
            }
            catch (XmlException e) { throw new Exception("Errore nella creazione del file utenti", e); }
        }
        /// <summary>
        /// Crea un amministratore nel file XML nel caso non sia presente prendendo i dati da un file di backup o assegnando un account di default
        /// </summary>
        /// <returns></returns>
        public bool createAdmin(){
            try
            {
                String user="";
                String res="";
                /*apro file di backup e estraggo i dati*/
                if (File.Exists(backupPath))
                {
                    XmlDocument docB = new XmlDocument();
                    FileStream streamB = new FileStream(backupPath, FileMode.Open);
                    docB.Load(streamB);
                    XmlNodeList l = docB.GetElementsByTagName("Admin");
                    user = ((XmlElement)l[0]).GetAttribute("Login");
                    res = ((XmlElement)l[0]).GetAttribute("Password");
                    streamB.Close();
                }
                else { user = "admin"; res = "admin"; } //se non esiste il backup

                /*scrivo i dati dell'admin nell'xml degli utenti*/
                XmlDocument doc = new XmlDocument();
                FileStream stream = new FileStream(filepath, FileMode.Open);
                doc.Load(stream);
                XmlElement el = doc.CreateElement("Utente");
                el.SetAttribute("Login", user);
                el.SetAttribute("Password", res);
                el.SetAttribute("FlagAmministratore", "Si");
                doc.DocumentElement.AppendChild(el);
                stream.Close();
                doc.Save(filepath);
                return true;
            }
            catch (XmlException e) { throw new Exception("Si è verificato un errore. Prego riprovare", e); }
        }
        /// <summary>
        /// Registra l'utente
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>True se non ci sono stati errori</returns>
        public bool registraUtente(String login, String password)
        {
            try
            {
                /*Verifica se esistono file e directory*/
                if (!(Directory.Exists(dirpath)))
                {
                    Directory.CreateDirectory(dirpath);
                }
                if (!File.Exists(filepath)) CreateListaUtenti();
            }
            catch (IOException e) { throw new Exception("Si è verificato un errore. Prego riprovare", e); }
            
            try
            {
                XmlDocument doc = new XmlDocument();
                FileStream stream = new FileStream(filepath, FileMode.Open);
                doc.Load(stream);
                ////crittografo la password con MD5
                MD5 md5 = new MD5CryptoServiceProvider();
                Byte[] original = ASCIIEncoding.Default.GetBytes(password);
                Byte[] encoded = md5.ComputeHash(original);
                String res = BitConverter.ToString(encoded);
                ////controllo se nome gia esistente
                XmlNodeList l = doc.GetElementsByTagName("Utente");
                for (int i = 0; i < l.Count; i++)
                {
                    XmlElement x = (XmlElement)l[i];
                    if (x.GetAttribute("Login") == login)
                    {
                        stream.Close();
                        throw new Exception("Esiste già un utente con questo nome");
                    }
                }
                XmlElement el = doc.CreateElement("Utente");
                el.SetAttribute("Login", login);
                el.SetAttribute("Password", res);
                el.SetAttribute("FlagAmministratore", "No");
                doc.DocumentElement.AppendChild(el);
                stream.Close();
                doc.Save(filepath);
                return true;
            }
            catch (XmlException e) { throw new Exception("Si è verificato un errore. Prego riprovare", e); }
        }
        /// <summary>
        /// Rimuove un utente dall'XML dato lo username
        /// </summary>
        /// <param name="login">Username</param>
        /// <returns>True se non ci sono stati errori</returns>
        public bool RemoveUtente(String login)
        {
            try
            {
                if (!(Directory.Exists(dirpath)))
                {
                    Directory.CreateDirectory(dirpath);
                }
                if (!File.Exists(filepath)) CreateListaUtenti();
            }
            catch (IOException e) { throw new Exception("Si è verificato un errore. Prego riprovare", e); }
            
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
            catch (XmlException e) { throw new Exception("Si è verificato un errore. Prego riprovare", e); }
        }
        /// <summary>
        /// Verifica l'autenticazione dell'utente
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>True se autenticato</returns>
        public bool autenticaUtente(String login, String password)
        {
            try
            {
                /*Se non esistono creo file e directory*/
                if (!(Directory.Exists(dirpath)))
                {
                    Directory.CreateDirectory(dirpath);
                }
                if (!File.Exists(filepath)) { CreateListaUtenti(); }
            }
            catch (IOException e) { throw new Exception("Si è verificato un errore. Prego riprovare", e); }

            try
            {
                Boolean flag = false;
                XmlDocument doc = new XmlDocument();
                FileStream stream = new FileStream(filepath, FileMode.Open);
                doc.Load(stream);
                //crittografo la password in MD5 per confrontarla con quella nel file XML
                MD5 md5 = new MD5CryptoServiceProvider();
                Byte[] original = ASCIIEncoding.Default.GetBytes(password);
                Byte[] encoded = md5.ComputeHash(original);
                String res = BitConverter.ToString(encoded);

                XmlNodeList loginList = doc.GetElementsByTagName("Utente");
                for (int i = 0; i < loginList.Count; i++)
                {
                    XmlElement temp = (XmlElement)doc.GetElementsByTagName("Utente")[i];
                    if (temp.GetAttribute("Login") == login && temp.GetAttribute("Password") == res)//confronto login e la password criptata
                    {
                        flag = true;
                    }
                }
                stream.Close();
                return flag;
            }
            catch (XmlException e) { throw new Exception("Si è verificato un errore. Prego riprovare", e); }
        }
        /// <summary>
        /// Ricava la lista di utenti registrati
        /// </summary>
        /// <returns>Lista di utenti</returns>
        public List<Model.User> getListaUtenti()
        {
            try
            {
                /*Se non esistono creo file e directory*/
                if (!(Directory.Exists(dirpath)))
                {
                    Directory.CreateDirectory(dirpath);
                }
                if (!File.Exists(filepath)) { CreateListaUtenti(); }
            }
            catch (IOException e) { throw new Exception("Si è verificato un errore. Prego riprovare", e); }

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
                    if (x.GetAttribute("FlagAmministratore") == "Si") tempFlag = true;
                    ut.setFlagAdmin(tempFlag);
                    temp.Add(ut);
                }
                stream.Close();
                return temp;
            }
            catch (XmlException e) { throw new Exception("Si è verificato un errore. Prego riprovare", e); }
        }
        /// <summary>
        /// Verifica se l'utente è amministratore dopo aver verificato l'autenticazione
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>True se amministratore</returns>
        public bool isAdmin(String username) {
            
            try
            {
                /*Se non esistono creo file e directory*/
                if (!(Directory.Exists(dirpath)))
                {
                    Directory.CreateDirectory(dirpath);
                }
                if (!File.Exists(filepath)) { CreateListaUtenti(); }
            }
            catch (IOException e) { throw new Exception("Si è verificato un errore. Prego riprovare", e); }

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
            catch (XmlException e) { throw new Exception("Si è verificato un errore. Prego riprovare", e); }
        }
    }
}

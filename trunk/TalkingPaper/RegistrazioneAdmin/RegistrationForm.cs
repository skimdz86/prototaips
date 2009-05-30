using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Security.Cryptography;

namespace RegistrazioneAdmin
{
    public partial class RegistrationForm : FormSchema
    {

        String filepath = "";
        String backup = "";

        public RegistrationForm(string installDirectory)
        {
            InitializeComponent();
            if ((installDirectory == null) || (installDirectory.Equals("")))
            {
                MessageBox.Show("Errore nella lettura dei parametri di installazione");
                return;
            }
            filepath = installDirectory + @"\Data\Users.xml";
            backup = installDirectory + @"\backup.dat";

        }

        

        private void ok_Click(object sender, EventArgs e)
        {
            if (!(user.Text.Equals("")) && !(password.Text.Equals("")) && !(verificaPass.Text.Equals("")))
            {
                if (password.Text == verificaPass.Text)
                {

                    if (registration(user.Text, password.Text, filepath))
                    {
                        MessageBox.Show("L'amministratore "+user.Text+" è stato registrato con successo!");
                        this.Close();
                    }
                    else
                    {
                        user.Clear();
                        password.Clear();
                        verificaPass.Clear();
                        MessageBox.Show("C'è stato un errore! E' necessario reinserire i dati");
                    }
                }
                else
                {
                    password.Clear();
                    verificaPass.Clear();
                    MessageBox.Show("Le password non coincidono!");
                }
            }
            else
            {
                MessageBox.Show("E' necessario riempire tutti i campi");
            }
        }

        /// <summary>
        /// Funzione che salva i dati amministratore sull'xml degli utenti e salva anche un file di backup
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public bool registration(String user, String password, String filepath)
        {

            try
            {
                if (File.Exists(filepath))
                {
                    File.Delete(filepath);

                }
                
                /*Salvataggio nel file XML*/
                XmlTextWriter writer = new XmlTextWriter(filepath, Encoding.UTF8);
                writer.WriteStartDocument();
                writer.WriteStartElement("ListaUtenti");
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();

                XmlDocument doc = new XmlDocument();
                FileStream stream = new FileStream(filepath, FileMode.Open);
                doc.Load(stream);
                /*crittografia della password*/
                MD5 md5 = new MD5CryptoServiceProvider();
                Byte[] original = ASCIIEncoding.Default.GetBytes(password);
                Byte[] encoded = md5.ComputeHash(original);
                String res = BitConverter.ToString(encoded);

                XmlElement el = doc.CreateElement("Utente");
                el.SetAttribute("Login", user);
                el.SetAttribute("Password", res);
                el.SetAttribute("FlagAmministratore", "Si");
                doc.DocumentElement.AppendChild(el);
                stream.Close();
                doc.Save(filepath);

                /*scrivo un file di backup con nome admin e password*/
                if (File.Exists(backup))
                {
                    File.Delete(backup);
                }
                XmlTextWriter backWriter = new XmlTextWriter(backup, Encoding.UTF8);
                backWriter.WriteStartDocument();
                backWriter.WriteStartElement("Backup");
                backWriter.WriteEndElement();
                backWriter.WriteEndDocument();
                backWriter.Close();

                XmlDocument doc2 = new XmlDocument();
                FileStream stream2 = new FileStream(backup, FileMode.Open);
                doc2.Load(stream2);
                XmlElement el2 = doc2.CreateElement("Admin");
                el2.SetAttribute("Login", user);
                el2.SetAttribute("Password", res);
                doc2.DocumentElement.AppendChild(el2);
                stream2.Close();
                doc2.Save(backup);

                return true;
            }
            catch (XmlException e) { throw new Exception("Si è verificato un errore!", e); }

        }

        private void help_Click(object sender, EventArgs e)
        {
            HelpFormSchema helpForm = new HelpFormSchema("E' possibile chiudere la finestra senza registrare un nuovo amministratore. In questo caso, ne verrà creato uno di default, con nome utente \"admin\" e password \"admin\". In seguito non sarà più possibile registrare un nuovo amministratore se non reinstallando il programma, quindi è consigliata la registrazione immediata.");
            NavigationControl.showDialog(helpForm);
        }

        
    }
}

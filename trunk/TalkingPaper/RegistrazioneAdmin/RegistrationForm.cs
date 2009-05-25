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

        public RegistrationForm(string installDirectory)
        {
            InitializeComponent();
            if ((installDirectory == null) || (installDirectory.Equals("")))
            {
                MessageBox.Show("Errore nella lettura dei parametri di installazione");
                return;
            }
            filepath = installDirectory + @"\Data\Users.xml";
            MessageBox.Show(filepath);

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

        public bool registration(String user, String password, String filepath)
        {

            try
            {
                if (File.Exists(filepath))
                {
                    File.Delete(filepath);

                }
                XmlTextWriter writer = new XmlTextWriter(filepath, Encoding.UTF8);
                writer.WriteStartDocument();
                writer.WriteStartElement("ListaUtenti");
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();

                XmlDocument doc = new XmlDocument();
                FileStream stream = new FileStream(filepath, FileMode.Open);
                doc.Load(stream);
                //aggiunta crittografia
                MD5 md5 = new MD5CryptoServiceProvider();
                Byte[] original = ASCIIEncoding.Default.GetBytes(password);
                Byte[] encoded = md5.ComputeHash(original);
                String res = BitConverter.ToString(encoded);

                XmlElement el = doc.CreateElement("Utente");
                el.SetAttribute("Login", user);
                el.SetAttribute("Password", res);
                //el.SetAttribute("Classe", IDClasse);
                el.SetAttribute("FlagAmministratore", "Si");//tipo account è si/no
                doc.DocumentElement.AppendChild(el);
                stream.Close();
                doc.Save(filepath);
                return true;
            }
            catch (XmlException e) { throw new Exception("Errore xml", e); }

        }

        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using RFIDlibrary;
using NHibernate;
using NHibernate.Cfg;
using QuartzTypeLib;
using System.Xml;


namespace TalkingPaper
{
    public partial class NuovoAmministratore : Form
    {
        private FormAmministrazione amministrazione;
        private ArrayList iscritti = new ArrayList();
        private string directoryprincipale;

        public NuovoAmministratore(FormAmministrazione amministrazione,string directoryprincipale)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 80, false);
            this.amministrazione = amministrazione;
            this.directoryprincipale = directoryprincipale;
            //directoryprincipale = Directory.GetCurrentDirectory();
            textBox1.Focus();
            button1.Cursor = Cursors.Hand;
            button2.Cursor = Cursors.Hand;
        }

        private void LeggiAmministratori()
        {
            try
            {
                string nome_file = directoryprincipale + "UtentiAmministratori" + ".xml";
                XmlTextReader iscritto = new XmlTextReader(nome_file);
                //bool fine = false;
                //int i = 1;
                //int j = 1;
                while ((iscritto.Read()))
                {
                    if (iscritto.NodeType == XmlNodeType.Element)
                    {
                        if (iscritto.LocalName.Equals("User"))
                        {
                            string user = iscritto.ReadString();
                            iscritti.Add(user);
                        }
                        if (iscritto.LocalName.Equals("Password"))
                        {
                            string psw = iscritto.ReadString();
                            iscritti.Add(psw);
                        }
                    }
                }
                iscritto.Close();
            }
            catch
            {
                //esiste = false;
            }
        }

        private void ScriviAmministratori (string u, string p){
            try
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.NewLineOnAttributes = true;
                XmlWriter wr = XmlWriter.Create(directoryprincipale + "UtentiAmministratori" + ".xml");
                wr.WriteStartDocument();
                wr.WriteStartElement("Amministratori");
                wr.WriteStartElement("Utente");
                wr.WriteStartElement("User");
                wr.WriteString(textBox1.Text);
                wr.WriteEndElement();
                wr.WriteStartElement("Password");
                wr.WriteString(maskedTextBox1.Text);
                wr.WriteEndElement();
                wr.WriteEndElement();
                for (int i = 0; i < iscritti.Count;i=i+2)
                {
                    wr.WriteStartElement("Utente");
                    wr.WriteStartElement("User");
                    wr.WriteString((string)iscritti[i]);
                    wr.WriteEndElement();
                    wr.WriteStartElement("Password");
                    wr.WriteString((string)iscritti[i+1]);
                    wr.WriteEndElement();
                    wr.WriteEndElement();
                }
                wr.WriteEndElement();
                //wr.WriteEndElement();
                wr.WriteEndDocument();
                wr.Flush();
                wr.Close();
            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            amministrazione.Visible = true;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if ((textBox1.Text == null) || (textBox1.Text.CompareTo("") == 0)) {
                MessageBox.Show("Non hai inserito lo user");
            }
            else if ((maskedTextBox1.Text == null) || (maskedTextBox1.Text.CompareTo("") == 0)) {
                MessageBox.Show("Non hai inserito la password");
            }
            else if ((maskedTextBox2.Text == null) || (maskedTextBox2.Text.CompareTo("") == 0))
            {
                MessageBox.Show("Devi confermare la password");
            }
            else if (maskedTextBox1.Text.CompareTo(maskedTextBox2.Text) != 0)
            {
                MessageBox.Show("I due campi password non corrispondono");
            }
            else {
                bool user_presente = false;
                LeggiAmministratori();
                for (int i = 0; i < iscritti.Count; i = i + 2) {
                    if (((string)iscritti[i]).CompareTo(textBox1.Text) == 0) {
                        user_presente = true;
                    }
                }
                if (user_presente == true)
                {
                    MessageBox.Show("Questo user è già utilizzato da un altro utente");
                }
                else {
                    ScriviAmministratori(textBox1.Text, maskedTextBox1.Text);
                    amministrazione.Visible = true;
                    this.Cursor = Cursors.Default;
                    this.Close();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void NuovoAmministratore_Load(object sender, EventArgs e)
        {
            button1.setAlignment(true);
            button2.setAlignment(true);
        }

    }
}
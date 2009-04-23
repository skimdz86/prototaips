using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
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
    public partial class LoginAdmin : Form
    {
        private Welcome partenza;
        private string directory_principale;
        private ArrayList iscritti = new ArrayList();
        
        public LoginAdmin(Welcome partenza, string directory_principale)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 60, false);
            this.partenza = partenza;
            this.directory_principale = directory_principale;
            button1.Cursor = Cursors.Hand;
            button3.Cursor = Cursors.Hand;
        }

        private void LoginAdmin_Load(object sender, EventArgs e)
        {
            button1.setAlignment(true);
            button3.setAlignment(true);
        }

        private void LeggiAmministratori()
        {
            try
            {
                string nome_file = directory_principale + "UtentiAmministratori" + ".xml";
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
            }
            catch
            {
                //esiste = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == null) || (textBox1.Text.CompareTo("") == 0))
            {
                this.Enabled = false;
                MessageBox.Show("Non hai inserito lo user");
                this.Enabled = true;
            }
            else if ((maskedTextBox1.Text == null) || (maskedTextBox1.Text.CompareTo("") == 0))
            {
                this.Enabled = false;
                MessageBox.Show("Non hai inserito la password");
                this.Enabled = true;
            }
            else
            {
                bool ok = false;
                LeggiAmministratori();
                for (int i = 0; i < iscritti.Count; i++)
                {
                    if (((string)iscritti[i]).CompareTo(textBox1.Text) == 0)
                    {
                        if (((string)iscritti[i + 1]).CompareTo(maskedTextBox1.Text) == 0)
                        {
                            ok = true;
                        }
                    }
                }
                if (ok == false)
                {
                    this.Enabled = false;
                    MessageBox.Show("I dati inseriti non corrispondono a nessun utente");
                    this.Enabled = true;
                }
                else if (ok == true)
                {
                    this.Cursor = Cursors.WaitCursor;
                    FormAmministrazione n = new FormAmministrazione(partenza, textBox1.Text, directory_principale);
                    n.Show();
                    //textBox1.Text = null;
                    //maskedTextBox1.Text = null;
                    this.Close();
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            partenza.Visible = true;
            this.Cursor = Cursors.Default;
            this.Close();
        }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TalkingPaper.Common;

namespace TalkingPaper.Welcome
{
    public partial class IndexForm : FormSchema
    {
        public IndexForm()
        {
            InitializeComponent();
            
            NavigationControl.setWelcome(this);
        }

        private void EsciButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            String user = textBox1.Text;
            String password = textBox2.Text;
            if (!(user.Equals("")) && !(password.Equals("")))
            {
                if (Global.dataHandler.autenticaUtente(user, password))
                {
                    textBox1.Clear();
                    textBox2.Clear();

                    if (Global.dataHandler.isAdmin(user))
                    {
                        Administration.AdminHomeForm adminHome = new Administration.AdminHomeForm(user);
                        NavigationControl.goTo(this, adminHome);
                    }
                    else
                    {
                        ChildHomeForm child = new ChildHomeForm();
                        NavigationControl.goTo(this, child);
                    }
                }
                else
                {
                    MessageBox.Show("I dati inseriti non sono corretti");
                }
            }
            else
            {
                MessageBox.Show("Devi inserire un nome utente ed una password");
            }
            
            
        }

        private void RegistrazioneButton_Click(object sender, EventArgs e)
        {
            RegistrationForm reg = new RegistrationForm();
            NavigationControl.goTo(this, reg);
        }

    }
}

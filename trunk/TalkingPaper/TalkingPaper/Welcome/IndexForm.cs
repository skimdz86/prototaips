using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TalkingPaper.Common;
using TalkingPaper.ControlLogic;


namespace TalkingPaper.Welcome
{
    public partial class IndexForm : FormSchema
    {
        private int isConfigured;

        public IndexForm()
        {
            InitializeComponent();
            
            NavigationControl.setWelcome(this);
            
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            String user = textBox1.Text;
            String password = textBox2.Text;
            LoginControl logc = new LoginControl();
            
            /*Autenticazione dell'utente o dell'amministratore*/
            if (Global.isNotEmpty(user) && Global.isNotEmpty(password))
            {
                String res = logc.login(user, password);
                if (res == "admin") 
                {
                    textBox1.Clear();
                    textBox2.Clear();
                    Administration.AdminHomeForm adminHome = new Administration.AdminHomeForm(user, isConfigured);
                    NavigationControl.goTo(this, adminHome);
                }
                else if (res == "utente")
                {
                    textBox1.Clear();
                    textBox2.Clear();
                    /*if (!(isConfigured))
                    {
                        MessageBox.Show("Il lettore non è configurato! Non puoi entrare");
                    }*/
                    //else
                    //{
                        Welcome.ChildHomeForm childHome = new ChildHomeForm();
                        NavigationControl.goTo(this, childHome);
                    //}
                }
                else 
                {
                    textBox2.Clear();
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

        private void esci_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void IndexForm_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                /*Prova l'autoconfigurazione del lettore RFID*/
                isConfigured = Global.reader.configure();
                if (isConfigured <= 0)
                {
                    erroreRfid.Visible = true;
                    config.Visible = true;
                    messaggioOK.Visible = false;
                    multiPorta.Visible = false;
                }
                else if (isConfigured > 1)
                {
                    erroreRfid.Visible = false;
                    config.Visible = false;
                    messaggioOK.Visible = false;
                    multiPorta.Visible = true;
                }
                else
                {
                    erroreRfid.Visible = false;
                    config.Visible = false;
                    messaggioOK.Visible = false;
                    multiPorta.Visible = false;
                }
            }
        }

        private void config_Click(object sender, EventArgs e)
        {
            /*Autoconfigurazione del lettore*/
            isConfigured = Global.reader.configure();
            if (isConfigured <= 0)
            {
                erroreRfid.Visible = true;
                config.Visible = true;
                messaggioOK.Visible = false;
            }
            else
            {
                erroreRfid.Visible = false;
                config.Visible = false;
                messaggioOK.Visible = true;
            }
            
            
            
        }

        private void help_Click(object sender, EventArgs e)
        {
            HelpFormSchema helpForm = new HelpFormSchema("Per entrare come amministratore, inserire il nome da amministratore nel campo \"Nome Classe\" e la password di amministratore nel campo \"Parola Chiave\".");
            NavigationControl.showDialog(helpForm);
        }

    }
}

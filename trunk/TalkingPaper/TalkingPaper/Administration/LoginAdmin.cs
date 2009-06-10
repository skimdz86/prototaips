using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TalkingPaper.Common;
using TalkingPaper.ControlLogic;


namespace TalkingPaper.Administration
{
    public partial class LoginAdmin : FormSchema
    {
        private int isConfigured;

        public LoginAdmin(int isConfigured)
        {
            InitializeComponent();
            this.isConfigured = isConfigured;
            
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
                else 
                {
                    textBox1.Clear();
                    textBox2.Clear();
                    MessageBox.Show("I dati inseriti non sono corretti");
                }
                
            }
            else
            {
                MessageBox.Show("Devi inserire un nome utente ed una password");
            }
            
            
        }

        private void home_Click(object sender, EventArgs e)
        {
            NavigationControl.goWelcome(this);
        }

        private void help_Click(object sender, EventArgs e)
        {
            HelpFormSchema helpForm = new HelpFormSchema("Inserendo nome e password dell'amministratore è possibile accedere alla sezione di gestione delle griglie e di eliminazione dei cartelloni. Se per caso il nome e la password non funzionassero, provare con quelli di default, cioè nome utente:\"admin\" e password:\"admin\"");
            NavigationControl.showDialog(helpForm);
        }

    }
}

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
    public partial class RegistrationForm : FormSchema
    {
        ControlLogic.LoginControl logc; 

        public RegistrationForm()
        {
            InitializeComponent();

            logc = new ControlLogic.LoginControl();

        }

        private void annulla_Click(object sender, EventArgs e)
        {
            NavigationControl.goBack(this);
        }

        private void ok_Click(object sender, EventArgs e)
        {
            if (!(user.Text.Equals("")) && !(password.Text.Equals("")) && !(verificaPassword.Text.Equals("")))
            {
                if (password.Text == verificaPassword.Text)
                {

                    if (logc.registration(user.Text, password.Text))//effettua la registrazione
                    {
                        MessageBox.Show("Ti sei registrato con successo!");
                        ChildHomeForm child=new ChildHomeForm();
                        NavigationControl.goTo(this, child);
                    }
                    else
                    {
                        user.Clear();
                        password.Clear();
                        verificaPassword.Clear();
                        MessageBox.Show("C'è stato un errore! E' necessario reinserire i dati");
                    }
                }
                else
                {
                    password.Clear();
                    verificaPassword.Clear();
                    MessageBox.Show("Le password non coincidono! Reinserirle prego");
                }
            }
            else
            {
                MessageBox.Show("E' necessario riempire tutti i campi");
            }
        }

        private void home_Click(object sender, EventArgs e)
        {
            NavigationControl.goWelcome(this);
        }

        private void help_Click(object sender, EventArgs e)
        {
            HelpFormSchema helpForm = new HelpFormSchema("Devi inserire due volte la stessa parola chiave per essere sicuro di non aver commesso errori.");
            NavigationControl.showDialog(helpForm);
        }
    }
}

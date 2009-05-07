﻿using System;
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
        public IndexForm()
        {
            InitializeComponent();
            
            NavigationControl.setWelcome(this);
            if (!(Global.reader.configure()))
            {
                erroreRfid.Visible = true;
            }
        }

        private void EsciButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            String user = textBox1.Text;
            String password = textBox2.Text;
            LoginControl logc = new LoginControl();
            
            /////////////////////autenticazione
            if (!(user.Equals("")) && !(password.Equals("")))
            {
                String res = logc.login(user, password);
                if (res == "admin") 
                {
                    textBox1.Clear();
                    textBox2.Clear();
                    Administration.AdminHomeForm adminHome = new Administration.AdminHomeForm(user);
                    NavigationControl.goTo(this, adminHome);
                }
                else if (res == "utente")
                {
                    textBox1.Clear();
                    textBox2.Clear();
                    Administration.AdminHomeForm adminHome = new Administration.AdminHomeForm(user);
                    NavigationControl.goTo(this, adminHome);
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

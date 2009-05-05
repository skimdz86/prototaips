using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TalkingPaper.Welcome
{
    public partial class IndexForm : Form
    {
        private ControlLogic.AdministrationControl control;

        public IndexForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            global.welcome = this;
            control = new ControlLogic.AdministrationControl();
        }

        private void mainButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mainButton3_Click(object sender, EventArgs e)
        {
            //ChildHomeForm child = new ChildHomeForm();
            //control.goTo(this, child);
            Administration.AdminHomeForm adminHome = new Administration.AdminHomeForm("massi");
            control.goTo(this,adminHome);
        }

        private void mainButton1_Click(object sender, EventArgs e)
        {
            RegistrationForm reg = new RegistrationForm();
            control.goTo(this, reg);
        }

    }
}

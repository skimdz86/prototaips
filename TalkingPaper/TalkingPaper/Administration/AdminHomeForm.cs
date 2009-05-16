using System.Windows.Forms;
using System;
using TalkingPaper.Common;

namespace TalkingPaper.Administration
{
    public partial class AdminHomeForm : FormSchema
    {
        private ControlLogic.AdministrationControl control;
               
        public AdminHomeForm(string user,bool isConfigured)
        {
            InitializeComponent();
            control = new ControlLogic.AdministrationControl();
            NavigationControl.setHome(this);
            
            label1.Text = label1.Text + " " + user;

            if (!(isConfigured))
            {
                configRfid.Visible = true;
                groupBox1.Visible = true;
            //    nuovaGriglia.Enabled = false;
            //    modificaGriglia.Enabled = false;


            }
        }
        
        private void logout_Click(object sender, EventArgs e)
        {
            NavigationControl.goWelcome(this);
        }

        private void nuovaGriglia_Click(object sender, EventArgs e)
        {
            NuovaGrigliaForm nuovaGriglia = new NuovaGrigliaForm();
            NavigationControl.goTo(this, nuovaGriglia);
        }

        private void modificaGriglia_Click(object sender, EventArgs e)
        {
            ListaGriglieForm listaGriglie = new ListaGriglieForm();
            NavigationControl.goTo(this, listaGriglie);
        }

        private void EliminaPoster_Click(object sender, EventArgs e)
        {
            EliminaPosterForm eliminaPoster = new EliminaPosterForm();
            NavigationControl.goTo(this, eliminaPoster);
        }

        private void configRfid_Click(object sender, EventArgs e)
        {
            RfidConfigForm rfidConf = new RfidConfigForm();
            NavigationControl.goTo(this, rfidConf);
        }

        

    }
}
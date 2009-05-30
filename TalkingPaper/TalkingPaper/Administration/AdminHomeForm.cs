using System.Windows.Forms;
using System;
using TalkingPaper.Common;

namespace TalkingPaper.Administration
{
    public partial class AdminHomeForm : FormSchema
    {
        private ControlLogic.AdministrationControl control;
               
        public AdminHomeForm(string user,int isConfigured)
        {
            try
            {
                InitializeComponent();
                control = new ControlLogic.AdministrationControl();
                NavigationControl.setHome(this);

                //Auto centramento della label di benvenuto in base alla dimensione del nome amministratore
                int dimensione = benvenuto.Size.Width;
                benvenuto.Text = benvenuto.Text + " " + user;
                benvenuto.Left -= (benvenuto.Size.Width - dimensione) / 2;

                /*se il lettore non è configurato appare il bottone per la configurazione manuale*/
                if (isConfigured > 1)
                {
                    configRfid.Visible = true;
                    groupBoxRfid.Visible = true;
                    //    nuovaGriglia.Enabled = false;
                    //    modificaGriglia.Enabled = false;


                }
                else
                {
                    configRfid.Visible = false;
                    groupBoxRfid.Visible = false;

                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
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

        private void help_Click(object sender, EventArgs e)
        {
            HelpFormSchema helpForm = new HelpFormSchema("");
            NavigationControl.showDialog(helpForm);
        }

        

    }
}
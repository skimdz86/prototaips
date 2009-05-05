using System.Windows.Forms;
using System;
using TalkingPaper.Common;

namespace TalkingPaper.Administration
{
    public partial class AdminHomeForm : Common.FormSchema
    {
        private ControlLogic.AdministrationControl control;
               
        public AdminHomeForm(string user)
        {
            InitializeComponent();
            control = new ControlLogic.AdministrationControl();
            NavigationControl.setHome(this);
            
            label1.Text = label1.Text + " " + user;
            logout.Cursor = Cursors.Hand;
            EliminaPoster.Cursor = Cursors.Hand;
            nuovaGriglia.Cursor = Cursors.Hand;
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
            //creare la finestra elimina poster
        }

        

    }
}
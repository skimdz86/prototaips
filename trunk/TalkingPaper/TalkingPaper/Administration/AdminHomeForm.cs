using System.Windows.Forms;
using System;

namespace TalkingPaper.Administration
{
    public partial class AdminHomeForm : FormSchema
    {
        private ControlLogic.AdministrationControl control;
               
        public AdminHomeForm(string user)
        {
            InitializeComponent();
            control = new ControlLogic.AdministrationControl();
            control.setHome(this);
            
            label1.Text = label1.Text + " " + user;
            logout.Cursor = Cursors.Hand;
            EliminaPoster.Cursor = Cursors.Hand;
            nuovaGriglia.Cursor = Cursors.Hand;
        }
        
        private void logout_Click(object sender, EventArgs e)
        {
            control.goWelcome(this);
        }

        private void nuovaGriglia_Click(object sender, EventArgs e)
        {
            NuovaGrigliaForm nuovaGriglia = new NuovaGrigliaForm();
            control.goTo(this, nuovaGriglia);
        }

        private void modificaGriglia_Click(object sender, EventArgs e)
        {
            ModificaGrigliaForm modificaGriglia = new ModificaGrigliaForm();
            control.goTo(this, modificaGriglia);
        }

        private void EliminaPoster_Click(object sender, EventArgs e)
        {
            //creare la finestra elimina poster
        }

        

    }
}
using System;
using TalkingPaper.Common;
using System.Windows.Forms;

namespace TalkingPaper.Authoring
{
    public partial class NuovoCartelloneForm : FormSchema
    {
        
        public NuovoCartelloneForm()
        {
            InitializeComponent();
           
            
        }

        private void ok_Click(object sender, EventArgs e)
        {
            if ((Nome.Text == null) || (Nome.Text.Equals("")))
            {
                MessageBox.Show("Devi inserire un nome per il cartellone");
            }
            else if ((Descrizione.Text == null) || (Descrizione.Text.Equals("")))
            {
                MessageBox.Show("Devi inserire una descrizione per il cartellone");
            }
            else
            {
                ScegliGrigliaForm sc = new ScegliGrigliaForm(Nome.Text, Descrizione.Text, Classe.Text);
                NavigationControl.goTo(this, sc);
            }
        }

        private void home_Click(object sender, EventArgs e)
        {
            NavigationControl.goHome(this);
        }

        private void annulla_Click(object sender, EventArgs e)
        {
            NavigationControl.goBack(this);
        }
                
    }
}
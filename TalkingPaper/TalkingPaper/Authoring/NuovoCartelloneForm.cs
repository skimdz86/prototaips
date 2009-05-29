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
            if (Global.isEmpty(Nome.Text))
            {
                MessageBox.Show("Devi inserire un nome per il cartellone");
            }
            else if (Nome.Text.Length > 15) 
            {
                MessageBox.Show("Il nome può essere al massimo di 15 lettere o numeri");
            }
            else if (Global.isEmpty(Descrizione.Text))
            {
                MessageBox.Show("Devi inserire una descrizione per il cartellone");
            }
            else if (Descrizione.Text.Length > 50) 
            {
                MessageBox.Show("La descrizione può essere al massimo di 50 lettere o numeri");
            }
            else if (!Global.isEmpty(Classe.Text) && Classe.Text.Length > 5) 
            {
                MessageBox.Show("Il nome della classe può essere al massimo di 5 lettere o numeri");
            }
            else if (Global.dataHandler.existPoster(Nome.Text))
            {
                MessageBox.Show("Questo poster esiste già");
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

        private void help_Click(object sender, EventArgs e)
        {
            HelpFormSchema helpForm = new HelpFormSchema("Nome e descrizione del cartellone sono obbligatori, mentre il nome della classe che lo sta creando è facoltativo.");
            NavigationControl.showDialog(helpForm);
        }
                
    }
}
using System;
using TalkingPaper.Common;



namespace TalkingPaper.Welcome
{
    public partial class ChildHomeForm : FormSchema
    {
        public ChildHomeForm()
        {
            InitializeComponent();

            NavigationControl.setHome(this);
            
            
        }

        private void nuovoCartellone_Click(object sender, EventArgs e)
        {
           Authoring.NuovoCartelloneForm nuovoCart = new Authoring.NuovoCartelloneForm();
           NavigationControl.goTo(this, nuovoCart);
        }

        private void parlaSchema_Click(object sender, EventArgs e)
        {
            Execution.ElencoCartelloniForm elencoCartelloni = new Execution.ElencoCartelloniForm();
            NavigationControl.goTo(this,elencoCartelloni);
        }

        private void modificaCartellone_Click(object sender, EventArgs e)
        {
            Authoring.ModificaCartelloneForm modifica = new TalkingPaper.Authoring.ModificaCartelloneForm();
            NavigationControl.goTo(this, modifica);
        }

        private void home_Click(object sender, EventArgs e)
        {
            NavigationControl.goWelcome(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Execution.ListaPosterForm listaPoster = new Execution.ListaPosterForm();
            NavigationControl.goTo(this, listaPoster);
        }

        private void help_Click(object sender, EventArgs e)
        {
            HelpFormSchema helpForm = new HelpFormSchema("\"Fai parlare un cartellone\" serve a riprodurre suoni e video associati ad esso. \"Stampa i contenuti di un carteellone\" invece permette di stampare testi e immagini associate in precedenza");
            NavigationControl.showDialog(helpForm);
        }

        

    }
}
using System;
using System.Windows.Forms;
using TalkingPaper.Common;

namespace TalkingPaper.Administration
{
    public partial class QuestionEliminaPoster : Form
    {
        private string nomePoster;
        private ControlLogic.AdministrationControl control;
        
        public QuestionEliminaPoster(string nomePoster)
        {
            InitializeComponent();

            this.nomePoster = nomePoster;

            control = new ControlLogic.AdministrationControl();

        }

        private void ok_Click(object sender, EventArgs e)
        {
            if ((nomePoster != null) && !(nomePoster.Equals("")))
            {
                bool result;
                result = control.rimuoviPoster(nomePoster);
                if (result == false)
                {
                    throw new Exception("Impossibile eliminare il poster");
                }
                NavigationControl.goBack(this);
            }
            else
            {
                throw new Exception("Eccezione nella eliminazione del poster (nomePoster == null)");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NavigationControl.goBack(this);
        }


        
    }
}
using System;
using System.Windows.Forms;

namespace TalkingPaper.Common
{
    public partial class QuestionSchema : Form
    {
        Form form;
        string param;
        public QuestionSchema(string frase,Form form,string param)
        {
            InitializeComponent();
            this.form = form;
            this.param = param;
            if (!(form is Administration.EliminaPosterForm) && !(form is Execution.EsecuzioneCartelloneForm))
            {
                throw new Exception("Impossibile usare la dialog");
            }
            question.Text = frase;
        }

        private void ok_Click(object sender, EventArgs e)
        {
            if (form is Administration.EliminaPosterForm) {
                ((Administration.EliminaPosterForm)form).questionAnswer(param,"yes");
            }
            else if (form is Execution.EsecuzioneCartelloneForm)
            {
                ((Execution.EsecuzioneCartelloneForm)form).questionAnswer(param, "yes");
            }
            NavigationControl.closeDialog(this);
        }

        private void annulla_Click(object sender, EventArgs e)
        {
            if (form is Administration.EliminaPosterForm)
            {
                ((Administration.EliminaPosterForm)form).questionAnswer(param,"no");
            }
            NavigationControl.closeDialog(this);
        }
                     
    }
}
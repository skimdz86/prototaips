using System.Windows.Forms;
using System;
using TalkingPaper.Common;

namespace TalkingPaper.Administration
{
    public partial class NuovaGrigliaForm : Common.FormSchema
    {
        ControlLogic.AdministrationControl control;
        
        public NuovaGrigliaForm()
        {
            InitializeComponent();
            //RidimensionaForm n = new RidimensionaForm(this, 60, true);
            control = new ControlLogic.AdministrationControl();
            ok.Cursor = Cursors.Hand;
            annulla.Cursor = Cursors.Hand;
        }

        private void annulla_Click(object sender, EventArgs e)
        {
            NavigationControl.goBack(this);
        }

        private void ok_Click(object sender, EventArgs e)
        {
            Model.Griglia griglia;
            griglia = control.inizializzaGriglia(textBox1.Text, textBox2.Text, textBox3.Text);
            if (griglia != null)
            {
                TaggaGrigliaForm taggaGriglia = new TaggaGrigliaForm(griglia);
                NavigationControl.goTo(this, taggaGriglia);
            }
            else
            {
                throw new Exception("Impossibile inizializzare la griglia");
            }
        }
    }
}
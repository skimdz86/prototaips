using System.Windows.Forms;
using System;
using TalkingPaper.Common;

namespace TalkingPaper.Administration
{
    public partial class NuovaGrigliaForm : FormSchema
    {
        ControlLogic.AdministrationControl control;
        
        public NuovaGrigliaForm()
        {
            try
            {
                InitializeComponent();
                //RidimensionaForm n = new RidimensionaForm(this, 60, true);
                control = new ControlLogic.AdministrationControl();
                ok.Cursor = Cursors.Hand;
                annulla.Cursor = Cursors.Hand;
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        private void annulla_Click(object sender, EventArgs e)
        {
            NavigationControl.goBack(this);
        }

        private void ok_Click(object sender, EventArgs e)
        {
            try
            {
                /*eseguo i controlli sui vari campi di input*/
                if (Global.isEmpty(textBox2.Text))
                {
                    MessageBox.Show("Non hai inserito i tag presenti in una riga");
                }
                else if (Global.isEmpty(textBox3.Text))
                {
                    MessageBox.Show("Non hai inserito i tag presenti in una colonna");
                }
                else if (Global.isEmpty(textBox1.Text))
                {
                    MessageBox.Show("Non hai inserito il nome della nuova griglia");
                }
                else if (textBox1.Text.Length > 15) 
                {
                    MessageBox.Show("Il nome può essere al massimo di 15 lettere o numeri");
                }
                else
                {
                    int numeroRighe = 0;
                    int numeroColonne = 0;

                    try
                    {
                        numeroRighe = Int32.Parse(textBox2.Text);
                        numeroColonne = Int32.Parse(textBox3.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Errore! Le righe e le colonne devono essere dei numeri positivi");
                        return;
                    }

                    if (numeroColonne > 9)
                    {
                        MessageBox.Show("Le colonne possono essere al massimo 9");
                    }
                    else if (numeroRighe > 9)
                    {
                        MessageBox.Show("Le righe possono essere al massimo 9");
                    }
                    else if ((numeroRighe <= 0) || (numeroColonne <= 0))
                    {
                        MessageBox.Show("Errore! Le righe e le colonne devono essere dei numeri positivi");
                    }
                    else
                    {
                        /*Se i controlli hanno avuto successo creo la griglia*/
                        Model.Griglia griglia;
                        griglia = control.inizializzaGriglia(textBox1.Text, textBox2.Text, textBox3.Text);
                        if (griglia != null)
                        {
                            TaggaGrigliaForm taggaGriglia = new TaggaGrigliaForm(griglia);
                            NavigationControl.goTo(this, taggaGriglia);
                        }
                        else
                        {
                            MessageBox.Show("Impossibile inizializzare la griglia");
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void home_Click(object sender, EventArgs e)
        {
            NavigationControl.goHome(this);
        }

        private void help_Click(object sender, EventArgs e)
        {
            HelpFormSchema helpForm = new HelpFormSchema("Non è disponibile un aiuto per questa schermata");
            NavigationControl.showDialog(helpForm);
        }
    }
}
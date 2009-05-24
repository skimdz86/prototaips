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
                if ((textBox2.Text == null) || (textBox2.Text.Equals("")))
                {
                    MessageBox.Show("Non hai inserito i tag presenti in una riga");
                }
                else if ((textBox3.Text == null) || (textBox3.Text.Equals("")))
                {
                    MessageBox.Show("Non hai inserito i tag presenti in una colonna");
                }
                else if ((textBox1.Text == null) || (textBox1.Text.Equals("")))
                {
                    MessageBox.Show("Non hai inserito il nome della nuova griglia");
                }
                else
                {
                    int numeroRighe = 0;///////////////perche vuole che le assegno qui per forza??????
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
                        Model.Griglia griglia;
                        griglia = control.inizializzaGriglia(textBox1.Text, textBox2.Text, textBox3.Text);
                        if (griglia != null)
                        {
                            TaggaGrigliaForm taggaGriglia = new TaggaGrigliaForm(griglia);
                            NavigationControl.goTo(this, taggaGriglia);
                        }
                        else
                        {
                            //throw new Exception("Impossibile inizializzare la griglia");
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
    }
}
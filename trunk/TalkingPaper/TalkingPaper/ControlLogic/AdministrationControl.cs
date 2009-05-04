using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TalkingPaper.ControlLogic
{
    class AdministrationControl : NavigationControl
    {
        public Model.Griglia inizializzaGriglia(String nome,String righe,String colonne)
        {
            if (( righe == null) || (righe.Equals("")))
            {
                MessageBox.Show("Non hai inserito i tag presenti in una riga");
            }
            else if ((colonne == null) || (colonne.Equals("")))
            {
                MessageBox.Show("Non hai inserito i tag presenti in una colonna");
            }
            else if ((nome == null) || (nome.Equals("")))
            {
                MessageBox.Show("Non hai inserito il nome della nuova griglia");
            }
            else
            {
                int numeroRighe;
                int numeroColonne;
                
                try
                {
                    numeroRighe = Int32.Parse(righe);
                    numeroColonne = Int32.Parse(colonne);
                }
                catch {
                    MessageBox.Show("Errore! Le righe e le colonne devono essere dei numeri");
                    return null;
                }

                if (numeroColonne > 6)
                {
                    MessageBox.Show("Le colonne possono essere al massimo 6");
                }
                else if (numeroRighe > 6)
                {
                    MessageBox.Show("Le righe possono essere al massimo 6");
                }
                else
                {
                    Model.Griglia griglia = new Model.Griglia(nome,numeroRighe,numeroColonne);
                    return griglia;
                }
            }
            return null;
        }

        public void inizializzaTagging(Administration.TaggaGrigliaForm form,Reader.IReader reader)
        {
            reader = new Reader.DumbReader();

            int rfid_num = reader.connect();
            if (rfid_num <= 0)
            {
                //Qualcosa non ha funzionato
                MessageBox.Show("Errore di collegamento con il RFID Reader.\nControllare che sia correttamente collegato al computer\nTerminazione forzata del programma.", "ATTENZIONE",
MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                goBack(form);
                return;

            }
            form.inizializzaDataGrid();
        }


        public void salvaGriglia(Model.Griglia griglia,DataGridView grid)
        {
            List<string> tags = new List<string>(grid.ColumnCount * grid.RowCount);
            for (int i = 0; i < grid.RowCount; i++)
            {
                for (int j = 0; j < grid.ColumnCount; j++)
                {
                    tags.Add((string)grid[j,i].Value);
                }
            }
            griglia.setListaTag(tags);

            if (global.dataHandler != null)
            {
                global.dataHandler.setGriglia(griglia);
            }
            else
            {
                throw new Exception("global.dataHandler == null");
            }
        }
    }
}

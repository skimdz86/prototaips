using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace TalkingPaper.ControlLogic
{
    class AdministrationControl : NavigationControl
    {
        private ArrayList idInseriti = new ArrayList();

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

        public void inizializzaReader(Administration.TaggaGrigliaForm form,Reader.IReader reader)
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
        }


        public void salvaGriglia(Model.Griglia griglia,string[,] grid)
        {
            List<string> tags = new List<string>(grid.Length);
            for (int i = 0; i < grid.Length; i++)
            {
                tags.Add((string)grid.GetValue(i));
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

        public bool verificaId(string id)
        {
            for (int i = 0; i < idInseriti.Count; i++)
            {
                if (((String)idInseriti[i]).Equals(id))
                {
                    MessageBox.Show("Il Tag " + id + " è già stato inserito");
                    return false;
                }
            }
            return true;
        }

        public void addId(string id)
        {
            idInseriti.Add(id);
        }
    }
}

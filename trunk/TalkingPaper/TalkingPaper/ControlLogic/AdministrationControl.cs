using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using TalkingPaper.Common;
using System.Windows.Forms;

namespace TalkingPaper.ControlLogic
{
    class AdministrationControl
    {
        private ArrayList idInseriti = new ArrayList();
        
        private Form caller;
        String lastRead = "";

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

        public void inizializzaReader(Form caller)
        {
            Global.reader.readerStatusUpdate += statusUpdate;
            Global.reader.startRead();
            this.caller = caller;
        }

        public void statusUpdate(string id)
        {
            if (caller != null)
            {
                if (caller is Administration.TaggaGrigliaForm)
                    ((Administration.TaggaGrigliaForm)caller).rfid_StatusUpdateEvent(id);
                else if (caller is Administration.ModificaGrigliaForm)
                    ((Administration.ModificaGrigliaForm)caller).rfid_StatusUpdateEvent(id);

            }
        }

        public void salvaGriglia(Model.Griglia griglia,string[,] grid)
        {
            List<string> tags = new List<string>(grid.Length);
            
            foreach (string a in grid)
            {
                tags.Add(a);
            }

            
            griglia.setListaTag(tags);

            if (Global.dataHandler != null)
            {
                Global.dataHandler.setGriglia(griglia);
            }
            else
            {
                throw new Exception("global.dataHandler == null");
            }
        }

        public bool verificaId(string id)
        {
            if (id.Equals(lastRead)) return false;
            else lastRead = id;

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

        public void delId(string id)
        {
            idInseriti.Remove(id);
        }

        public List<Model.Griglia> leggiGriglie()
        {
            return Global.dataHandler.getListaGriglie();
        }

        public void stopReader()
        {
            Global.reader.readerStatusUpdate -= statusUpdate;
            Global.reader.close();
        }
        public Model.Griglia getGriglia(String nomeGriglia) 
        {
            return Global.dataHandler.getGriglia(nomeGriglia);
        }
        public List<Model.Poster> getListaPoster() 
        {
            return Global.dataHandler.getListaPoster();
        }
        public bool rimuoviPoster(String nomePoster) 
        {
            return Global.dataHandler.removePoster(nomePoster);
        }

        
    }
}

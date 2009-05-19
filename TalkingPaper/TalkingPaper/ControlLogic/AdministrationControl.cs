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
        int type = 0;
        private Form caller;
        String lastRead = "";

        public Model.Griglia inizializzaGriglia(String nome, String righe, String colonne)
        {
            Model.Griglia griglia = new Model.Griglia(nome, Convert.ToInt32(righe), Convert.ToInt32(colonne));
            return griglia;
        }

        public bool inizializzaReader(Form caller)
        {
            Global.reader.readerStatusUpdate += statusUpdate;
            bool result = Global.reader.startRead();
            lastRead = "";
            if (!result)
            {
                return false;
            }
            this.caller = caller;
            if (caller is Administration.TaggaGrigliaForm) type = 1;
            else if (caller is Administration.ModificaGrigliaForm) type = 2;
            return true;
        }

        public void statusUpdate(string id)
        {
            if (type == 1)
            {
                ((Administration.TaggaGrigliaForm)caller).rfid_StatusUpdateEvent(id);
            }
            else if (type == 2)
            {
                ((Administration.ModificaGrigliaForm)caller).rfid_StatusUpdateEvent(id);
            }
               
        }

        public void salvaGriglia(Model.Griglia griglia, string[,] grid)
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


        public void resetControlReader()
        {
            lastRead = "";
        }
    }
}

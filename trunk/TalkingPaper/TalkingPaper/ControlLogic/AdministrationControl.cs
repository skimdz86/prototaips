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

        public Model.Griglia inizializzaGriglia(String nome, String righe, String colonne)
        {
            Model.Griglia griglia = new Model.Griglia(nome, Convert.ToInt32(righe), Convert.ToInt32(colonne));
            return griglia;
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

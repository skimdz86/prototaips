using System;
using System.Collections.Generic;
using System.Text;
using TalkingPaper.Common;
using System.Windows.Forms;
using System.Collections;

namespace TalkingPaper.ControlLogic
{
    class ExecutionControl
    {
        Form caller;
        String lastRead = "";
        private ArrayList idInseriti = new ArrayList();

        public List<Model.Poster> getListaPoster()
        {
            return Global.dataHandler.getListaPoster();
        }

        public Model.Poster getPoster(String nomePoster)
        {
            return Global.dataHandler.getPoster(nomePoster);
        }

        public Model.Griglia getGriglia(String nomeGriglia)
        {
            return Global.dataHandler.getGriglia(nomeGriglia);
        }

        public bool inizializzaReader(Form caller)
        {
            Global.reader.readerStatusUpdate += statusUpdate;
            bool result = Global.reader.startRead();
            if (!result)
            {
                return false;
            }
            this.caller = caller;
            return true;
        }

        public void statusUpdate(string id)
        {
            if (caller != null)
            {
                if (caller is Execution.EsecuzioneCartelloneForm)
                    ((Execution.EsecuzioneCartelloneForm)caller).rfid_StatusUpdateEvent(id);
                else throw new Exception("Errore in ExecutionControl.statusUpdate");
            }
        }

        public void stopReader()
        {
            Global.reader.readerStatusUpdate -= statusUpdate;
            Global.reader.close();
        }
    }
}

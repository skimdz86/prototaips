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
        Timer resetLastRead;

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
            lastRead = "";
            resetLastRead = new Timer();
            resetLastRead.Interval = 5000;
            resetLastRead.Tick += reset;
            resetLastRead.Start();
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
            resetLastRead.Stop();
            Global.reader.close();
        }

        public Model.Contenuto getContenutoFromTag(String nomePoster, String tag)
        {
            return Global.dataHandler.getContenutoFromTag(nomePoster, tag);
        }

        public bool verificaId(string id)
        {
            if (id.Equals(lastRead)) return false;
            else lastRead = id;

            return true;
        }

        public void reset(object sender, EventArgs e)
        {
            lastRead = "";
        }
    }
}

using System;
using TalkingPaper.Common;
using System.Windows.Forms;
using System.Collections.Generic;

namespace TalkingPaper.ControlLogic
{
    class AdministrationControl
    {
        private List<String> idInseriti = new List<String>();
        int type = 0;
        private Form caller;
        String lastRead = "";

        /// <summary>
        /// Metodo per l'inizializzazione di un oggetto di tipo Griglia
        /// </summary>
        /// <param name="nome">Il nome della griglia</param>
        /// <param name="righe">Il numero di righe</param>
        /// <param name="colonne">Il numero di colonne</param>
        /// <returns></returns>
        public Model.Griglia inizializzaGriglia(String nome, String righe, String colonne)
        {
            Model.Griglia griglia = new Model.Griglia(nome, Convert.ToInt32(righe), Convert.ToInt32(colonne));
            return griglia;
        }

        /// <summary>
        /// Metodo per l'inizializzazione del reader. E' necessario fornire la form chiamante
        /// per poter attivare correttamente il delegato.
        /// </summary>
        /// <param name="caller"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Delegato che invoca il metodo per la gestione di un dato letto dal reader
        /// </summary>
        /// <param name="id"></param>
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

        /// <summary>
        /// Metodo per il salvataggio di un oggetto Griglia in memoria.
        /// </summary>
        /// <param name="griglia"></param>
        /// <param name="grid"></param>
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

        /// <summary>
        /// Metodo che controlla se un dato letto dal reader è nuovo o è una ripetizione
        /// di un dato già letto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Aggiunge una lettura ad un elenco
        /// </summary>
        /// <param name="id"></param>
        public void addId(string id)
        {
            idInseriti.Add(id);
        }

        /// <summary>
        /// Rimuove un dato letto da un elenco
        /// </summary>
        /// <param name="id"></param>
        public void delId(string id)
        {
            idInseriti.Remove(id);
        }

        /// <summary>
        /// Legge dalla base di dati la lista delle griglie salvate
        /// </summary>
        /// <returns></returns>
        public List<Model.Griglia> leggiGriglie()
        {
            return Global.dataHandler.getListaGriglie();
        }

        /// <summary>
        /// Termina la lettura dal reader
        /// </summary>
        public void stopReader()
        {
            Global.reader.close();
        }

        /// <summary>
        /// Metodo per ottenere una griglia specificandone il nome
        /// </summary>
        /// <param name="nomeGriglia"></param>
        /// <returns></returns>
        public Model.Griglia getGriglia(String nomeGriglia)
        {
            return Global.dataHandler.getGriglia(nomeGriglia);
        }

        /// <summary>
        /// Legge dalla base di dati la lista dei cartelloni salvati
        /// </summary>
        /// <returns></returns>
        public List<Model.Poster> getListaPoster()
        {
            return Global.dataHandler.getListaPoster();
        }

        /// <summary>
        /// Metodo per ottenere un cartellone specificandone il nome
        /// </summary>
        /// <param name="nomePoster"></param>
        /// <returns></returns>
        public Model.Poster getPoster(String nomePoster)
        {
            return Global.dataHandler.getPoster(nomePoster);
        }

        /// <summary>
        /// Metodo per salvare un cartellone nella base di dati
        /// </summary>
        /// <param name="poster"></param>
        /// <returns></returns>
        public bool salvaPoster(Model.Poster poster)
        {
            return Global.dataHandler.setPoster(poster);
        }

        /// <summary>
        /// Metodo per eliminare un cartellone dalla base di dati
        /// </summary>
        /// <param name="nomePoster"></param>
        /// <returns></returns>
        public bool rimuoviPoster(String nomePoster)
        {
            return Global.dataHandler.removePoster(nomePoster);
        }

        /// <summary>
        /// Resetta il controllo sull'ultimo valore letto dal reader
        /// </summary>
        public void resetControlReader()
        {
            lastRead = "";
        }
    }
}

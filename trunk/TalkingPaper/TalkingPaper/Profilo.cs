using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace TalkingPaper
{
    /**
     * Partecipa con lato 1 con Utente, e con RisorsaMultimediale N:M
     * */
    class Profilo
    {
        private int _iDprofilo;
        private string _descrizione;
        private string _nome;
        private IList _utenteLista;
        private IList _risorsaLista;


        public Profilo()
        {
        }

        public virtual int IDprofilo
        {
            get { return _iDprofilo; }
            set { _iDprofilo = value; }
        }

        public virtual string Descrizione
        {
            get { return _descrizione; }
            set { _descrizione = value; }
        }

        public virtual string Nome
        {
            get { return _nome; }
            set { _nome= value; }
        }


        public virtual IList UtenteLista
        {
            get { return _utenteLista; }
            set { _utenteLista = value; }
        }

        public virtual IList RisorsaLista
        {
            get { return _risorsaLista; }
            set { _risorsaLista = value; }
        }

    }
}

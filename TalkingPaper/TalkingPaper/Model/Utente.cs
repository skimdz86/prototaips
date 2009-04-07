using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace TalkingPaper
{
    /**
     * Tabella che ha relazione lato N con Utente
     * 
     * Partecipa anche con RisorsaMultimediale in una N:M
     * */
    class Utente
    {
        private int _iDutente;
        private string _nome;
        private string _cognome;
        private string _classe;
        private string _barcode;
        private string _rfidtag;
        private DateTime _annoNascita;
        private Profilo _profilo;

        public Utente()
        {
        }

        public virtual int IDutente
        {
            get { return _iDutente; }
            set { _iDutente = value; }
        }

        public virtual string Nome
        {
            get { return _nome; }
            set { _nome= value; }
        }

        public virtual string Cognome
        {
            get { return _cognome; }
            set { _cognome = value; }
        }
        public virtual string Classe
        {
            get { return _classe; }
            set { _classe = value; }
        }

        public virtual string Barcode
        {
            get { return _barcode; }
            set { _barcode = value; }
        }

        public virtual string Rfidtag
        {
            get { return _rfidtag; }
            set { _rfidtag = value; }
        }

        public virtual DateTime AnnoNascita
        {
            get { return _annoNascita; }
            set { _annoNascita = value; }
        }

        public virtual Profilo Profilo
        {
            get { return _profilo; }
            set { _profilo = value; }
        }


    }
}

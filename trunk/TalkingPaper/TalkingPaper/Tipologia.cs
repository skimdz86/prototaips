using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace TalkingPaper
{
    /**
     * Tabella N side con Contenuto
     * 
     * */
    class Tipologia
    {
        private int _iDtipologia;
        private string _descrizione;
        private string _tipo;
        private IList _contenutoLista;

        public Tipologia()
        {
        }

        public virtual int IDtipologia
        {
            get { return _iDtipologia; }
            set { _iDtipologia = value; }
        }

        public virtual string Descrizione
        {
            get { return _descrizione; }
            set { _descrizione = value; }
        }

        public virtual string Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        public virtual IList ContenutoLista
        {
            get { return _contenutoLista; }
            set { _contenutoLista = value; }
        }
    }
}

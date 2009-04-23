using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace TalkingPaper
{
    /*
     * Poster lato 1 con mostra ; lato N con Contenuto
     * */
 
     
    class Poster
    {
        private int _iDposter;
        private string _descrizione;
        private int _ordine;
        string _nome;
        private Mostra mostra;
        private IList _contenutoLista;

        public Poster()
        {}

        public virtual int IDposter
        {
            get { return _iDposter; }
            set { _iDposter = value; }
        }

        public virtual string Descrizione
        {
            get { return _descrizione; }
            set { _descrizione = value; }
        }

        public virtual int Ordine
        {
            get { return _ordine; }
            set { _ordine = value; }
        }


        public virtual string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public virtual Mostra Mostra
        {
            get { return mostra; }
            set { mostra = value; }
        }

        public virtual IList ContenutoLista
        {
            get { return _contenutoLista; }
            set { _contenutoLista = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace TalkingPaper
{
    /**
     * 
     * La tabella è lato 1 nelle relazione con Tipologia, RisorsaMultimediale, Poster.
     *  e partecipa alla N:M con Altrarisorsa
     * 
     * */
    class Contenuto
    {
        private int _iDcontenuto;
        private int _livello;
        private int _ordine;
        private Tipologia _tipo;
        private Risorsamultimediale _risorsaMultimediale;
        private Poster3 _poster;
        private string _barcode;
        private string _rfidtag;
        private string _nome;
        private IList _altrarisorsaLista;


        public Contenuto()
        {
        }

        public virtual int IDcontenuto
        {
            get { return _iDcontenuto; }
            set { _iDcontenuto = value; }
        }

        public virtual int Livello
        {
            get { return _livello; }
            set { _livello= value; }
        }

        public virtual int Ordine
        {
            get { return _ordine; }
            set { _ordine= value; }
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

        public virtual Tipologia Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        public virtual Risorsamultimediale RisorsaMultimediale
        {
            get { return _risorsaMultimediale; }
            set { _risorsaMultimediale = value; }
        }

        public virtual Poster3 Poster
        {
            get { return _poster; }
            set { _poster = value; }
        }

        public virtual string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }


        public virtual IList AltrarisorsaLista
        {
            get { return _altrarisorsaLista; }
            set { _altrarisorsaLista = value; }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace TalkingPaper
{
    /*
     * Tabella lato N, nella relazione con Poster
     * */
    public class Mostra
    {
        private int iDmostra;
        private string _nome;
        private string _autore;
        private string _credits;
        private DateTime _datainizio;
        private IList _posterLista;

        public Mostra()
        {}

        public virtual int IDmostra
        {
            get { return iDmostra; }
            set { iDmostra = value; }
        }

        public virtual string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public virtual string Autore
        {
            get { return _autore; }
            set { _autore = value; }
        }

        public virtual string Credits
        {
            get { return _credits; }
            set { _credits = value; }
        }
        
        public virtual DateTime DataInizio
        {
            get { return _datainizio; }
            set { _datainizio = value; }
        }
         

        public virtual IList PosterLista
        {
            get { return _posterLista; }
            set { _posterLista = value; }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace TalkingPaper
{
    /**
     * Tabella che partecipa lato N con Contenuto
     * Partecipa anche ad una N:M con Profilo
     * */
    class Risorsamultimediale
    {
        private int _iDrisorsa;
        private string _nome;
        private string _path;
        private string _estensione;
        private int _dimensione;
        private IList _contenutoLista;
        private IList _profiloLista;

        public Risorsamultimediale()
        {
        }

        public virtual int IDrisorsa
        {
            get { return _iDrisorsa; }
            set { _iDrisorsa = value; }
        }

        public virtual string Path
        {
            get { return _path; }
            set { _path= value; }
        }

        public virtual string Nome
        {
            get { return _nome; }
            set { _nome= value; }
        }

        public virtual string Estensione
        {
            get { return _estensione; }
            set { _estensione = value; }
        }

        public virtual int Dimensione
        {
            get { return _dimensione; }
            set { _dimensione = value; }
        }



        public virtual IList ContenutoLista
        {
            get { return _contenutoLista; }
            set { _contenutoLista = value; }
        }

        public virtual IList ProfiloLista
        {
            get { return _profiloLista; }
            set { _profiloLista = value; }
        }
    }
}

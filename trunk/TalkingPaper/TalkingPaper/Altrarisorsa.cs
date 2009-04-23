using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace TalkingPaper
{
    class Altrarisorsa
    {
        private int _iDaltra;
        private string _nome;
        private string _path;
        private string _tipo;
        private IList _contenutoLista;


        public virtual int IDaltra
        {
            get { return _iDaltra; }
            set { _iDaltra = value; }
        }

        public virtual string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public virtual string Path
        {
            get { return _path; }
            set { _path = value; }
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

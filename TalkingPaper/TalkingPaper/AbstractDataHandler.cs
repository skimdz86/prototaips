using System;
using System.Collections.Generic;
using System.Text;

namespace TalkingPaper
{
    abstract class AbstractDataHandler : DataHandlerInterface
    {

        #region DataHandlerInterface Membri di

        public bool autenticaUtente(String username, String password)
        {
            return false;
        }

        public bool isAdmin(String username)
        {
            return false;
        }

        public bool registraUtente(String username, String password)
        {
            return false;
        }

        public List<String> getListaUtenti()
        {
            return new List<String>();
        }

        public bool setGriglia(Griglia griglia)
        {
            return false;
        }

        public Griglia getGriglia(String nomeGriglia)
        {
            return new Griglia("",0,0);
        }

        public List<Griglia> getListaGriglia()
        {
            return new List<Griglia>();
        }

        public bool setPoster(Poster poster)
        {
            return false;
        }

        public Poster getPoster(String nomePoster)
        {
            return new Poster();
        }

        public List<Poster> getListaPoster()
        {
            return new List<Poster>();
        }

        #endregion
    }
}

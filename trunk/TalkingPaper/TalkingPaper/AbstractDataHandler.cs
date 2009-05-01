using System;
using System.Collections.Generic;
using System.Text;

namespace TalkingPaper
{
    class AbstractDataHandler : DataHandlerInterface
    {
        GrigliaHandler gr;
        UserHandler ut;
        PosterHandler pos;

        public AbstractDataHandler() {
            gr = new GrigliaHandler();
            ut = new UserHandler();
            pos = new PosterHandler();
        }
        
        #region DataHandlerInterface Membri di

        public bool autenticaUtente(String username, String password)
        {
            bool b=ut.autenticaUtente(username, password);
            return b;
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
            return new Poster("", "", "", null);
        }

        public List<Poster> getListaPoster()
        {
            return new List<Poster>();
        }

        #endregion
    }
}

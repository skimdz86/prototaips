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
            bool b = ut.isAdmin(username);
            return b;
        }

        public bool registraUtente(String username, String password)
        {
            bool b = ut.registraUtente(username, password);
            return b;
        }

        public List<User> getListaUtenti()
        {
            List<User> l = ut.getListaUtenti();
            return l;
        }

        public bool setGriglia(Griglia griglia)
        {
            bool b = gr.setGriglia(griglia);
            return b;
        }

        public Griglia getGriglia(String nomeGriglia)
        {
            Griglia g = gr.getGriglia(nomeGriglia);
            return g;
        }

        public List<Griglia> getListaGriglie()
        {
            List<Griglia> l = gr.getListaGriglie();
            return l;
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

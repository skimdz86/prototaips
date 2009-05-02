using System;
using System.Collections.Generic;
using System.Text;

namespace TalkingPaper.DataAccess
{
    class GeneralDataHandler : DataHandlerInterface
    {
        GrigliaHandler gr;
        UserHandler ut;
        PosterHandler pos;

        public GeneralDataHandler() {
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
            bool b = pos.setPoster(poster);
            return b;
        }

        public Poster getPoster(String nomePoster)
        {
            Poster p = pos.getPoster(nomePoster);
            return p;
        }

        public List<Poster> getListaPoster()
        {
            List<Poster> l = pos.getListaPoster();
            return l;
        }
        public bool removePoster(String nomePoster) 
        {
            bool b = pos.removePoster(nomePoster);
            return b;
        }

        #endregion
    }
}

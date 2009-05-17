using System;
using System.Collections.Generic;
using System.Text;

namespace TalkingPaper.DataAccess
{
    class XmlDataHandler : DataHandlerInterface
    {
        GrigliaHandler gr;
        UserHandler ut;
        PosterHandler pos;

        public XmlDataHandler() {
            gr = new GrigliaHandler();
            ut = new UserHandler();
            pos = new PosterHandler();
        }
        
        

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

        public List<Model.User> getListaUtenti()
        {
            List<Model.User> l = ut.getListaUtenti();
            return l;
        }

        public bool setGriglia(Model.Griglia griglia)
        {
            bool b = gr.setGriglia(griglia);
            return b;
        }

        public Model.Griglia getGriglia(String nomeGriglia)
        {
            Model.Griglia g = gr.getGriglia(nomeGriglia);
            return g;
        }

        public List<Model.Griglia> getListaGriglie()
        {
            List<Model.Griglia> l = gr.getListaGriglie();
            return l;
        }

        public bool setPoster(Model.Poster poster)
        {
            bool b = pos.setPoster(poster);
            return b;
        }

        public Model.Poster getPoster(String nomePoster)
        {
            Model.Poster p = pos.getPoster(nomePoster);
            return p;
        }

        public List<Model.Poster> getListaPoster()
        {
            List<Model.Poster> l = pos.getListaPoster();
            return l;
        }
        public bool removePoster(String nomePoster) 
        {
            bool b = pos.removePoster(nomePoster);
            return b;
        }
        public bool existPoster(String nomePoster) 
        {
            return pos.existPoster(nomePoster);
        }

    }
}

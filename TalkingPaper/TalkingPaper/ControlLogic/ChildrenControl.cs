using System;
using System.Collections.Generic;
using System.Text;
using TalkingPaper.Common;

namespace TalkingPaper.ControlLogic
{
    class ChildrenControl
    {
        public List<Model.Griglia> leggiGriglie()
        {
            return Global.dataHandler.getListaGriglie();
        }

        public Model.Griglia getGriglia(String nomeGriglia)
        {
            return Global.dataHandler.getGriglia(nomeGriglia);
        }
        public List<Model.Poster> getListaPoster()
        {
            return Global.dataHandler.getListaPoster();
        }
        public Model.Poster getPoster(String nomePoster) 
        {
            return Global.dataHandler.getPoster(nomePoster);
        }
        public bool salvaPoster(Model.Poster poster) 
        {
            return Global.dataHandler.setPoster(poster);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using TalkingPaper.Common;

namespace TalkingPaper.ControlLogic
{
    class AuthoringControl
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

        public int getIndexFromNomeContenuto(List<Model.Contenuto> lista, string nome)
        {
            int index;
            for (index = 0; index < lista.Count; index++)
            {
                if (lista[index].getNomeContenuto().Equals(nome)) return index;
            }
            return -1;
        }

        public string getStringCoordFromNumericCoord(int col, int row)
        {
            return ((char)('A' + col - 1)).ToString() + row.ToString();
        }

        public List<Model.Contenuto> getListWithUsefulContents(List<Model.Contenuto> listaCompleta)
        {
            List<Model.Contenuto> listaUtile = new List<Model.Contenuto>();
            for (int index = 0; index < listaCompleta.Count; index++)
            {
                if (listaCompleta[index].getCoordinate().Equals("00") == false)
                {
                    listaUtile.Add(listaCompleta[index]);
                }
            }
            return listaUtile;
        }

    }
}

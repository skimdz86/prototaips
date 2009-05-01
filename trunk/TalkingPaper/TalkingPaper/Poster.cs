using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace TalkingPaper
{
    class Poster
    {

        private String nomePoster;
        private String descrizione;
        private String username;
        private Griglia griglia;

        private int numRighe;
        private int numColonne;

        private List<Contenuto> contenuti;

        public Poster(String nome, String desc, String username, Griglia griglia)
        {
            this.nomePoster = nome;
            this.descrizione = desc;
            this.username = username;
            this.griglia = griglia;
            this.numRighe = griglia.getNumRighe();
            this.numColonne = griglia.getNumColonne();
            contenuti = new List<Contenuto>(numRighe * numColonne);
        }

        public String getNome() { return nomePoster; }
        public String getDescrizione() { return descrizione; }
        public String getUsernama() { return username; }
        public Griglia getGriglia() { return griglia; }

        // x appartiene a {A,B,..} e indica la coordinata verticale
        // y appartiene a {1,2,..} e indica la coordinata orizzontale
        //...funziona quindi come le matrici
        //ATTENZIONE: l'index parte da ZERO: A1 -> 0, A2 -> 1
        public int getIndexFromCoord(char x, char y)
        {
            int index = (x - 'A') * numColonne + (y - '1');
            return index;
        }

        //se è più comodo, si può fare getContenuto(x,y)
        public Contenuto getContenutoFromIndex(int index)
        {
            return contenuti[index];
        }

        public void setTag(Contenuto contenuto, int index)
        {
            contenuti[index] = contenuto;
        }

        public void delTag(int index)
        {
            contenuti[index] = null;
        }
        

    }
}

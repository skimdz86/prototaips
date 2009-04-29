using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace TalkingPaper
{
    class Griglia
    {
        private String nome;
        private int numRighe;
        private int numColonne;
        //bisogna scegliere come implementare la matrice (matrice o array lungo?)
        private ArrayList tagRFID;

        public Griglia(String nome, int numRighe, int numColonne)
        {
            this.nome = nome;
            this.numRighe = numRighe;
            this.numColonne = numColonne;
            tagRFID = new ArrayList();
        }

        public String getName() { return null; }
        public int getNumRighe() { return 0; }
        public int getNumColonne() { return 0; }
        
        public String getTag() { return null; }
        public void setTag() { }
        public void delTag() { }

        
        


    }
}

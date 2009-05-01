﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace TalkingPaper
{
    class Griglia
    {
        private String nomeGriglia;
        private int numRighe;
        private int numColonne;
        private List<String> tagRFID;

        public Griglia(String nome, int numRighe, int numColonne)
        {
            this.nomeGriglia = nome;
            this.numRighe = numRighe;
            this.numColonne = numColonne;
            tagRFID = new List<String>(numRighe*numColonne);
        }

        public String getNome() { return nomeGriglia; }
        public int getNumRighe() { return numRighe; }
        public int getNumColonne() { return numColonne; }

        public void setNome(String nome) { this.nomeGriglia = nome; }
        public void setNumRighe(int numRighe) { this.numRighe = numRighe; }
        public void setNumColonne(int numColonne) { this.numColonne = numColonne; }
        
        // x appartiene a {A,B,..} e indica la coordinata verticale
        // y appartiene a {1,2,..} e indica la coordinata orizzontale
        //...funziona quindi come le matrici
        //ATTENZIONE: l'index parte da ZERO: A1 -> 0, A2 -> 1
        public int getIndexFromCoord(char x, char y) 
        {
            int index = (x - 'A') * numColonne + (y - '1');
            return index;
        }

        
        // ATTENZIONE: NON L'HO ANCORA TESTATA
        public String getCoordFromIndex(int index)
        {
            char x, y;
            int offset = 'A';
            x = (char)((int)(index / numColonne) + offset);
            y = (char) ((index % numColonne) + '1');
            return x.ToString() + y.ToString();
        }
       

        //se è più comodo, si può fare getTag(x,y)
        public String getTagFromIndex(int index)
        {
            return tagRFID[index];
        }

        public void setTag(String tag, int index) 
        {
            tagRFID[index] = tag;
        }
        
        public void delTag(int index) 
        {
            tagRFID[index] = null;
        }

        
        


    }
}

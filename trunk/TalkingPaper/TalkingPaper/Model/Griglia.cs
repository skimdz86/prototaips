using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace TalkingPaper.Model
{
    public class Griglia
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
            tagRFID = null;
        }

        public String getNome() { return nomeGriglia; }
        public int getNumRighe() { return numRighe; }
        public int getNumColonne() { return numColonne; }
        public List<String> getListaTag() { return tagRFID; }

        public void setNome(String nome) { this.nomeGriglia = nome; }
        public void setNumRighe(int numRighe) { this.numRighe = numRighe; }
        public void setNumColonne(int numColonne) { this.numColonne = numColonne; }
        public void setListaTag(List<String> tagRFID) { this.tagRFID = tagRFID; }
        
        
        //ATTENZIONE: l'index parte da ZERO: 11 -> 0, 12 -> 1
        public int getIndexFromCoord(int[] coord) 
        {
            int index = (coord[0] - 1) * numColonne + (coord[1] - 1);
            return index;
        }

        public int[] getCoordFromIndex(int index)
        {
            int[] coord = new int[2] { (index / numColonne)+ 1, (index % numColonne)+1 };
            
            return coord;
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

        public string getTagFromNumericCoord(int row, int col)
        {
            col--;
            row--;
            return tagRFID[row * numColonne + col];
        }

        public int[] getCoordFromTag(string tag)
        {
            int[] coord = new int[2];
            int i = 0;
            int index = -1;
            foreach (string nomeTag in tagRFID) {
                if (nomeTag.Equals(tag))
                {
                    index = i;
                    break;
                }
                i++;
            }
            if (index == -1) return null;
            coord[0] = (index / numColonne) + 1;
            coord[1] = (index % numColonne) + 1;
            return coord;

        }

        
        


    }
}

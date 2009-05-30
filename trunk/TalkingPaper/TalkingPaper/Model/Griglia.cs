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

        /*Costruttore*/
        public Griglia(String nome, int numRighe, int numColonne)
        {
            this.nomeGriglia = nome;
            this.numRighe = numRighe;
            this.numColonne = numColonne;
            tagRFID = null;
        }

        /*Getters e setters*/

        public String getNome() { return nomeGriglia; }
        public int getNumRighe() { return numRighe; }
        public int getNumColonne() { return numColonne; }
        public List<String> getListaTag() { return tagRFID; }

        public void setNome(String nome) { this.nomeGriglia = nome; }
        public void setNumRighe(int numRighe) { this.numRighe = numRighe; }
        public void setNumColonne(int numColonne) { this.numColonne = numColonne; }
        public void setListaTag(List<String> tagRFID) { this.tagRFID = tagRFID; }
        
        /*Varie funzioni utili*/
        
        /// <summary>
        /// Converte le coordinate della matrice visibile in grafica in un indice per l'array di tag
        /// </summary>
        /// <param name="coord"></param>
        /// <returns></returns>
        public int getIndexFromCoord(int[] coord) 
        {
            //ATTENZIONE: l'index parte da ZERO: 11 -> 0, 12 -> 1
            int index = (coord[0] - 1) * numColonne + (coord[1] - 1);
            return index;
        }

        /// <summary>
        /// Converte l'indice dell'array di tag in delle coordinate per la matrice da visualizzare
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int[] getCoordFromIndex(int index)
        {
            int[] coord = new int[2] { (index / numColonne)+ 1, (index % numColonne)+1 };
            
            return coord;
        }
        
        /// <summary>
        /// Ricava un tag partendo dall'indice dell'array
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public String getTagFromIndex(int index)
        {
            return tagRFID[index];
        }

        /// <summary>
        /// Imposta il valore di un tag
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="index"></param>
        public void setTag(String tag, int index) 
        {
            tagRFID[index] = tag;
        }
        
        /// <summary>
        /// Elimina un tag dalla lista
        /// </summary>
        /// <param name="index"></param>
        public void delTag(int index) 
        {
            tagRFID[index] = null;
        }

        /// <summary>
        /// Ricava un tag partendo dalle coordinate sulla griglia/matrice
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public string getTagFromNumericCoord(int row, int col)
        {
            col--;
            row--;
            return tagRFID[row * numColonne + col];
        }

        /// <summary>
        /// Ricava le coordinate della cella sulla griglia partendo dal valore del tag
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
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

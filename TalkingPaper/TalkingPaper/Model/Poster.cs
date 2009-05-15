using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace TalkingPaper.Model
{
    public class Poster
    {

        private String nomePoster;
        private String descrizione;
        private String username;
        private String nomeGriglia;

        private int numRighe;
        private int numColonne;

        private List<Contenuto> contenuti;

        public Poster(String nome, String desc, String username, String nomeGriglia)
        {
            this.nomePoster = nome;
            this.descrizione = desc;
            this.username = username;
            this.nomeGriglia = nomeGriglia;
            contenuti = null;
        }

        public String getNome() { return nomePoster; }
        public String getDescrizione() { return descrizione; }
        public String getUsername() { return username; }
        public String getNomeGriglia() { return nomeGriglia; }
        public List<Contenuto> getContenuti() { return contenuti; }

        public void setNome(String nome) { this.nomePoster = nome; }
        public void setDescrizione(String desc) { this.descrizione = desc; }
        public void setUsername(String username) { this.username = username; }
        public void setNomeGriglia(String nomeGriglia) { this.nomeGriglia = nomeGriglia; }
        public void setContenuti(List<Contenuto> contenuti) { this.contenuti = contenuti; }

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

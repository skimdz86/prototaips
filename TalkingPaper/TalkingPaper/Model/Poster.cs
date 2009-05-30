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

        
        private List<Contenuto> contenuti;

        /*Costruttore*/
        public Poster(String nome, String desc, String username, String nomeGriglia)
        {
            this.nomePoster = nome;
            this.descrizione = desc;
            this.username = username;
            this.nomeGriglia = nomeGriglia;
            contenuti = null;
        }

        /*Getters e setters*/
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

        /*Varie funzioni utili*/
        
        /// <summary>
        /// Ricava il contenuto dando l'indice
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Contenuto getContenutoFromIndex(int index)
        {
            return contenuti[index];
        }

        /// <summary>
        /// Imposta il valore di un contenuto nella lista di contenuti associata a un poster
        /// </summary>
        /// <param name="contenuto"></param>
        /// <param name="index"></param>
        public void setTag(Contenuto contenuto, int index)
        {
            contenuti[index] = contenuto;
        }

        /// <summary>
        /// Cancella un contenuto dalla lista
        /// </summary>
        /// <param name="index"></param>
        public void delTag(int index)
        {
            contenuti[index] = null;
        }

        /// <summary>
        /// Ricava un contenuto partendo dal nome
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Contenuto getContenutoFromName(string name)
        {
            foreach (Contenuto contenuto in contenuti)
            {
                if (contenuto.getNomeContenuto().Equals(name))
                    return contenuto;
            }
            return null;
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TalkingPaper.Authoring
{   
    class ElementoGriglia
    {
        private string id_pannello;
        private string nome_pannello;
        private string configurazione;
        private string nome_poster;
        private int id_poster;
        private int id_contenuto;
        private string nome_contenuto;
        private string tag_contenuto;
        private string colonna;
        private int riga;
        private bool utilizzato;
        //private bool modificato;

        public ElementoGriglia(string id_pannello, string nome_pannello, string configurazione, string nome_poster, int id_poster, int id_contenuto, string nome_contenuto, string colonna, int riga, string tag_contenuto, bool utilizzato)
        {
            this.id_pannello = id_pannello;
            this.nome_pannello = nome_pannello;
            this.configurazione = configurazione;
            this.nome_poster = nome_poster;
            this.id_poster = id_poster;
            this.id_contenuto = id_contenuto;
            this.nome_contenuto = nome_contenuto;
            this.colonna = colonna;
            this.riga = riga;
            this.tag_contenuto = tag_contenuto;
            this.utilizzato = utilizzato;
            //this.modificato = modificato;
        }

        public bool GetUtilizzato() {
            return utilizzato;
        }

        /*public void SerModificato(bool mod) {
            modificato = mod;
        }*/

        public void SetUtilizzato(bool util) {
            utilizzato = util;
        }

        public void SetIdContenuto(int id){
            this.id_contenuto = id;
        }

        public void SetNomeContenuto(string nome) {
            this.nome_contenuto = nome;
        }

        public string GetTagContenuto() {
            return tag_contenuto;
        }

        public void SetTagContenuto(string con) {
            tag_contenuto = con;
        }

        public int GetIdContenuto()
        {
            return id_contenuto;
        }

        public string GetNomeContenuto(){
            return nome_contenuto;
        }

        public int GetRiga() {
            return riga;
        }

        public string getColonna() {
            return colonna;
        }
    }
}

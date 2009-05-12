using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using QuartzTypeLib;
using System.Xml;

namespace TalkingPaper.Authoring
{
    class PannelliConfigurazione
    {
        private string nome_pannello;
        private string id_pannello;
        private ArrayList configurazioni = new ArrayList();
        private string tag_per_riga;
        private string tag_per_colonna;

        public PannelliConfigurazione(string id_pannello, string nome_pannello,string tag_per_riga,string tag_per_colonna) {
            this.id_pannello = id_pannello;
            this.nome_pannello = nome_pannello;
            this.tag_per_riga = tag_per_riga;
            this.tag_per_colonna = tag_per_colonna;
        }

        public void InserisciConfigurazione(string configurazione) {
            configurazioni.Add(configurazione);
        }

        public string GetConfigurazione(int i) {
            return (String)configurazioni[i];
        }

        public int GetConffigurazioniCount(){
            return configurazioni.Count;
        }

        public string GetId() {
            return id_pannello;
        }

        public string GetNome() {
            return nome_pannello;
        }

        public string GetTagRiga() {
            return tag_per_riga;
        }

        public string GetTagColonna() {
            return tag_per_colonna;
        }
    }
}

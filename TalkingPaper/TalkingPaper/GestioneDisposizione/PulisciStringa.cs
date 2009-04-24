using System;
using System.Collections.Generic;
using System.Text;

namespace TalkingPaper.GestioneDisposizione
{
    class PulisciStringa
    {
        private string test;
        
        public PulisciStringa(string test) {
            this.test = test;
            Pulizia(test);
        }

        public static string Pulizia(string testo) {
            testo = testo.Replace("&quot;", "'");
            testo=testo.Replace("&ugrave;","ù");
            testo=testo.Replace("&rsquo;", "'");
            testo=testo.Replace("&ograve;","ò");
            testo=testo.Replace("&egrave;","è");
            testo=testo.Replace("&agrave;", "à");
            testo=testo.Replace("&ldquo;", "'");
            testo = testo.Replace("&rdquo;", "'");
            testo=testo.Replace("&eacute;", "é");
            bool mah = testo.Contains("&#039;");
            testo=testo.Replace("&#039;", "'");
            return testo;
        }
    }
}

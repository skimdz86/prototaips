using System;
using System.Collections.Generic;
using System.Text;

namespace TalkingPaper.DataAccess
{
    /// <summary>
    /// E' l'implementazione dell'interfaccia per la gestione dei dati
    /// </summary>
    class XmlDataHandler : DataHandlerInterface
    {
        GrigliaHandler gr;
        UserHandler ut;
        PosterHandler pos;

        /// <summary>
        /// Costruttore: inizializza gli oggetti necessari
        /// </summary>
        public XmlDataHandler() {
            gr = new GrigliaHandler();
            ut = new UserHandler();
            pos = new PosterHandler();
        }
        
        
        /// <summary>
        /// Verifica l'autenticazione dell'utente
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>True se autenticato</returns>
        public bool autenticaUtente(String username, String password)
        {
            bool b=ut.autenticaUtente(username, password);
            return b;
        }
        /// <summary>
        /// Verifica se l'utente è amministratore dopo aver verificato l'autenticazione
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>True se amministratore</returns>
        public bool isAdmin(String username)
        {
            bool b = ut.isAdmin(username);
            return b;
        }
        /// <summary>
        /// Registra l'utente
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>True se non ci sono stati errori</returns>
        public bool registraUtente(String username, String password)
        {
            bool b = ut.registraUtente(username, password);
            return b;
        }
        /// <summary>
        /// Ricava la lista di utenti registrati
        /// </summary>
        /// <returns>Lista di utenti</returns>
        public List<Model.User> getListaUtenti()
        {
            List<Model.User> l = ut.getListaUtenti();
            return l;
        }
        /// <summary>
        /// Salva la griglia nel file XML
        /// </summary>
        /// <param name="griglia">E' un oggetto che contiene tutte le informazioni sulla griglia</param>
        /// <returns>True se non ci sono stati errori</returns>
        public bool setGriglia(Model.Griglia griglia)
        {
            bool b = gr.setGriglia(griglia);
            return b;
        }
        /// <summary>
        /// Ottiene l'oggetto griglia
        /// </summary>
        /// <param name="nomeGriglia"></param>
        /// <returns></returns>
        public Model.Griglia getGriglia(String nomeGriglia)
        {
            Model.Griglia g = gr.getGriglia(nomeGriglia);
            return g;
        }
        /// <summary>
        /// Ottiene la lista delle griglie presenti
        /// </summary>
        /// <returns>Lista di oggetti di tipo Griglia</returns>
        public List<Model.Griglia> getListaGriglie()
        {
            List<Model.Griglia> l = gr.getListaGriglie();
            return l;
        }
        /// <summary>
        /// Salva il poster nel file XML
        /// </summary>
        /// <param name="poster">Oggetto di tipo Poster</param>
        /// <returns>True se non ci sono stati errori</returns>
        public bool setPoster(Model.Poster poster)
        {
            bool b = pos.setPoster(poster);
            return b;
        }
        /// <summary>
        /// Ricava un oggetto di tipoPoster dal nome
        /// </summary>
        /// <param name="nomePoster"></param>
        /// <returns>Oggetto di tipo Poster</returns>
        public Model.Poster getPoster(String nomePoster)
        {
            Model.Poster p = pos.getPoster(nomePoster);
            return p;
        }
        /// <summary>
        /// Ricava la lista dei poster
        /// </summary>
        /// <returns>Lista di oggetti Poster</returns>
        public List<Model.Poster> getListaPoster()
        {
            List<Model.Poster> l = pos.getListaPoster();
            return l;
        }
        /// <summary>
        /// Rimuove un poster dal file XML
        /// </summary>
        /// <param name="nomePoster"></param>
        /// <returns>True se non ci sono stati errori</returns>
        public bool removePoster(String nomePoster) 
        {
            bool b = pos.removePoster(nomePoster);
            return b;
        }
        /// <summary>
        /// Verifica l'esistenza del poster
        /// </summary>
        /// <param name="nomePoster"></param>
        /// <returns>True se esiste</returns>
        public bool existPoster(String nomePoster) 
        {
            return pos.existPoster(nomePoster);
        }
        /// <summary>
        /// Ricava un contenuto dati il nome del poster e il tag associato alla cella della griglia scelta
        /// </summary>
        /// <param name="nomePoster"></param>
        /// <param name="tag"></param>
        /// <returns>Oggetto di tipo Contenuto</returns>
        public Model.Contenuto getContenutoFromTag(String nomePoster, String tag) 
        {
            String nomeGriglia = getPoster(nomePoster).getNomeGriglia();
            Model.Griglia grTemp = getGriglia(nomeGriglia);
            int[] coord=grTemp.getCoordFromTag(tag);
            if (coord == null) return null;
            List<Model.Contenuto> tempList = getPoster(nomePoster).getContenuti();
            for (int i = 0; i < tempList.Count; i++) 
            {
                if ((((Model.Contenuto)tempList[i]).getCoordinate()[0] == coord[0]) && (((Model.Contenuto)tempList[i]).getCoordinate()[1] == coord[1])) return (Model.Contenuto)tempList[i];
            }
            return null;
        }
    }
}

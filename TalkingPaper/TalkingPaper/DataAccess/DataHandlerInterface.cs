using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

/* 
 * NOTA BENE: hp == suppongo
 */

namespace TalkingPaper.DataAccess
{
    interface DataHandlerInterface
    {

        /* ----- SEZIONE UTENTI ----- */

        //ritorna true se username e password corrispondono
        //ad un utente presente in memoria
        bool autenticaUtente(String username, String password);

        //ritorna true se l'utente autenticato è amministratore
        //hp: l'username è univoco
        bool isAdmin(String username);

        //ritorna true se la registrazione è andata a buon fine
        //hp: il check tra password/ripetizione_password viene fatto PRIMA
        //di chiamare questo metodo
        bool registraUtente(String username, String password);

        List<Model.User> getListaUtenti();

        /* ----- SEZIONE GRIGLIA ----- */

        //Memorizza l'oggetto Griglia
        bool setGriglia(Model.Griglia griglia);

        //Recupera l'oggetto con nome nomeGriglia
        //hp: nomeGriglia univoco
        Model.Griglia getGriglia(String nomeGriglia);

        //ritorna la lista degli oggetti Griglia con solo nome/righe/colonne
        List<Model.Griglia> getListaGriglie();

        /* ----- SEZIONE POSTER ----- */

        //Memorizza l'oggetto Poster
        bool setPoster(Model.Poster poster);

        //Recupera l'oggetto con nome nomePoster
        //hp: nomePoster univoco
        Model.Poster getPoster(String nomePoster);
        
        //ritorna la lista degli oggetti Poster
        List<Model.Poster> getListaPoster();

        //rimuove un poster
        bool removePoster(String nomePoster);

        //controlla l'esistenza di un poster
        bool existPoster(String nomePoster);

        /*------------SEZIONE MISTA--------------*/
        Model.Contenuto getContenutoFromTag(String nomePoster, String tag);

        /*
         * Non c'è la sezione COMPONENTE, perchè i componenti
         * vengono gestiti solamente 'in locale'. I componenti
         * vengono infatti memorizzati all'interno dell'oggetto Poster.
         */
        
    }
}

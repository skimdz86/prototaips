﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

/* 
 * NOTA BENE: hp == suppongo
 */

namespace TalkingPaper
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

        List<String> getListaUtenti();

        /* ----- SEZIONE GRIGLIA ----- */

        //Memorizza l'oggetto Griglia
        bool setGriglia(Griglia griglia);

        //Recupera l'oggetto con nome nomeGriglia
        //hp: nomeGriglia univoco
        Griglia getGriglia(String nomeGriglia);

        //ritorna la lista degli oggetti Griglia con solo nome/righe/colonne
        List<Griglia> getListaGriglie();

        /* ----- SEZIONE POSTER ----- */

        //Memorizza l'oggetto Poster
        bool setPoster(Poster poster);

        //Recupera l'oggetto con nome nomePoster
        //hp: nomePoster univoco
        Poster getPoster(String nomePoster);
        
        //ritorna la lista degli oggetti Poster
        List<Poster> getListaPoster();

        /*
         * Non c'è la sezione COMPONENTE, perchè i componenti
         * vengono gestiti solamente 'in locale'. I componenti
         * vengono infatti memorizzati all'interno dell'oggetto Poster.
         */
        
    }
}

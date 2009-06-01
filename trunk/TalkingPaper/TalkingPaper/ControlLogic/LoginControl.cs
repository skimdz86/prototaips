using System;
using System.Collections.Generic;
using System.Text;
using TalkingPaper.Common;

namespace TalkingPaper.ControlLogic
{
    class LoginControl
    {
        /// <summary>
        /// Metodo per la verifica della validità dei dati di login
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public String login(String user, String password) 
        {
            bool res=Global.dataHandler.autenticaUtente(user, password);
            if (res) 
            { 
                bool admin=Global.dataHandler.isAdmin(user);
                if (admin) return "admin";
                else return "utente";
            }
            else return "non autenticato";
        }

        /// <summary>
        /// Metodo per effettuare la registrazione di un nuovo utente
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool registration(String user, String password) 
        {
            bool res = Global.dataHandler.registraUtente(user, password);
            return res;
        }
    }
}

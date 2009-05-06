using System;
using System.Collections.Generic;
using System.Text;
using TalkingPaper.Common;

namespace TalkingPaper.ControlLogic
{
    class LoginControl
    {
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
        public bool registration(String user, String password) 
        {
            bool res = Global.dataHandler.registraUtente(user, password);
            return res;
        }
    }
}

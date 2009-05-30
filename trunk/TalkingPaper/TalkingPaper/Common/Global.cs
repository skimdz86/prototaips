using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace TalkingPaper.Common
{
    class Global
    {
        /*VARIABILI GLOBALI DEL PROGRAMMA*/

        public static Form home;
        public static Form welcome;
        public static Stack<Form> back;
        
        public static DataAccess.DataHandlerInterface dataHandler;

        public static string directoryPrincipale;

        public static Reader.IReader reader;


        /*Funzione per verificare se un campo di input è riempito*/
        public static bool isNotEmpty(String text)
        {
            if ((text != null) && !(text.Equals(""))) return true;
            else return false;
        }

        /*Funzione per verificare se un campo di input è vuoto*/
        public static bool isEmpty(String text)
        {
            return !isNotEmpty(text);
        }
    }
}
    
 
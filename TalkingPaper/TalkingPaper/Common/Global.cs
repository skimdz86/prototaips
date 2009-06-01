using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace TalkingPaper.Common
{
    class Global
    {
        /*VARIABILI GLOBALI DEL PROGRAMMA*/

        //La form che punta alla homepage
        public static Form home;
        //La form che punta alla welcome page
        public static Form welcome;
        //Uno stack di form per tornare correttamente indietro nella navigazione
        public static Stack<Form> back;
        //Il gestore della base di dati
        public static DataAccess.DataHandlerInterface dataHandler;
        //La directory di esecuzione del programma
        public static string directoryPrincipale;
        //L'interfaccia al lettore
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
    
 
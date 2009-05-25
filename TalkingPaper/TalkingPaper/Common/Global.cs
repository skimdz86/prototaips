using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace TalkingPaper.Common
{
    class Global
    {


        public static Form home;
        public static Form welcome;
        public static Stack<Form> back;
        
        public static DataAccess.DataHandlerInterface dataHandler;

        public static string directoryPrincipale;

        public static Reader.IReader reader;

        public static bool isNotEmpty(String text)
        {
            if ((text != null) && !(text.Equals(""))) return true;
            else return false;
        }

        public static bool isEmpty(String text)
        {
            return !isNotEmpty(text);
        }
    }
}
    
 
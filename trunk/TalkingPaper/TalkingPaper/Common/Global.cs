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
        //public static float percentScale=(float)0.80;

        public static DataAccess.DataHandlerInterface dataHandler;

        public static string directoryPrincipale;

        public static Reader.IReader reader;
    }
}
    
 
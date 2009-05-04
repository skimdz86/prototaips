using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace TalkingPaper
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Inizializzo le variabili globali
            global.dataHandler = new DataAccess.GeneralDataHandler();
            global.directoryPrincipale = Directory.GetCurrentDirectory();
            
            //Avvio della finestra di accesso
            Application.Run(new Welcome.IndexForm());
         }
    }
}
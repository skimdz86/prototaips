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
            Common.Global.dataHandler = new DataAccess.GeneralDataHandler();
            Common.Global.directoryPrincipale = Directory.GetCurrentDirectory();
            Common.Global.reader = new Reader.RfidReader();
            Common.Global.back = new Stack<Form>();
            //creazione dei file XML---da commentare
            //TestXML xx = new TestXML();

            //Avvio della finestra di accesso
            Application.Run(new Welcome.IndexForm());
            
                        
         }
    }
}
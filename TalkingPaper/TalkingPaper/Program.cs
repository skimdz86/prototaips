using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using TalkingPaper.Common;

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
            Global.dataHandler = new DataAccess.GeneralDataHandler();
            Global.directoryPrincipale = Directory.GetCurrentDirectory();
            Global.reader = new Reader.RfidReader();
            Global.back = new Stack<Form>();
            //creazione dei file XML---da commentare
            //TestXML xx = new TestXML();

            //Avvio della finestra di accesso
            Application.Run(new Welcome.IndexForm());
            
                        
         }
    }
}
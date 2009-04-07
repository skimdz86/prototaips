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
            //Application.Run(new WelcomePre());

            Application.Run(new Welcome());
            
            //Application.Run(new Form1());
            //Application.Run(new Form2());
            //Application.Run(new TalkingPaper.Config.FormRfidConfig());
            //Application.Run(new FormProvaNH3());
            //Application.Run( new FormEsecuzione());
          //Application.Run( new TalkingPaper.RfidCode.BenvenutoRFID());
            //Application.Run(new NuovoAmministratore(null));
            //Application.Run(new FormAmministrazione(null,"pippo"));
           // Application.Run(new FiltroStorie());
            //Application.Run(new Authoring.BenvenutoAuthoring(null));
            //Application.Run(new TalkingPaper.GestioneDisposizione.SetDisposizione());
            //Application.Run(new TalkingPaper.GestioneDisposizione.TaggingDellaParete());
            //Application.Run(new TalkingPaper.GestioneDisposizione.ScegliConfigurazione("E0040100088AEFD9"));
           // Application.Run(new FiltroStorie());
        //Application.Run(new TalkingPaper.BarCode.BenvenutoBarCode());
          //Application.Run(new TalkingPaper.Postering.BenvenutoPostering());
            // Application.Run(new TalkingPaper.FormEsecuzione());
            //Application.Run(new TalkingPaper.Config.FormRfidConfig());
           // Application.Run(new TalkingPaper.FormEsecuzioneBarcode());
           //Application.Run(new TalkingPaper.Postering.PlayAudio());
           //Application.Run(new TalkingPaper.Postering.PlayVideo());
           // Application.Run(new TalkingPaper.Postering.NuovoComponente());
           // Application.Run(new TalkingPaper.Postering.BenvenutoPostering());



        }
    }
}
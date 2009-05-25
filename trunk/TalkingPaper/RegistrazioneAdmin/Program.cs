using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace RegistrazioneAdmin
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length == 0) return;
            String filedir = args[0] + @"/Data";
            if (!(Directory.Exists(filedir)))
                Directory.CreateDirectory(filedir);
            
            Application.Run(new RegistrationForm(args[0]));
        }

        

        

        
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TalkingPaper.Reader
{
    public delegate void ReaderDelegate(string value);

    interface IReader
    {
        int connect();

        string readValue();

        /// <summary>
        /// Configura il lettore in maniera automatica o leggendo i parametri inseriti
        /// con il comando saveConfiguration.        
        /// </summary>
        /// <returns> un intero che indica il risultato della configurazione</returns>
        int configure();

        bool close();

        bool saveConfiguration(params string[] parameters);

        String[] getConfiguration();

        bool startRead();

        event ReaderDelegate readerStatusUpdate;
    }
}

using System;

namespace TalkingPaper.Reader
{
    /// <summary>
    /// Delegato che genera il tipo dell'evento readerStatusUpdate
    /// </summary>
    /// <param name="value"></param>
    public delegate void ReaderDelegate(string value);

    interface IReader
    {
        /// <summary>
        /// Tenta una connessione esclusivamente leggendo i parametri salvati con il comando
        /// saveConfiguration.
        /// </summary>
        /// <returns>un intero che indica il risultato della connessione:
        /// se maggiore di 0 la connessione è stata effettuata.</returns>
        int connect();

        /// <summary>
        /// Restituisce l'ultimo valore letto dal reader.
        /// </summary>
        /// <returns></returns>
        string readValue();

        /// <summary>
        /// Configura il lettore in maniera automatica o leggendo i parametri inseriti
        /// con il comando saveConfiguration.        
        /// </summary>
        /// <returns> un intero che indica il risultato della configurazione</returns>
        int configure();

        /// <summary>
        /// Rilascia tutte le risorse attivate per la lettura. Da eseguire sempre quando non si
        /// utilizza più il reader.
        /// </summary>
        /// <returns></returns>
        bool close();

        /// <summary>
        /// Salva la configurazione per la connessione al reader.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        bool saveConfiguration(params string[] parameters);

        /// <summary>
        /// Restituisce la configurazione per la connessione al reader.
        /// </summary>
        /// <returns></returns>
        String[] getConfiguration();

        /// <summary>
        /// Avvia la lettura asincrona con la possibilità di utilizzo di un metodo delegato.
        /// </summary>
        /// <returns></returns>
        bool startRead();

        /// <summary>
        /// Evento di tipo ReaderDelegate(string value) che viene eseguito quando è disponibile
        /// il valore di una nuova lettura
        /// </summary>
        event ReaderDelegate readerStatusUpdate;
    }
}

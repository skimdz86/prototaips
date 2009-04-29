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

        bool configure();

        bool saveConfiguration(params string[] parameters);

        event ReaderDelegate readerStatusUpdate;
    }
}

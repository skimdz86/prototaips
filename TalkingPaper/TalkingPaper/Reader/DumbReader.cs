using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace TalkingPaper.Reader
{
    class DumbReader : IReader
    {
        private Timer timer;
        private int counter = 0;

        public int connect()
        {
            timer = new Timer();
            timer.Interval = 2000;
            timer.Tick += timer_Tick;
            timer.Start();
            return 1;
        }

        public bool close()
        {
            timer.Stop();
            return true;
        }
        public string readValue()
        {
            return (counter++).ToString();
        }

        public bool configure()
        {
            return true;
        }

        public bool saveConfiguration(params string[] parameters)
        {
            return true;
        }

        public String[] getConfiguration()
        {
            return null;
        }

        public void startRead()
        {
            counter = 0;
        }
        public event ReaderDelegate readerStatusUpdate;

        private void timer_Tick(object sender, EventArgs e)
        {
            if (readerStatusUpdate != null) 
            readerStatusUpdate((counter++).ToString());
        }
    }
}

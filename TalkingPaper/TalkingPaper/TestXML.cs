using System;
using System.Collections.Generic;
using System.Text;

namespace TalkingPaper
{
    class TestXML
    {
        public TestXML() {

            DataAccess.UserHandler user = new TalkingPaper.DataAccess.UserHandler();
            DataAccess.GrigliaHandler gr = new TalkingPaper.DataAccess.GrigliaHandler();
            DataAccess.PosterHandler pos = new TalkingPaper.DataAccess.PosterHandler();

            user.CreateListaUtenti();
            gr.CreateGriglieTaggate();
            pos.CreateElencoPoster();
        }
    }
}

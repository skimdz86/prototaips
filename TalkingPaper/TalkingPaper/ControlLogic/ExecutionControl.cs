using System;
using System.Collections.Generic;
using System.Text;
using TalkingPaper.Common;

namespace TalkingPaper.ControlLogic
{
    class ExecutionControl
    {

        public List<Model.Poster> getListaPoster()
        {
            return Global.dataHandler.getListaPoster();
        }
    }
}

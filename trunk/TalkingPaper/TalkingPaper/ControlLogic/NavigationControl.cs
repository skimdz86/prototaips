using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TalkingPaper.ControlLogic
{
    class NavigationControl
    {
        public void goHome(Form currentForm)
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }
            else
            {
                throw new Exception("Parametro non corretto (currentForm == null)");
            }

            if (global.home != null)
            {
                global.home.Visible = true;
            }
            else
            {
                throw new Exception("Errore nella configurazione dei tasti di navigazione (global.home == null)");
            }
        }

        public void goWelcome(Form currentForm)
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }
            else
            {
                throw new Exception("Parametro non corretto (currentForm == null)");
            }

            if (global.welcome != null)
            {
                global.welcome.Visible = true;
            }
            else
            {
                throw new Exception("Errore nella configurazione dei tasti di navigazione (global.welcome == null)");
            }
        }

        public void goBack(Form currentForm)
        {

            if (currentForm != null)
            {
                currentForm.Close();
            }
            else
            {
                throw new Exception("Parametro non corretto (currentForm == null)");
            }

            if (global.back != null)
            {
                global.back.Visible = true;
            }
            else
            {
                throw new Exception("Errore nella configurazione dei tasti di navigazione (global.back == null)");
            }
        }

        public void goTo(Form from,Form to)
        {
            if ((from != null) && (to != null))
            {
                global.back = from;
                to.Show();
                from.Visible = false;
            }
            else
            {
                throw new Exception("Parametro non corretto (from == null) || (to == null)");
            }
        }

        public void setHome(Form home)
        {
            if (home != null)
            {
                global.home = home;
            }
            else
            {
                throw new Exception("Parametro non corretto (home == null)");
            }
        }
    }


}

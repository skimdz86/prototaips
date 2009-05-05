using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TalkingPaper.Common
{
    class NavigationControl
    {
        public static void goHome(Form currentForm)
        {
            if (Global.home != null)
            {
                Global.home.Visible = true;
            }
            else
            {
                throw new Exception("Errore nella configurazione dei tasti di navigazione (global.home == null)");
            }

            if (currentForm != null)
            {
                currentForm.Close();
            }
            else
            {
                throw new Exception("Parametro non corretto (currentForm == null)");
            }

        }

        public static void goWelcome(Form currentForm)
        {
            if (Global.welcome != null)
            {
                Global.welcome.Visible = true;
            }
            else
            {
                throw new Exception("Errore nella configurazione dei tasti di navigazione (global.welcome == null)");
            }

            if (currentForm != null)
            {
                currentForm.Close();
            }
            else
            {
                throw new Exception("Parametro non corretto (currentForm == null)");
            }
        }

        public static void goBack(Form currentForm)
        {

            if (Global.back != null)
            {
                Global.back.Visible = true;
            }
            else
            {
                throw new Exception("Errore nella configurazione dei tasti di navigazione (global.back == null)");
            }

            if (currentForm != null)
            {
                currentForm.Close();
            }
            else
            {
                throw new Exception("Parametro non corretto (currentForm == null)");
            }
        }

        public static void goTo(Form from,Form to)
        {
            if ((from != null) && (to != null))
            {
                Global.back = from;
                to.Show();
                from.Visible = false;
            }
            else
            {
                throw new Exception("Parametro non corretto (from == null) || (to == null)");
            }
        }

        public static void setHome(Form home)
        {
            if (home != null)
            {
                Global.home = home;
            }
            else
            {
                throw new Exception("Parametro non corretto (home == null)");
            }
        }

        public static void setWelcome(Form welcome)
        {
            if (welcome != null)
            {
                Global.welcome = welcome;
            }
            else
            {
                throw new Exception("Parametro non corretto (welcome == null)");
            }
        }
    }


}

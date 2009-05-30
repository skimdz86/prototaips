using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TalkingPaper.Common
{
    class NavigationControl
    {
        /// <summary>
        /// Funzione per dirigersi alla homepage
        /// </summary>
        /// <param name="currentForm">La finestra corrente</param>
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

        /// <summary>
        /// Funzione per dirigersi alla finestra di benvenuto
        /// </summary>
        /// <param name="currentForm">La finestra corrente</param>
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

        /// <summary>
        /// Funzione per tornare indietro di una finestra
        /// </summary>
        /// <param name="currentForm">La finestra corrente</param>
        public static void goBack(Form currentForm)
        {

            if (Global.back.Count > 0)
            {
                Form form = Global.back.Pop();
                form.Visible = true;
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

        /// <summary>
        /// Funzione per raggiungere una determinata finestra
        /// </summary>
        /// <param name="from">La finestra corrente</param>
        /// <param name="to">La finestra da raggiungere</param>
        public static void goTo(Form from,Form to)
        {
            if ((from != null) && (to != null))
            {
                if (!(to.IsDisposed))
                {
                    Global.back.Push(from);
                    to.Show();
                    from.Visible = false;
                }
            }
            else
            {
                throw new Exception("Parametro non corretto (from == null) || (to == null)");
            }
        }

        /// <summary>
        /// Funzione per impostare una finestra come homepage
        /// </summary>
        /// <param name="home"></param>
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

        /// <summary>
        /// Funzione per impostare una finestra come pagina di benvenuto
        /// </summary>
        /// <param name="home"></param>
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

        /// <summary>
        /// Funzione per mostrare una finestra di dialogo
        /// </summary>
        /// <param name="dialog"></param>
        public static void showDialog(Form dialog)
        {
            if ((dialog != null) && (!(dialog.IsDisposed)))
            {
                dialog.Show();
            }
            else
            {
                throw new Exception("Parametro non corretto (dialog == null) || (dialog.isDisposed)");
            }

        }

        /// <summary>
        /// Funzione per chiudere una finestra di dialogo
        /// </summary>
        /// <param name="dialog"></param>
        public static void closeDialog(Form dialog)
        {
            if ((dialog != null) && (!(dialog.IsDisposed)))
            {
                dialog.Close();
            }
            else
            {
                throw new Exception("Parametro non corretto (dialog == null) || (dialog.isDisposed)");
            }

        }
    }


}

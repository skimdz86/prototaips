using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RegistrazioneAdmin
{
    class NavigationControl
    {

        /// <summary>
        /// Funzione per mostrare la finestra di dialogo
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
        /// Funzione per chiudere la finestra di dialogo
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

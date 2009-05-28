using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RegistrazioneAdmin
{
    class NavigationControl
    {
        
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

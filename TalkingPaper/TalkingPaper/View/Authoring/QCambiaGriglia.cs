using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TalkingPaper.Authoring
{
    public partial class QCambiaGriglia : Form
    {
        private FormVisualizzaElementiAuthoring indietro;
        
        public QCambiaGriglia(FormVisualizzaElementiAuthoring indietro)
        {
            InitializeComponent();
            this.indietro = indietro;
        }

        private void Si_Click(object sender, EventArgs e)
        {
            // non implementato
        }

        private void Annulla_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            indietro.Visible = true;
            this.Cursor = Cursors.Default;
            this.Close();
        }

    }
}
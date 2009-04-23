using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TalkingPaper.BarCode
{
    public partial class Question : Form
    {
        BenvenutoBarCode benvenuto;
        private Welcome inizio;
        public Question(BenvenutoBarCode benvenuto,Welcome inizio)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 45, true);
            this.benvenuto = benvenuto;
            this.inizio = inizio;
            this.Show();
            Si.Cursor = Cursors.Hand;
            Annulla.Cursor = Cursors.Hand;
        }


        private void Si_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            benvenuto.Close();
            inizio.Visible = true;
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void Annulla_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            benvenuto.Visible = true;
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void Si_Click_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            benvenuto.Close();
            //this.Close();
            inizio.Visible = true;
            this.Cursor = Cursors.Default;
            this.Close();
        }
    }
}
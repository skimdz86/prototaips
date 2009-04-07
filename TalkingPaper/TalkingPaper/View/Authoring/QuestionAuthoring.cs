using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TalkingPaper.Authoring
{
    public partial class QuestionCambiaGriglia : Form
    {
        BenvenutoAuthoring benvenuto;
        private Welcome inizio;
        public QuestionCambiaGriglia(BenvenutoAuthoring benvenuto, Welcome inizio)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 45, true);
            this.benvenuto = benvenuto;
            this.Show();
            this.inizio = inizio;
            Si.Cursor = Cursors.Hand;
            Annulla.Cursor = Cursors.Hand;
        }

        private void Question_Load(object sender, EventArgs e)
        {

        }

        private void Si_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            benvenuto.Close();
            //this.Close();
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
    }
}
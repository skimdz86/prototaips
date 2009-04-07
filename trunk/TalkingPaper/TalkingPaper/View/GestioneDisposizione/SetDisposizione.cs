using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TalkingPaper.GestioneDisposizione
{
    public partial class SetDisposizione : Form
    {
        public SetDisposizione()
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 90, true);
            ElencoTag.ColumnCount = 10;
            ElencoTag.Rows.Add();
            ElencoTag.CellClick += new DataGridViewCellEventHandler(ElencoTag_CellClick);
        }

        private void ElencoTag_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ElencoTag[e.ColumnIndex, e.RowIndex].Style.BackColor == Color.BlanchedAlmond)
            {
                ElencoTag[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Coral;
            }
            else
                ElencoTag[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.BlanchedAlmond;
        }

        private void ElencoTag_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(ElencoTag[e.ColumnIndex, e.RowIndex].Value.ToString());
            if (ElencoTag[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor != Color.Coral)
            {
                //ElencoTag[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.BlanchedAlmond;
                ElencoTag[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Coral;
            }
            else
                //ElencoTag[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Coral;
                ElencoTag[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.BlanchedAlmond;
            //ElencoTag[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.Coral;
        }


        private void Indietro_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Close();
            this.Cursor = Cursors.Default;
            //componenti.Visible = true;
        }

    }
}
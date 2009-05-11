using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TalkingPaper.Common;

namespace TalkingPaper.Administration
{
    public partial class ModificaGrigliaForm : FormSchema
    {
        private ControlLogic.AdministrationControl control;
        private Model.Griglia griglia;
        
        int riga = 1;
        int colonna = 1;

        private char[] alfabeto = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'Z' };

        public ModificaGrigliaForm(String nomeGriglia)
        {
            InitializeComponent();
            ControlLogic.AdministrationControl ad = new TalkingPaper.ControlLogic.AdministrationControl();
            this.griglia = ad.getGriglia(nomeGriglia);
            control = new ControlLogic.AdministrationControl();
            control.inizializzaReader(this);

            inizializzaDataGrid();

            ElencoTag.CellClick += new DataGridViewCellEventHandler(ElencoTag_CellClick);
        }

        public void inizializzaDataGrid()
        {
            Font font = new Font("Arial", 16);
            ElencoTag.ColumnCount = griglia.getNumColonne() + 1;
            ElencoTag.Rows.Add(griglia.getNumRighe() + 1);
            ElencoTag.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
            ElencoTag.Columns[0].DefaultCellStyle.ForeColor = Color.Red;
            ElencoTag.Rows[0].DefaultCellStyle.Font = font;
            ElencoTag.Columns[0].DefaultCellStyle.Font = font;
            for (int i = 1; i <= griglia.getNumRighe(); i++)
            {
                ElencoTag[0, i].Value = i;
            }
            for (int j = 1; j <= griglia.getNumColonne(); j++)
            {
                ElencoTag.Columns[j].Width = 110;
                ElencoTag[j, 0].Value = alfabeto[j - 1];
            }
            List<String> tags = griglia.getListaTag();

            for (int i = 1; i < (griglia.getNumRighe() + 1); i++)
            {
                for (int j = 1; j < (griglia.getNumColonne() + 1); j++)
                {
                    if (!(tags[(i - 1) * griglia.getNumColonne() + (j - 1)].Equals(""))) control.addId(tags[(i - 1) * griglia.getNumColonne() + (j - 1)]);
                    ElencoTag[j, i].Value = tags[(i-1) * griglia.getNumColonne() + (j-1)];
                }
            }
        }

        public void rfid_StatusUpdateEvent(string id)
        {
            if (((colonna <= griglia.getNumColonne()) && (riga <= griglia.getNumRighe()))
                 && ((colonna != -1) || (riga != -1)))
            {
                if (control.verificaId(id))
                {
                    if ((ElencoTag[colonna, riga].Value == null) || (ElencoTag[colonna, riga].Value.Equals("")))
                    {
                        ElencoTag[colonna, riga].Style.BackColor = Color.Coral;
                        ElencoTag[colonna, riga].Value = id;

                        control.addId(id);

                        ElencoTag[colonna, riga].Selected = false;


                        colonna++;
                        if (colonna > griglia.getNumColonne())
                        {
                            if (riga >= griglia.getNumRighe())
                            {
                                riga = -1;
                                colonna = -1;
                            }
                            else
                            {
                                riga++;
                                colonna = 1;
                                if ((ElencoTag[colonna, riga].Value == null) || (ElencoTag[colonna, riga].Value.Equals("")))
                                {
                                    ElencoTag[colonna, riga].Style.SelectionBackColor = Color.Yellow;
                                    ElencoTag[colonna, riga].Selected = true;
                                }
                            }
                        }
                        else
                        {
                            if ((ElencoTag[colonna, riga].Value == null) || (ElencoTag[colonna, riga].Value.Equals("")))
                            {
                                ElencoTag[colonna, riga].Style.SelectionBackColor = Color.Yellow;
                                ElencoTag[colonna, riga].Selected = true;
                            }
                        }
                    }
                    else
                    {
                        ElencoTag[colonna, riga].Selected = false;
                    }
                }
            }
        }

        private void ok_Click(object sender, EventArgs e)
        {
            string[,] matrix = new string[ElencoTag.RowCount - 1, ElencoTag.ColumnCount - 1];
            for (int i = 0; i < ElencoTag.RowCount - 1; i++)
            {
                for (int j = 0; j < ElencoTag.ColumnCount - 1; j++)
                {
                    if (ElencoTag[j + 1, i + 1].Value != null)
                        matrix[i, j] = ElencoTag[j + 1, i + 1].Value.ToString();
                    else
                        matrix[i, j] = "";
                }
            }
            control.salvaGriglia(griglia, matrix);
            control.stopReader();
            NavigationControl.goHome(this);
        }



        private void ElencoTag_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int i, j;
            for (i = 1; i <= griglia.getNumRighe(); i++) // se c'è qualche cella che risulta autoselezionata, la deseleziono
            {
                for (j = 1; j <= griglia.getNumColonne(); j++)
                {
                    if (ElencoTag[i, j].Style.BackColor == Color.Coral && String.IsNullOrEmpty(ElencoTag[i, j].Value.ToString()) == true)
                        ElencoTag[i, j].Style.BackColor = Color.BlanchedAlmond;
                }
            }
            if ((ElencoTag[e.ColumnIndex, e.RowIndex] != null) && (ElencoTag[e.ColumnIndex, e.RowIndex].Value != null) && (e.ColumnIndex != 0) && (e.RowIndex != 0))
            {
                control.delId((string)ElencoTag[e.ColumnIndex, e.RowIndex].Value);
                ElencoTag[e.ColumnIndex, e.RowIndex].Value = null;
                ElencoTag[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.BlanchedAlmond;
                ElencoTag[e.ColumnIndex, e.RowIndex].Selected = true;
                riga = e.RowIndex;
                colonna = e.ColumnIndex;
            }
            else
            {
                if ((e.ColumnIndex != 0) && (e.RowIndex != 0))
                {
                    ElencoTag[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Yellow;
                    ElencoTag[e.ColumnIndex, e.RowIndex].Selected = true;
                    riga = e.RowIndex;
                    colonna = e.ColumnIndex;
                }
            }
        }

        private void annulla_Click(object sender, EventArgs e)
        {
            control.stopReader();
            NavigationControl.goBack(this);
        }

        private void home_Click(object sender, EventArgs e)
        {
            NavigationControl.goHome(this);
        }
                
    }
}

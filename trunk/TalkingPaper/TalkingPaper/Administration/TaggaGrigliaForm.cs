using System;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;
using TalkingPaper.Common;

namespace TalkingPaper.Administration
{
    public partial class TaggaGrigliaForm : FormSchema
    {
        private ControlLogic.AdministrationControl control;
        
        Model.Griglia griglia;
        private int riga = 1;
        private int colonna = 1;
        
        private char[] alfabeto ={ 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'Z' };

        public TaggaGrigliaForm(Model.Griglia griglia)
        {
            InitializeComponent();
            //RidimensionaForm n = new RidimensionaForm(this, 98, true);
            this.griglia = griglia;
            ok.Cursor = Cursors.Hand;
            annulla.Cursor = Cursors.Hand;

            control = new TalkingPaper.ControlLogic.AdministrationControl();
            bool readerOk = control.inizializzaReader(this);
            if (!readerOk)
            {
                MessageBox.Show("Impossibile avviare il lettore");
                this.Dispose();
                return;
            }
            inizializzaDataGrid();
            
            //Gestione Eventi
                        
            ElencoTag.CellClick += new DataGridViewCellEventHandler(ElencoTag_CellClick);
        }
                
        public void inizializzaDataGrid()
        {
            Font font = new Font("Arial", 16);
            ElencoTag.ColumnCount = griglia.getNumColonne() + 1;
            ElencoTag.Rows.Add(griglia.getNumRighe() + 1);
            ElencoTag.Rows[0].DefaultCellStyle.Font = font;
            ElencoTag.Columns[0].DefaultCellStyle.Font = font;
            ElencoTag.Columns[0].Width = 50;
            ElencoTag.Rows[0].Height = 35;
            ElencoTag[0, 0].Style.BackColor = Color.ForestGreen;
            ElencoTag[0, 0].Style.SelectionBackColor = Color.ForestGreen;

            for (int i = 1; i <= griglia.getNumRighe(); i++)
            {
                ElencoTag[0, i].Value = i;
                ElencoTag[0, i].Style.BackColor = Color.ForestGreen;
                ElencoTag[0, i].Style.SelectionBackColor = Color.ForestGreen;
            }
            for (int j = 1; j <= griglia.getNumColonne(); j++)
            {
                ElencoTag.Columns[j].Width = 110;
                ElencoTag[j, 0].Value = alfabeto[j - 1];
                ElencoTag[j, 0].Style.BackColor = Color.ForestGreen;
                ElencoTag[j, 0].Style.SelectionBackColor = Color.ForestGreen;
            }
            ElencoTag[1, 1].Style.SelectionBackColor = Color.Yellow;
            ElencoTag[colonna, riga].Selected = true;
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
            string[,] matrix = new string[ElencoTag.RowCount-1, ElencoTag.ColumnCount-1];
            for (int i = 0; i < ElencoTag.RowCount-1; i++)
            {
                for (int j = 0; j < ElencoTag.ColumnCount-1; j++)
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
            int row = e.RowIndex;
            int col = e.ColumnIndex;
            
            //click su un header
            if (row == 0 || col == 0) return;

            if ((riga != -1) && (colonna != -1))
            {
                ElencoTag[colonna, riga].Selected = false;
                ElencoTag[colonna, riga].Style.BackColor = Color.BlanchedAlmond;
            }


            if (ElencoTag[col, row] != null)
            {
                if (ElencoTag[col, row].Value != null)
                {
                    control.delId((string)ElencoTag[col, row].Value);
                    ElencoTag[col, row].Value = null;
                }
                ElencoTag[col, row].Style.SelectionBackColor = Color.Yellow;
                ElencoTag[col, row].Selected = true;
                riga = row;
                colonna = col;

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
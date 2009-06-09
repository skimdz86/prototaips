using System;
using TalkingPaper.Common;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace TalkingPaper.Administration
{
    public partial class ListaGriglieForm : FormSchema
    {
        private ControlLogic.AdministrationControl control;
        private List<Model.Griglia> griglie;
        private Model.Griglia grigliaSelezionata;
        private Label lastLabelClicked;
        private char[] alfabeto ={ 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'Z' };
        
        public ListaGriglieForm()
        {
            try
            {
                InitializeComponent();

                ok.Cursor = Cursors.Default;
                annulla.Cursor = Cursors.Hand;
                ok.Enabled = false;

                control = new ControlLogic.AdministrationControl();
                griglie = control.leggiGriglie();
                if ((griglie == null) || (griglie.Count == 0))
                {
                    noGriglie.Visible = true;
                }
                caricaPannello();
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }
        /// <summary>
        /// Crea il pannello e aggiunge le griglie trovate ad esso
        /// </summary>
        private void caricaPannello() {
            try
            {
                int i = 0;
                foreach (Model.Griglia griglia in griglie)
                {
                    Label nome = new Label();
                    nome.Text = griglia.getNome() + " (" + griglia.getNumRighe() + "x" + griglia.getNumColonne() + ")";
                    nome.Tag = griglia.getNome();
                    nome.BackColor = Color.Orange;
                    nome.ForeColor = Color.White;
                    nome.Size = new System.Drawing.Size(175, 25);
                    nome.AutoSize = false;
                    nome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    nome.Click += new System.EventHandler(nomi_Click);
                    nome.Location = new System.Drawing.Point(25, 5 + i++ * 35);
                    nome.Visible = true;

                    pannello.Controls.Add(nome);
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }
        /// <summary>
        /// Disegna graficamente la griglia scelta
        /// </summary>
        private void disegnaGrigliaSelezionata()
        {
            try
            {
                Font font = new Font("Arial", 16);
                SchemaGriglia.Rows.Clear();

                SchemaGriglia.ColumnCount = grigliaSelezionata.getNumColonne() + 1;
                SchemaGriglia.Rows.Add(grigliaSelezionata.getNumRighe() + 1);


                SchemaGriglia.Rows[0].DefaultCellStyle.Font = font;
                SchemaGriglia.Columns[0].DefaultCellStyle.Font = font;
                SchemaGriglia.Columns[0].Width = 50;
                SchemaGriglia.Rows[0].Height = 35;
                SchemaGriglia[0, 0].Style.BackColor = Color.ForestGreen;
                SchemaGriglia[0, 0].Style.SelectionBackColor = Color.ForestGreen;

                for (int i = 1; i <= grigliaSelezionata.getNumRighe(); i++)
                {
                    SchemaGriglia[0, i].Value = i;
                    SchemaGriglia[0, i].Style.BackColor = Color.ForestGreen;
                    SchemaGriglia[0, i].Style.SelectionBackColor = Color.ForestGreen;
                }
                for (int j = 1; j <= grigliaSelezionata.getNumColonne(); j++)
                {
                    SchemaGriglia.Columns[j].Width = 90;
                    SchemaGriglia[j, 0].Value = alfabeto[j - 1];
                    SchemaGriglia[j, 0].Style.BackColor = Color.ForestGreen;
                    SchemaGriglia[j, 0].Style.SelectionBackColor = Color.ForestGreen;
                }
                for (int i = 0; i < (grigliaSelezionata.getNumRighe() * grigliaSelezionata.getNumColonne()); i++)
                {
                    if (Global.isNotEmpty(grigliaSelezionata.getTagFromIndex(i)))
                    {
                        SchemaGriglia[(i % grigliaSelezionata.getNumColonne()) + 1, (i / grigliaSelezionata.getNumColonne()) + 1].Style.BackColor = Color.Coral;
                        SchemaGriglia[(i % grigliaSelezionata.getNumColonne()) + 1, (i / grigliaSelezionata.getNumColonne()) + 1].Style.SelectionBackColor = Color.Coral;
                    }
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        private void ok_Click(object sender, EventArgs e)
        {
            if (grigliaSelezionata != null)
            {
                ModificaGrigliaForm modificaGriglia = new ModificaGrigliaForm(grigliaSelezionata.getNome());
                NavigationControl.goTo(this, modificaGriglia);
            }
            else
            {
                MessageBox.Show("Errore sul controllo del tasto ok");
            }
        }

        private void annulla_Click(object sender, EventArgs e)
        {
            NavigationControl.goBack(this);
        }

        private void nomi_Click(object sender, System.EventArgs e)
        {
            try
            {
                /*Ricava tutti i dati della griglia selezionata*/
                grigliaSelezionata = Global.dataHandler.getGriglia((string)((Label)sender).Tag);


                if (lastLabelClicked != null) lastLabelClicked.BackColor = System.Drawing.Color.Orange;
                ((Label)sender).BackColor = System.Drawing.Color.Red;
                lastLabelClicked = ((Label)sender);

                ok.Enabled = true;
                ok.Cursor = Cursors.Hand;
                groupBox2.Visible = true;
                disegnaGrigliaSelezionata();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void home_Click(object sender, EventArgs e)
        {
            NavigationControl.goHome(this);
        }

        private void help_Click(object sender, EventArgs e)
        {
            HelpFormSchema helpForm = new HelpFormSchema("Selezionando il nome di una griglia, questa apparirà a lato. Le caselle colorate di rosso sono quelle a cui è associato un tag, mentre quelle bianche sono vuote. Attenzione: controllare che il lettore RFID sia collegato prima di proseguire!");
            NavigationControl.showDialog(helpForm);
        }

            
    }
}
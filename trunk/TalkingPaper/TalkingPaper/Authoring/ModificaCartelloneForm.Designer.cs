using TalkingPaper.Common;
using System.Windows.Forms;
namespace TalkingPaper.Authoring
{
    partial class ModificaCartelloneForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.elencoPoster = new System.Windows.Forms.DataGridView();
            this.noPoster = new System.Windows.Forms.Label();
            this.boxSotto.SuspendLayout();
            this.boxSopra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elencoPoster)).BeginInit();
            this.SuspendLayout();
            // 
            // sottotitolo
            // 
            this.sottotitolo.Size = new System.Drawing.Size(521, 33);
            this.sottotitolo.Text = "Seleziona il cartellone da modificare";
            // 
            // home
            // 
            this.home.Click += new System.EventHandler(this.home_Click);
            // 
            // annulla
            // 
            this.annulla.Click += new System.EventHandler(this.annulla_Click);
            // 
            // ok
            // 
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // elencoPoster
            // 
            this.elencoPoster.AllowUserToAddRows = false;
            this.elencoPoster.AllowUserToDeleteRows = false;
            this.elencoPoster.AllowUserToResizeRows = false;
            this.elencoPoster.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.elencoPoster.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.elencoPoster.BackgroundColor = System.Drawing.Color.DarkOrange;
            this.elencoPoster.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.elencoPoster.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.elencoPoster.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.elencoPoster.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.elencoPoster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.elencoPoster.ColumnHeadersVisible = false;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.elencoPoster.DefaultCellStyle = dataGridViewCellStyle10;
            this.elencoPoster.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.elencoPoster.EnableHeadersVisualStyles = false;
            this.elencoPoster.GridColor = System.Drawing.Color.Cyan;
            this.elencoPoster.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.elencoPoster.Location = new System.Drawing.Point(154, 159);
            this.elencoPoster.MultiSelect = false;
            this.elencoPoster.Name = "elencoPoster";
            this.elencoPoster.ReadOnly = true;
            this.elencoPoster.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.elencoPoster.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.elencoPoster.RowHeadersVisible = false;
            this.elencoPoster.RowHeadersWidth = 120;
            this.elencoPoster.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.BlanchedAlmond;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.BlanchedAlmond;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            this.elencoPoster.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.elencoPoster.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.elencoPoster.ShowEditingIcon = false;
            this.elencoPoster.Size = new System.Drawing.Size(638, 394);
            this.elencoPoster.TabIndex = 43;
            // 
            // noPoster
            // 
            this.noPoster.BackColor = System.Drawing.Color.DarkOrange;
            this.noPoster.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noPoster.ForeColor = System.Drawing.Color.White;
            this.noPoster.Location = new System.Drawing.Point(236, 320);
            this.noPoster.Name = "noPoster";
            this.noPoster.Size = new System.Drawing.Size(501, 39);
            this.noPoster.TabIndex = 46;
            this.noPoster.Text = "Non sono presenti poster...creali!";
            this.noPoster.Visible = false;
            // 
            // ModificaCartelloneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1028, 739);
            this.Controls.Add(this.noPoster);
            this.Controls.Add(this.elencoPoster);
            this.Name = "ModificaCartelloneForm";
            this.Controls.SetChildIndex(this.boxSopra, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            this.Controls.SetChildIndex(this.boxSotto, 0);
            this.Controls.SetChildIndex(this.elencoPoster, 0);
            this.Controls.SetChildIndex(this.noPoster, 0);
            this.boxSotto.ResumeLayout(false);
            this.boxSotto.PerformLayout();
            this.boxSopra.ResumeLayout(false);
            this.boxSopra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elencoPoster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView elencoPoster;
        private Label noPoster;
    }
}
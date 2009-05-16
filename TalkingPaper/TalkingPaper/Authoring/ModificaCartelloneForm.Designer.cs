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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ElencoRisorse = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.Menu = new System.Windows.Forms.Button();
            this.elencoPoster = new System.Windows.Forms.DataGridView();
            this.noPoster = new System.Windows.Forms.Label();
            this.boxSotto.SuspendLayout();
            this.boxSopra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElencoRisorse)).BeginInit();
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
            // ElencoRisorse
            // 
            this.ElencoRisorse.AllowUserToAddRows = false;
            this.ElencoRisorse.AllowUserToDeleteRows = false;
            this.ElencoRisorse.AllowUserToResizeRows = false;
            this.ElencoRisorse.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ElencoRisorse.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ElencoRisorse.BackgroundColor = System.Drawing.Color.BlanchedAlmond;
            this.ElencoRisorse.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ElencoRisorse.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.ElencoRisorse.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ElencoRisorse.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ElencoRisorse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ElencoRisorse.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.BlanchedAlmond;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ElencoRisorse.DefaultCellStyle = dataGridViewCellStyle2;
            this.ElencoRisorse.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.ElencoRisorse.EnableHeadersVisualStyles = false;
            this.ElencoRisorse.GridColor = System.Drawing.Color.BlanchedAlmond;
            this.ElencoRisorse.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.ElencoRisorse.Location = new System.Drawing.Point(43, 154);
            this.ElencoRisorse.MinimumSize = new System.Drawing.Size(519, 340);
            this.ElencoRisorse.MultiSelect = false;
            this.ElencoRisorse.Name = "ElencoRisorse";
            this.ElencoRisorse.ReadOnly = true;
            this.ElencoRisorse.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.BlanchedAlmond;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ElencoRisorse.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ElencoRisorse.RowHeadersVisible = false;
            this.ElencoRisorse.RowHeadersWidth = 120;
            this.ElencoRisorse.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.BlanchedAlmond;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.BlanchedAlmond;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.ElencoRisorse.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.ElencoRisorse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.ElencoRisorse.ShowEditingIcon = false;
            this.ElencoRisorse.Size = new System.Drawing.Size(961, 370);
            this.ElencoRisorse.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 0;
            // 
            // Menu
            // 
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(75, 23);
            this.Menu.TabIndex = 0;
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.elencoPoster.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.elencoPoster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.elencoPoster.ColumnHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.elencoPoster.DefaultCellStyle = dataGridViewCellStyle6;
            this.elencoPoster.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.elencoPoster.EnableHeadersVisualStyles = false;
            this.elencoPoster.GridColor = System.Drawing.Color.Cyan;
            this.elencoPoster.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.elencoPoster.Location = new System.Drawing.Point(346, 185);
            this.elencoPoster.MultiSelect = false;
            this.elencoPoster.Name = "elencoPoster";
            this.elencoPoster.ReadOnly = true;
            this.elencoPoster.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.elencoPoster.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.elencoPoster.RowHeadersVisible = false;
            this.elencoPoster.RowHeadersWidth = 120;
            this.elencoPoster.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.BlanchedAlmond;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.BlanchedAlmond;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.elencoPoster.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.elencoPoster.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.elencoPoster.ShowEditingIcon = false;
            this.elencoPoster.Size = new System.Drawing.Size(336, 368);
            this.elencoPoster.TabIndex = 43;
            // 
            // noPoster
            // 
            this.noPoster.AutoSize = true;
            this.noPoster.BackColor = System.Drawing.Color.DarkOrange;
            this.noPoster.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noPoster.ForeColor = System.Drawing.Color.White;
            this.noPoster.Location = new System.Drawing.Point(380, 320);
            this.noPoster.Name = "noPoster";
            this.noPoster.Size = new System.Drawing.Size(268, 66);
            this.noPoster.TabIndex = 46;
            this.noPoster.Text = "Non sono presenti\r\n poster...creali!";
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
            ((System.ComponentModel.ISupportInitialize)(this.ElencoRisorse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elencoPoster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ElencoRisorse;
        private System.Windows.Forms.Label label2;
        private Button Menu;
        private DataGridView elencoPoster;
        private Label noPoster;
    }
}
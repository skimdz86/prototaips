namespace TalkingPaper.Authoring
{
    partial class FormScegliPosterAuthoring
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormScegliPosterAuthoring));
            this.Indietro = new TalkingPaper.ControlButton();
            this.ElencoPoster = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.Menu = new TalkingPaper.ControlButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).BeginInit();
            this.grouppoControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElencoPoster)).BeginInit();
            this.SuspendLayout();
            // 
            // grouppoControl
            // 
            this.grouppoControl.Controls.Add(this.Menu);
            this.grouppoControl.Controls.Add(this.Indietro);
            // 
            // sottotitolo
            // 
            this.sottotitolo.Size = new System.Drawing.Size(324, 33);
            this.sottotitolo.Text = "Scegli il tuo cartellone";
            // 
            // Indietro
            // 
            this.Indietro.BackColor = System.Drawing.Color.Yellow;
            this.Indietro.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Indietro.BackgroundImage")));
            this.Indietro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Indietro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Indietro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Indietro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Indietro.Location = new System.Drawing.Point(36, 19);
            this.Indietro.Name = "Indietro";
            this.Indietro.Size = new System.Drawing.Size(120, 62);
            this.Indietro.TabIndex = 16;
            this.Indietro.Text = "Indietro";
            this.Indietro.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Indietro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Indietro.UseVisualStyleBackColor = false;
            this.Indietro.Click += new System.EventHandler(this.Indietro_Click);
            // 
            // ElencoPoster
            // 
            this.ElencoPoster.AllowUserToAddRows = false;
            this.ElencoPoster.AllowUserToDeleteRows = false;
            this.ElencoPoster.AllowUserToResizeRows = false;
            this.ElencoPoster.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ElencoPoster.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ElencoPoster.BackgroundColor = System.Drawing.Color.BlanchedAlmond;
            this.ElencoPoster.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ElencoPoster.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.ElencoPoster.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ElencoPoster.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ElencoPoster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ElencoPoster.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ElencoPoster.DefaultCellStyle = dataGridViewCellStyle2;
            this.ElencoPoster.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.ElencoPoster.EnableHeadersVisualStyles = false;
            this.ElencoPoster.GridColor = System.Drawing.Color.Cyan;
            this.ElencoPoster.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.ElencoPoster.Location = new System.Drawing.Point(29, 118);
            this.ElencoPoster.MinimumSize = new System.Drawing.Size(519, 340);
            this.ElencoPoster.MultiSelect = false;
            this.ElencoPoster.Name = "ElencoPoster";
            this.ElencoPoster.ReadOnly = true;
            this.ElencoPoster.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ElencoPoster.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ElencoPoster.RowHeadersVisible = false;
            this.ElencoPoster.RowHeadersWidth = 120;
            this.ElencoPoster.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.BlanchedAlmond;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.BlanchedAlmond;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.ElencoPoster.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.ElencoPoster.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.ElencoPoster.ShowEditingIcon = false;
            this.ElencoPoster.Size = new System.Drawing.Size(1130, 446);
            this.ElencoPoster.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(480, 275);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(396, 32);
            this.label1.TabIndex = 17;
            this.label1.Text = "Non sono presenti cartelloni";
            this.label1.Visible = false;
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.Color.Yellow;
            this.Menu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Menu.BackgroundImage")));
            this.Menu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Menu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Menu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Menu.Location = new System.Drawing.Point(192, 19);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(120, 62);
            this.Menu.TabIndex = 17;
            this.Menu.Text = "Menu";
            this.Menu.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Menu.UseVisualStyleBackColor = false;
            // 
            // FormScegliPosterAuthoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 739);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ElencoPoster);
            this.Name = "FormScegliPosterAuthoring";
            this.Text = "FormScegliPosterAuthoring";
            this.Load += new System.EventHandler(this.FormScegliPosterAuthoring_Load);
            this.Controls.SetChildIndex(this.ElencoPoster, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.Controls.SetChildIndex(this.grouppoControl, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            this.Controls.SetChildIndex(this.pictureBoxPost1, 0);
            this.Controls.SetChildIndex(this.pictureBoxPost2, 0);
            this.Controls.SetChildIndex(this.textBoxPost, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).EndInit();
            this.grouppoControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElencoPoster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ElencoPoster;
        private System.Windows.Forms.Label label1;
        private ControlButton Indietro;
        private ControlButton Menu;
    }
}
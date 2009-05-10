namespace TalkingPaper.Administration
{
    partial class ListaGriglieForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListaGriglieForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ok = new TalkingPaper.ControlButton();
            this.annulla = new TalkingPaper.ControlButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SchemaGriglia = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.indietro = new TalkingPaper.ControlButton();
            this.pannello = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.SchemaGriglia)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // sottotitolo
            // 
            this.sottotitolo.Size = new System.Drawing.Size(530, 33);
            this.sottotitolo.Text = "Scegli lo schema per il tuo cartellone";
            // 
            // help
            // 
            this.help.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.help.Visible = false;
            // 
            // ok
            // 
            this.ok.BackColor = System.Drawing.Color.Yellow;
            this.ok.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ok.BackgroundImage")));
            this.ok.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ok.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.ok.Location = new System.Drawing.Point(446, 592);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(96, 49);
            this.ok.TabIndex = 23;
            this.ok.Text = "OK";
            this.ok.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ok.UseVisualStyleBackColor = false;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // annulla
            // 
            this.annulla.BackColor = System.Drawing.Color.Yellow;
            this.annulla.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("annulla.BackgroundImage")));
            this.annulla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.annulla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.annulla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.annulla.Location = new System.Drawing.Point(616, 592);
            this.annulla.Name = "annulla";
            this.annulla.Size = new System.Drawing.Size(96, 49);
            this.annulla.TabIndex = 24;
            this.annulla.Text = "Annulla";
            this.annulla.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.annulla.UseVisualStyleBackColor = false;
            this.annulla.Click += new System.EventHandler(this.annulla_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(267, 32);
            this.label2.TabIndex = 25;
            this.label2.Text = "Scegli il cartellone";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(404, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(462, 32);
            this.label3.TabIndex = 26;
            this.label3.Text = "Non sono presenti configurazioni";
            this.label3.Visible = false;
            // 
            // SchemaGriglia
            // 
            this.SchemaGriglia.AllowUserToAddRows = false;
            this.SchemaGriglia.AllowUserToDeleteRows = false;
            this.SchemaGriglia.AllowUserToResizeRows = false;
            this.SchemaGriglia.BackgroundColor = System.Drawing.Color.DarkOrange;
            this.SchemaGriglia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SchemaGriglia.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SchemaGriglia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.SchemaGriglia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.SchemaGriglia.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SchemaGriglia.DefaultCellStyle = dataGridViewCellStyle2;
            this.SchemaGriglia.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.SchemaGriglia.EnableHeadersVisualStyles = false;
            this.SchemaGriglia.GridColor = System.Drawing.Color.OrangeRed;
            this.SchemaGriglia.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.SchemaGriglia.Location = new System.Drawing.Point(18, 19);
            this.SchemaGriglia.MultiSelect = false;
            this.SchemaGriglia.Name = "SchemaGriglia";
            this.SchemaGriglia.ReadOnly = true;
            this.SchemaGriglia.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SchemaGriglia.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.SchemaGriglia.RowHeadersVisible = false;
            this.SchemaGriglia.RowHeadersWidth = 120;
            this.SchemaGriglia.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.BlanchedAlmond;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.BlanchedAlmond;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.SchemaGriglia.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.SchemaGriglia.RowTemplate.Height = 33;
            this.SchemaGriglia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.SchemaGriglia.ShowEditingIcon = false;
            this.SchemaGriglia.Size = new System.Drawing.Size(654, 307);
            this.SchemaGriglia.TabIndex = 27;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Red;
            this.groupBox2.Controls.Add(this.SchemaGriglia);
            this.groupBox2.Location = new System.Drawing.Point(334, 187);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(695, 344);
            this.groupBox2.TabIndex = 46;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            // 
            // indietro
            // 
            this.indietro.BackColor = System.Drawing.Color.Yellow;
            this.indietro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.indietro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.indietro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.indietro.Location = new System.Drawing.Point(0, 0);
            this.indietro.Name = "indietro";
            this.indietro.Size = new System.Drawing.Size(75, 23);
            this.indietro.TabIndex = 0;
            this.indietro.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.indietro.UseVisualStyleBackColor = false;
            // 
            // pannello
            // 
            this.pannello.AutoScroll = true;
            this.pannello.Location = new System.Drawing.Point(18, 171);
            this.pannello.Name = "pannello";
            this.pannello.Size = new System.Drawing.Size(310, 578);
            this.pannello.TabIndex = 54;
            // 
            // ListaGriglieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(1136, 739);
            this.Controls.Add(this.annulla);
            this.Controls.Add(this.pannello);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Name = "ListaGriglieForm";
            this.Text = "FormScegliConfigurazione";
            this.Controls.SetChildIndex(this.help, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.ok, 0);
            this.Controls.SetChildIndex(this.pannello, 0);
            this.Controls.SetChildIndex(this.annulla, 0);
            ((System.ComponentModel.ISupportInitialize)(this.SchemaGriglia)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlButton ok;
        private ControlButton annulla;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView SchemaGriglia;
        private System.Windows.Forms.GroupBox groupBox2;
        private ControlButton indietro;
        private System.Windows.Forms.Panel pannello;
    }
}
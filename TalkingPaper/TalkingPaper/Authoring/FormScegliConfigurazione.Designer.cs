namespace TalkingPaper.Authoring
{
    partial class FormScegliConfigurazione
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormScegliConfigurazione));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new TalkingPaper.ControlButton();
            this.button2 = new TalkingPaper.ControlButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ElencoTag2 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.indietro = new TalkingPaper.ControlButton();
            this.label4 = new System.Windows.Forms.Label();
            this.pannello = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).BeginInit();
            this.grouppoControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElencoTag2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxPost
            // 
            this.textBoxPost.Location = new System.Drawing.Point(913, 439);
            // 
            // pictureBoxPost2
            // 
            this.pictureBoxPost2.Location = new System.Drawing.Point(901, 422);
            // 
            // pictureBoxPost1
            // 
            this.pictureBoxPost1.Location = new System.Drawing.Point(1110, 592);
            // 
            // grouppoControl
            // 
            this.grouppoControl.Controls.Add(this.indietro);
            this.grouppoControl.Location = new System.Drawing.Point(1042, 25);
            this.grouppoControl.Size = new System.Drawing.Size(130, 91);
            // 
            // sottotitolo
            // 
            this.sottotitolo.Size = new System.Drawing.Size(530, 33);
            this.sottotitolo.Text = "Scegli lo schema per il tuo cartellone";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(21, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(340, 25);
            this.label1.TabIndex = 21;
            this.label1.Text = "Scegli il Supporto ed il Pattern ";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(541, 25);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(245, 32);
            this.comboBox1.TabIndex = 22;
            this.comboBox1.Visible = false;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Yellow;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(8, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 49);
            this.button1.TabIndex = 23;
            this.button1.Text = "OK";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Yellow;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(8, 82);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 49);
            this.button2.TabIndex = 24;
            this.button2.Text = "Annulla";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            // 
            // ElencoTag2
            // 
            this.ElencoTag2.AllowUserToAddRows = false;
            this.ElencoTag2.AllowUserToDeleteRows = false;
            this.ElencoTag2.AllowUserToResizeRows = false;
            this.ElencoTag2.BackgroundColor = System.Drawing.Color.DarkOrange;
            this.ElencoTag2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ElencoTag2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ElencoTag2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.ElencoTag2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ElencoTag2.ColumnHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ElencoTag2.DefaultCellStyle = dataGridViewCellStyle6;
            this.ElencoTag2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.ElencoTag2.EnableHeadersVisualStyles = false;
            this.ElencoTag2.GridColor = System.Drawing.Color.OrangeRed;
            this.ElencoTag2.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.ElencoTag2.Location = new System.Drawing.Point(18, 19);
            this.ElencoTag2.MultiSelect = false;
            this.ElencoTag2.Name = "ElencoTag2";
            this.ElencoTag2.ReadOnly = true;
            this.ElencoTag2.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ElencoTag2.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.ElencoTag2.RowHeadersVisible = false;
            this.ElencoTag2.RowHeadersWidth = 120;
            this.ElencoTag2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.BlanchedAlmond;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.BlanchedAlmond;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.ElencoTag2.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.ElencoTag2.RowTemplate.Height = 33;
            this.ElencoTag2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.ElencoTag2.ShowEditingIcon = false;
            this.ElencoTag2.Size = new System.Drawing.Size(654, 307);
            this.ElencoTag2.TabIndex = 27;
            this.ElencoTag2.Click += new System.EventHandler(this.ElencoTag2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Red;
            this.groupBox2.Controls.Add(this.ElencoTag2);
            this.groupBox2.Location = new System.Drawing.Point(334, 187);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(695, 344);
            this.groupBox2.TabIndex = 46;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Orange;
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(1042, 156);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(133, 157);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            // 
            // indietro
            // 
            this.indietro.BackColor = System.Drawing.Color.Yellow;
            this.indietro.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("indietro.BackgroundImage")));
            this.indietro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.indietro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.indietro.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.indietro.Location = new System.Drawing.Point(6, 19);
            this.indietro.Name = "indietro";
            this.indietro.Size = new System.Drawing.Size(96, 49);
            this.indietro.TabIndex = 50;
            this.indietro.Text = "Indietro";
            this.indietro.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.indietro.UseVisualStyleBackColor = false;
            this.indietro.Click += new System.EventHandler(this.indietro_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(292, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 32);
            this.label4.TabIndex = 53;
            // 
            // pannello
            // 
            this.pannello.AutoScroll = true;
            this.pannello.Location = new System.Drawing.Point(18, 171);
            this.pannello.Name = "pannello";
            this.pannello.Size = new System.Drawing.Size(310, 578);
            this.pannello.TabIndex = 54;
            // 
            // FormScegliConfigurazione
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(1184, 739);
            this.Controls.Add(this.pannello);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "FormScegliConfigurazione";
            this.Text = "FormScegliConfigurazione";
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.pictureBoxPost2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.comboBox1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.textBoxPost, 0);
            this.Controls.SetChildIndex(this.grouppoControl, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            this.Controls.SetChildIndex(this.pictureBoxPost1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.pannello, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).EndInit();
            this.grouppoControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElencoTag2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private ControlButton button1;
        private ControlButton button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView ElencoTag2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private ControlButton indietro;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pannello;
    }
}
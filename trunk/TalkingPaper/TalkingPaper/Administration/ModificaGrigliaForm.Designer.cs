namespace TalkingPaper.Administration
{
    partial class ModificaGrigliaForm
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModificaGrigliaForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ElencoTag = new System.Windows.Forms.DataGridView();
            this.button1 = new TalkingPaper.MainButton();
            this.button2 = new TalkingPaper.MainButton();
            //((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElencoTag)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxPost
            // 
            //this.textBoxPost.Location = new System.Drawing.Point(821, 656);
            // 
            // pictureBoxPost2
            // 
            //this.pictureBoxPost2.Location = new System.Drawing.Point(821, 559);
            // 
            // pictureBoxPost1
            // 
            //this.pictureBoxPost1.Location = new System.Drawing.Point(978, 603);
            // 
            // sottotitolo
            // 
            this.sottotitolo.Size = new System.Drawing.Size(234, 33);
            this.sottotitolo.Text = "Modifica Griglia";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(13, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1098, 25);
            this.label1.TabIndex = 44;
            this.label1.Text = "Clicca sulla casella che vorresti modificare e asssegna il nuovo tag ad essa. Pre" +
                "mi OK per terminare le modifiche ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(13, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(785, 25);
            this.label2.TabIndex = 45;
            this.label2.Text = "della griglia (NON TUTTE LE CASELLE NECESSITANO DI ESSERE TAGGATE). ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(13, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(668, 25);
            this.label3.TabIndex = 46;
            this.label3.Text = "ANNULLA per tornare al menù principale senza salvare le modifiche.";
            // 
            // ElencoTag
            // 
            this.ElencoTag.AllowUserToAddRows = false;
            this.ElencoTag.AllowUserToDeleteRows = false;
            this.ElencoTag.AllowUserToResizeRows = false;
            this.ElencoTag.BackgroundColor = System.Drawing.Color.BlanchedAlmond;
            this.ElencoTag.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ElencoTag.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ElencoTag.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ElencoTag.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ElencoTag.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ElencoTag.DefaultCellStyle = dataGridViewCellStyle2;
            this.ElencoTag.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.ElencoTag.EnableHeadersVisualStyles = false;
            this.ElencoTag.GridColor = System.Drawing.Color.OrangeRed;
            this.ElencoTag.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.ElencoTag.Location = new System.Drawing.Point(18, 233);
            this.ElencoTag.MinimumSize = new System.Drawing.Size(1150, 401);
            this.ElencoTag.MultiSelect = false;
            this.ElencoTag.Name = "ElencoTag";
            this.ElencoTag.ReadOnly = true;
            this.ElencoTag.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ElencoTag.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ElencoTag.RowHeadersVisible = false;
            this.ElencoTag.RowHeadersWidth = 120;
            this.ElencoTag.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.BlanchedAlmond;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.BlanchedAlmond;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.ElencoTag.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.ElencoTag.RowTemplate.Height = 33;
            this.ElencoTag.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.ElencoTag.ShowEditingIcon = false;
            this.ElencoTag.Size = new System.Drawing.Size(1150, 401);
            this.ElencoTag.TabIndex = 47;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Yellow;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(372, 640);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 88);
            this.button1.TabIndex = 3;
            this.button1.Text = "OK";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Yellow;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(607, 640);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(180, 88);
            this.button2.TabIndex = 4;
            this.button2.Text = "Annulla";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // ModificaGrigliaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 739);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ElencoTag);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "ModificaGrigliaForm";
            this.Text = "ModificaGrigliaForm";
            this.Load += new System.EventHandler(this.ModificaGrigliaForm_Load);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            //this.Controls.SetChildIndex(this.grouppoControl, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            //this.Controls.SetChildIndex(this.pictureBoxPost1, 0);
            //this.Controls.SetChildIndex(this.pictureBoxPost2, 0);
            //this.Controls.SetChildIndex(this.textBoxPost, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.ElencoTag, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            //((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElencoTag)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView ElencoTag;
        private MainButton button1;
        private MainButton button2;
    }
}
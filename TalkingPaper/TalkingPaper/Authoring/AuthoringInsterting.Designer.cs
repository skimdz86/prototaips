namespace TalkingPaper.Authoring
{
    partial class AuthoringInsterting
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthoringInsterting));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.Annulla = new TalkingPaper.MainButton();
            this.Salva = new TalkingPaper.MainButton();
            this.ElencoTag = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.indietro = new TalkingPaper.ControlButton();
            this.Menu = new TalkingPaper.ControlButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).BeginInit();
            this.grouppoControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElencoTag)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grouppoControl
            // 
            this.grouppoControl.Controls.Add(this.Menu);
            this.grouppoControl.Controls.Add(this.indietro);
            this.grouppoControl.Location = new System.Drawing.Point(850, 12);
            this.grouppoControl.Size = new System.Drawing.Size(322, 91);
            // 
            // sottotitolo
            // 
            this.sottotitolo.Size = new System.Drawing.Size(303, 33);
            this.sottotitolo.Text = "Inserisci il contenuto";
            // 
            // Annulla
            // 
            this.Annulla.BackColor = System.Drawing.Color.Yellow;
            this.Annulla.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Annulla.BackgroundImage")));
            this.Annulla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Annulla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Annulla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Annulla.Location = new System.Drawing.Point(238, 13);
            this.Annulla.Name = "Annulla";
            this.Annulla.Size = new System.Drawing.Size(226, 111);
            this.Annulla.TabIndex = 25;
            this.Annulla.Text = "Annulla";
            this.Annulla.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Annulla.UseVisualStyleBackColor = false;
            this.Annulla.Click += new System.EventHandler(this.Annulla_Click);
            // 
            // Salva
            // 
            this.Salva.BackColor = System.Drawing.Color.Yellow;
            this.Salva.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Salva.BackgroundImage")));
            this.Salva.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Salva.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Salva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Salva.Location = new System.Drawing.Point(6, 13);
            this.Salva.Name = "Salva";
            this.Salva.Size = new System.Drawing.Size(226, 111);
            this.Salva.TabIndex = 24;
            this.Salva.Text = "OK";
            this.Salva.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Salva.UseVisualStyleBackColor = false;
            this.Salva.Click += new System.EventHandler(this.Salva_Click);
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.ElencoTag.Location = new System.Drawing.Point(12, 120);
            this.ElencoTag.MinimumSize = new System.Drawing.Size(1150, 401);
            this.ElencoTag.MultiSelect = false;
            this.ElencoTag.Name = "ElencoTag";
            this.ElencoTag.ReadOnly = true;
            this.ElencoTag.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.BlanchedAlmond;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.ElencoTag.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.ElencoTag.RowTemplate.Height = 33;
            this.ElencoTag.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.ElencoTag.ShowEditingIcon = false;
            this.ElencoTag.Size = new System.Drawing.Size(1166, 444);
            this.ElencoTag.TabIndex = 26;
            this.ElencoTag.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ElencoTag_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Orange;
            this.groupBox1.Controls.Add(this.Salva);
            this.groupBox1.Controls.Add(this.Annulla);
            this.groupBox1.Location = new System.Drawing.Point(230, 592);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 130);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            // 
            // indietro
            // 
            this.indietro.BackColor = System.Drawing.Color.Yellow;
            this.indietro.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("indietro.BackgroundImage")));
            this.indietro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.indietro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.indietro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.indietro.Location = new System.Drawing.Point(25, 19);
            this.indietro.Name = "indietro";
            this.indietro.Size = new System.Drawing.Size(120, 62);
            this.indietro.TabIndex = 45;
            this.indietro.Text = "Indietro";
            this.indietro.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.indietro.UseVisualStyleBackColor = false;
            this.indietro.Click += new System.EventHandler(this.indietro_Click);
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.Color.Yellow;
            this.Menu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Menu.BackgroundImage")));
            this.Menu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Menu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Menu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Menu.Location = new System.Drawing.Point(173, 19);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(120, 62);
            this.Menu.TabIndex = 45;
            this.Menu.Text = "Menu";
            this.Menu.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Menu.UseVisualStyleBackColor = false;
            //this.Menu.Click += new System.EventHandler(this.Menu_Click);
            // 
            // AuthoringInsterting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 739);
            this.Controls.Add(this.ElencoTag);
            this.Controls.Add(this.groupBox1);
            this.Name = "AuthoringInsterting";
            this.Text = "AuthoringInsterting";
            this.Load += new System.EventHandler(this.AuthoringInsterting_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.ElencoTag, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.Controls.SetChildIndex(this.grouppoControl, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            this.Controls.SetChildIndex(this.pictureBoxPost1, 0);
            this.Controls.SetChildIndex(this.pictureBoxPost2, 0);
            this.Controls.SetChildIndex(this.textBoxPost, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).EndInit();
            this.grouppoControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElencoTag)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private MainButton Annulla;
        private MainButton Salva;
        private System.Windows.Forms.DataGridView ElencoTag;
        private System.Windows.Forms.GroupBox groupBox1;
        private ControlButton indietro;
        private ControlButton Menu;
    }
}
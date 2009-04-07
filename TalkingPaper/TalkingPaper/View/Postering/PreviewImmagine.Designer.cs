namespace TalkingPaper.Postering
{
    partial class PreviewImmagine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreviewImmagine));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ChiudiPreview = new TalkingPaper.ControlButton();
            this.Stampa = new TalkingPaper.MainButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).BeginInit();
            this.grouppoControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grouppoControl
            // 
            this.grouppoControl.Controls.Add(this.ChiudiPreview);
            this.grouppoControl.Location = new System.Drawing.Point(1023, 12);
            this.grouppoControl.Size = new System.Drawing.Size(149, 91);
            // 
            // sottotitolo
            // 
            this.sottotitolo.Size = new System.Drawing.Size(126, 33);
            this.sottotitolo.Text = "Preview";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(64, 120);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(673, 402);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ChiudiPreview
            // 
            this.ChiudiPreview.BackColor = System.Drawing.Color.Yellow;
            this.ChiudiPreview.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ChiudiPreview.BackgroundImage")));
            this.ChiudiPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ChiudiPreview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChiudiPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.ChiudiPreview.Location = new System.Drawing.Point(15, 19);
            this.ChiudiPreview.Name = "ChiudiPreview";
            this.ChiudiPreview.Size = new System.Drawing.Size(120, 62);
            this.ChiudiPreview.TabIndex = 45;
            this.ChiudiPreview.Text = "Chiudi";
            this.ChiudiPreview.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ChiudiPreview.UseVisualStyleBackColor = false;
            this.ChiudiPreview.Click += new System.EventHandler(this.ChiudiPreview_Click);
            // 
            // Stampa
            // 
            this.Stampa.BackColor = System.Drawing.Color.Yellow;
            this.Stampa.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Stampa.BackgroundImage")));
            this.Stampa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Stampa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Stampa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Stampa.Location = new System.Drawing.Point(6, 19);
            this.Stampa.Name = "Stampa";
            this.Stampa.Size = new System.Drawing.Size(226, 111);
            this.Stampa.TabIndex = 44;
            this.Stampa.Text = "Stampa";
            this.Stampa.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Stampa.UseVisualStyleBackColor = false;
            this.Stampa.Click += new System.EventHandler(this.Stampa_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Orange;
            this.groupBox1.Controls.Add(this.Stampa);
            this.groupBox1.Location = new System.Drawing.Point(826, 167);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 140);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            // 
            // PreviewImmagine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1184, 739);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Name = "PreviewImmagine";
            this.Text = "Anteprima Immagine";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.Controls.SetChildIndex(this.grouppoControl, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            this.Controls.SetChildIndex(this.pictureBoxPost1, 0);
            this.Controls.SetChildIndex(this.pictureBoxPost2, 0);
            this.Controls.SetChildIndex(this.textBoxPost, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).EndInit();
            this.grouppoControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private ControlButton ChiudiPreview;
        private MainButton Stampa;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
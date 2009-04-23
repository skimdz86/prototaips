namespace TalkingPaper
{
    partial class Welcome2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcome2));
            this.postering = new TalkingPaper.MainButton();
            this.BarCodeTagging = new TalkingPaper.MainButton();
            this.RFIDTagging = new TalkingPaper.MainButton();
            this.EsecuzioneBarCodePoster = new TalkingPaper.MainButton();
            this.EsecuzioneRFIDPoster = new TalkingPaper.MainButton();
            this.Esci = new TalkingPaper.ControlButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).BeginInit();
            this.grouppoControl.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // grouppoControl
            // 
            this.grouppoControl.Controls.Add(this.Esci);
            this.grouppoControl.Location = new System.Drawing.Point(999, 12);
            this.grouppoControl.Size = new System.Drawing.Size(160, 91);
            // 
            // sottotitolo
            // 
            this.sottotitolo.Size = new System.Drawing.Size(255, 33);
            this.sottotitolo.Text = "Crea il tuo poster";
            // 
            // postering
            // 
            this.postering.BackColor = System.Drawing.Color.Yellow;
            this.postering.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("postering.BackgroundImage")));
            this.postering.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.postering.Cursor = System.Windows.Forms.Cursors.Hand;
            this.postering.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.postering.Location = new System.Drawing.Point(25, 19);
            this.postering.Name = "postering";
            this.postering.Size = new System.Drawing.Size(180, 88);
            this.postering.TabIndex = 0;
            this.postering.Text = "Crea - Modifica";
            this.postering.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.postering.UseVisualStyleBackColor = false;
            this.postering.Click += new System.EventHandler(this.postering_Click);
            // 
            // BarCodeTagging
            // 
            this.BarCodeTagging.BackColor = System.Drawing.Color.Yellow;
            this.BarCodeTagging.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BarCodeTagging.BackgroundImage")));
            this.BarCodeTagging.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BarCodeTagging.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BarCodeTagging.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.BarCodeTagging.Location = new System.Drawing.Point(23, 19);
            this.BarCodeTagging.Name = "BarCodeTagging";
            this.BarCodeTagging.Size = new System.Drawing.Size(180, 88);
            this.BarCodeTagging.TabIndex = 1;
            this.BarCodeTagging.Text = "Willy impara SuperVista";
            this.BarCodeTagging.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BarCodeTagging.UseVisualStyleBackColor = false;
            this.BarCodeTagging.Visible = false;
            this.BarCodeTagging.Click += new System.EventHandler(this.BarCodeTagging_Click);
            // 
            // RFIDTagging
            // 
            this.RFIDTagging.BackColor = System.Drawing.Color.Yellow;
            this.RFIDTagging.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RFIDTagging.BackgroundImage")));
            this.RFIDTagging.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RFIDTagging.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RFIDTagging.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.RFIDTagging.Location = new System.Drawing.Point(25, 19);
            this.RFIDTagging.Name = "RFIDTagging";
            this.RFIDTagging.Size = new System.Drawing.Size(180, 88);
            this.RFIDTagging.TabIndex = 2;
            this.RFIDTagging.Text = "Willy impara SuperFiuto";
            this.RFIDTagging.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.RFIDTagging.UseVisualStyleBackColor = false;
            this.RFIDTagging.Visible = false;
            this.RFIDTagging.Click += new System.EventHandler(this.RFIDTagging_Click);
            // 
            // EsecuzioneBarCodePoster
            // 
            this.EsecuzioneBarCodePoster.BackColor = System.Drawing.Color.Yellow;
            this.EsecuzioneBarCodePoster.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EsecuzioneBarCodePoster.BackgroundImage")));
            this.EsecuzioneBarCodePoster.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EsecuzioneBarCodePoster.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EsecuzioneBarCodePoster.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.EsecuzioneBarCodePoster.Location = new System.Drawing.Point(23, 55);
            this.EsecuzioneBarCodePoster.Name = "EsecuzioneBarCodePoster";
            this.EsecuzioneBarCodePoster.Size = new System.Drawing.Size(180, 88);
            this.EsecuzioneBarCodePoster.TabIndex = 3;
            this.EsecuzioneBarCodePoster.Text = "Willy osserva il poster";
            this.EsecuzioneBarCodePoster.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.EsecuzioneBarCodePoster.UseVisualStyleBackColor = false;
            this.EsecuzioneBarCodePoster.Click += new System.EventHandler(this.EsecuzioneBarCodePoster_Click);
            // 
            // EsecuzioneRFIDPoster
            // 
            this.EsecuzioneRFIDPoster.BackColor = System.Drawing.Color.Yellow;
            this.EsecuzioneRFIDPoster.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EsecuzioneRFIDPoster.BackgroundImage")));
            this.EsecuzioneRFIDPoster.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EsecuzioneRFIDPoster.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EsecuzioneRFIDPoster.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.EsecuzioneRFIDPoster.Location = new System.Drawing.Point(273, 55);
            this.EsecuzioneRFIDPoster.Name = "EsecuzioneRFIDPoster";
            this.EsecuzioneRFIDPoster.Size = new System.Drawing.Size(180, 88);
            this.EsecuzioneRFIDPoster.TabIndex = 4;
            this.EsecuzioneRFIDPoster.Text = "Willy annusa il poster";
            this.EsecuzioneRFIDPoster.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.EsecuzioneRFIDPoster.UseVisualStyleBackColor = false;
            this.EsecuzioneRFIDPoster.Click += new System.EventHandler(this.EsecuzioneRFIDPoster_Click);
            // 
            // Esci
            // 
            this.Esci.BackColor = System.Drawing.Color.Yellow;
            this.Esci.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Esci.BackgroundImage")));
            this.Esci.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Esci.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Esci.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.Esci.Location = new System.Drawing.Point(24, 19);
            this.Esci.Name = "Esci";
            this.Esci.Size = new System.Drawing.Size(96, 49);
            this.Esci.TabIndex = 9;
            this.Esci.Text = "Esci";
            this.Esci.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Esci.UseVisualStyleBackColor = false;
            this.Esci.Click += new System.EventHandler(this.Esci_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Orange;
            this.groupBox1.Controls.Add(this.postering);
            this.groupBox1.Location = new System.Drawing.Point(67, 124);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 121);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Orange;
            this.groupBox2.Controls.Add(this.BarCodeTagging);
            this.groupBox2.Controls.Add(this.RFIDTagging);
            this.groupBox2.Location = new System.Drawing.Point(481, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(266, 145);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Orange;
            this.groupBox3.Controls.Add(this.EsecuzioneRFIDPoster);
            this.groupBox3.Controls.Add(this.EsecuzioneBarCodePoster);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Location = new System.Drawing.Point(67, 522);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(514, 205);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Visible = false;
            // 
            // Welcome2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(1184, 739);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Name = "Welcome2";
            this.Text = "Welcome";
            this.Controls.SetChildIndex(this.grouppoControl, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            this.Controls.SetChildIndex(this.pictureBoxPost1, 0);
            this.Controls.SetChildIndex(this.pictureBoxPost2, 0);
            this.Controls.SetChildIndex(this.textBoxPost, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).EndInit();
            this.grouppoControl.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MainButton postering;
        private MainButton BarCodeTagging;
        private MainButton RFIDTagging;
        private MainButton EsecuzioneBarCodePoster;
        private MainButton EsecuzioneRFIDPoster;
        private ControlButton Esci;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}
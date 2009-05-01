namespace TalkingPaper.Authoring
{
    partial class QuestionPostering
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuestionPostering));
            this.Annulla = new TalkingPaper.ControlButton();
            this.Si = new TalkingPaper.ControlButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Annulla
            // 
            this.Annulla.BackColor = System.Drawing.Color.Yellow;
            this.Annulla.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Annulla.BackgroundImage")));
            this.Annulla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Annulla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Annulla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Annulla.Location = new System.Drawing.Point(436, 167);
            this.Annulla.Name = "Annulla";
            this.Annulla.Size = new System.Drawing.Size(120, 62);
            this.Annulla.TabIndex = 45;
            this.Annulla.Text = "Annulla";
            this.Annulla.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Annulla.UseVisualStyleBackColor = false;
            this.Annulla.Click += new System.EventHandler(this.Annulla_Click);
            // 
            // Si
            // 
            this.Si.BackColor = System.Drawing.Color.Yellow;
            this.Si.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Si.BackgroundImage")));
            this.Si.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Si.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Si.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Si.Location = new System.Drawing.Point(228, 167);
            this.Si.Name = "Si";
            this.Si.Size = new System.Drawing.Size(120, 62);
            this.Si.TabIndex = 44;
            this.Si.Text = "Si";
            this.Si.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Si.UseVisualStyleBackColor = false;
            this.Si.Click += new System.EventHandler(this.Si_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(58, 68);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(95, 89);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(177, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 29);
            this.label1.TabIndex = 8;
            this.label1.Text = "Sei sicuro di voler uscire?";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(454, 55);
            this.label6.TabIndex = 46;
            this.label6.Text = "Cartellone Parlante";
            // 
            // QuestionPostering
            // 
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(639, 252);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Si);
            this.Controls.Add(this.Annulla);
            this.Name = "QuestionPostering";
            this.Text = "QuestionPostering";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlButton Annulla;
        private ControlButton Si;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
    }
}
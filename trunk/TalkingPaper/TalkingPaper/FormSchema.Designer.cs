namespace TalkingPaper
{
    partial class FormSchema
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSchema));
            this.textBoxPost = new System.Windows.Forms.TextBox();
            this.pictureBoxPost2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxPost1 = new System.Windows.Forms.PictureBox();
            this.titolo = new System.Windows.Forms.Label();
            this.grouppoControl = new System.Windows.Forms.GroupBox();
            this.sottotitolo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxPost
            // 
            this.textBoxPost.AcceptsReturn = true;
            this.textBoxPost.BackColor = System.Drawing.Color.Yellow;
            this.textBoxPost.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPost.Location = new System.Drawing.Point(821, 439);
            this.textBoxPost.Multiline = true;
            this.textBoxPost.Name = "textBoxPost";
            this.textBoxPost.Size = new System.Drawing.Size(338, 72);
            this.textBoxPost.TabIndex = 43;
            this.textBoxPost.Text = "Ciao!!!!\r\n    Il mio nome è Post e sono qui per aiutarti!\r\nOgni volta che non sap" +
                "rai cosa fare, clicca su di me e cercherò di consigliart!";
            this.textBoxPost.Visible = false;
            // 
            // pictureBoxPost2
            // 
            this.pictureBoxPost2.BackColor = System.Drawing.Color.Orange;
            this.pictureBoxPost2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPost2.Image")));
            this.pictureBoxPost2.Location = new System.Drawing.Point(809, 422);
            this.pictureBoxPost2.Name = "pictureBoxPost2";
            this.pictureBoxPost2.Size = new System.Drawing.Size(365, 169);
            this.pictureBoxPost2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPost2.TabIndex = 42;
            this.pictureBoxPost2.TabStop = false;
            this.pictureBoxPost2.Visible = false;
            // 
            // pictureBoxPost1
            // 
            this.pictureBoxPost1.BackColor = System.Drawing.Color.Orange;
            this.pictureBoxPost1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBoxPost1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxPost1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPost1.Image")));
            this.pictureBoxPost1.Location = new System.Drawing.Point(1018, 592);
            this.pictureBoxPost1.Name = "pictureBoxPost1";
            this.pictureBoxPost1.Size = new System.Drawing.Size(154, 135);
            this.pictureBoxPost1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPost1.TabIndex = 41;
            this.pictureBoxPost1.TabStop = false;
            this.pictureBoxPost1.Click += new System.EventHandler(this.pictureBoxPost1_Click);
            // 
            // titolo
            // 
            this.titolo.AutoSize = true;
            this.titolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titolo.ForeColor = System.Drawing.Color.White;
            this.titolo.Location = new System.Drawing.Point(8, 6);
            this.titolo.Name = "titolo";
            this.titolo.Size = new System.Drawing.Size(454, 55);
            this.titolo.TabIndex = 38;
            this.titolo.Text = "Cartellone Parlante";
            // 
            // grouppoControl
            // 
            this.grouppoControl.BackColor = System.Drawing.Color.Orange;
            this.grouppoControl.Location = new System.Drawing.Point(821, 12);
            this.grouppoControl.Name = "grouppoControl";
            this.grouppoControl.Size = new System.Drawing.Size(351, 91);
            this.grouppoControl.TabIndex = 40;
            this.grouppoControl.TabStop = false;
            // 
            // sottotitolo
            // 
            this.sottotitolo.AutoSize = true;
            this.sottotitolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sottotitolo.ForeColor = System.Drawing.Color.White;
            this.sottotitolo.Location = new System.Drawing.Point(12, 67);
            this.sottotitolo.Name = "sottotitolo";
            this.sottotitolo.Size = new System.Drawing.Size(165, 33);
            this.sottotitolo.TabIndex = 39;
            this.sottotitolo.Text = "SottoTitolo";
            // 
            // FormSchema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(1184, 739);
            this.ControlBox = false;
            this.Controls.Add(this.textBoxPost);
            this.Controls.Add(this.pictureBoxPost2);
            this.Controls.Add(this.pictureBoxPost1);
            this.Controls.Add(this.titolo);
            this.Controls.Add(this.grouppoControl);
            this.Controls.Add(this.sottotitolo);
            this.Name = "FormSchema";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ciao";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.TextBox textBoxPost;
        protected System.Windows.Forms.PictureBox pictureBoxPost2;
        protected System.Windows.Forms.PictureBox pictureBoxPost1;
        protected System.Windows.Forms.Label titolo;
        protected System.Windows.Forms.GroupBox grouppoControl;
        protected System.Windows.Forms.Label sottotitolo;
    }
}


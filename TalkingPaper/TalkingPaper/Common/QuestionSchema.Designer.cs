using TalkingPaper.Common;
using System.Windows.Forms;
namespace TalkingPaper.Common
{
    partial class QuestionSchema
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuestionSchema));
            this.immagine = new System.Windows.Forms.PictureBox();
            this.question = new System.Windows.Forms.Label();
            this.titolo = new System.Windows.Forms.Label();
            this.annulla = new System.Windows.Forms.Button();
            this.ok = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.immagine)).BeginInit();
            this.SuspendLayout();
            // 
            // immagine
            // 
            this.immagine.BackColor = System.Drawing.Color.Transparent;
            this.immagine.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("immagine.BackgroundImage")));
            this.immagine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.immagine.Location = new System.Drawing.Point(22, 76);
            this.immagine.Name = "immagine";
            this.immagine.Size = new System.Drawing.Size(95, 89);
            this.immagine.TabIndex = 13;
            this.immagine.TabStop = false;
            // 
            // question
            // 
            this.question.BackColor = System.Drawing.Color.Transparent;
            this.question.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.question.Location = new System.Drawing.Point(129, 73);
            this.question.Name = "question";
            this.question.Size = new System.Drawing.Size(531, 62);
            this.question.TabIndex = 12;
            this.question.Text = "question";
            // 
            // titolo
            // 
            this.titolo.AutoSize = true;
            this.titolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titolo.ForeColor = System.Drawing.Color.White;
            this.titolo.Location = new System.Drawing.Point(12, 9);
            this.titolo.Name = "titolo";
            this.titolo.Size = new System.Drawing.Size(454, 55);
            this.titolo.TabIndex = 47;
            this.titolo.Text = "Cartellone Parlante";
            // 
            // annulla
            // 
            this.annulla.AutoSize = true;
            this.annulla.BackColor = System.Drawing.Color.Yellow;
            this.annulla.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("annulla.BackgroundImage")));
            this.annulla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.annulla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.annulla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.annulla.Location = new System.Drawing.Point(403, 154);
            this.annulla.Name = "annulla";
            this.annulla.Size = new System.Drawing.Size(112, 72);
            this.annulla.TabIndex = 49;
            this.annulla.Text = "Annulla";
            this.annulla.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.annulla.UseVisualStyleBackColor = false;
            this.annulla.Click += new System.EventHandler(this.annulla_Click);
            // 
            // ok
            // 
            this.ok.AutoSize = true;
            this.ok.BackColor = System.Drawing.Color.Yellow;
            this.ok.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ok.BackgroundImage")));
            this.ok.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ok.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.ok.Location = new System.Drawing.Point(220, 154);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(112, 72);
            this.ok.TabIndex = 48;
            this.ok.Text = "OK";
            this.ok.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ok.UseVisualStyleBackColor = false;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // QuestionSchema
            // 
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(672, 253);
            this.Controls.Add(this.annulla);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.titolo);
            this.Controls.Add(this.question);
            this.Controls.Add(this.immagine);
            this.Name = "QuestionSchema";
            ((System.ComponentModel.ISupportInitialize)(this.immagine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox immagine;
        private System.Windows.Forms.Label question;
        private System.Windows.Forms.Label titolo;
        protected Button annulla;
        protected Button ok;
    }
}
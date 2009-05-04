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
            this.titolo = new System.Windows.Forms.Label();
            this.sottotitolo = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.ClientSize = new System.Drawing.Size(1028, 739);
            this.ControlBox = false;
            this.Controls.Add(this.titolo);
            this.Controls.Add(this.sottotitolo);
            this.Name = "FormSchema";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ciao";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label titolo;
        protected System.Windows.Forms.Label sottotitolo;
    }
}


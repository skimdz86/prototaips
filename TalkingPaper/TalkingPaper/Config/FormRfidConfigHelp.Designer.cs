namespace TalkingPaper.Config
{
    partial class FormRfidConfigHelp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRfidConfigHelp));
            this.label1 = new System.Windows.Forms.Label();
            this.BtnChiusura = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).BeginInit();
            this.grouppoControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // grouppoControl
            // 
            this.grouppoControl.Controls.Add(this.BtnChiusura);
            // 
            // sottotitolo
            // 
            this.sottotitolo.Size = new System.Drawing.Size(295, 33);
            this.sottotitolo.Text = "Help - cofigurazione";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(17, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(640, 144);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // BtnChiusura
            // 
            this.BtnChiusura.BackColor = System.Drawing.Color.Yellow;
            this.BtnChiusura.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnChiusura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.BtnChiusura.Location = new System.Drawing.Point(218, 19);
            this.BtnChiusura.Name = "BtnChiusura";
            this.BtnChiusura.Size = new System.Drawing.Size(120, 61);
            this.BtnChiusura.TabIndex = 1;
            this.BtnChiusura.Text = " Chiudi";
            this.BtnChiusura.UseVisualStyleBackColor = false;
            this.BtnChiusura.Click += new System.EventHandler(this.BtnChiusura_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(63, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 33);
            this.label2.TabIndex = 8;
            // 
            // FormRfidConfigHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(1184, 739);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormRfidConfigHelp";
            this.Text = "Rfid Config Help";
            this.Load += new System.EventHandler(this.FormRfidConfigHelp_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.Controls.SetChildIndex(this.grouppoControl, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            this.Controls.SetChildIndex(this.pictureBoxPost1, 0);
            this.Controls.SetChildIndex(this.pictureBoxPost2, 0);
            this.Controls.SetChildIndex(this.textBoxPost, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).EndInit();
            this.grouppoControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnChiusura;
        private System.Windows.Forms.Label label2;
    }
}
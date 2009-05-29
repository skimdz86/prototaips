using System.Windows.Forms;
namespace TalkingPaper.Common
{
    partial class HelpFormSchema
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpFormSchema));
            this.titolo = new System.Windows.Forms.Label();
            this.annulla = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.helpBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // titolo
            // 
            this.titolo.AutoSize = true;
            this.titolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titolo.ForeColor = System.Drawing.Color.White;
            this.titolo.Location = new System.Drawing.Point(181, 12);
            this.titolo.Name = "titolo";
            this.titolo.Size = new System.Drawing.Size(138, 55);
            this.titolo.TabIndex = 38;
            this.titolo.Text = "Aiuto";
            // 
            // annulla
            // 
            this.annulla.AutoSize = true;
            this.annulla.BackColor = System.Drawing.Color.Yellow;
            this.annulla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.annulla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.annulla.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.annulla.Location = new System.Drawing.Point(396, 12);
            this.annulla.Name = "annulla";
            this.annulla.Size = new System.Drawing.Size(89, 55);
            this.annulla.TabIndex = 42;
            this.annulla.Text = "Chiudi";
            this.annulla.UseVisualStyleBackColor = false;
            this.annulla.Click += new System.EventHandler(this.annulla_Click);
            // 
            // label1
            // 
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(12, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 257);
            this.label1.TabIndex = 44;
            // 
            // helpBox
            // 
            this.helpBox.BackColor = System.Drawing.Color.DarkOrange;
            this.helpBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.helpBox.CausesValidation = false;
            this.helpBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.helpBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpBox.ForeColor = System.Drawing.Color.White;
            this.helpBox.Location = new System.Drawing.Point(208, 96);
            this.helpBox.Multiline = true;
            this.helpBox.Name = "helpBox";
            this.helpBox.ReadOnly = true;
            this.helpBox.Size = new System.Drawing.Size(277, 416);
            this.helpBox.TabIndex = 47;
            // 
            // HelpFormSchema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(497, 589);
            this.ControlBox = false;
            this.Controls.Add(this.helpBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.annulla);
            this.Controls.Add(this.titolo);
            this.Name = "HelpFormSchema";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cartellone Parlante";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label titolo;
        protected Button annulla;
        private Label label1;
        private TextBox helpBox;
    }
}


using TalkingPaper.Common;
using System.Windows.Forms;
namespace TalkingPaper
{
    partial class FormErroreStorico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormErroreStorico));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonChiudi = new Button();
            //((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).BeginInit();
            //this.grouppoControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // grouppoControl
            // 
            //this.grouppoControl.Controls.Add(this.buttonChiudi);
            //this.grouppoControl.Location = new System.Drawing.Point(1024, 9);
            //this.grouppoControl.Size = new System.Drawing.Size(150, 91);
            // 
            // sottotitolo
            // 
            this.sottotitolo.Size = new System.Drawing.Size(93, 33);
            this.sottotitolo.Text = "Errori";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(37, 103);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(898, 516);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // buttonChiudi
            // 
            this.buttonChiudi.BackColor = System.Drawing.Color.Yellow;
            this.buttonChiudi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonChiudi.BackgroundImage")));
            this.buttonChiudi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonChiudi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonChiudi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.buttonChiudi.Location = new System.Drawing.Point(17, 19);
            this.buttonChiudi.Name = "buttonChiudi";
            this.buttonChiudi.Size = new System.Drawing.Size(120, 62);
            this.buttonChiudi.TabIndex = 44;
            this.buttonChiudi.Text = "Chiudi";
            this.buttonChiudi.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonChiudi.UseVisualStyleBackColor = false;
            this.buttonChiudi.Click += new System.EventHandler(this.buttonChiudi_Click_1);
            // 
            // FormErroreStorico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(1184, 739);
            this.Controls.Add(this.richTextBox1);
            this.Name = "FormErroreStorico";
            this.Text = "Storico degli Errori della sessione di lavoro corrente";
            this.Load += new System.EventHandler(this.FormErroreStorico_Load);
            //this.Controls.SetChildIndex(this.grouppoControl, 0);
            this.Controls.SetChildIndex(this.richTextBox1, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            //this.Controls.SetChildIndex(this.pictureBoxPost1, 0);
            //this.Controls.SetChildIndex(this.pictureBoxPost2, 0);
            //this.Controls.SetChildIndex(this.textBoxPost, 0);
            //((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).EndInit();
            //this.grouppoControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private Button buttonChiudi;
    }
}
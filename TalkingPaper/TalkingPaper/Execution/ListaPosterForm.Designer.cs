using TalkingPaper.Common;
using System.Windows.Forms;
namespace TalkingPaper.Execution
{
    partial class ListaPosterForm
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
            this.indietro = new System.Windows.Forms.Button();
            this.pannello = new System.Windows.Forms.Panel();
            this.noPoster = new System.Windows.Forms.Label();
            this.boxSotto.SuspendLayout();
            this.boxSopra.SuspendLayout();
            this.SuspendLayout();
            // 
            // sottotitolo
            // 
            this.sottotitolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sottotitolo.Size = new System.Drawing.Size(700, 31);
            this.sottotitolo.Text = "Scegli il poster del quale vuoi stampare un contenuto";
            // 
            // help
            // 
            this.help.Click += new System.EventHandler(this.help_Click);
            // 
            // home
            // 
            this.home.Click += new System.EventHandler(this.home_Click);
            // 
            // annulla
            // 
            this.annulla.Text = "Indietro";
            this.annulla.Click += new System.EventHandler(this.annulla_Click);
            // 
            // ok
            // 
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // indietro
            // 
            this.indietro.BackColor = System.Drawing.Color.Yellow;
            this.indietro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.indietro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.indietro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.indietro.Location = new System.Drawing.Point(0, 0);
            this.indietro.Name = "indietro";
            this.indietro.Size = new System.Drawing.Size(75, 23);
            this.indietro.TabIndex = 0;
            this.indietro.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.indietro.UseVisualStyleBackColor = false;
            // 
            // pannello
            // 
            this.pannello.AutoScroll = true;
            this.pannello.Location = new System.Drawing.Point(43, 202);
            this.pannello.Name = "pannello";
            this.pannello.Size = new System.Drawing.Size(916, 346);
            this.pannello.TabIndex = 54;
            // 
            // noPoster
            // 
            this.noPoster.AutoSize = true;
            this.noPoster.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noPoster.ForeColor = System.Drawing.Color.White;
            this.noPoster.Location = new System.Drawing.Point(72, 158);
            this.noPoster.Name = "noPoster";
            this.noPoster.Size = new System.Drawing.Size(355, 32);
            this.noPoster.TabIndex = 27;
            this.noPoster.Text = "Non sono presenti poster";
            this.noPoster.Visible = false;
            // 
            // ListaPosterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(1028, 732);
            this.Controls.Add(this.noPoster);
            this.Controls.Add(this.pannello);
            this.Name = "ListaPosterForm";
            this.Text = "FormScegliConfigurazione";
            this.Controls.SetChildIndex(this.boxSopra, 0);
            this.Controls.SetChildIndex(this.boxSotto, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            this.Controls.SetChildIndex(this.pannello, 0);
            this.Controls.SetChildIndex(this.noPoster, 0);
            this.boxSotto.ResumeLayout(false);
            this.boxSotto.PerformLayout();
            this.boxSopra.ResumeLayout(false);
            this.boxSopra.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button indietro;
        private System.Windows.Forms.Panel pannello;
        private System.Windows.Forms.Label noPoster;
    }
}
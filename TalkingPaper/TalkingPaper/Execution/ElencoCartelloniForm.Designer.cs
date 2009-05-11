using TalkingPaper.Common;
using System.Windows.Forms;
namespace TalkingPaper.Execution
{
    partial class ElencoCartelloniForm
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
            this.pannello = new System.Windows.Forms.Panel();
            this.noPoster = new System.Windows.Forms.Label();
            this.boxSotto.SuspendLayout();
            this.boxSopra.SuspendLayout();
            this.pannello.SuspendLayout();
            this.SuspendLayout();
            // 
            // sottotitolo
            // 
            this.sottotitolo.AutoSize = false;
            this.sottotitolo.Size = new System.Drawing.Size(673, 74);
            this.sottotitolo.Text = "Seleziona il cartellone che desideri far parlare dalla lista";
            // 
            // home
            // 
            this.home.Click += new System.EventHandler(this.home_Click);
            // 
            // annulla
            // 
            this.annulla.Click += new System.EventHandler(this.annulla_Click);
            // 
            // ok
            // 
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // pannello
            // 
            this.pannello.AutoScroll = true;
            this.pannello.Controls.Add(this.noPoster);
            this.pannello.Location = new System.Drawing.Point(78, 163);
            this.pannello.Name = "pannello";
            this.pannello.Size = new System.Drawing.Size(797, 385);
            this.pannello.TabIndex = 55;
            // 
            // noPoster
            // 
            this.noPoster.AutoSize = true;
            this.noPoster.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noPoster.ForeColor = System.Drawing.Color.White;
            this.noPoster.Location = new System.Drawing.Point(29, 199);
            this.noPoster.Name = "noPoster";
            this.noPoster.Size = new System.Drawing.Size(355, 32);
            this.noPoster.TabIndex = 27;
            this.noPoster.Text = "Non sono presenti poster";
            this.noPoster.Visible = false;
            // 
            // ElencoCartelloniForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(1028, 739);
            this.Controls.Add(this.pannello);
            this.Name = "ElencoCartelloniForm";
            this.Text = "ElencoPosterEsecuzioneSingoloModello";
            this.VisibleChanged += new System.EventHandler(this.ElencoCartelloniForm_VisibleChanged);
            this.Controls.SetChildIndex(this.boxSopra, 0);
            this.Controls.SetChildIndex(this.boxSotto, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            this.Controls.SetChildIndex(this.pannello, 0);
            this.boxSotto.ResumeLayout(false);
            this.boxSotto.PerformLayout();
            this.boxSopra.ResumeLayout(false);
            this.boxSopra.PerformLayout();
            this.pannello.ResumeLayout(false);
            this.pannello.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel pannello;
        private Label noPoster;
    }
}
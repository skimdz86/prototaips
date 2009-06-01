using TalkingPaper.Common;
using System.Windows.Forms;
namespace TalkingPaper.Authoring
{
    partial class ModificaCartelloneForm
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
            this.elencoPoster = new System.Windows.Forms.Panel();
            this.noPoster = new System.Windows.Forms.Label();
            this.boxSotto.SuspendLayout();
            this.boxSopra.SuspendLayout();
            this.SuspendLayout();
            // 
            // sottotitolo
            // 
            this.sottotitolo.Size = new System.Drawing.Size(521, 33);
            this.sottotitolo.Text = "Seleziona il cartellone da modificare";
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
            this.annulla.Click += new System.EventHandler(this.annulla_Click);
            // 
            // ok
            // 
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // elencoPoster
            // 
            this.elencoPoster.AutoScroll = true;
            this.elencoPoster.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.elencoPoster.Location = new System.Drawing.Point(40, 159);
            this.elencoPoster.Name = "elencoPoster";
            this.elencoPoster.Size = new System.Drawing.Size(940, 394);
            this.elencoPoster.TabIndex = 43;
            // 
            // noPoster
            // 
            this.noPoster.BackColor = System.Drawing.Color.DarkOrange;
            this.noPoster.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noPoster.ForeColor = System.Drawing.Color.White;
            this.noPoster.Location = new System.Drawing.Point(236, 320);
            this.noPoster.Name = "noPoster";
            this.noPoster.Size = new System.Drawing.Size(521, 39);
            this.noPoster.TabIndex = 46;
            this.noPoster.Text = "Non sono presenti cartelloni...creali!";
            this.noPoster.Visible = false;
            // 
            // ModificaCartelloneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1028, 732);
            this.Controls.Add(this.noPoster);
            this.Controls.Add(this.elencoPoster);
            this.Name = "ModificaCartelloneForm";
            this.Controls.SetChildIndex(this.boxSopra, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            this.Controls.SetChildIndex(this.boxSotto, 0);
            this.Controls.SetChildIndex(this.elencoPoster, 0);
            this.Controls.SetChildIndex(this.noPoster, 0);
            this.boxSotto.ResumeLayout(false);
            this.boxSotto.PerformLayout();
            this.boxSopra.ResumeLayout(false);
            this.boxSopra.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel elencoPoster;
        private Label noPoster;
    }
}
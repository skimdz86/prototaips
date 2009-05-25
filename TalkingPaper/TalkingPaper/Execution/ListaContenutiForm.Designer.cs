using TalkingPaper.Common;
using System.Windows.Forms;
namespace TalkingPaper.Execution
{
    partial class ListaContenutiForm
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
            this.noContenuti = new System.Windows.Forms.Label();
            this.anteprima = new System.Windows.Forms.Button();
            this.stampa = new System.Windows.Forms.Button();
            this.boxSotto.SuspendLayout();
            this.boxSopra.SuspendLayout();
            this.SuspendLayout();
            // 
            // sottotitolo
            // 
            this.sottotitolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sottotitolo.Size = new System.Drawing.Size(529, 31);
            this.sottotitolo.Text = "Scegli il componente che vuoi stampare";
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
            // pannello
            // 
            this.pannello.AutoScroll = true;
            this.pannello.Location = new System.Drawing.Point(49, 202);
            this.pannello.Name = "pannello";
            this.pannello.Size = new System.Drawing.Size(646, 346);
            this.pannello.TabIndex = 54;
            // 
            // noContenuti
            // 
            this.noContenuti.AutoSize = true;
            this.noContenuti.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noContenuti.ForeColor = System.Drawing.Color.White;
            this.noContenuti.Location = new System.Drawing.Point(72, 158);
            this.noContenuti.Name = "noContenuti";
            this.noContenuti.Size = new System.Drawing.Size(742, 32);
            this.noContenuti.TabIndex = 27;
            this.noContenuti.Text = "Non sono presenti contenuti che è possibile stampare";
            this.noContenuti.Visible = false;
            // 
            // anteprima
            // 
            this.anteprima.BackColor = System.Drawing.Color.Yellow;
            this.anteprima.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.anteprima.Cursor = System.Windows.Forms.Cursors.Hand;
            this.anteprima.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.anteprima.Location = new System.Drawing.Point(795, 202);
            this.anteprima.Name = "anteprima";
            this.anteprima.Size = new System.Drawing.Size(124, 62);
            this.anteprima.TabIndex = 54;
            this.anteprima.Text = "Anteprima";
            this.anteprima.UseVisualStyleBackColor = false;
            this.anteprima.Click += new System.EventHandler(this.anteprima_Click);
            // 
            // stampa
            // 
            this.stampa.BackColor = System.Drawing.Color.Yellow;
            this.stampa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.stampa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stampa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stampa.Location = new System.Drawing.Point(795, 290);
            this.stampa.Name = "stampa";
            this.stampa.Size = new System.Drawing.Size(124, 62);
            this.stampa.TabIndex = 55;
            this.stampa.Text = "Stampa";
            this.stampa.UseVisualStyleBackColor = false;
            this.stampa.Click += new System.EventHandler(this.stampa_Click);
            // 
            // ListaContenutiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(1028, 732);
            this.Controls.Add(this.stampa);
            this.Controls.Add(this.anteprima);
            this.Controls.Add(this.noContenuti);
            this.Controls.Add(this.pannello);
            this.Name = "ListaContenutiForm";
            this.Text = "FormScegliConfigurazione";
            this.Controls.SetChildIndex(this.boxSopra, 0);
            this.Controls.SetChildIndex(this.boxSotto, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            this.Controls.SetChildIndex(this.pannello, 0);
            this.Controls.SetChildIndex(this.noContenuti, 0);
            this.Controls.SetChildIndex(this.anteprima, 0);
            this.Controls.SetChildIndex(this.stampa, 0);
            this.boxSotto.ResumeLayout(false);
            this.boxSotto.PerformLayout();
            this.boxSopra.ResumeLayout(false);
            this.boxSopra.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pannello;
        private System.Windows.Forms.Label noContenuti;
        private Button anteprima;
        private Button stampa;
    }
}
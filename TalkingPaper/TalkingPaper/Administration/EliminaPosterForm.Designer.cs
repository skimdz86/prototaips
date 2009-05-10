namespace TalkingPaper.Administration
{
    partial class EliminaPosterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EliminaPosterForm));
            this.elimina = new TalkingPaper.ControlButton();
            this.annulla = new TalkingPaper.ControlButton();
            this.indietro = new TalkingPaper.ControlButton();
            this.pannello = new System.Windows.Forms.Panel();
            this.noPoster = new System.Windows.Forms.Label();
            this.pannello.SuspendLayout();
            this.SuspendLayout();
            // 
            // sottotitolo
            // 
            this.sottotitolo.Size = new System.Drawing.Size(486, 33);
            this.sottotitolo.Text = "Scegli il poster che vuoi eliminare";
            // 
            // help
            // 
            this.help.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.help.Visible = false;
            // 
            // elimina
            // 
            this.elimina.BackColor = System.Drawing.Color.Yellow;
            this.elimina.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.elimina.Cursor = System.Windows.Forms.Cursors.Hand;
            this.elimina.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.elimina.Location = new System.Drawing.Point(446, 592);
            this.elimina.Name = "elimina";
            this.elimina.Size = new System.Drawing.Size(96, 49);
            this.elimina.TabIndex = 23;
            this.elimina.Text = "Elimina";
            this.elimina.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.elimina.UseVisualStyleBackColor = false;
            this.elimina.Click += new System.EventHandler(this.elimina_Click);
            // 
            // annulla
            // 
            this.annulla.BackColor = System.Drawing.Color.Yellow;
            this.annulla.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("annulla.BackgroundImage")));
            this.annulla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.annulla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.annulla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.annulla.Location = new System.Drawing.Point(616, 592);
            this.annulla.Name = "annulla";
            this.annulla.Size = new System.Drawing.Size(96, 49);
            this.annulla.TabIndex = 24;
            this.annulla.Text = "Annulla";
            this.annulla.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.annulla.UseVisualStyleBackColor = false;
            this.annulla.Click += new System.EventHandler(this.annulla_Click);
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
            this.pannello.Controls.Add(this.noPoster);
            this.pannello.Location = new System.Drawing.Point(78, 127);
            this.pannello.Name = "pannello";
            this.pannello.Size = new System.Drawing.Size(464, 439);
            this.pannello.TabIndex = 54;
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
            // EliminaPosterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(1136, 739);
            this.Controls.Add(this.annulla);
            this.Controls.Add(this.pannello);
            this.Controls.Add(this.elimina);
            this.Name = "EliminaPosterForm";
            this.Text = "FormScegliConfigurazione";
            this.Controls.SetChildIndex(this.help, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            this.Controls.SetChildIndex(this.elimina, 0);
            this.Controls.SetChildIndex(this.pannello, 0);
            this.Controls.SetChildIndex(this.annulla, 0);
            this.pannello.ResumeLayout(false);
            this.pannello.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlButton elimina;
        private ControlButton annulla;
        private ControlButton indietro;
        private System.Windows.Forms.Panel pannello;
        private System.Windows.Forms.Label noPoster;
    }
}
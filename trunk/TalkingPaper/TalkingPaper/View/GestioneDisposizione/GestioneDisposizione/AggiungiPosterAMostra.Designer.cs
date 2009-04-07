namespace TalkingPaper.GestioneDisposizione
{
    partial class AggiungiPosterAMostra
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
            this.Annulla = new System.Windows.Forms.Button();
            this.Aggiungi = new System.Windows.Forms.Button();
            this.CreaNuova = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ElencoMostre = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).BeginInit();
            this.SuspendLayout();
            // 
            // sottotitolo
            // 
            this.sottotitolo.Size = new System.Drawing.Size(410, 33);
            this.sottotitolo.Text = "Aggiungi Poster Alla Mostra ";
            // 
            // Annulla
            //
            this.Annulla.Location = new System.Drawing.Point(332, 323);
            this.Annulla.Name = "Annulla";
            this.Annulla.Text = "Annulla";
            // 
            // Aggiungi
            // 
            this.Aggiungi.Location = new System.Drawing.Point(186, 323);
            this.Aggiungi.Name = "Aggiungi";
            this.Aggiungi.Text = "Aggiungi";
            // 
            // CreaNuova
            // 
            this.CreaNuova.Location = new System.Drawing.Point(475, 325);
            this.CreaNuova.Name = "CreaNuova";
            this.CreaNuova.Text = "Crea Nuova";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(53, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(496, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Seleziona la mostra oppure creane una nuova";
            // 
            // ElencoMostre
            // 
            this.ElencoMostre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElencoMostre.FormattingEnabled = true;
            this.ElencoMostre.Location = new System.Drawing.Point(99, 238);
            this.ElencoMostre.Name = "ElencoMostre";
            this.ElencoMostre.Size = new System.Drawing.Size(245, 24);
            this.ElencoMostre.TabIndex = 5;
            // 
            // AggiungiPosterAMostra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1192, 741);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ElencoMostre);
            this.Controls.Add(this.CreaNuova);
            this.Controls.Add(this.Aggiungi);
            this.Controls.Add(this.Annulla);
            this.Name = "AggiungiPosterAMostra";
            this.Text = "AggiungiPosterAMostra";
            this.Load += new System.EventHandler(this.AggiungiPosterAMostra_Load);
            this.Controls.SetChildIndex(this.Annulla, 0);
            this.Controls.SetChildIndex(this.grouppoControl, 0);
            this.Controls.SetChildIndex(this.Aggiungi, 0);
            this.Controls.SetChildIndex(this.CreaNuova, 0);
            this.Controls.SetChildIndex(this.pictureBoxPost1, 0);
            this.Controls.SetChildIndex(this.pictureBoxPost2, 0);
            this.Controls.SetChildIndex(this.ElencoMostre, 0);
            this.Controls.SetChildIndex(this.textBoxPost1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlButton Annulla;
        private ControlButton Aggiungi;
        private ControlButton CreaNuova;
        private ControlButton label1;
        private System.Windows.Forms.ComboBox ElencoMostre;
    }
}
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AggiungiPosterAMostra));
            this.Annulla = new TalkingPaper.MainButton();
            this.Aggiungi = new TalkingPaper.MainButton();
            this.CreaNuova = new TalkingPaper.ControlButton();
            this.label1 = new System.Windows.Forms.Label();
            this.ElencoMostre = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Indietro = new TalkingPaper.ControlButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).BeginInit();
            this.grouppoControl.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grouppoControl
            // 
            this.grouppoControl.Controls.Add(this.Indietro);
            this.grouppoControl.Location = new System.Drawing.Point(998, 12);
            this.grouppoControl.Size = new System.Drawing.Size(174, 91);
            // 
            // sottotitolo
            // 
            this.sottotitolo.Size = new System.Drawing.Size(511, 33);
            this.sottotitolo.Text = "Aggiungi Un Cartellone Alla Mostra ";
            // 
            // Annulla
            // 
            this.Annulla.BackColor = System.Drawing.Color.Yellow;
            this.Annulla.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Annulla.BackgroundImage")));
            this.Annulla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Annulla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Annulla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Annulla.Location = new System.Drawing.Point(243, 14);
            this.Annulla.Name = "Annulla";
            this.Annulla.Size = new System.Drawing.Size(226, 111);
            this.Annulla.TabIndex = 46;
            this.Annulla.Text = "Annulla";
            this.Annulla.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Annulla.UseVisualStyleBackColor = false;
            this.Annulla.Click += new System.EventHandler(this.Annulla_Click);
            // 
            // Aggiungi
            // 
            this.Aggiungi.BackColor = System.Drawing.Color.Yellow;
            this.Aggiungi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Aggiungi.BackgroundImage")));
            this.Aggiungi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Aggiungi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Aggiungi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Aggiungi.Location = new System.Drawing.Point(11, 14);
            this.Aggiungi.Name = "Aggiungi";
            this.Aggiungi.Size = new System.Drawing.Size(226, 111);
            this.Aggiungi.TabIndex = 45;
            this.Aggiungi.Text = "Aggiungi";
            this.Aggiungi.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Aggiungi.UseVisualStyleBackColor = false;
            this.Aggiungi.Click += new System.EventHandler(this.Aggiungi_Click);
            // 
            // CreaNuova
            // 
            this.CreaNuova.BackColor = System.Drawing.Color.Yellow;
            this.CreaNuova.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CreaNuova.BackgroundImage")));
            this.CreaNuova.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CreaNuova.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CreaNuova.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.CreaNuova.Location = new System.Drawing.Point(522, 28);
            this.CreaNuova.Name = "CreaNuova";
            this.CreaNuova.Size = new System.Drawing.Size(120, 62);
            this.CreaNuova.TabIndex = 48;
            this.CreaNuova.Text = "Crea Nuova";
            this.CreaNuova.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.CreaNuova.UseVisualStyleBackColor = false;
            this.CreaNuova.Click += new System.EventHandler(this.CreaNuova_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(4, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(496, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Seleziona la mostra oppure creane una nuova";
            // 
            // ElencoMostre
            // 
            this.ElencoMostre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElencoMostre.FormattingEnabled = true;
            this.ElencoMostre.Location = new System.Drawing.Point(50, 66);
            this.ElencoMostre.Name = "ElencoMostre";
            this.ElencoMostre.Size = new System.Drawing.Size(245, 24);
            this.ElencoMostre.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Orange;
            this.groupBox1.Controls.Add(this.Aggiungi);
            this.groupBox1.Controls.Add(this.Annulla);
            this.groupBox1.Location = new System.Drawing.Point(7, 329);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(481, 138);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Orange;
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.ElencoMostre);
            this.groupBox2.Controls.Add(this.CreaNuova);
            this.groupBox2.Location = new System.Drawing.Point(49, 172);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(653, 117);
            this.groupBox2.TabIndex = 49;
            this.groupBox2.TabStop = false;
            // 
            // Indietro
            // 
            this.Indietro.BackColor = System.Drawing.Color.Yellow;
            this.Indietro.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Indietro.BackgroundImage")));
            this.Indietro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Indietro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Indietro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Indietro.Location = new System.Drawing.Point(28, 19);
            this.Indietro.Name = "Indietro";
            this.Indietro.Size = new System.Drawing.Size(120, 62);
            this.Indietro.TabIndex = 50;
            this.Indietro.Text = "Indietro";
            this.Indietro.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Indietro.UseVisualStyleBackColor = false;
            this.Indietro.Click += new System.EventHandler(this.Indietro_Click);
            // 
            // AggiungiPosterAMostra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1192, 741);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "AggiungiPosterAMostra";
            this.Text = "AggiungiPosterAMostra";
            this.Load += new System.EventHandler(this.AggiungiPosterAMostra_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.grouppoControl, 0);
            this.Controls.SetChildIndex(this.pictureBoxPost1, 0);
            this.Controls.SetChildIndex(this.pictureBoxPost2, 0);
            this.Controls.SetChildIndex(this.textBoxPost, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).EndInit();
            this.grouppoControl.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MainButton Annulla;
        private MainButton Aggiungi;
        private ControlButton CreaNuova;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ElencoMostre;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private ControlButton Indietro;
    }
}
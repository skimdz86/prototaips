namespace TalkingPaper.Postering
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
            this.ElencoMostre = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CreaNuova = new TalkingPaper.ControlButton();
            this.Aggiungi = new TalkingPaper.MainButton();
            this.Annulla = new TalkingPaper.MainButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.controlButton1 = new TalkingPaper.ControlButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).BeginInit();
            this.grouppoControl.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grouppoControl
            // 
            this.grouppoControl.Controls.Add(this.controlButton1);
            this.grouppoControl.Location = new System.Drawing.Point(1031, 12);
            this.grouppoControl.Size = new System.Drawing.Size(141, 91);
            // 
            // sottotitolo
            // 
            this.sottotitolo.Size = new System.Drawing.Size(567, 33);
            this.sottotitolo.Text = "Aggiungi il tuo cartellone ad una mostra";
            // 
            // ElencoMostre
            // 
            this.ElencoMostre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElencoMostre.FormattingEnabled = true;
            this.ElencoMostre.Location = new System.Drawing.Point(32, 72);
            this.ElencoMostre.Name = "ElencoMostre";
            this.ElencoMostre.Size = new System.Drawing.Size(245, 24);
            this.ElencoMostre.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(27, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(440, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleziona la mostra oppure creane una nuova";
            // 
            // CreaNuova
            // 
            this.CreaNuova.BackColor = System.Drawing.Color.Yellow;
            this.CreaNuova.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CreaNuova.BackgroundImage")));
            this.CreaNuova.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CreaNuova.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CreaNuova.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.CreaNuova.Location = new System.Drawing.Point(535, 43);
            this.CreaNuova.Name = "CreaNuova";
            this.CreaNuova.Size = new System.Drawing.Size(120, 62);
            this.CreaNuova.TabIndex = 44;
            this.CreaNuova.Text = "Crea Nuova";
            this.CreaNuova.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.CreaNuova.UseVisualStyleBackColor = false;
            this.CreaNuova.Click += new System.EventHandler(this.CreaNuova_Click);
            // 
            // Aggiungi
            // 
            this.Aggiungi.BackColor = System.Drawing.Color.Yellow;
            this.Aggiungi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Aggiungi.BackgroundImage")));
            this.Aggiungi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Aggiungi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Aggiungi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Aggiungi.Location = new System.Drawing.Point(31, 15);
            this.Aggiungi.Name = "Aggiungi";
            this.Aggiungi.Size = new System.Drawing.Size(226, 111);
            this.Aggiungi.TabIndex = 45;
            this.Aggiungi.Text = "Aggiungi";
            this.Aggiungi.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Aggiungi.UseVisualStyleBackColor = false;
            this.Aggiungi.Click += new System.EventHandler(this.Aggiungi_Click);
            // 
            // Annulla
            // 
            this.Annulla.BackColor = System.Drawing.Color.Yellow;
            this.Annulla.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Annulla.BackgroundImage")));
            this.Annulla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Annulla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Annulla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Annulla.Location = new System.Drawing.Point(287, 15);
            this.Annulla.Name = "Annulla";
            this.Annulla.Size = new System.Drawing.Size(226, 111);
            this.Annulla.TabIndex = 46;
            this.Annulla.Text = "Annulla";
            this.Annulla.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Annulla.UseVisualStyleBackColor = false;
            this.Annulla.Click += new System.EventHandler(this.Annulla_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Orange;
            this.groupBox1.Controls.Add(this.Aggiungi);
            this.groupBox1.Controls.Add(this.Annulla);
            this.groupBox1.Location = new System.Drawing.Point(192, 312);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(534, 132);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Orange;
            this.groupBox2.Controls.Add(this.ElencoMostre);
            this.groupBox2.Controls.Add(this.CreaNuova);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(120, 154);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(680, 143);
            this.groupBox2.TabIndex = 48;
            this.groupBox2.TabStop = false;
            // 
            // controlButton1
            // 
            this.controlButton1.BackColor = System.Drawing.Color.Yellow;
            this.controlButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("controlButton1.BackgroundImage")));
            this.controlButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.controlButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.controlButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.controlButton1.Location = new System.Drawing.Point(9, 19);
            this.controlButton1.Name = "controlButton1";
            this.controlButton1.Size = new System.Drawing.Size(120, 62);
            this.controlButton1.TabIndex = 49;
            this.controlButton1.Text = "Indietro";
            this.controlButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.controlButton1.UseVisualStyleBackColor = false;
            this.controlButton1.Click += new System.EventHandler(this.controlButton1_Click);
            // 
            // AggiungiPosterAMostra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1184, 739);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "AggiungiPosterAMostra";
            this.Text = "Aggiunta del poster alla mostra - Fase di Postering";
            this.Load += new System.EventHandler(this.AggiungiPosterAMostra_Load);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            this.Controls.SetChildIndex(this.pictureBoxPost1, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.Controls.SetChildIndex(this.pictureBoxPost2, 0);
            this.Controls.SetChildIndex(this.grouppoControl, 0);
            this.Controls.SetChildIndex(this.textBoxPost, 0);
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

        private System.Windows.Forms.ComboBox ElencoMostre;
        private System.Windows.Forms.Label label1;
        private MainButton Annulla;
        private System.Windows.Forms.GroupBox groupBox1;
        private ControlButton controlButton1;
        private System.Windows.Forms.GroupBox groupBox2;
        private ControlButton CreaNuova;
        private MainButton Aggiungi;
    }
}
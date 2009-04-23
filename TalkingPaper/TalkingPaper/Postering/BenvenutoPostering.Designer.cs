namespace TalkingPaper.Postering
{
    partial class BenvenutoPostering
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BenvenutoPostering));
            this.NuovaMostra = new TalkingPaper.MainButton();
            this.Esci = new TalkingPaper.ControlButton();
            this.MostreEsistenti = new TalkingPaper.MainButton();
            this.button1 = new TalkingPaper.MainButton();
            this.SingoloPoster = new TalkingPaper.MainButton();
            this.ModificaSingoli = new TalkingPaper.MainButton();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).BeginInit();
            this.grouppoControl.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grouppoControl
            // 
            this.grouppoControl.Controls.Add(this.Esci);
            this.grouppoControl.Location = new System.Drawing.Point(1053, 12);
            this.grouppoControl.Size = new System.Drawing.Size(119, 91);
            // 
            // sottotitolo
            // 
            this.sottotitolo.Size = new System.Drawing.Size(392, 33);
            this.sottotitolo.Text = "Crea il tuo cartellone libero";
            // 
            // NuovaMostra
            // 
            this.NuovaMostra.BackColor = System.Drawing.Color.Yellow;
            this.NuovaMostra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NuovaMostra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NuovaMostra.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.NuovaMostra.Location = new System.Drawing.Point(46, 491);
            this.NuovaMostra.Name = "NuovaMostra";
            this.NuovaMostra.Size = new System.Drawing.Size(180, 88);
            this.NuovaMostra.TabIndex = 49;
            this.NuovaMostra.Text = "Crea Nuova Mostra";
            this.NuovaMostra.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.NuovaMostra.UseVisualStyleBackColor = false;
            this.NuovaMostra.Visible = false;
            // 
            // Esci
            // 
            this.Esci.BackColor = System.Drawing.Color.Yellow;
            this.Esci.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Esci.BackgroundImage")));
            this.Esci.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Esci.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Esci.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.Esci.Location = new System.Drawing.Point(6, 19);
            this.Esci.Name = "Esci";
            this.Esci.Size = new System.Drawing.Size(96, 49);
            this.Esci.TabIndex = 48;
            this.Esci.Text = "Menu";
            this.Esci.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Esci.UseVisualStyleBackColor = false;
            this.Esci.Click += new System.EventHandler(this.Esci_Click_1);
            // 
            // MostreEsistenti
            // 
            this.MostreEsistenti.BackColor = System.Drawing.Color.Yellow;
            this.MostreEsistenti.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MostreEsistenti.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MostreEsistenti.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.MostreEsistenti.Location = new System.Drawing.Point(46, 548);
            this.MostreEsistenti.Name = "MostreEsistenti";
            this.MostreEsistenti.Size = new System.Drawing.Size(180, 88);
            this.MostreEsistenti.TabIndex = 47;
            this.MostreEsistenti.Text = "Crea Mostra da storia esistente";
            this.MostreEsistenti.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MostreEsistenti.UseVisualStyleBackColor = false;
            this.MostreEsistenti.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Yellow;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(46, 517);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 88);
            this.button1.TabIndex = 46;
            this.button1.Text = "Modifica mostra già esistente";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            // 
            // SingoloPoster
            // 
            this.SingoloPoster.BackColor = System.Drawing.Color.Yellow;
            this.SingoloPoster.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SingoloPoster.BackgroundImage")));
            this.SingoloPoster.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SingoloPoster.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SingoloPoster.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.SingoloPoster.Location = new System.Drawing.Point(17, 30);
            this.SingoloPoster.Name = "SingoloPoster";
            this.SingoloPoster.Size = new System.Drawing.Size(180, 88);
            this.SingoloPoster.TabIndex = 45;
            this.SingoloPoster.Text = "Crea cartellone";
            this.SingoloPoster.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.SingoloPoster.UseVisualStyleBackColor = false;
            this.SingoloPoster.Click += new System.EventHandler(this.SingoloPoster_Click_1);
            // 
            // ModificaSingoli
            // 
            this.ModificaSingoli.BackColor = System.Drawing.Color.Yellow;
            this.ModificaSingoli.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ModificaSingoli.BackgroundImage")));
            this.ModificaSingoli.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ModificaSingoli.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ModificaSingoli.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.ModificaSingoli.Location = new System.Drawing.Point(296, 30);
            this.ModificaSingoli.Name = "ModificaSingoli";
            this.ModificaSingoli.Size = new System.Drawing.Size(180, 88);
            this.ModificaSingoli.TabIndex = 44;
            this.ModificaSingoli.Text = "Modifica un cartellone";
            this.ModificaSingoli.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ModificaSingoli.UseVisualStyleBackColor = false;
            this.ModificaSingoli.Click += new System.EventHandler(this.ModificaSingoli_Click_1);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(18, 704);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.TabIndex = 11;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(59, 539);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 25);
            this.label3.TabIndex = 27;
            this.label3.Text = "Gestione Mostre";
            this.label3.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Orange;
            this.groupBox1.Controls.Add(this.ModificaSingoli);
            this.groupBox1.Controls.Add(this.SingoloPoster);
            this.groupBox1.Location = new System.Drawing.Point(28, 157);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(538, 164);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            // 
            // BenvenutoPostering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1184, 739);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.MostreEsistenti);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.NuovaMostra);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "BenvenutoPostering";
            this.Text = "Benvenuto - Fase di Postering";
            this.Load += new System.EventHandler(this.BenvenutoPostering_Load);
            this.Controls.SetChildIndex(this.NuovaMostra, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.MostreEsistenti, 0);
            this.Controls.SetChildIndex(this.progressBar1, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            this.Controls.SetChildIndex(this.grouppoControl, 0);
            this.Controls.SetChildIndex(this.pictureBoxPost2, 0);
            this.Controls.SetChildIndex(this.textBoxPost, 0);
            this.Controls.SetChildIndex(this.pictureBoxPost1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).EndInit();
            this.grouppoControl.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MainButton NuovaMostra;
        private ControlButton Esci;
        private MainButton MostreEsistenti;
        private MainButton button1;
        private MainButton SingoloPoster;
        private MainButton ModificaSingoli;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;

    }
}


namespace TalkingPaper.GestioneDisposizione
{
    partial class BenvenutoGestioneDisposizione
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BenvenutoGestioneDisposizione));
            this.ModificaSingoli = new TalkingPaper.MainButton();
            this.button1 = new TalkingPaper.MainButton();
            this.Fase = new System.Windows.Forms.Label();
            this.Menu = new TalkingPaper.ControlButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).BeginInit();
            this.grouppoControl.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grouppoControl
            // 
            this.grouppoControl.Controls.Add(this.Menu);
            this.grouppoControl.Location = new System.Drawing.Point(1024, 12);
            this.grouppoControl.Size = new System.Drawing.Size(148, 91);
            // 
            // sottotitolo
            // 
            this.sottotitolo.Size = new System.Drawing.Size(243, 33);
            this.sottotitolo.Text = "Cosa vuoi fare ?";
            // 
            // ModificaSingoli
            // 
            this.ModificaSingoli.BackColor = System.Drawing.Color.Yellow;
            this.ModificaSingoli.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ModificaSingoli.BackgroundImage")));
            this.ModificaSingoli.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ModificaSingoli.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ModificaSingoli.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.ModificaSingoli.Location = new System.Drawing.Point(300, 16);
            this.ModificaSingoli.Name = "ModificaSingoli";
            this.ModificaSingoli.Size = new System.Drawing.Size(180, 88);
            this.ModificaSingoli.TabIndex = 45;
            this.ModificaSingoli.Text = "Modifica un Cartellone";
            this.ModificaSingoli.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ModificaSingoli.UseVisualStyleBackColor = false;
            this.ModificaSingoli.Click += new System.EventHandler(this.ModificaSingoli_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Yellow;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(12, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 88);
            this.button1.TabIndex = 46;
            this.button1.Text = "Crea Nuovo Cartellone";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Fase
            // 
            this.Fase.AutoSize = true;
            this.Fase.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.Fase.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fase.ForeColor = System.Drawing.Color.Red;
            this.Fase.Location = new System.Drawing.Point(12, 23);
            this.Fase.Name = "Fase";
            this.Fase.Size = new System.Drawing.Size(287, 37);
            this.Fase.TabIndex = 14;
            this.Fase.Text = "Fase di Authoring";
            this.Fase.Visible = false;
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.Color.Yellow;
            this.Menu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Menu.BackgroundImage")));
            this.Menu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Menu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Menu.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.Menu.Location = new System.Drawing.Point(15, 19);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(96, 49);
            this.Menu.TabIndex = 0;
            this.Menu.Text = "Menu";
            this.Menu.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Menu.UseVisualStyleBackColor = false;
            this.Menu.Click += new System.EventHandler(this.Menu_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Orange;
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.ModificaSingoli);
            this.groupBox1.Location = new System.Drawing.Point(157, 209);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(536, 136);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            // 
            // BenvenutoGestioneDisposizione
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1136, 739);
            this.Controls.Add(this.Fase);
            this.Controls.Add(this.groupBox1);
            this.Name = "BenvenutoGestioneDisposizione";
            this.Text = "BenvenutoPostering";
            this.Load += new System.EventHandler(this.BenvenutoPostering_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.Fase, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.Controls.SetChildIndex(this.grouppoControl, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            this.Controls.SetChildIndex(this.pictureBoxPost1, 0);
            this.Controls.SetChildIndex(this.pictureBoxPost2, 0);
            this.Controls.SetChildIndex(this.textBoxPost, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).EndInit();
            this.grouppoControl.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Fase;
        private MainButton ModificaSingoli;
        private MainButton button1;
        private ControlButton Menu;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
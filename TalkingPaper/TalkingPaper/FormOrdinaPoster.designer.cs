namespace TalkingPaper
{
    partial class FormOrdinaPoster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOrdinaPoster));
            this.listBoxBefore = new System.Windows.Forms.ListBox();
            this.listBoxAfter = new System.Windows.Forms.ListBox();
            this.ButtonAggiungi = new TalkingPaper.MainButton();
            this.buttonRimuovi = new TalkingPaper.MainButton();
            this.buttonSalva = new TalkingPaper.ControlButton();
            this.buttonEsci = new TalkingPaper.ControlButton();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxMostra = new System.Windows.Forms.ListBox();
            this.labelMostra = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).BeginInit();
            this.grouppoControl.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grouppoControl
            // 
            this.grouppoControl.Controls.Add(this.buttonEsci);
            this.grouppoControl.Controls.Add(this.buttonSalva);
            // 
            // sottotitolo
            // 
            this.sottotitolo.Size = new System.Drawing.Size(282, 33);
            this.sottotitolo.Text = "Ordina i tuoi poster";
            // 
            // listBoxBefore
            // 
            this.listBoxBefore.FormattingEnabled = true;
            this.listBoxBefore.Location = new System.Drawing.Point(399, 201);
            this.listBoxBefore.Name = "listBoxBefore";
            this.listBoxBefore.Size = new System.Drawing.Size(235, 316);
            this.listBoxBefore.TabIndex = 0;
            this.listBoxBefore.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OnDoubleClikBBefore);
            // 
            // listBoxAfter
            // 
            this.listBoxAfter.FormattingEnabled = true;
            this.listBoxAfter.Location = new System.Drawing.Point(691, 201);
            this.listBoxAfter.Name = "listBoxAfter";
            this.listBoxAfter.Size = new System.Drawing.Size(224, 316);
            this.listBoxAfter.TabIndex = 1;
            this.listBoxAfter.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OnMouseDoubleClickBAfter);
            // 
            // ButtonAggiungi
            // 
            this.ButtonAggiungi.BackColor = System.Drawing.Color.Yellow;
            this.ButtonAggiungi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButtonAggiungi.BackgroundImage")));
            this.ButtonAggiungi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonAggiungi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonAggiungi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.ButtonAggiungi.Location = new System.Drawing.Point(6, 14);
            this.ButtonAggiungi.Name = "ButtonAggiungi";
            this.ButtonAggiungi.Size = new System.Drawing.Size(226, 111);
            this.ButtonAggiungi.TabIndex = 2;
            this.ButtonAggiungi.Text = "Aggiungi";
            this.ButtonAggiungi.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ButtonAggiungi.UseVisualStyleBackColor = false;
            this.ButtonAggiungi.Click += new System.EventHandler(this.ButtonAggiungi_Click);
            // 
            // buttonRimuovi
            // 
            this.buttonRimuovi.BackColor = System.Drawing.Color.Yellow;
            this.buttonRimuovi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonRimuovi.BackgroundImage")));
            this.buttonRimuovi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonRimuovi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRimuovi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.buttonRimuovi.Location = new System.Drawing.Point(252, 14);
            this.buttonRimuovi.Name = "buttonRimuovi";
            this.buttonRimuovi.Size = new System.Drawing.Size(226, 111);
            this.buttonRimuovi.TabIndex = 3;
            this.buttonRimuovi.Text = "Rimuovi";
            this.buttonRimuovi.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonRimuovi.UseVisualStyleBackColor = false;
            this.buttonRimuovi.Click += new System.EventHandler(this.buttonRimuovi_Click);
            // 
            // buttonSalva
            // 
            this.buttonSalva.BackColor = System.Drawing.Color.Yellow;
            this.buttonSalva.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSalva.BackgroundImage")));
            this.buttonSalva.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSalva.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSalva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.buttonSalva.Location = new System.Drawing.Point(31, 19);
            this.buttonSalva.Name = "buttonSalva";
            this.buttonSalva.Size = new System.Drawing.Size(120, 62);
            this.buttonSalva.TabIndex = 4;
            this.buttonSalva.Text = "Salva";
            this.buttonSalva.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonSalva.UseVisualStyleBackColor = false;
            this.buttonSalva.Click += new System.EventHandler(this.buttonSalva_Click);
            // 
            // buttonEsci
            // 
            this.buttonEsci.BackColor = System.Drawing.Color.Yellow;
            this.buttonEsci.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonEsci.BackgroundImage")));
            this.buttonEsci.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonEsci.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEsci.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.buttonEsci.Location = new System.Drawing.Point(197, 19);
            this.buttonEsci.Name = "buttonEsci";
            this.buttonEsci.Size = new System.Drawing.Size(120, 62);
            this.buttonEsci.TabIndex = 5;
            this.buttonEsci.Text = "Esci";
            this.buttonEsci.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonEsci.UseVisualStyleBackColor = false;
            this.buttonEsci.Click += new System.EventHandler(this.buttonEsci_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(418, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "NESSUN POSTER PRESENTE";
            this.label1.Visible = false;
            // 
            // listBoxMostra
            // 
            this.listBoxMostra.FormattingEnabled = true;
            this.listBoxMostra.Location = new System.Drawing.Point(111, 201);
            this.listBoxMostra.Name = "listBoxMostra";
            this.listBoxMostra.Size = new System.Drawing.Size(223, 316);
            this.listBoxMostra.TabIndex = 9;
            this.listBoxMostra.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnMouseClick);
            // 
            // labelMostra
            // 
            this.labelMostra.AutoSize = true;
            this.labelMostra.Location = new System.Drawing.Point(131, 179);
            this.labelMostra.Name = "labelMostra";
            this.labelMostra.Size = new System.Drawing.Size(169, 13);
            this.labelMostra.TabIndex = 10;
            this.labelMostra.Text = "NESSUNA MOSTRA PRESENTE";
            this.labelMostra.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Orange;
            this.groupBox1.Controls.Add(this.buttonRimuovi);
            this.groupBox1.Controls.Add(this.ButtonAggiungi);
            this.groupBox1.Location = new System.Drawing.Point(240, 553);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(484, 132);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            // 
            // FormOrdinaPoster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(1184, 739);
            this.Controls.Add(this.listBoxMostra);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxAfter);
            this.Controls.Add(this.listBoxBefore);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelMostra);
            this.Name = "FormOrdinaPoster";
            this.Text = "FormOrdinaPoster";
            this.Load += new System.EventHandler(this.FormOrdinaPoster_Load);
            this.Controls.SetChildIndex(this.labelMostra, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.listBoxBefore, 0);
            this.Controls.SetChildIndex(this.listBoxAfter, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.listBoxMostra, 0);
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

        private System.Windows.Forms.ListBox listBoxBefore;
        private System.Windows.Forms.ListBox listBoxAfter;
        private MainButton ButtonAggiungi;
        private MainButton buttonRimuovi;
        private ControlButton buttonSalva;
        private ControlButton buttonEsci;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxMostra;
        private System.Windows.Forms.Label labelMostra;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
namespace TalkingPaper.GestioneDisposizione
{
    partial class NuovoPoster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NuovoPoster));
            this.button2 = new TalkingPaper.MainButton();
            this.button1 = new TalkingPaper.MainButton();
            this.Ordine = new System.Windows.Forms.TextBox();
            this.Descrizione = new System.Windows.Forms.TextBox();
            this.Nome = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.controlButton1 = new TalkingPaper.ControlButton();
            this.controlButton2 = new TalkingPaper.ControlButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).BeginInit();
            this.grouppoControl.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grouppoControl
            // 
            this.grouppoControl.Controls.Add(this.controlButton2);
            this.grouppoControl.Controls.Add(this.controlButton1);
            this.grouppoControl.Location = new System.Drawing.Point(892, 12);
            this.grouppoControl.Size = new System.Drawing.Size(280, 91);
            // 
            // sottotitolo
            // 
            this.sottotitolo.Size = new System.Drawing.Size(256, 33);
            this.sottotitolo.Text = "Nuovo Cartellone";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Yellow;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(243, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(226, 111);
            this.button2.TabIndex = 44;
            this.button2.Text = "Annulla";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Yellow;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(6, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(226, 111);
            this.button1.TabIndex = 45;
            this.button1.Text = "Salva";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Ordine
            // 
            this.Ordine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ordine.Location = new System.Drawing.Point(402, 330);
            this.Ordine.Name = "Ordine";
            this.Ordine.Size = new System.Drawing.Size(269, 26);
            this.Ordine.TabIndex = 28;
            // 
            // Descrizione
            // 
            this.Descrizione.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Descrizione.Location = new System.Drawing.Point(402, 269);
            this.Descrizione.Multiline = true;
            this.Descrizione.Name = "Descrizione";
            this.Descrizione.Size = new System.Drawing.Size(269, 26);
            this.Descrizione.TabIndex = 27;
            // 
            // Nome
            // 
            this.Nome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nome.Location = new System.Drawing.Point(402, 213);
            this.Nome.Name = "Nome";
            this.Nome.Size = new System.Drawing.Size(269, 26);
            this.Nome.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.DarkOrange;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(232, 332);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 24);
            this.label4.TabIndex = 25;
            this.label4.Text = "Ordine";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.DarkOrange;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(232, 271);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 24);
            this.label3.TabIndex = 24;
            this.label3.Text = "Descrizione";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DarkOrange;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(232, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 24);
            this.label2.TabIndex = 23;
            this.label2.Text = "Nome";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkOrange;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(170, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(620, 31);
            this.label1.TabIndex = 22;
            this.label1.Text = "Inserisci il nome e la descrizione del cartellone";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Orange;
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Location = new System.Drawing.Point(236, 423);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(475, 138);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            // 
            // controlButton1
            // 
            this.controlButton1.BackColor = System.Drawing.Color.Yellow;
            this.controlButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("controlButton1.BackgroundImage")));
            this.controlButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.controlButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.controlButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.controlButton1.Location = new System.Drawing.Point(147, 19);
            this.controlButton1.Name = "controlButton1";
            this.controlButton1.Size = new System.Drawing.Size(120, 62);
            this.controlButton1.TabIndex = 0;
            this.controlButton1.Text = "Menu";
            this.controlButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.controlButton1.UseVisualStyleBackColor = false;
            this.controlButton1.Click += new System.EventHandler(this.controlButton1_Click);
            // 
            // controlButton2
            // 
            this.controlButton2.BackColor = System.Drawing.Color.Yellow;
            this.controlButton2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("controlButton2.BackgroundImage")));
            this.controlButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.controlButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.controlButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.controlButton2.Location = new System.Drawing.Point(15, 19);
            this.controlButton2.Name = "controlButton2";
            this.controlButton2.Size = new System.Drawing.Size(120, 62);
            this.controlButton2.TabIndex = 1;
            this.controlButton2.Text = "Indietro";
            this.controlButton2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.controlButton2.UseVisualStyleBackColor = false;
            this.controlButton2.Click += new System.EventHandler(this.controlButton2_Click);
            // 
            // NuovoPoster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(1184, 739);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Ordine);
            this.Controls.Add(this.Descrizione);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Nome);
            this.Name = "NuovoPoster";
            this.Text = "NuovoPoster";
            this.Load += new System.EventHandler(this.NuovoPoster_Load);
            this.Controls.SetChildIndex(this.Nome, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.Descrizione, 0);
            this.Controls.SetChildIndex(this.Ordine, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.pictureBoxPost2, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            this.Controls.SetChildIndex(this.grouppoControl, 0);
            this.Controls.SetChildIndex(this.pictureBoxPost1, 0);
            this.Controls.SetChildIndex(this.textBoxPost, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).EndInit();
            this.grouppoControl.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MainButton button2;
        private MainButton button1;
        private System.Windows.Forms.TextBox Ordine;
        private System.Windows.Forms.TextBox Descrizione;
        private System.Windows.Forms.TextBox Nome;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private ControlButton controlButton2;
        private ControlButton controlButton1;
    }
}
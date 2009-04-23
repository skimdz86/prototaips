namespace TalkingPaper.GestioneDisposizione
{
    partial class CreaNuovaMostraPerSingolo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreaNuovaMostraPerSingolo));
            this.label3 = new System.Windows.Forms.Label();
            this.Credits = new System.Windows.Forms.TextBox();
            this.Crea = new TalkingPaper.MainButton();
            this.Annulla = new TalkingPaper.MainButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Autore = new System.Windows.Forms.TextBox();
            this.Nome = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Indietro = new TalkingPaper.ControlButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).BeginInit();
            this.grouppoControl.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grouppoControl
            // 
            this.grouppoControl.Controls.Add(this.Indietro);
            this.grouppoControl.Location = new System.Drawing.Point(1011, 12);
            this.grouppoControl.Size = new System.Drawing.Size(161, 91);
            // 
            // sottotitolo
            // 
            this.sottotitolo.Size = new System.Drawing.Size(353, 33);
            this.sottotitolo.Text = "Crea Mostra per Singolo";
            this.sottotitolo.Click += new System.EventHandler(this.sottotitolo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(64, 300);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 24);
            this.label3.TabIndex = 33;
            this.label3.Text = "Credits";
            // 
            // Credits
            // 
            this.Credits.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Credits.Location = new System.Drawing.Point(297, 295);
            this.Credits.Name = "Credits";
            this.Credits.Size = new System.Drawing.Size(270, 29);
            this.Credits.TabIndex = 32;
            // 
            // Crea
            // 
            this.Crea.BackColor = System.Drawing.Color.Yellow;
            this.Crea.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Crea.BackgroundImage")));
            this.Crea.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Crea.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Crea.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Crea.Location = new System.Drawing.Point(6, 19);
            this.Crea.Name = "Crea";
            this.Crea.Size = new System.Drawing.Size(226, 111);
            this.Crea.TabIndex = 45;
            this.Crea.Text = "Crea Mostra";
            this.Crea.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Crea.UseVisualStyleBackColor = false;
            this.Crea.Click += new System.EventHandler(this.Crea_Click);
            // 
            // Annulla
            // 
            this.Annulla.BackColor = System.Drawing.Color.Yellow;
            this.Annulla.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Annulla.BackgroundImage")));
            this.Annulla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Annulla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Annulla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Annulla.Location = new System.Drawing.Point(242, 19);
            this.Annulla.Name = "Annulla";
            this.Annulla.Size = new System.Drawing.Size(226, 111);
            this.Annulla.TabIndex = 44;
            this.Annulla.Text = "Annulla";
            this.Annulla.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Annulla.UseVisualStyleBackColor = false;
            this.Annulla.Click += new System.EventHandler(this.Annulla_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(64, 246);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 24);
            this.label2.TabIndex = 29;
            this.label2.Text = "Autore";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(64, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 24);
            this.label1.TabIndex = 28;
            this.label1.Text = "Nome della mostra";
            // 
            // Autore
            // 
            this.Autore.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Autore.Location = new System.Drawing.Point(297, 241);
            this.Autore.Name = "Autore";
            this.Autore.Size = new System.Drawing.Size(270, 29);
            this.Autore.TabIndex = 27;
            // 
            // Nome
            // 
            this.Nome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nome.Location = new System.Drawing.Point(297, 189);
            this.Nome.Name = "Nome";
            this.Nome.Size = new System.Drawing.Size(270, 29);
            this.Nome.TabIndex = 26;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Orange;
            this.groupBox1.Controls.Add(this.Crea);
            this.groupBox1.Controls.Add(this.Annulla);
            this.groupBox1.Location = new System.Drawing.Point(140, 409);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(474, 138);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            // 
            // Indietro
            // 
            this.Indietro.BackColor = System.Drawing.Color.Yellow;
            this.Indietro.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Indietro.BackgroundImage")));
            this.Indietro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Indietro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Indietro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Indietro.Location = new System.Drawing.Point(20, 19);
            this.Indietro.Name = "Indietro";
            this.Indietro.Size = new System.Drawing.Size(120, 62);
            this.Indietro.TabIndex = 48;
            this.Indietro.Text = "Indietro";
            this.Indietro.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Indietro.UseVisualStyleBackColor = false;
            this.Indietro.Click += new System.EventHandler(this.Indietro_Click);
            // 
            // CreaNuovaMostraPerSingolo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1184, 739);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Nome);
            this.Controls.Add(this.Autore);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Credits);
            this.Name = "CreaNuovaMostraPerSingolo";
            this.Text = "CreaNuovaMostraPerSingolo";
            this.Load += new System.EventHandler(this.CreaNuovaMostraPerSingolo_Load);
            this.Controls.SetChildIndex(this.pictureBoxPost2, 0);
            this.Controls.SetChildIndex(this.Credits, 0);
            this.Controls.SetChildIndex(this.grouppoControl, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.pictureBoxPost1, 0);
            this.Controls.SetChildIndex(this.Autore, 0);
            this.Controls.SetChildIndex(this.textBoxPost, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.Controls.SetChildIndex(this.Nome, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).EndInit();
            this.grouppoControl.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Credits;
        private MainButton Crea;
        private MainButton Annulla;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Autore;
        private System.Windows.Forms.TextBox Nome;
        private System.Windows.Forms.GroupBox groupBox1;
        private ControlButton Indietro;
    }
}
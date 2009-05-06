namespace TalkingPaper.Administration
{
    partial class NuovaGrigliaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NuovaGrigliaForm));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.annulla = new TalkingPaper.MainButton();
            this.ok = new TalkingPaper.MainButton();
            this.Indietro = new TalkingPaper.ControlButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // titolo
            // 
            this.titolo.Location = new System.Drawing.Point(22, 9);
            // 
            // sottotitolo
            // 
            this.sottotitolo.Size = new System.Drawing.Size(513, 33);
            this.sottotitolo.Text = "Crea nuovo supporto per i cartelloni";
            // 
            // help
            // 
            this.help.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.help.Location = new System.Drawing.Point(887, 31);
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(165, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(543, 64);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inserisci negli spazi sottostanti il nome e  le dimensioni della nuova griglia";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(515, 362);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(515, 311);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(222, 357);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Numero di colonne";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(222, 306);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Numero di righe";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Orange;
            this.groupBox1.Controls.Add(this.annulla);
            this.groupBox1.Controls.Add(this.ok);
            this.groupBox1.Location = new System.Drawing.Point(181, 463);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(496, 143);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // annulla
            // 
            this.annulla.BackColor = System.Drawing.Color.Yellow;
            this.annulla.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("annulla.BackgroundImage")));
            this.annulla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.annulla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.annulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.annulla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.annulla.Location = new System.Drawing.Point(255, 19);
            this.annulla.Name = "annulla";
            this.annulla.Size = new System.Drawing.Size(226, 111);
            this.annulla.TabIndex = 7;
            this.annulla.Text = "Annulla";
            this.annulla.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.annulla.UseVisualStyleBackColor = false;
            this.annulla.Click += new System.EventHandler(this.annulla_Click);
            // 
            // ok
            // 
            this.ok.BackColor = System.Drawing.Color.Yellow;
            this.ok.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ok.BackgroundImage")));
            this.ok.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ok.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.ok.Location = new System.Drawing.Point(13, 19);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(226, 111);
            this.ok.TabIndex = 6;
            this.ok.Text = "Conferma";
            this.ok.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ok.UseVisualStyleBackColor = false;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // Indietro
            // 
            this.Indietro.BackColor = System.Drawing.Color.Yellow;
            this.Indietro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Indietro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Indietro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Indietro.Location = new System.Drawing.Point(0, 0);
            this.Indietro.Name = "Indietro";
            this.Indietro.Size = new System.Drawing.Size(75, 23);
            this.Indietro.TabIndex = 0;
            this.Indietro.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Indietro.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(515, 257);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(222, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nome";
            // 
            // NuovaGrigliaForm
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.CancelButton = this.annulla;
            this.ClientSize = new System.Drawing.Size(1036, 739);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Name = "NuovaGrigliaForm";
            this.Text = "TagRigaColonna";
            this.Controls.SetChildIndex(this.help, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.textBox2, 0);
            this.Controls.SetChildIndex(this.textBox3, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private MainButton ok;
        private MainButton annulla;
        private System.Windows.Forms.GroupBox groupBox1;
        private ControlButton Indietro;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
    }
}
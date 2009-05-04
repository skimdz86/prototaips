namespace TalkingPaper.Authoring
{
    partial class NuovoCartelloneForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NuovoCartelloneForm));
            this.Ordine = new System.Windows.Forms.TextBox();
            this.Descrizione = new System.Windows.Forms.TextBox();
            this.Nome = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mainButton1 = new TalkingPaper.MainButton();
            this.mainButton2 = new TalkingPaper.MainButton();
            //((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).BeginInit();
            this.SuspendLayout();
            // 
            // grouppoControl
            // 
           // this.grouppoControl.Location = new System.Drawing.Point(892, 12);
           // this.grouppoControl.Size = new System.Drawing.Size(280, 91);
            // 
            // sottotitolo
            // 
            this.sottotitolo.Size = new System.Drawing.Size(256, 33);
            this.sottotitolo.Text = "Nuovo Cartellone";
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
            this.label4.Size = new System.Drawing.Size(72, 24);
            this.label4.TabIndex = 25;
            this.label4.Text = "Classe";
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
            // mainButton1
            // 
            this.mainButton1.BackColor = System.Drawing.Color.Yellow;
            this.mainButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mainButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mainButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.mainButton1.Image = ((System.Drawing.Image)(resources.GetObject("mainButton1.Image")));
            this.mainButton1.Location = new System.Drawing.Point(549, 439);
            this.mainButton1.Name = "mainButton1";
            this.mainButton1.Size = new System.Drawing.Size(180, 88);
            this.mainButton1.TabIndex = 45;
            this.mainButton1.Text = "ANNULLA";
            this.mainButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.mainButton1.UseVisualStyleBackColor = false;
            this.mainButton1.Click += new System.EventHandler(this.mainButton1_Click);
            // 
            // mainButton2
            // 
            this.mainButton2.BackColor = System.Drawing.Color.Yellow;
            this.mainButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mainButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mainButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.mainButton2.Location = new System.Drawing.Point(309, 439);
            this.mainButton2.Name = "mainButton2";
            this.mainButton2.Size = new System.Drawing.Size(180, 88);
            this.mainButton2.TabIndex = 44;
            this.mainButton2.Text = "CONFERMA";
            this.mainButton2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.mainButton2.UseVisualStyleBackColor = false;
            this.mainButton2.Click += new System.EventHandler(this.mainButton2_Click);
            // 
            // NuovoCartelloneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(1184, 739);
            this.Controls.Add(this.mainButton1);
            this.Controls.Add(this.mainButton2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Ordine);
            this.Controls.Add(this.Descrizione);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Nome);
            this.Name = "NuovoCartelloneForm";
            this.Text = "NuovoPoster";
            this.Load += new System.EventHandler(this.NuovoPoster_Load);
            this.Controls.SetChildIndex(this.Nome, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.Descrizione, 0);
            this.Controls.SetChildIndex(this.Ordine, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            //this.Controls.SetChildIndex(this.pictureBoxPost2, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            //this.Controls.SetChildIndex(this.grouppoControl, 0);
            //this.Controls.SetChildIndex(this.pictureBoxPost1, 0);
            //this.Controls.SetChildIndex(this.textBoxPost, 0);
            this.Controls.SetChildIndex(this.mainButton2, 0);
            this.Controls.SetChildIndex(this.mainButton1, 0);
            //((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Ordine;
        private System.Windows.Forms.TextBox Descrizione;
        private System.Windows.Forms.TextBox Nome;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private MainButton mainButton1;
        private MainButton mainButton2;
    }
}
namespace TalkingPaper.Welcome
{
    partial class IndexForm
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IndexForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.mainButton1 = new TalkingPaper.MainButton();
            this.label6 = new System.Windows.Forms.Label();
            this.mainButton2 = new TalkingPaper.MainButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(237, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(454, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Benvenuto ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(31, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(357, 34);
            this.label2.TabIndex = 1;
            this.label2.Text = "Se sei già registrato effettua il login";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(31, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "USERNAME";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(31, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "PASSWORD";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(258, 166);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(296, 20);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(258, 227);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(296, 20);
            this.textBox2.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Location = new System.Drawing.Point(31, 315);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(357, 34);
            this.label5.TabIndex = 6;
            this.label5.Text = "Altrimenti effettua la registrazione";
            // 
            // mainButton1
            // 
            this.mainButton1.BackColor = System.Drawing.Color.Yellow;
            this.mainButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mainButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mainButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.mainButton1.Location = new System.Drawing.Point(415, 286);
            this.mainButton1.Name = "mainButton1";
            this.mainButton1.Size = new System.Drawing.Size(180, 88);
            this.mainButton1.TabIndex = 7;
            this.mainButton1.Text = "REGISTRAZIONE";
            this.mainButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.mainButton1.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label6.Location = new System.Drawing.Point(31, 413);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(357, 34);
            this.label6.TabIndex = 8;
            this.label6.Text = "ERRORE!!!";
            this.label6.Visible = false;
            // 
            // mainButton2
            // 
            this.mainButton2.BackColor = System.Drawing.Color.Yellow;
            this.mainButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mainButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mainButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.mainButton2.Image = ((System.Drawing.Image)(resources.GetObject("mainButton2.Image")));
            this.mainButton2.Location = new System.Drawing.Point(848, 9);
            this.mainButton2.Name = "mainButton2";
            this.mainButton2.Size = new System.Drawing.Size(180, 88);
            this.mainButton2.TabIndex = 9;
            this.mainButton2.Text = "ESCI DAL PROGRAMMA";
            this.mainButton2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.mainButton2.UseVisualStyleBackColor = false;
            this.mainButton2.Click += new System.EventHandler(this.mainButton2_Click);
            // 
            // IndexForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(1028, 739);
            this.Controls.Add(this.mainButton2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mainButton1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "IndexForm";
            this.Text = "Index";
            this.Load += new System.EventHandler(this.Index_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private MainButton mainButton1;
        private System.Windows.Forms.Label label6;
        private MainButton mainButton2;
    }
}
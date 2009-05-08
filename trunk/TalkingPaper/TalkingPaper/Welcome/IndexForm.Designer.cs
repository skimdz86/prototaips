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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.RegistrazioneButton = new TalkingPaper.MainButton();
            this.erroreRfid = new System.Windows.Forms.Label();
            this.EsciButton = new TalkingPaper.MainButton();
            this.LoginButton = new TalkingPaper.MainButton();
            this.configura = new TalkingPaper.MainButton();
            this.SuspendLayout();
            // 
            // titolo
            // 
            this.titolo.Size = new System.Drawing.Size(264, 55);
            this.titolo.Text = "Benvenuto";
            // 
            // sottotitolo
            // 
            this.sottotitolo.Visible = false;
            // 
            // help
            // 
            this.help.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
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
            // RegistrazioneButton
            // 
            this.RegistrazioneButton.BackColor = System.Drawing.Color.Yellow;
            this.RegistrazioneButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.RegistrazioneButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RegistrazioneButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.RegistrazioneButton.Location = new System.Drawing.Point(415, 286);
            this.RegistrazioneButton.Name = "RegistrazioneButton";
            this.RegistrazioneButton.Size = new System.Drawing.Size(180, 88);
            this.RegistrazioneButton.TabIndex = 7;
            this.RegistrazioneButton.Text = "REGISTRAZIONE";
            this.RegistrazioneButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.RegistrazioneButton.UseVisualStyleBackColor = false;
            this.RegistrazioneButton.Click += new System.EventHandler(this.RegistrazioneButton_Click);
            // 
            // erroreRfid
            // 
            this.erroreRfid.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.erroreRfid.ForeColor = System.Drawing.Color.Red;
            this.erroreRfid.Location = new System.Drawing.Point(29, 441);
            this.erroreRfid.Name = "erroreRfid";
            this.erroreRfid.Size = new System.Drawing.Size(835, 47);
            this.erroreRfid.TabIndex = 8;
            this.erroreRfid.Text = "Attenzione! Il lettore Rfid non risulta essere collegato!";
            this.erroreRfid.Visible = false;
            // 
            // EsciButton
            // 
            this.EsciButton.BackColor = System.Drawing.Color.Yellow;
            this.EsciButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.EsciButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EsciButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.EsciButton.Image = ((System.Drawing.Image)(resources.GetObject("EsciButton.Image")));
            this.EsciButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.EsciButton.Location = new System.Drawing.Point(848, 9);
            this.EsciButton.Name = "EsciButton";
            this.EsciButton.Size = new System.Drawing.Size(180, 88);
            this.EsciButton.TabIndex = 9;
            this.EsciButton.Text = "ESCI DAL PROGRAMMA";
            this.EsciButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.EsciButton.UseVisualStyleBackColor = false;
            this.EsciButton.Click += new System.EventHandler(this.EsciButton_Click);
            // 
            // LoginButton
            // 
            this.LoginButton.BackColor = System.Drawing.Color.Yellow;
            this.LoginButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.LoginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.LoginButton.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.LoginButton.Location = new System.Drawing.Point(628, 166);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(180, 88);
            this.LoginButton.TabIndex = 10;
            this.LoginButton.Text = "ENTRA";
            this.LoginButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // configura
            // 
            this.configura.BackColor = System.Drawing.Color.Yellow;
            this.configura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.configura.Cursor = System.Windows.Forms.Cursors.Hand;
            this.configura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.configura.Location = new System.Drawing.Point(882, 431);
            this.configura.Name = "configura";
            this.configura.Size = new System.Drawing.Size(125, 57);
            this.configura.TabIndex = 41;
            this.configura.Text = "Configura Manualmente";
            this.configura.UseVisualStyleBackColor = false;
            this.configura.Visible = false;
            this.configura.Click += new System.EventHandler(this.configura_Click);
            // 
            // IndexForm
            // 
            this.AcceptButton = this.LoginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(1028, 732);
            this.Controls.Add(this.configura);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.EsciButton);
            this.Controls.Add(this.RegistrazioneButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.erroreRfid);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "IndexForm";
            this.Text = "Index";
            this.Controls.SetChildIndex(this.help, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.textBox2, 0);
            this.Controls.SetChildIndex(this.erroreRfid, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.RegistrazioneButton, 0);
            this.Controls.SetChildIndex(this.EsciButton, 0);
            this.Controls.SetChildIndex(this.LoginButton, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            this.Controls.SetChildIndex(this.configura, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private MainButton RegistrazioneButton;
        private System.Windows.Forms.Label erroreRfid;
        private MainButton EsciButton;
        private MainButton LoginButton;
        private MainButton configura;
    }
}
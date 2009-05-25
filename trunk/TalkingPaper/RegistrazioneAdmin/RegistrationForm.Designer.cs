
namespace RegistrazioneAdmin
{
    partial class RegistrationForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.user = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.verificaPass = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.boxSotto.SuspendLayout();
            this.SuspendLayout();
            // 
            // sottotitolo
            // 
            this.sottotitolo.Size = new System.Drawing.Size(428, 33);
            this.sottotitolo.Text = "Registrazione Amministratore";
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(35, 19);
            this.ok.Text = "Conferma";
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // boxSotto
            // 
            this.boxSotto.Location = new System.Drawing.Point(264, 418);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(33, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(681, 38);
            this.label2.TabIndex = 2;
            this.label2.Text = "Inserisci un nome utente ed una password nelle caselle";
            // 
            // user
            // 
            this.user.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user.Location = new System.Drawing.Point(311, 212);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(296, 26);
            this.user.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(34, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 26);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nome utente";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // password
            // 
            this.password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.Location = new System.Drawing.Point(311, 266);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(296, 26);
            this.password.TabIndex = 8;
            this.password.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(34, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 26);
            this.label4.TabIndex = 7;
            this.label4.Text = "Password";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // verificaPass
            // 
            this.verificaPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verificaPass.Location = new System.Drawing.Point(311, 320);
            this.verificaPass.Name = "verificaPass";
            this.verificaPass.Size = new System.Drawing.Size(296, 26);
            this.verificaPass.TabIndex = 10;
            this.verificaPass.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Location = new System.Drawing.Point(34, 317);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(271, 26);
            this.label5.TabIndex = 9;
            this.label5.Text = "Ripeti la Password";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(748, 592);
            this.ControlBox = true;
            this.Controls.Add(this.user);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.verificaPass);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.MaximumSize = new System.Drawing.Size(764, 628);
            this.MinimumSize = new System.Drawing.Size(764, 628);
            this.Name = "RegistrationForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Registrazione";
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.boxSotto, 0);
            this.Controls.SetChildIndex(this.password, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.verificaPass, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.user, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            this.boxSotto.ResumeLayout(false);
            this.boxSotto.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox user;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox verificaPass;
        private System.Windows.Forms.Label label5;
    }
}
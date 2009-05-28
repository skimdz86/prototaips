using TalkingPaper.Common;
using System.Windows.Forms;
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
            this.RegistrazioneButton = new System.Windows.Forms.Button();
            this.erroreRfid = new System.Windows.Forms.Label();
            this.LoginButton = new System.Windows.Forms.Button();
            this.config = new System.Windows.Forms.Button();
            this.messaggioOK = new System.Windows.Forms.Label();
            this.multiPorta = new System.Windows.Forms.Label();
            this.boxSotto.SuspendLayout();
            this.boxSopra.SuspendLayout();
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
            this.help.Click += new System.EventHandler(this.help_Click);
            // 
            // home
            // 
            this.home.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("home.BackgroundImage")));
            this.home.Text = "Chiudi";
            this.home.Click += new System.EventHandler(this.esci_Click);
            // 
            // annulla
            // 
            this.annulla.Visible = false;
            // 
            // ok
            // 
            this.ok.Visible = false;
            // 
            // boxSotto
            // 
            this.boxSotto.Visible = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(15, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(711, 66);
            this.label2.TabIndex = 1;
            this.label2.Text = "Se sei già registrato inserisci il nome della classe e la parola chiave e premi i" +
                "l bottone \"Entra\"";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(31, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 51);
            this.label3.TabIndex = 2;
            this.label3.Text = "NOME CLASSE";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(31, 271);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(188, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "PAROLA CHIAVE";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(258, 210);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(296, 26);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(258, 271);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(296, 26);
            this.textBox2.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Location = new System.Drawing.Point(21, 395);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(433, 34);
            this.label5.TabIndex = 6;
            this.label5.Text = "Altrimenti effettua la registrazione";
            // 
            // RegistrazioneButton
            // 
            this.RegistrazioneButton.BackColor = System.Drawing.Color.Yellow;
            this.RegistrazioneButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RegistrazioneButton.BackgroundImage")));
            this.RegistrazioneButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RegistrazioneButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RegistrazioneButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegistrazioneButton.Location = new System.Drawing.Point(638, 370);
            this.RegistrazioneButton.Name = "RegistrazioneButton";
            this.RegistrazioneButton.Size = new System.Drawing.Size(180, 88);
            this.RegistrazioneButton.TabIndex = 7;
            this.RegistrazioneButton.Text = "Registrazione";
            this.RegistrazioneButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.RegistrazioneButton.UseVisualStyleBackColor = false;
            this.RegistrazioneButton.Click += new System.EventHandler(this.RegistrazioneButton_Click);
            // 
            // erroreRfid
            // 
            this.erroreRfid.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.erroreRfid.ForeColor = System.Drawing.Color.Red;
            this.erroreRfid.Location = new System.Drawing.Point(20, 542);
            this.erroreRfid.Name = "erroreRfid";
            this.erroreRfid.Size = new System.Drawing.Size(731, 117);
            this.erroreRfid.TabIndex = 8;
            this.erroreRfid.Text = "Attenzione! Il lettore Rfid non risulta essere collegato! Collegarlo e premere il" +
                " bottone \"Cerca lettore RFID\"";
            this.erroreRfid.Visible = false;
            // 
            // LoginButton
            // 
            this.LoginButton.BackColor = System.Drawing.Color.Yellow;
            this.LoginButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LoginButton.BackgroundImage")));
            this.LoginButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.LoginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginButton.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.LoginButton.Location = new System.Drawing.Point(638, 208);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(180, 88);
            this.LoginButton.TabIndex = 6;
            this.LoginButton.Text = "Entra";
            this.LoginButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // config
            // 
            this.config.BackColor = System.Drawing.Color.Yellow;
            this.config.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.config.Cursor = System.Windows.Forms.Cursors.Hand;
            this.config.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.config.Location = new System.Drawing.Point(806, 545);
            this.config.Name = "config";
            this.config.Size = new System.Drawing.Size(180, 88);
            this.config.TabIndex = 43;
            this.config.Text = "Cerca lettore RFID";
            this.config.UseVisualStyleBackColor = false;
            this.config.Visible = false;
            this.config.Click += new System.EventHandler(this.config_Click);
            // 
            // messaggioOK
            // 
            this.messaggioOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messaggioOK.ForeColor = System.Drawing.Color.RoyalBlue;
            this.messaggioOK.Location = new System.Drawing.Point(20, 545);
            this.messaggioOK.Name = "messaggioOK";
            this.messaggioOK.Size = new System.Drawing.Size(731, 41);
            this.messaggioOK.TabIndex = 44;
            this.messaggioOK.Text = "Il lettore è stato configurato correttamente!";
            this.messaggioOK.Visible = false;
            // 
            // multiPorta
            // 
            this.multiPorta.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.multiPorta.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.multiPorta.Location = new System.Drawing.Point(21, 545);
            this.multiPorta.Name = "multiPorta";
            this.multiPorta.Size = new System.Drawing.Size(878, 70);
            this.multiPorta.TabIndex = 45;
            this.multiPorta.Text = "E\' stato rilevato un lettore ma potrebbe essere necessario configurarlo. Per farl" +
                "o bisogna collegarsi come Amministratore.";
            this.multiPorta.Visible = false;
            // 
            // IndexForm
            // 
            this.AcceptButton = this.LoginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(1028, 732);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.RegistrazioneButton);
            this.Controls.Add(this.messaggioOK);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.config);
            this.Controls.Add(this.multiPorta);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.erroreRfid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "IndexForm";
            this.VisibleChanged += new System.EventHandler(this.IndexForm_VisibleChanged);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.boxSotto, 0);
            this.Controls.SetChildIndex(this.boxSopra, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.erroreRfid, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.textBox2, 0);
            this.Controls.SetChildIndex(this.multiPorta, 0);
            this.Controls.SetChildIndex(this.config, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.messaggioOK, 0);
            this.Controls.SetChildIndex(this.RegistrazioneButton, 0);
            this.Controls.SetChildIndex(this.LoginButton, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            this.boxSotto.ResumeLayout(false);
            this.boxSotto.PerformLayout();
            this.boxSopra.ResumeLayout(false);
            this.boxSopra.PerformLayout();
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
        private Button RegistrazioneButton;
        private System.Windows.Forms.Label erroreRfid;
        private Button LoginButton;
        private Button config;
        private Label messaggioOK;
        private Label multiPorta;
    }
}
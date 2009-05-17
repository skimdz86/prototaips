using TalkingPaper.Common;
using System.Windows.Forms;
namespace TalkingPaper.Execution
{
    partial class EsecuzioneCartelloneForm
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
            this.buttonAttiva = new System.Windows.Forms.Button();
            this.buttonDisattiva = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelNomeRisorsa = new System.Windows.Forms.Label();
            this.labelNomeContenuto = new System.Windows.Forms.Label();
            this.labelNomePoster = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelOrario = new System.Windows.Forms.Label();
            this.labelOrario2 = new System.Windows.Forms.Label();
            this.admin2 = new System.Windows.Forms.GroupBox();
            this.boxSotto.SuspendLayout();
            this.boxSopra.SuspendLayout();
            this.admin2.SuspendLayout();
            this.SuspendLayout();
            // 
            // sottotitolo
            // 
            this.sottotitolo.Size = new System.Drawing.Size(375, 33);
            this.sottotitolo.Text = "Esecuzione del tuo poster";
            // 
            // home
            // 
            this.home.Click += new System.EventHandler(this.home_Click);
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
            // buttonAttiva
            // 
            this.buttonAttiva.BackColor = System.Drawing.Color.Yellow;
            this.buttonAttiva.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAttiva.ForeColor = System.Drawing.Color.Black;
            this.buttonAttiva.Location = new System.Drawing.Point(34, 34);
            this.buttonAttiva.Name = "buttonAttiva";
            this.buttonAttiva.Size = new System.Drawing.Size(119, 80);
            this.buttonAttiva.TabIndex = 3;
            this.buttonAttiva.Text = "Attiva";
            this.buttonAttiva.UseVisualStyleBackColor = false;
            this.buttonAttiva.Click += new System.EventHandler(this.buttonAttiva_Click);
            // 
            // buttonDisattiva
            // 
            this.buttonDisattiva.BackColor = System.Drawing.Color.Yellow;
            this.buttonDisattiva.Enabled = false;
            this.buttonDisattiva.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDisattiva.ForeColor = System.Drawing.Color.Black;
            this.buttonDisattiva.Location = new System.Drawing.Point(196, 34);
            this.buttonDisattiva.Name = "buttonDisattiva";
            this.buttonDisattiva.Size = new System.Drawing.Size(119, 80);
            this.buttonDisattiva.TabIndex = 4;
            this.buttonDisattiva.Text = "Disattiva";
            this.buttonDisattiva.UseVisualStyleBackColor = false;
            this.buttonDisattiva.Click += new System.EventHandler(this.buttonDisattiva_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(21, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Esecuzione di: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(20, 234);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "File: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(21, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Cartellone: ";
            // 
            // labelNomeRisorsa
            // 
            this.labelNomeRisorsa.AutoSize = true;
            this.labelNomeRisorsa.ForeColor = System.Drawing.Color.White;
            this.labelNomeRisorsa.Location = new System.Drawing.Point(150, 234);
            this.labelNomeRisorsa.Name = "labelNomeRisorsa";
            this.labelNomeRisorsa.Size = new System.Drawing.Size(154, 20);
            this.labelNomeRisorsa.TabIndex = 9;
            this.labelNomeRisorsa.Text = "labelNomeRisorsa";
            this.labelNomeRisorsa.Visible = false;
            // 
            // labelNomeContenuto
            // 
            this.labelNomeContenuto.AutoSize = true;
            this.labelNomeContenuto.ForeColor = System.Drawing.Color.White;
            this.labelNomeContenuto.Location = new System.Drawing.Point(150, 189);
            this.labelNomeContenuto.Name = "labelNomeContenuto";
            this.labelNomeContenuto.Size = new System.Drawing.Size(177, 20);
            this.labelNomeContenuto.TabIndex = 10;
            this.labelNomeContenuto.Text = "labelNomeContenuto";
            this.labelNomeContenuto.Visible = false;
            // 
            // labelNomePoster
            // 
            this.labelNomePoster.AutoSize = true;
            this.labelNomePoster.ForeColor = System.Drawing.Color.White;
            this.labelNomePoster.Location = new System.Drawing.Point(150, 143);
            this.labelNomePoster.Name = "labelNomePoster";
            this.labelNomePoster.Size = new System.Drawing.Size(145, 20);
            this.labelNomePoster.TabIndex = 11;
            this.labelNomePoster.Text = "labelNomePoster";
            this.labelNomePoster.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(21, 285);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 20);
            this.label7.TabIndex = 21;
            this.label7.Text = "Stato :";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.ForeColor = System.Drawing.Color.White;
            this.labelStatus.Location = new System.Drawing.Point(117, 285);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(100, 20);
            this.labelStatus.TabIndex = 22;
            this.labelStatus.Text = "labelStatus";
            this.labelStatus.Visible = false;
            // 
            // labelOrario
            // 
            this.labelOrario.AutoSize = true;
            this.labelOrario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOrario.ForeColor = System.Drawing.Color.White;
            this.labelOrario.Location = new System.Drawing.Point(375, 288);
            this.labelOrario.Name = "labelOrario";
            this.labelOrario.Size = new System.Drawing.Size(39, 15);
            this.labelOrario.TabIndex = 25;
            this.labelOrario.Text = "orario";
            this.labelOrario.Visible = false;
            // 
            // labelOrario2
            // 
            this.labelOrario2.AutoSize = true;
            this.labelOrario2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOrario2.ForeColor = System.Drawing.Color.White;
            this.labelOrario2.Location = new System.Drawing.Point(323, 288);
            this.labelOrario2.Name = "labelOrario2";
            this.labelOrario2.Size = new System.Drawing.Size(46, 15);
            this.labelOrario2.TabIndex = 26;
            this.labelOrario2.Text = "orario2";
            this.labelOrario2.Visible = false;
            // 
            // admin2
            // 
            this.admin2.BackColor = System.Drawing.Color.Orange;
            this.admin2.Controls.Add(this.buttonAttiva);
            this.admin2.Controls.Add(this.buttonDisattiva);
            this.admin2.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.admin2.Location = new System.Drawing.Point(666, 568);
            this.admin2.Name = "admin2";
            this.admin2.Size = new System.Drawing.Size(350, 142);
            this.admin2.TabIndex = 56;
            this.admin2.TabStop = false;
            this.admin2.Visible = false;
            // 
            // EsecuzioneCartelloneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(1028, 739);
            this.Controls.Add(this.labelOrario2);
            this.Controls.Add(this.labelOrario);
            this.Controls.Add(this.admin2);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labelNomePoster);
            this.Controls.Add(this.labelNomeContenuto);
            this.Controls.Add(this.labelNomeRisorsa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "EsecuzioneCartelloneForm";
            this.Text = "Esecuzione";
            this.Load += new System.EventHandler(this.FormEsecuzioneRfidPoster_Load);
            this.Controls.SetChildIndex(this.boxSotto, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.labelNomeRisorsa, 0);
            this.Controls.SetChildIndex(this.labelNomeContenuto, 0);
            this.Controls.SetChildIndex(this.labelNomePoster, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            this.Controls.SetChildIndex(this.labelStatus, 0);
            this.Controls.SetChildIndex(this.admin2, 0);
            this.Controls.SetChildIndex(this.labelOrario, 0);
            this.Controls.SetChildIndex(this.labelOrario2, 0);
            this.Controls.SetChildIndex(this.boxSopra, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.boxSotto.ResumeLayout(false);
            this.boxSotto.PerformLayout();
            this.boxSopra.ResumeLayout(false);
            this.boxSopra.PerformLayout();
            this.admin2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAttiva;
        private System.Windows.Forms.Button buttonDisattiva;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelNomeRisorsa;
        private System.Windows.Forms.Label labelNomeContenuto;
        private System.Windows.Forms.Label labelNomePoster;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelOrario;
        private System.Windows.Forms.Label labelOrario2;
        private System.Windows.Forms.GroupBox admin2;
    }
}
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
            this.labelEsecuzioneDi = new System.Windows.Forms.Label();
            this.nomeContenuto = new System.Windows.Forms.Label();
            this.labelStato = new System.Windows.Forms.Label();
            this.stato = new System.Windows.Forms.Label();
            this.tempoTotale = new System.Windows.Forms.Label();
            this.tempoTrascorso = new System.Windows.Forms.Label();
            this.attivaBox = new System.Windows.Forms.GroupBox();
            this.messaggioStart = new System.Windows.Forms.Label();
            this.esecuzioneDisattivata = new System.Windows.Forms.Label();
            this.labelSu = new System.Windows.Forms.Label();
            this.boxSotto.SuspendLayout();
            this.boxSopra.SuspendLayout();
            this.attivaBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // sottotitolo
            // 
            this.sottotitolo.Size = new System.Drawing.Size(373, 33);
            this.sottotitolo.Text = "Esecuzione del cartellone";
            // 
            // home
            // 
            this.home.Text = "Esci";
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
            this.buttonAttiva.Enabled = false;
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
            // labelEsecuzioneDi
            // 
            this.labelEsecuzioneDi.AutoSize = true;
            this.labelEsecuzioneDi.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEsecuzioneDi.ForeColor = System.Drawing.Color.Black;
            this.labelEsecuzioneDi.Location = new System.Drawing.Point(55, 356);
            this.labelEsecuzioneDi.Name = "labelEsecuzioneDi";
            this.labelEsecuzioneDi.Size = new System.Drawing.Size(198, 31);
            this.labelEsecuzioneDi.TabIndex = 6;
            this.labelEsecuzioneDi.Text = "Esecuzione di :";
            this.labelEsecuzioneDi.Visible = false;
            // 
            // nomeContenuto
            // 
            this.nomeContenuto.AutoSize = true;
            this.nomeContenuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomeContenuto.ForeColor = System.Drawing.Color.White;
            this.nomeContenuto.Location = new System.Drawing.Point(288, 356);
            this.nomeContenuto.Name = "nomeContenuto";
            this.nomeContenuto.Size = new System.Drawing.Size(208, 31);
            this.nomeContenuto.TabIndex = 10;
            this.nomeContenuto.Text = "nome contenuto";
            this.nomeContenuto.Visible = false;
            // 
            // labelStato
            // 
            this.labelStato.AutoSize = true;
            this.labelStato.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStato.ForeColor = System.Drawing.Color.Black;
            this.labelStato.Location = new System.Drawing.Point(55, 427);
            this.labelStato.Name = "labelStato";
            this.labelStato.Size = new System.Drawing.Size(93, 31);
            this.labelStato.TabIndex = 21;
            this.labelStato.Text = "Stato :";
            this.labelStato.Visible = false;
            // 
            // stato
            // 
            this.stato.AutoSize = true;
            this.stato.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stato.ForeColor = System.Drawing.Color.White;
            this.stato.Location = new System.Drawing.Point(288, 427);
            this.stato.Name = "stato";
            this.stato.Size = new System.Drawing.Size(74, 31);
            this.stato.TabIndex = 22;
            this.stato.Text = "stato";
            this.stato.Visible = false;
            // 
            // tempoTotale
            // 
            this.tempoTotale.AutoSize = true;
            this.tempoTotale.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tempoTotale.ForeColor = System.Drawing.Color.White;
            this.tempoTotale.Location = new System.Drawing.Point(774, 427);
            this.tempoTotale.Name = "tempoTotale";
            this.tempoTotale.Size = new System.Drawing.Size(132, 31);
            this.tempoTotale.TabIndex = 25;
            this.tempoTotale.Text = "hh:mm:ss";
            this.tempoTotale.Visible = false;
            // 
            // tempoTrascorso
            // 
            this.tempoTrascorso.AutoSize = true;
            this.tempoTrascorso.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tempoTrascorso.ForeColor = System.Drawing.Color.White;
            this.tempoTrascorso.Location = new System.Drawing.Point(584, 427);
            this.tempoTrascorso.Name = "tempoTrascorso";
            this.tempoTrascorso.Size = new System.Drawing.Size(132, 31);
            this.tempoTrascorso.TabIndex = 26;
            this.tempoTrascorso.Text = "hh:mm:ss";
            this.tempoTrascorso.Visible = false;
            // 
            // attivaBox
            // 
            this.attivaBox.BackColor = System.Drawing.Color.Orange;
            this.attivaBox.Controls.Add(this.buttonAttiva);
            this.attivaBox.Controls.Add(this.buttonDisattiva);
            this.attivaBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attivaBox.Location = new System.Drawing.Point(666, 568);
            this.attivaBox.Name = "attivaBox";
            this.attivaBox.Size = new System.Drawing.Size(350, 142);
            this.attivaBox.TabIndex = 56;
            this.attivaBox.TabStop = false;
            // 
            // messaggioStart
            // 
            this.messaggioStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messaggioStart.ForeColor = System.Drawing.Color.White;
            this.messaggioStart.Location = new System.Drawing.Point(53, 211);
            this.messaggioStart.Name = "messaggioStart";
            this.messaggioStart.Size = new System.Drawing.Size(928, 55);
            this.messaggioStart.TabIndex = 57;
            this.messaggioStart.Text = "Avvicina il lettore al cartellone per farlo parlare!";
            // 
            // esecuzioneDisattivata
            // 
            this.esecuzioneDisattivata.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.esecuzioneDisattivata.ForeColor = System.Drawing.Color.RoyalBlue;
            this.esecuzioneDisattivata.Location = new System.Drawing.Point(286, 332);
            this.esecuzioneDisattivata.Name = "esecuzioneDisattivata";
            this.esecuzioneDisattivata.Size = new System.Drawing.Size(457, 55);
            this.esecuzioneDisattivata.TabIndex = 58;
            this.esecuzioneDisattivata.Text = "Esecuzione disattivata!";
            this.esecuzioneDisattivata.Visible = false;
            // 
            // labelSu
            // 
            this.labelSu.AutoSize = true;
            this.labelSu.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSu.ForeColor = System.Drawing.Color.White;
            this.labelSu.Location = new System.Drawing.Point(722, 427);
            this.labelSu.Name = "labelSu";
            this.labelSu.Size = new System.Drawing.Size(43, 31);
            this.labelSu.TabIndex = 59;
            this.labelSu.Text = "su";
            this.labelSu.Visible = false;
            // 
            // EsecuzioneCartelloneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(1028, 739);
            this.Controls.Add(this.labelSu);
            this.Controls.Add(this.esecuzioneDisattivata);
            this.Controls.Add(this.messaggioStart);
            this.Controls.Add(this.tempoTrascorso);
            this.Controls.Add(this.tempoTotale);
            this.Controls.Add(this.attivaBox);
            this.Controls.Add(this.stato);
            this.Controls.Add(this.labelStato);
            this.Controls.Add(this.nomeContenuto);
            this.Controls.Add(this.labelEsecuzioneDi);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "EsecuzioneCartelloneForm";
            this.Text = "Esecuzione";
            this.Controls.SetChildIndex(this.boxSotto, 0);
            this.Controls.SetChildIndex(this.labelEsecuzioneDi, 0);
            this.Controls.SetChildIndex(this.nomeContenuto, 0);
            this.Controls.SetChildIndex(this.labelStato, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            this.Controls.SetChildIndex(this.stato, 0);
            this.Controls.SetChildIndex(this.attivaBox, 0);
            this.Controls.SetChildIndex(this.tempoTotale, 0);
            this.Controls.SetChildIndex(this.tempoTrascorso, 0);
            this.Controls.SetChildIndex(this.boxSopra, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.Controls.SetChildIndex(this.messaggioStart, 0);
            this.Controls.SetChildIndex(this.esecuzioneDisattivata, 0);
            this.Controls.SetChildIndex(this.labelSu, 0);
            this.boxSotto.ResumeLayout(false);
            this.boxSotto.PerformLayout();
            this.boxSopra.ResumeLayout(false);
            this.boxSopra.PerformLayout();
            this.attivaBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAttiva;
        private System.Windows.Forms.Button buttonDisattiva;
        private System.Windows.Forms.Label labelEsecuzioneDi;
        private System.Windows.Forms.Label nomeContenuto;
        private System.Windows.Forms.Label labelStato;
        private System.Windows.Forms.Label stato;
        private System.Windows.Forms.Label tempoTotale;
        private System.Windows.Forms.Label tempoTrascorso;
        private System.Windows.Forms.GroupBox attivaBox;
        private Label messaggioStart;
        private Label esecuzioneDisattivata;
        private Label labelSu;
    }
}
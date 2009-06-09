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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EsecuzioneCartelloneForm));
            this.labelEsecuzioneDi = new System.Windows.Forms.Label();
            this.nomeContenuto = new System.Windows.Forms.Label();
            this.labelStato = new System.Windows.Forms.Label();
            this.stato = new System.Windows.Forms.Label();
            this.tempoTotale = new System.Windows.Forms.Label();
            this.tempoTrascorso = new System.Windows.Forms.Label();
            this.messaggioStart = new System.Windows.Forms.Label();
            this.labelSu = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.annulla1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.boxSotto.SuspendLayout();
            this.boxSopra.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sottotitolo
            // 
            this.sottotitolo.Size = new System.Drawing.Size(373, 33);
            this.sottotitolo.Text = "Esecuzione del cartellone";
            // 
            // help
            // 
            this.help.Click += new System.EventHandler(this.help_Click);
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
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(55, 266);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(928, 70);
            this.label1.TabIndex = 60;
            this.label1.Text = "Attenzione: verificare che il lettore sia collegato e lampeggi la luce rossa!";
            // 
            // annulla1
            // 
            this.annulla1.AutoSize = true;
            this.annulla1.BackColor = System.Drawing.Color.Yellow;
            this.annulla1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("annulla1.BackgroundImage")));
            this.annulla1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.annulla1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.annulla1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.annulla1.Location = new System.Drawing.Point(29, 18);
            this.annulla1.Name = "annulla1";
            this.annulla1.Size = new System.Drawing.Size(148, 105);
            this.annulla1.TabIndex = 61;
            this.annulla1.Text = "Annulla";
            this.annulla1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.annulla1.UseVisualStyleBackColor = false;
            this.annulla1.Click += new System.EventHandler(this.annulla1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Orange;
            this.groupBox1.Controls.Add(this.annulla1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(799, 568);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(205, 142);
            this.groupBox1.TabIndex = 62;
            this.groupBox1.TabStop = false;
            // 
            // EsecuzioneCartelloneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(1028, 732);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelSu);
            this.Controls.Add(this.messaggioStart);
            this.Controls.Add(this.tempoTrascorso);
            this.Controls.Add(this.tempoTotale);
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
            this.Controls.SetChildIndex(this.tempoTotale, 0);
            this.Controls.SetChildIndex(this.tempoTrascorso, 0);
            this.Controls.SetChildIndex(this.boxSopra, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.Controls.SetChildIndex(this.messaggioStart, 0);
            this.Controls.SetChildIndex(this.labelSu, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.boxSotto.ResumeLayout(false);
            this.boxSotto.PerformLayout();
            this.boxSopra.ResumeLayout(false);
            this.boxSopra.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelEsecuzioneDi;
        private System.Windows.Forms.Label nomeContenuto;
        private System.Windows.Forms.Label labelStato;
        private System.Windows.Forms.Label stato;
        private System.Windows.Forms.Label tempoTotale;
        private System.Windows.Forms.Label tempoTrascorso;
        private Label messaggioStart;
        private Label labelSu;
        private Label label1;
        protected Button annulla1;
        protected GroupBox groupBox1;
    }
}
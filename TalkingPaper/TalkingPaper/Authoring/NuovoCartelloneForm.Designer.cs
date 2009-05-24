using TalkingPaper.Common;
using System.Windows.Forms;
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
            this.Classe = new System.Windows.Forms.TextBox();
            this.Descrizione = new System.Windows.Forms.TextBox();
            this.Nome = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.boxSotto.SuspendLayout();
            this.boxSopra.SuspendLayout();
            this.SuspendLayout();
            // 
            // sottotitolo
            // 
            this.sottotitolo.Size = new System.Drawing.Size(256, 33);
            this.sottotitolo.Text = "Nuovo Cartellone";
            // 
            // home
            // 
            this.home.Click += new System.EventHandler(this.home_Click);
            // 
            // annulla
            // 
            this.annulla.Click += new System.EventHandler(this.annulla_Click);
            // 
            // ok
            // 
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // Classe
            // 
            this.Classe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Classe.Location = new System.Drawing.Point(432, 389);
            this.Classe.Name = "Classe";
            this.Classe.Size = new System.Drawing.Size(269, 26);
            this.Classe.TabIndex = 28;
            // 
            // Descrizione
            // 
            this.Descrizione.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Descrizione.Location = new System.Drawing.Point(432, 328);
            this.Descrizione.Multiline = true;
            this.Descrizione.Name = "Descrizione";
            this.Descrizione.Size = new System.Drawing.Size(269, 26);
            this.Descrizione.TabIndex = 27;
            // 
            // Nome
            // 
            this.Nome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nome.Location = new System.Drawing.Point(432, 272);
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
            this.label4.Location = new System.Drawing.Point(262, 391);
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
            this.label3.Location = new System.Drawing.Point(262, 330);
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
            this.label2.Location = new System.Drawing.Point(262, 274);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 24);
            this.label2.TabIndex = 23;
            this.label2.Text = "Nome";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkOrange;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(200, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(620, 67);
            this.label1.TabIndex = 22;
            this.label1.Text = "Inserisci il nome e la descrizione del cartellone e la classe alla quale appartie" +
                "ni";
            // 
            // NuovoCartelloneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(1028, 732);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Nome);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Classe);
            this.Controls.Add(this.Descrizione);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Name = "NuovoCartelloneForm";
            this.Text = "NuovoPoster";
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.Descrizione, 0);
            this.Controls.SetChildIndex(this.Classe, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.Nome, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.boxSopra, 0);
            this.Controls.SetChildIndex(this.boxSotto, 0);
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

        private System.Windows.Forms.TextBox Classe;
        private System.Windows.Forms.TextBox Descrizione;
        private System.Windows.Forms.TextBox Nome;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
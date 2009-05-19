using TalkingPaper.Common;
using System.Windows.Forms;
namespace TalkingPaper.Welcome
{
    partial class ChildHomeForm
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
            this.nuovoCartellone = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.modificaCartellone = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.parla = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.boxSotto.SuspendLayout();
            this.boxSopra.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // sottotitolo
            // 
            this.sottotitolo.Size = new System.Drawing.Size(322, 33);
            this.sottotitolo.Text = "Menu: cosa vuoi fare?";
            // 
            // home
            // 
            this.home.Text = "Logout";
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
            // nuovoCartellone
            // 
            this.nuovoCartellone.BackColor = System.Drawing.Color.Yellow;
            this.nuovoCartellone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.nuovoCartellone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nuovoCartellone.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nuovoCartellone.Location = new System.Drawing.Point(74, 41);
            this.nuovoCartellone.Name = "nuovoCartellone";
            this.nuovoCartellone.Size = new System.Drawing.Size(193, 95);
            this.nuovoCartellone.TabIndex = 2;
            this.nuovoCartellone.Text = "Nuovo Cartellone";
            this.nuovoCartellone.UseVisualStyleBackColor = false;
            this.nuovoCartellone.Click += new System.EventHandler(this.nuovoCartellone_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Orange;
            this.groupBox1.Controls.Add(this.nuovoCartellone);
            this.groupBox1.Controls.Add(this.modificaCartellone);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(200, 215);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(621, 178);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // modificaCartellone
            // 
            this.modificaCartellone.BackColor = System.Drawing.Color.Yellow;
            this.modificaCartellone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.modificaCartellone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.modificaCartellone.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modificaCartellone.Location = new System.Drawing.Point(356, 41);
            this.modificaCartellone.Name = "modificaCartellone";
            this.modificaCartellone.Size = new System.Drawing.Size(193, 95);
            this.modificaCartellone.TabIndex = 14;
            this.modificaCartellone.Text = "Modifica Cartellone";
            this.modificaCartellone.UseVisualStyleBackColor = false;
            this.modificaCartellone.Click += new System.EventHandler(this.modificaCartellone_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Orange;
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.parla);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(200, 425);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(621, 178);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            // 
            // parla
            // 
            this.parla.BackColor = System.Drawing.Color.Yellow;
            this.parla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.parla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.parla.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.parla.Location = new System.Drawing.Point(66, 46);
            this.parla.Name = "parla";
            this.parla.Size = new System.Drawing.Size(193, 95);
            this.parla.TabIndex = 15;
            this.parla.Text = "Fai parlare un cartellone";
            this.parla.UseVisualStyleBackColor = false;
            this.parla.Click += new System.EventHandler(this.parlaSchema_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Yellow;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(356, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(193, 95);
            this.button1.TabIndex = 16;
            this.button1.Text = "Stampa un cartellone";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // ChildHomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(1028, 739);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "ChildHomeForm";
            this.Text = "Menu";
            this.Controls.SetChildIndex(this.boxSotto, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.boxSopra, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            this.boxSotto.ResumeLayout(false);
            this.boxSotto.PerformLayout();
            this.boxSopra.ResumeLayout(false);
            this.boxSopra.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button nuovoCartellone;
        private System.Windows.Forms.GroupBox groupBox1;
        private Button modificaCartellone;
        private GroupBox groupBox2;
        private Button parla;
        private Button button1;
    }
}
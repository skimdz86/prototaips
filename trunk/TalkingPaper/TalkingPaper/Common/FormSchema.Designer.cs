using System.Windows.Forms;
namespace TalkingPaper.Common
{
    partial class FormSchema
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSchema));
            this.titolo = new System.Windows.Forms.Label();
            this.sottotitolo = new System.Windows.Forms.Label();
            this.boxSopra = new System.Windows.Forms.GroupBox();
            this.home = new System.Windows.Forms.Button();
            this.help = new System.Windows.Forms.Button();
            this.boxSotto = new System.Windows.Forms.GroupBox();
            this.annulla = new System.Windows.Forms.Button();
            this.ok = new System.Windows.Forms.Button();
            this.boxSopra.SuspendLayout();
            this.boxSotto.SuspendLayout();
            this.SuspendLayout();
            // 
            // titolo
            // 
            this.titolo.AutoSize = true;
            this.titolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titolo.ForeColor = System.Drawing.Color.White;
            this.titolo.Location = new System.Drawing.Point(8, 6);
            this.titolo.Name = "titolo";
            this.titolo.Size = new System.Drawing.Size(454, 55);
            this.titolo.TabIndex = 38;
            this.titolo.Text = "Cartellone Parlante";
            // 
            // sottotitolo
            // 
            this.sottotitolo.AutoSize = true;
            this.sottotitolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sottotitolo.ForeColor = System.Drawing.Color.White;
            this.sottotitolo.Location = new System.Drawing.Point(12, 67);
            this.sottotitolo.Name = "sottotitolo";
            this.sottotitolo.Size = new System.Drawing.Size(165, 33);
            this.sottotitolo.TabIndex = 39;
            this.sottotitolo.Text = "SottoTitolo";
            // 
            // boxSopra
            // 
            this.boxSopra.BackColor = System.Drawing.Color.Orange;
            this.boxSopra.Controls.Add(this.home);
            this.boxSopra.Controls.Add(this.help);
            this.boxSopra.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxSopra.ForeColor = System.Drawing.Color.Black;
            this.boxSopra.Location = new System.Drawing.Point(764, 21);
            this.boxSopra.Name = "boxSopra";
            this.boxSopra.Size = new System.Drawing.Size(240, 111);
            this.boxSopra.TabIndex = 41;
            this.boxSopra.TabStop = false;
            // 
            // home
            // 
            this.home.AutoSize = true;
            this.home.BackColor = System.Drawing.Color.Yellow;
            this.home.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("home.BackgroundImage")));
            this.home.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.home.Cursor = System.Windows.Forms.Cursors.Hand;
            this.home.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.home.Location = new System.Drawing.Point(127, 14);
            this.home.Name = "home";
            this.home.Size = new System.Drawing.Size(95, 83);
            this.home.TabIndex = 40;
            this.home.Text = "Home";
            this.home.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.home.UseVisualStyleBackColor = false;
            // 
            // help
            // 
            this.help.AutoSize = true;
            this.help.BackColor = System.Drawing.Color.Yellow;
            this.help.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("help.BackgroundImage")));
            this.help.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.help.Cursor = System.Windows.Forms.Cursors.Hand;
            this.help.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.help.Location = new System.Drawing.Point(16, 14);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(95, 83);
            this.help.TabIndex = 40;
            this.help.Text = "Aiuto";
            this.help.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.help.UseVisualStyleBackColor = false;
            this.help.Click += new System.EventHandler(this.help_Click);
            // 
            // boxSotto
            // 
            this.boxSotto.BackColor = System.Drawing.Color.Orange;
            this.boxSotto.Controls.Add(this.annulla);
            this.boxSotto.Controls.Add(this.ok);
            this.boxSotto.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxSotto.ForeColor = System.Drawing.Color.Black;
            this.boxSotto.Location = new System.Drawing.Point(310, 568);
            this.boxSotto.Name = "boxSotto";
            this.boxSotto.Size = new System.Drawing.Size(406, 142);
            this.boxSotto.TabIndex = 42;
            this.boxSotto.TabStop = false;
            // 
            // annulla
            // 
            this.annulla.AutoSize = true;
            this.annulla.BackColor = System.Drawing.Color.Yellow;
            this.annulla.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("annulla.BackgroundImage")));
            this.annulla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.annulla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.annulla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.annulla.Location = new System.Drawing.Point(227, 18);
            this.annulla.Name = "annulla";
            this.annulla.Size = new System.Drawing.Size(148, 105);
            this.annulla.TabIndex = 42;
            this.annulla.Text = "Annulla";
            this.annulla.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.annulla.UseVisualStyleBackColor = false;
            // 
            // ok
            // 
            this.ok.AutoSize = true;
            this.ok.BackColor = System.Drawing.Color.Yellow;
            this.ok.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ok.BackgroundImage")));
            this.ok.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ok.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.ok.Location = new System.Drawing.Point(37, 18);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(148, 105);
            this.ok.TabIndex = 41;
            this.ok.Text = "OK";
            this.ok.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ok.UseVisualStyleBackColor = false;
            // 
            // FormSchema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(1028, 739);
            this.ControlBox = false;
            this.Controls.Add(this.boxSotto);
            this.Controls.Add(this.titolo);
            this.Controls.Add(this.sottotitolo);
            this.Controls.Add(this.boxSopra);
            this.Name = "FormSchema";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cartellone Parlante";
            this.boxSopra.ResumeLayout(false);
            this.boxSopra.PerformLayout();
            this.boxSotto.ResumeLayout(false);
            this.boxSotto.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label titolo;
        protected System.Windows.Forms.Label sottotitolo;
        protected Button help;
        protected Button home;
        protected Button annulla;
        protected Button ok;
        protected System.Windows.Forms.GroupBox boxSotto;
        protected System.Windows.Forms.GroupBox boxSopra;
    }
}


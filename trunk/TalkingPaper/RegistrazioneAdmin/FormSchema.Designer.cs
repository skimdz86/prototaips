
using System.Windows.Forms;
namespace RegistrazioneAdmin
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
            this.boxSotto = new System.Windows.Forms.GroupBox();
            this.ok = new System.Windows.Forms.Button();
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
            // boxSotto
            // 
            this.boxSotto.BackColor = System.Drawing.Color.Orange;
            this.boxSotto.Controls.Add(this.ok);
            this.boxSotto.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxSotto.ForeColor = System.Drawing.Color.Black;
            this.boxSotto.Location = new System.Drawing.Point(406, 565);
            this.boxSotto.Name = "boxSotto";
            this.boxSotto.Size = new System.Drawing.Size(219, 143);
            this.boxSotto.TabIndex = 42;
            this.boxSotto.TabStop = false;
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
            this.Name = "FormSchema";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cartellone Parlante";
            this.boxSotto.ResumeLayout(false);
            this.boxSotto.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label titolo;
        protected System.Windows.Forms.Label sottotitolo;
        protected Button ok;
        protected System.Windows.Forms.GroupBox boxSotto;
    }
}


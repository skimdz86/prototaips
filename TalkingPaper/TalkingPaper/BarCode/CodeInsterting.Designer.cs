namespace TalkingPaper.BarCode
{
    partial class CodeInsterting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodeInsterting));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Salva = new TalkingPaper.MainButton();
            this.Annulla = new TalkingPaper.MainButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.indietro = new TalkingPaper.ControlButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).BeginInit();
            this.grouppoControl.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grouppoControl
            // 
            this.grouppoControl.Controls.Add(this.indietro);
            // 
            // sottotitolo
            // 
            this.sottotitolo.Size = new System.Drawing.Size(366, 33);
            this.sottotitolo.Text = "Inserisci il codice a barre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 37);
            this.label1.TabIndex = 16;
            this.label1.Text = "Inserimento Codice";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(335, 247);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(379, 31);
            this.textBox1.TabIndex = 17;
            // 
            // Salva
            // 
            this.Salva.BackColor = System.Drawing.Color.Yellow;
            this.Salva.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Salva.BackgroundImage")));
            this.Salva.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Salva.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Salva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Salva.Location = new System.Drawing.Point(10, 14);
            this.Salva.Name = "Salva";
            this.Salva.Size = new System.Drawing.Size(226, 111);
            this.Salva.TabIndex = 20;
            this.Salva.Text = "Salva";
            this.Salva.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Salva.UseVisualStyleBackColor = false;
            this.Salva.Click += new System.EventHandler(this.Salva_Click);
            // 
            // Annulla
            // 
            this.Annulla.BackColor = System.Drawing.Color.Yellow;
            this.Annulla.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Annulla.BackgroundImage")));
            this.Annulla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Annulla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Annulla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Annulla.Location = new System.Drawing.Point(242, 14);
            this.Annulla.Name = "Annulla";
            this.Annulla.Size = new System.Drawing.Size(226, 111);
            this.Annulla.TabIndex = 21;
            this.Annulla.Text = "Annulla";
            this.Annulla.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Annulla.UseVisualStyleBackColor = false;
            this.Annulla.Click += new System.EventHandler(this.Annulla_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Orange;
            this.groupBox1.Controls.Add(this.Annulla);
            this.groupBox1.Controls.Add(this.Salva);
            this.groupBox1.Location = new System.Drawing.Point(293, 351);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(474, 131);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            // 
            // indietro
            // 
            this.indietro.BackColor = System.Drawing.Color.Yellow;
            this.indietro.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("indietro.BackgroundImage")));
            this.indietro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.indietro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.indietro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.indietro.Location = new System.Drawing.Point(225, 19);
            this.indietro.Name = "indietro";
            this.indietro.Size = new System.Drawing.Size(120, 62);
            this.indietro.TabIndex = 45;
            this.indietro.Text = "Indietro";
            this.indietro.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.indietro.UseVisualStyleBackColor = false;
            this.indietro.Click += new System.EventHandler(this.indietro_Click);
            // 
            // CodeInsterting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 739);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "CodeInsterting";
            this.Text = "Inserimento del codice - Fase di Coding";
            this.Load += new System.EventHandler(this.CodeInsterting_Load);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.Controls.SetChildIndex(this.grouppoControl, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            this.Controls.SetChildIndex(this.pictureBoxPost1, 0);
            this.Controls.SetChildIndex(this.pictureBoxPost2, 0);
            this.Controls.SetChildIndex(this.textBoxPost, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).EndInit();
            this.grouppoControl.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private MainButton Salva;
        private MainButton Annulla;
        private System.Windows.Forms.GroupBox groupBox1;
        private ControlButton indietro;
    }
}
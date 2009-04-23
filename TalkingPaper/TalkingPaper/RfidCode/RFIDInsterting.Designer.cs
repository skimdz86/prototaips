namespace TalkingPaper.RfidCode
{
    partial class RFIDInsterting
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RFIDInsterting));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Salva = new TalkingPaper.ControlButton();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Esci = new TalkingPaper.ControlButton();
            this.Annulla = new TalkingPaper.ControlButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).BeginInit();
            this.grouppoControl.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // grouppoControl
            // 
            this.grouppoControl.Controls.Add(this.Annulla);
            this.grouppoControl.Controls.Add(this.Salva);
            this.grouppoControl.Location = new System.Drawing.Point(875, 9);
            this.grouppoControl.Size = new System.Drawing.Size(284, 91);
            // 
            // sottotitolo
            // 
            this.sottotitolo.Size = new System.Drawing.Size(210, 33);
            this.sottotitolo.Text = "Inserisci onda";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(395, 240);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
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
            this.Salva.Location = new System.Drawing.Point(16, 19);
            this.Salva.Name = "Salva";
            this.Salva.Size = new System.Drawing.Size(120, 62);
            this.Salva.TabIndex = 20;
            this.Salva.Text = "Salva";
            this.Salva.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Salva.UseVisualStyleBackColor = false;
            this.Salva.Click += new System.EventHandler(this.Salva_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Orange;
            this.groupBox4.Controls.Add(this.Esci);
            this.groupBox4.Location = new System.Drawing.Point(905, -169);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(137, 91);
            this.groupBox4.TabIndex = 30;
            this.groupBox4.TabStop = false;
            // 
            // Esci
            // 
            this.Esci.BackColor = System.Drawing.Color.Yellow;
            this.Esci.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Esci.BackgroundImage")));
            this.Esci.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Esci.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Esci.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Esci.Location = new System.Drawing.Point(6, 19);
            this.Esci.Name = "Esci";
            this.Esci.Size = new System.Drawing.Size(120, 62);
            this.Esci.TabIndex = 9;
            this.Esci.Text = "Esci";
            this.Esci.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Esci.UseVisualStyleBackColor = false;
            // 
            // Annulla
            // 
            this.Annulla.BackColor = System.Drawing.Color.Yellow;
            this.Annulla.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Annulla.BackgroundImage")));
            this.Annulla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Annulla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Annulla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Annulla.Location = new System.Drawing.Point(157, 19);
            this.Annulla.Name = "Annulla";
            this.Annulla.Size = new System.Drawing.Size(120, 62);
            this.Annulla.TabIndex = 21;
            this.Annulla.Text = "Annulla";
            this.Annulla.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Annulla.UseVisualStyleBackColor = false;
            this.Annulla.Click += new System.EventHandler(this.Annulla_Click_1);
            // 
            // RFIDInsterting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 739);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.textBox1);
            this.Name = "RFIDInsterting";
            this.Text = "CodeInsterting - Fase di Coding";
            this.Load += new System.EventHandler(this.CodeInsterting_Load);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.grouppoControl, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            this.Controls.SetChildIndex(this.pictureBoxPost1, 0);
            this.Controls.SetChildIndex(this.pictureBoxPost2, 0);
            this.Controls.SetChildIndex(this.textBoxPost, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).EndInit();
            this.grouppoControl.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private ControlButton Salva;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.GroupBox groupBox4;
        private ControlButton Esci;
        private ControlButton Annulla;
    }
}
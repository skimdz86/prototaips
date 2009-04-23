namespace TalkingPaper.BarCode
{
    partial class BenvenutoBarCode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BenvenutoBarCode));
            this.Entra = new TalkingPaper.MainButton();
            this.Esci = new TalkingPaper.ControlButton();
            this.Fase = new System.Windows.Forms.Label();
            this.button1 = new TalkingPaper.MainButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).BeginInit();
            this.grouppoControl.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grouppoControl
            // 
            this.grouppoControl.Controls.Add(this.Esci);
            this.grouppoControl.Location = new System.Drawing.Point(1028, 9);
            this.grouppoControl.Size = new System.Drawing.Size(146, 91);
            // 
            // sottotitolo
            // 
            this.sottotitolo.Size = new System.Drawing.Size(314, 33);
            this.sottotitolo.Text = "Mostra o Cartellone ?";
            // 
            // Entra
            // 
            this.Entra.BackColor = System.Drawing.Color.Yellow;
            this.Entra.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Entra.BackgroundImage")));
            this.Entra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Entra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Entra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Entra.Location = new System.Drawing.Point(30, 33);
            this.Entra.Name = "Entra";
            this.Entra.Size = new System.Drawing.Size(226, 111);
            this.Entra.TabIndex = 3;
            this.Entra.Text = "Super Olfatto per una mostra";
            this.Entra.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Entra.UseVisualStyleBackColor = false;
            this.Entra.Click += new System.EventHandler(this.Entra_Click);
            // 
            // Esci
            // 
            this.Esci.BackColor = System.Drawing.Color.Yellow;
            this.Esci.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Esci.BackgroundImage")));
            this.Esci.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Esci.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Esci.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Esci.Location = new System.Drawing.Point(15, 16);
            this.Esci.Name = "Esci";
            this.Esci.Size = new System.Drawing.Size(120, 62);
            this.Esci.TabIndex = 4;
            this.Esci.Text = "Esci";
            this.Esci.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Esci.UseVisualStyleBackColor = false;
            this.Esci.Click += new System.EventHandler(this.Esci_Click);
            // 
            // Fase
            // 
            this.Fase.AutoSize = true;
            this.Fase.BackColor = System.Drawing.Color.Transparent;
            this.Fase.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fase.ForeColor = System.Drawing.Color.Red;
            this.Fase.Location = new System.Drawing.Point(12, 23);
            this.Fase.Name = "Fase";
            this.Fase.Size = new System.Drawing.Size(247, 37);
            this.Fase.TabIndex = 6;
            this.Fase.Text = "Fase di Coding";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Yellow;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(306, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(226, 111);
            this.button1.TabIndex = 7;
            this.button1.Text = "Super Olfatto per cartellone ?";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Orange;
            this.groupBox1.Controls.Add(this.Entra);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(244, 176);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(555, 179);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            // 
            // BenvenutoBarCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(1184, 739);
            this.Controls.Add(this.Fase);
            this.Controls.Add(this.groupBox1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "BenvenutoBarCode";
            this.Text = "Benvenuto - Fase di Coding";
            this.Load += new System.EventHandler(this.BenvenutoBarCode_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grouppoControl, 0);
            this.Controls.SetChildIndex(this.Fase, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.Controls.SetChildIndex(this.pictureBoxPost2, 0);
            this.Controls.SetChildIndex(this.textBoxPost, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            this.Controls.SetChildIndex(this.pictureBoxPost1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).EndInit();
            this.grouppoControl.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MainButton Entra;
        private ControlButton Esci;
        private System.Windows.Forms.Label Fase;
        private MainButton button1;
        private System.Windows.Forms.GroupBox groupBox1;

    }
}


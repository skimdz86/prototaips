namespace TalkingPaper.Authoring
{
    partial class BenvenutoAuthoring
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BenvenutoAuthoring));
            this.button1 = new TalkingPaper.MainButton();
            this.Entra = new TalkingPaper.MainButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Menu = new TalkingPaper.ControlButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).BeginInit();
            this.grouppoControl.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grouppoControl
            // 
            this.grouppoControl.Controls.Add(this.Menu);
            this.grouppoControl.Location = new System.Drawing.Point(1018, 12);
            this.grouppoControl.Size = new System.Drawing.Size(154, 91);
            // 
            // sottotitolo
            // 
            this.sottotitolo.Size = new System.Drawing.Size(334, 33);
            this.sottotitolo.Text = "Associa il super potere";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Yellow;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(24, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(226, 111);
            this.button1.TabIndex = 11;
            this.button1.Text = "Tagging di un poster singolo";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Entra
            // 
            this.Entra.BackColor = System.Drawing.Color.Yellow;
            this.Entra.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Entra.BackgroundImage")));
            this.Entra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Entra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Entra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Entra.Location = new System.Drawing.Point(293, 13);
            this.Entra.Name = "Entra";
            this.Entra.Size = new System.Drawing.Size(226, 111);
            this.Entra.TabIndex = 8;
            this.Entra.Text = "Tagging di una mostra";
            this.Entra.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Entra.UseVisualStyleBackColor = false;
            this.Entra.Click += new System.EventHandler(this.Entra_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Orange;
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.Entra);
            this.groupBox1.Location = new System.Drawing.Point(286, 251);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(538, 138);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.Color.Yellow;
            this.Menu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Menu.BackgroundImage")));
            this.Menu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Menu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Menu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Menu.Location = new System.Drawing.Point(17, 14);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(120, 62);
            this.Menu.TabIndex = 1;
            this.Menu.Text = "Menu";
            this.Menu.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Menu.UseVisualStyleBackColor = false;
            // 
            // BenvenutoAuthoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 739);
            this.Controls.Add(this.groupBox1);
            this.Name = "BenvenutoAuthoring";
            this.Text = "BenvenutoAuthoring";
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

        private MainButton button1;
        private MainButton Entra;
        private System.Windows.Forms.GroupBox groupBox1;
        private ControlButton Menu;
    }
}
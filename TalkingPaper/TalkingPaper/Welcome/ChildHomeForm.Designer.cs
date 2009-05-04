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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChildHomeForm));
            this.Esci = new TalkingPaper.ControlButton();
            this.button2 = new TalkingPaper.MainButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.test_button = new TalkingPaper.MainButton();
            this.label3 = new System.Windows.Forms.Label();
            this.parlaSchema = new TalkingPaper.MainButton();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            //((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).BeginInit();
            //this.grouppoControl.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grouppoControl
            // 
            //this.grouppoControl.Controls.Add(this.Esci);
            //this.grouppoControl.Location = new System.Drawing.Point(1018, 12);
            //this.grouppoControl.Size = new System.Drawing.Size(154, 91);
            // 
            // sottotitolo
            // 
            this.sottotitolo.Size = new System.Drawing.Size(322, 33);
            this.sottotitolo.Text = "Menu: cosa vuoi fare?";
            // 
            // Esci
            // 
            this.Esci.BackColor = System.Drawing.Color.Yellow;
            this.Esci.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Esci.BackgroundImage")));
            this.Esci.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Esci.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Esci.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.Esci.Location = new System.Drawing.Point(21, 19);
            this.Esci.Name = "Esci";
            this.Esci.Size = new System.Drawing.Size(96, 49);
            this.Esci.TabIndex = 6;
            this.Esci.Text = "Esci";
            this.Esci.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Esci.UseVisualStyleBackColor = false;
            this.Esci.Click += new System.EventHandler(this.Esci_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Yellow;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(30, 58);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(180, 88);
            this.button2.TabIndex = 2;
            this.button2.Text = "Nuovo Cartellone";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Orange;
            this.groupBox1.Controls.Add(this.test_button);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Location = new System.Drawing.Point(28, 172);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(540, 195);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // test_button
            // 
            this.test_button.BackColor = System.Drawing.Color.Yellow;
            this.test_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("test_button.BackgroundImage")));
            this.test_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.test_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.test_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.test_button.Location = new System.Drawing.Point(278, 58);
            this.test_button.Name = "test_button";
            this.test_button.Size = new System.Drawing.Size(180, 88);
            this.test_button.TabIndex = 14;
            this.test_button.Text = "Modifica Cartellone";
            this.test_button.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.test_button.UseVisualStyleBackColor = false;
            this.test_button.Click += new System.EventHandler(this.test_button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(25, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(384, 29);
            this.label3.TabIndex = 13;
            this.label3.Text = "Crea o modifica il tuo cartellone";
            // 
            // parlaSchema
            // 
            this.parlaSchema.BackColor = System.Drawing.Color.Yellow;
            this.parlaSchema.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("parlaSchema.BackgroundImage")));
            this.parlaSchema.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.parlaSchema.Cursor = System.Windows.Forms.Cursors.Hand;
            this.parlaSchema.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.parlaSchema.Location = new System.Drawing.Point(30, 73);
            this.parlaSchema.Name = "parlaSchema";
            this.parlaSchema.Size = new System.Drawing.Size(180, 88);
            this.parlaSchema.TabIndex = 14;
            this.parlaSchema.Text = "Fai Parlare Cartellone";
            this.parlaSchema.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.parlaSchema.UseVisualStyleBackColor = false;
            this.parlaSchema.Click += new System.EventHandler(this.parlaSchema_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(25, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(327, 29);
            this.label4.TabIndex = 13;
            this.label4.Text = "Fai parlare il tuo cartellone";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DarkOrange;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(491, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(226, 111);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 44;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Orange;
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.parlaSchema);
            this.groupBox2.Location = new System.Drawing.Point(28, 396);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(540, 195);
            this.groupBox2.TabIndex = 45;
            this.groupBox2.TabStop = false;
            // 
            // ChildHomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(1036, 739);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ChildHomeForm";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Welcome_Load);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            //this.Controls.SetChildIndex(this.grouppoControl, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            //this.Controls.SetChildIndex(this.pictureBoxPost1, 0);
            //this.Controls.SetChildIndex(this.pictureBoxPost2, 0);
            //this.Controls.SetChildIndex(this.textBoxPost, 0);
            //this.Controls.SetChildIndex(this.groupBox2, 0);
            //((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).EndInit();
            //this.grouppoControl.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlButton Esci;
        private MainButton button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private MainButton parlaSchema;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private MainButton test_button;
    }
}
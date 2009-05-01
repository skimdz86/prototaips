namespace TalkingPaper
{
    partial class TestForm
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonTest = new System.Windows.Forms.Button();
            this.labelTest1 = new System.Windows.Forms.Label();
            this.labelTest2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(55, 25);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(75, 23);
            this.buttonTest.TabIndex = 0;
            this.buttonTest.Text = "Test";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // labelTest1
            // 
            this.labelTest1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelTest1.Location = new System.Drawing.Point(23, 69);
            this.labelTest1.Name = "labelTest1";
            this.labelTest1.Size = new System.Drawing.Size(137, 15);
            this.labelTest1.TabIndex = 1;
            // 
            // labelTest2
            // 
            this.labelTest2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelTest2.Location = new System.Drawing.Point(23, 95);
            this.labelTest2.Name = "labelTest2";
            this.labelTest2.Size = new System.Drawing.Size(137, 15);
            this.labelTest2.TabIndex = 2;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(189, 145);
            this.Controls.Add(this.labelTest2);
            this.Controls.Add(this.labelTest1);
            this.Controls.Add(this.buttonTest);
            this.Name = "TestForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "I test di yan";
            this.Load += new System.EventHandler(this.TestForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.Label labelTest1;
        private System.Windows.Forms.Label labelTest2;
    }
}
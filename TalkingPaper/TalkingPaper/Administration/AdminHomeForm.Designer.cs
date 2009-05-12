namespace TalkingPaper.Administration
{
    partial class AdminHomeForm
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
            this.nuovaGriglia = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.EliminaPoster = new System.Windows.Forms.Button();
            this.modificaGriglia = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.configRfid = new System.Windows.Forms.Button();
            this.boxSotto.SuspendLayout();
            this.boxSopra.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sottotitolo
            // 
            this.sottotitolo.Size = new System.Drawing.Size(248, 33);
            this.sottotitolo.Text = "Amministrazione";
            // 
            // home
            // 
            this.home.Text = "Logout";
            this.home.Click += new System.EventHandler(this.logout_Click);
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
            // nuovaGriglia
            // 
            this.nuovaGriglia.BackColor = System.Drawing.Color.Yellow;
            this.nuovaGriglia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nuovaGriglia.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nuovaGriglia.Location = new System.Drawing.Point(114, 37);
            this.nuovaGriglia.Name = "nuovaGriglia";
            this.nuovaGriglia.Size = new System.Drawing.Size(202, 109);
            this.nuovaGriglia.TabIndex = 4;
            this.nuovaGriglia.Text = "Nuova Griglia";
            this.nuovaGriglia.UseVisualStyleBackColor = false;
            this.nuovaGriglia.Click += new System.EventHandler(this.nuovaGriglia_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(8, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(454, 55);
            this.label3.TabIndex = 21;
            this.label3.Text = "Cartellone Parlante";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Orange;
            this.groupBox3.Controls.Add(this.EliminaPoster);
            this.groupBox3.Controls.Add(this.modificaGriglia);
            this.groupBox3.Controls.Add(this.nuovaGriglia);
            this.groupBox3.Location = new System.Drawing.Point(278, 227);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(409, 490);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            // 
            // EliminaPoster
            // 
            this.EliminaPoster.BackColor = System.Drawing.Color.Yellow;
            this.EliminaPoster.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EliminaPoster.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EliminaPoster.Location = new System.Drawing.Point(114, 347);
            this.EliminaPoster.Name = "EliminaPoster";
            this.EliminaPoster.Size = new System.Drawing.Size(202, 109);
            this.EliminaPoster.TabIndex = 7;
            this.EliminaPoster.Text = "Elimina Poster";
            this.EliminaPoster.UseVisualStyleBackColor = false;
            this.EliminaPoster.Click += new System.EventHandler(this.EliminaPoster_Click);
            // 
            // modificaGriglia
            // 
            this.modificaGriglia.BackColor = System.Drawing.Color.Yellow;
            this.modificaGriglia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.modificaGriglia.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modificaGriglia.Location = new System.Drawing.Point(114, 193);
            this.modificaGriglia.Name = "modificaGriglia";
            this.modificaGriglia.Size = new System.Drawing.Size(202, 109);
            this.modificaGriglia.TabIndex = 5;
            this.modificaGriglia.Text = "Modifica Griglia";
            this.modificaGriglia.UseVisualStyleBackColor = false;
            this.modificaGriglia.Click += new System.EventHandler(this.modificaGriglia_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(293, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 32);
            this.label1.TabIndex = 33;
            this.label1.Text = "Benvenuto ";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Orange;
            this.groupBox1.Controls.Add(this.configRfid);
            this.groupBox1.Location = new System.Drawing.Point(738, 227);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 177);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // configRfid
            // 
            this.configRfid.BackColor = System.Drawing.Color.Yellow;
            this.configRfid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.configRfid.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.configRfid.Location = new System.Drawing.Point(37, 37);
            this.configRfid.Name = "configRfid";
            this.configRfid.Size = new System.Drawing.Size(202, 109);
            this.configRfid.TabIndex = 4;
            this.configRfid.Text = "Configura lettore Rfid";
            this.configRfid.UseVisualStyleBackColor = false;
            this.configRfid.Visible = false;
            this.configRfid.Click += new System.EventHandler(this.configRfid_Click);
            // 
            // AdminHomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(1036, 732);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label3);
            this.Name = "AdminHomeForm";
            this.Text = "FormAmministrazione";
            this.Controls.SetChildIndex(this.boxSopra, 0);
            this.Controls.SetChildIndex(this.boxSotto, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            this.boxSotto.ResumeLayout(false);
            this.boxSotto.PerformLayout();
            this.boxSopra.ResumeLayout(false);
            this.boxSopra.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button nuovaGriglia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button EliminaPoster;
        private System.Windows.Forms.Button modificaGriglia;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button configRfid;
    }
}